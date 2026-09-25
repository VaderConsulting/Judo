namespace Designer
{
    partial class frmOptions
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
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtEuroJudoDatabaseFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoDatabaseBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIJFExportFilename = new System.Windows.Forms.Label();
            this.txtIJFExportFilename = new System.Windows.Forms.TextBox();
            this.btnIJFExportBrowse = new System.Windows.Forms.Button();
            this.lblEuroJudoFile = new System.Windows.Forms.Label();
            this.txtEuroJudoExportFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoSaveFileBrowse = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEuroJudoSubDivisionFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoSubDivisionsFileBrowse = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEuroJudoCountriesFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoCountriesFileBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEuroJudoClubsFilename = new System.Windows.Forms.TextBox();
            this.btnEuroJudoClubsFileBrowse = new System.Windows.Forms.Button();
            this.chkImportHasHeaders = new System.Windows.Forms.CheckBox();
            this.cmbSplitCharacters = new System.Windows.Forms.ComboBox();
            this.chkRemoveTotalRow = new System.Windows.Forms.CheckBox();
            this.lblInputDelimiter = new System.Windows.Forms.Label();
            this.tabOptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOptions
            // 
            this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOptions.Controls.Add(this.tabPage4);
            this.tabOptions.Controls.Add(this.tabPage1);
            this.tabOptions.Controls.Add(this.tabPage2);
            this.tabOptions.Controls.Add(this.tabPage3);
            this.tabOptions.Location = new System.Drawing.Point(12, 12);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(471, 190);
            this.tabOptions.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkImportHasHeaders);
            this.tabPage1.Controls.Add(this.cmbSplitCharacters);
            this.tabPage1.Controls.Add(this.chkRemoveTotalRow);
            this.tabPage1.Controls.Add(this.lblInputDelimiter);
            this.tabPage1.Controls.Add(this.lblEuroJudoFile);
            this.tabPage1.Controls.Add(this.txtEuroJudoExportFilename);
            this.tabPage1.Controls.Add(this.btnEuroJudoSaveFileBrowse);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 164);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblIJFExportFilename);
            this.tabPage2.Controls.Add(this.txtIJFExportFilename);
            this.tabPage2.Controls.Add(this.btnIJFExportBrowse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(463, 164);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "IJF";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(408, 208);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(327, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtEuroJudoDatabaseFilename);
            this.tabPage3.Controls.Add(this.btnEuroJudoDatabaseBrowse);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(463, 164);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Euro Judo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtEuroJudoDatabaseFilename
            // 
            this.txtEuroJudoDatabaseFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoDatabaseFilename.Location = new System.Drawing.Point(122, 9);
            this.txtEuroJudoDatabaseFilename.Name = "txtEuroJudoDatabaseFilename";
            this.txtEuroJudoDatabaseFilename.Size = new System.Drawing.Size(307, 20);
            this.txtEuroJudoDatabaseFilename.TabIndex = 4;
            // 
            // btnEuroJudoDatabaseBrowse
            // 
            this.btnEuroJudoDatabaseBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoDatabaseBrowse.Location = new System.Drawing.Point(435, 7);
            this.btnEuroJudoDatabaseBrowse.Name = "btnEuroJudoDatabaseBrowse";
            this.btnEuroJudoDatabaseBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoDatabaseBrowse.TabIndex = 5;
            this.btnEuroJudoDatabaseBrowse.Text = "...";
            this.btnEuroJudoDatabaseBrowse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tournament Database";
            // 
            // lblIJFExportFilename
            // 
            this.lblIJFExportFilename.AutoSize = true;
            this.lblIJFExportFilename.Location = new System.Drawing.Point(3, 12);
            this.lblIJFExportFilename.Name = "lblIJFExportFilename";
            this.lblIJFExportFilename.Size = new System.Drawing.Size(63, 13);
            this.lblIJFExportFilename.TabIndex = 3;
            this.lblIJFExportFilename.Text = "IJF filename";
            // 
            // txtIJFExportFilename
            // 
            this.txtIJFExportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIJFExportFilename.Location = new System.Drawing.Point(122, 9);
            this.txtIJFExportFilename.Name = "txtIJFExportFilename";
            this.txtIJFExportFilename.Size = new System.Drawing.Size(307, 20);
            this.txtIJFExportFilename.TabIndex = 4;
            // 
            // btnIJFExportBrowse
            // 
            this.btnIJFExportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIJFExportBrowse.Location = new System.Drawing.Point(435, 7);
            this.btnIJFExportBrowse.Name = "btnIJFExportBrowse";
            this.btnIJFExportBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnIJFExportBrowse.TabIndex = 5;
            this.btnIJFExportBrowse.Text = "...";
            this.btnIJFExportBrowse.UseVisualStyleBackColor = true;
            // 
            // lblEuroJudoFile
            // 
            this.lblEuroJudoFile.AutoSize = true;
            this.lblEuroJudoFile.Location = new System.Drawing.Point(3, 12);
            this.lblEuroJudoFile.Name = "lblEuroJudoFile";
            this.lblEuroJudoFile.Size = new System.Drawing.Size(79, 13);
            this.lblEuroJudoFile.TabIndex = 6;
            this.lblEuroJudoFile.Text = "Export filename";
            // 
            // txtEuroJudoExportFilename
            // 
            this.txtEuroJudoExportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoExportFilename.Location = new System.Drawing.Point(122, 9);
            this.txtEuroJudoExportFilename.Name = "txtEuroJudoExportFilename";
            this.txtEuroJudoExportFilename.Size = new System.Drawing.Size(307, 20);
            this.txtEuroJudoExportFilename.TabIndex = 7;
            // 
            // btnEuroJudoSaveFileBrowse
            // 
            this.btnEuroJudoSaveFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoSaveFileBrowse.Location = new System.Drawing.Point(435, 7);
            this.btnEuroJudoSaveFileBrowse.Name = "btnEuroJudoSaveFileBrowse";
            this.btnEuroJudoSaveFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoSaveFileBrowse.TabIndex = 8;
            this.btnEuroJudoSaveFileBrowse.Text = "...";
            this.btnEuroJudoSaveFileBrowse.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.txtEuroJudoSubDivisionFilename);
            this.tabPage4.Controls.Add(this.btnEuroJudoSubDivisionsFileBrowse);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.txtEuroJudoCountriesFilename);
            this.tabPage4.Controls.Add(this.btnEuroJudoCountriesFileBrowse);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.txtEuroJudoClubsFilename);
            this.tabPage4.Controls.Add(this.btnEuroJudoClubsFileBrowse);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(463, 164);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "General";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Sub-Divisions filename";
            // 
            // txtEuroJudoSubDivisionFilename
            // 
            this.txtEuroJudoSubDivisionFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoSubDivisionFilename.Location = new System.Drawing.Point(122, 67);
            this.txtEuroJudoSubDivisionFilename.Name = "txtEuroJudoSubDivisionFilename";
            this.txtEuroJudoSubDivisionFilename.Size = new System.Drawing.Size(307, 20);
            this.txtEuroJudoSubDivisionFilename.TabIndex = 25;
            // 
            // btnEuroJudoSubDivisionsFileBrowse
            // 
            this.btnEuroJudoSubDivisionsFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoSubDivisionsFileBrowse.Location = new System.Drawing.Point(435, 65);
            this.btnEuroJudoSubDivisionsFileBrowse.Name = "btnEuroJudoSubDivisionsFileBrowse";
            this.btnEuroJudoSubDivisionsFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoSubDivisionsFileBrowse.TabIndex = 26;
            this.btnEuroJudoSubDivisionsFileBrowse.Text = "...";
            this.btnEuroJudoSubDivisionsFileBrowse.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Countries filename";
            // 
            // txtEuroJudoCountriesFilename
            // 
            this.txtEuroJudoCountriesFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoCountriesFilename.Location = new System.Drawing.Point(122, 38);
            this.txtEuroJudoCountriesFilename.Name = "txtEuroJudoCountriesFilename";
            this.txtEuroJudoCountriesFilename.Size = new System.Drawing.Size(307, 20);
            this.txtEuroJudoCountriesFilename.TabIndex = 22;
            // 
            // btnEuroJudoCountriesFileBrowse
            // 
            this.btnEuroJudoCountriesFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoCountriesFileBrowse.Location = new System.Drawing.Point(435, 36);
            this.btnEuroJudoCountriesFileBrowse.Name = "btnEuroJudoCountriesFileBrowse";
            this.btnEuroJudoCountriesFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoCountriesFileBrowse.TabIndex = 23;
            this.btnEuroJudoCountriesFileBrowse.Text = "...";
            this.btnEuroJudoCountriesFileBrowse.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Clubs filename";
            // 
            // txtEuroJudoClubsFilename
            // 
            this.txtEuroJudoClubsFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEuroJudoClubsFilename.Location = new System.Drawing.Point(122, 9);
            this.txtEuroJudoClubsFilename.Name = "txtEuroJudoClubsFilename";
            this.txtEuroJudoClubsFilename.Size = new System.Drawing.Size(307, 20);
            this.txtEuroJudoClubsFilename.TabIndex = 19;
            // 
            // btnEuroJudoClubsFileBrowse
            // 
            this.btnEuroJudoClubsFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEuroJudoClubsFileBrowse.Location = new System.Drawing.Point(435, 7);
            this.btnEuroJudoClubsFileBrowse.Name = "btnEuroJudoClubsFileBrowse";
            this.btnEuroJudoClubsFileBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnEuroJudoClubsFileBrowse.TabIndex = 20;
            this.btnEuroJudoClubsFileBrowse.Text = "...";
            this.btnEuroJudoClubsFileBrowse.UseVisualStyleBackColor = true;
            // 
            // chkImportHasHeaders
            // 
            this.chkImportHasHeaders.AutoSize = true;
            this.chkImportHasHeaders.Checked = true;
            this.chkImportHasHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImportHasHeaders.Location = new System.Drawing.Point(6, 35);
            this.chkImportHasHeaders.Name = "chkImportHasHeaders";
            this.chkImportHasHeaders.Size = new System.Drawing.Size(140, 17);
            this.chkImportHasHeaders.TabIndex = 9;
            this.chkImportHasHeaders.Text = "Include Column headers";
            this.chkImportHasHeaders.UseVisualStyleBackColor = true;
            // 
            // cmbSplitCharacters
            // 
            this.cmbSplitCharacters.FormattingEnabled = true;
            this.cmbSplitCharacters.Items.AddRange(new object[] {
            ",",
            ";",
            "/t"});
            this.cmbSplitCharacters.Location = new System.Drawing.Point(91, 81);
            this.cmbSplitCharacters.Name = "cmbSplitCharacters";
            this.cmbSplitCharacters.Size = new System.Drawing.Size(52, 21);
            this.cmbSplitCharacters.TabIndex = 12;
            // 
            // chkRemoveTotalRow
            // 
            this.chkRemoveTotalRow.AutoSize = true;
            this.chkRemoveTotalRow.Checked = true;
            this.chkRemoveTotalRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveTotalRow.Location = new System.Drawing.Point(6, 58);
            this.chkRemoveTotalRow.Name = "chkRemoveTotalRow";
            this.chkRemoveTotalRow.Size = new System.Drawing.Size(118, 17);
            this.chkRemoveTotalRow.TabIndex = 10;
            this.chkRemoveTotalRow.Text = "Remove Total Row";
            this.chkRemoveTotalRow.UseVisualStyleBackColor = true;
            // 
            // lblInputDelimiter
            // 
            this.lblInputDelimiter.AutoSize = true;
            this.lblInputDelimiter.Location = new System.Drawing.Point(3, 84);
            this.lblInputDelimiter.Name = "lblInputDelimiter";
            this.lblInputDelimiter.Size = new System.Drawing.Size(74, 13);
            this.lblInputDelimiter.TabIndex = 11;
            this.lblInputDelimiter.Text = "Input Delimiter";
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(495, 243);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabOptions);
            this.Name = "frmOptions";
            this.Text = "Options";
            this.tabOptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtEuroJudoDatabaseFilename;
        private System.Windows.Forms.Button btnEuroJudoDatabaseBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIJFExportFilename;
        private System.Windows.Forms.TextBox txtIJFExportFilename;
        private System.Windows.Forms.Button btnIJFExportBrowse;
        private System.Windows.Forms.Label lblEuroJudoFile;
        private System.Windows.Forms.TextBox txtEuroJudoExportFilename;
        private System.Windows.Forms.Button btnEuroJudoSaveFileBrowse;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEuroJudoSubDivisionFilename;
        private System.Windows.Forms.Button btnEuroJudoSubDivisionsFileBrowse;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtEuroJudoCountriesFilename;
        private System.Windows.Forms.Button btnEuroJudoCountriesFileBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEuroJudoClubsFilename;
        private System.Windows.Forms.Button btnEuroJudoClubsFileBrowse;
        private System.Windows.Forms.CheckBox chkImportHasHeaders;
        private System.Windows.Forms.ComboBox cmbSplitCharacters;
        private System.Windows.Forms.CheckBox chkRemoveTotalRow;
        private System.Windows.Forms.Label lblInputDelimiter;
    }
}