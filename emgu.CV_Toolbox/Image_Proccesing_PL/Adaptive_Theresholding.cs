using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emgu.CV_Toolbox.Image_Processing_BLL;
using Emgu.CV;
using Emgu.CV.Structure;

namespace emgu.CV_Toolbox.Image_Proccesing
{
    public partial class ImageProccesing_Main : Form
    {
        public ImageProccesing_Main()
        {
            InitializeComponent();
        }
        Mean_Shift MN = new Mean_Shift();
        private void ImageProccesing_Main_Load(object sender, EventArgs e)
        {

            MN.ShowImage("C:/Users/Berkay/source/repos/emgu.CV_Toolbox/emgu.CV_Toolbox/Assets/Images/Koala.jpg", "Koala");

        }
    }
}
