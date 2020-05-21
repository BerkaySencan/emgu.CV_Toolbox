using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Dnn_Based
    {
        public Bitmap Dnn_Face(Image<Bgr,byte> image)
        {
            int imgDim = 300;
            MCvScalar meanVal = new MCvScalar(104, 177, 123);
            String ssdFile = "res10_300x300_ssd_iter_140000.caffemodel";
            String ssdProtoFile = "deploy.prototxt";


            CheckAndDownloadFile(ssdFile, "https://github.com/opencv/opencv_3rdparty/raw/dnn_samples_face_detector_20170830/");
            CheckAndDownloadFile(ssdProtoFile, "https://raw.githubusercontent.com/opencv/opencv/master/samples/dnn/face_detector/");

            Emgu.CV.Dnn.Net net = DnnInvoke.ReadNetFromCaffe(ssdProtoFile, ssdFile);

            Mat img = image.Mat;

            Mat inputBlob = DnnInvoke.BlobFromImage(img, 1.0, new Size(imgDim, imgDim), meanVal, false, false);
            net.SetInput(inputBlob, "data");
            Mat detection = net.Forward("detection_out");

            float confidenceThreshold = 0.5f;

            List<Rectangle> faceRegions = new List<Rectangle>();

            int[] dim = detection.SizeOfDimension;
            int step = dim[3] * sizeof(float);
            IntPtr start = detection.DataPointer;
            for (int i = 0; i < dim[2]; i++)
            {
                float[] values = new float[dim[3]];
                Marshal.Copy(new IntPtr(start.ToInt64() + step * i), values, 0, dim[3]);
                float confident = values[2];

                if (confident > confidenceThreshold)
                {
                    float xLeftBottom = values[3] * img.Cols;
                    float yLeftBottom = values[4] * img.Rows;
                    float xRightTop = values[5] * img.Cols;
                    float yRightTop = values[6] * img.Rows;
                    RectangleF objectRegion = new RectangleF(xLeftBottom, yLeftBottom, xRightTop - xLeftBottom, yRightTop - yLeftBottom);
                    Rectangle faceRegion = Rectangle.Round(objectRegion);
                    faceRegions.Add(faceRegion);

                }
            }

            String facemarkFileName = "lbfmodel.yaml";
            String facemarkFileUrl = "https://raw.githubusercontent.com/kurnianggoro/GSOC2017/master/data/";
            CheckAndDownloadFile(facemarkFileName, facemarkFileUrl);

            using (FacemarkLBFParams facemarkParam = new Emgu.CV.Face.FacemarkLBFParams())
            using (FacemarkLBF facemark = new Emgu.CV.Face.FacemarkLBF(facemarkParam))
            using (VectorOfRect vr = new VectorOfRect(faceRegions.ToArray()))
            using (VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF())
            {
                facemark.LoadModel(facemarkFileName);
                facemark.Fit(img, vr, landmarks);

                foreach (Rectangle face in faceRegions)
                {
                    CvInvoke.Rectangle(img, face, new MCvScalar(0, 255, 0));
                }

                int len = landmarks.Size;
                for (int i = 0; i < landmarks.Size; i++)
                {
                    using (VectorOfPointF vpf = landmarks[i])
                        FaceInvoke.DrawFacemarks(img, vpf, new MCvScalar(255, 0, 0));
                }

            }
            return img.ToBitmap();
        }     
        public void TestDnnTensorFlow(Image<Bgr, byte> image)
        {

          
            String tensorFlowFile = "tensorflow_inception_graph.pb";
            if (!File.Exists(tensorFlowFile))
            {
                //Download the tensorflow file
                String inceptionFile = "inception5h.zip";
                String googleNetUrl = "https://storage.googleapis.com/download.tensorflow.org/models/inception5h.zip";
                Trace.WriteLine("downloading file from:" + googleNetUrl + " to: " + inceptionFile);
                System.Net.WebClient downloadClient = new System.Net.WebClient();
                downloadClient.DownloadFile(googleNetUrl, inceptionFile);

                ZipFile.ExtractToDirectory(inceptionFile, ".");
            }

            Emgu.CV.Dnn.Net net = DnnInvoke.ReadNetFromTensorflow(tensorFlowFile);
         

            Mat img = image.Mat;

            CvInvoke.Resize(img, img, new Size(224, 224));
            CvInvoke.CvtColor(img, img, ColorConversion.Bgr2Rgb);

            Mat inputBlob = DnnInvoke.BlobFromImage(img);
            net.SetInput(inputBlob, "input");
            Mat probBlob = net.Forward("softmax2");

          
            
            int classId;
            double classProb;
            GetMaxClass(probBlob, out classId, out classProb);
            String[] classNames = ReadClassNames("imagenet_comp_graph_label_strings.txt");

           
            System.Windows.Forms.MessageBox.Show("Best class: " + classNames[classId] + ". Probability: " + classProb);
           

        }
        public static void CheckAndDownloadFile(String fileName, String url)
        {

            if (!File.Exists(fileName))
            {

                String fileUrl = url + fileName;
                Trace.WriteLine("downloading file from:" + fileUrl + " to: " + fileName);
                System.Net.WebClient downloadClient = new System.Net.WebClient();
                try
                {
                    downloadClient.DownloadFile(fileUrl, fileName);
                }
                catch
                {
                    File.Delete(fileName);
                    throw;
                }
            }
        }
        public static void GetMaxClass(Mat probBlob, out int classId, out double classProb)
        {

            Mat probMat = probBlob.Reshape(1, 1); //reshape the blob to 1x1000 matrix
            Point minLoc = new Point(), maxLoc = new Point();
            double minVal = 0, maxVal = 0;
            CvInvoke.MinMaxLoc(probMat, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            classId = maxLoc.X;
            classProb = maxVal;
        }
        public static String[] ReadClassNames(String fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
