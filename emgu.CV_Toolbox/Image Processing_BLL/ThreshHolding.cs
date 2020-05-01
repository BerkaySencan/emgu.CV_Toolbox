using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class ThreshHolding : ImgProcessing_Base
    {
        private Image<Gray, byte> GrayImage;
        private Image<Gray, byte> BinarazitonImage;

        public Image<Gray, byte> Cal_ThresHolding(Image<Bgra, byte> Img, Emgu.CV.CvEnum.ThresholdType thresholdType, double threshold = 40.0, double maxValue = 255)
        {
            Image<Gray, byte> GrayImage = Img.Convert<Gray, byte>();

            //Binarization

            BinarazitonImage = new Image<Gray, byte>(GrayImage.Width, GrayImage.Height, new Gray(0));
            CvInvoke.Threshold(GrayImage, BinarazitonImage, threshold, maxValue, thresholdType);
            return BinarazitonImage;
        }
    }
}
