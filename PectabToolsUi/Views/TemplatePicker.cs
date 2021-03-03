using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PectabTools.Ui.Views {
    public partial class TemplatePicker : Form {

        public TemplatePicker() {
            InitializeComponent();
        }

        private void btnOk_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
