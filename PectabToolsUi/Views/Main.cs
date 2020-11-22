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

        private void mnuToolsPectabRaw_Click(object sender, EventArgs e) {
            PectabRawEditor frm = new PectabRawEditor();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion

    }
}
