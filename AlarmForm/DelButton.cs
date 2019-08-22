using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AlarmForm
    {
    class DelButton : Button
        {
        private static byte id = 0;
        private Form form;
        static List<DelButton> buttons = new List<DelButton>(5);
        private MyTextBox textBox;

        public DelButton(MyForm form1, MyTextBox textBox)
            {
            id++;
            buttons.Add(this);
            form = form1;
            this.textBox = textBox;
            DelButton_Initiate();
            }

        private void DelButton_Initiate()
            {
            Location = new System.Drawing.Point(515, 10 + id * 22);
            Name = "Del" + id;
            Size = new System.Drawing.Size(20, 20);
            UseVisualStyleBackColor = true;
            BackgroundImage = global::AlarmForm.Properties.Resources.delJpg;
            BackgroundImageLayout = ImageLayout.Stretch;

            Click += new EventHandler(DelButton_Click);
            form.Controls.Add(this);
            }
        private void DelButton_Click(object sender, EventArgs e)
            {
            form.Height -= 22;
            for (int i = buttons.IndexOf(this) + 1; i < buttons.Count; i++)
                {
                buttons[i].textBox.Up();
                buttons[i].Location = new System.Drawing.Point(buttons[i].Location.X, buttons[i].Location.Y - 22);
                }
            id--;
            
           
            textBox.Close();
            form.Controls.Remove(this);
            buttons.Remove(this);
            textBox = null;
            System.GC.Collect();
            }
        }
    }
