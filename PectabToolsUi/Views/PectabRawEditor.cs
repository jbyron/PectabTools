using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PectabTools.Ui.Models;

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

        #region Properties

        public PectabEditorViewModel documentModel { get; set; }

        #endregion

        #region Methods

        public virtual void Show( Form mdiParent, PectabEditorViewModel docModel ) {

            this.MdiParent = mdiParent;
            this.WindowState = FormWindowState.Maximized;
            base.Show();

        }

        #endregion

    }
}
