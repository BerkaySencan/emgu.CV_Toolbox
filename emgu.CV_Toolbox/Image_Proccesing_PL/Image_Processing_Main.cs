using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emgu.CV_Toolbox.Image_Proccesing_PL;
using emgu.CV_Toolbox.Image_Processing_BLL;
using Emgu.CV;
using Emgu.CV.Aruco;
using Emgu.CV.Bioinspired;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Face;
using Emgu.CV.ML;
using Emgu.CV.Shape;
using Emgu.CV.Stitching;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace emgu.CV_Toolbox.Image_Proccesing
{
    public partial class Image_Processing_Main : Form
    {
        public Image_Processing_Main()
        {
            InitializeComponent();
            imgList = new Dictionary<string, Image<Bgr, byte>>();
        }
        bool selecting = false;
        private bool showPixelValue = false;
        private bool down;
        bool SelectROI = false;
        Point StartROI, EndROI;
        bool saveTemplate = false;
        public int rows, cols;
        Rectangle rect = Rectangle.Empty;
        Point start, end;
        Rectangle rectROI;
        Color getColor;
        public Dictionary<string, Image<Bgr, byte>> imgList;

        // Test       
        Dnn_Based DnnBase = new Dnn_Based();
        Image_General IG = new Image_General();
        Filter2DTool FT = new Filter2DTool();
        Mean_Shift MN = new Mean_Shift();
        Edge_Detection ED = new Edge_Detection();
        ThreshHolding TH = new ThreshHolding();
        Morphology Morp = new Morphology();
        Segmentation SG = new Segmentation();
        Contour_Extraction CE = new Contour_Extraction();
        Image_Converter IC = new Image_Converter();
        Feature_Detection FD = new Feature_Detection();
        Image<Gray, byte> GrayImage;
        Image<Gray, float> GrayImageFloat;
        public Image<Bgr, byte> BgrImage;

        private void button1_Click(object sender, EventArgs e)
        {
            // MN.Async_OpenImage(ımageBox1);

            // ımageBox1.Image =  MN.Bgr_OpenImage();

            BgrImage = MN.Bgr_OpenImage();



            //ımageBox1.Image = GrayImage;
            //  ımageBox2.Image = CE.findContours_bySize((Image<Bgr,byte>)ımageBox1.Image,10,10,1000);
            // ımageBox1.Image = ED.Sobel_Detector((Image<Bgra,byte>)ımageBox1.Image);

            // ımageBox1.Image = TH.Cal_ThresHolding((Image<Bgr, byte>)ımageBox1.Image, Emgu.CV.CvEnum.ThresholdType.Binary);

            // ımageBox1.Image = TH.Cal_Adaptive_ThresHolding((Image<Bgr, byte>)ımageBox1.Image,
            //    Emgu.CV.CvEnum.ThresholdType.Binary,
            //    Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC,
            //    3,//BlockSize
            //    255,//MaxValue
            //    0);//Parameter

            // ımageBox1.Image = MN.CalcuateMeanshift((Image<Bgra, byte>)ımageBox1.Image,
            //    5,//spatialWindow
            //    5,//colorWindow
            //    20,//MinSegmentSize
            //    10);//Iteration



            //ımageBox1.Image = SG.Overlay(); 

            // ımageBox1.Image = CE.findContours_Bgr((Image<Bgr,byte>) ımageBox1.Image,
            //    Emgu.CV.CvEnum.RetrType.Ccomp,
            //    Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);


            //ımageBox1.Image = Morp.Morphological_Operation((Image<Bgr, byte>)ımageBox1.Image,
            //Emgu.CV.CvEnum.MorphOp.Open,
            //5);//Iteration


        }

        private void Image_Processing_Main_Load(object sender, EventArgs e)
        {
            pnlPictureBox.AutoScroll = true;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ımageProccesiingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BgrImage = MN.Bgr_OpenImage();
                AddImage(BgrImage, "Input");
                cols = BgrImage.Width;
                rows = BgrImage.Height;
                //  pictureBox1.Image = IC.toWhichType<Gray, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(), ColorConversion.Bgr2Hsv);


                //  pictureBox1.Image = SG.RangeFilter(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(), 10, 100).AsBitmap();
                //pictureBox1.Image = ED.Convex_Hull(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());
                pictureBox1.Image = BgrImage.AsBitmap();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            ////pictureBox1.Image = BgrImage.AsBitmap();


            //GrayImage = BgrImage[0].Convert<Gray, byte>();

            //// pictureBox1.Image = GrayImage.AsBitmap();
            //GrayImage = ED.Sobel_Detector(GrayImage).Convert<Gray,byte>();
            ////pictureBox1.Image= ED.Sobel_Detector(GrayImage).AsBitmap();

            // pictureBox1.Image = TH.Cal_ThresHolding(GrayImage,
            //  Emgu.CV.CvEnum.ThresholdType.Otsu).AsBitmap();




        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }









        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {   // the 'real thing':

                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    getColor = bmp.GetPixel(e.X, e.Y);
                    lblBGR.Text = getColor.ToString();
                    panel3.BackColor = getColor;
                    bmp.Dispose();
                }
                else
                {   // just the background:
                    Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
                    getColor = bmp.GetPixel(e.X, e.Y);

                    lblBGR.Text = getColor.ToString();
                    panel3.BackColor = getColor;
                    bmp.Dispose();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }

            if (selecting == true)
            {
                down = true;
                start = e.Location;
            }

            if (SelectROI)
            {
                down = true;
                StartROI = e.Location;
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (selecting)
            {
                selecting = false;
                down = false;
                end = e.Location;

                if (saveTemplate && rect != null)
                {
                    var img = new Bitmap(pictureBox1.Image)
                   .ToImage<Bgr, byte>();

                    img.ROI = rect;
                    var img2 = img.Copy();

                    img.ROI = Rectangle.Empty;

                    pictureBox1.Image = img2.AsBitmap();
                    AddImage(img2, "Template");
                    saveTemplate = false;
                }
            }

            if (SelectROI)
            {
                SelectROI = false;
                down = false;
                EndROI = e.Location;
                int width = Math.Abs(StartROI.Y - EndROI.Y);
                int height = Math.Abs(StartROI.X - EndROI.X);

                rectROI = new Rectangle(StartROI.X, StartROI.Y, width, height);
            }
        }

        private void showPixelValuesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPixelValue = !showPixelValue;
        }

        private void selectingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selecting = !selecting;
        }

        private void selectTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTemplate = true;
            selecting = true;
        }







        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                pictureBox1.Image = imgList[e.Node.Text].AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void templateMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectRoiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                    return;

                if (rect == Rectangle.Empty)
                    return;

                var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();

                img.ROI = rect;
                var imgROI = img.Copy();
                img.ROI = Rectangle.Empty;

                pictureBox1.Image = imgROI.ToBitmap();
                
                AddImage(imgROI, "ROI Image");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddImage(Image<Bgr, byte> img, string keyName)
        {
            if (!treeView1.Nodes.ContainsKey(keyName))
            {
                TreeNode node = new TreeNode(keyName);
                node.Name = keyName;
                treeView1.Nodes.Add(node);
                treeView1.SelectedNode = node;
            }

            if (!imgList.ContainsKey(keyName))
            {
                imgList.Add(keyName, img);

            }
            else
            {
                imgList[keyName] = img;
            }
        }

        private void resizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!imgList.ContainsKey("ROI Image"))
                {
                    MessageBox.Show("Select a template first");
                    return;
                }

                var img = new Bitmap(pictureBox1.Image)
                        .ToImage<Bgr, byte>();

                img = img.Resize(1.25, Inter.Cubic);

                pictureBox1.Image = img.AsBitmap();
                AddImage(img, "Template Resized");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rotateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!imgList.ContainsKey("ROI Image"))
                {
                    MessageBox.Show("Select a template first");
                    return;
                }

                var img = new Bitmap(pictureBox1.Image)
                    .ToImage<Bgr, byte>();

                img = img.Rotate(90, new Bgr(0, 0, 0), false);

                pictureBox1.Image = img.AsBitmap();
                AddImage(img, "Template Rotated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aasdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matcher mh = new Matcher();
            pictureBox1.Image = mh.MultiScaleTemplateMatcher(new Bitmap(pictureBox1.Image),
                                                  rect,
                                                  imgList["Input"].Clone(),
                                                  Emgu.CV.CvEnum.TemplateMatchingType.Sqdiff);
        }

        // Start  Matcher  -------------- ****** //

        private void multiScaleTemplateMatchingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Matcher mh = new Matcher();
            pictureBox1.Image = mh.TemplateMatcher(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                                                  imgList["Input"].Clone(),
                                                  rect,
                                                  Emgu.CV.CvEnum.TemplateMatchingType.Sqdiff);
        }

        private void bruteForceMatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matcher mh = new Matcher();
            pictureBox1.Image = mh.BruteForceMatcher(imgList["Template"].Clone(), imgList["Input"].Clone());
        }

        private void fLANNMatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matcher mh = new Matcher();
            pictureBox1.Image = mh.FLANNMatcher(imgList["Template"].Clone(), imgList["Input"].Clone());
        }

        // End  Matcher  -------------- ****** //



        // Start  Feature Detection  -------------- ****** //
        private void mSERDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image = FD.MSER_Detector(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void harrisDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    Bar frmBar = new Bar(pictureBox1, this, "Thersholding value", 0, 255, 180);
                    frmBar.OnApply += FD.Harris_Detector;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }



        }

        private void shiThomasiDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image = FD.Shi_Thomasi_Detector(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }


        }

        private void fastDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    Bar frmBar = new Bar(pictureBox1, this, "Thersholding value", 0, 255, 180);
                    frmBar.OnApply += FD.Fast_Detector;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void oRBDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image = FD.ORB_Detector(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        // End  Feature Detection  -------------- ****** //

        // Start  Edge Detection  -------------- ****** //

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    TwoBar frmBar = new TwoBar(pictureBox1, this,
                        "Thersholding value", 0, 255, 180,
                        "Thersholding Linking", 0, 255, 180);
                    frmBar.OnApply += ED.Canny_Detector;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image = ED.Sobel_Detector(new Bitmap(pictureBox1.Image).ToImage<Gray, byte>()).AsBitmap<Gray, float>();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void lablacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image = ED.Laplacian_Detector(new Bitmap(pictureBox1.Image).ToImage<Bgra, byte>()).AsBitmap();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void convexHullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image = ED.Convex_Hull(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }



        // End  Edge Detection  -------------- ****** //
        // Start  Contour Extraction  -------------- ****** //

        private void findContourToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                try
                {
                    Contour frmBar = new Contour(pictureBox1, this);

                    frmBar.OnApply += CE.findContours_Bgr;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void findContourBySizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    Contour_By_Size frmBar = new Contour_By_Size(pictureBox1, this);

                    frmBar.OnApply += CE.findContours_bySize;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }



        // End  Contour Extraction  -------------- ****** //

        // Start  Morpholoji   -------------- ****** //

        private void morpholocigalOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    Morpholocigal_Operation frmBar = new Morpholocigal_Operation(pictureBox1, this);

                    frmBar.OnApply += Morp.Morphological_Operation;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }



        // End   Morpholoji   -------------- ****** //

        // Start  MeanShift   -------------- ****** //

        private void meanShiftSegmentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    MeanShiftFiltering frmBar = new MeanShiftFiltering(pictureBox1, this);

                    frmBar.OnApply += MN.CalcuateMeanshift;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }



        // End  MeanShift   -------------- ****** //

        // Start  Overlay   -------------- ****** //

        private void overlayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                try
                {

                    pictureBox1.Image = SG.Overlay().ToBitmap();

                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        // End  Overlay   -------------- ****** //
        // Start  RangeFilter   -------------- ****** //

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    Range_Filter frmBar = new Range_Filter(pictureBox1, this);

                    frmBar.OnApply += SG.RangeFilter;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }
        // End  RangeFilter   -------------- ****** //

        // Start  Thersholding   -------------- ****** //
        private void thersholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    frmTheresholding frmBar = new frmTheresholding(pictureBox1, this);

                    frmBar.OnApply += TH.Cal_ThresHolding;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }
        // End  Thersholding   -------------- ****** //

        // Start Adaptive Thersholding   -------------- ****** //
        private void adaptiveThersholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    frmAdaptiveThershold frmBar = new frmAdaptiveThershold(pictureBox1, this);

                    frmBar.OnApply += TH.Cal_Adaptive_ThresHolding;
                    frmBar.ShowDialog();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }



        // End Adaptive Thersholding   -------------- ****** //
        // Start Color Converter    -------------- ****** //
        private void toGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Gray, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Gray);

        }

        private void bgr2BgraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Bgra, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Bgra);
        }

        private void bgr2RgbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Rgba, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Rgba);
        }

        private void bgr2RgbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Rgb, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Rgb);
        }

        private void bgr2XyzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Xyz, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Xyz);
        }

        private void bgr2YCrCbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Ycc, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2YCrCb);
        }

        private void bgr2HsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Hsv, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Hsv);

        }

        private void bgr2LuvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Luv, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Luv);
        }

        private void bgr2HlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Hls, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Hls);
        }

        private void bgr2YuvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = IC.toWhichType<Ycc, byte>(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(),
                ColorConversion.Bgr2Yuv);
        }
        // End Color Converter   -------------- ****** //
        // Start Histogram     -------------- ****** //
        private void redChannelHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    frmHistogram frm = new frmHistogram(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(), frmHistogram.ColorChannel.R);
                    frm.ShowDialog();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
            else
            {
                MessageBox.Show("First,Select Image");
            }


        }

        private void greenChannelHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    frmHistogram frm = new frmHistogram(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(), frmHistogram.ColorChannel.G);
                    frm.ShowDialog();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
            else
            {
                MessageBox.Show("First,Select Image");
            }


        }

        private void blueChannelHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    frmHistogram frm = new frmHistogram(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(), frmHistogram.ColorChannel.B);
                    frm.ShowDialog();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }



        }

        private void bGRHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    frmHistogram frm = new frmHistogram(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>(), frmHistogram.ColorChannel.BGR);
                    frm.ShowDialog();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }


        }

        private void colorBasedMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) { MessageBox.Show("First Select Image"); return; }

                var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                img._SmoothGaussian(5);

                Bgr lower = new Bgr(getColor.B - 10, getColor.G - 10, getColor.R - 10);
                Bgr higher = new Bgr(getColor.B + 10, getColor.G + 10, getColor.R + 10);

                var mask = img.InRange(lower, higher).Not();
                img.SetValue(new Bgr(0, 0, 0), mask);
                pictureBox1.Image = img.AsBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (selecting)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }

            if (down)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    return;
                }



                if (showPixelValue)
                {
                    if (e.X < cols && e.Y < rows)
                    {
                        Bgr bgr = imgList["Input"][e.Y, e.X];
                        lblBGR.Text = "B G R: " + bgr.Blue + " " + bgr.Green + " " + bgr.Red;
                    }
                }
                if (selecting && down)
                {
                    int x = Math.Min(start.X, e.X);
                    int y = Math.Min(start.Y, e.Y);

                    int width = Math.Max(start.X, e.X) - Math.Min(start.X, e.X);

                    int height = Math.Max(start.Y, e.Y) - Math.Min(start.Y, e.Y);
                    rect = new Rectangle(x, y, width, height);
                    Refresh();
                }

                if (SelectROI)
                {
                    int x = Math.Min(StartROI.X, e.X);
                    int y = Math.Min(StartROI.Y, e.Y);

                    int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);

                    int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
                    rect = new Rectangle(x, y, width, height);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DnnBase.TestDnnTensorFlow(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         


        }

        private void oilPaintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    Image<Bgr, byte> image = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                    Mat m = image.Mat;
                    Mat result = new Mat();
                    Emgu.CV.XPhoto.XPhotoInvoke.OilPainting(m, result, 10, 1, ColorConversion.Bgr2Lab);
                    pictureBox1.Image = result.ToBitmap();
                }
                catch (Exception erros)
                {
                    MessageBox.Show(erros.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("first,Select Image");
            }
            
        }
        public static void TestOpenCL(Action test)
        {
            Trace.WriteLine("Testing without OpenCL");

            CvInvoke.UseOpenCL = false;
            test();
            if (CvInvoke.HaveOpenCL)
            {
                CvInvoke.UseOpenCL = true;
                Trace.WriteLine("Testing with OpenCL");
                test();
                CvInvoke.OclFinish();
            }
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = new Bitmap(pictureBox1.Image).ToImage<Bgr, Byte>();
            Image<Bgr, Byte> result = new Image<Bgr, byte>(image.Size);
            CvInvoke.FastNlMeansDenoisingColored(image, result, 3f, 10, 7, 21);
            CvInvoke.Imshow("he",image.ConcateHorizontal(result));

        }

        private void shapeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = FD.Shape_Detector(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());
        }



        private void PyrUpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {

                    AddImage(IG.PyrUp(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>()), "PyrUp");
                    if (!imgList.ContainsKey("PyrUp"))
                    {
                        MessageBox.Show("PyrUp Doesn't Exist");
                    }
                    else
                    {
                        pictureBox1.Image = imgList["PyrUp"].AsBitmap();
                    }
                   

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }
        }

        private void pyrDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {

                    AddImage(IG.PyrDown(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>()), "PyrDown");
                    if (!imgList.ContainsKey("PyrDown"))
                    {
                        MessageBox.Show("PyrDown Doesn't Exist");
                    }
                    else
                    {
                        pictureBox1.Image = imgList["PyrDown"].AsBitmap();
                    }


                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    frmGaussianBlur frm = new frmGaussianBlur(pictureBox1, this);

                    frm.OnApply += IG.GaussianBlur;
                    frm.ShowDialog();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }
        }

        private void gaussianNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {

                    AddImage(IG.GaussianNoise(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>()), "Gaussian Noise");
                    if (!imgList.ContainsKey("Gaussian Noise"))
                    {
                        MessageBox.Show("Gaussian Noise Doesn't Exist");
                    }
                    else
                    {
                        pictureBox1.Image = imgList["Gaussian Noise"].AsBitmap();
                    }


                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }
        }

        private void hitOrMissToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {

                    pictureBox1.Image = IG.HitOrMiss(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>());


                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }
        }

        private void ımageDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {

                    List<string> list = new List<string>();
                    foreach (TreeNode item in treeView1.Nodes)
                    {
                        if (item.Checked)
                        {
                            list.Add(item.Text);
                        }
                    }
                    if (list.Count > 1)
                    {
                        var mat = new Mat();
                        CvInvoke.AbsDiff(imgList[list[0]], imgList[list[1]], mat);
                        AddImage(mat.ToImage<Bgr, byte>(), "Image Difference");
                        pictureBox1.Image = mat.ToBitmap();

                    }
                    else
                    {
                        MessageBox.Show("Select two images.");
                    }


                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("First,Select Image");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void jpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                List<string> list = new List<string>();
                foreach (TreeNode item in treeView1.Nodes)
                {
                    list.Add(item.Text);
                    if (item.Checked)
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "Images|*.jpg";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            int width = Convert.ToInt32(imgList[list[item.Index]].Width);
                            int height = Convert.ToInt32(imgList[list[item.Index]].Height);
                            Bitmap bmp = new Bitmap(width, height);
                            pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                            bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
    
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                List<string> list = new List<string>();
                foreach (TreeNode item in treeView1.Nodes)
                {
                    list.Add(item.Text);
                    if (item.Checked)
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "Images|*.png";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            int width = Convert.ToInt32(imgList[list[item.Index]].Width);
                            int height = Convert.ToInt32(imgList[list[item.Index]].Height);
                            Bitmap bmp = new Bitmap(width, height);
                            pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                            bmp.Save(dialog.FileName, ImageFormat.Png);
                        }
                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void tfifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                List<string> list = new List<string>();
                foreach (TreeNode item in treeView1.Nodes)
                {
                    list.Add(item.Text);
                    if (item.Checked)
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "Images|*.tfif";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            int width = Convert.ToInt32(imgList[list[item.Index]].Width);
                            int height = Convert.ToInt32(imgList[list[item.Index]].Height);
                            Bitmap bmp = new Bitmap(width, height);
                            pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                            bmp.Save(dialog.FileName, ImageFormat.Tiff);
                        }
                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void bmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                List<string> list = new List<string>();
                foreach (TreeNode item in treeView1.Nodes)
                {
                    list.Add(item.Text);
                    if (item.Checked)
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "Images|*.bmp";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            int width = Convert.ToInt32(imgList[list[item.Index]].Width);
                            int height = Convert.ToInt32(imgList[list[item.Index]].Height);
                            Bitmap bmp = new Bitmap(width, height);
                            pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                            bmp.Save(dialog.FileName, ImageFormat.Bmp);
                        }
                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void dFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image = FT.TwoDimentionsFilter(new Bitmap(pictureBox1.Image));

                }
                else
                {
                    MessageBox.Show("First,Select Image");
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MN.Async_OpenImage(pictureBox1, this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> image = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();



            pictureBox1.Image = DnnBase.Dnn_Face(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>())
;
        }


      
        // End Histogram    -------------- ****** // 

        // Start Color Converter   -------------- ****** //
    }
}
