using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {

    public class PrintPositions : IEnumerable<PrintPosition> {

        #region Data

        private List<PrintPosition> _col = new List<PrintPosition>();

        #endregion

        #region Constructor

        public PrintPositions() { }

        public PrintPositions( IEnumerable<PrintPosition> list ) {
            foreach ( PrintPosition pos in list ) {
                _col.Add( pos );
            }
        }

        #endregion

        #region Operators

        public PrintPosition this[int index] {
            get {
                return _col[index];
            }
        }

        #endregion

        #region Properties

        public int count { get { return _col.Count; } }

        #endregion

        #region Methods

        public void add( PrintPosition pos ) {
            _col.Add( pos );
            return;
        }

        #endregion

        #region IEnumarable

        public IEnumerator<PrintPosition> GetEnumerator() {
            return _col.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _col.GetEnumerator();
        }

        #endregion

    }
}
