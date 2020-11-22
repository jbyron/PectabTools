using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib.Atb {

    public class AtbField : Field {

        public int maxLength { get; set; }

        public string printRow { get; set; }

        public string printColumn { get; set; }

        public string trackId { get; set; }

        public string trackBlock { get; set; }

        public string trackPosition { get; set; }

        public string elementSteeringCmd { get; set; }

    }
}
