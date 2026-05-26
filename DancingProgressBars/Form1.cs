using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DancingProgressBars
{
    public partial class Form1 : Form
    {
        List<ProgressBar> bars = new List<ProgressBar>();

        Random random = new Random();

        bool stop = false;

        ManualResetEvent pauseEvent = new ManualResetEvent(true);

        public Form1()
        {
            InitializeComponent();

            btnCreate.Click += btnCreate_Click;
            btnStart.Click += btnStart_Click;
            btnPause.Click += btnPause_Click;
            btnResume.Click += btnResume_Click;
            btnStop.Click += btnStop_Click;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            bars.Clear();

            int count = (int)numericUpDown1.Value;

            for (int i = 0; i < count; i++)
            {
                ProgressBar bar = new ProgressBar();

                bar.Width = 400;
                bar.Height = 30;

                bar.Maximum = 100;

                bar.Left = 20;
                bar.Top = i * 40;

                panel1.Controls.Add(bar);

                bars.Add(bar);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            stop = false;

            pauseEvent.Set();

            foreach (var bar in bars)
            {
                bar.Value = 0;

                Task.Run(() =>
                {
                    FillBar(bar);
                });
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            pauseEvent.Reset();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            pauseEvent.Set();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        void FillBar(ProgressBar bar)
        {
            while (bar.Value < 100)
            {
                if (stop)
                {
                    break;
                }

                pauseEvent.WaitOne();

                int step = random.Next(1, 10);

                Invoke(new Action(() =>
                {
                    if (bar.Value + step <= 100)
                    {
                        bar.Value += step;
                    }
                    else
                    {
                        bar.Value = 100;
                    }
                }));

                Thread.Sleep(random.Next(100, 400));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}