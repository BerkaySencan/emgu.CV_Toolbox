using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Contour_Extraction
    {
        
        
        public Image<Gray,byte> findContours_Gray(Image<Bgr,byte> imgInput, Emgu.CV.CvEnum.RetrType retrType, Emgu.CV.CvEnum.ChainApproxMethod chainApproxMethod)
        {
           
            Image<Gray, byte> imgOutput = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Mat hier = new Mat();

            Image<Gray, byte> imgContoursOutput = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray(0));

            CvInvoke.FindContours(imgOutput, contours, hier, retrType, chainApproxMethod);
            CvInvoke.DrawContours(imgContoursOutput, contours, -1, new MCvScalar(255, 0, 0));

            return imgContoursOutput;
        }

        public Image<Bgr, byte> findContours_Bgr(Image<Bgr, byte> imgInput, Emgu.CV.CvEnum.RetrType retrType, Emgu.CV.CvEnum.ChainApproxMethod chainApproxMethod)
        {

            Image<Gray, byte> imgOutput = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Mat hier = new Mat();

            CvInvoke.FindContours(imgOutput, contours, hier, retrType, chainApproxMethod);
            CvInvoke.DrawContours(imgInput, contours, -1, new MCvScalar(255, 0, 0));

            return imgInput;
        }
    }
}
