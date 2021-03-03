using PectabToolsUi.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PectabTools.Ui.Views {
    public partial class Main : Form {

        #region Constructor

        public Main() {
            InitializeComponent();
        }

        #endregion

        #region Event Procs

        private void Main_Load( object sender, EventArgs e ) {
            return;
        }

        private void mnuFileExit_Click( object sender, EventArgs e ) {
            Environment.Exit( 0 );
        }

        private void mnuHelpAbout_Click( object sender, EventArgs e ) {
            About frm = new About();
            //frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void mnuFileOpen_Click( object sender, EventArgs e ) {
            return;
        }

        private void mnuFileSave_Click( object sender, EventArgs e ) {
            return;
        }

        private void mnuFileSaveAs_Click( object sender, EventArgs e ) {
            return;
        }

        private void mnuFileNewCustom_Click( object sender, EventArgs e ) {
            PectabRawEditor frm = new PectabRawEditor();
            frm.Show( this, new Models.PectabEditorViewModel() );

            return;
        }

        private void mnuFileNewFromTemplate_Click( object sender, EventArgs e ) {
            return;
        }

        #endregion

    }
}
