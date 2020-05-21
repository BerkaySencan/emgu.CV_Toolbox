using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emgu.CV_Toolbox.Machine_Learning_PL
{
    public partial class frm_Svm_Model : Form
    {
        Support_Vector_Machine _frm;
        SVM _svm;
        public frm_Svm_Model(Support_Vector_Machine frm,SVM svm)
        {
            InitializeComponent();
            _frm = frm;
            _svm = svm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_frm != null)
            {
               SVM.SvmType returnSVMType = (SVM.SvmType)Enum.Parse(typeof(SVM.SvmType), cmbSVMType.Text);
               SVM.SvmKernelType returnKernelType = (SVM.SvmKernelType)Enum.Parse(typeof(SVM.SvmKernelType), cmbKernelType.Text);
                
                _svm.C = double.Parse(txtC.Text);
                _svm.Type = returnSVMType;
                _svm.Gamma = double.Parse(txtGamma.Text);
                _svm.SetKernel(returnKernelType);
                _svm.TermCriteria = new MCvTermCriteria(1000, 1e-6);
                _svm.Train(_frm.TrainData, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, _frm.TrainLabel);


                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "txt|*.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                   
                    FileStorage fs = new FileStorage(dialog.FileName, FileStorage.Mode.Write);
                    _svm.Write(fs);
                    fs.ReleaseAndGetString();
                  
                }
                

                MessageBox.Show("SVM is trained.");
            }
            else
            {
                MessageBox.Show("Null Error");
            }
        }

        private void frm_Svm_Model_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> dictionarySVMType = new Dictionary<string, int>();
            Dictionary<string, int> dictionaryKernelType = new Dictionary<string, int>();


            foreach (int enumValue in
            Enum.GetValues(typeof(SVM.SvmType)))
            {
                dictionarySVMType.Add(Enum.GetName(typeof(SVM.SvmType), enumValue), enumValue);
            }
            cmbSVMType.DisplayMember = "Key"; ;
            cmbSVMType.ValueMember = "Value";
            cmbSVMType.DataSource = new BindingSource(dictionarySVMType, null);

            foreach (int enumValue in
            Enum.GetValues(typeof(SVM.SvmKernelType)))
            {
                dictionaryKernelType.Add(Enum.GetName(typeof(SVM.SvmKernelType), enumValue), enumValue);
            }
            cmbKernelType.DisplayMember = "Key"; ;
            cmbKernelType.ValueMember = "Value";
            cmbKernelType.DataSource = new BindingSource(dictionaryKernelType, null);
        }
    }
}
