using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emgu.CV_Toolbox.Image_Processing_BLL;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

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
     public   Dictionary<string, Image<Bgr, byte>> imgList;

        // Test       
        Mean_Shift MN = new Mean_Shift();
        Edge_Detection ED = new Edge_Detection();
        ThreshHolding TH = new ThreshHolding();
        Morphology Morp = new Morphology();
        Segmentation SG = new Segmentation();
        Contour_Extraction CE = new Contour_Extraction();
        Image_Converter IC = new Image_Converter();
        Image<Gray, byte> GrayImage;
        Image<Gray, float> GrayImageFloat;
        Image<Bgr, byte> BgrImage;

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
                //pictureBox1.Image = BgrImage.AsBitmap();
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


    }
}
