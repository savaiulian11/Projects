namespace Analizatori.Pagini
{
    partial class UserControl2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.cursuriGroupBox = new System.Windows.Forms.GroupBox();
            this.backButton = new System.Windows.Forms.Button();
            this.patologiileButton = new System.Windows.Forms.Button();
            this.acusticoVestivularButton = new System.Windows.Forms.Button();
            this.vizualButton = new System.Windows.Forms.Button();
            this.cutanatButton = new System.Windows.Forms.Button();
            this.introducereButton = new System.Windows.Forms.Button();
            this.cursuriPDFViewer = new AxAcroPDFLib.AxAcroPDF();
            this.cursuriGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursuriPDFViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // cursuriGroupBox
            // 
            this.cursuriGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cursuriGroupBox.Controls.Add(this.backButton);
            this.cursuriGroupBox.Controls.Add(this.patologiileButton);
            this.cursuriGroupBox.Controls.Add(this.acusticoVestivularButton);
            this.cursuriGroupBox.Controls.Add(this.vizualButton);
            this.cursuriGroupBox.Controls.Add(this.cutanatButton);
            this.cursuriGroupBox.Controls.Add(this.introducereButton);
            this.cursuriGroupBox.Location = new System.Drawing.Point(0, 0);
            this.cursuriGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cursuriGroupBox.Name = "cursuriGroupBox";
            this.cursuriGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cursuriGroupBox.Size = new System.Drawing.Size(187, 558);
            this.cursuriGroupBox.TabIndex = 0;
            this.cursuriGroupBox.TabStop = false;
            this.cursuriGroupBox.Text = "Cursuri";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(8, 462);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(171, 66);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "Înapoi";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // patologiileButton
            // 
            this.patologiileButton.Location = new System.Drawing.Point(8, 382);
            this.patologiileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.patologiileButton.Name = "patologiileButton";
            this.patologiileButton.Size = new System.Drawing.Size(171, 66);
            this.patologiileButton.TabIndex = 9;
            this.patologiileButton.Text = "Patologiile";
            this.patologiileButton.UseVisualStyleBackColor = true;
            this.patologiileButton.Click += new System.EventHandler(this.patologiileButton_Click);
            // 
            // acusticoVestivularButton
            // 
            this.acusticoVestivularButton.Location = new System.Drawing.Point(8, 302);
            this.acusticoVestivularButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.acusticoVestivularButton.Name = "acusticoVestivularButton";
            this.acusticoVestivularButton.Size = new System.Drawing.Size(171, 66);
            this.acusticoVestivularButton.TabIndex = 8;
            this.acusticoVestivularButton.Text = "Analizatorul acustico-vestivular";
            this.acusticoVestivularButton.UseVisualStyleBackColor = true;
            this.acusticoVestivularButton.Click += new System.EventHandler(this.acusticoVestivularButton_Click);
            // 
            // vizualButton
            // 
            this.vizualButton.Location = new System.Drawing.Point(8, 222);
            this.vizualButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vizualButton.Name = "vizualButton";
            this.vizualButton.Size = new System.Drawing.Size(171, 66);
            this.vizualButton.TabIndex = 7;
            this.vizualButton.Text = "Analizatorul vizual";
            this.vizualButton.UseVisualStyleBackColor = true;
            this.vizualButton.Click += new System.EventHandler(this.vizualButton_Click);
            // 
            // cutanatButton
            // 
            this.cutanatButton.Location = new System.Drawing.Point(8, 142);
            this.cutanatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cutanatButton.Name = "cutanatButton";
            this.cutanatButton.Size = new System.Drawing.Size(171, 66);
            this.cutanatButton.TabIndex = 6;
            this.cutanatButton.Text = "Analizatorul cutanat";
            this.cutanatButton.UseVisualStyleBackColor = true;
            this.cutanatButton.Click += new System.EventHandler(this.cutanatButton_Click);
            // 
            // introducereButton
            // 
            this.introducereButton.Location = new System.Drawing.Point(8, 62);
            this.introducereButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.introducereButton.Name = "introducereButton";
            this.introducereButton.Size = new System.Drawing.Size(171, 66);
            this.introducereButton.TabIndex = 5;
            this.introducereButton.Text = "Introducere";
            this.introducereButton.UseVisualStyleBackColor = true;
            this.introducereButton.Click += new System.EventHandler(this.introducereButton_Click);
            // 
            // cursuriPDFViewer
            // 
            this.cursuriPDFViewer.Enabled = true;
            this.cursuriPDFViewer.Location = new System.Drawing.Point(140, 0);
            this.cursuriPDFViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cursuriPDFViewer.Name = "cursuriPDFViewer";
            this.cursuriPDFViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cursuriPDFViewer.OcxState")));
            this.cursuriPDFViewer.Size = new System.Drawing.Size(663, 453);
            this.cursuriPDFViewer.TabIndex = 1;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Analizatori.Properties.Resources.img5;
            this.Controls.Add(this.cursuriPDFViewer);
            this.Controls.Add(this.cursuriGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1071, 558);
           
            this.cursuriGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cursuriPDFViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cursuriGroupBox;
        private System.Windows.Forms.Button patologiileButton;
        private System.Windows.Forms.Button acusticoVestivularButton;
        private System.Windows.Forms.Button vizualButton;
        private System.Windows.Forms.Button cutanatButton;
        private System.Windows.Forms.Button introducereButton;
        private System.Windows.Forms.Button backButton;
        private AxAcroPDFLib.AxAcroPDF cursuriPDFViewer;
    }
}
