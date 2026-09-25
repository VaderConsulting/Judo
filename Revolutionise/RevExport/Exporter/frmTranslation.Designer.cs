namespace MappingTool
{
    partial class frmTranslation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranslation));
            this.nudEuroJudoTransformCount = new System.Windows.Forms.NumericUpDown();
            this.nudEuroJudoTransformStart = new System.Windows.Forms.NumericUpDown();
            this.lblEuroJudoTransformCount = new System.Windows.Forms.Label();
            this.lblEuroJudoTransformCharacter = new System.Windows.Forms.Label();
            this.radEuroJudoSubstringTranslation = new System.Windows.Forms.RadioButton();
            this.lblEuroJudoTransformStart = new System.Windows.Forms.Label();
            this.radEuroJudoLengthTranslation = new System.Windows.Forms.RadioButton();
            this.radEuroJudoCharacterTranslation = new System.Windows.Forms.RadioButton();
            this.radEuroJudoValueTranslation = new System.Windows.Forms.RadioButton();
            this.lvwTransformationType = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblExampleValue = new System.Windows.Forms.Label();
            this.lblExample = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lstCharacters = new System.Windows.Forms.ListBox();
            this.lblJoinChar = new System.Windows.Forms.Label();
            this.cmbJoinCharacter = new System.Windows.Forms.ComboBox();
            this.chkPerformValidation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudEuroJudoTransformCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEuroJudoTransformStart)).BeginInit();
            this.SuspendLayout();
            // 
            // nudEuroJudoTransformCount
            // 
            this.nudEuroJudoTransformCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudEuroJudoTransformCount.Enabled = false;
            this.nudEuroJudoTransformCount.Location = new System.Drawing.Point(367, 209);
            this.nudEuroJudoTransformCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEuroJudoTransformCount.Name = "nudEuroJudoTransformCount";
            this.nudEuroJudoTransformCount.Size = new System.Drawing.Size(56, 20);
            this.nudEuroJudoTransformCount.TabIndex = 10;
            this.nudEuroJudoTransformCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEuroJudoTransformCount.ValueChanged += new System.EventHandler(this.nudEuroJudoTransformCount_ValueChanged);
            // 
            // nudEuroJudoTransformStart
            // 
            this.nudEuroJudoTransformStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudEuroJudoTransformStart.Enabled = false;
            this.nudEuroJudoTransformStart.Location = new System.Drawing.Point(367, 248);
            this.nudEuroJudoTransformStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEuroJudoTransformStart.Name = "nudEuroJudoTransformStart";
            this.nudEuroJudoTransformStart.Size = new System.Drawing.Size(56, 20);
            this.nudEuroJudoTransformStart.TabIndex = 12;
            this.nudEuroJudoTransformStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEuroJudoTransformStart.ValueChanged += new System.EventHandler(this.nudEuroJudoTransformStart_ValueChanged);
            // 
            // lblEuroJudoTransformCount
            // 
            this.lblEuroJudoTransformCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEuroJudoTransformCount.AutoSize = true;
            this.lblEuroJudoTransformCount.Enabled = false;
            this.lblEuroJudoTransformCount.Location = new System.Drawing.Point(367, 193);
            this.lblEuroJudoTransformCount.Name = "lblEuroJudoTransformCount";
            this.lblEuroJudoTransformCount.Size = new System.Drawing.Size(35, 13);
            this.lblEuroJudoTransformCount.TabIndex = 9;
            this.lblEuroJudoTransformCount.Text = "Count";
            // 
            // lblEuroJudoTransformCharacter
            // 
            this.lblEuroJudoTransformCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEuroJudoTransformCharacter.AutoSize = true;
            this.lblEuroJudoTransformCharacter.Enabled = false;
            this.lblEuroJudoTransformCharacter.Location = new System.Drawing.Point(367, 35);
            this.lblEuroJudoTransformCharacter.Name = "lblEuroJudoTransformCharacter";
            this.lblEuroJudoTransformCharacter.Size = new System.Drawing.Size(57, 13);
            this.lblEuroJudoTransformCharacter.TabIndex = 5;
            this.lblEuroJudoTransformCharacter.Text = "Split Chars";
            // 
            // radEuroJudoSubstringTranslation
            // 
            this.radEuroJudoSubstringTranslation.AutoSize = true;
            this.radEuroJudoSubstringTranslation.Location = new System.Drawing.Point(237, 12);
            this.radEuroJudoSubstringTranslation.Name = "radEuroJudoSubstringTranslation";
            this.radEuroJudoSubstringTranslation.Size = new System.Drawing.Size(69, 17);
            this.radEuroJudoSubstringTranslation.TabIndex = 3;
            this.radEuroJudoSubstringTranslation.Text = "Substring";
            this.radEuroJudoSubstringTranslation.UseVisualStyleBackColor = true;
            this.radEuroJudoSubstringTranslation.CheckedChanged += new System.EventHandler(this.radEuroJudoSubstringTranslation_CheckedChanged);
            // 
            // lblEuroJudoTransformStart
            // 
            this.lblEuroJudoTransformStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEuroJudoTransformStart.AutoSize = true;
            this.lblEuroJudoTransformStart.Enabled = false;
            this.lblEuroJudoTransformStart.Location = new System.Drawing.Point(367, 232);
            this.lblEuroJudoTransformStart.Name = "lblEuroJudoTransformStart";
            this.lblEuroJudoTransformStart.Size = new System.Drawing.Size(29, 13);
            this.lblEuroJudoTransformStart.TabIndex = 11;
            this.lblEuroJudoTransformStart.Text = "Start";
            // 
            // radEuroJudoLengthTranslation
            // 
            this.radEuroJudoLengthTranslation.AutoSize = true;
            this.radEuroJudoLengthTranslation.Location = new System.Drawing.Point(166, 12);
            this.radEuroJudoLengthTranslation.Name = "radEuroJudoLengthTranslation";
            this.radEuroJudoLengthTranslation.Size = new System.Drawing.Size(58, 17);
            this.radEuroJudoLengthTranslation.TabIndex = 2;
            this.radEuroJudoLengthTranslation.Text = "Length";
            this.radEuroJudoLengthTranslation.UseVisualStyleBackColor = true;
            this.radEuroJudoLengthTranslation.CheckedChanged += new System.EventHandler(this.radEuroJudoLengthTranslation_CheckedChanged);
            // 
            // radEuroJudoCharacterTranslation
            // 
            this.radEuroJudoCharacterTranslation.AutoSize = true;
            this.radEuroJudoCharacterTranslation.Location = new System.Drawing.Point(83, 12);
            this.radEuroJudoCharacterTranslation.Name = "radEuroJudoCharacterTranslation";
            this.radEuroJudoCharacterTranslation.Size = new System.Drawing.Size(71, 17);
            this.radEuroJudoCharacterTranslation.TabIndex = 1;
            this.radEuroJudoCharacterTranslation.Text = "Character";
            this.radEuroJudoCharacterTranslation.UseVisualStyleBackColor = true;
            this.radEuroJudoCharacterTranslation.CheckedChanged += new System.EventHandler(this.radEuroJudoCharacterTranslation_CheckedChanged);
            // 
            // radEuroJudoValueTranslation
            // 
            this.radEuroJudoValueTranslation.AutoSize = true;
            this.radEuroJudoValueTranslation.Checked = true;
            this.radEuroJudoValueTranslation.Location = new System.Drawing.Point(12, 12);
            this.radEuroJudoValueTranslation.Name = "radEuroJudoValueTranslation";
            this.radEuroJudoValueTranslation.Size = new System.Drawing.Size(52, 17);
            this.radEuroJudoValueTranslation.TabIndex = 0;
            this.radEuroJudoValueTranslation.TabStop = true;
            this.radEuroJudoValueTranslation.Text = "Value";
            this.radEuroJudoValueTranslation.UseVisualStyleBackColor = true;
            this.radEuroJudoValueTranslation.CheckedChanged += new System.EventHandler(this.radEuroJudoSimpleTranslation_CheckedChanged);
            // 
            // lvwTransformationType
            // 
            this.lvwTransformationType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTransformationType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwTransformationType.FullRowSelect = true;
            this.lvwTransformationType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwTransformationType.HideSelection = false;
            this.lvwTransformationType.Location = new System.Drawing.Point(9, 35);
            this.lvwTransformationType.MultiSelect = false;
            this.lvwTransformationType.Name = "lvwTransformationType";
            this.lvwTransformationType.Size = new System.Drawing.Size(352, 233);
            this.lvwTransformationType.TabIndex = 4;
            this.lvwTransformationType.UseCompatibleStateImageBehavior = false;
            this.lvwTransformationType.View = System.Windows.Forms.View.Details;
            this.lvwTransformationType.SelectedIndexChanged += new System.EventHandler(this.lvwTransformationType_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Method";
            this.columnHeader1.Width = 216;
            // 
            // lblExampleValue
            // 
            this.lblExampleValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExampleValue.AutoSize = true;
            this.lblExampleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExampleValue.Location = new System.Drawing.Point(68, 284);
            this.lblExampleValue.Name = "lblExampleValue";
            this.lblExampleValue.Size = new System.Drawing.Size(39, 13);
            this.lblExampleValue.TabIndex = 14;
            this.lblExampleValue.Text = "Value";
            // 
            // lblExample
            // 
            this.lblExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(12, 284);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(50, 13);
            this.lblExample.TabIndex = 13;
            this.lblExample.Text = "Example:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(370, 279);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstCharacters
            // 
            this.lstCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCharacters.FormattingEnabled = true;
            this.lstCharacters.Items.AddRange(new object[] {
            "- ",
            "",
            ".",
            ",",
            "/",
            "\\"});
            this.lstCharacters.Location = new System.Drawing.Point(370, 53);
            this.lstCharacters.Name = "lstCharacters";
            this.lstCharacters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCharacters.Size = new System.Drawing.Size(55, 95);
            this.lstCharacters.TabIndex = 6;
            this.lstCharacters.SelectedIndexChanged += new System.EventHandler(this.lstCharacters_SelectedIndexChanged);
            // 
            // lblJoinChar
            // 
            this.lblJoinChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJoinChar.AutoSize = true;
            this.lblJoinChar.Enabled = false;
            this.lblJoinChar.Location = new System.Drawing.Point(367, 151);
            this.lblJoinChar.Name = "lblJoinChar";
            this.lblJoinChar.Size = new System.Drawing.Size(51, 13);
            this.lblJoinChar.TabIndex = 7;
            this.lblJoinChar.Text = "Join Char";
            // 
            // cmbJoinCharacter
            // 
            this.cmbJoinCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbJoinCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJoinCharacter.FormattingEnabled = true;
            this.cmbJoinCharacter.Items.AddRange(new object[] {
            "- ",
            "",
            ".",
            ",",
            "/",
            "\\"});
            this.cmbJoinCharacter.Location = new System.Drawing.Point(368, 168);
            this.cmbJoinCharacter.Name = "cmbJoinCharacter";
            this.cmbJoinCharacter.Size = new System.Drawing.Size(57, 21);
            this.cmbJoinCharacter.TabIndex = 8;
            // 
            // chkPerformValidation
            // 
            this.chkPerformValidation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPerformValidation.AutoSize = true;
            this.chkPerformValidation.Checked = true;
            this.chkPerformValidation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPerformValidation.Location = new System.Drawing.Point(228, 283);
            this.chkPerformValidation.Name = "chkPerformValidation";
            this.chkPerformValidation.Size = new System.Drawing.Size(133, 17);
            this.chkPerformValidation.TabIndex = 15;
            this.chkPerformValidation.Text = "Allow in-transform edits";
            this.chkPerformValidation.UseVisualStyleBackColor = true;
            this.chkPerformValidation.Visible = false;
            // 
            // frmTranslation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 314);
            this.Controls.Add(this.chkPerformValidation);
            this.Controls.Add(this.cmbJoinCharacter);
            this.Controls.Add(this.lblJoinChar);
            this.Controls.Add(this.lstCharacters);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudEuroJudoTransformCount);
            this.Controls.Add(this.nudEuroJudoTransformStart);
            this.Controls.Add(this.lblEuroJudoTransformCount);
            this.Controls.Add(this.lblEuroJudoTransformCharacter);
            this.Controls.Add(this.radEuroJudoSubstringTranslation);
            this.Controls.Add(this.lblEuroJudoTransformStart);
            this.Controls.Add(this.radEuroJudoLengthTranslation);
            this.Controls.Add(this.radEuroJudoCharacterTranslation);
            this.Controls.Add(this.radEuroJudoValueTranslation);
            this.Controls.Add(this.lvwTransformationType);
            this.Controls.Add(this.lblExampleValue);
            this.Controls.Add(this.lblExample);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTranslation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translation";
            this.Shown += new System.EventHandler(this.frmTranslation_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudEuroJudoTransformCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEuroJudoTransformStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudEuroJudoTransformCount;
        private System.Windows.Forms.NumericUpDown nudEuroJudoTransformStart;
        private System.Windows.Forms.Label lblEuroJudoTransformCount;
        private System.Windows.Forms.Label lblEuroJudoTransformCharacter;
        private System.Windows.Forms.RadioButton radEuroJudoSubstringTranslation;
        private System.Windows.Forms.Label lblEuroJudoTransformStart;
        private System.Windows.Forms.RadioButton radEuroJudoLengthTranslation;
        private System.Windows.Forms.RadioButton radEuroJudoCharacterTranslation;
        private System.Windows.Forms.RadioButton radEuroJudoValueTranslation;
        private System.Windows.Forms.ListView lvwTransformationType;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblExampleValue;
        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox lstCharacters;
        private System.Windows.Forms.Label lblJoinChar;
        private System.Windows.Forms.ComboBox cmbJoinCharacter;
        private System.Windows.Forms.CheckBox chkPerformValidation;
    }
}