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
    public partial class chooseAllocator : Form
    {
        public chooseAllocator()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                variables.alloc.setType("best");
            }
            else if (radioButton2.Checked == true)
            {
                variables.alloc.setType("worst");
            }
            else if (radioButton3.Checked == true)
            {
                variables.alloc.setType("first");
            }
            output o=new output();
            this.Hide();
            o.Show();
        }
    }
}
