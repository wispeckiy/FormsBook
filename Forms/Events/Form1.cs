using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        private void click(object sender, EventArgs e) 
        {
            Console.WriteLine("Event: Click");
        }

        private void resize(object sender, EventArgs e)
        {
            Console.WriteLine("Event: Resize");
        }
        private void resize_Begin(object sender, EventArgs e)
        {
            Console.WriteLine("Event: resize begin");
        }
        private void resize_End(object sender, EventArgs e)
        {
            Console.WriteLine("Event: resize end");
        }

        private void load(object sender, EventArgs e)
        {
            Console.WriteLine("Form loaded.");
        }
        private void form_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Form closed.");
        }

        private void form_LanguageChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Event: language changed.");
        }
        private void scroll(object sender, EventArgs e)
        {
            Console.WriteLine("Event: scroll");
        }
    }
}
