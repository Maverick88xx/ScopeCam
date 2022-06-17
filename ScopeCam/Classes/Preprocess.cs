using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;

using System.Drawing;

namespace ScopeCam
{
    class Preprocess
    {
        // Глобальні змінні
        private static readonly Size GAUSSIAN_SMOOTH_FILTER_SIZE = new Size(5, 5);

        private static readonly int ADAPTIVE_THRESH_BLOCK_SIZE   = 19;
        private static readonly int ADAPTIVE_THRESH_WEIGHT       = 9;

        public static void DoPreprocess(Mat originalImage, ref Mat grayscaleImage, ref Mat threshImage)
        {
            grayscaleImage = ExtractGrayscaleValue(originalImage);

            Mat maxContrastGrayscaleImage = MaximizeContrast(ref grayscaleImage);

            // Змінна для задання розмиття
            Mat blurredImage = new Mat();

            // Гаусове розмиття
            CvInvoke.GaussianBlur(maxContrastGrayscaleImage, 
                                  blurredImage, 
                                  GAUSSIAN_SMOOTH_FILTER_SIZE, 
                                  0);

            // Перетворює зображення у відтінках сірого на бінарне зображення. 
            // Поріг розраховується індивідуально для кожного пікселя.
            CvInvoke.AdaptiveThreshold(blurredImage, 
                                       threshImage, 
                                       255.0, 
                                       AdaptiveThresholdType.GaussianC, 
                                       ThresholdType.BinaryInv, 
                                       ADAPTIVE_THRESH_BLOCK_SIZE, 
                                       ADAPTIVE_THRESH_WEIGHT);
        }

        // Отримання значення каналу кольору з оригінального 
        // зображення, щоб отримати відтінки сірого зображення
        private static Mat ExtractGrayscaleValue(Mat originalImage)
        {
            Mat HSVImage   = new Mat();
            Mat imageValue = new Mat();

            VectorOfMat vectorOfHSVImages = new VectorOfMat();

            CvInvoke.CvtColor(originalImage, HSVImage, ColorConversion.Bgr2Hsv);

            CvInvoke.Split(HSVImage, vectorOfHSVImages);

            vectorOfHSVImages[2].CopyTo(imageValue);

            return (imageValue);
        }

        // Збільшити контраст
        private static Mat MaximizeContrast(ref Mat imgGrayscale)
        {
            Mat topHatImage                           = new Mat();
            Mat blackHatImage                         = new Mat();
            Mat grayscalePlusTopHatImage              = new Mat();
            Mat grayscalePlusTopHatMinusBlackHatImage = new Mat();

            Mat structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                                                                    new Size(3, 3), 
                                                                    new Point(-1, -1));
            
            CvInvoke.MorphologyEx(imgGrayscale, 
                                  topHatImage, 
                                  MorphOp.Tophat, 
                                  structuringElement, 
                                  new Point(-1, -1), 
                                  1, 
                                  BorderType.Default, 
                                  new MCvScalar());
            
            CvInvoke.MorphologyEx(imgGrayscale, 
                                  blackHatImage, 
                                  MorphOp.Blackhat, 
                                  structuringElement, 
                                  new Point(-1, -1), 
                                  1, 
                                  BorderType.Default, 
                                  new MCvScalar());

            CvInvoke.Add(imgGrayscale, topHatImage, grayscalePlusTopHatImage);

            CvInvoke.Subtract(grayscalePlusTopHatImage, blackHatImage, grayscalePlusTopHatMinusBlackHatImage);

            return (grayscalePlusTopHatMinusBlackHatImage);
        }
    }
}