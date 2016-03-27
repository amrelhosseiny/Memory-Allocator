using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {

        int x = 1;
        

        public Form1()
        {
            InitializeComponent();
            label2.Text = "1";
            button1.Enabled = false;
            variables.alloc = new allocator();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int start = int.Parse(textBox1.Text);
            int size = int.Parse(textBox2.Text);
            variables.alloc.addHole(new hole(start, size));
            textBox1.Text = "";
            textBox2.Text = "";
            x = x + 1;
            label2.Text = x.ToString();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled)
            {
                int start = int.Parse(textBox1.Text);
                int size = int.Parse(textBox2.Text);
                variables.alloc.addHole(new hole(start, size));
            }
            this.Hide();
            enterProcess eP = new enterProcess();
            eP.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int o;
            if (int.TryParse(textBox1.Text, out o) && int.TryParse(textBox2.Text, out o) && textBox1.Text != "" && textBox2.Text != ""&& int.Parse(textBox1.Text)>=0&& int.Parse(textBox2.Text)>=0)
                button1.Enabled = true;
             else button1.Enabled = false;
        }  
      

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int o;
            if (int.TryParse(textBox1.Text, out o) && int.TryParse(textBox2.Text, out o) && textBox1.Text != "" && textBox2.Text != ""&&int.Parse(textBox1.Text)>=0&& int.Parse(textBox2.Text)>=0)
                button1.Enabled = true;
            else button1.Enabled = false;
        }   

       
    }
}
