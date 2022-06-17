using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Emgu.CV;                                  
using Emgu.CV.Structure;                             
using Emgu.CV.ML; 
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

using System.IO;

// Classes
using static ScopeCam.DetectPlates;

// Constants
using static ScopeCam.ScalarColorConstants;

// Імпорт для запису об'єктів Matrix в файл, див. кінець програми
using System.Xml.Serialization;

namespace ScopeCam
{
    class DetectChars
    {
        // Глобальні константи

        // Константи для перевірки можливого символу, 
        // перевіряє тільки один можливий символ (не порівнює з іншим символом)
        private const int MIN_PIXEL_WIDTH  = 2;
        private const int MIN_PIXEL_HEIGHT = 8;

        private const double MIN_ASPECT_RATIO = 0.25;
        private const double MAX_ASPECT_RATIO = 1.0;

        private const int MIN_PIXEL_AREA = 80;

        // Константи для порівняння двох символів
        private const double MIN_DIAG_SIZE_MULTIPLE_AWAY = 0.3;
        private const double MAX_DIAG_SIZE_MULTIPLE_AWAY = 5.0;

        private const double MAX_CHANGE_IN_AREA   = 0.5;
        private const double MAX_CHANGE_IN_WIDTH  = 0.8;
        private const double MAX_CHANGE_IN_HEIGHT = 0.2;

        private const double MAX_ANGLE_BETWEEN_CHARS = 12.0;

        // Допоміжні константи
        private const int MIN_NUMBER_OF_MATCHING_CHARS = 3;

        private const int RESIZED_CHAR_IMAGE_WIDTH  = 20;
        private const int RESIZED_CHAR_IMAGE_HEIGHT = 30;

        private const int MIN_CONTOUR_AREA = 100;

        // Глобальні змінні
        public static KNearest kNearest = new KNearest();

        public static bool LoadKNNDataAndTrainKNN()
        {
            /*
                Примітка. Необхідно двічі прочитати перший XML-файл.
                По-перше, читання файлу, щоб отримати кількість рядків (що відповідає кількості зразків).
                При першому читанні файлу не можна отримати дані, оскільки немає інформації про кількість рядків даних.
                Далі, робота з класифікацією Matrix та навчання - матриці з правильною кількістю рядків.
                Потім знову читання файлу, читання даних у змінену класифікацію 
                Матриця та навчальна матрицю зображень
             */

            // Змінна для читання цифр класифікації в неї як у вектор
            // Оголошення матриці - 1 рядок на 1 стовпець
            // Буде змінено розмір, коли стане відома кількість рядків 
            // (тобто кількість навчальних зразків)
            Matrix<Single> classificationsMatrix = new Matrix<Single>(1, 1);
            Matrix<Single> trainingImagesMatrix  = new Matrix<Single>(1, 1);

            // Змінні для читання XML файлів 
            XmlSerializer xmlSerializer = new XmlSerializer(classificationsMatrix.GetType());
            StreamReader streamReader;

            try
            {
                // Спроба відкрити файл класифікацій
                streamReader = new StreamReader(UserStoriesGeneralConstants.kClassificationsXMLFile);
            }
            catch (Exception e)
            {
                // Якщо файл не був відкритий успішно - показати повідомлення про помилку
                MessageBox.Show(UserStoriesGeneralConstants.kErrorOpenTrainingClassificationsFileMessage + "\n" +
                                UserStoriesGeneralConstants.kError + ": " + e.Message + "\n\n",
                                UserStoriesGeneralConstants.kError, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);

                return false;
            }

            // Зчитування з файлу класифікацій для отримання кількості рядків, а не фактичних даних
            classificationsMatrix = (Matrix<Single>) xmlSerializer.Deserialize(streamReader);

            // Закрити файл XML класифікацій 
            streamReader.Close();         

            // Отримати кількість рядків, тобто кількість навчальних зразків
            int intNumberOfTrainingSamples = classificationsMatrix.Rows;

            // Ініціалізація матриці класифікацій та матриці навчальних зображень
            // фактичною кількістю рядків
            classificationsMatrix = new Matrix<Single>(intNumberOfTrainingSamples, 1);
            trainingImagesMatrix  = new Matrix<Single>(intNumberOfTrainingSamples, 
                                                       RESIZED_CHAR_IMAGE_WIDTH * RESIZED_CHAR_IMAGE_HEIGHT);

            try
            {
                // Повторна ініціалізація streamReader
                streamReader = new StreamReader(UserStoriesGeneralConstants.kClassificationsXMLFile);                   
            }
            catch (Exception e)
            {
                // Якщо виникає помилка - показати повідомлення про помилку
                MessageBox.Show(UserStoriesGeneralConstants.kErrorOpenTrainingClassificationsFileMessage + "\n" +
                                UserStoriesGeneralConstants.kError + ": " + e.Message + "\n\n",
                                UserStoriesGeneralConstants.kError,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return false;
            }

            // Зчитування з файлу класифікацій, отримання фактичних даних
            classificationsMatrix = (Matrix<Single>) xmlSerializer.Deserialize(streamReader);

            // Закрити файл XML класифікацій
            streamReader.Close();         

            // Змінити змінну файлу читання
            xmlSerializer = new XmlSerializer(trainingImagesMatrix.GetType());           

            try
            {
                // Спроба відкрити файл класифікацій
                streamReader = new StreamReader(UserStoriesGeneralConstants.kImagesClassificationsXMLFile);                              
            }
            catch (Exception e)
            {                                                       
                // Якщо виникає помилка - показати повідомлення про помилку
                MessageBox.Show(UserStoriesGeneralConstants.kErrorOpenImagesClassificationsFileMessage + "\n" +
                                UserStoriesGeneralConstants.kError + ": " + e.Message + "\n\n",
                                UserStoriesGeneralConstants.kError,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return false;
            }

            // Зчитування з навчального файлу зображень
            trainingImagesMatrix = (Matrix<Single>) xmlSerializer.Deserialize(streamReader);

            // Закрити XML файли навчальних зображень
            streamReader.Close();

            // Значення за замовчуванням для сусідів по методу прогнозування
            kNearest.DefaultK = 1;

            // Навчання статистичної моделі 
            kNearest.Train(trainingImagesMatrix, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, classificationsMatrix);

            // Якщо навчання було успішним, повертаємо значення 'true'
            return true;
        }

        public static List<PossiblePlate> DetectCharsInPlates(ref List<PossiblePlate> vectorOfPossiblePlates)
        {
            Mat imgContours = new Mat();

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            Random rnd = new Random();

            // Якщо вектор можливих пластин порожній
            if (vectorOfPossiblePlates.Count == 0)
            {
                // Повернути порожній вектор можливих пластин
                return (vectorOfPossiblePlates);
            }

            // На цьому моменті вектор можливих пластин має щонайменше один номерний знак

            // Для кожного можливого номерного знаку
            foreach (var possiblePlate in vectorOfPossiblePlates)
            {
                // Попередня обробка для отримання чорно-білого і порогового(бінарного) зображень
                Preprocess.DoPreprocess(possiblePlate.plateImage, ref possiblePlate.grayscaleImage, ref possiblePlate.threshImage);

                if (DetectPlates.currentProgramMode == ProgramMode.ImageRecognitionAnalysisMode)
                {
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateImageFilePath,          possiblePlate.plateImage);
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateGrayscaleImageFilePath, possiblePlate.grayscaleImage);
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateThreshImageFilePath,    possiblePlate.threshImage);
                }

                // Збільшити розмір на 60% для більш зручного перегляду і розпізнавання символів
                CvInvoke.Resize(possiblePlate.threshImage, possiblePlate.threshImage, new Size(), 1.6, 1.6);

                // Повторне отримання бінарного зображення, для видалення шуму, 
                // тобто фільтрації пікселів з занадто малими або занадто великими значеннями.
                // Усунення будь-яких сірих зон
                CvInvoke.Threshold(possiblePlate.threshImage, 
                                   possiblePlate.threshImage, 
                                   0.0, 
                                   255.0, 
                                   ThresholdType.Binary | ThresholdType.Otsu);

                if (DetectPlates.currentProgramMode == ProgramMode.ImageRecognitionAnalysisMode)
                {
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateDoubleThreshImageFilePath, possiblePlate.threshImage);
                }

                // Знайти всі можливі символи на номерному знаку.
                // Функція спочатку знаходить всі контури, 
                // які можуть бути символами (без порівняння з іншими)
                List<PossibleChar> vectorOfPossibleCharsInPlate = 
                          FindPossibleCharsInPlate(ref possiblePlate.grayscaleImage, ref possiblePlate.threshImage);

                imgContours = new Mat(possiblePlate.threshImage.Size, DepthType.Cv8U, 3);

                imgContours.SetTo(SCALAR_BLACK_COLOR);

                contours.Clear();

                foreach (var possibleChar in vectorOfPossibleCharsInPlate)
                {
                    contours.Push(possibleChar.contour);
                }

                CvInvoke.DrawContours(imgContours, contours, -1, SCALAR_WHITE_COLOR);

                if (DetectPlates.currentProgramMode == ProgramMode.ImageRecognitionAnalysisMode)
                {
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlatePossibleCharsImageFilePath, imgContours);
                }

                // Враховуючи вектор всіх можливих символів,
                // знайти групи однакових символів всередині номерного знаку
                List<List<PossibleChar>> vectorOfVectorsOfMatchingCharsInPlate = 
                            FindVectorOfVectorsOfMatchingChars(ref vectorOfPossibleCharsInPlate);

                imgContours = new Mat(possiblePlate.threshImage.Size, DepthType.Cv8U, 3);

                imgContours.SetTo(SCALAR_BLACK_COLOR);

                contours.Clear();

                foreach (List<PossibleChar> vectorOfMatchingChars in vectorOfVectorsOfMatchingCharsInPlate)
                {
                    int intRandomBlue  = rnd.Next(0, 256);
                    int intRandomGreen = rnd.Next(0, 256);
                    int intRandomRed   = rnd.Next(0, 256);

                    foreach (PossibleChar matchingChar in vectorOfMatchingChars)
                    {
                        contours.Push(matchingChar.contour);
                    }

                    try
                    {
                        CvInvoke.DrawContours(imgContours, contours, -1, new MCvScalar(intRandomBlue,
                                                                                       intRandomGreen,
                                                                                       intRandomRed));
                    }
                    catch (Emgu.CV.Util.CvException) {}
                }

                if (DetectPlates.currentProgramMode == ProgramMode.ImageRecognitionAnalysisMode)
                {
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateMatchingCharsImageFilePath, imgContours);
                }

                // Якщо не було знайдено жодної групи співпадаючих символів на номерному знаку
                if (vectorOfVectorsOfMatchingCharsInPlate.Count == 0)
                {
                    // Набір змінних номерного знаку порожнього рядка
                    possiblePlate.licensePlateChars = "";

                    // повернутися на початок циклу
                    continue;
                }

                List<PossibleChar> vectorOfMatchingCharsResult;

                List<List<PossibleChar>> vectorOfVectorsOfMatchingCharsInPlateResult = new List<List<PossibleChar>>();

                List<PossibleChar> vectorOfMatchingCharsTemp = new List<PossibleChar>();

                // Для кожного вектора співпадачих символів в поточному номерному знаці
                foreach (var vectorOfMatchingChars in vectorOfVectorsOfMatchingCharsInPlate)
                {
                    // Відсортувати символи зліва направо
                    vectorOfMatchingChars.Sort((x, y) => x.boundingRect.X.CompareTo(y.boundingRect.X));

                    vectorOfMatchingCharsTemp = vectorOfMatchingChars;

                    vectorOfMatchingCharsResult = RemoveInnerOverlappingChars(ref vectorOfMatchingCharsTemp);

                    vectorOfVectorsOfMatchingCharsInPlateResult.Add(vectorOfMatchingCharsResult);
                }
                
                vectorOfVectorsOfMatchingCharsInPlate = vectorOfVectorsOfMatchingCharsInPlateResult;

                imgContours = new Mat(possiblePlate.threshImage.Size, DepthType.Cv8U, 3);

                imgContours.SetTo(SCALAR_BLACK_COLOR);

                foreach (var vectorOfMatchingChars in vectorOfVectorsOfMatchingCharsInPlate)
                {
                    int intRandomBlue  = rnd.Next(0, 256);
                    int intRandomGreen = rnd.Next(0, 256);
                    int intRandomRed   = rnd.Next(0, 256);

                    contours.Clear();

                    foreach (var matchingChar in vectorOfMatchingChars)
                    {
                        contours.Push(matchingChar.contour);
                    }

                    try
                    {
                        CvInvoke.DrawContours(imgContours, contours, -1, new MCvScalar(intRandomBlue,
                                                                                       intRandomGreen,
                                                                                       intRandomRed));
                    }
                    catch (Emgu.CV.Util.CvException) { }
                }

                if (DetectPlates.currentProgramMode == ProgramMode.ImageRecognitionAnalysisMode)
                {
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateRemovedOverlappingImageFilePath, imgContours);
                }

                uint intLenOfLongestVectorOfChars   = 0;
                uint intIndexOfLongestVectorOfChars = 0;

                // Перебрати всі вектори співпадаючих символів.
                // Отримати індекс одного, з найбільшою кількістю символів
                for (var i = 0; i < vectorOfVectorsOfMatchingCharsInPlate.Count; i++)
                {
                    if (vectorOfVectorsOfMatchingCharsInPlate[i].Count > intLenOfLongestVectorOfChars)
                    {
                        intLenOfLongestVectorOfChars = (uint)vectorOfVectorsOfMatchingCharsInPlate[i].Count;

                        intIndexOfLongestVectorOfChars = (uint)i;
                    }
                }

                // Припущення, що найдовший вектор співпадаючих символів 
                // номерного знаку є фактичним вектором символів
                List<PossibleChar> longestVectorOfMatchingCharsInPlate = 
                    vectorOfVectorsOfMatchingCharsInPlate[(int)intIndexOfLongestVectorOfChars];

                imgContours = new Mat(possiblePlate.threshImage.Size, DepthType.Cv8U, 3);

                imgContours.SetTo(SCALAR_BLACK_COLOR);

                contours.Clear();

                foreach (var matchingChar in longestVectorOfMatchingCharsInPlate)
                {
                    contours.Push(matchingChar.contour);
                }

                try
                {
                    CvInvoke.DrawContours(imgContours, contours, -1, SCALAR_WHITE_COLOR);
                }
                catch (Emgu.CV.Util.CvException) { }

                if (DetectPlates.currentProgramMode == ProgramMode.ImageRecognitionAnalysisMode)
                {
                    CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateLongestMatchCharsVectorFilePath, imgContours);
                }

                // Виконати розпізнавання символу на найдовшому векторі співпадаючих символів на пластині
                possiblePlate.licensePlateChars = 
                    RecognizeCharsInPlate(ref possiblePlate.threshImage, ref longestVectorOfMatchingCharsInPlate);
            } // кінець циклу для кожного можливого знаку

            return (vectorOfPossiblePlates);
        }

        private static List<PossibleChar> FindPossibleCharsInPlate(ref Mat imgGrayscale, ref Mat imgThresh)
        {
            // Список можливих пластин номерного знаку для повернення значення з методу
            List<PossibleChar> vectorOfPossibleChars = new List<PossibleChar>();

            Mat imgThreshCopy = new Mat();

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            // Зробити копію змінюємого зображення.
            // Необхідно, щоб знайти контури змінюємого зображення
            imgThreshCopy = imgThresh.Clone();

            // Знайти всі контури на номерному знаці 
            CvInvoke.FindContours(imgThreshCopy, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            // Для кожного контуру
            for (var i = 0; i < contours.Size; i++)
            {
                PossibleChar possibleChar = new PossibleChar(contours[i]);

                // Якщо є контуром можливих символів (не порівняння з іншими символами)
                if (CheckIfPossibleChar(possibleChar))
                {
                    // Додати в вектор можливих символів
                    vectorOfPossibleChars.Add(possibleChar);
                }
            }

            return (vectorOfPossibleChars);
        }

        public static bool CheckIfPossibleChar(PossibleChar possibleChar)
        {
            // Функція є "першим проходом", який робить грубу перевірку
            // по контуру, щоб побачити, якщо це може бути символ,
            // (не порівняння символу з іншими шуканими групами)
            if (possibleChar.rectArea > MIN_PIXEL_AREA && 
                possibleChar.boundingRect.Width > MIN_PIXEL_WIDTH               && 
                possibleChar.boundingRect.Height > MIN_PIXEL_HEIGHT             && 
                MIN_ASPECT_RATIO < possibleChar.aspectRatio                     && 
                possibleChar.aspectRatio < MAX_ASPECT_RATIO)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        // Мета функції - організувати один великий вектор символів в вектор векторів співпадаючих символів.
        // Символи, які не зустрічаються в групі не потрібно розглядати додатково
        public static List<List<PossibleChar>> FindVectorOfVectorsOfMatchingChars(ref List<PossibleChar> vectorOfPossibleChars)
        {
            // Вектор векторів співпадаючих символів для повернення значення з методу
            List<List<PossibleChar>> vectorOfVectorsOfMatchingChars = new List<List<PossibleChar>>();

            PossibleChar possibleCharTemp;

            // Для кожного можливого символу в векторі можливих символів
            foreach (var possibleChar in vectorOfPossibleChars)
            {
                possibleCharTemp = possibleChar;

                // Знайти вектор співпадаючих символів згідно поточного символу
                List<PossibleChar> vectorOfMatchingChars = 
                        FindVectorOfMatchingChars(ref possibleCharTemp, ref vectorOfPossibleChars);

                // Додати поточний символ для поточного можливого вектора символів, що збігаються
                vectorOfMatchingChars.Add(possibleCharTemp);

                // Якщо поточний можливий вектор співпадаючих символів 
                // не досить довгий, щоб скласти можливий номерний знак
                if (vectorOfMatchingChars.Count < MIN_NUMBER_OF_MATCHING_CHARS)
                {
                    // Перехід назад до верхньої частини циклу і спробувати ще раз
                    continue;
                }

                // Якщо було отримано поточний вектор, що пройшов тест 
                // як "група" або "кластер" співпадаючих символів

                // Додати до вектору векторів співпадаючих символів
                vectorOfVectorsOfMatchingChars.Add(vectorOfMatchingChars);

                // Видалити поточний вектор співпадаючих символів з великого вектора, 
                // не використовуються ті ж символи два рази
                List<PossibleChar> vectorOfPossibleCharsWithCurrentMatchesRemoved = 
                    vectorOfPossibleChars.Except(vectorOfMatchingChars).ToList();

                foreach (var possChar in vectorOfPossibleChars)
                {
                    if (vectorOfMatchingChars.Find(e => e == possChar) == vectorOfMatchingChars.Last())
                    {
                        vectorOfPossibleCharsWithCurrentMatchesRemoved.Add(possChar);
                    }
                }

                // Оголосити новий вектор векторів символів, 
                // щоб отримати в результаті рекурсивний виклик
                List<List<PossibleChar>> recursiveVectorOfVectorsOfMatchingChars = new List<List<PossibleChar>>();

                // Рекурсивний виклик
                recursiveVectorOfVectorsOfMatchingChars = 
                    new List<List<PossibleChar>>(FindVectorOfVectorsOfMatchingChars(ref vectorOfPossibleCharsWithCurrentMatchesRemoved));

                // Для кожного вектора збігаються символи знайденого рекурсивного виклику
                foreach (var recursiveVectorOfMatchingChars in recursiveVectorOfVectorsOfMatchingChars)
                {
                    // Додати до вихідного вектору векторів співпадаючих символів
                    vectorOfVectorsOfMatchingChars.Add(recursiveVectorOfMatchingChars);
                }

                // Вихід з циклу
                break;
            }

            return (vectorOfVectorsOfMatchingChars);
        }

        // Мета функції - враховувати можливий символ і великий вектор можливих символів.
        // Знайти всі символи в великому векторі, які відповідають хоча б одному 
        // можливого символу, і повернути ті співпадаючі символи в якості вектора
        private static List<PossibleChar> FindVectorOfMatchingChars(ref PossibleChar possibleChar, 
                                                                    ref List<PossibleChar> vectorOfChars)
        {
            // Список можливих символів для повернення значення з методу
            List<PossibleChar> vectorOfMatchingChars = new List<PossibleChar>();
            
            PossibleChar possibleMatchingCharTemp;

            // Для кожного символу в великому векторі
            foreach (var possibleMatchingChar in vectorOfChars)
            {
                // Якщо символ, то знаходимо відповідності для точно також символу, 
                // як символ у великому векторі при поточній перевірці
                if  (possibleMatchingChar.Equals(possibleChar))
                {
                    // Не треба включати його в вектор відповідностей, 
                    // що б в кінцевому підсумку включити подвійний символ
                    // так що не додавати до вектору відповідностей і перейти назад на початок циклу
                    continue;
                }

                possibleMatchingCharTemp = possibleMatchingChar;

                double dblDistanceBetweenChars = DistanceBetweenChars(ref possibleChar, ref possibleMatchingCharTemp);
                double dblAngleBetweenChars    = AngleBetweenChars(ref possibleChar, ref possibleMatchingCharTemp);

                double dblChangeInArea   = Math.Abs(possibleMatchingChar.rectArea - possibleChar.rectArea) / 
                                                    (double)possibleChar.rectArea;

                double dblChangeInWidth  = Math.Abs(possibleMatchingChar.boundingRect.Width - possibleChar.boundingRect.Width)   / 
                                                   (double)possibleChar.boundingRect.Width;

                double dblChangeInHeight = Math.Abs(possibleMatchingChar.boundingRect.Height - possibleChar.boundingRect.Height) / 
                                                   (double)possibleChar.boundingRect.Height;

                // Перевірити, чи співпадають символи
                if (dblDistanceBetweenChars < (possibleChar.diagonalSize * MAX_DIAG_SIZE_MULTIPLE_AWAY) && 
                    dblAngleBetweenChars    < MAX_ANGLE_BETWEEN_CHARS                                      && 
                    dblChangeInArea         < MAX_CHANGE_IN_AREA                                           && 
                    dblChangeInWidth        < MAX_CHANGE_IN_WIDTH                                          && 
                    dblChangeInHeight       < MAX_CHANGE_IN_HEIGHT)
                {
                    // Якщо символи збігаються, то додати поточний символ у вектор співпадаючих символів
                    vectorOfMatchingChars.Add(possibleMatchingChar);
                }
            }

            // Повернення результату
            return (vectorOfMatchingChars);
        }


        // Використання теореми Піфагора для обчислення відстані між двома символами
        public static double DistanceBetweenChars(ref PossibleChar firstChar, ref PossibleChar secondChar)
        {
            int intX = Math.Abs(firstChar.pointOfCenterX - secondChar.pointOfCenterX);
            int intY = Math.Abs(firstChar.pointOfCenterY - secondChar.pointOfCenterY);

            return (Math.Sqrt(Math.Pow(intX, 2) + Math.Pow(intY, 2)));
        }

        // Використання основних тригонометричних властивостей для обчислення кута між символами
        private static double AngleBetweenChars(ref PossibleChar firstChar, ref PossibleChar secondChar)
        {
            double dblAdj = Math.Abs(firstChar.pointOfCenterX - secondChar.pointOfCenterX);
            double dblOpp = Math.Abs(firstChar.pointOfCenterY - secondChar.pointOfCenterY);

            double dblAngleInRad = Math.Atan(dblOpp / dblAdj);

            double dblAngleInDeg = dblAngleInRad * (180.0 / Math.PI);

            return (dblAngleInDeg);
        }

        // Якщо є два символи перекриття або близькі один до одного, 
        // щоб, можливо, бути окремими символи, знімається внутрішій (менший) символ,
        // щоб запобігти в тому числі повторення символу. 
        // Якщо два контури зустрічаються для того ж символу,
        // наприклад, для літери 'O' як внутрішнього кільця і зовнішнього 
        // кільця можуть бути знайдені як контури, необхідно включати символ тільки один раз
        private static List<PossibleChar> RemoveInnerOverlappingChars(ref List<PossibleChar> vectorOfMatchingChars)
        {
            List<PossibleChar> vectorOfMatchingCharsWithInnerCharRemoved = new List<PossibleChar>(vectorOfMatchingChars);
            
            PossibleChar currentCharTemp;
            PossibleChar otherCharTemp;

            foreach (var currentChar in vectorOfMatchingChars)
            {
                foreach (var otherChar in vectorOfMatchingChars)
                {
                    // Якщо поточний символ і інший символ не збігаються.
                    // Якщо поточний символ і інший символ мають центральні точки майже у тому ж місці
                    if (!currentChar.Equals(otherChar))
                    {
                        currentCharTemp = currentChar;
                        otherCharTemp   = otherChar;

                        if (DistanceBetweenChars(ref currentCharTemp, ref otherCharTemp) < 
                           (currentChar.diagonalSize * MIN_DIAG_SIZE_MULTIPLE_AWAY))
                        {
                            // Якщо перекривання символів.
                            // Визначити який символ менше. 
                            // Якщо цей символ ще не видалений на попередньому проході - видалити його

                            // Якщо поточний символ менше, ніж інший символ
                            if (currentChar.rectArea < otherChar.rectArea)
                            {
                                if  (vectorOfMatchingCharsWithInnerCharRemoved.Contains(currentChar))
                                {
                                        // Видалити символ
                                        vectorOfMatchingCharsWithInnerCharRemoved.Remove(currentChar);
                                }
                            }
                            // інакше, якщо інший символ менше поточного символу
                            // шукає символ в векторі з ітератором
                            else
                            { 
                                // якщо ітератор не добрався до кінця, то символ був знайдений в векторі
                                if (vectorOfMatchingCharsWithInnerCharRemoved.Contains(otherChar))
                                {
                                    // Видалити символ
                                    vectorOfMatchingCharsWithInnerCharRemoved.Remove(otherChar);
                                }
                            }
                        }
                    }
                }
            }

            return (vectorOfMatchingCharsWithInnerCharRemoved);
        }

        // Розпізнавання фактично самих символів
        private static string RecognizeCharsInPlate(ref Mat imgThresh, ref List<PossibleChar> vectorOfMatchingChars)
        {
            // строкова змінна для повернення значення символів в номерному знаку
            string strChars = "";

            Mat imgThreshColor = new Mat();

            // Сортування по символам зліва направо
            vectorOfMatchingChars.Sort((x, y) => x.boundingRect.X.CompareTo(y.boundingRect.X));

            // Зробити кольорову версію порогового(бінарного) зображення, 
            // таким чином можна намалювати контури в кольорі на ньому
            CvInvoke.CvtColor(imgThresh, imgThreshColor, ColorConversion.Gray2Bgr);

            // Для кожного символу на пластині
            foreach (var currentChar in vectorOfMatchingChars)
            {
                // Намалювати зелену рамку навколо символу
                CvInvoke.Rectangle(imgThreshColor, currentChar.boundingRect, SCALAR_GREEN_COLOR, 2);

                // Отримати ROI(регіон інтересів) зображення з обмежуючим прямокутником
                Mat imgROItoBeCloned = new Mat(imgThresh, currentChar.boundingRect);

                // Клон ROI зображення, без зміни оригінального, при зміні розміру
                Mat imgROI = imgROItoBeCloned.Clone();

                Mat imgROIResized = new Mat();

                // Змінити розмір зображення, необхідно для розпізнавання символу
                CvInvoke.Resize(imgROI, imgROIResized, new Size(RESIZED_CHAR_IMAGE_WIDTH, RESIZED_CHAR_IMAGE_HEIGHT));

                // Оголосити Матрицю тих же розмірів, що і зображення, 
                // яке додається до структури даних навчальних зображень
                Matrix<Single> mtxTemp = new Matrix<Single>(imgROIResized.Size);

                // Оголосити сплощену (лише 1 рядок) матрицю 
                // з таким же загальним розміром
                Matrix<Single> mtxTempReshaped = new Matrix<Single>(1, RESIZED_CHAR_IMAGE_WIDTH * RESIZED_CHAR_IMAGE_HEIGHT);

                // Перетворити зображення в матрицю одиночних знаків з однаковими розмірами
                imgROIResized.ConvertTo(mtxTemp, DepthType.Cv32F);

                for (int intRow = 0; intRow <= RESIZED_CHAR_IMAGE_HEIGHT - 1; ++intRow)
                {
                    // Вирівняти матрицю в один рядок за RESIZED_IMAGE_WIDTH * RESIZED_IMAGE_HEIGHT кількість стовпців
                    for (int intCol = 0; intCol <= RESIZED_CHAR_IMAGE_WIDTH - 1; intCol++)
                    {
                        mtxTempReshaped[0, (intRow * RESIZED_CHAR_IMAGE_WIDTH) + intCol] = mtxTemp[intRow, intCol];
                    }
                }

                Single sngCurrentChar;

                // Для знаходження найближчих сусідів.
                // Прогноз відповіді для заданих зразків
                sngCurrentChar = kNearest.Predict(mtxTempReshaped);

                // Додати поточний символ у повний рядок
                strChars = strChars + (char)(Convert.ToInt32(sngCurrentChar));
            }

            if (DetectPlates.currentProgramMode == ProgramMode.ImageRecognitionAnalysisMode)
            {
                CvInvoke.Imwrite(UserStoriesGeneralConstants.kPlateRecognizedCharsImageFilePath, imgThreshColor);
            }

            // Повернення результату
            return (strChars);
        }
    }
}
