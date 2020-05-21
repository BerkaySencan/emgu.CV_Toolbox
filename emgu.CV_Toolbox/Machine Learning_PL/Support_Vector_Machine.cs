using emgu.CV_Toolbox.Image_Processing_BLL;
using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu.CV_Toolbox.Machine_Learning_PL
{
    public partial class Support_Vector_Machine : Form
    {
        public Support_Vector_Machine()
        {
            InitializeComponent();
        }
        Dnn_Based dnn_Base = new Dnn_Based();

        public SVM svm;
        public string Node;
        int Counter = 0;
        bool IsDisplayImage = false;

        string TraingDataPath;
        string TestDataPath;

        public Matrix<float> TrainData;
        public Matrix<float> TestData;
        public Matrix<int> TrainLabel;
        public Matrix<int> TestLabel;
        private void loadDtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void LoadTrainData()
        {
            
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TraingDataPath = dialog.FileName;
            }

            else { MessageBox.Show("Train File Error"); return; }
            List<float[]> trainList = new List<float[]>();
            List<int> trainLabel = new List<int>();

            StreamReader reader = new StreamReader(TraingDataPath);

            string line = "";
            if (!File.Exists(TraingDataPath))
            {
                throw new Exception("File Not found");
            }

            while ((line = reader.ReadLine()) != null)
            {
                int firstIndex = line.IndexOf(',');
                int currentLabel = Convert.ToInt32(line.Substring(0, firstIndex));
                string currentData = line.Substring(firstIndex + 1);
                float[] data = currentData.Split(',').Select(x => float.Parse(x)).ToArray();

                trainList.Add(data);
                trainLabel.Add(currentLabel);

            }

            TrainData = new Matrix<float>(To2D<float>(trainList.ToArray()));
            TrainLabel = new Matrix<int>(trainLabel.ToArray());

        }
        private void LoadTestData()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TestDataPath = dialog.FileName;
            }

            else { MessageBox.Show("Test File Error"); return; }
            List<float[]> trainList = new List<float[]>();
            List<int> trainLabel = new List<int>();

            StreamReader reader = new StreamReader(TestDataPath);

            string line = "";
            if (!File.Exists(TestDataPath))
            {
                throw new Exception("Test File Not found");
            }

            while ((line = reader.ReadLine()) != null)
            {
                int firstIndex = line.IndexOf(',');
                int currentLabel = Convert.ToInt32(line.Substring(0, firstIndex));
                string currentData = line.Substring(firstIndex + 1);
                float[] data = currentData.Split(',').Select(x => float.Parse(x)).ToArray();

                trainList.Add(data);
                trainLabel.Add(currentLabel);

            }

            TestData = new Matrix<float>(To2D<float>(trainList.ToArray()));
            TestLabel = new Matrix<int>(trainLabel.ToArray());

        }
        private T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }

        private void trainSVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Svm_Model frmModel = new frm_Svm_Model(this, svm=new SVM());
                frmModel.ShowDialog();

           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void testSVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TestData == null)
            {
                return;
            }

            if (svm == null)
            {
                return;
            }
            try
            {
                int counter = 0;
                for (int i = 0; i < TestData.Rows; i++)
                {
                    Matrix<float> row = TestData.GetRow(i);
                    float predict = svm.Predict(row);
                    if (IsDisplayImage)
                    {
                        Image<Gray, byte> imgout = TrainData.GetRow(i).Mat.Reshape(0, 28).ToImage<Gray, byte>().ThresholdBinary(new Gray(30), new Gray(255));
                        pictureBox1.Image = imgout.AsBitmap();
                        lblInput.Text = "Input Label:" + TestLabel[i, 0].ToString();
                        lblPredict.Text = "Predicted Label" + predict.ToString();
                    }
                   
                    if (predict == TestLabel[i, 0])
                    {
                        counter += 1;
                    }

                    if (IsDisplayImage == true)
                    {
                        Image<Gray, byte> imgout = TestData.GetRow(i).Mat.Reshape(0, 28).ToImage<Gray, byte>().ThresholdBinary(new Gray(30), new Gray(255));
                        pictureBox1.Image = imgout.AsBitmap();
                        await Task.Delay(1);
                    }
                    else
                    {
                        await Task.Delay(1);
                    }
                }

                lblAccuracy.Text = "Accuracy = " + (counter / (float)(TestData.Rows));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TrainData == null)
            {
                return;
            }

            if (Counter >= 0)
            {

                Image<Gray, byte> imgout = TrainData.GetRow(Counter).Mat.Reshape(0, 28).ToImage<Gray, byte>().ThresholdBinary(new Gray(30), new Gray(255));
                pictureBox1.Image = imgout.AsBitmap();
                Counter--;

            }
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TrainData == null)
            {
                return;
            }

            if (Counter < TrainData.Rows - 1)
            {
                Counter++;

                Image<Gray, byte> imgout = TrainData.GetRow(Counter).Mat.Reshape(0, 28).ToImage<Gray, byte>().ThresholdBinary(new Gray(30), new Gray(255));
                pictureBox1.Image = imgout.AsBitmap();
            }
        }

        private void chckBoxDisplay_CheckedChanged(object sender, EventArgs e)
        {
            IsDisplayImage = chckBoxDisplay.Checked;
        }

        private void trainDataLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTrainData();
                
                MessageBox.Show("Train Data loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void testDataLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                LoadTestData();
                MessageBox.Show("Test Data loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readTrainedSVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                SvmDialog frmDialog = new SvmDialog(this);
                OpenFileDialog dialog = new OpenFileDialog();
                //dialog.Filter = "*.txt|.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    svm = new SVM();
                    FileStorage fs = new FileStorage(dialog.FileName, FileStorage.Mode.Read);  
                    svm.Read(fs.GetRoot());
                    fs.ReleaseAndGetString();
                    MessageBox.Show("Read  Trained SVM");

          

                }
                else
                {
                    MessageBox.Show("Error");
                }
               
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
           
         
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
