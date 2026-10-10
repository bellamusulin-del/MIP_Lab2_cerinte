using System;
using System.Threading;

namespace Lab2_MIP_Initial_2
{
    public class MyThread
    {
        private Thread thread;
        private volatile bool running;
        private Form1 form;

        public MyThread(Form1 form)
        {
            this.form = form;
        }

        public void Start()
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
                form.RequestMove();
                Thread.Sleep(100);
            }
        }

        public void Stop()
        {
            running = false;

            if (thread != null && thread.IsAlive)
            {
                thread.Join(500);
            }
        }
    }
}

