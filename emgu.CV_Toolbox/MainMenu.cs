using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emgu.CV_Toolbox.Image_Processing_BLL;

namespace emgu.CV_Toolbox
{
    public partial class MainMenu : Form
    {
        Mean_Shift MN = new Mean_Shift();

        public MainMenu()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private Form activeForm = null;
        private void hideSubMenu()
        {
            panelImageProcessing.Visible = false;
            panelMachinLearning.Visible = false;
            panelToolsSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnImageProcessing_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelImageProcessing);
        }

        #region ImageProccesingSubMenu

        private void btn_Image_1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Image_Proccesing.ImageProccesing_Main());
            //..
            //your codes
            //..
            hideSubMenu();
            
        }

        private void btn_Image_2_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Image_Proccesing.Image_Processing_Main());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btn_Image_3_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btn_Image_4_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }



        #endregion
        private void btnMachineLearning_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelMachinLearning);
        }


        #region MachineLearningSubMenu
        private void btn_Machine_1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Machine_Learning.MachineLearning_Main());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btn_Machine_2_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btn_Machine_3_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btn_Machine_4_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion
        private void btnTools_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelToolsSubMenu);
        }

        #region ToolsSubMenu
        private void button13_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
     
   
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
