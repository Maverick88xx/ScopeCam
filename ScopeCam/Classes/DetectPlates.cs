using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

using static ScopeCam.ScalarColorConstants;
using static ScopeCam.LicensePlateDrawingHelper;

using System.Runtime.ExceptionServices;

namespace ScopeCam
{
    class DetectPlates
    {
        // Глобальні константи
        private static readonly double PLATE_WIDTH_PADDING_FACTOR  = 1.3;
        private static readonly double PLATE_HEIGHT_PADDING_FACTOR = 1.5;

        // Глобальна змінна для зберігання поточного режиму роботи програми
        public static ProgramMode currentProgramMode;

        public enum ProgramMode
        {
            ImageRecognitionSimpleMode = 0,
            ImageRecognitionAnalysisMode,
            VideoRecognitionMode
        }

        [HandleProcessCorruptedStateExceptions]
        public static List<PossiblePlate> DetectPlatesInScene(ref Mat imgOriginalScene)
        {
            // Список можливих номерних пластин для повернення значення з методу
            List<PossiblePlate> vectorOfPossiblePlates = new List<PossiblePlate>();

            Mat imgGrayscaleScene = new Mat();
            Mat imgThreshScene    = new Mat();

            Mat imgContours = new Mat(imgOriginalScene.Size, DepthType.Cv8U, 3);

            Random rnd = new Random();

            imgContours.SetTo(SCALAR_BLACK_COLOR);

            if (currentProgramMode == ProgramMode.ImageRecognitionSimpleMode)
            {
                CvInvoke.Imwrite(UserStoriesGeneralConstants.kOriginalSceneImageFilePath, imgOriginalScene);
            }

            // Попередня обробка для отримання чорно-білого і порогового(бінарного) зображення
            Preprocess.DoPreprocess(imgOriginalScene, ref imgGrayscaleScene, ref imgThreshScene);

            if (currentProgramMode == ProgramMode.ImageRecognitionSimpleMode)
            {
                CvInvoke.Imwrite(UserStoriesGeneralConstants.kGrayscaleSceneImageFilePath, imgGrayscaleScene);
                CvInvoke.Imwrite(UserStoriesGeneralConstants.kThreshSceneImageFilePath,    imgThreshScene);
            }
            // Знайти всі можливі символи на зображенні,
            // Функція спочатку знаходить всі контури, 
            // які можуть бути символами (без порівняння з іншими символами)
            List<PossibleChar> vectorOfPossibleCharsInScene = FindPossibleCharsInScene(ref imgThreshScene);

            if (currentProgramMode == ProgramMode.ImageRecognitionSimpleMode)
            {
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

                foreach (PossibleChar possibleChar in vectorOfPossibleCharsInScene)
                {
                    contours.Push(possibleChar.contour);
                }

                CvInvoke.DrawContours(imgContours, contours, -1, SCALAR_WHITE_COLOR);

                CvInvoke.Imwrite(UserStoriesGeneralConstants.kPossibleCharsInSceneImageFilePath, imgContours);
            }

            // Враховуючи вектор всіх можливих символів, 
            // знайти групи однакових символів.
            // В наступних кроках кожна група співпадаючих символів 
            // може бути визнаною як номерний знак
            List<List<PossibleChar>> vectorOfVectorsOfMatchingCharsInScene = 
                      DetectChars.FindVectorOfVectorsOfMatchingChars(ref vectorOfPossibleCharsInScene);

            if (currentProgramMode == ProgramMode.ImageRecognitionSimpleMode)
            {
                imgContours = new Mat(imgOriginalScene.Size, DepthType.Cv8U, 3);

                imgContours.SetTo(SCALAR_BLACK_COLOR);

                foreach (List<PossibleChar> vectorOfMatchingChars in vectorOfVectorsOfMatchingCharsInScene)
                {
                    int intRandomBlue  = rnd.Next(0, 256);
                    int intRandomGreen = rnd.Next(0, 256);
                    int intRandomRed   = rnd.Next(0, 256);

                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

                    try
                    {
                        foreach (PossibleChar matchingChar in vectorOfMatchingChars)
                        {
                            contours.Push(matchingChar.contour);
                        }

                        CvInvoke.DrawContours(imgContours, contours, -1, new MCvScalar(intRandomBlue,
                                                                                       intRandomGreen,
                                                                                       intRandomRed));
                    }
                    catch (Exception){ }
                }

                CvInvoke.Imwrite(UserStoriesGeneralConstants.kVectorOfMatchingCharsInSceneFilePath, imgContours);
            }

            List<PossibleChar> vectorOfMatchingCharsTemp;

            // Для кожної групи співпадаючих символів
            foreach (List<PossibleChar> vectorOfMatchingChars in vectorOfVectorsOfMatchingCharsInScene)
            {
                vectorOfMatchingCharsTemp = vectorOfMatchingChars;

                // Отримання пластини номерних знаків
                PossiblePlate possiblePlate = ExtractPlate(ref imgOriginalScene, ref vectorOfMatchingCharsTemp);

                // Якщо номерний знак було знайдено
                if (possiblePlate.plateImage.IsEmpty == false)
                {
                    // Додати до вектору можливих номерних знаків
                    vectorOfPossiblePlates.Add(possiblePlate);
                }
            }

            if (currentProgramMode == ProgramMode.ImageRecognitionSimpleMode)
            {
                MessageBox.Show(UserStoriesGeneralConstants.kFoundPossiblePlatesMessage + 
                                vectorOfPossiblePlates.Count.ToString(),
                                UserStoriesGeneralConstants.kInformation, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                for (int i = 0; i < vectorOfPossiblePlates.Count; i++)
                {
                    DrawRedRectangleAroundPlate(imgContours, vectorOfPossiblePlates[i]);

                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kVectorOfPossiblePlatesInSceneFilePath, imgContours);
                }
            }

            return vectorOfPossiblePlates;
        }


        private static List<PossibleChar> FindPossibleCharsInScene(ref Mat imgThresh)
        {
            // Список можливих символів на зображенні для повернення значення списку з методу
            List<PossibleChar> vectorOfPossibleChars = new List<PossibleChar>();

            Mat imgContours = new Mat(imgThresh.Size, DepthType.Cv8U, 3);

            imgContours.SetTo(SCALAR_BLACK_COLOR);

            int intCountOfPossibleChars = 0;

            Mat imgThreshCopy = imgThresh.Clone();

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            // Знаходження всіх контурів на номерному знаці 
            CvInvoke.FindContours(imgThreshCopy, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            // Для кожного контуру
            for (int i = 0; i < contours.Size; i++)
            { 
                CvInvoke.DrawContours(imgContours, contours, i, SCALAR_WHITE_COLOR);

                PossibleChar possibleChar = new PossibleChar(contours[i]);

                // Якщо контур - це можливий символ, (не є порівняннням з іншими символами)
                if (DetectChars.CheckIfPossibleChar(possibleChar))
                {
                    // Інкремент (збільшення) кількості можливих символів
                    intCountOfPossibleChars++;

                    // Додавання до вектору можливих символів
                    vectorOfPossibleChars.Add(possibleChar);
                }
            }

            if (currentProgramMode == ProgramMode.ImageRecognitionSimpleMode)
            {
                CvInvoke.Imwrite(UserStoriesGeneralConstants.kDoubleThreshSceneImageFilePath, imgContours);
            }

            return (vectorOfPossibleChars);
        }


        private static PossiblePlate ExtractPlate(ref Mat imgOriginal, ref List<PossibleChar> vectorOfMatchingChars)
        {
            // Об'єкт можливої номерної пластини для повернення значення з методу
            PossiblePlate possiblePlate = new PossiblePlate();

            // Сортування по символам зліва направо, грунтуючись на положенні X
            vectorOfMatchingChars.Sort((x, y) => x.pointOfCenterX.CompareTo(y.pointOfCenterX));

            // Обчислення точки центру номерного знаку
            double dblPlateCenterX = (vectorOfMatchingChars[0].pointOfCenterX + 
                                      vectorOfMatchingChars[vectorOfMatchingChars.Count - 1].pointOfCenterX) / 2.0;

            double dblPlateCenterY = (vectorOfMatchingChars[0].pointOfCenterY + 
                                      vectorOfMatchingChars[vectorOfMatchingChars.Count - 1].pointOfCenterY) / 2.0;

            PointF p2dPlateCenter = new PointF((float)dblPlateCenterX, (float)dblPlateCenterY);

            // Розрахунок ширини і висоти номерного знаку
            int intPlateWidth = (int)((vectorOfMatchingChars[vectorOfMatchingChars.Count  - 1].boundingRect.X     + 
                                        vectorOfMatchingChars[vectorOfMatchingChars.Count - 1].boundingRect.Width - 
                                        vectorOfMatchingChars[0].boundingRect.X) 
                                       * PLATE_WIDTH_PADDING_FACTOR);

            double intTotalOfCharHeights = 0;

            foreach (PossibleChar matchingChar in vectorOfMatchingChars)
            {
                intTotalOfCharHeights = intTotalOfCharHeights + matchingChar.boundingRect.Height;
            }

            double dblAverageCharHeight = intTotalOfCharHeights / vectorOfMatchingChars.Count;

            int intPlateHeight = (int)(dblAverageCharHeight * PLATE_HEIGHT_PADDING_FACTOR);

            // Обчислення кута корекції області номерного знаку
            double dblOpposite = vectorOfMatchingChars[vectorOfMatchingChars.Count - 1].pointOfCenterY - 
                                 vectorOfMatchingChars[0].pointOfCenterY;

            PossibleChar firstMatchingChar = vectorOfMatchingChars[0];
            PossibleChar lastMatchingChar  = vectorOfMatchingChars[vectorOfMatchingChars.Count - 1];

            double dblHypotenuse = DetectChars.DistanceBetweenChars(ref firstMatchingChar, ref lastMatchingChar);
            double dblCorrectionAngleInRad = Math.Asin(dblOpposite / dblHypotenuse);
            double dblCorrectionAngleInDeg = dblCorrectionAngleInRad * (180.0 / Math.PI);

            // Призначення повернутої змінної членом можливого номерного знаку
            possiblePlate.locationOfPlateInSceneRR = new RotatedRect(p2dPlateCenter, 
                                                                     new Size(intPlateWidth, intPlateHeight), 
                                                                     (float)dblCorrectionAngleInDeg);

            // Кінцеві кроки для виконання фактичного обертання
            // ..

            Mat rotationMatrix = new Mat();

            Mat imgRotated = new Mat();
            Mat imgCropped = new Mat();

            // Отримання матриці обертання для розрахунку кута корекції
            CvInvoke.GetRotationMatrix2D(p2dPlateCenter, dblCorrectionAngleInDeg, 1.0, rotationMatrix);

            // Поворот всього зображення
            CvInvoke.WarpAffine(imgOriginal, imgRotated, rotationMatrix, imgOriginal.Size);

            // Обрізати фактичну частину номерного знаку повернутого зображення
            CvInvoke.GetRectSubPix(imgRotated, 
                                   Size.Round(possiblePlate.locationOfPlateInSceneRR.Size), 
                                   possiblePlate.locationOfPlateInSceneRR.Center, 
                                   imgCropped);

            // Скопіювати обрізаний номерний знак (зображення) в 
            // призначену змінну можливого номерного знаку
            possiblePlate.plateImage = imgCropped;

            return (possiblePlate);
        }
    }
}
