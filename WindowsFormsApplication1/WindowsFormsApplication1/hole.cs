using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class hole
    {
     private int start;
     private int size;
     string process;
     public hole()
     {
         size = 0;
         start = 0;
         process = "";
     }
     public hole(int x, int y)
     {
         start = x;
         size = y;
         process = "";
     }
     public hole(int x, int y,string p)
     {
         start = x;
         size = y;
         process = p;
     }
     public int getStart() { return start; }
     public int getSize () { return size; }
     public void setSize(int s) { size = s; }
     public void setStart(int s) { start = s; }
     public String getProcess() { return process; }
     public void setProcess(string p) { process=p;}

    }
}
