namespace Judo_Scoreboard
{
    partial class frmScoreboard
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
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.tmrSecondary = new System.Windows.Forms.Timer(this.components);
            this.tlp3Rows = new System.Windows.Forms.TableLayoutPanel();
            this.tlpThirdRow = new System.Windows.Forms.TableLayoutPanel();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.picSpecialNeeds = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.picCategoryWeight = new System.Windows.Forms.PictureBox();
            this.picCategoryDescription = new System.Windows.Forms.PictureBox();
            this.picCategoryName = new System.Windows.Forms.PictureBox();
            this.tlpMainTimer = new System.Windows.Forms.TableLayoutPanel();
            this.picMainTimer = new System.Windows.Forms.PictureBox();
            this.tlpOsaekomiTimer = new System.Windows.Forms.TableLayoutPanel();
            this.picOsaekomiTimer = new System.Windows.Forms.PictureBox();
            this.picOsaekomiText = new System.Windows.Forms.PictureBox();
            this.transparentTableLayoutPanel1 = new TransparentTableLayoutPanel();
            this.picGoldenScore = new System.Windows.Forms.PictureBox();
            this.pnlPlayer2 = new System.Windows.Forms.Panel();
            this.tlpPlayer2 = new TransparentTableLayoutPanel();
            this.tlpPlayer2Row2 = new TransparentTableLayoutPanel();
            this.picPlayer2ClubName = new System.Windows.Forms.PictureBox();
            this.picPlayer2Score = new System.Windows.Forms.PictureBox();
            this.picPlayer2WazaAri = new System.Windows.Forms.PictureBox();
            this.picPlayer2Shido = new System.Windows.Forms.PictureBox();
            this.tlpPlayer2Top = new TransparentTableLayoutPanel();
            this.picPlayer2Logo = new System.Windows.Forms.PictureBox();
            this.picPlayer2Surname = new System.Windows.Forms.PictureBox();
            this.pnlPlayer1 = new System.Windows.Forms.Panel();
            this.tlpPlayer1 = new TransparentTableLayoutPanel();
            this.tlpPlayer1Row2 = new TransparentTableLayoutPanel();
            this.picPlayer1ClubName = new System.Windows.Forms.PictureBox();
            this.picPlayer1Score = new System.Windows.Forms.PictureBox();
            this.picPlayer1WazaAri = new System.Windows.Forms.PictureBox();
            this.picPlayer1Shido = new System.Windows.Forms.PictureBox();
            this.tlpPlayer1Top = new TransparentTableLayoutPanel();
            this.picPlayer1Logo = new System.Windows.Forms.PictureBox();
            this.picPlayer1Surname = new System.Windows.Forms.PictureBox();
            this.tmrPlayer1Score = new System.Windows.Forms.Timer(this.components);
            this.tmrPlayer2Score = new System.Windows.Forms.Timer(this.components);
            this.btnResetTimer = new System.Windows.Forms.Button();
            this.tlp3Rows.SuspendLayout();
            this.tlpThirdRow.SuspendLayout();
            this.tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpecialNeeds)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryName)).BeginInit();
            this.tlpMainTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainTimer)).BeginInit();
            this.tlpOsaekomiTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOsaekomiTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOsaekomiText)).BeginInit();
            this.transparentTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGoldenScore)).BeginInit();
            this.pnlPlayer2.SuspendLayout();
            this.tlpPlayer2.SuspendLayout();
            this.tlpPlayer2Row2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2ClubName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2WazaAri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Shido)).BeginInit();
            this.tlpPlayer2Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Surname)).BeginInit();
            this.pnlPlayer1.SuspendLayout();
            this.tlpPlayer1.SuspendLayout();
            this.tlpPlayer1Row2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1ClubName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1WazaAri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Shido)).BeginInit();
            this.tlpPlayer1Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Surname)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // tmrSecondary
            // 
            this.tmrSecondary.Interval = 1000;
            this.tmrSecondary.Tick += new System.EventHandler(this.tmrSecondary_Tick);
            // 
            // tlp3Rows
            // 
            this.tlp3Rows.ColumnCount = 1;
            this.tlp3Rows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp3Rows.Controls.Add(this.tlpThirdRow, 0, 2);
            this.tlp3Rows.Controls.Add(this.pnlPlayer2, 0, 1);
            this.tlp3Rows.Controls.Add(this.pnlPlayer1, 0, 0);
            this.tlp3Rows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp3Rows.Location = new System.Drawing.Point(0, 0);
            this.tlp3Rows.Name = "tlp3Rows";
            this.tlp3Rows.RowCount = 3;
            this.tlp3Rows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlp3Rows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlp3Rows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp3Rows.Size = new System.Drawing.Size(784, 561);
            this.tlp3Rows.TabIndex = 0;
            // 
            // tlpThirdRow
            // 
            this.tlpThirdRow.ColumnCount = 4;
            this.tlpThirdRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpThirdRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpThirdRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpThirdRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpThirdRow.Controls.Add(this.tlp, 0, 0);
            this.tlpThirdRow.Controls.Add(this.tlpMainTimer, 1, 0);
            this.tlpThirdRow.Controls.Add(this.tlpOsaekomiTimer, 3, 0);
            this.tlpThirdRow.Controls.Add(this.transparentTableLayoutPanel1, 2, 0);
            this.tlpThirdRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThirdRow.Location = new System.Drawing.Point(3, 395);
            this.tlpThirdRow.Name = "tlpThirdRow";
            this.tlpThirdRow.RowCount = 1;
            this.tlpThirdRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThirdRow.Size = new System.Drawing.Size(778, 163);
            this.tlpThirdRow.TabIndex = 0;
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 3;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp.Controls.Add(this.picSpecialNeeds, 0, 1);
            this.tlp.Controls.Add(this.pnlMenu, 0, 4);
            this.tlp.Controls.Add(this.picCategoryWeight, 1, 3);
            this.tlp.Controls.Add(this.picCategoryDescription, 1, 2);
            this.tlp.Controls.Add(this.picCategoryName, 1, 1);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(3, 3);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 5;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp.Size = new System.Drawing.Size(250, 157);
            this.tlp.TabIndex = 0;
            // 
            // picSpecialNeeds
            // 
            this.picSpecialNeeds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSpecialNeeds.Image = global::Judo_Scoreboard.Properties.Resources.ISA;
            this.picSpecialNeeds.Location = new System.Drawing.Point(3, 18);
            this.picSpecialNeeds.Name = "picSpecialNeeds";
            this.picSpecialNeeds.Size = new System.Drawing.Size(19, 41);
            this.picSpecialNeeds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSpecialNeeds.TabIndex = 7;
            this.picSpecialNeeds.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnConnect);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(3, 143);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(19, 11);
            this.pnlMenu.TabIndex = 7;
            this.pnlMenu.MouseEnter += new System.EventHandler(this.pnlMenu_MouseEnter);
            this.pnlMenu.MouseLeave += new System.EventHandler(this.pnlMenu_MouseLeave);
            // 
            // btnConnect
            // 
            this.btnConnect.BackgroundImage = global::Judo_Scoreboard.Properties.Resources.connection_error;
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Location = new System.Drawing.Point(0, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(19, 11);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // picCategoryWeight
            // 
            this.picCategoryWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCategoryWeight.Location = new System.Drawing.Point(28, 112);
            this.picCategoryWeight.Name = "picCategoryWeight";
            this.picCategoryWeight.Size = new System.Drawing.Size(194, 25);
            this.picCategoryWeight.TabIndex = 1;
            this.picCategoryWeight.TabStop = false;
            // 
            // picCategoryDescription
            // 
            this.picCategoryDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCategoryDescription.Location = new System.Drawing.Point(28, 65);
            this.picCategoryDescription.Name = "picCategoryDescription";
            this.picCategoryDescription.Size = new System.Drawing.Size(194, 41);
            this.picCategoryDescription.TabIndex = 5;
            this.picCategoryDescription.TabStop = false;
            // 
            // picCategoryName
            // 
            this.picCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCategoryName.Location = new System.Drawing.Point(28, 18);
            this.picCategoryName.Name = "picCategoryName";
            this.picCategoryName.Size = new System.Drawing.Size(194, 41);
            this.picCategoryName.TabIndex = 6;
            this.picCategoryName.TabStop = false;
            // 
            // tlpMainTimer
            // 
            this.tlpMainTimer.ColumnCount = 3;
            this.tlpMainTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMainTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpMainTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMainTimer.Controls.Add(this.btnResetTimer, 0, 2);
            this.tlpMainTimer.Controls.Add(this.picMainTimer, 1, 1);
            this.tlpMainTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainTimer.Location = new System.Drawing.Point(259, 3);
            this.tlpMainTimer.Name = "tlpMainTimer";
            this.tlpMainTimer.RowCount = 3;
            this.tlpMainTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMainTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpMainTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMainTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMainTimer.Size = new System.Drawing.Size(258, 157);
            this.tlpMainTimer.TabIndex = 0;
            // 
            // picMainTimer
            // 
            this.picMainTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMainTimer.Location = new System.Drawing.Point(28, 18);
            this.picMainTimer.Name = "picMainTimer";
            this.picMainTimer.Size = new System.Drawing.Size(200, 119);
            this.picMainTimer.TabIndex = 7;
            this.picMainTimer.TabStop = false;
            this.picMainTimer.Click += new System.EventHandler(this.picMainTimer_Click);
            // 
            // tlpOsaekomiTimer
            // 
            this.tlpOsaekomiTimer.ColumnCount = 3;
            this.tlpOsaekomiTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125F));
            this.tlpOsaekomiTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.75F));
            this.tlpOsaekomiTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125F));
            this.tlpOsaekomiTimer.Controls.Add(this.picOsaekomiTimer, 1, 2);
            this.tlpOsaekomiTimer.Controls.Add(this.picOsaekomiText, 1, 3);
            this.tlpOsaekomiTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOsaekomiTimer.Location = new System.Drawing.Point(639, 3);
            this.tlpOsaekomiTimer.Name = "tlpOsaekomiTimer";
            this.tlpOsaekomiTimer.RowCount = 5;
            this.tlpOsaekomiTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpOsaekomiTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpOsaekomiTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOsaekomiTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpOsaekomiTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpOsaekomiTimer.Size = new System.Drawing.Size(136, 157);
            this.tlpOsaekomiTimer.TabIndex = 8;
            // 
            // picOsaekomiTimer
            // 
            this.picOsaekomiTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOsaekomiTimer.Location = new System.Drawing.Point(7, 41);
            this.picOsaekomiTimer.Name = "picOsaekomiTimer";
            this.picOsaekomiTimer.Size = new System.Drawing.Size(121, 72);
            this.picOsaekomiTimer.TabIndex = 8;
            this.picOsaekomiTimer.TabStop = false;
            // 
            // picOsaekomiText
            // 
            this.picOsaekomiText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOsaekomiText.Location = new System.Drawing.Point(7, 119);
            this.picOsaekomiText.Name = "picOsaekomiText";
            this.picOsaekomiText.Size = new System.Drawing.Size(121, 17);
            this.picOsaekomiText.TabIndex = 9;
            this.picOsaekomiText.TabStop = false;
            // 
            // transparentTableLayoutPanel1
            // 
            this.transparentTableLayoutPanel1.ColumnCount = 3;
            this.transparentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.transparentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.transparentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.transparentTableLayoutPanel1.Controls.Add(this.picGoldenScore, 1, 1);
            this.transparentTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentTableLayoutPanel1.Location = new System.Drawing.Point(523, 3);
            this.transparentTableLayoutPanel1.Name = "transparentTableLayoutPanel1";
            this.transparentTableLayoutPanel1.RowCount = 3;
            this.transparentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.transparentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.transparentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.transparentTableLayoutPanel1.Size = new System.Drawing.Size(110, 157);
            this.transparentTableLayoutPanel1.TabIndex = 9;
            // 
            // picGoldenScore
            // 
            this.picGoldenScore.BackColor = System.Drawing.Color.Gold;
            this.picGoldenScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGoldenScore.Location = new System.Drawing.Point(5, 34);
            this.picGoldenScore.Name = "picGoldenScore";
            this.picGoldenScore.Size = new System.Drawing.Size(99, 88);
            this.picGoldenScore.TabIndex = 9;
            this.picGoldenScore.TabStop = false;
            // 
            // pnlPlayer2
            // 
            this.pnlPlayer2.Controls.Add(this.tlpPlayer2);
            this.pnlPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayer2.Location = new System.Drawing.Point(3, 199);
            this.pnlPlayer2.Name = "pnlPlayer2";
            this.pnlPlayer2.Size = new System.Drawing.Size(778, 190);
            this.pnlPlayer2.TabIndex = 1;
            // 
            // tlpPlayer2
            // 
            this.tlpPlayer2.ColumnCount = 1;
            this.tlpPlayer2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayer2.Controls.Add(this.tlpPlayer2Row2, 0, 1);
            this.tlpPlayer2.Controls.Add(this.tlpPlayer2Top, 0, 0);
            this.tlpPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayer2.Location = new System.Drawing.Point(0, 0);
            this.tlpPlayer2.Name = "tlpPlayer2";
            this.tlpPlayer2.RowCount = 2;
            this.tlpPlayer2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayer2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayer2.Size = new System.Drawing.Size(778, 190);
            this.tlpPlayer2.TabIndex = 0;
            // 
            // tlpPlayer2Row2
            // 
            this.tlpPlayer2Row2.ColumnCount = 6;
            this.tlpPlayer2Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpPlayer2Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tlpPlayer2Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPlayer2Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpPlayer2Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpPlayer2Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpPlayer2Row2.Controls.Add(this.picPlayer2ClubName, 1, 1);
            this.tlpPlayer2Row2.Controls.Add(this.picPlayer2Score, 2, 1);
            this.tlpPlayer2Row2.Controls.Add(this.picPlayer2WazaAri, 3, 1);
            this.tlpPlayer2Row2.Controls.Add(this.picPlayer2Shido, 4, 1);
            this.tlpPlayer2Row2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayer2Row2.Location = new System.Drawing.Point(3, 98);
            this.tlpPlayer2Row2.Name = "tlpPlayer2Row2";
            this.tlpPlayer2Row2.RowCount = 3;
            this.tlpPlayer2Row2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpPlayer2Row2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpPlayer2Row2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpPlayer2Row2.Size = new System.Drawing.Size(772, 89);
            this.tlpPlayer2Row2.TabIndex = 3;
            // 
            // picPlayer2ClubName
            // 
            this.picPlayer2ClubName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer2ClubName.Location = new System.Drawing.Point(18, 7);
            this.picPlayer2ClubName.Name = "picPlayer2ClubName";
            this.picPlayer2ClubName.Size = new System.Drawing.Size(349, 74);
            this.picPlayer2ClubName.TabIndex = 0;
            this.picPlayer2ClubName.TabStop = false;
            // 
            // picPlayer2Score
            // 
            this.picPlayer2Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer2Score.Location = new System.Drawing.Point(373, 7);
            this.picPlayer2Score.Name = "picPlayer2Score";
            this.picPlayer2Score.Size = new System.Drawing.Size(225, 74);
            this.picPlayer2Score.TabIndex = 1;
            this.picPlayer2Score.TabStop = false;
            this.picPlayer2Score.Click += new System.EventHandler(this.picPlayer2Score_Click);
            // 
            // picPlayer2WazaAri
            // 
            this.picPlayer2WazaAri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer2WazaAri.Location = new System.Drawing.Point(604, 7);
            this.picPlayer2WazaAri.Name = "picPlayer2WazaAri";
            this.picPlayer2WazaAri.Size = new System.Drawing.Size(71, 74);
            this.picPlayer2WazaAri.TabIndex = 2;
            this.picPlayer2WazaAri.TabStop = false;
            this.picPlayer2WazaAri.Click += new System.EventHandler(this.picPlayer2WazaAri_Click);
            // 
            // picPlayer2Shido
            // 
            this.picPlayer2Shido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer2Shido.Location = new System.Drawing.Point(681, 7);
            this.picPlayer2Shido.Name = "picPlayer2Shido";
            this.picPlayer2Shido.Size = new System.Drawing.Size(71, 74);
            this.picPlayer2Shido.TabIndex = 3;
            this.picPlayer2Shido.TabStop = false;
            this.picPlayer2Shido.Click += new System.EventHandler(this.picPlayer2Shido_Click);
            // 
            // tlpPlayer2Top
            // 
            this.tlpPlayer2Top.ColumnCount = 2;
            this.tlpPlayer2Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpPlayer2Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpPlayer2Top.Controls.Add(this.picPlayer2Logo, 0, 0);
            this.tlpPlayer2Top.Controls.Add(this.picPlayer2Surname, 1, 0);
            this.tlpPlayer2Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayer2Top.Location = new System.Drawing.Point(3, 3);
            this.tlpPlayer2Top.Name = "tlpPlayer2Top";
            this.tlpPlayer2Top.RowCount = 1;
            this.tlpPlayer2Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayer2Top.Size = new System.Drawing.Size(772, 89);
            this.tlpPlayer2Top.TabIndex = 2;
            // 
            // picPlayer2Logo
            // 
            this.picPlayer2Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer2Logo.Location = new System.Drawing.Point(3, 3);
            this.picPlayer2Logo.Name = "picPlayer2Logo";
            this.picPlayer2Logo.Size = new System.Drawing.Size(71, 83);
            this.picPlayer2Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayer2Logo.TabIndex = 1;
            this.picPlayer2Logo.TabStop = false;
            // 
            // picPlayer2Surname
            // 
            this.picPlayer2Surname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer2Surname.Location = new System.Drawing.Point(80, 3);
            this.picPlayer2Surname.Name = "picPlayer2Surname";
            this.picPlayer2Surname.Size = new System.Drawing.Size(689, 83);
            this.picPlayer2Surname.TabIndex = 2;
            this.picPlayer2Surname.TabStop = false;
            // 
            // pnlPlayer1
            // 
            this.pnlPlayer1.Controls.Add(this.tlpPlayer1);
            this.pnlPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayer1.Location = new System.Drawing.Point(3, 3);
            this.pnlPlayer1.Name = "pnlPlayer1";
            this.pnlPlayer1.Size = new System.Drawing.Size(778, 190);
            this.pnlPlayer1.TabIndex = 2;
            // 
            // tlpPlayer1
            // 
            this.tlpPlayer1.ColumnCount = 1;
            this.tlpPlayer1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayer1.Controls.Add(this.tlpPlayer1Row2, 0, 1);
            this.tlpPlayer1.Controls.Add(this.tlpPlayer1Top, 0, 0);
            this.tlpPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayer1.Location = new System.Drawing.Point(0, 0);
            this.tlpPlayer1.Name = "tlpPlayer1";
            this.tlpPlayer1.RowCount = 2;
            this.tlpPlayer1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayer1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayer1.Size = new System.Drawing.Size(778, 190);
            this.tlpPlayer1.TabIndex = 0;
            // 
            // tlpPlayer1Row2
            // 
            this.tlpPlayer1Row2.ColumnCount = 6;
            this.tlpPlayer1Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpPlayer1Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tlpPlayer1Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPlayer1Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpPlayer1Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpPlayer1Row2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpPlayer1Row2.Controls.Add(this.picPlayer1ClubName, 1, 1);
            this.tlpPlayer1Row2.Controls.Add(this.picPlayer1Score, 2, 1);
            this.tlpPlayer1Row2.Controls.Add(this.picPlayer1WazaAri, 3, 1);
            this.tlpPlayer1Row2.Controls.Add(this.picPlayer1Shido, 4, 1);
            this.tlpPlayer1Row2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayer1Row2.Location = new System.Drawing.Point(3, 98);
            this.tlpPlayer1Row2.Name = "tlpPlayer1Row2";
            this.tlpPlayer1Row2.RowCount = 3;
            this.tlpPlayer1Row2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpPlayer1Row2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpPlayer1Row2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpPlayer1Row2.Size = new System.Drawing.Size(772, 89);
            this.tlpPlayer1Row2.TabIndex = 4;
            // 
            // picPlayer1ClubName
            // 
            this.picPlayer1ClubName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer1ClubName.Location = new System.Drawing.Point(18, 7);
            this.picPlayer1ClubName.Name = "picPlayer1ClubName";
            this.picPlayer1ClubName.Size = new System.Drawing.Size(349, 74);
            this.picPlayer1ClubName.TabIndex = 0;
            this.picPlayer1ClubName.TabStop = false;
            // 
            // picPlayer1Score
            // 
            this.picPlayer1Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer1Score.Location = new System.Drawing.Point(373, 7);
            this.picPlayer1Score.Name = "picPlayer1Score";
            this.picPlayer1Score.Size = new System.Drawing.Size(225, 74);
            this.picPlayer1Score.TabIndex = 1;
            this.picPlayer1Score.TabStop = false;
            this.picPlayer1Score.Click += new System.EventHandler(this.picPlayer1Score_Click);
            // 
            // picPlayer1WazaAri
            // 
            this.picPlayer1WazaAri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer1WazaAri.Location = new System.Drawing.Point(604, 7);
            this.picPlayer1WazaAri.Name = "picPlayer1WazaAri";
            this.picPlayer1WazaAri.Size = new System.Drawing.Size(71, 74);
            this.picPlayer1WazaAri.TabIndex = 2;
            this.picPlayer1WazaAri.TabStop = false;
            this.picPlayer1WazaAri.Click += new System.EventHandler(this.picPlayer1WazaAri_Click);
            // 
            // picPlayer1Shido
            // 
            this.picPlayer1Shido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer1Shido.Location = new System.Drawing.Point(681, 7);
            this.picPlayer1Shido.Name = "picPlayer1Shido";
            this.picPlayer1Shido.Size = new System.Drawing.Size(71, 74);
            this.picPlayer1Shido.TabIndex = 3;
            this.picPlayer1Shido.TabStop = false;
            this.picPlayer1Shido.Click += new System.EventHandler(this.picPlayer1Shido_Click);
            // 
            // tlpPlayer1Top
            // 
            this.tlpPlayer1Top.ColumnCount = 2;
            this.tlpPlayer1Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpPlayer1Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpPlayer1Top.Controls.Add(this.picPlayer1Logo, 0, 0);
            this.tlpPlayer1Top.Controls.Add(this.picPlayer1Surname, 1, 0);
            this.tlpPlayer1Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayer1Top.Location = new System.Drawing.Point(3, 3);
            this.tlpPlayer1Top.Name = "tlpPlayer1Top";
            this.tlpPlayer1Top.RowCount = 1;
            this.tlpPlayer1Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayer1Top.Size = new System.Drawing.Size(772, 89);
            this.tlpPlayer1Top.TabIndex = 0;
            // 
            // picPlayer1Logo
            // 
            this.picPlayer1Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPlayer1Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer1Logo.Location = new System.Drawing.Point(3, 3);
            this.picPlayer1Logo.Name = "picPlayer1Logo";
            this.picPlayer1Logo.Size = new System.Drawing.Size(71, 83);
            this.picPlayer1Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayer1Logo.TabIndex = 0;
            this.picPlayer1Logo.TabStop = false;
            // 
            // picPlayer1Surname
            // 
            this.picPlayer1Surname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPlayer1Surname.Location = new System.Drawing.Point(80, 3);
            this.picPlayer1Surname.Name = "picPlayer1Surname";
            this.picPlayer1Surname.Size = new System.Drawing.Size(689, 83);
            this.picPlayer1Surname.TabIndex = 1;
            this.picPlayer1Surname.TabStop = false;
            // 
            // tmrPlayer1Score
            // 
            this.tmrPlayer1Score.Interval = 2000;
            this.tmrPlayer1Score.Tick += new System.EventHandler(this.tmrPlayer1Score_Tick);
            // 
            // tmrPlayer2Score
            // 
            this.tmrPlayer2Score.Interval = 2000;
            this.tmrPlayer2Score.Tick += new System.EventHandler(this.tmrPlayer2Score_Tick);
            // 
            // btnResetTimer
            // 
            this.btnResetTimer.BackgroundImage = global::Judo_Scoreboard.Properties.Resources.connection_error;
            this.btnResetTimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetTimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetTimer.Location = new System.Drawing.Point(3, 143);
            this.btnResetTimer.Name = "btnResetTimer";
            this.btnResetTimer.Size = new System.Drawing.Size(19, 11);
            this.btnResetTimer.TabIndex = 8;
            this.btnResetTimer.UseVisualStyleBackColor = true;
            this.btnResetTimer.Click += new System.EventHandler(this.btnResetTimer_Click);
            // 
            // frmScoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tlp3Rows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmScoreboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Scoreboard";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmScoreboard_Load);
            this.Shown += new System.EventHandler(this.frmScoreboard_Shown);
            this.Resize += new System.EventHandler(this.frmScoreboard_Resize);
            this.tlp3Rows.ResumeLayout(false);
            this.tlpThirdRow.ResumeLayout(false);
            this.tlp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSpecialNeeds)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategoryName)).EndInit();
            this.tlpMainTimer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMainTimer)).EndInit();
            this.tlpOsaekomiTimer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOsaekomiTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOsaekomiText)).EndInit();
            this.transparentTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGoldenScore)).EndInit();
            this.pnlPlayer2.ResumeLayout(false);
            this.tlpPlayer2.ResumeLayout(false);
            this.tlpPlayer2Row2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2ClubName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2WazaAri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Shido)).EndInit();
            this.tlpPlayer2Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2Surname)).EndInit();
            this.pnlPlayer1.ResumeLayout(false);
            this.tlpPlayer1.ResumeLayout(false);
            this.tlpPlayer1Row2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1ClubName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1WazaAri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Shido)).EndInit();
            this.tlpPlayer1Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1Surname)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Timer tmrSecondary;
        private System.Windows.Forms.TableLayoutPanel tlp3Rows;
        private System.Windows.Forms.TableLayoutPanel tlpThirdRow;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Panel pnlPlayer1;
        private System.Windows.Forms.PictureBox picCategoryWeight;
        private System.Windows.Forms.PictureBox picCategoryName;
        private System.Windows.Forms.PictureBox picSpecialNeeds;
        private System.Windows.Forms.PictureBox picCategoryDescription;
        private System.Windows.Forms.PictureBox picMainTimer;
        private System.Windows.Forms.PictureBox picOsaekomiTimer;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.TableLayoutPanel tlpOsaekomiTimer;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.TableLayoutPanel tlpMainTimer;
        private TransparentTableLayoutPanel tlpPlayer2;
        private TransparentTableLayoutPanel tlpPlayer2Top;
        private TransparentTableLayoutPanel tlpPlayer1;
        private TransparentTableLayoutPanel tlpPlayer1Top;
        private System.Windows.Forms.PictureBox picPlayer2Logo;
        private System.Windows.Forms.PictureBox picPlayer1Logo;
        private System.Windows.Forms.PictureBox picPlayer2Surname;
        private System.Windows.Forms.PictureBox picPlayer1Surname;
        private TransparentTableLayoutPanel tlpPlayer2Row2;
        private System.Windows.Forms.PictureBox picPlayer2ClubName;
        private System.Windows.Forms.PictureBox picPlayer2Score;
        private System.Windows.Forms.PictureBox picPlayer2WazaAri;
        private System.Windows.Forms.PictureBox picPlayer2Shido;
        private TransparentTableLayoutPanel tlpPlayer1Row2;
        private System.Windows.Forms.PictureBox picPlayer1ClubName;
        private System.Windows.Forms.PictureBox picPlayer1Score;
        private System.Windows.Forms.PictureBox picPlayer1WazaAri;
        private System.Windows.Forms.PictureBox picPlayer1Shido;
        private System.Windows.Forms.PictureBox picGoldenScore;
        private TransparentTableLayoutPanel transparentTableLayoutPanel1;
        private System.Windows.Forms.Timer tmrPlayer1Score;
        private System.Windows.Forms.PictureBox picOsaekomiText;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Timer tmrPlayer2Score;
        private System.Windows.Forms.Button btnResetTimer;
    }
}

