

using Utilities;

namespace Designer
{
    partial class frmDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportBrowse = new System.Windows.Forms.Button();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtImportFilename = new System.Windows.Forms.TextBox();
            this.txtIJFExportFilename = new System.Windows.Forms.TextBox();
            this.btnIJFExportBrowse = new System.Windows.Forms.Button();
            this.lblIJFExportFilename = new System.Windows.Forms.Label();
            this.lblEuroJudoFile = new System.Windows.Forms.Label();
            this.txtEuroJudoExportFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoFileBrowse = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chkImportHasHeaders = new System.Windows.Forms.CheckBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblSplitCharacter = new System.Windows.Forms.Label();
            this.cmbSplitCharacters = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportBrowse
            // 
            this.btnImportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportBrowse.Location = new System.Drawing.Point(533, 12);
            this.btnImportBrowse.Name = "btnImportBrowse";
            this.btnImportBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnImportBrowse.TabIndex = 0;
            this.btnImportBrowse.Text = "...";
            this.btnImportBrowse.UseVisualStyleBackColor = true;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(12, 17);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(130, 13);
            this.lblImport.TabIndex = 1;
            this.lblImport.Text = "Revolutionise file to import";
            // 
            // txtImportFilename
            // 
            this.txtImportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportFilename.Location = new System.Drawing.Point(148, 14);
            this.txtImportFilename.Name = "txtImportFilename";
            this.txtImportFilename.Size = new System.Drawing.Size(379, 20);
            this.txtImportFilename.TabIndex = 2;
            this.txtImportFilename.Text = "C:\\Users\\YourUser\\OneDrive\\VS Projects\\Revolutionise\\Samples\\rev.csv";
            // 
            // txtIJFExportFilename
            // 
            this.txtIJFExportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIJFExportFilename.Location = new System.Drawing.Point(148, 43);
            this.txtIJFExportFilename.Name = "txtIJFExportFilename";
            this.txtIJFExportFilename.Size = new System.Drawing.Size(379, 20);
            this.txtIJFExportFilename.TabIndex = 3;
            // 
            // btnIJFExportBrowse
            // 
            this.btnIJFExportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIJFExportBrowse.Location = new System.Drawing.Point(533, 41);
            this.btnIJFExportBrowse.Name = "btnIJFExportBrowse";
            this.btnIJFExportBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnIJFExportBrowse.TabIndex = 4;
            this.btnIJFExportBrowse.Text = "...";
            this.btnIJFExportBrowse.UseVisualStyleBackColor = true;
            // 
            // lblIJFExportFilename
            // 
            this.lblIJFExportFilename.AutoSize = true;
            this.lblIJFExportFilename.Location = new System.Drawing.Point(12, 46);
            this.lblIJFExportFilename.Name = "lblIJFExportFilename";
            this.lblIJFExportFilename.Size = new System.Drawing.Size(81, 13);
            this.lblIJFExportFilename.TabIndex = 5;
            this.lblIJFExportFilename.Text = "IJF file to export";
            // 
            // lblEuroJudoFile
            // 
            this.lblEuroJudoFile.AutoSize = true;
            this.lblEuroJudoFile.Location = new System.Drawing.Point(12, 75);
            this.lblEuroJudoFile.Name = "lblEuroJudoFile";
            this.lblEuroJudoFile.Size = new System.Drawing.Size(115, 13);
            this.lblEuroJudoFile.TabIndex = 6;
            this.lblEuroJudoFile.Text = "Euro Judo file to export";
            // 
            // txtEuroJudoExportFilename
            // 
            this.txtEuroJudoExportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoExportFilename.Location = new System.Drawing.Point(148, 72);
            this.txtEuroJudoExportFilename.Name = "txtEuroJudoExportFilename";
            this.txtEuroJudoExportFilename.Size = new System.Drawing.Size(379, 20);
            this.txtEuroJudoExportFilename.TabIndex = 7;
            // 
            // btnEuroJudoFileBrowse
            // 
            this.btnEuroJudoFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoFileBrowse.Location = new System.Drawing.Point(533, 70);
            this.btnEuroJudoFileBrowse.Name = "btnEuroJudoFileBrowse";
            this.btnEuroJudoFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoFileBrowse.TabIndex = 8;
            this.btnEuroJudoFileBrowse.Text = "...";
            this.btnEuroJudoFileBrowse.UseVisualStyleBackColor = true;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(483, 99);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // chkImportHasHeaders
            // 
            this.chkImportHasHeaders.AutoSize = true;
            this.chkImportHasHeaders.Location = new System.Drawing.Point(15, 103);
            this.chkImportHasHeaders.Name = "chkImportHasHeaders";
            this.chkImportHasHeaders.Size = new System.Drawing.Size(158, 17);
            this.chkImportHasHeaders.TabIndex = 10;
            this.chkImportHasHeaders.Text = "First row is column headings";
            this.chkImportHasHeaders.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AllowUserToOrderColumns = true;
            this.DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(13, 127);
            this.DataGridView.Name = "DataGridView";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.Size = new System.Drawing.Size(545, 300);
            this.DataGridView.TabIndex = 11;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(483, 433);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // lblSplitCharacter
            // 
            this.lblSplitCharacter.AutoSize = true;
            this.lblSplitCharacter.Location = new System.Drawing.Point(199, 103);
            this.lblSplitCharacter.Name = "lblSplitCharacter";
            this.lblSplitCharacter.Size = new System.Drawing.Size(76, 13);
            this.lblSplitCharacter.TabIndex = 13;
            this.lblSplitCharacter.Text = "Split Character";
            // 
            // cmbSplitCharacters
            // 
            this.cmbSplitCharacters.FormattingEnabled = true;
            this.cmbSplitCharacters.Items.AddRange(new object[] {
            ",",
            ";",
            "/t"});
            this.cmbSplitCharacters.Location = new System.Drawing.Point(281, 101);
            this.cmbSplitCharacters.Name = "cmbSplitCharacters";
            this.cmbSplitCharacters.Size = new System.Drawing.Size(52, 21);
            this.cmbSplitCharacters.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 468);
            this.Controls.Add(this.cmbSplitCharacters);
            this.Controls.Add(this.lblSplitCharacter);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.chkImportHasHeaders);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnEuroJudoFileBrowse);
            this.Controls.Add(this.txtEuroJudoExportFilename);
            this.Controls.Add(this.lblEuroJudoFile);
            this.Controls.Add(this.lblIJFExportFilename);
            this.Controls.Add(this.btnIJFExportBrowse);
            this.Controls.Add(this.txtIJFExportFilename);
            this.Controls.Add(this.txtImportFilename);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.btnImportBrowse);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "DownShift - Revolutionise export converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportBrowse;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox txtImportFilename;
        private System.Windows.Forms.TextBox txtIJFExportFilename;
        private System.Windows.Forms.Button btnIJFExportBrowse;
        private System.Windows.Forms.Label lblIJFExportFilename;
        private System.Windows.Forms.Label lblEuroJudoFile;
        private System.Windows.Forms.TextBox txtEuroJudoExportFilename;
        private System.Windows.Forms.Button btnEuroJudoFileBrowse;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.CheckBox chkImportHasHeaders;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Label lblSplitCharacter;
        private System.Windows.Forms.ComboBox cmbSplitCharacters;
    }
}

