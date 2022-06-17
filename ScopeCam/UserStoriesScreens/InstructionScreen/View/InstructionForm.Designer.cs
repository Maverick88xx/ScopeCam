namespace ScopeCam
{
    partial class InstructionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionForm));
            this.appIconPictureBox = new System.Windows.Forms.PictureBox();
            this.InstructionTitleLabel = new System.Windows.Forms.Label();
            this.instructionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.minimizeWindowButton = new System.Windows.Forms.Button();
            this.closeWindowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appIconPictureBox)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // appIconPictureBox
            // 
            this.appIconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.appIconPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("appIconPictureBox.BackgroundImage")));
            this.appIconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.appIconPictureBox.InitialImage = null;
            this.appIconPictureBox.Location = new System.Drawing.Point(35, 0);
            this.appIconPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.appIconPictureBox.Name = "appIconPictureBox";
            this.appIconPictureBox.Size = new System.Drawing.Size(67, 62);
            this.appIconPictureBox.TabIndex = 22;
            this.appIconPictureBox.TabStop = false;
            // 
            // InstructionTitleLabel
            // 
            this.InstructionTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.InstructionTitleLabel.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InstructionTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.InstructionTitleLabel.Location = new System.Drawing.Point(123, 11);
            this.InstructionTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InstructionTitleLabel.Name = "InstructionTitleLabel";
            this.InstructionTitleLabel.Size = new System.Drawing.Size(467, 39);
            this.InstructionTitleLabel.TabIndex = 22;
            this.InstructionTitleLabel.Text = "ScopeCam - Інструкція";
            // 
            // instructionRichTextBox
            // 
            this.instructionRichTextBox.BackColor = System.Drawing.Color.Black;
            this.instructionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructionRichTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.instructionRichTextBox.ForeColor = System.Drawing.Color.White;
            this.instructionRichTextBox.Location = new System.Drawing.Point(129, 69);
            this.instructionRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.instructionRichTextBox.Name = "instructionRichTextBox";
            this.instructionRichTextBox.ReadOnly = true;
            this.instructionRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.instructionRichTextBox.Size = new System.Drawing.Size(1112, 629);
            this.instructionRichTextBox.TabIndex = 29;
            this.instructionRichTextBox.Text = resources.GetString("instructionRichTextBox.Text");
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.appIconPictureBox);
            this.topPanel.Controls.Add(this.InstructionTitleLabel);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1241, 47);
            this.topPanel.TabIndex = 28;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
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
            this.minimizeWindowButton.Location = new System.Drawing.Point(1249, 4);
            this.minimizeWindowButton.Margin = new System.Windows.Forms.Padding(4);
            this.minimizeWindowButton.Name = "minimizeWindowButton";
            this.minimizeWindowButton.Size = new System.Drawing.Size(47, 43);
            this.minimizeWindowButton.TabIndex = 27;
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
            this.closeWindowButton.Location = new System.Drawing.Point(1304, 5);
            this.closeWindowButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeWindowButton.Name = "closeWindowButton";
            this.closeWindowButton.Size = new System.Drawing.Size(47, 43);
            this.closeWindowButton.TabIndex = 26;
            this.closeWindowButton.Text = "X";
            this.closeWindowButton.UseVisualStyleBackColor = false;
            this.closeWindowButton.Click += new System.EventHandler(this.CloseWindowButton_Click);
            this.closeWindowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseWindowButton_MouseDown);
            this.closeWindowButton.MouseLeave += new System.EventHandler(this.CloseWindowButton_MouseLeave);
            this.closeWindowButton.MouseHover += new System.EventHandler(this.CloseWindowButton_MouseHover);
            // 
            // InstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 713);
            this.Controls.Add(this.instructionRichTextBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.minimizeWindowButton);
            this.Controls.Add(this.closeWindowButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstructionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Інструкція користувача";
            ((System.ComponentModel.ISupportInitialize)(this.appIconPictureBox)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox appIconPictureBox;
        private System.Windows.Forms.Label InstructionTitleLabel;
        private System.Windows.Forms.RichTextBox instructionRichTextBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button minimizeWindowButton;
        private System.Windows.Forms.Button closeWindowButton;
    }
}