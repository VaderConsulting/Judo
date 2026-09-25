namespace MappingTool
{
    partial class frmOutputType
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
            this.lblChooseAMappingType = new System.Windows.Forms.Label();
            this.btnEuroJudo = new System.Windows.Forms.Button();
            this.btnIJF = new System.Windows.Forms.Button();
            this.btnEuroJudoAndIJF = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChooseAMappingType
            // 
            this.lblChooseAMappingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseAMappingType.Location = new System.Drawing.Point(12, 9);
            this.lblChooseAMappingType.Name = "lblChooseAMappingType";
            this.lblChooseAMappingType.Size = new System.Drawing.Size(161, 23);
            this.lblChooseAMappingType.TabIndex = 0;
            this.lblChooseAMappingType.Text = "Choose an output type";
            this.lblChooseAMappingType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEuroJudo
            // 
            this.btnEuroJudo.Location = new System.Drawing.Point(15, 37);
            this.btnEuroJudo.Name = "btnEuroJudo";
            this.btnEuroJudo.Size = new System.Drawing.Size(75, 23);
            this.btnEuroJudo.TabIndex = 1;
            this.btnEuroJudo.Text = "Euro Judo";
            this.btnEuroJudo.UseVisualStyleBackColor = true;
            this.btnEuroJudo.Click += new System.EventHandler(this.btnEuroJudo_Click);
            // 
            // btnIJF
            // 
            this.btnIJF.Location = new System.Drawing.Point(98, 37);
            this.btnIJF.Name = "btnIJF";
            this.btnIJF.Size = new System.Drawing.Size(75, 23);
            this.btnIJF.TabIndex = 2;
            this.btnIJF.Text = "IJF";
            this.btnIJF.UseVisualStyleBackColor = true;
            this.btnIJF.Click += new System.EventHandler(this.btnIJF_Click);
            // 
            // btnEuroJudoAndIJF
            // 
            this.btnEuroJudoAndIJF.Location = new System.Drawing.Point(15, 66);
            this.btnEuroJudoAndIJF.Name = "btnEuroJudoAndIJF";
            this.btnEuroJudoAndIJF.Size = new System.Drawing.Size(158, 23);
            this.btnEuroJudoAndIJF.TabIndex = 3;
            this.btnEuroJudoAndIJF.Text = "Euro Judo and IJF";
            this.btnEuroJudoAndIJF.UseVisualStyleBackColor = true;
            this.btnEuroJudoAndIJF.Click += new System.EventHandler(this.btnEuroJudoAndIJF_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(98, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmOutputType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 158);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEuroJudoAndIJF);
            this.Controls.Add(this.btnIJF);
            this.Controls.Add(this.btnEuroJudo);
            this.Controls.Add(this.lblChooseAMappingType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOutputType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Output Type";
            this.Shown += new System.EventHandler(this.frmOutputType_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChooseAMappingType;
        private System.Windows.Forms.Button btnEuroJudo;
        private System.Windows.Forms.Button btnIJF;
        private System.Windows.Forms.Button btnEuroJudoAndIJF;
        private System.Windows.Forms.Button btnCancel;
    }
}