using Emgu.CV;
using Emgu.CV.Structure;
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
using System.Drawing.Imaging;

namespace emgu.CV_Toolbox.Machine_Learning_PL
{
    public partial class Dnn_Main : Form
    {
        public Dnn_Main()
        {
            InitializeComponent();
            imgList = new Dictionary<string, Image<Bgr, byte>>();
        }
        Dnn_Based DNN = new Dnn_Based();
        Image_Processing_BLL.ImgProcessing_Base Base =new ImgProcessing_Base();
        public Dictionary<string, Image<Bgr, byte>> imgList;
        int cols, rows;
        Image<Bgr, byte> BgrImage;
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    Image<Bgr, byte> image = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();

                    AddImage(DNN.Dnn_Face(new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>()).ToImage<Bgr, byte>(), "Find Face");
                    pictureBox1.Image = imgList["Find Face"].AsBitmap();
                    

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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BgrImage = Base.Bgr_OpenImage();
                AddImage(BgrImage, "Input");
                cols = BgrImage.Width;
                rows = BgrImage.Height;
                pictureBox1.Image = BgrImage.AsBitmap();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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

        //Start Image Save 

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
                        dialog.Filter = "Images|*.Tiff";
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

        // Image Save End
        private void Dnn_Main_Load(object sender, EventArgs e)
        {
            pnlPictureBox.AutoScroll = true;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
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
