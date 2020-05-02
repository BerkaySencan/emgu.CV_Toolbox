using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
    class Morphology : ImgProcessing_Base
    {
        

        public Image<Bgr,byte> Morphological_Operation(Image<Bgr,byte> imgInput, Emgu.CV.CvEnum.MorphOp MorpOpType,int Iteration)
        {
            Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle,
                new System.Drawing.Size(5, 5),
                new System.Drawing.Point(-1,-1));
          
            
            return 
                imgInput.MorphologyEx(
                    MorpOpType,
                    kernel,
                    new System.Drawing.Point(-1, -1),
                    Iteration,
                    Emgu.CV.CvEnum.BorderType.Default,
                    new MCvScalar(1.0));
        }

    }
}
