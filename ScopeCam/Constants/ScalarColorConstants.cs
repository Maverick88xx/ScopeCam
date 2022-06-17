using Emgu.CV.Structure;        

namespace ScopeCam
{
    static class ScalarColorConstants
    {
        // Глобальні константи кольорів у скалярних структурах
        public static MCvScalar SCALAR_BLACK_COLOR  = new MCvScalar(0.0,   0.0,   0.0  );
        public static MCvScalar SCALAR_WHITE_COLOR  = new MCvScalar(255.0, 255.0, 255.0);
        public static MCvScalar SCALAR_YELLOW_COLOR = new MCvScalar(0.0,   255.0, 255.0);
        public static MCvScalar SCALAR_GREEN_COLOR  = new MCvScalar(0.0,   255.0, 0.0  );
        public static MCvScalar SCALAR_RED_COLOR    = new MCvScalar(0.0,   0.0,   255.0);
    }
}
