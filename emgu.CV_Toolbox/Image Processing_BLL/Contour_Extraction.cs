using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
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
       
        /*
         2 Verilen resimdeki kenarları siyah ile çizer 
         geriye threshold yapılmış resim döndürür bunuda farklı bir image boxta gostermek gerekir.
             */
        public  Image<Bgr, byte> findContours_bySize(Image<Bgr, byte> imgInput,int width,int height,double area)
        {
            Image<Gray, byte> imgout = imgInput.Convert<Gray, byte>().Not().ThresholdBinary(new Gray(50), new Gray(255));
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hier = new Mat();

            CvInvoke.FindContours(imgout, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);



            Dictionary<int, double> dict = new Dictionary<int, double>();

            if (contours.Size > 0)
            {
                for (int i = 0; i < contours.Size; i++)
                {
                    double _area = CvInvoke.ContourArea(contours[i]);
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                    if (rect.Width > width && rect.Height > height && area < 3000)
                    {
                        dict.Add(i, _area);
                    }
                }
            }



            var item = dict.OrderByDescending(v => v.Value);

            Image<Bgr, byte> imgout1 = new Image<Bgr, byte>(imgInput.Width, imgInput.Height, new Bgr(0, 0, 0));

            foreach (var it in item)
            {
                int key = int.Parse(it.Key.ToString());
                Rectangle rect = CvInvoke.BoundingRectangle(contours[key]);
                CvInvoke.DrawContours(imgInput, contours, key, new MCvScalar(0, 0, 0),1);
                CvInvoke.Rectangle(imgout1, rect, new MCvScalar(255, 255, 255), 3);
            }

            return imgout1;
        }
    }
}
