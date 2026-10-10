namespace Lab2_MIP_Final
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (worker != null)
                {
                    worker.Stop();
                    worker = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.buttonTextColor = new System.Windows.Forms.Button();
            this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
            this.colorDialogText = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();

            // buttonStart
            this.buttonStart.Location = new System.Drawing.Point(338, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(150, 86);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);

            // buttonStop
            this.buttonStop.Location = new System.Drawing.Point(338, 353);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(150, 75);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);

            // buttonBackground
            this.buttonBackground.Location = new System.Drawing.Point(630, 151);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(146, 75);
            this.buttonBackground.TabIndex = 2;
            this.buttonBackground.Text = "Background color";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);

            // buttonTextColor
            this.buttonTextColor.Location = new System.Drawing.Point(12, 142);
            this.buttonTextColor.Name = "buttonTextColor";
            this.buttonTextColor.Size = new System.Drawing.Size(147, 84);
            this.buttonTextColor.TabIndex = 3;
            this.buttonTextColor.Text = "Text color";
            this.buttonTextColor.UseVisualStyleBackColor = true;
            this.buttonTextColor.Click += new System.EventHandler(this.buttonTextColor_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonBackground);
            this.Controls.Add(this.buttonTextColor);
            this.Name = "Form1";
            this.Text = "Moving Text";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Button buttonTextColor;
        private System.Windows.Forms.ColorDialog colorDialogBackground;
        private System.Windows.Forms.ColorDialog colorDialogText;
    }
}

