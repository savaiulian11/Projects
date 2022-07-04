namespace Analizatori.Pagini
{
    partial class UserControl4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl4));
            this.videoGroupBox = new System.Windows.Forms.GroupBox();
            this.backButton = new System.Windows.Forms.Button();
            this.acusticoVestivularButton = new System.Windows.Forms.Button();
            this.vizualButton = new System.Windows.Forms.Button();
            this.cutanatButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.videoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // videoGroupBox
            // 
            this.videoGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.videoGroupBox.Controls.Add(this.backButton);
            this.videoGroupBox.Controls.Add(this.acusticoVestivularButton);
            this.videoGroupBox.Controls.Add(this.vizualButton);
            this.videoGroupBox.Controls.Add(this.cutanatButton);
            this.videoGroupBox.Location = new System.Drawing.Point(0, 0);
            this.videoGroupBox.Name = "videoGroupBox";
            this.videoGroupBox.Size = new System.Drawing.Size(140, 453);
            this.videoGroupBox.TabIndex = 0;
            this.videoGroupBox.TabStop = false;
            this.videoGroupBox.Text = "Videoclipuri";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(6, 340);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(128, 54);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "Înapoi";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // acusticoVestivularButton
            // 
            this.acusticoVestivularButton.Location = new System.Drawing.Point(6, 250);
            this.acusticoVestivularButton.Name = "acusticoVestivularButton";
            this.acusticoVestivularButton.Size = new System.Drawing.Size(128, 54);
            this.acusticoVestivularButton.TabIndex = 14;
            this.acusticoVestivularButton.Text = "Analizatorul acustico-vestivular";
            this.acusticoVestivularButton.UseVisualStyleBackColor = true;
            this.acusticoVestivularButton.Click += new System.EventHandler(this.acusticoVestivularButton_Click);
            // 
            // vizualButton
            // 
            this.vizualButton.Location = new System.Drawing.Point(6, 160);
            this.vizualButton.Name = "vizualButton";
            this.vizualButton.Size = new System.Drawing.Size(128, 54);
            this.vizualButton.TabIndex = 13;
            this.vizualButton.Text = "Analizatorul vizual";
            this.vizualButton.UseVisualStyleBackColor = true;
            this.vizualButton.Click += new System.EventHandler(this.vizualButton_Click);
            // 
            // cutanatButton
            // 
            this.cutanatButton.Location = new System.Drawing.Point(6, 70);
            this.cutanatButton.Name = "cutanatButton";
            this.cutanatButton.Size = new System.Drawing.Size(128, 54);
            this.cutanatButton.TabIndex = 12;
            this.cutanatButton.Text = "Analizatorul cutanat";
            this.cutanatButton.UseVisualStyleBackColor = true;
            this.cutanatButton.Click += new System.EventHandler(this.cutanatButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(302, 400);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(104, 37);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(412, 400);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(104, 37);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(522, 400);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(104, 37);
            this.pauseButton.TabIndex = 6;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(170, 25);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(601, 356);
            this.mediaPlayer.TabIndex = 7;
            // 
            // UserControl4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Analizatori.Properties.Resources.img1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.videoGroupBox);
            this.Name = "UserControl4";
            this.Size = new System.Drawing.Size(803, 453);
            this.videoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox videoGroupBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button acusticoVestivularButton;
        private System.Windows.Forms.Button vizualButton;
        private System.Windows.Forms.Button cutanatButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
    }
}
