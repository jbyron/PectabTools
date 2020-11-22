using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace PectabTools.Lib {
    public class Field {

        #region Data

        private static ILogger _log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        public string ident { get; set; }

        public string name { get; set; }

        /// <summary>Set to False to prevent the field from being rendered in the output PECTAB</summary>
        public bool visible { get; set; } = true;

        public string positionRelativeToRegion { get; set; }

        public PrintPositions printPositionsRelative { get; set; } = new PrintPositions();

        #endregion

    }
}
