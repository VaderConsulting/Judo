namespace GUITest
{
    partial class Form1
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
            Judo.Score score3 = new Judo.Score();
            Judo.Score score4 = new Judo.Score();
            this.tlpMatch = new System.Windows.Forms.TableLayoutPanel();
            this.White = new JudoControls.Player(Judo.Enums.PlayerColors.White);
            this.Blue = new JudoControls.Player(Judo.Enums.PlayerColors.Blue);
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblRound = new CustomControls.LabelEx();
            this.lblCategory = new CustomControls.LabelEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbrOsaekomi = new CustomControls.ProgressBarEx();
            this.lblTimer = new CustomControls.LabelEx();
            this.lblGoldenScore = new CustomControls.LabelEx();
            this.lblOsaekomiTimer = new CustomControls.LabelEx();
            this.tlpMatch.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMatch
            // 
            this.tlpMatch.ColumnCount = 1;
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMatch.Controls.Add(this.White, 0, 0);
            this.tlpMatch.Controls.Add(this.Blue, 0, 1);
            this.tlpMatch.Controls.Add(this.tlpInfo, 0, 2);
            this.tlpMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMatch.Location = new System.Drawing.Point(0, 0);
            this.tlpMatch.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMatch.Name = "tlpMatch";
            this.tlpMatch.RowCount = 3;
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMatch.Size = new System.Drawing.Size(385, 186);
            this.tlpMatch.TabIndex = 3;
            // 
            // White
            // 
            this.White.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.White.Dock = System.Windows.Forms.DockStyle.Fill;
            this.White.Location = new System.Drawing.Point(0, 0);
            this.White.Margin = new System.Windows.Forms.Padding(0);
            this.White.MatchInfo = "";
            this.White.Name = "White";
            this.White.PlayerName = null;
            this.White.PlayerNation = null;
            score3.HansokuMake = false;
            score3.Ippon = 0;
            score3.PenaltyImage = null;
            score3.Shido = 0;
            score3.WazaAri = 0;
            this.White.PlayerScore = score3;
            this.White.Size = new System.Drawing.Size(385, 61);
            this.White.TabIndex = 1;
            // 
            // Blue
            // 
            this.Blue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Blue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Blue.Location = new System.Drawing.Point(0, 61);
            this.Blue.Margin = new System.Windows.Forms.Padding(0);
            this.Blue.MatchInfo = "";
            this.Blue.Name = "Blue";
            this.Blue.PlayerName = null;
            this.Blue.PlayerNation = null;
            score4.HansokuMake = false;
            score4.Ippon = 0;
            score4.PenaltyImage = null;
            score4.Shido = 0;
            score4.WazaAri = 0;
            this.Blue.PlayerScore = score4;
            this.Blue.Size = new System.Drawing.Size(385, 61);
            this.Blue.TabIndex = 2;
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 2;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpInfo.Controls.Add(this.lblRound, 0, 0);
            this.tlpInfo.Controls.Add(this.lblCategory, 0, 1);
            this.tlpInfo.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.Location = new System.Drawing.Point(0, 122);
            this.tlpInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 2;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.Size = new System.Drawing.Size(385, 64);
            this.tlpInfo.TabIndex = 3;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.BackColor = System.Drawing.Color.Black;
            this.lblRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRound.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblRound.Image = null;
            this.lblRound.Location = new System.Drawing.Point(0, 0);
            this.lblRound.Margin = new System.Windows.Forms.Padding(0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(77, 32);
            this.lblRound.TabIndex = 0;
            this.lblRound.Text = "";
            this.lblRound.TextPatternImage = null;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Black;
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategory.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblCategory.Image = null;
            this.lblCategory.Location = new System.Drawing.Point(0, 32);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(77, 32);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "";
            this.lblCategory.TextPatternImage = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.lblTimer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbrOsaekomi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblGoldenScore, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOsaekomiTimer, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(77, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tlpInfo.SetRowSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 64);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pbrOsaekomi
            // 
            this.pbrOsaekomi.BackColor = System.Drawing.Color.Transparent;
            this.pbrOsaekomi.BackgroundColor = System.Drawing.Color.Black;
            this.pbrOsaekomi.Border = false;
            this.tableLayoutPanel1.SetColumnSpan(this.pbrOsaekomi, 2);
            this.pbrOsaekomi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbrOsaekomi.ForeColor = System.Drawing.Color.Cornsilk;
            this.pbrOsaekomi.GradiantColor = System.Drawing.Color.OrangeRed;
            this.pbrOsaekomi.GradiantPosition = CustomControls.ProgressBarEx.GradiantArea.None;
            this.pbrOsaekomi.Image = null;
            this.pbrOsaekomi.Location = new System.Drawing.Point(215, 0);
            this.pbrOsaekomi.Margin = new System.Windows.Forms.Padding(0);
            this.pbrOsaekomi.Maximum = 20;
            this.pbrOsaekomi.Name = "pbrOsaekomi";
            this.pbrOsaekomi.ProgressColor = System.Drawing.Color.OrangeRed;
            this.pbrOsaekomi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pbrOsaekomi.Size = new System.Drawing.Size(93, 32);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Black;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblTimer.Image = null;
            this.lblTimer.Location = new System.Drawing.Point(0, 0);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(0);
            this.lblTimer.Name = "lblTimer";
            this.tableLayoutPanel1.SetRowSpan(this.lblTimer, 2);
            this.lblTimer.Size = new System.Drawing.Size(215, 64);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "";
            this.lblTimer.TextPatternImage = null;
            // 
            // lblGoldenScore
            // 
            this.lblGoldenScore.AutoSize = true;
            this.lblGoldenScore.BackColor = System.Drawing.Color.Black;
            this.lblGoldenScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoldenScore.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblGoldenScore.Image = null;
            this.lblGoldenScore.Location = new System.Drawing.Point(215, 32);
            this.lblGoldenScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblGoldenScore.Name = "lblGoldenScore";
            this.lblGoldenScore.Size = new System.Drawing.Size(46, 32);
            this.lblGoldenScore.TabIndex = 12;
            this.lblGoldenScore.Text = "";
            this.lblGoldenScore.TextPatternImage = null;
            // 
            // lblOsaekomiTimer
            // 
            this.lblOsaekomiTimer.AutoSize = true;
            this.lblOsaekomiTimer.BackColor = System.Drawing.Color.Black;
            this.lblOsaekomiTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOsaekomiTimer.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblOsaekomiTimer.Image = null;
            this.lblOsaekomiTimer.Location = new System.Drawing.Point(261, 32);
            this.lblOsaekomiTimer.Margin = new System.Windows.Forms.Padding(0);
            this.lblOsaekomiTimer.Name = "lblOsaekomiTimer";
            this.lblOsaekomiTimer.Size = new System.Drawing.Size(47, 32);
            this.lblOsaekomiTimer.TabIndex = 13;
            this.lblOsaekomiTimer.Text = "";
            this.lblOsaekomiTimer.TextPatternImage = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(385, 186);
            this.Controls.Add(this.tlpMatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example Scoreboard";
            this.tlpMatch.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.tlpInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private JudoControls.Player White;
        private JudoControls.Player Blue;
        private System.Windows.Forms.TableLayoutPanel tlpMatch;
        private CustomControls.ProgressBarEx pbrOsaekomi;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private CustomControls.LabelEx lblRound;
        private CustomControls.LabelEx lblCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.LabelEx lblTimer;
        private CustomControls.LabelEx lblGoldenScore;
        private CustomControls.LabelEx lblOsaekomiTimer;
    }
}

