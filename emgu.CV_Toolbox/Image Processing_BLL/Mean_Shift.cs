using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
  public  class Mean_Shift : ImgProcessing_Base
    {
        
        public Image<Bgra,byte> CalcuateMeanshift(Image<Bgra, byte> imgInput, int spatialWindow = 5, int colorWindow = 5, int MinSegmentSize = 20)
        {

           
            Image<Bgra, byte> imgOutput = new Image<Bgra, byte>(imgInput.Width, imgInput.Height, new Bgra(0, 0, 0, 0));

                //convert the image to BGRA as it requires a BGRA to pass it in constructor of CudaImage
               
                CudaImage<Bgra, byte> _inputCuda = new CudaImage<Bgra, byte>(imgInput);
                CudaInvoke.MeanShiftSegmentation(_inputCuda, imgOutput, spatialWindow, colorWindow, MinSegmentSize, new MCvTermCriteria(1, .001), null);
           
            return imgOutput;

        
        }
  

    }
}
