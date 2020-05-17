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
    public partial class Contour : Form
    {
        PictureBox _pc;
        Image_Processing_Main _main;
        public Contour(PictureBox pc, Image_Processing_Main main)
        {
            InitializeComponent();
            _pc = pc;
            _main = main;
        }
        public delegate Bitmap DelegateContour(Image<Bgr, byte> img, Emgu.CV.CvEnum.RetrType retrType, Emgu.CV.CvEnum.ChainApproxMethod method);

        public event DelegateContour OnApply;
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_pc.Image != null && _main != null)
            {
                Emgu.CV.CvEnum.RetrType returnReType = (Emgu.CV.CvEnum.RetrType)Enum.Parse(typeof(Emgu.CV.CvEnum.RetrType), cmbReType.Text);
                Emgu.CV.CvEnum.ChainApproxMethod returnCAM = (Emgu.CV.CvEnum.ChainApproxMethod)Enum.Parse(typeof(Emgu.CV.CvEnum.ChainApproxMethod), cmbCAM.Text);
                _pc.Image = OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Bgr, byte>(),returnReType,returnCAM);
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void Contour_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> dictionaryReType = new Dictionary<string,int>();
            Dictionary<string, int> dictionaryCAM = new Dictionary<string, int>();


            foreach (int enumValue in
            Enum.GetValues(typeof(Emgu.CV.CvEnum.RetrType)))
            {
                dictionaryReType.Add(Enum.GetName(typeof(Emgu.CV.CvEnum.RetrType), enumValue), enumValue);
            }
            cmbReType.DisplayMember = "Key"; ;
            cmbReType.ValueMember = "Value";
            cmbReType.DataSource = new BindingSource(dictionaryReType, null);

            foreach (int enumValue in
            Enum.GetValues(typeof(Emgu.CV.CvEnum.ChainApproxMethod)))
            {
                dictionaryCAM.Add(Enum.GetName(typeof(Emgu.CV.CvEnum.ChainApproxMethod), enumValue), enumValue);
            }
            cmbCAM.DisplayMember = "Key"; ;
            cmbCAM.ValueMember = "Value";
            cmbCAM.DataSource = new BindingSource(dictionaryCAM, null);
        }
    }
}
