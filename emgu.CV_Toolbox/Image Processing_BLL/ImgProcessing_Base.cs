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
 public class ImgProcessing_Base
    {
        //Bazı durumlarda Burada ki methodalara extra bişeyler eklemeniz gerekirse oluşturdugunuz çlass içinde
        //override işlemi yapıp buradaki methodları ezebilirisinz örneğin ;
        //public override Bitmap OpenImage(){} ... deyip kendi clasınızda tekrar içini doldurabilirisinz.
        public virtual Bitmap OpenImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
          

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                 return new Image<Bgra, byte>(ofd.FileName).Bitmap;
            }
            return null;
          
           
        }


        public virtual void ShowImage(string path,string ImageName)
        {

            string fileName = path;
            Image<Bgr, byte> imf = new Image<Bgr, byte>(fileName);
            CvInvoke.Imshow(ImageName, imf);
            CvInvoke.WaitKey(0);
        }

    }
}
