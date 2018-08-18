using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_004_CircleChart
{
    public partial class Form1 : Form
    {

        string header;
        int N = 0;

        double[] dat;
        double[] p;

        private string[] title;

        public Form1()
        {
            InitializeComponent();
            try
            {
                System.IO.StreamReader sr;
                sr = new System.IO.StreamReader(Application.StartupPath + "\\data.txt");
                header = sr.ReadLine();
                N = Convert.ToInt16(sr.ReadLine());
                dat = new double[N];
                p = new double[N];
                title = new string[N];

                int i = 0;
                string st = sr.ReadLine();
                while (st != null && i < N)
                {
                    title[i] = st;
                    st = sr.ReadLine();
                    dat[i++] = Convert.ToDouble(st);
                    st = sr.ReadLine();
                }
                sr.Close();

                this.Paint += new PaintEventHandler(Diagram);

                double sum = 0;
                int j = 0;
                for (; j < N; j++)
                    sum += dat[j];
                for (j = 0; j < N; j++)
                    p[j] = (double)(dat[j] / sum);

                this.BackColor = System.Drawing.Color.Azure;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Circle chart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Diagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font hfont = new Font("Tahoma", 12);
            int w = (int)g.MeasureString(header, hfont).Width;
            int x = (this.ClientSize.Width - w) / 2;
            g.DrawString(header, hfont, System.Drawing.Brushes.Black, x, 10);

            Font lfont = new Font("Tahoma", 9);

            int d = ClientSize.Height - 110;
            int x0 = 30;
            int y0 = (ClientSize.Height - d) / 2 + 10;
            int lx = 60 + d;
            int ly = y0 + (d - N * 20 + 10) / 2;

            int swe;
            Brush fbrush = Brushes.White;
            int sta = -90;

            for (int i = 0; i < N; i++)
            {
                swe = (int)(360 * p[i]);
                switch (i)
                {
                    case 0:
                        fbrush = Brushes.YellowGreen; break;
                    case 1:
                        fbrush = Brushes.Gold; break;
                    case 2:
                        fbrush = Brushes.Pink; break;
                    case 3:
                        fbrush = Brushes.Violet; break;
                    case 4:
                        fbrush = Brushes.OrangeRed; break;
                    case 5:
                        fbrush = Brushes.RoyalBlue; break;
                    case 6:
                        fbrush = Brushes.SteelBlue; break;
                    case 7:
                        fbrush = Brushes.Chocolate; break;
                    case 8:
                        fbrush = Brushes.LightGray; break;
                }

                if (i == N - 1)
                    swe = 270 - sta;

                g.FillPie(fbrush, x0, y0, d, d, sta, swe);
                g.DrawPie(System.Drawing.Pens.Black, x0, y0, d, d, sta, swe);

                g.FillRectangle(fbrush, lx, ly + i * 20, 20, 10);
                g.DrawRectangle(System.Drawing.Pens.Black, lx, ly + i * 20, 20, 10);

                g.DrawString(title[i] + " - " + p[i].ToString("P"), lfont, System.Drawing.Brushes.Black, lx + 24, ly + i * 20 - 3);

                sta += swe;
            }
        }
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
