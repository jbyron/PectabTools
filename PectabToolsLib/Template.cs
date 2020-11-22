using System;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {
    public class Template {

        private Document _document = null;


        public string name { get; set; }

        public Document document {
            get { return _document.Clone(); }
            set { _document = value; }
        }

    }
}
