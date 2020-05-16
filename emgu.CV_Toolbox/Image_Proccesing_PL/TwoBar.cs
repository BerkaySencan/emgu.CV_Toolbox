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
    public partial class TwoBar : Form
    {
        Image_Proccesing.Image_Processing_Main main;
        PictureBox pc;
        public TwoBar(PictureBox pc, Image_Proccesing.Image_Processing_Main main, 
            string LabelText1, int min, int max, int currentValue,
            string LabelText2,int min2,int max2, int currentValue2)
        {
            InitializeComponent();
            lblFirst.Text = LabelText1 + " : ";
            trackBar1.Minimum = min;
            trackBar1.Maximum = max;
            trackBar1.Value = currentValue;
            lblFirstValue.Text = currentValue.ToString();

            lblSecond.Text = LabelText2 + " : ";
            trackBar2.Minimum = min2;
            trackBar2.Maximum = max2;
            trackBar2.Value = currentValue2;
            lblSecondValue.Text = currentValue2.ToString();

            this.main = main;
            this.pc = pc;
        }
        public delegate Bitmap DelegateEdge(Image<Bgra, byte> img, double x, double y);

        public event DelegateEdge OnApply;
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (pc.Image != null && main != null)
            {
                pc.Image = OnApply?.Invoke(new Bitmap(pc.Image).ToImage<Bgra, byte>(), trackBar1.Value,trackBar2.Value);
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblFirstValue.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lblSecondValue.Text = trackBar2.Value.ToString();
        }
    }
}
