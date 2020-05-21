using Emgu.CV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emgu.CV_Toolbox.Machine_Learning_BLL
{
    class SVM_Base
    {
        public Matrix<float> TrainData;
        public Matrix<float> TestData;
        public Matrix<int> TrainLabel;
        public Matrix<int> TestLabel;
        public void LoadTrainData(string TrainPath)
        {
            List<float[]> trainList = new List<float[]>();
            List<int> trainLabel = new List<int>();

            StreamReader reader = new StreamReader(TrainPath);

            string line = "";
            if (!File.Exists(TrainPath))
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
    }
}
