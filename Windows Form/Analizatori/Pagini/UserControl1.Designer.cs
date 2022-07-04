namespace Analizatori
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.menuGroupBox = new System.Windows.Forms.GroupBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.testeButton = new System.Windows.Forms.Button();
            this.videoButton = new System.Windows.Forms.Button();
            this.stiaiCaButton = new System.Windows.Forms.Button();
            this.cursuriButton = new System.Windows.Forms.Button();
            this.stiaiCaPDFViewer = new AxAcroPDFLib.AxAcroPDF();
            this.menuGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stiaiCaPDFViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuGroupBox
            // 
            this.menuGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuGroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuGroupBox.Controls.Add(this.exitButton);
            this.menuGroupBox.Controls.Add(this.testeButton);
            this.menuGroupBox.Controls.Add(this.videoButton);
            this.menuGroupBox.Controls.Add(this.stiaiCaButton);
            this.menuGroupBox.Controls.Add(this.cursuriButton);
            this.menuGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.menuGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.menuGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuGroupBox.Location = new System.Drawing.Point(0, 0);
            this.menuGroupBox.Name = "menuGroupBox";
            this.menuGroupBox.Size = new System.Drawing.Size(140, 453);
            this.menuGroupBox.TabIndex = 0;
            this.menuGroupBox.TabStop = false;
            this.menuGroupBox.Text = "Analizatori";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(6, 370);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(128, 54);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // testeButton
            // 
            this.testeButton.Location = new System.Drawing.Point(6, 290);
            this.testeButton.Name = "testeButton";
            this.testeButton.Size = new System.Drawing.Size(128, 54);
            this.testeButton.TabIndex = 3;
            this.testeButton.Text = "Teste";
            this.testeButton.UseVisualStyleBackColor = true;
            this.testeButton.Click += new System.EventHandler(this.testeButton_Click);
            // 
            // videoButton
            // 
            this.videoButton.Location = new System.Drawing.Point(6, 210);
            this.videoButton.Name = "videoButton";
            this.videoButton.Size = new System.Drawing.Size(128, 54);
            this.videoButton.TabIndex = 2;
            this.videoButton.Text = "Videoclipuri";
            this.videoButton.UseVisualStyleBackColor = true;
            this.videoButton.Click += new System.EventHandler(this.videoButton_Click);
            // 
            // stiaiCaButton
            // 
            this.stiaiCaButton.Location = new System.Drawing.Point(6, 130);
            this.stiaiCaButton.Name = "stiaiCaButton";
            this.stiaiCaButton.Size = new System.Drawing.Size(128, 54);
            this.stiaiCaButton.TabIndex = 1;
            this.stiaiCaButton.Text = "Știai că";
            this.stiaiCaButton.UseVisualStyleBackColor = true;
            this.stiaiCaButton.Click += new System.EventHandler(this.stiaiCaButton_Click);
            // 
            // cursuriButton
            // 
            this.cursuriButton.Location = new System.Drawing.Point(6, 50);
            this.cursuriButton.Name = "cursuriButton";
            this.cursuriButton.Size = new System.Drawing.Size(128, 54);
            this.cursuriButton.TabIndex = 0;
            this.cursuriButton.Text = "Cursuri";
            this.cursuriButton.UseVisualStyleBackColor = true;
            this.cursuriButton.Click += new System.EventHandler(this.cursuriButton_Click);
            // 
            // stiaiCaPDFViewer
            // 
            this.stiaiCaPDFViewer.Enabled = true;
            this.stiaiCaPDFViewer.Location = new System.Drawing.Point(140, 0);
            this.stiaiCaPDFViewer.Name = "stiaiCaPDFViewer";
            this.stiaiCaPDFViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("stiaiCaPDFViewer.OcxState")));
            this.stiaiCaPDFViewer.Size = new System.Drawing.Size(663, 453);
            this.stiaiCaPDFViewer.TabIndex = 2;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Analizatori.Properties.Resources.img4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.stiaiCaPDFViewer);
            this.Controls.Add(this.menuGroupBox);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(803, 453);
            this.menuGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stiaiCaPDFViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox menuGroupBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button testeButton;
        private System.Windows.Forms.Button videoButton;
        private System.Windows.Forms.Button stiaiCaButton;
        private System.Windows.Forms.Button cursuriButton;
        private AxAcroPDFLib.AxAcroPDF stiaiCaPDFViewer;
    }
}
