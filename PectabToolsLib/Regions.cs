using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PectabTools.Lib {
    public class Regions : IEnumerable<Region> {

        #region Data

        private Dictionary<string, Region> _col = new Dictionary<string, Region>();

        #endregion

        #region Constructor

        public Regions() { }

        public Regions(IEnumerable<Region> list) {
            foreach(Region reg in list) {
                _col.Add( reg.name, reg );
            }
        }

        #endregion

        #region Operators

        public Region this[string ident] {
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

        public bool exists(string regionName) {
            return _col.ContainsKey( regionName );
        }

        public void addRegion(Region region) {
            _col.Add(region.name, region);
        }

        public bool containsKey(string name) {
            return _col.ContainsKey( name );
        }

        #endregion

        #region IEnumerable

        public IEnumerator<Region> GetEnumerator() {
            return _col.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _col.Values.GetEnumerator();
        }

        #endregion
    }
}
