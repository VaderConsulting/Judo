namespace Haidenban
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
            this.btnAdministration = new System.Windows.Forms.Button();
            this.btnTournaments = new System.Windows.Forms.Button();
            this.btnRoutine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdministration
            // 
            this.btnAdministration.Location = new System.Drawing.Point(12, 12);
            this.btnAdministration.Name = "btnAdministration";
            this.btnAdministration.Size = new System.Drawing.Size(120, 40);
            this.btnAdministration.TabIndex = 0;
            this.btnAdministration.Text = "Administration";
            this.btnAdministration.UseVisualStyleBackColor = true;
            this.btnAdministration.Click += new System.EventHandler(this.btnAdministration_Click);
            // 
            // btnTournaments
            // 
            this.btnTournaments.Location = new System.Drawing.Point(138, 12);
            this.btnTournaments.Name = "btnTournaments";
            this.btnTournaments.Size = new System.Drawing.Size(120, 40);
            this.btnTournaments.TabIndex = 0;
            this.btnTournaments.Text = "Tournaments";
            this.btnTournaments.UseVisualStyleBackColor = true;
            this.btnTournaments.Click += new System.EventHandler(this.btnTournaments_Click);
            // 
            // btnRoutine
            // 
            this.btnRoutine.Location = new System.Drawing.Point(264, 12);
            this.btnRoutine.Name = "btnRoutine";
            this.btnRoutine.Size = new System.Drawing.Size(120, 40);
            this.btnRoutine.TabIndex = 0;
            this.btnRoutine.Text = "Routine";
            this.btnRoutine.UseVisualStyleBackColor = true;
            this.btnRoutine.Click += new System.EventHandler(this.btnRoutine_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 64);
            this.Controls.Add(this.btnRoutine);
            this.Controls.Add(this.btnTournaments);
            this.Controls.Add(this.btnAdministration);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配電盤";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdministration;
        private System.Windows.Forms.Button btnTournaments;
        private System.Windows.Forms.Button btnRoutine;
    }
}

