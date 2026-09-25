namespace Internet_Sender
{
    partial class frmSender
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.tabLanguage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.radRaw = new System.Windows.Forms.RadioButton();
            this.radFormatted = new System.Windows.Forms.RadioButton();
            this.grpFormatted = new System.Windows.Forms.GroupBox();
            this.tmrClear = new System.Windows.Forms.Timer(this.components);
            this.picData = new System.Windows.Forms.PictureBox();
            this.tmrData = new System.Windows.Forms.Timer(this.components);
            this.tabLanguage.SuspendLayout();
            this.grpFormatted.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(12, 37);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(658, 31);
            this.txtURL.TabIndex = 0;
            this.txtURL.Text = "http://input.sport4.au/judodata";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL to receive JSON";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(676, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 34);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(12, 163);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(776, 350);
            this.txtOutput.TabIndex = 3;
            // 
            // tabLanguage
            // 
            this.tabLanguage.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabLanguage.Controls.Add(this.tabPage1);
            this.tabLanguage.Controls.Add(this.tabPage2);
            this.tabLanguage.Controls.Add(this.tabPage3);
            this.tabLanguage.Controls.Add(this.tabPage4);
            this.tabLanguage.Controls.Add(this.tabPage5);
            this.tabLanguage.Enabled = false;
            this.tabLanguage.Location = new System.Drawing.Point(6, 21);
            this.tabLanguage.Name = "tabLanguage";
            this.tabLanguage.SelectedIndex = 0;
            this.tabLanguage.Size = new System.Drawing.Size(404, 43);
            this.tabLanguage.TabIndex = 4;
            this.tabLanguage.SelectedIndexChanged += new System.EventHandler(this.tabLanguage_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(396, 2);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "English";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(396, 2);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Japanese";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 37);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(396, 2);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "German";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 37);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(396, 2);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Spanish";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 37);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(396, 2);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "French";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // radRaw
            // 
            this.radRaw.AutoSize = true;
            this.radRaw.Checked = true;
            this.radRaw.Location = new System.Drawing.Point(12, 74);
            this.radRaw.Name = "radRaw";
            this.radRaw.Size = new System.Drawing.Size(70, 29);
            this.radRaw.TabIndex = 5;
            this.radRaw.TabStop = true;
            this.radRaw.Text = "Raw";
            this.radRaw.UseVisualStyleBackColor = true;
            this.radRaw.CheckedChanged += new System.EventHandler(this.radRaw_CheckedChanged);
            // 
            // radFormatted
            // 
            this.radFormatted.AutoSize = true;
            this.radFormatted.Location = new System.Drawing.Point(88, 74);
            this.radFormatted.Name = "radFormatted";
            this.radFormatted.Size = new System.Drawing.Size(120, 29);
            this.radFormatted.TabIndex = 6;
            this.radFormatted.TabStop = true;
            this.radFormatted.Text = "Formatted";
            this.radFormatted.UseVisualStyleBackColor = true;
            this.radFormatted.CheckedChanged += new System.EventHandler(this.radFormatted_CheckedChanged);
            // 
            // grpFormatted
            // 
            this.grpFormatted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFormatted.Controls.Add(this.tabLanguage);
            this.grpFormatted.Location = new System.Drawing.Point(88, 88);
            this.grpFormatted.Name = "grpFormatted";
            this.grpFormatted.Size = new System.Drawing.Size(700, 69);
            this.grpFormatted.TabIndex = 7;
            this.grpFormatted.TabStop = false;
            // 
            // tmrClear
            // 
            this.tmrClear.Interval = 5000;
            this.tmrClear.Tick += new System.EventHandler(this.tmrClear_Tick);
            // 
            // picData
            // 
            this.picData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picData.BackColor = System.Drawing.Color.LightGreen;
            this.picData.Location = new System.Drawing.Point(12, 519);
            this.picData.Name = "picData";
            this.picData.Size = new System.Drawing.Size(20, 20);
            this.picData.TabIndex = 8;
            this.picData.TabStop = false;
            this.picData.Visible = false;
            // 
            // tmrData
            // 
            this.tmrData.Tick += new System.EventHandler(this.tmrData_Tick);
            // 
            // frmSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 551);
            this.Controls.Add(this.picData);
            this.Controls.Add(this.radFormatted);
            this.Controls.Add(this.radRaw);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.grpFormatted);
            this.Name = "frmSender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sender";
            this.Load += new System.EventHandler(this.frmSender_Load);
            this.tabLanguage.ResumeLayout(false);
            this.grpFormatted.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtURL;
        private Label label1;
        private Button btnStart;
        private TextBox txtOutput;
        private TabControl tabLanguage;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private RadioButton radRaw;
        private RadioButton radFormatted;
        private GroupBox grpFormatted;
        private System.Windows.Forms.Timer tmrClear;
        private PictureBox picData;
        private System.Windows.Forms.Timer tmrData;
    }
}