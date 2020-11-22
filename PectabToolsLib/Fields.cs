using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {
    public class Fields : IEnumerable<Field> {

        #region Data

        private Dictionary<string, Field> _col = new Dictionary<string, Field>();

        #endregion

        #region Constructor

        public Fields() { }

        public Fields( IEnumerable<Field> list ) {
            foreach ( Field fld in list ) {
                _col.Add( fld.ident, fld );
            }
        }

        #endregion

        #region Operators

        public Field this[string ident] {
            get {
                if ( _col.ContainsKey( ident ) ) {
                    return _col[ident];
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
            if ( overrideExisting && _col.ContainsKey( field.ident ) ) {
                _col[field.ident] = field;
            } else {
                _col.Add( field.ident, field );
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
