namespace FlagRaising
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.btnRaise = new System.Windows.Forms.Button();
            this.btnLower = new System.Windows.Forms.Button();
            this.lblTournament = new System.Windows.Forms.Label();
            this.txtTournament = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbGold = new System.Windows.Forms.ComboBox();
            this.lblGoldOrSilver = new System.Windows.Forms.Label();
            this.cmbSilver = new System.Windows.Forms.ComboBox();
            this.cmbBronze1 = new System.Windows.Forms.ComboBox();
            this.cmbBronze2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDivision = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radGoldSilverBronzeBronze = new System.Windows.Forms.RadioButton();
            this.radSilverSilverBronzeBronze = new System.Windows.Forms.RadioButton();
            this.cmbScreen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRaise
            // 
            this.btnRaise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRaise.Location = new System.Drawing.Point(270, 195);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(75, 23);
            this.btnRaise.TabIndex = 0;
            this.btnRaise.Text = "Raise";
            this.btnRaise.UseVisualStyleBackColor = true;
            this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
            // 
            // btnLower
            // 
            this.btnLower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLower.Location = new System.Drawing.Point(351, 195);
            this.btnLower.Name = "btnLower";
            this.btnLower.Size = new System.Drawing.Size(75, 23);
            this.btnLower.TabIndex = 1;
            this.btnLower.Text = "Lower";
            this.btnLower.UseVisualStyleBackColor = true;
            this.btnLower.Click += new System.EventHandler(this.btnLower_Click);
            // 
            // lblTournament
            // 
            this.lblTournament.AutoSize = true;
            this.lblTournament.Location = new System.Drawing.Point(14, 15);
            this.lblTournament.Name = "lblTournament";
            this.lblTournament.Size = new System.Drawing.Size(64, 13);
            this.lblTournament.TabIndex = 2;
            this.lblTournament.Text = "Tournament";
            // 
            // txtTournament
            // 
            this.txtTournament.Location = new System.Drawing.Point(84, 12);
            this.txtTournament.Name = "txtTournament";
            this.txtTournament.Size = new System.Drawing.Size(342, 20);
            this.txtTournament.TabIndex = 3;
            this.txtTournament.Text = "2019 OJU Open";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(14, 41);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(49, 13);
            this.lblSex.TabIndex = 4;
            this.lblSex.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(84, 38);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // cmbGold
            // 
            this.cmbGold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGold.FormattingEnabled = true;
            this.cmbGold.Location = new System.Drawing.Point(84, 116);
            this.cmbGold.Name = "cmbGold";
            this.cmbGold.Size = new System.Drawing.Size(121, 21);
            this.cmbGold.TabIndex = 6;
            // 
            // lblGoldOrSilver
            // 
            this.lblGoldOrSilver.AutoSize = true;
            this.lblGoldOrSilver.Location = new System.Drawing.Point(14, 119);
            this.lblGoldOrSilver.Name = "lblGoldOrSilver";
            this.lblGoldOrSilver.Size = new System.Drawing.Size(29, 13);
            this.lblGoldOrSilver.TabIndex = 7;
            this.lblGoldOrSilver.Text = "Gold";
            // 
            // cmbSilver
            // 
            this.cmbSilver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSilver.FormattingEnabled = true;
            this.cmbSilver.Location = new System.Drawing.Point(84, 143);
            this.cmbSilver.Name = "cmbSilver";
            this.cmbSilver.Size = new System.Drawing.Size(121, 21);
            this.cmbSilver.TabIndex = 8;
            // 
            // cmbBronze1
            // 
            this.cmbBronze1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBronze1.FormattingEnabled = true;
            this.cmbBronze1.Location = new System.Drawing.Point(84, 170);
            this.cmbBronze1.Name = "cmbBronze1";
            this.cmbBronze1.Size = new System.Drawing.Size(121, 21);
            this.cmbBronze1.TabIndex = 9;
            // 
            // cmbBronze2
            // 
            this.cmbBronze2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBronze2.FormattingEnabled = true;
            this.cmbBronze2.Location = new System.Drawing.Point(84, 197);
            this.cmbBronze2.Name = "cmbBronze2";
            this.cmbBronze2.Size = new System.Drawing.Size(121, 21);
            this.cmbBronze2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Silver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bronze";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bronze";
            // 
            // cmbDivision
            // 
            this.cmbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDivision.FormattingEnabled = true;
            this.cmbDivision.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cmbDivision.Location = new System.Drawing.Point(263, 38);
            this.cmbDivision.Name = "cmbDivision";
            this.cmbDivision.Size = new System.Drawing.Size(163, 21);
            this.cmbDivision.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Division";
            // 
            // radGoldSilverBronzeBronze
            // 
            this.radGoldSilverBronzeBronze.AutoSize = true;
            this.radGoldSilverBronzeBronze.Checked = true;
            this.radGoldSilverBronzeBronze.Location = new System.Drawing.Point(84, 66);
            this.radGoldSilverBronzeBronze.Name = "radGoldSilverBronzeBronze";
            this.radGoldSilverBronzeBronze.Size = new System.Drawing.Size(132, 17);
            this.radGoldSilverBronzeBronze.TabIndex = 16;
            this.radGoldSilverBronzeBronze.TabStop = true;
            this.radGoldSilverBronzeBronze.Text = "Gold, Silver, Bronze x2";
            this.radGoldSilverBronzeBronze.UseVisualStyleBackColor = true;
            this.radGoldSilverBronzeBronze.CheckedChanged += new System.EventHandler(this.radGoldSilverBronzeBronze_CheckedChanged);
            // 
            // radSilverSilverBronzeBronze
            // 
            this.radSilverSilverBronzeBronze.AutoSize = true;
            this.radSilverSilverBronzeBronze.Location = new System.Drawing.Point(263, 66);
            this.radSilverSilverBronzeBronze.Name = "radSilverSilverBronzeBronze";
            this.radSilverSilverBronzeBronze.Size = new System.Drawing.Size(118, 17);
            this.radSilverSilverBronzeBronze.TabIndex = 17;
            this.radSilverSilverBronzeBronze.Text = "Silver x2, Bronze x2";
            this.radSilverSilverBronzeBronze.UseVisualStyleBackColor = true;
            this.radSilverSilverBronzeBronze.CheckedChanged += new System.EventHandler(this.radSilverSilverBronzeBronze_CheckedChanged);
            // 
            // cmbScreen
            // 
            this.cmbScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScreen.FormattingEnabled = true;
            this.cmbScreen.Location = new System.Drawing.Point(84, 89);
            this.cmbScreen.Name = "cmbScreen";
            this.cmbScreen.Size = new System.Drawing.Size(68, 21);
            this.cmbScreen.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Positions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Screen";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 230);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbScreen);
            this.Controls.Add(this.radSilverSilverBronzeBronze);
            this.Controls.Add(this.radGoldSilverBronzeBronze);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDivision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBronze2);
            this.Controls.Add(this.cmbBronze1);
            this.Controls.Add(this.cmbSilver);
            this.Controls.Add(this.lblGoldOrSilver);
            this.Controls.Add(this.cmbGold);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.txtTournament);
            this.Controls.Add(this.lblTournament);
            this.Controls.Add(this.btnLower);
            this.Controls.Add(this.btnRaise);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfig";
            this.Text = "Flag raising";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRaise;
        private System.Windows.Forms.Button btnLower;
        private System.Windows.Forms.Label lblTournament;
        private System.Windows.Forms.TextBox txtTournament;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbGold;
        private System.Windows.Forms.Label lblGoldOrSilver;
        private System.Windows.Forms.ComboBox cmbSilver;
        private System.Windows.Forms.ComboBox cmbBronze1;
        private System.Windows.Forms.ComboBox cmbBronze2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDivision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radGoldSilverBronzeBronze;
        private System.Windows.Forms.RadioButton radSilverSilverBronzeBronze;
        private System.Windows.Forms.ComboBox cmbScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}

