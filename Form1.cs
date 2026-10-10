using Lab2_MIP_Final;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2_MIP_Final
{
    public partial class Form1 : Form
    {
        private MyThread worker;
        private int x = 50;
        private int y = 150;
        private Color textColor = Color.Black;

        private BooleanSwitch logSwitch =
            new BooleanSwitch("Logare", "Logarea deplasarilor");

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                return;
            }

            worker = new MyThread(RequestMove);
            worker.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.Stop();
                worker = null;
            }
        }

        public void RequestMove()
        {
            if (IsDisposed || !IsHandleCreated)
            {
                return;
            }

            try
            {
                BeginInvoke(new Action(moveText));
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void moveText()
        {
            x += 10;

            if (x > ClientSize.Width)
            {
                x = -100;
            }

            Invalidate();

            if (logSwitch.Enabled)
            {
                Trace.WriteLine(
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"));
            }
        }

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            colorDialogBackground.Color = BackColor;

            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialogBackground.Color;
            }
        }

        private void buttonTextColor_Click(object sender, EventArgs e)
        {
            colorDialogText.Color = textColor;

            if (colorDialogText.ShowDialog() == DialogResult.OK)
            {
                textColor = colorDialogText.Color;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (SolidBrush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    "Moving text",
                    Font,
                    brush,
                    x,
                    y);
            }
        }
    }
}
