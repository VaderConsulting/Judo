namespace JudoControls.Scoreboard
{
    partial class MatchData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMatch = new System.Windows.Forms.TableLayoutPanel();
            this.pbrOsaekomi = new CustomControls.ProgressBarEx();
            this.lblRound = new CustomControls.LabelEx();
            this.lblCategory = new CustomControls.LabelEx();
            this.lblTimer = new CustomControls.LabelEx();
            this.tlpGSO = new System.Windows.Forms.TableLayoutPanel();
            this.lblOsaekomiTimer = new CustomControls.LabelEx();
            this.lblGoldenScore = new CustomControls.LabelEx();
            this.tlpMatch.SuspendLayout();
            this.tlpGSO.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMatch
            // 
            this.tlpMatch.ColumnCount = 3;
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tlpMatch.Controls.Add(this.pbrOsaekomi, 2, 0);
            this.tlpMatch.Controls.Add(this.lblRound, 0, 0);
            this.tlpMatch.Controls.Add(this.lblCategory, 0, 1);
            this.tlpMatch.Controls.Add(this.lblTimer, 1, 0);
            this.tlpMatch.Controls.Add(this.tlpGSO, 2, 1);
            this.tlpMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMatch.Location = new System.Drawing.Point(0, 0);
            this.tlpMatch.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMatch.Name = "tlpMatch";
            this.tlpMatch.RowCount = 2;
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMatch.Size = new System.Drawing.Size(579, 103);
            this.tlpMatch.TabIndex = 0;
            // 
            // pbrOsaekomi
            // 
            this.pbrOsaekomi.AutoSize = true;
            this.pbrOsaekomi.BackColor = System.Drawing.Color.Transparent;
            this.pbrOsaekomi.BackgroundColor = System.Drawing.Color.OrangeRed;
            this.pbrOsaekomi.Border = false;
            this.pbrOsaekomi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbrOsaekomi.GradiantColor = System.Drawing.Color.Black;
            this.pbrOsaekomi.GradiantPosition = CustomControls.ProgressBarEx.GradiantArea.None;
            this.pbrOsaekomi.Image = null;
            this.pbrOsaekomi.Location = new System.Drawing.Point(392, 0);
            this.pbrOsaekomi.Margin = new System.Windows.Forms.Padding(0);
            this.pbrOsaekomi.Maximum = 20;
            this.pbrOsaekomi.Name = "pbrOsaekomi";
            this.pbrOsaekomi.ProgressColor = System.Drawing.Color.Black;
            this.pbrOsaekomi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pbrOsaekomi.RoundedCorners = false;
            this.pbrOsaekomi.Size = new System.Drawing.Size(187, 51);
            this.pbrOsaekomi.Value = 20;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.BackColor = System.Drawing.Color.Black;
            this.lblRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRound.ForeColor = System.Drawing.Color.Lime;
            this.lblRound.Image = null;
            this.lblRound.Location = new System.Drawing.Point(3, 3);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(138, 45);
            this.lblRound.TabIndex = 0;
            this.lblRound.Text = "Round";
            this.lblRound.TextPatternImage = null;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Black;
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategory.ForeColor = System.Drawing.Color.Yellow;
            this.lblCategory.Image = null;
            this.lblCategory.Location = new System.Drawing.Point(3, 54);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(138, 46);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category";
            this.lblCategory.TextPatternImage = null;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Black;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.ForeColor = System.Drawing.Color.Lime;
            this.lblTimer.Image = null;
            this.lblTimer.Location = new System.Drawing.Point(147, 3);
            this.lblTimer.Name = "lblTimer";
            this.tlpMatch.SetRowSpan(this.lblTimer, 2);
            this.lblTimer.Size = new System.Drawing.Size(242, 97);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimer.TextPatternImage = null;
            // 
            // tlpGSO
            // 
            this.tlpGSO.ColumnCount = 2;
            this.tlpGSO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGSO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGSO.Controls.Add(this.lblOsaekomiTimer, 1, 0);
            this.tlpGSO.Controls.Add(this.lblGoldenScore, 0, 0);
            this.tlpGSO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGSO.Location = new System.Drawing.Point(392, 51);
            this.tlpGSO.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGSO.Name = "tlpGSO";
            this.tlpGSO.RowCount = 1;
            this.tlpGSO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGSO.Size = new System.Drawing.Size(187, 52);
            this.tlpGSO.TabIndex = 5;
            // 
            // lblOsaekomiTimer
            // 
            this.lblOsaekomiTimer.AutoSize = true;
            this.lblOsaekomiTimer.BackColor = System.Drawing.Color.Black;
            this.lblOsaekomiTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOsaekomiTimer.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblOsaekomiTimer.Image = null;
            this.lblOsaekomiTimer.Location = new System.Drawing.Point(93, 0);
            this.lblOsaekomiTimer.Margin = new System.Windows.Forms.Padding(0);
            this.lblOsaekomiTimer.Name = "lblOsaekomiTimer";
            this.lblOsaekomiTimer.Size = new System.Drawing.Size(94, 52);
            this.lblOsaekomiTimer.TabIndex = 0;
            this.lblOsaekomiTimer.Text = "00";
            this.lblOsaekomiTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOsaekomiTimer.TextPatternImage = null;
            this.lblOsaekomiTimer.Visible = false;
            // 
            // lblGoldenScore
            // 
            this.lblGoldenScore.AutoSize = true;
            this.lblGoldenScore.BackColor = System.Drawing.Color.Black;
            this.lblGoldenScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoldenScore.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblGoldenScore.Image = null;
            this.lblGoldenScore.Location = new System.Drawing.Point(0, 0);
            this.lblGoldenScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblGoldenScore.Name = "lblGoldenScore";
            this.lblGoldenScore.Size = new System.Drawing.Size(93, 52);
            this.lblGoldenScore.TabIndex = 1;
            this.lblGoldenScore.Text = "GS";
            this.lblGoldenScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGoldenScore.TextPatternImage = null;
            this.lblGoldenScore.Visible = false;
            // 
            // MatchData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tlpMatch);
            this.Name = "MatchData";
            this.Size = new System.Drawing.Size(579, 103);
            this.tlpMatch.ResumeLayout(false);
            this.tlpMatch.PerformLayout();
            this.tlpGSO.ResumeLayout(false);
            this.tlpGSO.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMatch;
        private CustomControls.LabelEx lblRound;
        private CustomControls.LabelEx lblCategory;
        private CustomControls.LabelEx lblTimer;
        private System.Windows.Forms.TableLayoutPanel tlpGSO;
        private CustomControls.LabelEx lblOsaekomiTimer;
        private CustomControls.LabelEx lblGoldenScore;
        private CustomControls.ProgressBarEx pbrOsaekomi;
    }
}
