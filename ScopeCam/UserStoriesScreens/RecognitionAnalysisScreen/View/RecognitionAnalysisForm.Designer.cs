namespace ScopeCam
{
    partial class RecognitionAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecognitionAnalysisForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.appIconPictureBox = new System.Windows.Forms.PictureBox();
            this.recognitionAnalysisTitleLabel = new System.Windows.Forms.Label();
            this.minimizeWindowButton = new System.Windows.Forms.Button();
            this.closeWindowButton = new System.Windows.Forms.Button();
            this.previousSlideButton = new System.Windows.Forms.Button();
            this.nextSlideButton = new System.Windows.Forms.Button();
            this.sliderImagePictureBox = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.appIconPictureBox);
            this.topPanel.Controls.Add(this.recognitionAnalysisTitleLabel);
            this.topPanel.Location = new System.Drawing.Point(1, 1);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1241, 47);
            this.topPanel.TabIndex = 24;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // appIconPictureBox
            // 
            this.appIconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.appIconPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("appIconPictureBox.BackgroundImage")));
            this.appIconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.appIconPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("appIconPictureBox.Image")));
            this.appIconPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("appIconPictureBox.InitialImage")));
            this.appIconPictureBox.Location = new System.Drawing.Point(39, 0);
            this.appIconPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.appIconPictureBox.Name = "appIconPictureBox";
            this.appIconPictureBox.Size = new System.Drawing.Size(67, 62);
            this.appIconPictureBox.TabIndex = 23;
            this.appIconPictureBox.TabStop = false;
            // 
            // recognitionAnalysisTitleLabel
            // 
            this.recognitionAnalysisTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.recognitionAnalysisTitleLabel.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recognitionAnalysisTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.recognitionAnalysisTitleLabel.Location = new System.Drawing.Point(127, 11);
            this.recognitionAnalysisTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recognitionAnalysisTitleLabel.Name = "recognitionAnalysisTitleLabel";
            this.recognitionAnalysisTitleLabel.Size = new System.Drawing.Size(748, 39);
            this.recognitionAnalysisTitleLabel.TabIndex = 24;
            this.recognitionAnalysisTitleLabel.Text = "ScopeCam - Аналіз розпізнавання";
            // 
            // minimizeWindowButton
            // 
            this.minimizeWindowButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeWindowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minimizeWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.minimizeWindowButton.FlatAppearance.BorderSize = 0;
            this.minimizeWindowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.minimizeWindowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.minimizeWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeWindowButton.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minimizeWindowButton.ForeColor = System.Drawing.Color.White;
            this.minimizeWindowButton.Location = new System.Drawing.Point(1251, 5);
            this.minimizeWindowButton.Margin = new System.Windows.Forms.Padding(4);
            this.minimizeWindowButton.Name = "minimizeWindowButton";
            this.minimizeWindowButton.Size = new System.Drawing.Size(47, 43);
            this.minimizeWindowButton.TabIndex = 23;
            this.minimizeWindowButton.Text = "___";
            this.minimizeWindowButton.UseVisualStyleBackColor = false;
            this.minimizeWindowButton.Click += new System.EventHandler(this.MinimizeWindowButton_Click);
            this.minimizeWindowButton.MouseLeave += new System.EventHandler(this.MinimizeWindowButton_MouseLeave);
            this.minimizeWindowButton.MouseHover += new System.EventHandler(this.MinimizeWindowButton_MouseHover);
            // 
            // closeWindowButton
            // 
            this.closeWindowButton.BackColor = System.Drawing.Color.Transparent;
            this.closeWindowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closeWindowButton.FlatAppearance.BorderSize = 0;
            this.closeWindowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.closeWindowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.closeWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeWindowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeWindowButton.ForeColor = System.Drawing.Color.White;
            this.closeWindowButton.Location = new System.Drawing.Point(1305, 6);
            this.closeWindowButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeWindowButton.Name = "closeWindowButton";
            this.closeWindowButton.Size = new System.Drawing.Size(47, 43);
            this.closeWindowButton.TabIndex = 22;
            this.closeWindowButton.Text = "X";
            this.closeWindowButton.UseVisualStyleBackColor = false;
            this.closeWindowButton.Click += new System.EventHandler(this.CloseWindowButton_Click);
            this.closeWindowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseWindowButton_MouseDown);
            this.closeWindowButton.MouseLeave += new System.EventHandler(this.CloseWindowButton_MouseLeave);
            this.closeWindowButton.MouseHover += new System.EventHandler(this.CloseWindowButton_MouseHover);
            // 
            // previousSlideButton
            // 
            this.previousSlideButton.BackColor = System.Drawing.Color.Transparent;
            this.previousSlideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.previousSlideButton.Enabled = false;
            this.previousSlideButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.previousSlideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.previousSlideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.previousSlideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousSlideButton.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.previousSlideButton.ForeColor = System.Drawing.Color.White;
            this.previousSlideButton.Location = new System.Drawing.Point(435, 645);
            this.previousSlideButton.Margin = new System.Windows.Forms.Padding(4);
            this.previousSlideButton.Name = "previousSlideButton";
            this.previousSlideButton.Size = new System.Drawing.Size(169, 53);
            this.previousSlideButton.TabIndex = 21;
            this.previousSlideButton.Text = "←";
            this.previousSlideButton.UseVisualStyleBackColor = false;
            this.previousSlideButton.Click += new System.EventHandler(this.PreviousSlideButton_Click);
            // 
            // nextSlideButton
            // 
            this.nextSlideButton.BackColor = System.Drawing.Color.Transparent;
            this.nextSlideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.nextSlideButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.nextSlideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.nextSlideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.nextSlideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextSlideButton.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextSlideButton.ForeColor = System.Drawing.Color.White;
            this.nextSlideButton.Location = new System.Drawing.Point(784, 645);
            this.nextSlideButton.Margin = new System.Windows.Forms.Padding(4);
            this.nextSlideButton.Name = "nextSlideButton";
            this.nextSlideButton.Size = new System.Drawing.Size(169, 53);
            this.nextSlideButton.TabIndex = 20;
            this.nextSlideButton.Text = "→";
            this.nextSlideButton.UseVisualStyleBackColor = false;
            this.nextSlideButton.Click += new System.EventHandler(this.NextSlideButton_Click);
            // 
            // sliderImagePictureBox
            // 
            this.sliderImagePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.sliderImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sliderImagePictureBox.Location = new System.Drawing.Point(220, 54);
            this.sliderImagePictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.sliderImagePictureBox.Name = "sliderImagePictureBox";
            this.sliderImagePictureBox.Size = new System.Drawing.Size(941, 574);
            this.sliderImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sliderImagePictureBox.TabIndex = 19;
            this.sliderImagePictureBox.TabStop = false;
            // 
            // RecognitionAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 713);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.minimizeWindowButton);
            this.Controls.Add(this.closeWindowButton);
            this.Controls.Add(this.previousSlideButton);
            this.Controls.Add(this.nextSlideButton);
            this.Controls.Add(this.sliderImagePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecognitionAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подробиці розпізнавання";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecognitionAnalysisForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecognitionAnalysisForm_FormClosed);
            this.Load += new System.EventHandler(this.RecognitionAnalysisForm_Load);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox appIconPictureBox;
        private System.Windows.Forms.Label recognitionAnalysisTitleLabel;
        private System.Windows.Forms.Button minimizeWindowButton;
        private System.Windows.Forms.Button closeWindowButton;
        private System.Windows.Forms.Button previousSlideButton;
        private System.Windows.Forms.Button nextSlideButton;
        private System.Windows.Forms.PictureBox sliderImagePictureBox;
    }
}