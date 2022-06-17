using System;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.CvEnum;

using static ScopeCam.ScalarColorConstants;

namespace ScopeCam
{
    class LicensePlateDrawingHelper
    {
        public static void DrawRedRectangleAroundPlate(Mat originalSceneImage, PossiblePlate licensePlate)
        {
            // Отримати 4 вершини повернутого прямокутника
            PointF[] p2fRectPoints = licensePlate.locationOfPlateInSceneRR.GetVertices();

            // Намалювати 4 червоні лінії
            for (int i = 0; i < 4; i++)
            {
                CvInvoke.Line(originalSceneImage,
                              Point.Round(p2fRectPoints[i]),
                              Point.Round(p2fRectPoints[(i + 1) % 4]),
                              SCALAR_RED_COLOR,
                              2);
            }
        }

        public static void WriteLicensePlateCharsOnImage(Mat originalSceneImage, PossiblePlate licensePlate)
        {
            // Центр області для запису тексту
            Point ptCenterOfTextArea = new Point();

            // Лівий нижній кут області для запису тексту
            Point ptLowerLeftTextOrigin = new Point();

            // Вибір шрифта 'JANE'
            var fontFace = FontFace.HersheySimplex;

            // Базовий розмір шрифту по висоті зони номерного знаку
            double fontScale = (double)licensePlate.plateImage.Rows / 30.0;

            // Базова товщина шрифту за шкалою шрифту
            int fontThickness = (int)Math.Round(fontScale * 1.5);

            int baseline = 0;

            // Отримати розмір тексту
            Size textSize = CvInvoke.GetTextSize(licensePlate.licensePlateChars,
                                                 fontFace,
                                                 fontScale,
                                                 fontThickness,
                                                 ref baseline);

            // Горизонтальне розташування текстової 
            // області є таким же, як і номерного знаку
            ptCenterOfTextArea.X = (int)licensePlate.locationOfPlateInSceneRR.Center.X;

            // Якщо номерний знак знаходиться у верхній 3/4 частині 
            // зображення, тоді писати символи нижче номерного знаку
            if (licensePlate.locationOfPlateInSceneRR.Center.Y < (originalSceneImage.Rows * 0.75))
            {
                ptCenterOfTextArea.Y = (int)Math.Round(licensePlate.locationOfPlateInSceneRR.Center.Y) +
                                       (int)Math.Round(licensePlate.plateImage.Rows * 1.6);
            }

            // Інакше, якщо номерний знак знаходиться в нижній частині 
            // зображення, тоді писати символи вище номерного знаку
            else
            {
                ptCenterOfTextArea.Y = (int)Math.Round(licensePlate.locationOfPlateInSceneRR.Center.Y) -
                                       (int)Math.Round(licensePlate.plateImage.Rows * 1.6);
            }

            // Обчислити лівий нижній кут області для запису тексту,
            // заснований на центрі текстової області, ширині і висоті
            ptLowerLeftTextOrigin.X = (int)(ptCenterOfTextArea.X - (textSize.Width  / 2));
            ptLowerLeftTextOrigin.Y = (int)(ptCenterOfTextArea.Y + (textSize.Height / 2));

            // Написати текст розпізнаного номерного знаку на зображенні
            CvInvoke.PutText(originalSceneImage,
                             licensePlate.licensePlateChars,
                             ptLowerLeftTextOrigin,
                             fontFace,
                             fontScale,
                             SCALAR_YELLOW_COLOR,
                             fontThickness);
        }
    }
}
