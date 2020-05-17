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
    public partial class Range_Filter : Form
    {
        Image_Processing_Main _main;
        PictureBox _pc;
        public Range_Filter(PictureBox pc, Image_Processing_Main main)
        {
            InitializeComponent();
            _main = main;
            _pc = pc;
        }
        public delegate Bitmap DelegateRangeFilter(Image<Bgr, byte> imgInput, int grayMin, int GrayMax);

        public event DelegateRangeFilter OnApply;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_pc.Image != null && _main != null)
            {
                _pc.Image = OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Bgr, byte>(), (int)nudMin.Value, (int)nudMax.Value); ;
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void Range_Filter_Load(object sender, EventArgs e)
        {
            nudMin.Minimum = 0;
            nudMax.Minimum = 0;
            nudMin.Maximum = 255;
            nudMax.Maximum = 255;
        }
    }
}
