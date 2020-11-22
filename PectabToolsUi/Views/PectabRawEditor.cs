using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PectabToolsUi.Views {
    public partial class PectabRawEditor : Form {

        #region Constructor

        public PectabRawEditor() {
            InitializeComponent();
        }

        #endregion

        #region Event Procs

        private void PectabRawEditor_Load( object sender, EventArgs e ) {
            return;
        }

        private void btnSave_Click( object sender, EventArgs e ) {

            switch ( tbcMain.TabPages[tbcMain.SelectedIndex].Name.ToLower() ) {
                case "tbppectab":
                case "tbpdocsetup":
                case "tbpgrid":
                case "tbpjson":
                case "tbpcsv":
                default:
                    break;
            }

            return;
        }

        private void btnRevert_Click( object sender, EventArgs e ) {
            return;
        }

        private void tbcMain_Selected( object sender, TabControlEventArgs e ) {
            return;
        }

        #endregion

    }
}
