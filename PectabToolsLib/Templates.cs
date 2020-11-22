using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PectabTools.Lib.Atb;
using PectabTools.Lib.Btp;

namespace PectabTools.Lib {
    public class Templates : IEnumerable<Template> {

        private Dictionary<string, Template> _col = new Dictionary<string, Template>();



        public Templates() {
            populateTemplatesCollection();
        }




        public int count { get { return _col.Count; } }

        public List<string> templateNames {
            get { return new List<string>( _col.Keys ); }
        }

        #region Methods

        public Template getTemplate( string templateName ) {
            return _col[templateName];
        }

        #endregion

        #region Private Procs

        private bool populateTemplatesCollection() {

            addTemplateBtp19Rec3PogoDoc();
            addTemplateAtb8DocCoupon();
            addTemplateBtp192PogoDocRec();
            addTemplateBtp213PogoDocRec();

            return true;
        }

        private void addTemplateBtp213PogoDocRec() {
            _col.Add( "BTP-21inch-3pogo-document-receipt", new Template() {
                name = "BTP-21inch-3pogo-document-receipt",
                document = new BtpDocument() {
                    name = "BTP-21inch-3pogo-document-receipt",
                    pectabType = DocumentTypes.Btp,
                    paperWidthMm = 53.975F,                 // 21.125" x 2.125"
                    paperHeightMm = 536.575F

                }
            } );

            return;
        }

        private void addTemplateBtp192PogoDocRec() {
            _col.Add( "BTP-19inch-2pogo-document-receipt", new Template() {
                name = "BTP-19inch-2pogo-document-receipt",
                document = new BtpDocument() {
                    name = "BTP-19inch-2pogo-document-receipt",
                    pectabType = DocumentTypes.Btp,
                    paperWidthMm = 53.975F,                 // 18.8125" x 2.125"
                    paperHeightMm = 477.8375F,
                    regions = new Regions(),
                    fields = new Fields(),
                }
            } );

            return;
        }

        private void addTemplateAtb8DocCoupon() {
            _col.Add( "ATB-8inch-document-tearaway", new Template() {
                name = "ATB-8inch-document-tearaway",
                document = new AtbDocument() {
                    name = "ATB-8inch-document-tearaway",
                    pectabType = DocumentTypes.Atb,
                    paperWidthMm = 203.2F,                  // 8x3.25"
                    paperHeightMm = 82.55F,
                    regions = new Regions(),
                    fields = new Fields(),
                }
            } );

            return;
        }

        private void addTemplateBtp19Rec3PogoDoc() {
            _col.Add( "BTP-19inch-receipt-3pogo-document", new Template() {
                name = "BTP-19inch-receipt-3pogo-document",
                document = new BtpDocument() {
                    name = "BTP-19inch-receipt-3pogo-document",
                    pectabType = DocumentTypes.Btp,
                    paperWidthMm = 53.975F,                 // 18.8125" x 2.125"
                    paperHeightMm = 477.8375F,
                    regions = new Regions(),
                    fields = new Fields()
                }
            } );

            return;
        }

        #endregion

        #region IEnumerator 

        public IEnumerator<Template> GetEnumerator() {
            return _col.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _col.Values.GetEnumerator();
        }

        #endregion

    }
}
