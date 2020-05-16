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
    public partial class Bar : Form
    {
        Image_Processing_Main main;
        PictureBox pc;



        public Bar(PictureBox pc,Image_Processing_Main main, string LabelText,int min,int max,int currentValue)
        {
           
            InitializeComponent();
            label1.Text = LabelText + " : ";
            trackBar1.Minimum = min;
            trackBar1.Maximum = max;
            trackBar1.Value = currentValue;
            lblValue.Text = currentValue.ToString();
            this.main = main;
            this.pc = pc;


        }
        public delegate Bitmap DelegateHaris(Image<Bgr,byte> img,int x);
        
        public event DelegateHaris OnApply;
        private void TrackBar_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pc.Image !=null && main !=null)
            {
                pc.Image = OnApply?.Invoke(new Bitmap(pc.Image).ToImage<Bgr, byte>(), trackBar1.Value);
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
            
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblValue.Text = trackBar1.Value.ToString();
        }
    }
}
