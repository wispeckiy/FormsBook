using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_004_Fly
{
    public partial class Form1 : Form
    {
        System.Drawing.Bitmap sky, plane;
        Graphics g;
        int dx1, dx2;

        Rectangle rct1, rct2;

        int count1 = 0, count2 = 0;

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(("1 plane: " + count1 + "\n2 plane: " + count2), "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        System.Random rnd;

        private void timer2_Tick(object sender, EventArgs e)
        {
            g.DrawImage(sky, new Point(0, 0));
            if (rct1.X < this.ClientRectangle.Width) rct1.X += dx1;
            else
            {
                rct1.X = -40;
                rct1.Y = 20 + rnd.Next(40);
                dx1 = rnd.Next(7, 12);
                count1++;
            }

            g.DrawImage(plane, rct1.X, rct1.Y);
            
            if (rct2.X < this.ClientRectangle.Width) rct2.X += dx2;
            else
            {
                rct2.X = -40;
                rct2.Y = rct1.Y + plane.Height + (ClientSize.Height - 100) / 2;
                dx2 = rnd.Next(7,12);
                count2++;
            }
            
            g.DrawImage(plane, rct2.X, rct2.Y);
            Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
            g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
            this.Invalidate(reg);
        }

        public Form1()
        {
            InitializeComponent();

            try
            {
                sky = Properties.Resources.sky;
                plane = Properties.Resources.plane;
                this.BackgroundImage = Properties.Resources.sky;
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            plane.MakeTransparent();
            this.ClientSize = new System.Drawing.Size(new Point(BackgroundImage.Width, BackgroundImage.Height));
            g = Graphics.FromImage(BackgroundImage);
            rnd = new System.Random();

            rct1.X = -40;
            rct1.Y = 20 + rnd.Next(20);
            rct1.Width = plane.Width;
            rct1.Height = plane.Height;

            rct2.X = -40;
            rct2.Y = rct1.Y + plane.Height + (ClientSize.Height - 100)/ 2;
            rct2.Width = rct1.Width;
            rct2.Height = rct1.Height;
            dx1 = rnd.Next(7, 12);
            dx2 = rnd.Next(7, 12);
            timer2.Interval = 1;
            timer2.Enabled = true;
        }
    }
}
