namespace ScopeCam
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.appTitleLabel = new System.Windows.Forms.Label();
            this.aboutProgramButton = new System.Windows.Forms.Button();
            this.instructionButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.appIconPictureBox = new System.Windows.Forms.PictureBox();
            this.minimizeWindowButton = new System.Windows.Forms.Button();
            this.closeWindowButton = new System.Windows.Forms.Button();
            this.stopVideoModeButton = new System.Windows.Forms.Button();
            this.recognitionInfoButton = new System.Windows.Forms.Button();
            this.chooseImageFileButton = new System.Windows.Forms.Button();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.LicensePlateNumberLabel = new System.Windows.Forms.Label();
            this.recognizedLPNumberTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.msTimer = new System.Windows.Forms.Timer(this.components);
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.videoModeButton = new System.Windows.Forms.Button();
            this.recognizedSceneImageBox = new Emgu.CV.UI.ImageBox();
            this.recognizedPlateImageBox = new Emgu.CV.UI.ImageBox();
            this.originalSceneImageBox = new Emgu.CV.UI.ImageBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recognizedSceneImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recognizedPlateImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalSceneImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // appTitleLabel
            // 
            this.appTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.appTitleLabel.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.appTitleLabel.Location = new System.Drawing.Point(88, 11);
            this.appTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appTitleLabel.Name = "appTitleLabel";
            this.appTitleLabel.Size = new System.Drawing.Size(193, 39);
            this.appTitleLabel.TabIndex = 24;
            this.appTitleLabel.Text = "ScopeCam";
            // 
            // aboutProgramButton
            // 
            this.aboutProgramButton.BackColor = System.Drawing.Color.Transparent;
            this.aboutProgramButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aboutProgramButton.BackgroundImage")));
            this.aboutProgramButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aboutProgramButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.aboutProgramButton.FlatAppearance.BorderSize = 0;
            this.aboutProgramButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.aboutProgramButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.aboutProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutProgramButton.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutProgramButton.ForeColor = System.Drawing.Color.White;
            this.aboutProgramButton.Location = new System.Drawing.Point(1134, 2);
            this.aboutProgramButton.Margin = new System.Windows.Forms.Padding(4);
            this.aboutProgramButton.Name = "aboutProgramButton";
            this.aboutProgramButton.Size = new System.Drawing.Size(51, 47);
            this.aboutProgramButton.TabIndex = 33;
            this.aboutProgramButton.UseVisualStyleBackColor = false;
            this.aboutProgramButton.Click += new System.EventHandler(this.AboutProgramButton_Click);
            // 
            // instructionButton
            // 
            this.instructionButton.BackColor = System.Drawing.Color.Transparent;
            this.instructionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.instructionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.instructionButton.FlatAppearance.BorderSize = 0;
            this.instructionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.instructionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.instructionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructionButton.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.instructionButton.ForeColor = System.Drawing.Color.White;
            this.instructionButton.Location = new System.Drawing.Point(1193, 1);
            this.instructionButton.Margin = new System.Windows.Forms.Padding(4);
            this.instructionButton.Name = "instructionButton";
            this.instructionButton.Size = new System.Drawing.Size(47, 47);
            this.instructionButton.TabIndex = 32;
            this.instructionButton.Text = "?";
            this.instructionButton.UseVisualStyleBackColor = false;
            this.instructionButton.Click += new System.EventHandler(this.InstructionButton_Click);
            this.instructionButton.MouseLeave += new System.EventHandler(this.InstructionButton_MouseLeave);
            this.instructionButton.MouseHover += new System.EventHandler(this.InstructionButton_MouseHover);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.appIconPictureBox);
            this.topPanel.Controls.Add(this.appTitleLabel);
            this.topPanel.Location = new System.Drawing.Point(33, 1);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1093, 47);
            this.topPanel.TabIndex = 30;
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
            this.appIconPictureBox.Location = new System.Drawing.Point(0, 0);
            this.appIconPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.appIconPictureBox.Name = "appIconPictureBox";
            this.appIconPictureBox.Size = new System.Drawing.Size(67, 62);
            this.appIconPictureBox.TabIndex = 23;
            this.appIconPictureBox.TabStop = false;
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
            this.minimizeWindowButton.Location = new System.Drawing.Point(1246, 5);
            this.minimizeWindowButton.Margin = new System.Windows.Forms.Padding(4);
            this.minimizeWindowButton.Name = "minimizeWindowButton";
            this.minimizeWindowButton.Size = new System.Drawing.Size(47, 43);
            this.minimizeWindowButton.TabIndex = 29;
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
            this.closeWindowButton.Location = new System.Drawing.Point(1301, 6);
            this.closeWindowButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeWindowButton.Name = "closeWindowButton";
            this.closeWindowButton.Size = new System.Drawing.Size(47, 43);
            this.closeWindowButton.TabIndex = 23;
            this.closeWindowButton.Text = "X";
            this.closeWindowButton.UseVisualStyleBackColor = false;
            this.closeWindowButton.Click += new System.EventHandler(this.CloseWindowButton_Click);
            this.closeWindowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseWindowButton_MouseDown);
            this.closeWindowButton.MouseLeave += new System.EventHandler(this.CloseWindowButton_MouseLeave);
            this.closeWindowButton.MouseHover += new System.EventHandler(this.CloseWindowButton_MouseHover);
            // 
            // stopVideoModeButton
            // 
            this.stopVideoModeButton.BackColor = System.Drawing.Color.Transparent;
            this.stopVideoModeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stopVideoModeButton.BackgroundImage")));
            this.stopVideoModeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopVideoModeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.stopVideoModeButton.FlatAppearance.BorderSize = 0;
            this.stopVideoModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.stopVideoModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.stopVideoModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopVideoModeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopVideoModeButton.ForeColor = System.Drawing.Color.White;
            this.stopVideoModeButton.Location = new System.Drawing.Point(577, 478);
            this.stopVideoModeButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopVideoModeButton.Name = "stopVideoModeButton";
            this.stopVideoModeButton.Size = new System.Drawing.Size(93, 86);
            this.stopVideoModeButton.TabIndex = 31;
            this.stopVideoModeButton.UseVisualStyleBackColor = false;
            this.stopVideoModeButton.Visible = false;
            this.stopVideoModeButton.Click += new System.EventHandler(this.StopVideoModeButton_Click);
            // 
            // recognitionInfoButton
            // 
            this.recognitionInfoButton.BackColor = System.Drawing.Color.Transparent;
            this.recognitionInfoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("recognitionInfoButton.BackgroundImage")));
            this.recognitionInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recognitionInfoButton.Enabled = false;
            this.recognitionInfoButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.recognitionInfoButton.FlatAppearance.BorderSize = 0;
            this.recognitionInfoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.recognitionInfoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.recognitionInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recognitionInfoButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recognitionInfoButton.ForeColor = System.Drawing.Color.White;
            this.recognitionInfoButton.Location = new System.Drawing.Point(394, 478);
            this.recognitionInfoButton.Margin = new System.Windows.Forms.Padding(4);
            this.recognitionInfoButton.Name = "recognitionInfoButton";
            this.recognitionInfoButton.Size = new System.Drawing.Size(93, 86);
            this.recognitionInfoButton.TabIndex = 28;
            this.recognitionInfoButton.UseVisualStyleBackColor = false;
            this.recognitionInfoButton.Click += new System.EventHandler(this.RecognitionInfoButton_Click);
            // 
            // chooseImageFileButton
            // 
            this.chooseImageFileButton.BackColor = System.Drawing.Color.Transparent;
            this.chooseImageFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chooseImageFileButton.BackgroundImage")));
            this.chooseImageFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chooseImageFileButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chooseImageFileButton.FlatAppearance.BorderSize = 0;
            this.chooseImageFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.chooseImageFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.chooseImageFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseImageFileButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseImageFileButton.ForeColor = System.Drawing.Color.White;
            this.chooseImageFileButton.Location = new System.Drawing.Point(33, 471);
            this.chooseImageFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.chooseImageFileButton.Name = "chooseImageFileButton";
            this.chooseImageFileButton.Size = new System.Drawing.Size(107, 98);
            this.chooseImageFileButton.TabIndex = 27;
            this.chooseImageFileButton.UseVisualStyleBackColor = false;
            this.chooseImageFileButton.Click += new System.EventHandler(this.ChooseImageFileButton_Click);
            // 
            // recognizeButton
            // 
            this.recognizeButton.BackColor = System.Drawing.Color.Transparent;
            this.recognizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("recognizeButton.BackgroundImage")));
            this.recognizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recognizeButton.Enabled = false;
            this.recognizeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.recognizeButton.FlatAppearance.BorderSize = 0;
            this.recognizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.recognizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.recognizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recognizeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recognizeButton.ForeColor = System.Drawing.Color.White;
            this.recognizeButton.Location = new System.Drawing.Point(210, 478);
            this.recognizeButton.Margin = new System.Windows.Forms.Padding(4);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(93, 86);
            this.recognizeButton.TabIndex = 26;
            this.recognizeButton.UseVisualStyleBackColor = false;
            this.recognizeButton.Click += new System.EventHandler(this.RecognizeButton_Click);
            // 
            // LicensePlateNumberLabel
            // 
            this.LicensePlateNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.LicensePlateNumberLabel.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LicensePlateNumberLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LicensePlateNumberLabel.Location = new System.Drawing.Point(174, 628);
            this.LicensePlateNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LicensePlateNumberLabel.Name = "LicensePlateNumberLabel";
            this.LicensePlateNumberLabel.Size = new System.Drawing.Size(609, 52);
            this.LicensePlateNumberLabel.TabIndex = 22;
            this.LicensePlateNumberLabel.Text = "Автомобільний номер:";
            // 
            // recognizedLPNumberTextBox
            // 
            this.recognizedLPNumberTextBox.BackColor = System.Drawing.Color.Black;
            this.recognizedLPNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recognizedLPNumberTextBox.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recognizedLPNumberTextBox.ForeColor = System.Drawing.Color.White;
            this.recognizedLPNumberTextBox.Location = new System.Drawing.Point(817, 626);
            this.recognizedLPNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.recognizedLPNumberTextBox.Name = "recognizedLPNumberTextBox";
            this.recognizedLPNumberTextBox.ReadOnly = true;
            this.recognizedLPNumberTextBox.Size = new System.Drawing.Size(347, 51);
            this.recognizedLPNumberTextBox.TabIndex = 21;
            this.recognizedLPNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // msTimer
            // 
            this.msTimer.Interval = 1;
            // 
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
            this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
            this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
            this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Paid", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Number_car", "Number_car")})});
            this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM `Paid` WHERE ((`Number_car` = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Number_car", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Number_car", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection
            // 
            this.oleDbConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\Avto_numbers_paid.accdb";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO `Paid` (`Number_car`) VALUES (?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Number_car", System.Data.OleDb.OleDbType.VarWChar, 0, "Number_car")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        Number_car\r\nFROM            Paid";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE `Paid` SET `Number_car` = ? WHERE ((`Number_car` = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Number_car", System.Data.OleDb.OleDbType.VarWChar, 0, "Number_car"),
            new System.Data.OleDb.OleDbParameter("Original_Number_car", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Number_car", System.Data.DataRowVersion.Original, null)});
            // 
            // videoModeButton
            // 
            this.videoModeButton.BackColor = System.Drawing.Color.Transparent;
            this.videoModeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("videoModeButton.BackgroundImage")));
            this.videoModeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoModeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.videoModeButton.FlatAppearance.BorderSize = 0;
            this.videoModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.videoModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.videoModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoModeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.videoModeButton.ForeColor = System.Drawing.Color.White;
            this.videoModeButton.Location = new System.Drawing.Point(577, 478);
            this.videoModeButton.Margin = new System.Windows.Forms.Padding(4);
            this.videoModeButton.Name = "videoModeButton";
            this.videoModeButton.Size = new System.Drawing.Size(93, 86);
            this.videoModeButton.TabIndex = 34;
            this.videoModeButton.UseVisualStyleBackColor = false;
            this.videoModeButton.Click += new System.EventHandler(this.VideoModeButton_Click);
            // 
            // recognizedSceneImageBox
            // 
            this.recognizedSceneImageBox.BackColor = System.Drawing.Color.Transparent;
            this.recognizedSceneImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recognizedSceneImageBox.Location = new System.Drawing.Point(710, 57);
            this.recognizedSceneImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.recognizedSceneImageBox.Name = "recognizedSceneImageBox";
            this.recognizedSceneImageBox.Size = new System.Drawing.Size(637, 370);
            this.recognizedSceneImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recognizedSceneImageBox.TabIndex = 2;
            this.recognizedSceneImageBox.TabStop = false;
            // 
            // recognizedPlateImageBox
            // 
            this.recognizedPlateImageBox.BackColor = System.Drawing.Color.Transparent;
            this.recognizedPlateImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recognizedPlateImageBox.Location = new System.Drawing.Point(710, 456);
            this.recognizedPlateImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.recognizedPlateImageBox.Name = "recognizedPlateImageBox";
            this.recognizedPlateImageBox.Size = new System.Drawing.Size(637, 113);
            this.recognizedPlateImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.recognizedPlateImageBox.TabIndex = 36;
            this.recognizedPlateImageBox.TabStop = false;
            // 
            // originalSceneImageBox
            // 
            this.originalSceneImageBox.BackColor = System.Drawing.Color.Transparent;
            this.originalSceneImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalSceneImageBox.Location = new System.Drawing.Point(33, 57);
            this.originalSceneImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.originalSceneImageBox.Name = "originalSceneImageBox";
            this.originalSceneImageBox.Size = new System.Drawing.Size(637, 370);
            this.originalSceneImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalSceneImageBox.TabIndex = 38;
            this.originalSceneImageBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 713);
            this.Controls.Add(this.originalSceneImageBox);
            this.Controls.Add(this.recognizedPlateImageBox);
            this.Controls.Add(this.recognizedSceneImageBox);
            this.Controls.Add(this.videoModeButton);
            this.Controls.Add(this.aboutProgramButton);
            this.Controls.Add(this.instructionButton);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.minimizeWindowButton);
            this.Controls.Add(this.closeWindowButton);
            this.Controls.Add(this.stopVideoModeButton);
            this.Controls.Add(this.recognitionInfoButton);
            this.Controls.Add(this.chooseImageFileButton);
            this.Controls.Add(this.recognizeButton);
            this.Controls.Add(this.LicensePlateNumberLabel);
            this.Controls.Add(this.recognizedLPNumberTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Головна";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recognizedSceneImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recognizedPlateImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalSceneImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label appTitleLabel;
        private System.Windows.Forms.Button aboutProgramButton;
        private System.Windows.Forms.Button instructionButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox appIconPictureBox;
        private System.Windows.Forms.Button minimizeWindowButton;
        private System.Windows.Forms.Button closeWindowButton;
        private System.Windows.Forms.Button stopVideoModeButton;
        private System.Windows.Forms.Button recognitionInfoButton;
        private System.Windows.Forms.Button chooseImageFileButton;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.Label LicensePlateNumberLabel;
        private System.Windows.Forms.TextBox recognizedLPNumberTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer msTimer;
        private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Windows.Forms.Button videoModeButton;
        private Emgu.CV.UI.ImageBox recognizedSceneImageBox;
        private Emgu.CV.UI.ImageBox recognizedPlateImageBox;
        private Emgu.CV.UI.ImageBox originalSceneImageBox;
    }
}

