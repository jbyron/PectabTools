using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NLog;
using PectabTools.Lib.Atb;
using PectabTools.Lib.Btp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static PectabTools.Lib.BarcodeField;

namespace PectabTools.Lib.Converters {

    public class PectabConverter {

        #region Data

        private static ILogger _log = LogManager.GetCurrentClassLogger();
        private const string BTP_HEADER_REGEX = @"^BTT(\d\d)(\d\d)(\W)([A-Z])(\W)(\d\d\d)(\d\d\d)(\W)(\W)\d\d";
        private const string BTP_FIELDS_REGEX = @"^([A-F0-9]{2})([A-Z])(\d)(M|\s)([A-Z0-9])(\d{3})(\d{2})(\d{2})(\d{2})(.{0,20})";

        private const string ATB_HEADER_REGEX = @"^PT(\W)\1(\W)([A-Z]\d)([A-Z])\1(\W)(\W)\1([A-Z0-9]{1,5})\1([A-Z0-9]{1,5})\1([A-Z0-9]{1,5})\1";
        private const string ATB_FIELDS_REGEX = @"^([0-9A-F]{2})(\d{2}|B[0-9P-Z])(?:(?:([A-R]{1})(?:(\d{1}\d{1}){1}))*)(((\d{1})(\d{1})(\d\d){1})*)([A-R]{0,1})$";
            //@"^([0-9A-F]{2})(\d{2})(?:(?:([A-R]{1})(?:(\d{1}\d{1}){1}))*)(((\d{1})(\d{1})(\d\d){1})*)([A-R]{0,1})$";
        #endregion

        #region Constructor

        private PectabConverter() { }

        #endregion

        #region Static Methods

        public static string toJson( Document doc ) {
            string fRv = "";

            _log.Trace( "Begin" );

            try {
                initJsonSerializer();
                JsonSerializerSettings stgs = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
                fRv = JsonConvert.SerializeObject( doc, stgs );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        public static Document fromJson( string json ) {
            Document fRv = null;

            _log.Trace( "Begin" );

            try {
                initJsonSerializer();
                JsonSerializerSettings stgs = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
                fRv = JsonConvert.DeserializeObject<Document>( json, stgs );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        public static Document fromPectab( string pectab ) {
            return fromPectab( pectab, null );
        }

        public static Document fromPectab( string pectab, Document docToMerge ) {
            Document fRv = null;

            _log.Trace( "Begin" );

            try {
                switch ( determinePectabType( pectab ) ) {
                    case DocumentTypes.Atb:
                        fRv = fromPectabAtb( pectab, docToMerge );
                        break;
                    case DocumentTypes.Btp:
                        fRv = fromPectabBtp( pectab, docToMerge );
                        break;
                    default:
                        break;
                }

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        public static string toPectab( Document doc ) {
            string fRv = null;

            _log.Trace( "Begin" );

            try {

                switch ( doc.pectabType ) {
                    case DocumentTypes.Atb:
                        fRv = docToPectabAtb( doc );
                        break;
                    case DocumentTypes.Btp:
                        fRv = docToPectabBtp( doc );
                        break;
                    default:
                        throw new ArgumentException( "Cannot convert an unknown document type to a PECTAB" );
                }

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        public static string toPectab( string json ) {
            string fRv = null;

            _log.Trace( "Begin" );

            try {
                Document doc = fromJson( json );
                fRv = toPectab( doc );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        public static DocumentTypes determinePectabType( string pectab ) {
            DocumentTypes fRv = DocumentTypes.Unknown;
            Regex atbCheckRegex = new Regex( @"^PT\W\W" );
            Regex btpCheckRegex = new Regex( @"^BTT\d\d\d\d\W" );

            _log.Trace( "Begin" );

            try {
                pectab = pectab.Trim();
                if ( pectab.Length > 3 ) {
                    if ( atbCheckRegex.IsMatch( pectab ) ) {
                        fRv = DocumentTypes.Atb;
                    } else if ( btpCheckRegex.IsMatch( pectab ) ) {
                        fRv = DocumentTypes.Btp;
                    }
                }
            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        #endregion

        #region Private Procs

        private static AtbDocument fromPectabAtb( string pectab, Document docToMerge ) {
            AtbDocument fRv = (AtbDocument)docToMerge;

            _log.Trace( "Begin" );

            try {
                if ( docToMerge == null ) {
                    fRv = new AtbDocument();
                    fRv = (AtbDocument)(new Templates()).getTemplate( fRv.defaultTemplateName ).document;
                }

                parseAtbHeader( pectab, ref fRv );

                string[] extractedFields = null;
                retrieveAtbFields( pectab, ref fRv, out extractedFields );

                parseAtbFields( pectab, ref fRv, extractedFields );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static void retrieveAtbFields( string pectab, ref AtbDocument docToMerge, out string[] extractedFields ) {

            _log.Trace( "Begin" );

            try {

                string[] fieldsOrig = pectab.Split( new char[] { docToMerge.fieldSeparator.ToCharArray()[0] }, StringSplitOptions.RemoveEmptyEntries );
                extractedFields = new string[fieldsOrig.Length - 6];

                // ignore header
                Array.Copy( fieldsOrig, 6, extractedFields, 0, extractedFields.Length );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return;
        }

        private static void parseAtbFields( string pectab, ref AtbDocument docToMerge, string[] extractedFields ) {

            _log.Trace( "Begin" );

            try {

                Regex reFieldParse = new Regex( ATB_FIELDS_REGEX, RegexOptions.Compiled );

                foreach ( string field in extractedFields ) {

                    Match match = reFieldParse.Match( field );

                    if ( match.Success ) {

                        AtbField newField = new AtbField();

                        newField.ident = match.Groups[1].Value;

                        if ( (match.Groups[2].Value.Length > 0) && (match.Groups[2].Value.Substring( 0, 1 ) == "B") ) {
                            newField.barcodeField = new AtbBarcodeField();
                            newField.barcodeField.barcodeType = getBarcodeAtbByString( match.Groups[2].Value.Substring( 1, 1 ) );

                        } else {
                            newField.maxLength = int.Parse( match.Groups[2].Value );
                        }
                        if ( match.Groups[3].Captures.Count == 0 ) {
                            newField.printPositionsRelative.add( new PrintPosition() {
                                row = match.Groups[3].Value,
                                column = match.Groups[4].Value,
                            } );
                        } else {
                            for ( int i = 0; i < match.Groups[3].Captures.Count; i++) {
                                newField.printPositionsRelative.add( new PrintPosition() {
                                    row = match.Groups[3].Captures[i].Value,
                                    column = match.Groups[4].Captures[i].Value,
                                } );
                            }
                        }
                        newField.trackId = match.Groups[5].Value;
                        newField.trackBlock = match.Groups[6].Value;
                        newField.trackPosition = match.Groups[7].Value;

                        newField.elementSteeringCmd = match.Groups[10].Value;

                        docToMerge.fields.add( newField, true );
                    } else {
                        _log.Warn( "Regex match of BTP field failed: {0}", field );
                    }
                }

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return;
        }

        private static BarcodeTypes getBarcodeAtbByString( string atbBarcodeTypeCode ) {
            BarcodeTypes fRv = BarcodeTypes.None; 

            _log.Trace( "Begin" );

            try {
                atbBarcodeTypeCode = atbBarcodeTypeCode.Trim();

                if ( atbBarcodeTypeCode.Length > 0 ) {
                    switch ( atbBarcodeTypeCode.Substring( 0, 1 ).ToUpper() ) {
                        case "5":   // QR       - Horizontal
                            fRv = BarcodeTypes.Qr;
                            break;

                        case "6":   // PDF417   - Horizontal
                        case "R":   // PDF417   - Vertical
                            fRv = BarcodeTypes.Pdf417;
                            break;

                        case "V":   // Aztec
                            fRv = BarcodeTypes.Aztec;
                            break;

                        default:
                            fRv = BarcodeTypes.None;
                            break;
                    }
                }
            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static BtpDocument fromPectabBtp( string pectab, Document docToMerge ) {
            BtpDocument fRv = (BtpDocument)docToMerge;

            _log.Trace( "Begin" );

            try {
                if ( fRv == null ) {
                    fRv = new BtpDocument();
                    fRv = (BtpDocument)(new Templates()).getTemplate( fRv.defaultTemplateName ).document;
                }

                parseBtpHeader( pectab, ref fRv );

                string[] extractedFields = null;
                retrieveBtpFields( pectab, ref fRv, out extractedFields );

                parseBtpFields( pectab, ref fRv, extractedFields );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static bool parseBtpFields( string pectab, ref BtpDocument docToMerge, string[] extractedFields ) {
            bool fRv = false;

            _log.Trace( "Begin" );

            try {
                Regex reFieldParse = new Regex( BTP_FIELDS_REGEX, RegexOptions.Compiled );

                foreach ( string field in extractedFields ) {

                    Match match = reFieldParse.Match( field );

                    if ( match.Success ) {

                        BtpField newField = new BtpField();
                        newField.positionRelativeToRegion = "#document";
                        newField.ident = match.Groups[1].Value;
                        newField.elementType = match.Groups[2].Value;
                        newField.elementChoice = match.Groups[3].Value;
                        newField.mirrorIndicator = match.Groups[4].Value == "M";
                        newField.orientation = match.Groups[5].Value;
                        newField.printPositionsRelative.add( new PrintPosition() {
                                row = match.Groups[6].Value,
                                column = match.Groups[7].Value
                            });
                        newField.sizeHeight = int.Parse( match.Groups[8].Value );
                        newField.sizeWidth = int.Parse( match.Groups[9].Value );
                        newField.commonData = match.Groups[10].Value;
                        newField.colourData = "";

                        docToMerge.fields.add( newField );
                    } else {
                        _log.Warn( "Regex match of BTP field failed: {0}", field );
                    }
                }

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static bool retrieveBtpFields( string pectab, ref BtpDocument docToMerge, out string[] extractedFields ) {
            bool fRv = false;

            _log.Trace( "Begin" );

            try {
                string[] fieldsOrig = pectab.Split( new char[] { docToMerge.fieldSeparator.ToCharArray()[0] }, StringSplitOptions.RemoveEmptyEntries );
                extractedFields = new string[fieldsOrig.Length - 1];

                Array.Copy( fieldsOrig, 1, extractedFields, 0, extractedFields.Length );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static bool parseAtbHeader(string pectab, ref AtbDocument docToMerge) {
            bool fRv = false;

            _log.Trace( "Begin" );

            try {
                Regex reHeader = new Regex( ATB_HEADER_REGEX );
                Match reHeaderMatch = reHeader.Match( pectab );

                if ( !reHeaderMatch.Success ) {
                    _log.Error( "Could not extract BTP header. Regex failure." );
                } else {
                    docToMerge.fieldSeparator = reHeaderMatch.Groups[1].Value;
                    docToMerge.unreadableCharReplace = reHeaderMatch.Groups[2].Value;
                    docToMerge.formatCodeVersion = reHeaderMatch.Groups[3].Value;
                    docToMerge.atbprSteeringCmd = reHeaderMatch.Groups[4].Value;
                    docToMerge.steeringCmdLogo = reHeaderMatch.Groups[5].Value;
                    docToMerge.steeringCmdColour = reHeaderMatch.Groups[6].Value;
                    docToMerge.transactionCodeTicket = reHeaderMatch.Groups[7].Value;
                    docToMerge.transactionCodeCheckin = reHeaderMatch.Groups[8].Value;
                    docToMerge.transactionCodeBoard = reHeaderMatch.Groups[9].Value;

                    fRv = true;
                }
            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static bool parseBtpHeader( string pectab, ref BtpDocument docToMerge ) {
            bool fRv = false;

            _log.Trace( "Begin" );

            try {
                Regex reHeader = new Regex( BTP_HEADER_REGEX );
                Match reHeaderMatch = reHeader.Match( pectab );

                if ( !reHeaderMatch.Success ) {
                    _log.Error( "Could not extract BTP header. Regex failure." );
                } else {
                    docToMerge.tableNumber = int.Parse( reHeaderMatch.Groups[1].Value );
                    docToMerge.tableVersion = int.Parse( reHeaderMatch.Groups[2].Value );
                    docToMerge.continuationCharacter = reHeaderMatch.Groups[3].Value;
                    docToMerge.autoIncrementFieldLength = reHeaderMatch.Groups[4].Value;
                    docToMerge.colourCharacter = reHeaderMatch.Groups[5].Value;
                    docToMerge.tagWidth = int.Parse( reHeaderMatch.Groups[6].Value );
                    docToMerge.mirrorPoint = int.Parse( reHeaderMatch.Groups[7].Value );
                    docToMerge.elementReferenceCharacter = reHeaderMatch.Groups[8].Value;
                    docToMerge.fieldSeparator = reHeaderMatch.Groups[9].Value;

                    fRv = true;
                }
            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static void initJsonSerializer() {
            JsonConvert.DefaultSettings = () => {
                var serSettings = new JsonSerializerSettings();
                serSettings.Converters.Add( new StringEnumConverter() { AllowIntegerValues = true, NamingStrategy = new CamelCaseNamingStrategy() } );
                return serSettings;
            };
        }

        private static string docToPectabAtb( Document doc ) {
            string fRv = "";

            _log.Trace( "Begin" );

            try {

                throw new NotImplementedException();

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static string docToPectabBtp( Document doc ) {
            string fRv = "";

            _log.Trace( "Begin" );

            try {

                if ( doc is BtpDocument ) {
                    BtpDocument btpDoc = (BtpDocument)doc;
                    fRv = string.Format( "{0}{1}{2}{3}",
                            buildBtpHeader( btpDoc ),
                            btpDoc.fieldSeparator,
                            buildBtpFields( btpDoc ),
                            btpDoc.fieldSeparator
                        );
                } else {
                    throw new ArgumentException( "Must pass in a document of type BtpDocument to build BTP PECTAB" );
                }

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static string buildBtpHeader( BtpDocument btpDoc ) {
            string fRv = "";

            _log.Trace( "Begin" );

            try {

                fRv = string.Format( "BTT{0:D2}{1:D2}{2}{3}{4}{5}{6}{7}",
                        btpDoc.tableNumber,
                        btpDoc.tableVersion,
                        btpDoc.continuationCharacter,
                        btpDoc.autoIncrementFieldLength,
                        btpDoc.colourCharacter,
                        btpDoc.tagWidth,
                        btpDoc.mirrorPoint,
                        btpDoc.elementReferenceCharacter
                    );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static string buildBtpFields( BtpDocument btpDoc ) {
            string fRv = "";

            _log.Trace( "Begin" );

            try {
                List<string> fields = new List<string>();

                foreach(BtpField field in btpDoc.fields) {
                    if ( field.visible ) {
                        fields.Add( string.Format( "{0}{1}{2}{3}{4}{5:D3}{6:D2}{7:D2}{8:D2}{9}{10}",
                                field.ident,
                                field.elementType,
                                field.elementChoice,
                                field.mirrorIndicator ? "M" : " ",
                                field.orientation,
                                int.Parse( calculateFieldPositionVertical( btpDoc, field ) ),
                                int.Parse( calculateFieldPositionHorizontal( btpDoc, field ) ),
                                field.sizeHeight,
                                field.sizeWidth,
                                field.commonData,
                                field.colourData
                            ) );
                    }
                }

                fRv = string.Join( btpDoc.fieldSeparator, fields.ToArray() );

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static string calculateFieldPositionVertical( Document doc, Field field ) {
            string fRv = "0";

            _log.Trace( "Begin" );

            try {
                if ( field is BtpField ) {
                    fRv = string.Format("{0:D}", int.Parse(fRv) + int.Parse( field.printPositionsRelative[0].row ));
                } else {
                    throw new NotImplementedException("Cannot calculate field position - vertical - " + field.GetType().Name );
                }

                Region containingRegion = null;

                if ( field.positionRelativeToRegion != null ) {
                    containingRegion = doc.regions[field.positionRelativeToRegion];
                }

                while ( containingRegion != null ) {

                    if ( field is BtpField ) {
                        fRv = string.Format( "{0:D}", int.Parse( fRv ) + int.Parse(containingRegion.printPositionRelative.row ) );
                    } else {
                        throw new NotImplementedException( "Cannot calculate field position - vertical - " + field.GetType().Name );
                    }

                    if ( containingRegion.positionRelativeToRegion != null ) {
                        containingRegion = doc.regions[containingRegion.positionRelativeToRegion];
                    } else {
                        containingRegion = null;
                    }
                }

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        private static string calculateFieldPositionHorizontal( Document doc, Field field ) {
            string fRv = "0";

            _log.Trace( "Begin" );

            try {
                if ( field is BtpField ) {
                    fRv = string.Format( "{0:D}", int.Parse( fRv ) + int.Parse( field.printPositionsRelative[0].column ) );
                } else {
                    throw new NotImplementedException( "Cannot calculate field position - vertical - " + field.GetType().Name );
                }

                Region containingRegion = null;

                if ( field.positionRelativeToRegion != null ) {
                    containingRegion = doc.regions[field.positionRelativeToRegion];
                }

                while ( containingRegion != null ) {

                    if ( field is BtpField ) {
                        fRv = string.Format( "{0:D}", int.Parse( fRv ) + int.Parse( containingRegion.printPositionRelative.column ) );
                    } else {
                        throw new NotImplementedException( "Cannot calculate field position - vertical - " + field.GetType().Name );
                    }

                    if ( containingRegion.positionRelativeToRegion != null ) {
                        containingRegion = doc.regions[containingRegion.positionRelativeToRegion];
                    } else {
                        containingRegion = null;
                    }
                }

            } catch ( Exception ex ) {
                _log.Error( ex, "Caught Exception" );
                throw;
            } finally {
                _log.Trace( "Done" );
            }

            return fRv;
        }

        #endregion
    }
}
