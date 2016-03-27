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
    public partial class enterProcess : Form
    {
        int x = 1;
        public enterProcess()
        {
            InitializeComponent();
            button1.Enabled = false;
            label2.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = int.Parse(textBox1.Text);
            variables.alloc.addProcess(new process(x,size));
            textBox1.Text = "";
            x = x + 1;
            label2.Text = x.ToString();
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             int o;
             if (int.TryParse(textBox1.Text, out o) && textBox1.Text != ""&& int.Parse(textBox1.Text)>=0)
             {
                 button1.Enabled = true;
             }
             else button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled)
            {
                int size = int.Parse(textBox1.Text);
                variables.alloc.addProcess(new process(x, size));
            }
            this.Hide();
            chooseAllocator ch = new chooseAllocator();
            ch.Show();
        }
    }
}
