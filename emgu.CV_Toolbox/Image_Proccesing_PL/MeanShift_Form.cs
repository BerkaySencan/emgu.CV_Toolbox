﻿using System;
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
    public partial class MeanShift_Form : Form
    {
        public MeanShift_Form()
        {
            InitializeComponent();
        }
        Mean_Shift MN = new Mean_Shift();
        Edge_Detection ED = new Edge_Detection();
        ThreshHolding TH = new ThreshHolding();
        private void button1_Click(object sender, EventArgs e)
        {
             MN.Async_OpenImage(ımageBox1);

            // ımageBox1.Image =  MN.OpenImage();

            // ımageBox1.Image = ED.Sobel_Detector((Image<Bgra,byte>)ımageBox1.Image);

            // ımageBox1.Image = TH.Cal_ThresHolding((Image<Bgra, byte>) ımageBox1.Image, Emgu.CV.CvEnum.ThresholdType.Binary);

            // ımageBox1.Image = TH.Cal_Adaptive_ThresHolding((Image<Bgra, byte>)ımageBox1.Image,
            //    Emgu.CV.CvEnum.ThresholdType.Binary,
            //    Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC,
            //    3,//BlockSize
            //    255,//MaxValue
            //    0);//Parameter

            // ımageBox1.Image = MN.CalcuateMeanshift((Image<Bgra, byte>)ımageBox1.Image,
            //    5,//spatialWindow
            //    5,//colorWindow
            //    20,//MinSegmentSize
            //    10);//Iteration
               
        }

        private void MeanShift_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
