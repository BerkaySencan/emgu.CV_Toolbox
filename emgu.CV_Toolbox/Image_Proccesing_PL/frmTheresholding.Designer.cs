namespace emgu.CV_Toolbox.Image_Proccesing_PL
{
    partial class frmTheresholding
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
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.lblThValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbarMaxValue = new System.Windows.Forms.TrackBar();
            this.tbarThershold = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarThershold)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblMaxValue);
            this.panel1.Controls.Add(this.lblThValue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbarMaxValue);
            this.panel1.Controls.Add(this.tbarThershold);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 288);
            this.panel1.TabIndex = 0;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(184, 150);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(212, 24);
            this.cmbType.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 68);
            this.button1.TabIndex = 2;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Location = new System.Drawing.Point(485, 80);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(46, 17);
            this.lblMaxValue.TabIndex = 1;
            this.lblMaxValue.Text = "label1";
            // 
            // lblThValue
            // 
            this.lblThValue.AutoSize = true;
            this.lblThValue.Location = new System.Drawing.Point(485, 31);
            this.lblThValue.Name = "lblThValue";
            this.lblThValue.Size = new System.Drawing.Size(46, 17);
            this.lblThValue.TabIndex = 1;
            this.lblThValue.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 157);
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
            this.label2.Text = "Max Value :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Threshold :";
            // 
            // tbarMaxValue
            // 
            this.tbarMaxValue.Location = new System.Drawing.Point(153, 80);
            this.tbarMaxValue.Name = "tbarMaxValue";
            this.tbarMaxValue.Size = new System.Drawing.Size(243, 56);
            this.tbarMaxValue.TabIndex = 0;
            this.tbarMaxValue.Scroll += new System.EventHandler(this.tbarMaxValue_Scroll);
            // 
            // tbarThershold
            // 
            this.tbarThershold.Location = new System.Drawing.Point(153, 18);
            this.tbarThershold.Name = "tbarThershold";
            this.tbarThershold.Size = new System.Drawing.Size(243, 56);
            this.tbarThershold.TabIndex = 0;
            this.tbarThershold.Scroll += new System.EventHandler(this.tbarThershold_Scroll);
            // 
            // frmTheresholding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 327);
            this.Controls.Add(this.panel1);
            this.Name = "frmTheresholding";
            this.Text = "frmTheresholding";
            this.Load += new System.EventHandler(this.frmTheresholding_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarThershold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.Label lblThValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbarMaxValue;
        private System.Windows.Forms.TrackBar tbarThershold;
    }
}