using System;

namespace ScopeCam
{
    static class UserStoriesGeneralConstants
    {
        public const String kCarsDirectory                               = "cars/";
        public const String kError                                       = "Помилка";
        public const String kInformation                                 = "Інформація";
        public const String kMainDateFormat                              = "dd.MM.yyyy";
        public const String kImagesClassificationsXMLFile                = "images.xml";
        public const String kClassificationsXMLFile                      = "classifications.xml";
        public const String kChooseImageMessage                          = "Виберіть зображення: ";
        public const String kImageNotFoundMessage                        = "Зображення не було знайдено!";
        public const String kNotSuccessKNNTrainingMessage                = "KNN навчання не було успішним!";
        public const String kLicensePlateNotRecognizedMessage            = "Автомобільних номерів не виявлено!";
        public const String kFoundPossiblePlatesMessage                  = "Знайдено можливих пластин номерних знаків: ";
        public const String kErrorOpenImagesClassificationsFileMessage   = "Не вдалося відкрити файл навчальних образів!";
        public const String kCharsOnLicensePlateNotRecognizedMessage     = "Символів на автомобільних номерах не виявлено!";
        public const String kErrorOpenTrainingClassificationsFileMessage = "Не вдалося відкрити файл навчальних класифікацій!";


        public const String kOriginalSceneImageFilePath            = "plate_steps/0.png";
        public const String kGrayscaleSceneImageFilePath           = "plate_steps/1a.png";
        public const String kThreshSceneImageFilePath              = "plate_steps/1b.png";
        public const String kDoubleThreshSceneImageFilePath        = "plate_steps/2a.png";
        public const String kPossibleCharsInSceneImageFilePath     = "plate_steps/2b.png";
        public const String kVectorOfMatchingCharsInSceneFilePath  = "plate_steps/3.png";
        public const String kVectorOfPossiblePlatesInSceneFilePath = "plate_steps/4.png";
        public const String kPlateImageFilePath                    = "plate_steps/5a.png";
        public const String kPlateGrayscaleImageFilePath           = "plate_steps/5b.png";
        public const String kPlateThreshImageFilePath              = "plate_steps/5c.png";
        public const String kPlateDoubleThreshImageFilePath        = "plate_steps/5d.png";
        public const String kPlatePossibleCharsImageFilePath       = "plate_steps/6.png";
        public const String kPlateMatchingCharsImageFilePath       = "plate_steps/7.png";
        public const String kPlateRemovedOverlappingImageFilePath  = "plate_steps/8.png";
        public const String kPlateLongestMatchCharsVectorFilePath  = "plate_steps/9.png";
        public const String kPlateRecognizedCharsImageFilePath     = "plate_steps/10.png";

        public const String kLiftingBarrierStubGifFilePath = "image_program/lifting_barrier_(gif).gif";
    }
}
