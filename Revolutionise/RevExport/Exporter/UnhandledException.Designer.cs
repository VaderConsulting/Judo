namespace MappingTool
{
    partial class frmUnhandledException
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnhandledException));
            this.lblUnhandledException = new System.Windows.Forms.Label();
            this.txtExceptionText = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtExceptionMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUnhandledException
            // 
            this.lblUnhandledException.AutoSize = true;
            this.lblUnhandledException.Location = new System.Drawing.Point(12, 9);
            this.lblUnhandledException.Name = "lblUnhandledException";
            this.lblUnhandledException.Size = new System.Drawing.Size(188, 13);
            this.lblUnhandledException.TabIndex = 0;
            this.lblUnhandledException.Text = "An unhandled Exception has occured.";
            // 
            // txtExceptionText
            // 
            this.txtExceptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExceptionText.Location = new System.Drawing.Point(13, 65);
            this.txtExceptionText.Multiline = true;
            this.txtExceptionText.Name = "txtExceptionText";
            this.txtExceptionText.ReadOnly = true;
            this.txtExceptionText.Size = new System.Drawing.Size(447, 156);
            this.txtExceptionText.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 29);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message:";
            // 
            // txtExceptionMessage
            // 
            this.txtExceptionMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExceptionMessage.Location = new System.Drawing.Point(74, 26);
            this.txtExceptionMessage.Name = "txtExceptionMessage";
            this.txtExceptionMessage.ReadOnly = true;
            this.txtExceptionMessage.Size = new System.Drawing.Size(386, 20);
            this.txtExceptionMessage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stack Trace:";
            // 
            // frmUnhandledException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 233);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExceptionMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtExceptionText);
            this.Controls.Add(this.lblUnhandledException);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUnhandledException";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unhandled Exception";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnhandledException;
        private System.Windows.Forms.TextBox txtExceptionText;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtExceptionMessage;
        private System.Windows.Forms.Label label1;
    }
}