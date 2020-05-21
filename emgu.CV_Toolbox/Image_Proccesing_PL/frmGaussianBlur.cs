using emgu.CV_Toolbox.Image_Proccesing;
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

namespace emgu.CV_Toolbox.Image_Proccesing_PL
{
    public partial class frmGaussianBlur : Form
    {
        Image_Processing_Main _main;
        PictureBox _pc;
        public frmGaussianBlur(PictureBox pc,Image_Processing_Main main )
        {
            InitializeComponent();
            _pc = pc;
            _main = main;
        }
        public delegate Image<Bgr,byte> DelegateGaussianBlur(Image<Bgr, byte> img, int x);

        public event DelegateGaussianBlur OnApply;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_pc.Image != null && _main != null)
            {
               
                _main.AddImage(OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Bgr, byte>(), trackBar1.Value), "Gaussian Blur");
                if (!_main.imgList.ContainsKey("Gaussian Blur"))
                {
                    MessageBox.Show("Gaussian Blur Doesn't Exist");
                }
                else
                {
                    _pc.Image = _main.imgList["Gaussian Blur"].AsBitmap();
                }


            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void frmGaussianBlur_Load(object sender, EventArgs e)
        {
            

            trackBar1.Value = 3;
            label2.Text = "3";
            trackBar1.Maximum = 101;
            trackBar1.Minimum = 1;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value %2==0)
            {
                trackBar1.Value = trackBar1.Value + 1;
                label2.Text = trackBar1.Value.ToString();
            }
        }
    }
}
