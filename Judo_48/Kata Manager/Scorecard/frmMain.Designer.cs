
namespace KataManager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnManual = new System.Windows.Forms.Button();
            this.btnElectronic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(12, 12);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(120, 120);
            this.btnManual.TabIndex = 0;
            this.btnManual.TabStop = false;
            this.btnManual.Text = "Manual Scorecards";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnElectronic
            // 
            this.btnElectronic.Location = new System.Drawing.Point(264, 12);
            this.btnElectronic.Name = "btnElectronic";
            this.btnElectronic.Size = new System.Drawing.Size(120, 120);
            this.btnElectronic.TabIndex = 1;
            this.btnElectronic.TabStop = false;
            this.btnElectronic.Text = "Electronic Scoring";
            this.btnElectronic.UseVisualStyleBackColor = true;
            this.btnElectronic.Click += new System.EventHandler(this.btnElectronic_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 143);
            this.Controls.Add(this.btnElectronic);
            this.Controls.Add(this.btnManual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kata Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnElectronic;
    }
}