
namespace KataManager
{
    partial class frmManualScorecard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualScorecard));
            this.btnPrint = new System.Windows.Forms.Button();
            this.web = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.cmbKata = new System.Windows.Forms.ComboBox();
            this.lblKata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(283, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 31);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // web
            // 
            this.web.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.web.Location = new System.Drawing.Point(16, 44);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(1096, 1168);
            this.web.Source = new System.Uri("about:blank", System.UriKind.Absolute);
            this.web.TabIndex = 4;
            this.web.ZoomFactor = 0.75D;
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
            "Katame No Kata",
            "Kime No Kata",
            "Ju No Kata",
            "Goshin Jutsu",
            "Koshiki No Kata"});
            this.cmbKata.Location = new System.Drawing.Point(60, 10);
            this.cmbKata.Name = "cmbKata";
            this.cmbKata.Size = new System.Drawing.Size(217, 28);
            this.cmbKata.TabIndex = 5;
            this.cmbKata.SelectedIndexChanged += new System.EventHandler(this.cmbKata_SelectedIndexChanged);
            // 
            // lblKata
            // 
            this.lblKata.AutoSize = true;
            this.lblKata.Location = new System.Drawing.Point(12, 13);
            this.lblKata.Name = "lblKata";
            this.lblKata.Size = new System.Drawing.Size(42, 20);
            this.lblKata.TabIndex = 6;
            this.lblKata.Text = "Kata";
            // 
            // frmManualScorecard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 1224);
            this.Controls.Add(this.lblKata);
            this.Controls.Add(this.cmbKata);
            this.Controls.Add(this.web);
            this.Controls.Add(this.btnPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManualScorecard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Scorecards";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private Microsoft.Web.WebView2.WinForms.WebView2 web;
        private System.Windows.Forms.ComboBox cmbKata;
        private System.Windows.Forms.Label lblKata;
    }
}

