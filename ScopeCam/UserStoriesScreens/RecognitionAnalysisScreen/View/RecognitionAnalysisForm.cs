using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeCam
{
    public partial class RecognitionAnalysisForm : Form
    {
        public RecognitionAnalysisForm()
        {
            InitializeComponent();
        }

        int counter_img = 0;
        private void CloseWindowButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RecognitionAnalysisForm_Load(object sender, EventArgs e)
        {
            sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kOriginalSceneImageFilePath);
        }

        private void NextSlideButton_Click(object sender, EventArgs e)
        {
            counter_img++;

            previousSlideButton.Enabled = true;

            switch (counter_img)
            {
                case 1:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kGrayscaleSceneImageFilePath);

                        break;
                    }
                case 2:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kThreshSceneImageFilePath);

                        break;
                    }
                case 3:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kDoubleThreshSceneImageFilePath);

                        break;
                    }
                case 4:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPossibleCharsInSceneImageFilePath);

                        break;
                    }
                case 5:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kVectorOfMatchingCharsInSceneFilePath);

                        break;
                    }
                case 6:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.ClientSize = new Size(941, 574);

                        sliderImagePictureBox.Location = new Point(220, 54);

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kVectorOfPossiblePlatesInSceneFilePath);

                        break;
                    }
                case 7:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.ClientSize = new Size(801, 147);

                        sliderImagePictureBox.Location = new Point(291, 246);

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateImageFilePath);

                        break;
                    }
                case 8:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateGrayscaleImageFilePath);

                        break;
                    }
                case 9:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateThreshImageFilePath);

                        break;
                    }
                case 10:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateDoubleThreshImageFilePath);

                        break;
                    }
                case 11:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlatePossibleCharsImageFilePath);

                        break;
                    }
                case 12:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateMatchingCharsImageFilePath);

                        break;
                    }
                case 13:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateRemovedOverlappingImageFilePath);

                        break;
                    }
                case 14:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateLongestMatchCharsVectorFilePath);

                        nextSlideButton.Enabled = true;

                        break;
                    }
                case 15:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateRecognizedCharsImageFilePath);

                        nextSlideButton.Enabled = false;

                        break;
                    }
                default:
                    {
                        nextSlideButton.Enabled = false;

                        break;
                    }
            }
        }

        private void RecognitionAnalysisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sliderImagePictureBox.Image = null;
        }

        private void PreviousSlideButton_Click(object sender, EventArgs e)
        {
            counter_img--;

            nextSlideButton.Enabled = true;

            switch (counter_img)
            {
                case 1:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kGrayscaleSceneImageFilePath);

                        break;
                    }
                case 2:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kThreshSceneImageFilePath);

                        break;
                    }
                case 3:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kDoubleThreshSceneImageFilePath);

                        break;
                    }
                case 4:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPossibleCharsInSceneImageFilePath);

                        break;
                    }
                case 5:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kVectorOfMatchingCharsInSceneFilePath);

                        break;
                    }
                case 6:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.ClientSize = new Size(941, 574);

                        sliderImagePictureBox.Location = new Point(220, 54);

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kVectorOfPossiblePlatesInSceneFilePath);

                        break;
                    }
                case 7:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.ClientSize = new Size(801, 147);

                        sliderImagePictureBox.Location = new Point(291, 246);

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateImageFilePath);

                        break;
                    }
                case 8:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateGrayscaleImageFilePath);

                        break;
                    }
                case 9:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateThreshImageFilePath);

                        break;
                    }
                case 10:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateDoubleThreshImageFilePath);

                        break;
                    }
                case 11:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlatePossibleCharsImageFilePath);

                        break;
                    }
                case 12:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateMatchingCharsImageFilePath);

                        break;
                    }
                case 13:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateRemovedOverlappingImageFilePath);

                        break;
                    }
                case 14:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateLongestMatchCharsVectorFilePath);

                        break;
                    }
                case 15:
                    {
                        sliderImagePictureBox.Image = null;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kPlateRecognizedCharsImageFilePath);

                        break;
                    }
                default:
                    {
                        previousSlideButton.Enabled = false;

                        sliderImagePictureBox.Image = Image.FromFile(UserStoriesGeneralConstants.kOriginalSceneImageFilePath);
                    }

                    break;
            }
        }

        private void RecognitionAnalysisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sliderImagePictureBox.Image = null;
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

        private void MinimizeWindowButton_Click(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.DarkTurquoise;

            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeWindowButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.White;
        }

        Point lastLocation;

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
    }
}
