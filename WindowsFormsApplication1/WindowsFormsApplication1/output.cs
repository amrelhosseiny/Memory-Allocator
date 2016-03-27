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
    public partial class output : Form
    {
        String proName;
        Pen Bluepen = new Pen(Color.Blue, 3);
        Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
        Pen Redpen = new Pen(Color.Red, 2);
        string proSize, holeSize, holeStart, holeEnd;
        public output()
        {
            InitializeComponent();
        }


      
        private void output_Shown(object sender, EventArgs e)
        
        {
            variables.alloc.refreshHoles(variables.alloc.getHoles());
            Graphics dc = this.CreateGraphics();
            int proSize = 350 / (variables.alloc.getProcesses().Count()+1);
            int holeSize = 350 / (variables.alloc.getHoles().Count()+1);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Far;
            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Near;
            stringFormat2.LineAlignment = StringAlignment.Near;
            StringFormat stringFormat3 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;
            stringFormat2.LineAlignment = StringAlignment.Center;
           

            for (int i = 0; i < variables.alloc.getProcesses().Count(); i++)
            {
                proName = "P" + variables.alloc.getProcesses().ElementAt(i).getOrder().ToString();
                RectangleF rectF1 = new RectangleF(50, 50+proSize*(i), 70, proSize);
              //  dc.DrawString(proName, font1, Brushes.Blue, rectF1);
                dc.DrawString(proName, font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getProcesses().ElementAt(i).getSize().ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                dc.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
            }
            for (int i = 0; i < variables.alloc.getHoles().Count(); i++)
            {
                RectangleF rectF1 = new RectangleF(200, 50 + holeSize * (i), 180, holeSize);
                

                // Draw the text and the surrounding rectangle.
                dc.DrawString("Start: " + variables.alloc.getHoles().ElementAt(i).getStart().ToString(), font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getHoles().ElementAt(i).getSize().ToString(), font1, Brushes.Blue, rectF1, stringFormat2);
                dc.DrawString("End: " + (variables.alloc.getHoles().ElementAt(i).getStart()+variables.alloc.getHoles().ElementAt(i).getSize()).ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                
                //dc.DrawString("", font1, Brushes.Blue, rectF1);
                dc.DrawRectangle(Pens.Blue, Rectangle.Round(rectF1));
            }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Graphics dc = this.CreateGraphics();
            dc.Clear(output.ActiveForm.BackColor);   
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Far;
            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Near;
            stringFormat2.LineAlignment = StringAlignment.Near;
            StringFormat stringFormat3 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;
            stringFormat2.LineAlignment = StringAlignment.Center;
            if (variables.alloc.getType() == "best") variables.alloc.bestFit();
            if (variables.alloc.getType() == "first") variables.alloc.firstFit();
            if (variables.alloc.getType() == "worst") variables.alloc.worstFit();
            int proSize = 350 / (variables.alloc.getUnAllocatedProcesses().Count() + 1);
            int holeSize = 350 / (variables.alloc.getHoles().Count() + 1);
            int allocatedHole = 350 / (variables.alloc.getAllocatedHoles().Count() + 1);

            for (int i = 0; i < variables.alloc.getUnAllocatedProcesses().Count(); i++)
            {
                proName = "P" + variables.alloc.getUnAllocatedProcesses().ElementAt(i).getOrder().ToString();
                RectangleF rectF1 = new RectangleF(50, 50 + proSize * (i), 70, proSize);
                dc.DrawString(proName, font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getUnAllocatedProcesses().ElementAt(i).getSize().ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                dc.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
            }
            for (int i = 0; i < variables.alloc.getHoles().Count(); i++)
            {
                RectangleF rectF1 = new RectangleF(200, 50 + holeSize * (i), 180, holeSize);
                dc.DrawString("Start: " + variables.alloc.getHoles().ElementAt(i).getStart().ToString(), font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getHoles().ElementAt(i).getSize().ToString(), font1, Brushes.Blue, rectF1, stringFormat2);
                dc.DrawString("End: " + (variables.alloc.getHoles().ElementAt(i).getStart() + variables.alloc.getHoles().ElementAt(i).getSize()).ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                dc.DrawRectangle(Pens.Blue, Rectangle.Round(rectF1));
            }
            for (int i = 0; i < variables.alloc.getAllocatedHoles().Count(); i++)
            {
                RectangleF rectF1 = new RectangleF(460, 50 + allocatedHole * (i), 180, allocatedHole);
                dc.DrawString("Start: " + variables.alloc.getAllocatedHoles().ElementAt(i).getStart().ToString(), font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getAllocatedHoles().ElementAt(i).getSize().ToString() + ", Process: " + variables.alloc.getAllocatedHoles().ElementAt(i).getProcess().ToString(), font1, Brushes.Blue, rectF1, stringFormat2);
                dc.DrawString("End: " + (variables.alloc.getAllocatedHoles().ElementAt(i).getStart() + variables.alloc.getAllocatedHoles().ElementAt(i).getSize()).ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                dc.DrawRectangle(Pens.Blue, Rectangle.Round(rectF1));
            }
            button1.Enabled = false;
            button2.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (variables.alloc.getProcesses().Count() == 1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            Graphics dc = this.CreateGraphics();
            dc.Clear(output.ActiveForm.BackColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Far;
            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Near;
            stringFormat2.LineAlignment = StringAlignment.Near;
            StringFormat stringFormat3 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;
            stringFormat2.LineAlignment = StringAlignment.Center;
            if (variables.alloc.getType() == "best") variables.alloc.bestFitAllocateProcess(variables.alloc.getProcesses().ElementAt(0));
            if (variables.alloc.getType() == "first") variables.alloc.firstFitAllocateProcess(variables.alloc.getProcesses().ElementAt(0));
            if (variables.alloc.getType() == "worst") variables.alloc.worstFitAllocateProcess(variables.alloc.getProcesses().ElementAt(0));
            int proSize = 350 / (variables.alloc.getUnAllocatedProcesses().Count() + variables.alloc.getProcesses().Count() + 1);
            int holeSize = 350 / (variables.alloc.getHoles().Count() + 1);
            int allocatedHole = 350 / (variables.alloc.getAllocatedHoles().Count() + 1);

            for (int i = 0; i < variables.alloc.getUnAllocatedProcesses().Count(); i++)
            {

                proName = "P" + variables.alloc.getUnAllocatedProcesses().ElementAt(i).getOrder().ToString();
                RectangleF rectF1 = new RectangleF(50, 50 + proSize * (i), 70, proSize);
                dc.DrawString(proName, font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getUnAllocatedProcesses().ElementAt(i).getSize().ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                dc.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
            }
            for (int i = 0; i < variables.alloc.getHoles().Count(); i++)
            {
                RectangleF rectF1 = new RectangleF(200, 50 + holeSize * (i), 180, holeSize);
                dc.DrawString("Start: " + variables.alloc.getHoles().ElementAt(i).getStart().ToString(), font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getHoles().ElementAt(i).getSize().ToString(), font1, Brushes.Blue, rectF1, stringFormat2);
                dc.DrawString("End: " + (variables.alloc.getHoles().ElementAt(i).getStart() + variables.alloc.getHoles().ElementAt(i).getSize()).ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                dc.DrawRectangle(Pens.Blue, Rectangle.Round(rectF1));
            }
            for (int i = 0; i < variables.alloc.getAllocatedHoles().Count(); i++)
            {
                RectangleF rectF1 = new RectangleF(460, 50 + allocatedHole * (i), 180, allocatedHole);
                dc.DrawString("Start: " + variables.alloc.getAllocatedHoles().ElementAt(i).getStart().ToString(), font1, Brushes.Blue, rectF1, stringFormat3);
                dc.DrawString("Size: " + variables.alloc.getAllocatedHoles().ElementAt(i).getSize().ToString() + ", Process: " + variables.alloc.getAllocatedHoles().ElementAt(i).getProcess().ToString(), font1, Brushes.Blue, rectF1, stringFormat2);
                dc.DrawString("End: " + (variables.alloc.getAllocatedHoles().ElementAt(i).getStart() + variables.alloc.getAllocatedHoles().ElementAt(i).getSize()).ToString(), font1, Brushes.Blue, rectF1, stringFormat);
                dc.DrawRectangle(Pens.Blue, Rectangle.Round(rectF1));
            }

          




        }
    }
}




