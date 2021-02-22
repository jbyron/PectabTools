using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {

    public class BarcodeField : Field {

        public enum BarcodeTypes {
            None,
            Pdf417,
            Aztec,
            Qr
        }

        public enum BarcodeOrientations {
            Horizontal,
            Vertical
        }

        public BarcodeTypes barcodeType { get; set; } = BarcodeTypes.None;

        public BarcodeOrientations orientation { get; set; } = BarcodeOrientations.Horizontal;



    }
}
