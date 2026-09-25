namespace FlagRaising
{
    partial class frmDisplay
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
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblDetails = new CustomControls.LabelEx();
            this.pnlSilver = new System.Windows.Forms.Panel();
            this.picSilver = new System.Windows.Forms.PictureBox();
            this.pnlGold = new System.Windows.Forms.Panel();
            this.picGold = new System.Windows.Forms.PictureBox();
            this.pnlBronze1 = new System.Windows.Forms.Panel();
            this.picBronze1 = new System.Windows.Forms.PictureBox();
            this.pnlBronze2 = new System.Windows.Forms.Panel();
            this.picBronze2 = new System.Windows.Forms.PictureBox();
            this.lblTournamentName = new CustomControls.LabelEx();
            this.tmrMovement = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.pnlSilver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSilver)).BeginInit();
            this.pnlGold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGold)).BeginInit();
            this.pnlBronze1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBronze1)).BeginInit();
            this.pnlBronze2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBronze2)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 7;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04943F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.934091F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04943F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.934091F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04943F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.934091F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04943F));
            this.tlpMain.Controls.Add(this.lblDetails, 0, 1);
            this.tlpMain.Controls.Add(this.pnlSilver, 0, 2);
            this.tlpMain.Controls.Add(this.pnlGold, 2, 2);
            this.tlpMain.Controls.Add(this.pnlBronze1, 4, 2);
            this.tlpMain.Controls.Add(this.pnlBronze2, 6, 2);
            this.tlpMain.Controls.Add(this.lblTournamentName, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpMain.Size = new System.Drawing.Size(640, 480);
            this.tlpMain.TabIndex = 0;
            // 
            // lblDetails
            // 
            this.lblDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.White;
            this.tlpMain.SetColumnSpan(this.lblDetails, 7);
            this.lblDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDetails.Image = null;
            this.lblDetails.Location = new System.Drawing.Point(3, 27);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(634, 18);
            this.lblDetails.TabIndex = 5;
            this.lblDetails.Text = "Details";
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDetails.TextPatternImage = null;
            // 
            // pnlSilver
            // 
            this.pnlSilver.Controls.Add(this.picSilver);
            this.pnlSilver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSilver.Location = new System.Drawing.Point(3, 51);
            this.pnlSilver.Name = "pnlSilver";
            this.pnlSilver.Size = new System.Drawing.Size(115, 426);
            this.pnlSilver.TabIndex = 0;
            // 
            // picSilver
            // 
            this.picSilver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSilver.Location = new System.Drawing.Point(3, 3);
            this.picSilver.Name = "picSilver";
            this.picSilver.Size = new System.Drawing.Size(109, 94);
            this.picSilver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSilver.TabIndex = 0;
            this.picSilver.TabStop = false;
            this.picSilver.Visible = false;
            // 
            // pnlGold
            // 
            this.pnlGold.Controls.Add(this.picGold);
            this.pnlGold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGold.Location = new System.Drawing.Point(174, 51);
            this.pnlGold.Name = "pnlGold";
            this.pnlGold.Size = new System.Drawing.Size(115, 426);
            this.pnlGold.TabIndex = 1;
            // 
            // picGold
            // 
            this.picGold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picGold.Location = new System.Drawing.Point(3, 3);
            this.picGold.Name = "picGold";
            this.picGold.Size = new System.Drawing.Size(109, 94);
            this.picGold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGold.TabIndex = 1;
            this.picGold.TabStop = false;
            this.picGold.Visible = false;
            // 
            // pnlBronze1
            // 
            this.pnlBronze1.Controls.Add(this.picBronze1);
            this.pnlBronze1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBronze1.Location = new System.Drawing.Point(345, 51);
            this.pnlBronze1.Name = "pnlBronze1";
            this.pnlBronze1.Size = new System.Drawing.Size(115, 426);
            this.pnlBronze1.TabIndex = 3;
            // 
            // picBronze1
            // 
            this.picBronze1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBronze1.Location = new System.Drawing.Point(3, 3);
            this.picBronze1.Name = "picBronze1";
            this.picBronze1.Size = new System.Drawing.Size(109, 94);
            this.picBronze1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBronze1.TabIndex = 1;
            this.picBronze1.TabStop = false;
            this.picBronze1.Visible = false;
            // 
            // pnlBronze2
            // 
            this.pnlBronze2.Controls.Add(this.picBronze2);
            this.pnlBronze2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBronze2.Location = new System.Drawing.Point(516, 51);
            this.pnlBronze2.Name = "pnlBronze2";
            this.pnlBronze2.Size = new System.Drawing.Size(121, 426);
            this.pnlBronze2.TabIndex = 2;
            // 
            // picBronze2
            // 
            this.picBronze2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBronze2.Location = new System.Drawing.Point(3, 3);
            this.picBronze2.Name = "picBronze2";
            this.picBronze2.Size = new System.Drawing.Size(113, 94);
            this.picBronze2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBronze2.TabIndex = 1;
            this.picBronze2.TabStop = false;
            this.picBronze2.Visible = false;
            // 
            // lblTournamentName
            // 
            this.lblTournamentName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTournamentName.AutoSize = true;
            this.lblTournamentName.BackColor = System.Drawing.Color.White;
            this.tlpMain.SetColumnSpan(this.lblTournamentName, 7);
            this.lblTournamentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTournamentName.Image = null;
            this.lblTournamentName.Location = new System.Drawing.Point(3, 3);
            this.lblTournamentName.Name = "lblTournamentName";
            this.lblTournamentName.Size = new System.Drawing.Size(634, 18);
            this.lblTournamentName.TabIndex = 4;
            this.lblTournamentName.Text = "Tournament Name";
            this.lblTournamentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTournamentName.TextPatternImage = null;
            // 
            // tmrMovement
            // 
            this.tmrMovement.Interval = 40;
            this.tmrMovement.Tick += new System.EventHandler(this.tmrMovement_Tick);
            // 
            // frmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Display";
            this.Load += new System.EventHandler(this.frmDisplay_Load);
            this.Resize += new System.EventHandler(this.frmDisplay_Resize);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.pnlSilver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSilver)).EndInit();
            this.pnlGold.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGold)).EndInit();
            this.pnlBronze1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBronze1)).EndInit();
            this.pnlBronze2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBronze2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlSilver;
        private System.Windows.Forms.PictureBox picSilver;
        private System.Windows.Forms.Panel pnlGold;
        private System.Windows.Forms.PictureBox picGold;
        private System.Windows.Forms.Panel pnlBronze1;
        private System.Windows.Forms.PictureBox picBronze1;
        private System.Windows.Forms.Panel pnlBronze2;
        private System.Windows.Forms.PictureBox picBronze2;
        private System.Windows.Forms.Timer tmrMovement;
        private CustomControls.LabelEx lblTournamentName;
        private CustomControls.LabelEx lblDetails;
    }
}