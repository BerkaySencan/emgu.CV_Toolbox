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
    public partial class frmHistogram : Form
    {
        public enum ColorChannel
        {
            B, G, R,BGR
        }
        
        Image<Bgr, byte> _img;
     

        ColorChannel _Channel;
        public frmHistogram(Image<Bgr,byte> img,ColorChannel Channel)
        {
            InitializeComponent();
            _img = img;
            _Channel = Channel;


        }

        private void frmHistogram_Load(object sender, EventArgs e)
        {
            histogramBox1.Dock = DockStyle.Fill;
           
            if (_img !=null)
            {
                histogramBox1.ClearHistogram();
                if (ColorChannel.B ==_Channel)
                {
                    histogramBox1.GenerateHistograms(_img[0], 256);
                    histogramBox1.Refresh();
                }
                else if (ColorChannel.G == _Channel)
                {
                    histogramBox1.GenerateHistograms(_img[1], 256);
                    histogramBox1.Refresh();
                }
                else if (ColorChannel.R == _Channel)
                {
                    histogramBox1.GenerateHistograms(_img[2], 256);
                    histogramBox1.Refresh();
                }
                else if (ColorChannel.BGR == _Channel)
                {
                    histogramBox1.GenerateHistograms(_img, 256);
                    histogramBox1.Refresh();
                }
            }
     
        }
    }
}
