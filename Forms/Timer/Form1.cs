using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        private DateTime t1, t2;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0 && numericUpDown2.Value == 0) button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                t1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                t2 = t1.AddMinutes((double)numericUpDown1.Value);
                t2 = t2.AddSeconds((double)numericUpDown2.Value);
                groupBox1.Enabled = false;
                button1.Text = "Стоп";
                if(t2.Minute < 9)
                {
                    label1.Text = "0" + t2.Minute.ToString() + ": ";
                }
                else label1.Text = t2.Minute.ToString() + ": ";
                if (t2.Second < 9)
                {
                    label1.Text += "0" + t2.Second.ToString();
                }
                else label1.Text += t2.Second.ToString();
                timer1.Interval = 1000;
                timer1.Enabled = true;
                groupBox1.Visible = false;
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = t2.Minute;
                numericUpDown2.Value = t2.Second;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t2 = t2.AddSeconds(-1);
            if (t2.Minute < 9) label1.Text = "0" + t2.Minute.ToString() + ":";
            else label1.Text = t2.Minute.ToString() + ":";
            if (t2.Second < 9) label1.Text += "0" + t2.Second.ToString();
            else label1.Text += t2.Second.ToString();
            if (Equals(t1, t2))
            {
                timer1.Enabled = false;
                MessageBox.Show("Заданий інтервал часу сплив.", "Таймер", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;

            }
        }

        public Form1()
        {
            InitializeComponent();
            
            numericUpDown1.Maximum = 59;
            numericUpDown1.Minimum = 0;
            numericUpDown1.TabStop = false;

            numericUpDown2.Maximum = 59;
            numericUpDown2.Minimum = 0;
            numericUpDown2.TabStop = false;

            button1.Enabled = false;
        }
    }
}
