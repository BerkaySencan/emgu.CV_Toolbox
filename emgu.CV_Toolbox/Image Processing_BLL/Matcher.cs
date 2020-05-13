using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Flann;
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
    class Matcher
    {
        public  Bitmap TemplateMatcher(Image<Bgr,byte> input, Image<Bgr, byte> pcBx,Rectangle rect,Emgu.CV.CvEnum.TemplateMatchingType type)
        {
            try
            {
                if (pcBx == null)
                {
                    return null;
                }

                if (rect == null)
                {
                    MessageBox.Show("Select a template");
                    return null;
                }

                var imgScene = input;
                var template = pcBx;



                Mat imgout = new Mat();
                CvInvoke.MatchTemplate(imgScene,
                    template,
                    imgout,
                    type);

                double minVal = 0;
                double maxVal = 0;
                Point minLoc = new Point();
                Point maxLoc = new Point();

                CvInvoke.MinMaxLoc(imgout, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                Rectangle r = new Rectangle(minLoc, template.Size);
                CvInvoke.Rectangle(imgScene, r, new MCvScalar(255, 0, 0), 3);
               return imgScene.AsBitmap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Bitmap MultiScaleTemplateMatcher(Bitmap Input,Rectangle rect,Image<Bgr,byte> ListImage, Emgu.CV.CvEnum.TemplateMatchingType type)
        {
            try
            {
                if (Input == null)
                {
                    return null;
                }

                if (rect == null)
                {
                    MessageBox.Show("Select a template");
                    return null;
                }

                var imgScene = ListImage;
                var template = new Bitmap(Input)
                    .ToImage<Bgr, byte>();
                Rectangle r = Rectangle.Empty;
                double GlobalMin = float.MaxValue;

                for (float scale = 0.5f; scale <= 2.0; scale += 0.5f)
                {
                    var temp = template.Resize(scale, Inter.Cubic);
                    Mat imgout = new Mat();
                    CvInvoke.MatchTemplate(imgScene,
                        temp,
                        imgout,
                        type);

                    double minVal = 0;
                    double maxVal = 0;
                    Point minLoc = new Point();
                    Point maxLoc = new Point();

                    CvInvoke.MinMaxLoc(imgout, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
                    double prob = minVal / (imgout.ToImage<Gray, byte>().GetSum().Intensity);

                    if (prob < GlobalMin)
                    {
                        GlobalMin = prob;
                        r = new Rectangle(minLoc, temp.Size);
                    }

                    //CvInvoke.PutText(imgScene, prob.ToString("##############.##") + ":"+minVal.ToString() + ":" + scale.ToString(), minLoc, FontFace.HersheySimplex, .5, new MCvScalar(0, 0, 255));
                }
                if (r != null)
                {
                    CvInvoke.Rectangle(imgScene, r, new MCvScalar(255, 0, 0), 3);

                  return imgScene.AsBitmap();
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Bitmap BruteForceMatcher(Image<Bgr,byte> img,Image<Bgr,byte> ImgListInput)
        {
            try
            {
                if (img == null || null == ImgListInput)
                {
                    return  null;
                }


                var template = img.Convert<Gray, byte>();
                   

                var vp = ProcessImageBF(template, ImgListInput.Convert<Gray, byte>());
                if (vp != null)
                {
                    CvInvoke.Polylines(ImgListInput, vp, true, new MCvScalar(0, 0, 255), 5);
                }

                return ImgListInput.AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Bitmap FLANNMatcher(Image<Bgr, byte> img, Image<Bgr, byte> ImgListInput)
        {
            try
            {
                if (img == null || null == ImgListInput)
                {
                    return null;
                }


                var template = img.Convert<Gray, byte>();

                var vp = ProcessImageFLANN(template, ImgListInput.Convert<Gray, byte>());
                if (vp != null)
                {
                    CvInvoke.Polylines(ImgListInput, vp, true, new MCvScalar(0, 0, 255), 5);
                }

                return ImgListInput.AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private static VectorOfPoint ProcessImageBF(Image<Gray, byte> template, Image<Gray, byte> sceneImage)
        {
            try
            {
                // initialization
                VectorOfPoint finalPoints = null;
                Mat homography = null;
                VectorOfKeyPoint templateKeyPoints = new VectorOfKeyPoint();
                VectorOfKeyPoint sceneKeyPoints = new VectorOfKeyPoint();
                Mat tempalteDescriptor = new Mat();
                Mat sceneDescriptor = new Mat();

                Mat mask;
                int k = 2;
                double uniquenessthreshold = 0.80;
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

                // feature detectino and description
                Brisk featureDetector = new Brisk();
                featureDetector.DetectAndCompute(template, null, templateKeyPoints, tempalteDescriptor, false);
                featureDetector.DetectAndCompute(sceneImage, null, sceneKeyPoints, sceneDescriptor, false);

                // Matching
                BFMatcher matcher = new BFMatcher(DistanceType.Hamming);
                matcher.Add(tempalteDescriptor);
                matcher.KnnMatch(sceneDescriptor, matches, k);

                mask = new Mat(matches.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenessthreshold, mask);

                int count = Features2DToolbox.VoteForSizeAndOrientation(templateKeyPoints, sceneKeyPoints, matches, mask, 1.5, 20);

                if (count >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(templateKeyPoints,
                        sceneKeyPoints, matches, mask, 5);
                }

                if (homography != null)
                {
                    Rectangle rect = new Rectangle(Point.Empty, template.Size);
                    PointF[] pts = new PointF[]
                    {
                        new PointF(rect.Left,rect.Bottom),
                        new PointF(rect.Right,rect.Bottom),
                        new PointF(rect.Right,rect.Top),
                        new PointF(rect.Left,rect.Top)
                    };

                    pts = CvInvoke.PerspectiveTransform(pts, homography);
                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    finalPoints = new VectorOfPoint(points);
                }

                return finalPoints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static VectorOfPoint ProcessImageFLANN(Image<Gray, byte> template, Image<Gray, byte> sceneImage)
        {
            try
            {
                // initialization
                VectorOfPoint finalPoints = null;
                Mat homography = null;
                VectorOfKeyPoint templateKeyPoints = new VectorOfKeyPoint();
                VectorOfKeyPoint sceneKeyPoints = new VectorOfKeyPoint();
                Mat tempalteDescriptor = new Mat();
                Mat sceneDescriptor = new Mat();

                Mat mask;
                int k = 2;
                double uniquenessthreshold = 0.80;
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

                // feature detectino and description
                KAZE featureDetector = new KAZE();
                featureDetector.DetectAndCompute(template, null, templateKeyPoints, tempalteDescriptor, false);
                featureDetector.DetectAndCompute(sceneImage, null, sceneKeyPoints, sceneDescriptor, false);


                // Matching

                //KdTreeIndexParams ip = new KdTreeIndexParams();
                //var ip = new AutotunedIndexParams();
                var ip = new LinearIndexParams();
                SearchParams sp = new SearchParams();
                FlannBasedMatcher matcher = new FlannBasedMatcher(ip, sp);


                matcher.Add(tempalteDescriptor);
                matcher.KnnMatch(sceneDescriptor, matches, k);

                mask = new Mat(matches.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenessthreshold, mask);

                int count = Features2DToolbox.VoteForSizeAndOrientation(templateKeyPoints, sceneKeyPoints, matches, mask, 1.5, 20);

                if (count >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(templateKeyPoints,
                        sceneKeyPoints, matches, mask, 5);
                }

                if (homography != null)
                {
                    Rectangle rect = new Rectangle(Point.Empty, template.Size);
                    PointF[] pts = new PointF[]
                    {
                        new PointF(rect.Left,rect.Bottom),
                        new PointF(rect.Right,rect.Bottom),
                        new PointF(rect.Right,rect.Top),
                        new PointF(rect.Left,rect.Top)
                    };

                    pts = CvInvoke.PerspectiveTransform(pts, homography);
                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    finalPoints = new VectorOfPoint(points);
                }

                return finalPoints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
