namespace Pose
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            picVideo = new PictureBox();
            btnLoad = new Button();
            btnPlay = new Button();
            btnPause = new Button();
            btnForward5 = new Button();
            btnBack5 = new Button();
            btnPose = new Button();
            lblVideoInfo = new Label();
            btnPlayPause = new Button();
            btnBeginning = new Button();
            btnEnd = new Button();
            tmrFormRefresh = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picVideo).BeginInit();
            SuspendLayout();
            // 
            // picVideo
            // 
            picVideo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picVideo.Location = new Point(12, 12);
            picVideo.Name = "picVideo";
            picVideo.Size = new Size(938, 605);
            picVideo.SizeMode = PictureBoxSizeMode.Zoom;
            picVideo.TabIndex = 0;
            picVideo.TabStop = false;
            picVideo.MouseClick += picVideo_MouseClick;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(12, 641);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(112, 34);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(0, 0);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 0;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(0, 0);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 0;
            // 
            // btnForward5
            // 
            btnForward5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnForward5.Location = new Point(604, 641);
            btnForward5.Name = "btnForward5";
            btnForward5.Size = new Size(112, 34);
            btnForward5.TabIndex = 4;
            btnForward5.Text = "+ 5";
            btnForward5.UseVisualStyleBackColor = true;
            btnForward5.Click += btnForward5_Click;
            // 
            // btnBack5
            // 
            btnBack5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack5.Location = new Point(368, 641);
            btnBack5.Name = "btnBack5";
            btnBack5.Size = new Size(112, 34);
            btnBack5.TabIndex = 5;
            btnBack5.Text = "- 5";
            btnBack5.UseVisualStyleBackColor = true;
            btnBack5.Click += btnBack5_Click;
            // 
            // btnPose
            // 
            btnPose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPose.Location = new Point(840, 641);
            btnPose.Name = "btnPose";
            btnPose.Size = new Size(112, 34);
            btnPose.TabIndex = 6;
            btnPose.Text = "Pose";
            btnPose.UseVisualStyleBackColor = true;
            btnPose.Click += btnPose_Click;
            // 
            // lblVideoInfo
            // 
            lblVideoInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblVideoInfo.AutoSize = true;
            lblVideoInfo.Location = new Point(12, 679);
            lblVideoInfo.Name = "lblVideoInfo";
            lblVideoInfo.Size = new Size(114, 25);
            lblVideoInfo.TabIndex = 7;
            lblVideoInfo.Text = "Load a video";
            // 
            // btnPlayPause
            // 
            btnPlayPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPlayPause.Location = new Point(132, 641);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(112, 34);
            btnPlayPause.TabIndex = 8;
            btnPlayPause.Text = "Play";
            btnPlayPause.UseVisualStyleBackColor = true;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // btnBeginning
            // 
            btnBeginning.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBeginning.Location = new Point(250, 641);
            btnBeginning.Name = "btnBeginning";
            btnBeginning.Size = new Size(112, 34);
            btnBeginning.TabIndex = 10;
            btnBeginning.Text = "|<";
            btnBeginning.UseVisualStyleBackColor = true;
            btnBeginning.Click += btnBeginning_Click;
            // 
            // btnEnd
            // 
            btnEnd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEnd.Location = new Point(722, 641);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(112, 34);
            btnEnd.TabIndex = 11;
            btnEnd.Text = ">|";
            btnEnd.UseVisualStyleBackColor = true;
            btnEnd.Click += btnEnd_Click;
            // 
            // tmrFormRefresh
            // 
            tmrFormRefresh.Enabled = true;
            tmrFormRefresh.Interval = 500;
            tmrFormRefresh.Tick += tmrFormRefresh_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 713);
            Controls.Add(btnEnd);
            Controls.Add(btnBeginning);
            Controls.Add(btnPlayPause);
            Controls.Add(lblVideoInfo);
            Controls.Add(btnPose);
            Controls.Add(btnBack5);
            Controls.Add(btnForward5);
            Controls.Add(btnLoad);
            Controls.Add(picVideo);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picVideo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picVideo;
        private Button btnLoad;
        private Button btnPlay;
        private Button btnPause;
        private Button btnForward5;
        private Button btnBack5;
        private Button btnPose;
        private Label lblVideoInfo;
        private Button btnPlayPause;
        private Button btnBeginning;
        private Button btnEnd;
        private System.Windows.Forms.Timer tmrFormRefresh;
    }
}
