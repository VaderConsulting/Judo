using Utilities;

namespace JudoControls
{
    partial class JudoScoreboard
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
            this.components = new System.ComponentModel.Container();
            Judo.Score score1 = new Judo.Score();
            Judo.Score score2 = new Judo.Score();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.MatchData = new JudoControls.Scoreboard.MatchData();
            this.WhitePlayer = new JudoControls.Players();
            this.BluePlayer = new JudoControls.Players();
            this.tlpParent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMat = new CustomControls.LabelEx();
            this.tips = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpParent.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Controls.Add(this.MatchData, 0, 2);
            this.tlpMain.Controls.Add(this.WhitePlayer, 0, 0);
            this.tlpMain.Controls.Add(this.BluePlayer, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 47);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpMain.Size = new System.Drawing.Size(480, 270);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.Visible = false;
            // 
            // MatchData
            // 
            this.MatchData.AutoSize = true;
            this.MatchData.BackColor = System.Drawing.Color.Black;
            this.MatchData.Category = "Category";
            this.MatchData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MatchData.GoldenScore = true;
            this.MatchData.Location = new System.Drawing.Point(0, 179);
            this.MatchData.Margin = new System.Windows.Forms.Padding(0);
            this.MatchData.Name = "MatchData";
            this.MatchData.OsaekomiTimer = "00";
            this.MatchData.OsaekomiTimerState = Enums.TimerState.Unknown;
            this.MatchData.ProgressbarPosition = Enums.HorizontalPosition.Right;
            this.MatchData.Round = "Round";
            this.MatchData.Size = new System.Drawing.Size(480, 91);
            this.MatchData.TabIndex = 2;
            this.MatchData.Timer = "00:00";
            this.MatchData.TimerState = Enums.TimerState.Unknown;
            // 
            // WhitePlayer
            // 
            this.WhitePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WhitePlayer.Location = new System.Drawing.Point(6, 8);
            this.WhitePlayer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0); // 6, 8, 6, 8
            this.WhitePlayer.MatchInfo = "";
            this.WhitePlayer.Name = "WhitePlayer";
            this.WhitePlayer.PlayerColor = Enums.PlayerColors.White;
            this.WhitePlayer.PlayerName = null;
            this.WhitePlayer.PlayerNation = null;
            score1.HansokuMake = false;
            score1.Ippon = 0;
            score1.PenaltyImage = null;
            score1.Shido = 0;
            score1.WazaAri = 0;
            this.WhitePlayer.PlayerScore = score1;
            this.WhitePlayer.Size = new System.Drawing.Size(468, 73);
            this.WhitePlayer.TabIndex = 3;
            // 
            // BluePlayer
            // 
            this.BluePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BluePlayer.Location = new System.Drawing.Point(6, 97);
            this.BluePlayer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0); // 6, 8, 6, 8
            this.BluePlayer.MatchInfo = "";
            this.BluePlayer.Name = "BluePlayer";
            this.BluePlayer.PlayerColor = Enums.PlayerColors.Blue;
            this.BluePlayer.PlayerName = null;
            this.BluePlayer.PlayerNation = null;
            score2.HansokuMake = false;
            score2.Ippon = 0;
            score2.PenaltyImage = null;
            score2.Shido = 0;
            score2.WazaAri = 0;
            this.BluePlayer.PlayerScore = score2;
            this.BluePlayer.Size = new System.Drawing.Size(468, 74);
            this.BluePlayer.TabIndex = 4;
            // 
            // tlpParent
            // 
            this.tlpParent.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpParent.ColumnCount = 1;
            this.tlpParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParent.Controls.Add(this.tlpMain, 0, 1);
            this.tlpParent.Controls.Add(this.tlpTop, 0, 0);
            this.tlpParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tlpParent.Location = new System.Drawing.Point(0, 0);
            this.tlpParent.Margin = new System.Windows.Forms.Padding(0);
            this.tlpParent.Name = "tlpParent";
            this.tlpParent.RowCount = 2;
            this.tlpParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParent.Size = new System.Drawing.Size(482, 318);
            this.tlpParent.TabIndex = 1;
            // 
            // tlpTop
            // 
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpTop.Controls.Add(this.btnClose, 1, 0);
            this.tlpTop.Controls.Add(this.lblMat, 0, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(1, 1);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpTop.Size = new System.Drawing.Size(480, 45);
            this.tlpTop.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(439, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.tips.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMat
            // 
            this.lblMat.AutoSize = true;
            this.lblMat.BackColor = System.Drawing.SystemColors.Control;
            this.lblMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMat.Image = null;
            this.lblMat.Location = new System.Drawing.Point(4, 3);
            this.lblMat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(427, 39);
            this.lblMat.TabIndex = 2;
            this.lblMat.Text = "";
            this.lblMat.TextPatternImage = null;
            // 
            // JudoScoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpParent);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "JudoScoreboard";
            this.Size = new System.Drawing.Size(482, 318);
            this.Load += new System.EventHandler(this.JudoScoreboard_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpParent.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpParent;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.ToolTip tips;
        private System.Windows.Forms.Button btnClose;
        private Scoreboard.MatchData MatchData;
        private CustomControls.LabelEx lblMat;
        private Players WhitePlayer;
        private Players BluePlayer;
    }
}
