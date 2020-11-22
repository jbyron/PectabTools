using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib.Btp {
    public class BtpDocument : Document {

        #region Constructor

        public BtpDocument() {
            base.defaultTemplateName = "BTP-21inch-3pogo-document-receipt";
        }

        #endregion

        #region Properties

        public int tableNumber { get; set; }

        public int tableVersion { get; set; }

        public string continuationCharacter { get; set; }

        public string autoIncrementFieldLength { get; set; }

        public string colourCharacter { get; set; }

        public int tagWidth { get; set; }

        public int mirrorPoint { get; set; }

        public string elementReferenceCharacter { get; set; }

        #endregion

    }
}
