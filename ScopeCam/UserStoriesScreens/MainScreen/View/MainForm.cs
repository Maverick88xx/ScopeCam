using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Emgu.CV;
using Emgu.CV.CvEnum;

using ScopeCam.UserStoriesScreens.MainScreen.View.Interfaces;
using ScopeCam.UserStoriesScreens.MainScreen.Presenter;

using static ScopeCam.LicensePlateDrawingHelper;
using static ScopeCam.DetectPlates;
using System.Data.OleDb;

namespace ScopeCam
{
    public partial class MainForm : Form, IPaymentDB
    {
        private PaymentDBPresenter paymentDBPresenter;

        public MainForm()
        {
            InitializeComponent();

            paymentDBPresenter = new PaymentDBPresenter(this);
        }

        //Оголошення глобальних змінних

        // назва файлу із зображенням
        string FileName;

        // для зберігання кадрів трансляції з відеокамери
        static Mat videoFrameImage = new Mat();

        // для зчитування кадру з відеокамери
        static VideoCapture capture = new VideoCapture(0);


        #region IPaymentDB interface methods implement
        public string RecognizedLPNumberText
        {
            get
            {
                return recognizedLPNumberTextBox.Text;
            }
        }

        public OleDbConnection DatabaseConnection
        {
            get
            {
                return oleDbConnection;
            }
        }

        // Відкриття та закриття проїзду - 9 секунд - заглушка для навчальної демонстрації
        public void OpenTheBarrier()
        {
            recognizedSceneImageBox.ImageLocation = UserStoriesGeneralConstants.kLiftingBarrierStubGifFilePath;

            Wait(9000);
        }
        #endregion


        private void CloseWindowButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutProgramButton_Click(object sender, EventArgs e)
        {
            ShowWinForm(this, new AboutProgramForm());
        }

        private void InstructionButton_Click(object sender, EventArgs e)
        {
            instructionButton.ForeColor = Color.DarkTurquoise;

            ShowWinForm(this, new InstructionForm());
        }

        private void MinimizeWindowButton_Click(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.DarkTurquoise;

            this.WindowState = FormWindowState.Minimized;
        }

        private void ChooseImageFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = UserStoriesGeneralConstants.kChooseImageMessage;

            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                recognizeButton.Enabled       = true;
                recognitionInfoButton.Enabled = false;

                recognizedLPNumberTextBox.Text = "";

                FileName = openFileDialog.FileName.ToString();

                originalSceneImageBox.ImageLocation = FileName;

                FileName = openFileDialog.SafeFileName.ToString();

                recognizedPlateImageBox.Image = null;
                recognizedSceneImageBox.Image = null;
            }
        }

        private void RecognizeButton_Click(object sender, EventArgs e)
        {
            DetectPlates.currentProgramMode = ProgramMode.ImageRecognitionSimpleMode;

            string originalImage = UserStoriesGeneralConstants.kCarsDirectory + FileName;

            // Зчитування вхідного зображення
            Mat imgOriginalScene = CvInvoke.Imread(originalImage);

            // Якщо не вдалося прочитати зображення - показати повідомлення про помилку
            if (imgOriginalScene.IsEmpty)
            {
                MessageBox.Show(UserStoriesGeneralConstants.kImageNotFoundMessage,
                                UserStoriesGeneralConstants.kError, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }

            // Знайти можливі пластини автомобільних номерів
            List<PossiblePlate> vectorOfPossiblePlates = DetectPlates.DetectPlatesInScene(ref imgOriginalScene);

            // Знайти символи на пластинах автомобільних номерів
            vectorOfPossiblePlates = DetectChars.DetectCharsInPlates(ref vectorOfPossiblePlates);

            // Якщо не було знайдено ніяких пластин - вивести про це повідомлення
            if (vectorOfPossiblePlates.Count == 0)
            {
                MessageBox.Show(UserStoriesGeneralConstants.kLicensePlateNotRecognizedMessage,
                                UserStoriesGeneralConstants.kError, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            else
            {
                // Інакше, якщо було отримано вектор можливих пластин,
                // що має щонайменше одну пластину,
                // сортувати вектор можливих пластин в порядку спадання
                // (з найбільшої кількості символів до найменшої кількості символів)
                vectorOfPossiblePlates.Sort((x, y) => -x.licensePlateChars.Length.CompareTo(y.licensePlateChars.Length));

                // Припущення, що пластина з найбільш впізнаваних символів 
                // (перша пластина яка відсортована по довжині рядка у порядку убування) є актуальною пластиною
                PossiblePlate licPlate = vectorOfPossiblePlates[0];

                // Записати значення пластини та показати його
                recognizedPlateImageBox.Image = licPlate.plateImage;

                // Блок для коректного відображення подробиць розпізнавання (кнопка "Подробиці розпізнавання")
                DetectPlates.currentProgramMode = ProgramMode.ImageRecognitionAnalysisMode;

                List<PossiblePlate> plateNumbersImage = DetectPlates.DetectPlatesInScene(ref licPlate.plateImage);

                // Виявити символи на пластині автомобільних номерів
                // кінець блоку
                plateNumbersImage = DetectChars.DetectCharsInPlates(ref plateNumbersImage);

                // Якщо символи не були знайдені на пластині - показати повідомлення
                if (licPlate.licensePlateChars.Length == 0)
                {
                    MessageBox.Show(UserStoriesGeneralConstants.kCharsOnLicensePlateNotRecognizedMessage,
                                    UserStoriesGeneralConstants.kError, 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                }

                // Намалювати червоний прямокутник навколо пластини номерних знаків
                DrawRedRectangleAroundPlate(imgOriginalScene, licPlate);

                // Вивести текст автомобільного номеру
                recognizedLPNumberTextBox.Text = licPlate.licensePlateChars;

                // Написати текст номерного знаку на зображенні
                WriteLicensePlateCharsOnImage(imgOriginalScene, licPlate);

                recognizedSceneImageBox.Image = imgOriginalScene;

                recognizeButton.Enabled       = false;
                recognitionInfoButton.Enabled = true;
            }
        }

        private void RecognitionInfoButton_Click(object sender, EventArgs e)
        {
            ShowWinForm(this, new RecognitionAnalysisForm());
        }

        private void StopVideoModeButton_Click(object sender, EventArgs e)
        {
            videoModeButton.Visible     = true;
            stopVideoModeButton.Visible = false;

            Application.Idle -= processFrameAndUpdateGUIForVideoMode;

            ClearAllImageBoxes();

            recognizedLPNumberTextBox.Text = "";
            chooseImageFileButton.Enabled  = true;
        }

        private void VideoModeButton_Click(object sender, EventArgs e)
        {
            videoModeButton.Visible     = false;
            stopVideoModeButton.Visible = true;

            ClearAllImageBoxes();

            recognizeButton.Enabled       = false;
            chooseImageFileButton.Enabled = false;
            recognitionInfoButton.Enabled = false;

            Application.Idle += processFrameAndUpdateGUIForVideoMode;
        }

        private void CloseWindowButton_MouseDown(object sender, MouseEventArgs e)
        {
            closeWindowButton.ForeColor = Color.IndianRed;
        }

        private void CloseWindowButton_MouseHover(object sender, EventArgs e)
        {
            closeWindowButton.ForeColor = Color.Red;
        }

        private void CloseWindowButton_MouseLeave(object sender, EventArgs e)
        {
            closeWindowButton.ForeColor = Color.White;
        }

        private void MinimizeWindowButton_MouseHover(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.Aqua;
        }

        private void MinimizeWindowButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.White;
        }

        Point lastLocation = new Point();

        bool mouseDown = false;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDown == false && e.Button == MouseButtons.Left)
            {
                mouseDown = true;

                lastLocation = e.Location;
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - lastLocation.X + e.X, 
                                        this.DesktopLocation.Y - lastLocation.Y + e.Y);
                this.Update();
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        void processFrameAndUpdateGUIForVideoMode(object sender, EventArgs arg)
        {
            videoFrameImage = capture.QueryFrame();

            originalSceneImageBox.Image = videoFrameImage;

            DetectPlates.currentProgramMode = ProgramMode.VideoRecognitionMode;

            // Якщо не вдалося відкрити зображення - показати повідомлення про помилку
            if (videoFrameImage.IsEmpty)
            {
                MessageBox.Show(UserStoriesGeneralConstants.kImageNotFoundMessage,
                                UserStoriesGeneralConstants.kError, 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            // Знайти можливі пластини автомобільних номерів
            List<PossiblePlate> vectorOfPossiblePlates = DetectPlates.DetectPlatesInScene(ref videoFrameImage);

            // Знайти символи в пластинах автомобільних номерів
            vectorOfPossiblePlates = DetectChars.DetectCharsInPlates(ref vectorOfPossiblePlates);

            // Якщо не було знайдено ніяких пластин
            if (vectorOfPossiblePlates.Count == 0)
            {
                recognizedLPNumberTextBox.Text = "";

                recognizedPlateImageBox.Image = null;
                recognizedSceneImageBox.Image = null;
            }
            else
            { // Інакше, якщо було отримано вектор можливих пластин, 
              // що має щонайменше одну пластину, то
              // сортувати вектор можливих пластин в порядку спадання 
              // (з найбільшої кількості символів до найменшої кількості символів)
                vectorOfPossiblePlates.Sort((x, y) => -x.licensePlateChars.Length.CompareTo(y.licensePlateChars.Length));

                // Припущення, що пластина з найбільш впізнаваних символів 
                // (перша пластина яка відсортована по довжині рядка у порядку убування) є актуальною пластиною
                PossiblePlate licPlate = vectorOfPossiblePlates[0];

                recognizedPlateImageBox.Image = licPlate.plateImage;

                // Намалювати червоний прямокутник навколо пластини номерних знаків
                DrawRedRectangleAroundPlate(videoFrameImage, licPlate);

                // Вивести текст автомобільного номеру
                recognizedLPNumberTextBox.Text = licPlate.licensePlateChars;

                // Написати текст номерного знаку на зображенні
                WriteLicensePlateCharsOnImage(videoFrameImage, licPlate);

                recognizedSceneImageBox.Image = videoFrameImage;

                // Підключення та взаємодія з Базою Даних
                paymentDBPresenter.FindLPNumberInDB();
            }
        }

        private void InstructionButton_MouseHover(object sender, EventArgs e)
        {
            instructionButton.ForeColor = Color.Aqua;
        }

        private void InstructionButton_MouseLeave(object sender, EventArgs e)
        {
            instructionButton.ForeColor = Color.White;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Спроба KNN навчання
            bool blnKNNTrainingSuccessful = DetectChars.LoadKNNDataAndTrainKNN();

            // Якщо KNN  навчання не було успішним - показати повідомлення про помилку
            if (blnKNNTrainingSuccessful == false)
            {
                MessageBox.Show(UserStoriesGeneralConstants.kNotSuccessKNNTrainingMessage,
                                UserStoriesGeneralConstants.kError, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }

        #region Internal methods
        private void Wait(int milliseconds)
        {
            if (milliseconds == 0 || milliseconds < 0) return;
            
            msTimer.Interval = milliseconds;
            msTimer.Enabled = true;
            msTimer.Start();
            msTimer.Tick += (s, e) =>
            {
                msTimer.Enabled = false;
                msTimer.Stop();
            };
            while (msTimer.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void ShowWinForm(Form currentForm, Form showingForm)
        {
            currentForm.Hide();

            showingForm.ShowDialog();

            currentForm.Show();
        }

        private void ClearAllImageBoxes()
        {
            recognizedPlateImageBox.Image = null;
            originalSceneImageBox.Image   = null;
            recognizedSceneImageBox.Image = null;
        }
        #endregion
    }
}
