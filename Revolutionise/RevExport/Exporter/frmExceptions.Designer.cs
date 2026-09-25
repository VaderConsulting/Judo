namespace MappingTool
{
    partial class frmExceptions
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
            this.lvwExceptions = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwExceptions
            // 
            this.lvwExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwExceptions.HideSelection = false;
            this.lvwExceptions.Location = new System.Drawing.Point(12, 12);
            this.lvwExceptions.Name = "lvwExceptions";
            this.lvwExceptions.Size = new System.Drawing.Size(545, 426);
            this.lvwExceptions.TabIndex = 0;
            this.lvwExceptions.UseCompatibleStateImageBehavior = false;
            // 
            // frmExceptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 450);
            this.Controls.Add(this.lvwExceptions);
            this.Name = "frmExceptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exceptions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwExceptions;
    }
}