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
            tlpMatch = new System.Windows.Forms.TableLayoutPanel();
            pbrOsaekomi = new CustomControls.ProgressBarEx();
            lblRound = new CustomControls.LabelEx();
            lblCategory = new CustomControls.LabelEx();
            lblTimer = new CustomControls.LabelEx();
            tlpGSO = new System.Windows.Forms.TableLayoutPanel();
            lblOsaekomiTimer = new CustomControls.LabelEx();
            lblGoldenScore = new CustomControls.LabelEx();
            tlpMatch.SuspendLayout();
            tlpGSO.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMatch
            // 
            tlpMatch.ColumnCount = 3;
            tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tlpMatch.Controls.Add(pbrOsaekomi, 2, 0);
            tlpMatch.Controls.Add(lblRound, 0, 0);
            tlpMatch.Controls.Add(lblCategory, 0, 2);
            tlpMatch.Controls.Add(lblTimer, 1, 0);
            tlpMatch.Controls.Add(tlpGSO, 2, 1);
            tlpMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpMatch.Location = new System.Drawing.Point(0, 0);
            tlpMatch.Margin = new System.Windows.Forms.Padding(0);
            tlpMatch.Name = "tlpMatch";
            tlpMatch.RowCount = 4;
            tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tlpMatch.Size = new System.Drawing.Size(450, 77);
            tlpMatch.TabIndex = 0;
            // 
            // pbrOsaekomi
            // 
            pbrOsaekomi.AutoSize = true;
            pbrOsaekomi.BackColor = System.Drawing.Color.Transparent;
            pbrOsaekomi.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            pbrOsaekomi.Border = false;
            pbrOsaekomi.Dock = System.Windows.Forms.DockStyle.Fill;
            pbrOsaekomi.GradientColor = System.Drawing.Color.Black;
            pbrOsaekomi.GradientPosition = CustomControls.ProgressBarEx.GradientArea.None;
            pbrOsaekomi.Image = null;
            pbrOsaekomi.Location = new System.Drawing.Point(337, 0);
            pbrOsaekomi.Margin = new System.Windows.Forms.Padding(0);
            pbrOsaekomi.Maximum = 20;
            pbrOsaekomi.Name = "pbrOsaekomi";
            pbrOsaekomi.ProgressColor = System.Drawing.Color.OrangeRed;
            pbrOsaekomi.RoundedCorners = false;
            pbrOsaekomi.Size = new System.Drawing.Size(113, 19);
            // 
            // lblRound
            // 
            lblRound.AutoSize = true;
            lblRound.BackColor = System.Drawing.Color.Black;
            lblRound.BackgroundImage = null;
            lblRound.Dock = System.Windows.Forms.DockStyle.Fill;
            lblRound.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblRound.ForeColor = System.Drawing.Color.White;
            lblRound.Image = null;
            lblRound.Location = new System.Drawing.Point(2, 2);
            lblRound.Margin = new System.Windows.Forms.Padding(2);
            lblRound.Name = "lblRound";
            tlpMatch.SetRowSpan(lblRound, 2);
            lblRound.Size = new System.Drawing.Size(108, 34);
            lblRound.TabIndex = 0;
            lblRound.Text = "Round";
            lblRound.TextPatternImage = null;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = System.Drawing.Color.Black;
            lblCategory.BackgroundImage = null;
            lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblCategory.ForeColor = System.Drawing.Color.White;
            lblCategory.Image = null;
            lblCategory.Location = new System.Drawing.Point(2, 40);
            lblCategory.Margin = new System.Windows.Forms.Padding(2);
            lblCategory.Name = "lblCategory";
            tlpMatch.SetRowSpan(lblCategory, 2);
            lblCategory.Size = new System.Drawing.Size(108, 35);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Category";
            lblCategory.TextPatternImage = null;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = System.Drawing.Color.Black;
            lblTimer.BackgroundImage = null;
            lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTimer.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            lblTimer.ForeColor = System.Drawing.Color.Lime;
            lblTimer.Image = null;
            lblTimer.Location = new System.Drawing.Point(114, 2);
            lblTimer.Margin = new System.Windows.Forms.Padding(2);
            lblTimer.Name = "lblTimer";
            tlpMatch.SetRowSpan(lblTimer, 4);
            lblTimer.Size = new System.Drawing.Size(221, 73);
            lblTimer.TabIndex = 2;
            lblTimer.Text = "00:00";
            lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTimer.TextPatternImage = null;
            // 
            // tlpGSO
            // 
            tlpGSO.ColumnCount = 2;
            tlpGSO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpGSO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpGSO.Controls.Add(lblOsaekomiTimer, 1, 0);
            tlpGSO.Controls.Add(lblGoldenScore, 0, 0);
            tlpGSO.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpGSO.Location = new System.Drawing.Point(337, 19);
            tlpGSO.Margin = new System.Windows.Forms.Padding(0);
            tlpGSO.Name = "tlpGSO";
            tlpGSO.RowCount = 2;
            tlpMatch.SetRowSpan(tlpGSO, 3);
            tlpGSO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpGSO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            tlpGSO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            tlpGSO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            tlpGSO.Size = new System.Drawing.Size(113, 58);
            tlpGSO.TabIndex = 5;
            // 
            // lblOsaekomiTimer
            // 
            lblOsaekomiTimer.AutoSize = true;
            lblOsaekomiTimer.BackColor = System.Drawing.Color.Black;
            lblOsaekomiTimer.BackgroundImage = null;
            lblOsaekomiTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOsaekomiTimer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblOsaekomiTimer.ForeColor = System.Drawing.Color.DeepSkyBlue;
            lblOsaekomiTimer.Image = null;
            lblOsaekomiTimer.Location = new System.Drawing.Point(56, 0);
            lblOsaekomiTimer.Margin = new System.Windows.Forms.Padding(0);
            lblOsaekomiTimer.Name = "lblOsaekomiTimer";
            tlpGSO.SetRowSpan(lblOsaekomiTimer, 4);
            lblOsaekomiTimer.ShadowColor = System.Drawing.Color.White;
            lblOsaekomiTimer.ShadowDepth = 1;
            lblOsaekomiTimer.ShowTextShadow = true;
            lblOsaekomiTimer.Size = new System.Drawing.Size(57, 58);
            lblOsaekomiTimer.TabIndex = 0;
            lblOsaekomiTimer.Text = "00";
            lblOsaekomiTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblOsaekomiTimer.TextPatternImage = null;
            lblOsaekomiTimer.Visible = false;
            // 
            // lblGoldenScore
            // 
            lblGoldenScore.AutoSize = true;
            lblGoldenScore.BackColor = System.Drawing.Color.Black;
            lblGoldenScore.BackgroundImage = null;
            lblGoldenScore.Dock = System.Windows.Forms.DockStyle.Fill;
            lblGoldenScore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblGoldenScore.ForeColor = System.Drawing.Color.OrangeRed;
            lblGoldenScore.Image = null;
            lblGoldenScore.Location = new System.Drawing.Point(0, 0);
            lblGoldenScore.Margin = new System.Windows.Forms.Padding(0);
            lblGoldenScore.Name = "lblGoldenScore";
            tlpGSO.SetRowSpan(lblGoldenScore, 4);
            lblGoldenScore.Size = new System.Drawing.Size(56, 58);
            lblGoldenScore.TabIndex = 1;
            lblGoldenScore.Text = "GS";
            lblGoldenScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblGoldenScore.TextPatternImage = null;
            lblGoldenScore.Visible = false;
            // 
            // MatchData
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            Controls.Add(tlpMatch);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "MatchData";
            Size = new System.Drawing.Size(450, 77);
            tlpMatch.ResumeLayout(false);
            tlpMatch.PerformLayout();
            tlpGSO.ResumeLayout(false);
            tlpGSO.PerformLayout();
            ResumeLayout(false);
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
