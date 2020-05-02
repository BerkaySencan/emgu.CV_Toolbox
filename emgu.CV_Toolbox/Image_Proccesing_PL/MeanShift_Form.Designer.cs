namespace emgu.CV_Toolbox.Image_Proccesing
{
    partial class MeanShift_Form
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
            this.components = new System.ComponentModel.Container();
            this.ımageBox1 = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ımageBox1
            // 
            this.ımageBox1.Location = new System.Drawing.Point(47, 58);
            this.ımageBox1.Name = "ımageBox1";
            this.ımageBox1.Size = new System.Drawing.Size(472, 418);
            this.ımageBox1.TabIndex = 2;
            this.ımageBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(695, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 69);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MeanShift_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 533);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ımageBox1);
            this.Name = "MeanShift_Form";
            this.Text = "MeanShift_Form";
            this.Load += new System.EventHandler(this.MeanShift_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox ımageBox1;
        private System.Windows.Forms.Button button1;
    }
}