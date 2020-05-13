using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
   public class Filter2DTool
    {
        public Bitmap TwoDimentionsFilter (Bitmap ImgInput,double scale= 1 / 9.0)
        { 
         try
            {
                if (ImgInput == null)
                {
                    return null;
                }

                float[,] data = {
                    { 0, 1, 0 },
                    { 1, -1, 1},
                    { 0, 1, 0 } };
        Matrix<float> SE = new Matrix<float>(data);
        SE._Mul(scale);

                var img = new Bitmap(ImgInput)
                    .ToImage<Bgr, float>();

        var imgout = img.CopyBlank();
        CvInvoke.Filter2D(img, imgout, SE, new Point(-1, -1));

             return imgout.ToBitmap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
