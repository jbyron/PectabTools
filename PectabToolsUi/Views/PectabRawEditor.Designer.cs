namespace PectabToolsUi.Views {
    partial class PectabRawEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PectabRawEditor));
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpPectab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbPectab = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbSampleData = new System.Windows.Forms.RichTextBox();
            this.tbpDocSetup = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvwDocSetupRegions = new System.Windows.Forms.TreeView();
            this.lvwDocSetupRegionView = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboDocSetupType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPaperHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaperWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboDocSetupTemplate = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpGrid = new System.Windows.Forms.TabPage();
            this.tbpJson = new System.Windows.Forms.TabPage();
            this.tbpCsv = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tbpPectab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbpDocSetup.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tbpPectab);
            this.tbcMain.Controls.Add(this.tbpDocSetup);
            this.tbcMain.Controls.Add(this.tbpGrid);
            this.tbcMain.Controls.Add(this.tbpJson);
            this.tbcMain.Controls.Add(this.tbpCsv);
            this.tbcMain.Location = new System.Drawing.Point(2, 2);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(716, 263);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcMain_Selected);
            // 
            // tbpPectab
            // 
            this.tbpPectab.Controls.Add(this.splitContainer1);
            this.tbpPectab.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbpPectab.Location = new System.Drawing.Point(4, 24);
            this.tbpPectab.Name = "tbpPectab";
            this.tbpPectab.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPectab.Size = new System.Drawing.Size(708, 235);
            this.tbpPectab.TabIndex = 0;
            this.tbpPectab.Text = "PECTAB";
            this.tbpPectab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(702, 229);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbPectab);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PECTAB";
            // 
            // rtbPectab
            // 
            this.rtbPectab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbPectab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPectab.Location = new System.Drawing.Point(3, 16);
            this.rtbPectab.Name = "rtbPectab";
            this.rtbPectab.Size = new System.Drawing.Size(696, 103);
            this.rtbPectab.TabIndex = 0;
            this.rtbPectab.Text = resources.GetString("rtbPectab.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbSampleData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 103);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample Data";
            // 
            // rtbSampleData
            // 
            this.rtbSampleData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSampleData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSampleData.Location = new System.Drawing.Point(3, 16);
            this.rtbSampleData.Name = "rtbSampleData";
            this.rtbSampleData.Size = new System.Drawing.Size(696, 84);
            this.rtbSampleData.TabIndex = 0;
            this.rtbSampleData.Text = "BTP010301#018P9999#03YYZ#048P123#058P456#06YUL#08YYQ#09YYQ#0AABCDEF#0BMAILLET, NI" +
    "CK#0C0622123457#0DREGULAR#0ECONFIRMED#0FVIP#13SEP/18/2015#1407:00#1ASSSS#2CYWG#";
            // 
            // tbpDocSetup
            // 
            this.tbpDocSetup.Controls.Add(this.groupBox6);
            this.tbpDocSetup.Controls.Add(this.groupBox5);
            this.tbpDocSetup.Controls.Add(this.groupBox4);
            this.tbpDocSetup.Controls.Add(this.groupBox3);
            this.tbpDocSetup.Location = new System.Drawing.Point(4, 24);
            this.tbpDocSetup.Name = "tbpDocSetup";
            this.tbpDocSetup.Size = new System.Drawing.Size(708, 235);
            this.tbpDocSetup.TabIndex = 4;
            this.tbpDocSetup.Text = "Document Setup";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.splitContainer2);
            this.groupBox6.Location = new System.Drawing.Point(3, 208);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(783, 171);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Regions";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 19);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvwDocSetupRegions);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvwDocSetupRegionView);
            this.splitContainer2.Size = new System.Drawing.Size(777, 149);
            this.splitContainer2.SplitterDistance = 259;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.Text = "splitContainer2";
            // 
            // tvwDocSetupRegions
            // 
            this.tvwDocSetupRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDocSetupRegions.Location = new System.Drawing.Point(0, 0);
            this.tvwDocSetupRegions.Name = "tvwDocSetupRegions";
            this.tvwDocSetupRegions.Size = new System.Drawing.Size(259, 149);
            this.tvwDocSetupRegions.TabIndex = 0;
            // 
            // lvwDocSetupRegionView
            // 
            this.lvwDocSetupRegionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDocSetupRegionView.HideSelection = false;
            this.lvwDocSetupRegionView.Location = new System.Drawing.Point(0, 0);
            this.lvwDocSetupRegionView.Name = "lvwDocSetupRegionView";
            this.lvwDocSetupRegionView.Size = new System.Drawing.Size(514, 149);
            this.lvwDocSetupRegionView.TabIndex = 0;
            this.lvwDocSetupRegionView.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboDocSetupType);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(3, 102);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(274, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Type";
            // 
            // cboDocSetupType
            // 
            this.cboDocSetupType.FormattingEnabled = true;
            this.cboDocSetupType.Location = new System.Drawing.Point(75, 30);
            this.cboDocSetupType.Name = "cboDocSetupType";
            this.cboDocSetupType.Size = new System.Drawing.Size(193, 23);
            this.cboDocSetupType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Doc Type: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPaperHeight);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtPaperWidth);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(315, 102);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Paper Dimensions";
            // 
            // txtPaperHeight
            // 
            this.txtPaperHeight.Location = new System.Drawing.Point(123, 62);
            this.txtPaperHeight.Name = "txtPaperHeight";
            this.txtPaperHeight.Size = new System.Drawing.Size(100, 23);
            this.txtPaperHeight.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Paper Height (mm): ";
            // 
            // txtPaperWidth
            // 
            this.txtPaperWidth.Location = new System.Drawing.Point(123, 33);
            this.txtPaperWidth.Name = "txtPaperWidth";
            this.txtPaperWidth.Size = new System.Drawing.Size(100, 23);
            this.txtPaperWidth.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Paper Width (mm): ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboDocSetupTemplate);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(3, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(783, 75);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Templates";
            // 
            // cboDocSetupTemplate
            // 
            this.cboDocSetupTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDocSetupTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocSetupTemplate.FormattingEnabled = true;
            this.cboDocSetupTemplate.Location = new System.Drawing.Point(134, 37);
            this.cboDocSetupTemplate.Name = "cboDocSetupTemplate";
            this.cboDocSetupTemplate.Size = new System.Drawing.Size(643, 23);
            this.cboDocSetupTemplate.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(104, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Template: ";
            // 
            // tbpGrid
            // 
            this.tbpGrid.Location = new System.Drawing.Point(4, 24);
            this.tbpGrid.Name = "tbpGrid";
            this.tbpGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGrid.Size = new System.Drawing.Size(708, 235);
            this.tbpGrid.TabIndex = 1;
            this.tbpGrid.Text = "Grid";
            this.tbpGrid.UseVisualStyleBackColor = true;
            // 
            // tbpJson
            // 
            this.tbpJson.Location = new System.Drawing.Point(4, 24);
            this.tbpJson.Name = "tbpJson";
            this.tbpJson.Size = new System.Drawing.Size(708, 235);
            this.tbpJson.TabIndex = 3;
            this.tbpJson.Text = "Json";
            // 
            // tbpCsv
            // 
            this.tbpCsv.Location = new System.Drawing.Point(4, 24);
            this.tbpCsv.Name = "tbpCsv";
            this.tbpCsv.Size = new System.Drawing.Size(708, 235);
            this.tbpCsv.TabIndex = 2;
            this.tbpCsv.Text = "Csv";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(558, 271);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.Location = new System.Drawing.Point(639, 271);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 23);
            this.btnRevert.TabIndex = 2;
            this.btnRevert.Text = "&Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // PectabRawEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnRevert;
            this.ClientSize = new System.Drawing.Size(719, 306);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbcMain);
            this.Name = "PectabRawEditor";
            this.Text = "PectabRawEditor";
            this.Load += new System.EventHandler(this.PectabRawEditor_Load);
            this.tbcMain.ResumeLayout(false);
            this.tbpPectab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tbpDocSetup.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpPectab;
        private System.Windows.Forms.TabPage tbpGrid;
        private System.Windows.Forms.TabPage tbpJson;
        private System.Windows.Forms.TabPage tbpCsv;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbPectab;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbSampleData;
        private System.Windows.Forms.TabPage tbpDocSetup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboDocSetupTemplate;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboDocSetupType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPaperHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaperWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvwDocSetupRegions;
        private System.Windows.Forms.ListView lvwDocSetupRegionView;
    }
}
