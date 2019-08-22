using System;

using System.Windows.Forms;

namespace AlarmForm
    {
    class AddButton : Button
        {
        private MyForm form;
        private MyTextBox textBox;

        public AddButton(MyForm form1)
            {

            form = form1;
            Initiate();
            }
        private void Initiate()
            {
            BackgroundImage = global::AlarmForm.Properties.Resources.addPng;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Location = new System.Drawing.Point(515, 10);
            Name = "Add";
            Size = new System.Drawing.Size(20, 20);
            TabIndex = 7;
            /*Text = "+";*/
            UseVisualStyleBackColor = true;
            Click += new EventHandler(AddButton_Click);
            form.Controls.Add(this);
            }
        private void AddButton_Click(object sender, EventArgs e)
            {
            form.Height += 22;
            textBox = new MyTextBox( form);
            new DelButton(form, textBox);
            }


        }
    }
