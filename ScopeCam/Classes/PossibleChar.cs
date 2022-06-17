using System;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Util;

namespace ScopeCam
{
    class PossibleChar
    {
        // Змінні
        public VectorOfPoint contour;

        public Rectangle boundingRect; 

        public int pointOfCenterX;
        public int pointOfCenterY;

        public double diagonalSize;
        public double aspectRatio;

        public int rectArea;

        public PossibleChar(VectorOfPoint _contour)
        {
            contour = _contour;

            boundingRect = CvInvoke.BoundingRectangle(contour);

            pointOfCenterX = (boundingRect.Left + boundingRect.Right)  / 2;
            pointOfCenterY = (boundingRect.Top  + boundingRect.Bottom) / 2;

            diagonalSize = Math.Sqrt(Math.Pow(boundingRect.Width,  2)   + 
                                     Math.Pow(boundingRect.Height, 2));

            aspectRatio = (float)boundingRect.Width / (float)boundingRect.Height;

            rectArea = boundingRect.Width * boundingRect.Height;
        }
    }
}