using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games_003_Alarm
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("winmm.dll")]

        private static extern Boolean PlaySound(string lpszName, int hModule, int dwFlags);

        private DateTime alarm;

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = Properties.Resources.icon;
            numericUpDown1.Maximum = 23;
            numericUpDown1.Minimum = 0;

            numericUpDown2.Minimum = 0;
            numericUpDown2.Maximum = 59;

            numericUpDown1.Value = DateTime.Now.Hour;
            numericUpDown2.Value = DateTime.Now.Minute;

            notifyIcon1.Visible = false;

            timer1.Interval = 1000;
            timer1.Enabled = true;

            label2.Text = DateTime.Now.ToLongTimeString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();

            if (checkBox1.Checked)
            {
                if(DateTime.Compare(DateTime.Now,alarm) > 0)
                {
                    checkBox1.Checked = false;
                    PlaySound(Application.StartupPath + "\\ring.wav", 0, 1);
                    Form2 frm = new Form2();

                    frm.label1.Text = DateTime.Now.ToShortTimeString();
                    frm.label2.Text = this.textBox1.Text;

                    frm.ShowDialog();

                    this.Show();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                textBox1.Enabled = false;

                alarm = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt16(numericUpDown1.Value), Convert.ToInt16(numericUpDown2.Value), 0, 0);

                if (DateTime.Compare(DateTime.Now, alarm) > 0) alarm.AddDays(1);
                notifyIcon1.Text = alarm.ToShortTimeString() + "\n" + textBox1.Text;
                button1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;

                notifyIcon1.Text = "Alarm`s not been set.";
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void showhideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Visible) this.Hide();
            else
            {
                this.Show();
                notifyIcon1.Visible = false;
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alarm");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(Control.MousePosition);
        }
    }
}
