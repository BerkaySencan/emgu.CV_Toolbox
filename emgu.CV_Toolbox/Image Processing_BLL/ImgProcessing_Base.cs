using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Emgu.CV.UI;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu.CV_Toolbox.Image_Processing_BLL
{
 public class ImgProcessing_Base
    {
        private Image<Bgra, byte> inputImg;
        private string imgPath="";
        ImageBox _imgBox;
    
        public virtual Image<Bgra,byte> OpenImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
          

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                 return new Image<Bgra, byte>(ofd.FileName);
            }
            return null;
          
           
        }
        public virtual void Async_OpenImage(ImageBox imgBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            _imgBox = imgBox;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.WorkerReportsProgress = false;
                bgw.DoWork += Bgw_DoWork;   
                bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
                imgPath = ofd.FileName;
                bgw.RunWorkerAsync();

                
            }
            


        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _imgBox.Image = inputImg;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            inputImg = new Image<Bgra, byte>(imgPath);
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
