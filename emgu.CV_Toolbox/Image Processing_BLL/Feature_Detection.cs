using Emgu.CV;
using Emgu.CV.Features2D;
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
    class Feature_Detection
    {
        public Bitmap Harris_Detector(Image<Bgr,byte> img ,int Threshold=180)
        {
            try
            {
                if (img == null)
                {
               
                    return null;
                }

                var gray = img.Convert<Gray, byte>();

                var corners = new Mat();
                CvInvoke.CornerHarris(gray, corners, 2);
                CvInvoke.Normalize(corners, corners, 255, 0, Emgu.CV.CvEnum.NormType.MinMax);

                Matrix<float> matrix = new Matrix<float>(corners.Rows, corners.Cols);
                corners.CopyTo(matrix);

                for (int i = 0; i < matrix.Rows; i++)
                {
                    for (int j = 0; j < matrix.Cols; j++)
                    {
                        if (matrix[i, j] > Threshold)
                        {
                            CvInvoke.Circle(img, new Point(j, i), 5, new MCvScalar(0, 0, 255), 3);
                        }
                    }
                }

               return img.AsBitmap();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
        public Bitmap Shi_Thomasi_Detector(Image<Bgr, byte> img)
        {
            try
            {
                if (img == null)
                {
                    return null;
                }

               
                var gray = img.Convert<Gray, byte>();

                GFTTDetector detector = new GFTTDetector(2000, 0.06);
                var corners = detector.Detect(gray);

                Mat outimg = new Mat();
                Features2DToolbox.DrawKeypoints(img, new VectorOfKeyPoint(corners), outimg, new Bgr(0, 0, 255));

                return outimg.ToBitmap();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
        public Bitmap Fast_Detector(Image<Bgr, byte> img, int Threshold= 180)
        {
            try
            {
                if (img == null)
                {
                    return null;
                }

                
                var gray = img.Convert<Gray, byte>();

                FastFeatureDetector detector = new FastFeatureDetector(Threshold);
                var corners = detector.Detect(gray);

                Mat outimg = new Mat();
                Features2DToolbox.DrawKeypoints(img, new VectorOfKeyPoint(corners), outimg, new Bgr(0, 0, 255));

                return outimg.ToBitmap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public Bitmap ORB_Detector(Image<Bgr, byte> img)
        {
            try
            {
                if (img == null)
                {
                    return null;
                }

                
                var gray = img.Convert<Gray, byte>();

                ORBDetector detector = new ORBDetector();
                var corners = detector.Detect(gray);

                Mat outimg = new Mat();
                Features2DToolbox.DrawKeypoints(img, new VectorOfKeyPoint(corners), outimg, new Bgr(0, 0, 255));

                return outimg.ToBitmap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public Bitmap MSER_Detector(Image<Bgr, byte> img)
        {
            try
            {
                if (img == null)
                {
                    return null;
                }


                var gray = img.Convert<Gray, byte>();

                MSERDetector detector = new MSERDetector();
                var corners = detector.Detect(gray);

                Mat outimg = new Mat();
                Features2DToolbox.DrawKeypoints(img, new VectorOfKeyPoint(corners), outimg, new Bgr(0, 0, 255));

                return outimg.ToBitmap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


    }
}
