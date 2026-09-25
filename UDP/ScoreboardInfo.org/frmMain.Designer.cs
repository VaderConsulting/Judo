namespace Scoreboards
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMats = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMat6 = new System.Windows.Forms.Panel();
            this.judoScoreboard6 = new JudoControls.JudoScoreboard();
            this.pnlMat5 = new System.Windows.Forms.Panel();
            this.judoScoreboard5 = new JudoControls.JudoScoreboard();
            this.pnlMat4 = new System.Windows.Forms.Panel();
            this.judoScoreboard4 = new JudoControls.JudoScoreboard();
            this.pnlMat3 = new System.Windows.Forms.Panel();
            this.judoScoreboard3 = new JudoControls.JudoScoreboard();
            this.pnlMat2 = new System.Windows.Forms.Panel();
            this.judoScoreboard2 = new JudoControls.JudoScoreboard();
            this.pnlMat1 = new System.Windows.Forms.Panel();
            this.judoScoreboard1 = new JudoControls.JudoScoreboard();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtUpcomingMatch1 = new System.Windows.Forms.TextBox();
            this.lblUpcomingMatch = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvwMain = new System.Windows.Forms.TreeView();
            this.txtUpcomingMatch2 = new System.Windows.Forms.TextBox();
            this.txtUpcomingMatch3 = new System.Windows.Forms.TextBox();
            this.txtUpcomingMatch4 = new System.Windows.Forms.TextBox();
            this.txtUpcomingMatch5 = new System.Windows.Forms.TextBox();
            this.txtUpcomingMatch6 = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpMats.SuspendLayout();
            this.pnlMat6.SuspendLayout();
            this.pnlMat5.SuspendLayout();
            this.pnlMat4.SuspendLayout();
            this.pnlMat3.SuspendLayout();
            this.pnlMat2.SuspendLayout();
            this.pnlMat1.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(755, 537);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tlpMain);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(747, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpMats, 0, 0);
            this.tlpMain.Controls.Add(this.pnlInfo, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.6F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
            this.tlpMain.Size = new System.Drawing.Size(741, 505);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpMats
            // 
            this.tlpMats.ColumnCount = 3;
            this.tlpMats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpMats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMats.Controls.Add(this.pnlMat6, 2, 1);
            this.tlpMats.Controls.Add(this.pnlMat5, 1, 1);
            this.tlpMats.Controls.Add(this.pnlMat4, 0, 1);
            this.tlpMats.Controls.Add(this.pnlMat3, 2, 0);
            this.tlpMats.Controls.Add(this.pnlMat2, 1, 0);
            this.tlpMats.Controls.Add(this.pnlMat1, 0, 0);
            this.tlpMats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMats.Location = new System.Drawing.Point(3, 3);
            this.tlpMats.Name = "tlpMats";
            this.tlpMats.RowCount = 2;
            this.tlpMats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMats.Size = new System.Drawing.Size(735, 330);
            this.tlpMats.TabIndex = 0;
            // 
            // pnlMat6
            // 
            this.pnlMat6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMat6.Controls.Add(this.judoScoreboard6);
            this.pnlMat6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMat6.Location = new System.Drawing.Point(492, 168);
            this.pnlMat6.Name = "pnlMat6";
            this.pnlMat6.Size = new System.Drawing.Size(240, 159);
            this.pnlMat6.TabIndex = 5;
            // 
            // judoScoreboard6
            // 
            this.judoScoreboard6.BackColor = System.Drawing.SystemColors.Control;
            this.judoScoreboard6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.judoScoreboard6.Location = new System.Drawing.Point(0, 0);
            this.judoScoreboard6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.judoScoreboard6.Name = "judoScoreboard6";
            this.judoScoreboard6.Size = new System.Drawing.Size(238, 157);
            this.judoScoreboard6.TabIndex = 1;
            // 
            // pnlMat5
            // 
            this.pnlMat5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMat5.Controls.Add(this.judoScoreboard5);
            this.pnlMat5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMat5.Location = new System.Drawing.Point(247, 168);
            this.pnlMat5.Name = "pnlMat5";
            this.pnlMat5.Size = new System.Drawing.Size(239, 159);
            this.pnlMat5.TabIndex = 4;
            // 
            // judoScoreboard5
            // 
            this.judoScoreboard5.BackColor = System.Drawing.SystemColors.Control;
            this.judoScoreboard5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.judoScoreboard5.Location = new System.Drawing.Point(0, 0);
            this.judoScoreboard5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.judoScoreboard5.Name = "judoScoreboard5";
            this.judoScoreboard5.Size = new System.Drawing.Size(237, 157);
            this.judoScoreboard5.TabIndex = 1;
            // 
            // pnlMat4
            // 
            this.pnlMat4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMat4.Controls.Add(this.judoScoreboard4);
            this.pnlMat4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMat4.Location = new System.Drawing.Point(3, 168);
            this.pnlMat4.Name = "pnlMat4";
            this.pnlMat4.Size = new System.Drawing.Size(238, 159);
            this.pnlMat4.TabIndex = 3;
            // 
            // judoScoreboard4
            // 
            this.judoScoreboard4.BackColor = System.Drawing.SystemColors.Control;
            this.judoScoreboard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.judoScoreboard4.Location = new System.Drawing.Point(0, 0);
            this.judoScoreboard4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.judoScoreboard4.Name = "judoScoreboard4";
            this.judoScoreboard4.Size = new System.Drawing.Size(236, 157);
            this.judoScoreboard4.TabIndex = 1;
            // 
            // pnlMat3
            // 
            this.pnlMat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMat3.Controls.Add(this.judoScoreboard3);
            this.pnlMat3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMat3.Location = new System.Drawing.Point(492, 3);
            this.pnlMat3.Name = "pnlMat3";
            this.pnlMat3.Size = new System.Drawing.Size(240, 159);
            this.pnlMat3.TabIndex = 2;
            // 
            // judoScoreboard3
            // 
            this.judoScoreboard3.BackColor = System.Drawing.SystemColors.Control;
            this.judoScoreboard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.judoScoreboard3.Location = new System.Drawing.Point(0, 0);
            this.judoScoreboard3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.judoScoreboard3.Name = "judoScoreboard3";
            this.judoScoreboard3.Size = new System.Drawing.Size(238, 157);
            this.judoScoreboard3.TabIndex = 1;
            // 
            // pnlMat2
            // 
            this.pnlMat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMat2.Controls.Add(this.judoScoreboard2);
            this.pnlMat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMat2.Location = new System.Drawing.Point(247, 3);
            this.pnlMat2.Name = "pnlMat2";
            this.pnlMat2.Size = new System.Drawing.Size(239, 159);
            this.pnlMat2.TabIndex = 1;
            // 
            // judoScoreboard2
            // 
            this.judoScoreboard2.BackColor = System.Drawing.SystemColors.Control;
            this.judoScoreboard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.judoScoreboard2.Location = new System.Drawing.Point(0, 0);
            this.judoScoreboard2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.judoScoreboard2.Name = "judoScoreboard2";
            this.judoScoreboard2.Size = new System.Drawing.Size(237, 157);
            this.judoScoreboard2.TabIndex = 0;
            // 
            // pnlMat1
            // 
            this.pnlMat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMat1.Controls.Add(this.judoScoreboard1);
            this.pnlMat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMat1.Location = new System.Drawing.Point(3, 3);
            this.pnlMat1.Name = "pnlMat1";
            this.pnlMat1.Size = new System.Drawing.Size(238, 159);
            this.pnlMat1.TabIndex = 0;
            // 
            // judoScoreboard1
            // 
            this.judoScoreboard1.BackColor = System.Drawing.SystemColors.Control;
            this.judoScoreboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.judoScoreboard1.Location = new System.Drawing.Point(0, 0);
            this.judoScoreboard1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.judoScoreboard1.Name = "judoScoreboard1";
            this.judoScoreboard1.Size = new System.Drawing.Size(236, 157);
            this.judoScoreboard1.TabIndex = 0;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.txtUpcomingMatch6);
            this.pnlInfo.Controls.Add(this.txtUpcomingMatch5);
            this.pnlInfo.Controls.Add(this.txtUpcomingMatch4);
            this.pnlInfo.Controls.Add(this.txtUpcomingMatch3);
            this.pnlInfo.Controls.Add(this.txtUpcomingMatch2);
            this.pnlInfo.Controls.Add(this.txtUpcomingMatch1);
            this.pnlInfo.Controls.Add(this.lblUpcomingMatch);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(3, 339);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(735, 163);
            this.pnlInfo.TabIndex = 1;
            // 
            // txtUpcomingMatch1
            // 
            this.txtUpcomingMatch1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpcomingMatch1.Location = new System.Drawing.Point(106, 7);
            this.txtUpcomingMatch1.Name = "txtUpcomingMatch1";
            this.txtUpcomingMatch1.ReadOnly = true;
            this.txtUpcomingMatch1.Size = new System.Drawing.Size(625, 20);
            this.txtUpcomingMatch1.TabIndex = 3;
            // 
            // lblUpcomingMatch
            // 
            this.lblUpcomingMatch.AutoSize = true;
            this.lblUpcomingMatch.Location = new System.Drawing.Point(1, 10);
            this.lblUpcomingMatch.Name = "lblUpcomingMatch";
            this.lblUpcomingMatch.Size = new System.Drawing.Size(99, 13);
            this.lblUpcomingMatch.TabIndex = 2;
            this.lblUpcomingMatch.Text = "Upcoming Matches";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvwMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(747, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tree";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvwMain
            // 
            this.tvwMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwMain.Location = new System.Drawing.Point(6, 6);
            this.tvwMain.Name = "tvwMain";
            this.tvwMain.Size = new System.Drawing.Size(245, 499);
            this.tvwMain.TabIndex = 0;
            // 
            // txtUpcomingMatch2
            // 
            this.txtUpcomingMatch2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpcomingMatch2.Location = new System.Drawing.Point(106, 33);
            this.txtUpcomingMatch2.Name = "txtUpcomingMatch2";
            this.txtUpcomingMatch2.ReadOnly = true;
            this.txtUpcomingMatch2.Size = new System.Drawing.Size(625, 20);
            this.txtUpcomingMatch2.TabIndex = 4;
            // 
            // txtUpcomingMatch3
            // 
            this.txtUpcomingMatch3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpcomingMatch3.Location = new System.Drawing.Point(106, 59);
            this.txtUpcomingMatch3.Name = "txtUpcomingMatch3";
            this.txtUpcomingMatch3.ReadOnly = true;
            this.txtUpcomingMatch3.Size = new System.Drawing.Size(625, 20);
            this.txtUpcomingMatch3.TabIndex = 5;
            // 
            // txtUpcomingMatch4
            // 
            this.txtUpcomingMatch4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpcomingMatch4.Location = new System.Drawing.Point(106, 85);
            this.txtUpcomingMatch4.Name = "txtUpcomingMatch4";
            this.txtUpcomingMatch4.ReadOnly = true;
            this.txtUpcomingMatch4.Size = new System.Drawing.Size(625, 20);
            this.txtUpcomingMatch4.TabIndex = 6;
            // 
            // txtUpcomingMatch5
            // 
            this.txtUpcomingMatch5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpcomingMatch5.Location = new System.Drawing.Point(106, 111);
            this.txtUpcomingMatch5.Name = "txtUpcomingMatch5";
            this.txtUpcomingMatch5.ReadOnly = true;
            this.txtUpcomingMatch5.Size = new System.Drawing.Size(625, 20);
            this.txtUpcomingMatch5.TabIndex = 7;
            // 
            // txtUpcomingMatch6
            // 
            this.txtUpcomingMatch6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpcomingMatch6.Location = new System.Drawing.Point(106, 137);
            this.txtUpcomingMatch6.Name = "txtUpcomingMatch6";
            this.txtUpcomingMatch6.ReadOnly = true;
            this.txtUpcomingMatch6.Size = new System.Drawing.Size(625, 20);
            this.txtUpcomingMatch6.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 561);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scoreboards";
            this.Load += new System.EventHandler(this.frmScoreboard_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabMain.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMats.ResumeLayout(false);
            this.pnlMat6.ResumeLayout(false);
            this.pnlMat5.ResumeLayout(false);
            this.pnlMat4.ResumeLayout(false);
            this.pnlMat3.ResumeLayout(false);
            this.pnlMat2.ResumeLayout(false);
            this.pnlMat1.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView tvwMain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpMats;
        private System.Windows.Forms.Panel pnlMat6;
        private System.Windows.Forms.Panel pnlMat5;
        private System.Windows.Forms.Panel pnlMat4;
        private System.Windows.Forms.Panel pnlMat3;
        private System.Windows.Forms.Panel pnlMat2;
        private System.Windows.Forms.Panel pnlMat1;
        private JudoControls.JudoScoreboard judoScoreboard1;
        private JudoControls.JudoScoreboard judoScoreboard6;
        private JudoControls.JudoScoreboard judoScoreboard5;
        private JudoControls.JudoScoreboard judoScoreboard4;
        private JudoControls.JudoScoreboard judoScoreboard3;
        private JudoControls.JudoScoreboard judoScoreboard2;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtUpcomingMatch1;
        private System.Windows.Forms.Label lblUpcomingMatch;
        private System.Windows.Forms.TextBox txtUpcomingMatch6;
        private System.Windows.Forms.TextBox txtUpcomingMatch5;
        private System.Windows.Forms.TextBox txtUpcomingMatch4;
        private System.Windows.Forms.TextBox txtUpcomingMatch3;
        private System.Windows.Forms.TextBox txtUpcomingMatch2;
    }
}

