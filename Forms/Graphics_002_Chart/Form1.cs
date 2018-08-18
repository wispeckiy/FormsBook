using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_002_Chart
{
    public partial class Form1 : Form
    {
        private double[] d;
        private void drawDiagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font dFont = new Font("Tahoma", 9);
            Font hFont = new Font("Tahoma", 14, FontStyle.Regular);
            string header = "Зміна курсу долара.";
            int wh = (int)g.MeasureString(header, hFont).Width;
            int x = (this.ClientSize.Width - wh) / 2;
            g.DrawString(header, hFont, System.Drawing.Brushes.DarkGreen, x, 5);
            double max = d[0];
            double min = d[0];
            for (int i = 1; i < d.Length; i++)
            {
                if (d[i] > max) max = d[i];
                if (d[i] < min) min = d[i];
            }
            int x1, y1;
            int w, h;

            w = (this.Size.Width - 10 - 80) / d.Length;
            x1 = 20;
            for (int i = 0; i < d.Length; i++)
            {
                y1 = this.ClientSize.Height - 20 - (int)((this.ClientSize.Height - 100) * (d[i] - min) / (max - min));
                g.DrawString(Convert.ToString(d[i]), dFont, System.Drawing.Brushes.Black, x1, y1 - 20);
                h = ClientSize.Height - y1 - 20 + 1;
                g.FillRectangle(Brushes.ForestGreen, x1, y1, w, h);
                g.DrawRectangle(System.Drawing.Pens.Black, x1, y1, w, h);
                x1 = x1 + w + 5;
            }
        }
        public Form1()
        {
            InitializeComponent();
            System.IO.StreamReader sr;
            try
            {
                sr = new System.IO.StreamReader(Application.StartupPath + @"\usd.txt");
                
                d = new double[10];
                int i = 0;
                string t = sr.ReadLine();
                while ((t != null) && (i < d.Length))
                {
                    d[i++] = Convert.ToDouble(t);
                    t = sr.ReadLine();
                }
                sr.Close();
                this.Paint += new PaintEventHandler(drawDiagram);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\n" + "(" + ex.GetType().ToString() + ")", "График", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
            private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
