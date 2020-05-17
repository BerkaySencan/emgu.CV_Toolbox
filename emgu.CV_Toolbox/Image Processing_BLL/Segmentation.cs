using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;


namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Segmentation : ImgProcessing_Base
    {
        private  Image<Gray,byte> _imgOutput;
        private  Image<Bgr, byte> _imgInput;


        public Bitmap RangeFilter(Image<Bgr, byte> imgInput, int min, int max)
        {
            _imgInput = imgInput;
            _imgOutput = imgInput.Convert<Gray, byte>().InRange(new Gray(min), new Gray(max)).Canny(10, 50);
            return _imgOutput.AsBitmap();
        }

        public Image<Bgr, byte> Overlay()
        {
            if (_imgOutput == null)
            {
                System.Windows.Forms.MessageBox.Show("First of all, you should apply the Range Filter Process.");
                return null;
            }
            Image<Bgr, byte> temp = _imgInput.Clone();
            temp.SetValue(new Bgr(0, 0, 255),_imgOutput);
            return temp;
        }

    }
}
