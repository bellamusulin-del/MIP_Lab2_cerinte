using System;
using System.Threading;

namespace Lab2_MIP_Final
{
    public delegate void MoveDelegate();

    public class MyThread
    {
        private Thread thread;
        private volatile bool running;
        private MoveDelegate move;

        public MyThread(MoveDelegate move)
        {
            this.move = move;
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
                move();
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
