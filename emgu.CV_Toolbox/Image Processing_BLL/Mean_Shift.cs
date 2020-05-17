using Emgu.CV;
using Emgu.CV.Cuda;
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
  public  class Mean_Shift : ImgProcessing_Base
    {
        
        public Bitmap CalcuateMeanshift(Image<Bgr, byte> imgInput, int spatialWindow = 20, int colorWindow = 20, int MinSegmentSize = 1,int Iteration=1)
        {

           
            Image<Bgr, byte> imgOutput = new Image<Bgr, byte>(imgInput.Width, imgInput.Height, new Bgr(0, 0, 0));
         
                
                CvInvoke.PyrMeanShiftFiltering(imgInput, imgOutput, spatialWindow, colorWindow, MinSegmentSize, new MCvTermCriteria(Iteration));
                return imgOutput.AsBitmap();
            

            

        
        }
  

    }
}
