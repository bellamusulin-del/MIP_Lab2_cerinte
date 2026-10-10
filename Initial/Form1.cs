using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab2_Ex1
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private volatile bool running = false;
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
            if (running)
            {
                return;
            }

            running = true;
            thread = new Thread(run);
            thread.IsBackground = true;
            thread.Start();
        }

        private void run()
        {
            while (running)
            {
                if (IsDisposed || !IsHandleCreated)
                {
                    break;
                }

                try
                {
                    BeginInvoke(new Action(moveText));
                }
                catch (InvalidOperationException)
                {
                    break;
                }

                Thread.Sleep(100);
            }
        }

        private void moveText()
        {
            if (!running)
            {
                return;
            }

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

        private void buttonStop_Click(object sender, EventArgs e)
        {
            running = false;
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
