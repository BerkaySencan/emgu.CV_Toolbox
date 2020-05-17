using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Image_Converter
    {

        public Bitmap toWhichType<TColor,TDepth>(Image<Bgr, byte> img,Emgu.CV.CvEnum.ColorConversion convertTo) where TColor : struct, IColor
                  where TDepth : new()
        {
            try
            {
                if (img==null)
                {
                    return null;
                }
                Image<TColor, TDepth> outImg = new Image<TColor, TDepth>(img.Width, img.Height);
                CvInvoke.CvtColor(img, outImg, convertTo);
                CvInvoke.Imshow("Convert Image",outImg);
                return outImg.AsBitmap();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
       
        }

    }
        
}
