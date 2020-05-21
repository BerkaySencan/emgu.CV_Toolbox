using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Image_General
    {
        public Image<Bgr, byte> PyrUp(Image<Bgr,byte> img)
        {         
            var imgout = img.PyrUp();
            return imgout;
           
        }
        public Image<Bgr, byte> PyrDown(Image<Bgr, byte> img)
        {
            var imgout = img.PyrDown();
            return imgout;

        }
        public Image<Bgr, byte> GaussianBlur(Image<Bgr, byte> img, int kernelSize)
        {
            var imgout = img.SmoothGaussian(kernelSize);
            return imgout;

        }

        public Image<Bgr, byte> GaussianNoise(Image<Bgr, byte> img)
        {
           
            Bgr avg = new Bgr();
            MCvScalar std = new MCvScalar();

            img.AvgSdv(out avg, out std);

            var output = img.CopyBlank();
            CvInvoke.Randn(output, avg.MCvScalar, std);

            var Image = img.AddWeighted(output, .6, .4, 0);
            return Image;

        }


        public Bitmap HitOrMiss(Image<Bgr, byte> img)
        {
            var imgTH =img
                    .Convert<Gray, byte>()
                    .ThresholdBinary(new Gray(100), new Gray(255));

        
            int[,] data = {
                    { 0, -1, -1 },
                    { 1, 1, -1 },
                    { 0, 1, 0 } };
            Matrix<int> SE = new Matrix<int>(data);

            Mat imgout = new Mat();
            CvInvoke.MorphologyEx(img, imgout, Emgu.CV.CvEnum.MorphOp.HitMiss, SE, new Point(0, 2), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0));
            return imgout.ToBitmap();

        }
       
    }
}
