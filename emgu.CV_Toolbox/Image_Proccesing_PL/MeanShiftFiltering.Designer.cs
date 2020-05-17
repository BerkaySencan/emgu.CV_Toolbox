namespace emgu.CV_Toolbox.Image_Proccesing_PL
{
    partial class MeanShiftFiltering
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
            this.lblCWValue = new System.Windows.Forms.Label();
            this.lblSWValue = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudIteration = new System.Windows.Forms.NumericUpDown();
            this.nudMLS = new System.Windows.Forms.NumericUpDown();
            this.tbarCW = new System.Windows.Forms.TrackBar();
            this.tbarSW = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMLS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarCW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSW)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCWValue);
            this.panel1.Controls.Add(this.lblSWValue);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nudIteration);
            this.panel1.Controls.Add(this.nudMLS);
            this.panel1.Controls.Add(this.tbarCW);
            this.panel1.Controls.Add(this.tbarSW);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 342);
            this.panel1.TabIndex = 0;
            // 
            // lblCWValue
            // 
            this.lblCWValue.AutoSize = true;
            this.lblCWValue.Location = new System.Drawing.Point(513, 85);
            this.lblCWValue.Name = "lblCWValue";
            this.lblCWValue.Size = new System.Drawing.Size(46, 17);
            this.lblCWValue.TabIndex = 4;
            this.lblCWValue.Text = "label5";
            // 
            // lblSWValue
            // 
            this.lblSWValue.AutoSize = true;
            this.lblSWValue.Location = new System.Drawing.Point(513, 23);
            this.lblSWValue.Name = "lblSWValue";
            this.lblSWValue.Size = new System.Drawing.Size(46, 17);
            this.lblSWValue.TabIndex = 4;
            this.lblSWValue.Text = "label5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 66);
            this.button1.TabIndex = 3;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Iteration :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Maximum level Segmentation :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color Window :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spatial Window :";
            // 
            // nudIteration
            // 
            this.nudIteration.Location = new System.Drawing.Point(253, 198);
            this.nudIteration.Name = "nudIteration";
            this.nudIteration.Size = new System.Drawing.Size(254, 22);
            this.nudIteration.TabIndex = 1;
            // 
            // nudMLS
            // 
            this.nudMLS.Location = new System.Drawing.Point(253, 147);
            this.nudMLS.Name = "nudMLS";
            this.nudMLS.Size = new System.Drawing.Size(254, 22);
            this.nudMLS.TabIndex = 1;
            // 
            // tbarCW
            // 
            this.tbarCW.Location = new System.Drawing.Point(241, 85);
            this.tbarCW.Name = "tbarCW";
            this.tbarCW.Size = new System.Drawing.Size(266, 56);
            this.tbarCW.TabIndex = 0;
            this.tbarCW.Scroll += new System.EventHandler(this.tbarCW_Scroll);
            // 
            // tbarSW
            // 
            this.tbarSW.Location = new System.Drawing.Point(241, 23);
            this.tbarSW.Name = "tbarSW";
            this.tbarSW.Size = new System.Drawing.Size(266, 56);
            this.tbarSW.TabIndex = 0;
            this.tbarSW.Scroll += new System.EventHandler(this.tbarSW_Scroll);
            // 
            // MeanShiftFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 386);
            this.Controls.Add(this.panel1);
            this.Name = "MeanShiftFiltering";
            this.Text = "MeanShiftFiltering";
            this.Load += new System.EventHandler(this.MeanShiftFiltering_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMLS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarCW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMLS;
        private System.Windows.Forms.TrackBar tbarSW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudIteration;
        private System.Windows.Forms.TrackBar tbarCW;
        private System.Windows.Forms.Label lblCWValue;
        private System.Windows.Forms.Label lblSWValue;
    }
}