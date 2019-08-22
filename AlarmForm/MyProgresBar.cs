
using System.Windows.Forms;

namespace AlarmForm
    {
    class MyProgressBar : ProgressBar
        {
        public static byte id = 0;
        public MyProgressBar(Form form)
            {
            Location = new System.Drawing.Point(97, 10 + 22 * id);
            TabIndex = 6;
            Name = "progressBar" + id;
            Size = new System.Drawing.Size(414, 19);
            form.Controls.Add(this);
            id++;
            }
        internal void Increment()
            {
            if (Value < Maximum || Value > Minimum)
                Value++;
            }

        internal void Up()
            {

            Location = new System.Drawing.Point(Location.X, Location.Y - 22);

            }
        }

    }
