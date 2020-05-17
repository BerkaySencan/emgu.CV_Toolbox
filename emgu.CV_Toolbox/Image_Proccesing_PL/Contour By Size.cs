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
    public partial class Contour_By_Size : Form
    {
        Image_Processing_Main _main;
        PictureBox _pc;
        public Contour_By_Size(PictureBox pc , Image_Processing_Main main)
        {
            InitializeComponent();
            _main = main;
            _pc = pc;
        }
        public delegate Bitmap DelegateContourBySize(Image<Bgr, byte> img, int width,int height,double area);

        public event DelegateContourBySize OnApply;
        private void button1_Click(object sender, EventArgs e)
        {
            if (_pc.Image != null && _main != null)
            {
                _pc.Image = OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Bgr, byte>(),int.Parse(txtWidth.Text),int.Parse(txtHeight.Text),double.Parse(txtArea.Text));
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }

        }
    }
}
