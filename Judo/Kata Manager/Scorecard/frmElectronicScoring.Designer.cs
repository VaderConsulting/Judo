
namespace KataManager
{
    partial class frmElectronicScoring
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
            this.lblKata = new System.Windows.Forms.Label();
            this.cmbKata = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblKata
            // 
            this.lblKata.AutoSize = true;
            this.lblKata.Location = new System.Drawing.Point(12, 9);
            this.lblKata.Name = "lblKata";
            this.lblKata.Size = new System.Drawing.Size(42, 20);
            this.lblKata.TabIndex = 8;
            this.lblKata.Text = "Kata";
            // 
            // cmbKata
            // 
            this.cmbKata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKata.FormattingEnabled = true;
            this.cmbKata.Items.AddRange(new object[] {
            "Nage No Kata (1 set)",
            "Nage No Kata (2 sets)",
            "Nage No Kata (3 sets)",
            "Nage No Kata",
            "Katame No Kata (1 set)",
            "Katame No Kata (2 sets)",
            "Katame No Kata (3 sets)",
            "Katame No Kata",
            "Kime No Kata",
            "Ju No Kata",
            "Goshin Jutsu",
            "Koshiki No Kata"});
            this.cmbKata.Location = new System.Drawing.Point(60, 6);
            this.cmbKata.Name = "cmbKata";
            this.cmbKata.Size = new System.Drawing.Size(217, 28);
            this.cmbKata.TabIndex = 7;
            // 
            // frmElectronicScoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 1224);
            this.Controls.Add(this.lblKata);
            this.Controls.Add(this.cmbKata);
            this.Name = "frmElectronicScoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electronic Scoring";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKata;
        private System.Windows.Forms.ComboBox cmbKata;
    }
}