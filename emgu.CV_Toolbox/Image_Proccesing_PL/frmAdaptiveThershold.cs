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
    public partial class frmAdaptiveThershold : Form
    {
        PictureBox _pc;
        Image_Processing_Main _main;
        public frmAdaptiveThershold(PictureBox pc, Image_Processing_Main main)
        {
            InitializeComponent();
            _pc = pc;
            _main = main;
        }
        public delegate Bitmap DelegateAdaptiveTheresholding(Image<Bgr, byte> img, Emgu.CV.CvEnum.ThresholdType thresholdType, Emgu.CV.CvEnum.AdaptiveThresholdType adaptiveThresholdType, int blocksize = 5, double max = 255,double pmtr=0);

        public event DelegateAdaptiveTheresholding OnApply;
        private void button1_Click(object sender, EventArgs e)
        {
            Emgu.CV.CvEnum.ThresholdType returnThType = (Emgu.CV.CvEnum.ThresholdType)Enum.Parse(typeof(Emgu.CV.CvEnum.ThresholdType), cmbThType.Text);
            Emgu.CV.CvEnum.AdaptiveThresholdType returnAdaptiveThType = (Emgu.CV.CvEnum.AdaptiveThresholdType)Enum.Parse(typeof(Emgu.CV.CvEnum.AdaptiveThresholdType), cmbAdaptiveType.Text);
            _pc.Image = OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Bgr, byte>(), returnThType, returnAdaptiveThType, tbarBlockSize.Value, tbarMax.Value,(int)nudParamater.Value);
        }

        private void frmAdaptiveThershold_Load(object sender, EventArgs e)
        {
            tbarBlockSize.Maximum = 7;
            tbarBlockSize.Minimum = 1;
            tbarMax.Minimum = 0;
            tbarMax.Maximum = 255;
           

            lblBlockSize.Text = "5";
            lblMax.Text = "255";

            tbarBlockSize.Value = 5;
            tbarMax.Value = 255;


            Dictionary<string, int> dictionaryTHType = new Dictionary<string, int>();
            Dictionary<string, int> dictionaryAdaptiveTHType = new Dictionary<string, int>();


            foreach (int enumValue in
            Enum.GetValues(typeof(Emgu.CV.CvEnum.ThresholdType)))
            {
                dictionaryTHType.Add(Enum.GetName(typeof(Emgu.CV.CvEnum.ThresholdType), enumValue), enumValue);
            }
            cmbThType.DisplayMember = "Key"; ;
            cmbThType.ValueMember = "Value";
            cmbThType.DataSource = new BindingSource(dictionaryTHType, null);


            //adaptive
            foreach (int enumValue in
            Enum.GetValues(typeof(Emgu.CV.CvEnum.AdaptiveThresholdType)))
            {
                dictionaryAdaptiveTHType.Add(Enum.GetName(typeof(Emgu.CV.CvEnum.AdaptiveThresholdType), enumValue), enumValue);
            }
            cmbAdaptiveType.DisplayMember = "Key"; ;
            cmbAdaptiveType.ValueMember = "Value";
            cmbAdaptiveType.DataSource = new BindingSource(dictionaryAdaptiveTHType, null);
        }

        private void tbarMax_Scroll(object sender, EventArgs e)
        {
            lblMax.Text = tbarMax.Value.ToString();
        }

        private void tbarBlockSize_Scroll(object sender, EventArgs e)
        {
            lblBlockSize.Text = tbarBlockSize.Value.ToString();
        }
    }
}
