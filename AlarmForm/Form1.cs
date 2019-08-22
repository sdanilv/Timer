using System;
using System.Windows.Forms;

namespace AlarmForm
    {
    public partial class MyForm : Form
        {
        public MyForm()
            {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            Text = "SuperAlarm";
            Icon = Properties.Resources.alarm;
            this.ClientSize = new System.Drawing.Size(540, 42);
            new AddButton(this);
            new MyTextBox(this);
            this.ResumeLayout(false);
            this.PerformLayout();
            }
        }
    }
