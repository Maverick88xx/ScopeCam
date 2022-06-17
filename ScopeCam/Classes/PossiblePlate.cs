using Emgu.CV;
using Emgu.CV.Structure;

namespace ScopeCam
{
    class PossiblePlate
    {
        // Змінні
        public Mat plateImage     = new Mat();
        public Mat grayscaleImage = new Mat();
        public Mat threshImage    = new Mat();

        public RotatedRect locationOfPlateInSceneRR = new RotatedRect();

        public string licensePlateChars = "";
    }
}
