using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib.Btp {

    public class BtpField : Field {

        public string elementType { get; set; }

        public string elementChoice { get; set; }

        public bool mirrorIndicator { get; set; }

        public string orientation { get; set; }

        public int sizeHeight { get; set; }

        public int sizeWidth { get; set; }

        public string commonData { get; set; }

        public string colourData { get; set; }

    }
}
