using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class process
    {
        private int order;
        private int size;
        private bool allocated;
        public process()
        {
            order = 0;
            size = 0;
            allocated = false;
        }
        public process(int x, int y)
        {
            order = x;
            size = y;
            allocated = false;
        }
        public process (int x, int y,bool a)
    {
        order=x;
        size = y;
        allocated = a;
    }
        public int getOrder() { return order; }
        public int getSize() { return size; }
        public void setOrder(int x) {  order=x; }
        public void setSize(int x) {  order=x; }
        public void setAsAllocated() { allocated = true; }
        public bool isAllocated() { return allocated; }


    }
}
