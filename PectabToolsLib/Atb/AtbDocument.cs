using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib.Atb {
    public class AtbDocument : Document {

        #region Constructor

        public AtbDocument() {
            base.defaultTemplateName = "ATB-8inch-document-tearaway";
        }

        #endregion

        #region Properties

        public string unreadableCharReplace { get; set; }

        public string formatCodeVersion { get; set; }

        public string atbprSteeringCmd { get; set; }

        public string steeringCmdLogo { get; set; }

        public string steeringCmdColour { get; set; }

        public string transactionCodeTicket { get; set; }

        public string transactionCodeCheckin { get; set; }

        public string transactionCodeBoard { get; set; }

        #endregion

    }
}
