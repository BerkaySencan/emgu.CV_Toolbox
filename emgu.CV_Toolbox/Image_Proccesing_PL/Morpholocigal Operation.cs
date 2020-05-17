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
    public partial class Morpholocigal_Operation : Form
    {
        PictureBox _pc;
        Image_Processing_Main _main;
        public Morpholocigal_Operation(PictureBox pc, Image_Processing_Main main)
        {
            InitializeComponent();
            _pc = pc;
            _main = main;
        }
        public delegate Bitmap DelegateMorpOp(Image<Bgr, byte> img, Emgu.CV.CvEnum.MorphOp retrType,int iteration);

        public event DelegateMorpOp OnApply;
        private void button1_Click(object sender, EventArgs e)
        {

            if (_pc.Image != null && _main != null)
            {
                Emgu.CV.CvEnum.MorphOp returnMorpType = (Emgu.CV.CvEnum.MorphOp)Enum.Parse(typeof(Emgu.CV.CvEnum.MorphOp), cmbMorpType.Text);
                _pc.Image = OnApply?.Invoke(new Bitmap(_pc.Image).ToImage<Bgr, byte>(), returnMorpType,(int)nupIteration.Value);
            }
            else
            {
                MessageBox.Show("First, Select Image");
            }
        }

        private void Morpholocigal_Operation_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> dictionaryMorpType = new Dictionary<string, int>();

         foreach (int enumValue in
         Enum.GetValues(typeof(Emgu.CV.CvEnum.MorphOp)))
            {
                dictionaryMorpType.Add(Enum.GetName(typeof(Emgu.CV.CvEnum.MorphOp), enumValue), enumValue);
            }
            cmbMorpType.DisplayMember = "Key"; ;
            cmbMorpType.ValueMember = "Value";
            cmbMorpType.DataSource = new BindingSource(dictionaryMorpType, null);
        }
    }
}
