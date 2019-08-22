
using System.Drawing;

using System.Windows.Forms;

namespace AlarmForm
    {
    class MyTextBox : TextBox
        {
        private static int id = 0;
        public bool backgroundIsRed = false;
        private MyTimers timers;
        private MyProgressBar progressBar;
        private Form form;

        public MyTextBox( MyForm form)
            {
            this.form = form;
            progressBar = new MyProgressBar(form);
            timers = new MyTimers(form, progressBar, this);
            Name = "textBox" + id;
            Size = new Size(76, 22);
            TabIndex = 5;
            KeyDown += new KeyEventHandler(KeyDownHandler);
            Location = new Point(9, 10 + 22 * id);
            form.Controls.Add(this);
            Focus();
            id++;
            }
        private void KeyDownHandler(object sender, KeyEventArgs e)
            {
            if (backgroundIsRed)
                {
                BackColor = Color.White;
                backgroundIsRed = false;
                }

            if (e.KeyCode == Keys.Enter)
                {
                string textContainsTime = ((TextBox)sender).Text;
                AlarmGears alarmGears = new AlarmGears((MyTextBox)sender);
                if (textContainsTime.Equals("") || textContainsTime == null || textContainsTime.Equals("0")) return;
                int continuance = alarmGears.getContinuenseOfTimers(textContainsTime);
                if (continuance <= 0) return;
                progressBar.Maximum = continuance - 1;
                timers.Start(continuance);
                }
            }

        internal void Up()
            {
            Location = new Point(Location.X, Location.Y - 22);
            progressBar.Up();
            form.PerformLayout();
            }

        public void Close()
            {
            id--;
            MyProgressBar.id--;
            timers.Del();
            form.Controls.Remove(progressBar);
            form.Controls.Remove(this);
            progressBar.Dispose();
            progressBar = null;
            timers = null;
            this.Dispose();
            }
        public void ChangeBackgroundForRed()
            {
            BackColor = Color.Red;
            backgroundIsRed = true;
            }
        public void changeAndDisable(string text) {
           Text = text;
           Enabled = false;
            }
        }
    
    }
