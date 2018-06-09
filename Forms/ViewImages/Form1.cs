using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ViewImages
{
    public partial class Form1 : Form
    {
        int pbw, pbh, pbX, pbY; // розмір і положення Picture Box


        string aPath;

        

        public Form1()
        {


            InitializeComponent();

            pbh = pictureBox1.Height;
            pbw = pictureBox1.Width;
            pbX = pictureBox1.Location.X;
            pbY = pictureBox1.Location.Y;

            listBox1.Sorted = true;

            DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            aPath = di.FullName;
            label1.Text = aPath;
            FillListBox(aPath);
        }
        
        private Boolean FillListBox(string aPath)
        {
            DirectoryInfo di = new DirectoryInfo(aPath);
            FileInfo[] fi = di.GetFiles("*.png");
            listBox1.Items.Clear();
            foreach(FileInfo fc in fi)
            {
                listBox1.Items.Add(fc.Name);
            }

            fi = di.GetFiles("*.jpg");
            foreach (FileInfo fc in fi)
            {
                listBox1.Items.Add(fc.Name);
            }

            label1.Text = aPath;
            if (fi.Length == 0) return false;
            else
            {
                listBox1.SelectedIndex = 0;
                return true;
            }
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double mh, mw;

            pictureBox1.Visible = false;
            pictureBox1.Left = pbX;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = new Bitmap(aPath + "\\" + listBox1.SelectedItem.ToString());

            if((pictureBox1.Image.Width > pbw) || (pictureBox1.Image.Height > pbh))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                mh = (double)pbh / (double)pictureBox1.Image.Height;
                mw = (double)pbw / (double)pictureBox1.Image.Width;
                if(mh < mw)
                {
                    pictureBox1.Width = Convert.ToInt16(pictureBox1.Image.Width * mh);
                    pictureBox1.Height = pbh;
                }
                else
                {
                    pictureBox1.Width = pbw;
                    pictureBox1.Height = Convert.ToInt16(pictureBox1.Image.Height * mw);
                }
            }
            pictureBox1.Left = pbX + (pbw - pictureBox1.Width) / 2;
            pictureBox1.Top = pbY + (pbh - pictureBox1.Height) / 2;
            pictureBox1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Выберите папку, \nв какой находятся иллюстрации";
            fb.ShowNewFolderButton = false;
            if(fb.ShowDialog() == DialogResult.OK)
            {
                aPath = fb.SelectedPath;
                label1.Text = aPath;

                if (!FillListBox(fb.SelectedPath))
                    pictureBox1.Image = null;
            } 
        }
    }
}
