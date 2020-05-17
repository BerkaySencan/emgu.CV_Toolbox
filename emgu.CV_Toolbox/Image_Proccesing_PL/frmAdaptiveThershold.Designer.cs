namespace emgu.CV_Toolbox.Image_Proccesing_PL
{
    partial class frmAdaptiveThershold
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
            this.cmbThType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblBlockSize = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbarBlockSize = new System.Windows.Forms.TrackBar();
            this.tbarMax = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAdaptiveType = new System.Windows.Forms.ComboBox();
            this.nudParamater = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParamater)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudParamater);
            this.panel1.Controls.Add(this.cmbAdaptiveType);
            this.panel1.Controls.Add(this.cmbThType);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblBlockSize);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblMax);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbarBlockSize);
            this.panel1.Controls.Add(this.tbarMax);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 366);
            this.panel1.TabIndex = 1;
            // 
            // cmbThType
            // 
            this.cmbThType.FormattingEnabled = true;
            this.cmbThType.Location = new System.Drawing.Point(227, 134);
            this.cmbThType.Name = "cmbThType";
            this.cmbThType.Size = new System.Drawing.Size(212, 24);
            this.cmbThType.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 68);
            this.button1.TabIndex = 2;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblBlockSize
            // 
            this.lblBlockSize.AutoSize = true;
            this.lblBlockSize.Location = new System.Drawing.Point(485, 80);
            this.lblBlockSize.Name = "lblBlockSize";
            this.lblBlockSize.Size = new System.Drawing.Size(46, 17);
            this.lblBlockSize.TabIndex = 1;
            this.lblBlockSize.Text = "label1";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(485, 31);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(46, 17);
            this.lblMax.TabIndex = 1;
            this.lblMax.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Thershold Type :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Block Size :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max Value :";
            // 
            // tbarBlockSize
            // 
            this.tbarBlockSize.Location = new System.Drawing.Point(196, 76);
            this.tbarBlockSize.Name = "tbarBlockSize";
            this.tbarBlockSize.Size = new System.Drawing.Size(243, 56);
            this.tbarBlockSize.TabIndex = 0;
            this.tbarBlockSize.Scroll += new System.EventHandler(this.tbarBlockSize_Scroll);
            // 
            // tbarMax
            // 
            this.tbarMax.Location = new System.Drawing.Point(196, 14);
            this.tbarMax.Name = "tbarMax";
            this.tbarMax.Size = new System.Drawing.Size(243, 56);
            this.tbarMax.TabIndex = 0;
            this.tbarMax.Scroll += new System.EventHandler(this.tbarMax_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Adaptive Thershold Type :";
            // 
            // cmbAdaptiveType
            // 
            this.cmbAdaptiveType.FormattingEnabled = true;
            this.cmbAdaptiveType.Location = new System.Drawing.Point(227, 182);
            this.cmbAdaptiveType.Name = "cmbAdaptiveType";
            this.cmbAdaptiveType.Size = new System.Drawing.Size(212, 24);
            this.cmbAdaptiveType.TabIndex = 3;
            // 
            // nudParamater
            // 
            this.nudParamater.Location = new System.Drawing.Point(227, 228);
            this.nudParamater.Name = "nudParamater";
            this.nudParamater.Size = new System.Drawing.Size(212, 22);
            this.nudParamater.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Paramater  :";
            // 
            // frmAdaptiveThershold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 384);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdaptiveThershold";
            this.Text = "frmAdaptiveThershold";
            this.Load += new System.EventHandler(this.frmAdaptiveThershold_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParamater)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbThType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblBlockSize;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbarBlockSize;
        private System.Windows.Forms.TrackBar tbarMax;
        private System.Windows.Forms.ComboBox cmbAdaptiveType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudParamater;
        private System.Windows.Forms.Label label5;
    }
}