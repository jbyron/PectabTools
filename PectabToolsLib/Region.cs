using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {
    public class Region {

        public string name { get; set; }

        /// <summary>The name of the region this item's coordinate relate to. Null indicates this is the #document region</summary>
        public string positionRelativeToRegion { get; set; }

        public PrintPosition printPositionRelative { get; set; } = new PrintPosition() { row = "0", column = "0" };

    }
}
