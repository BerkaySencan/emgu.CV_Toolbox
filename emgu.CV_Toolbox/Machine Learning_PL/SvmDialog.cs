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
    public partial class SvmDialog : Form
    {
        Support_Vector_Machine _frm;
        public SvmDialog(Support_Vector_Machine frm)
        {
            InitializeComponent();
            _frm = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _frm.Node = textBox1.Text;
        }
    }
}
