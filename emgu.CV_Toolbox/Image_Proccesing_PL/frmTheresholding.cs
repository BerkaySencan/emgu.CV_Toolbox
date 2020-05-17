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
    public partial class frmTheresholding : Form
    {
        PictureBox _pc;
        Image_Processing_Main _main;
        public frmTheresholding(PictureBox pc, Image_Processing_Main main)
        {
            InitializeComponent();
            _pc = pc;
            _main = main;
        }
        public delegate Bitmap DelegateTheresholding(Image<Gray, byte> img, Emgu.CV.CvEnum.ThresholdType retrType, double thershold=100,double max=255);

        public event DelegateTheresholding OnApply;


        private void button1_Click_1(object sender, EventArgs e)
        {
            Emgu.CV.CvEnum.ThresholdType returnThType = (Emgu.CV.CvEnum.ThresholdType)Enum.Parse(typeof(Emgu.CV.CvEnum.ThresholdType), cmbType.Text);
            _pc.Image = OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Gray, byte>(), returnThType, tbarThershold.Value, tbarMaxValue.Value);
        }

        private void tbarThershold_Scroll(object sender, EventArgs e)
        {
            lblThValue.Text = tbarThershold.Value.ToString(); 
        }

        private void tbarMaxValue_Scroll(object sender, EventArgs e)
        {
            lblMaxValue.Text = tbarMaxValue.Value.ToString();
        }

        private void frmTheresholding_Load_1(object sender, EventArgs e)
        {
            tbarThershold.Maximum = 255;
            tbarThershold.Minimum = 0;
            tbarMaxValue.Minimum = 0;
            tbarMaxValue.Maximum = 255;

            lblMaxValue.Text = "255";
            lblThValue.Text = "180";

            tbarMaxValue.Value = 255;
            tbarThershold.Value = 180;

           

            Dictionary<string, int> dictionaryType = new Dictionary<string, int>();


            foreach (int enumValue in
            Enum.GetValues(typeof(Emgu.CV.CvEnum.ThresholdType)))
            {
                dictionaryType.Add(Enum.GetName(typeof(Emgu.CV.CvEnum.ThresholdType), enumValue), enumValue);
            }
            cmbType.DisplayMember = "Key"; ;
            cmbType.ValueMember = "Value";
            cmbType.DataSource = new BindingSource(dictionaryType, null);
        }
    }
}
