using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2_MIP_Final
{
    public partial class Form1 : Form
    {
        // The thread object that moves the text (managed by the MyThread class)
        private MyThread worker;

        // Current position of the moving text
        private int textPositionX = 50;
        private int textPositionY = 250;

        // Current color of the moving text
        private Color textColor = Color.Black;

        // Switch that turns logging on/off, its value comes from App.config
        private BooleanSwitch logSwitch =
            new BooleanSwitch("Logare", "Logarea deplasarilor");

        public Form1()
        {
            InitializeComponent();
        }

        // Start button: creates and starts the thread
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // If the thread is already running, do nothing
            if (worker != null)
            {
                return;
            }

            // Variant 1: MyThread calls the method through a reference to Form1
            // worker = new MyThread(this);

            // Variant 2: MyThread calls the method through a delegate
            worker = new MyThread(RequestMove);

            worker.Start();
        }

        // Stop button: stops the thread
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.Stop();
                worker = null;
            }
        }

        // Called from the worker thread, so the move must be sent to the UI thread
        public void RequestMove()
        {
            // Do not touch the form if it is closing or has no window yet
            if (IsDisposed || !IsHandleCreated)
            {
                return;
            }

            try
            {
                // Run moveText on the UI thread
                BeginInvoke(new Action(moveText));
            }
            catch (InvalidOperationException)
            {
                // The form was closed while the call was being made, ignore it
            }
        }

        // Moves the text to the right and logs the time (runs on the UI thread)
        private void moveText()
        {
            textPositionX += 10;

            // If the text left the window on the right, put it back on the left
            if (textPositionX > ClientSize.Width)
            {
                textPositionX = -100;
            }

            // Ask the form to redraw itself
            Invalidate();

            // Write the time of the move to the trace file, only if logging is on
            if (logSwitch.Enabled)
            {
                string currentTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
                Trace.WriteLine(currentTime);
            }
        }

        // Background color button: opens the color dialog
        private void buttonBackground_Click(object sender, EventArgs e)
        {
            colorDialogBackground.Color = BackColor;

            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialogBackground.Color;
            }
        }

        // Text color button: opens the color dialog
        private void buttonTextColor_Click(object sender, EventArgs e)
        {
            colorDialogText.Color = textColor;

            if (colorDialogText.ShowDialog() == DialogResult.OK)
            {
                textColor = colorDialogText.Color;
                Invalidate();
            }
        }

        // Draws the moving text on the form
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    "Moving text",
                    Font,
                    textBrush,
                    textPositionX,
                    textPositionY);
            }
        }
    }
}
