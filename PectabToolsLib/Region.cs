using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {
    public class Region {

        public string name { get; set; }

        /// <summary>The name of the region this item's coordinate relate to. Null indicates this is the #document region</summary>
        public string coordRelativeTo { get; set; }

        public int lowCoordX { get; set; }

        public int lowCoordY { get; set; }

        public int highCoordX { get; set; }

        public int highCoordY { get; set; }

    }
}
