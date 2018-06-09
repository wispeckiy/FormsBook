using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jalousie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            List<string> TypesList = new List<string> { "Пластик", "Алюминий", "Бамбук", "Соломка", "Текстиль" };
            comboBox1.DataSource = TypesList;


            //string[] TypesArray = {"Пластик", "Алюминий", "Бамбук", "Соломка", "Текстиль" };
            //comboBox1.Items.AddRange(TypesArray);


            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1)) textBox2.Focus();
                    else comboBox1.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else button1.Enabled = true;
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double w;
            double h;
            double price = 0;
            double sum;
            w = Convert.ToDouble(textBox1.Text);
            h = Convert.ToDouble(textBox2.Text);

            switch (comboBox1.SelectedIndex)
            {
                case 0: price = 50; break;
                case 1: price = 100; break;
                case 2: price = 75; break;
                case 3: price = 70; break;
                case 4: price = 60; break;
            }

            sum = (w * h) / 10000 * price;
            label4.Text = "Размер: " + w + "x" + h + "см. \n"
                + "Цена(грн./кв.м): " + price.ToString("C")
                + "\nСумма: " + sum.ToString("C");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = "";
        }
    }
}
