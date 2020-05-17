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
    public partial class MeanShiftFiltering : Form
    {
        Image_Processing_Main _main;
        PictureBox _pc;

        public MeanShiftFiltering(PictureBox pc, Image_Processing_Main main)
        {
            InitializeComponent();
            _main = main;
            _pc = pc;
        }
        public delegate Bitmap DelegateMeanShift(Image<Bgr, byte> imgInput, int spatialWindow = 20, int colorWindow = 20, int MinSegmentSize = 1, int Iteration = 1);

        public event DelegateMeanShift OnApply;

        private void button1_Click(object sender, EventArgs e)
        {
            if (_pc.Image != null && _main != null)
            {
                _pc.Image = OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Bgr, byte>(), tbarSW.Value, tbarSW.Value,(int) nudMLS.Value,(int) nudIteration.Value); ;
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void tbarSW_Scroll(object sender, EventArgs e)
        {
            lblSWValue.Text = tbarSW.Value.ToString();
        }

        private void tbarCW_Scroll(object sender, EventArgs e)
        {
            lblCWValue.Text = tbarCW.Value.ToString();
        }

        private void MeanShiftFiltering_Load(object sender, EventArgs e)
        {
            tbarCW.Minimum = 1;
            tbarSW.Minimum = 1;
            nudMLS.Minimum = 0;
            nudIteration.Minimum = 0;

            tbarCW.Maximum = 255;
            tbarSW.Maximum = 255;
            nudIteration.Maximum = 255;
            nudMLS.Maximum = 9;

            tbarSW.Value = 20;
            tbarCW.Value = 20;
            lblCWValue.Text = "20";
            lblSWValue.Text = "20";
            
           

        }
    }
}
