using System;

using System.Windows.Forms;

namespace AlarmForm
    {
    class MyTimers
        {
        Timer timer1;
        Timer timer2;
        MyProgressBar progressBar;
        Form form;
        TextBox tb;
        public MyTimers(MyForm form, MyProgressBar myProgres, TextBox textBox)
            {
            this.form = form;
            progressBar = myProgres;
            tb = textBox;
            timer1 = new Timer(form.components);
            timer2 = new Timer(form.components);
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer2.Tick += new EventHandler(Timer2_Tick);
            }
        public Timer Timer { get => timer1; }
        private void Timer1_Tick(object sender, EventArgs e)
            {
            progressBar.Increment();
            }

        private void Timer2_Tick(object sender, EventArgs e)
            {
            form.Activate();
            progressBar.Value = progressBar.Maximum;
            AlarmGears.Bels();
            Stop();
            progressBar.Value = 0;
            tb.Text = "";
            tb.Enabled = true;
            tb.Focus();
            }

        public void Stop()
            {

            timer1.Stop();
            timer2.Stop();
            }
        public void Del()
            {
            timer1.Dispose();
            timer2.Dispose();
            }

        public void Start(int sec)
            {
            timer2.Interval = sec * 1000;
            timer2.Start();
            timer1.Start();
            }

        }
    }
