namespace emgu.CV_Toolbox.Machine_Learning_PL
{
    partial class frm_Svm_Model
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSVMType = new System.Windows.Forms.ComboBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGamma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKernelType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtGamma);
            this.panel1.Controls.Add(this.txtC);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbKernelType);
            this.panel1.Controls.Add(this.cmbSVMType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 273);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paramater C :";
            // 
            // cmbSVMType
            // 
            this.cmbSVMType.FormattingEnabled = true;
            this.cmbSVMType.Location = new System.Drawing.Point(289, 98);
            this.cmbSVMType.Name = "cmbSVMType";
            this.cmbSVMType.Size = new System.Drawing.Size(202, 24);
            this.cmbSVMType.TabIndex = 1;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(289, 24);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(202, 22);
            this.txtC.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Paramater Gamma Of Kernel Func :";
            // 
            // txtGamma
            // 
            this.txtGamma.Location = new System.Drawing.Point(289, 61);
            this.txtGamma.Name = "txtGamma";
            this.txtGamma.Size = new System.Drawing.Size(202, 22);
            this.txtGamma.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "SVM Type :";
            // 
            // cmbKernelType
            // 
            this.cmbKernelType.FormattingEnabled = true;
            this.cmbKernelType.Location = new System.Drawing.Point(289, 141);
            this.cmbKernelType.Name = "cmbKernelType";
            this.cmbKernelType.Size = new System.Drawing.Size(202, 24);
            this.cmbKernelType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kernel Type :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_Svm_Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 302);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Svm_Model";
            this.Text = "frm_Svm_Model";
            this.Load += new System.EventHandler(this.frm_Svm_Model_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.ComboBox cmbSVMType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtGamma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKernelType;
    }
}