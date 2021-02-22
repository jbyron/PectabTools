using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {
    public class Fields : IEnumerable<Field> {

        #region Data

        private SortedDictionary<int, Field> _col = new SortedDictionary<int, Field>();

        #endregion

        #region Constructor

        public Fields() { }

        public Fields( IEnumerable<Field> list ) {
            foreach ( Field fld in list ) {
                _col.Add( int.Parse( fld.ident, System.Globalization.NumberStyles.HexNumber ), fld );
            }
        }

        #endregion

        #region Operators

        public Field this[string ident] {
            get {
                if ( _col.ContainsKey( int.Parse(ident, System.Globalization.NumberStyles.HexNumber ) ) ) {
                    return _col[int.Parse( ident, System.Globalization.NumberStyles.HexNumber )];
                } else {
                    throw new ArgumentException( "Item ident does not exist in collection" );
                }
            }
        }

        #endregion

        #region Properties

        public int count { get { return _col.Count; } }

        #endregion

        #region Methods

        public void add( Field field, bool overrideExisting = false ) {
            if ( overrideExisting && _col.ContainsKey( int.Parse(field.ident, System.Globalization.NumberStyles.HexNumber ) ) ) {
                _col[int.Parse( field.ident, System.Globalization.NumberStyles.HexNumber )] = field;
            } else {
                _col.Add( int.Parse( field.ident, System.Globalization.NumberStyles.HexNumber ), field );
            }
            return;
        }

        #endregion

        #region IEnumerable

        public IEnumerator<Field> GetEnumerator() {
            return _col.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _col.Values.GetEnumerator();
        }

        #endregion

    }
}
