using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Edge_Detection
    {
        public Image<Gray, byte> Canny_Detector(Image<Bgra, byte> img,double thresh=40.0,double threshLinking=10.0)
        {
            Image<Gray, byte> _imgCanny = new Image<Gray, byte>(img.Width, img.Height, new Gray(0));
            return img.Canny(thresh, threshLinking);
        }
        public Image<Gray, float> Sobel_Detector(Image<Bgra, byte> img)
        {
            Image<Gray, byte> GrayImage = img.Convert<Gray, byte>();
            Image<Gray, float> SobelImage = new Image<Gray, float>(img.Width, img.Height, new Gray(0));

            SobelImage = GrayImage.Sobel(1, 1, 3);
            return SobelImage;
        }
        public Image<Gray, float> Laplacian_Detector(Image<Bgra, byte> img)
        {

            Image<Gray, byte> GrayImage = img.Convert<Gray, byte>();
            Image<Gray, float> LaplacianImage = new Image<Gray, float>(img.Width, img.Height, new Gray(0));

            LaplacianImage = GrayImage.Laplace(7);
            return LaplacianImage;

        }
    }
}
