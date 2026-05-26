using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
    public partial class Form1 : Form
    {
        List<ProgressBar> horses = new List<ProgressBar>();

        List<string> results = new List<string>();

        Random random = new Random();

        int place = 1;

        public Form1()
        {
            InitializeComponent();

            horses.Add(progressBar1);
            horses.Add(progressBar2);
            horses.Add(progressBar3);
            horses.Add(progressBar4);
            horses.Add(progressBar5);

            btnStart.Click += btnStart_Click;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            results.Clear();

            listBox1.Items.Clear();

            place = 1;

            foreach (var horse in horses)
            {
                horse.Value = 0;
            }

            for (int i = 0; i < horses.Count; i++)
            {
                int horseNumber = i + 1;

                ProgressBar currentHorse = horses[i];

                Task.Run(() =>
                {
                    RunHorse(currentHorse, horseNumber);
                });
            }
        }

        void RunHorse(ProgressBar horse, int number)
        {
            while (horse.Value < 100)
            {
                int step = random.Next(1, 10);

                Invoke(new Action(() =>
                {
                    if (horse.Value + step <= 100)
                    {
                        horse.Value += step;
                    }
                    else
                    {
                        horse.Value = 100;
                    }
                }));

                Thread.Sleep(random.Next(100, 300));
            }

            lock (results)
            {
                string result = $"{place} place - Horse #{number}";

                results.Add(result);

                place++;

                Invoke(new Action(() =>
                {
                    listBox1.Items.Add(result);
                }));
            }

            if (results.Count == 5)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Race finished!");
                }));
            }
        }
    }
}