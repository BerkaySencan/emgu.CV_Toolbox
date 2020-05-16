using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Edge_Detection
    {
        public Bitmap Canny_Detector(Image<Bgra, byte> img,double thresh=40.0,double threshLinking=10.0)
        {
            Image<Gray, byte> _imgCanny = new Image<Gray, byte>(img.Width, img.Height, new Gray(0));

            return img.Canny(thresh, threshLinking).AsBitmap<Gray,byte>();
        }
        public Image<Gray, float> Sobel_Detector(Image<Gray, byte> img)
        {
            //Image<Gray, byte> GrayImage = img.Convert<Gray, byte>();
           // Image<Gray, float> SobelImage = new Image<Gray, float>(img.Width, img.Height, new Gray(0));
            Image<Gray, float> sobel = img.Sobel(0, 1, 3).Add(img.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));
          //  SobelImage = img.Sobel(1, 1, 3);
            return sobel;
        }
        public Image<Gray, float> Laplacian_Detector(Image<Bgra, byte> img)
        {

            Image<Gray, byte> GrayImage = img.Convert<Gray, byte>();
            Image<Gray, float> LaplacianImage = new Image<Gray, float>(img.Width, img.Height, new Gray(0));

            LaplacianImage = GrayImage.Laplace(7);
            return LaplacianImage;

        }

        public Bitmap Convex_Hull(Image<Bgr,byte> img)
        {
            try
            {
                if (img == null)
                {
                    return null;
                }

                

                img = img.SmoothGaussian(3);
                var gray = img.Convert<Gray, byte>()
                    .ThresholdBinaryInv(new Gray(225), new Gray(255));
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();

                CvInvoke.FindContours(gray, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                int index = -1;
                double maxarea = -100;
                for (int i = 0; i < contours.Size; i++)
                {
                    double area = CvInvoke.ContourArea(contours[i]);
                    if (area > maxarea)
                    {
                        maxarea = area;
                        index = i;
                    }
                }

                if (index > -1)
                {
                    var biggestcontour = contours[index];
                    //Mat hull = new Mat();

                    VectorOfPoint hull = new VectorOfPoint();
                    CvInvoke.ConvexHull(biggestcontour, hull);

                    //CvInvoke.DrawContours(img, hull, -1, new MCvScalar(0, 0, 255), 3);
                    CvInvoke.Polylines(img, hull.ToArray(), true, new MCvScalar(0, 0.0, 255.0), 3);

                }
                return img.AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
