using System;
using System.Text.Json.Serialization;
using NLog;

namespace PectabTools.Lib {

    public enum DocumentTypes {
        Atb,
        Btp,
        Unknown
    }

    public class Document {

        #region Data

        private static ILogger _log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor

        public Document() {
            fields = new Fields();
            updateDocumentRegion();
        }

        #endregion

        #region Properties

        public string name { get; set; }

        public DocumentTypes pectabType { get; set; }

        public string fieldSeparator { get; set; }

        public float paperWidthMm { get; set; }

        public float paperHeightMm { get; set; }

        public Regions regions { get; set; }

        public virtual Fields fields { get; set; }

        /// <summary>The name of the template to use when loading a document and no template has been provided. For example, when a PECTAB is being imported.</summary>
        public string defaultTemplateName { get; protected set; }

        #endregion

        #region Methods

        public Document Clone() {
            return (Document)this.MemberwiseClone();
        }

        #endregion

        #region Private Procs

        /// <summary>
        /// Creates the region that covers the entire document
        /// </summary>
        private void updateDocumentRegion() {

            if(regions == null) {
                regions = new Regions();
            }
            if ( regions.containsKey( "#document" ) ) {
                _log.Warn( "Attempt to create a '#document' region when region already exists" );

            } else {
                regions.addRegion( new Region() {
                    name = "#document",
                    coordRelativeTo = null,
                    lowCoordX = 0,
                    lowCoordY = 0,
                    highCoordX = (int)paperWidthMm,
                    highCoordY = (int)paperHeightMm,
                } );

            }

            return;
        }

        #endregion

    }
}
