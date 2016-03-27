using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class allocator
    {
        private LinkedList<hole> holes;
        string type;
        private LinkedList<process> processes;
        private LinkedList<hole> allocatedHoles;
        private LinkedList<process> unallocatedprocesses;
        public allocator()
        {
            holes = new LinkedList<hole>();
            processes = new LinkedList<process>();
            allocatedHoles = new LinkedList<hole>();
            unallocatedprocesses = new LinkedList<process>();
        }
        public void addHole(hole h) { holes.AddLast(h); }
        public void addProcess(process p) { processes.AddLast(p); }
        public int getNumberOfHoles() { return holes.Count(); }
        public int getNumberOfProcesses() { return processes.Count(); }
        public void refreshHoles(LinkedList <hole>h)
        {
            for (int i = 0; i < h.Count(); i++)
            {

                for (int j = 0; j < h.Count(); j++)
                {
                    if (i == j) ;
                    else
                    {
                        if (h.ElementAt(i).getStart() + h.ElementAt(i).getSize() >= h.ElementAt(j).getStart() && h.ElementAt(i).getStart() <= h.ElementAt(j).getStart())
                        {
                            hole temp = new hole();
                            hole removable = h.ElementAt(j);// h.Remove(h.ElementAt((i < j) ? j - 1 : j));
                            temp.setStart((h.ElementAt(i).getStart() < h.ElementAt(j).getStart()) ? h.ElementAt(i).getStart() : h.ElementAt(j).getStart());
                            temp.setSize((h.ElementAt(i).getStart() + h.ElementAt(i).getSize() > h.ElementAt(j).getStart() + h.ElementAt(j).getSize()) ? h.ElementAt(i).getStart() + h.ElementAt(i).getSize() - temp.getStart() : h.ElementAt(j).getStart() + h.ElementAt(j).getSize() - temp.getStart());
                            h.Remove(h.ElementAt(i));
                            h.Remove(removable);
                            h.AddLast(temp);
                            variables.alloc.refreshHoles(h);
                            break;
                        }
                    }
                } break;
            } 

        }
        public LinkedList<hole> getHoles() { return holes; }
        public LinkedList<process> getProcesses() { return processes; }
        public LinkedList<hole> getAllocatedHoles() { return allocatedHoles; }
        public LinkedList<process> getUnAllocatedProcesses() { return unallocatedprocesses; }

        public void setType(string s) { type=s;}
        public string getType() { return type; }
        public void firstFitAllocateProcess(process p)
        {
            if (variables.alloc.getHoles().Count() == 0)
            {
                
                    unallocatedprocesses.AddLast(p);
                    processes.Remove(p);
                
            }
          if (variables.alloc.getHoles().Count()>0)  this.refreshHoles(holes);
            for (int i = 0; i < holes.Count(); i++)
            {
                if (holes.ElementAt(i).getSize() >= p.getSize())
                {
                    p.setAsAllocated();
                    processes.Remove(p);
                    if (holes.ElementAt(i).getSize() == p.getSize())
                    {
                        allocatedHoles.AddLast(new hole(holes.ElementAt(i).getStart(), holes.ElementAt(i).getSize(), "P " + p.getOrder().ToString()));
                        holes.Remove(holes.ElementAt(i));
                        break;
                    }
                    else
                    {
                        hole temp = holes.ElementAt(i);
                        hole unallocatedhole = new hole(temp.getStart() + p.getSize(), temp.getSize() - p.getSize());
                        holes.Remove(holes.ElementAt(i));
                        allocatedHoles.AddLast(new hole(temp.getStart(), p.getSize(), "P " + p.getOrder().ToString()));
                        break;
                    }
                    
                }
                else
                {
                    unallocatedprocesses.AddLast(p);
                    processes.Remove(p);
                }
            }
        }
        public void bestFitAllocateProcess(process p)
        {
            if (variables.alloc.getHoles().Count() == 0)
            {

                unallocatedprocesses.AddLast(p);
                processes.Remove(p);

            }
            if (variables.alloc.getHoles().Count() > 0) this.refreshHoles(holes);
            hole bestFit = holes.ElementAt(0);
            bool matchFound = false;
            int bestFitIndex = 0;
            for (int i = 0; i < holes.Count(); i++)
            {
                if (holes.ElementAt(i).getSize() >= p.getSize())
                {
                   
                    p.setAsAllocated();
                    processes.Remove(p);
                    if ((holes.ElementAt(i).getSize() < bestFit.getSize() && holes.ElementAt(i).getSize() >= p.getSize()&&matchFound)||(holes.ElementAt(i).getSize()>=p.getSize()&&!matchFound))
                    {
                        bestFit = holes.ElementAt(i);
                        bestFitIndex = i;
                    }
                    matchFound = true;
                }
            }
            if (matchFound)
            {
                if (bestFit.getSize() == p.getSize())
                {
                    holes.ElementAt(bestFitIndex).setProcess("P" + p.getOrder().ToString());
                    allocatedHoles.AddLast(holes.ElementAt(bestFitIndex));
                    holes.Remove(holes.ElementAt(bestFitIndex));
                }
                else if (bestFit.getSize()>p.getSize())
                {
                    allocatedHoles.AddLast(new hole(bestFit.getStart(), p.getSize(), "P" + p.getOrder().ToString()));
                    hole temp=holes.ElementAt(bestFitIndex);
                    holes.Remove(holes.ElementAt(bestFitIndex));
                    holes.AddLast(new hole(bestFit.getStart() + p.getSize(), bestFit.getSize() - p.getSize()));
                
                }
                
            }
            else
            { 
                unallocatedprocesses.AddLast(p);
                processes.Remove(p);
            }
        
        }
        public void worstFitAllocateProcess(process p)
        {
            if (variables.alloc.getHoles().Count() == 0)
            {

                unallocatedprocesses.AddLast(p);
                processes.Remove(p);

            }
            if (variables.alloc.getHoles().Count() > 0) this.refreshHoles(holes);
            hole worstFit = holes.ElementAt(0);
            bool matchFound = false;
            int worstFitIndex = 0;
            for (int i = 0; i < holes.Count(); i++)
            {
                if (holes.ElementAt(i).getSize() >= p.getSize())
                {

                    p.setAsAllocated();
                    processes.Remove(p);
                    if ((holes.ElementAt(i).getSize() > worstFit.getSize() && holes.ElementAt(i).getSize() >= p.getSize() && matchFound) || (holes.ElementAt(i).getSize() >= p.getSize() && !matchFound))
                    {
                        worstFit = holes.ElementAt(i);
                        worstFitIndex = i;
                    }
                    matchFound = true;
                }
            }
            if (matchFound)
            {
                if (worstFit.getSize() == p.getSize())
                {
                    holes.ElementAt(worstFitIndex).setProcess("P" + p.getOrder().ToString());
                    allocatedHoles.AddLast(holes.ElementAt(worstFitIndex));
                    holes.Remove(holes.ElementAt(worstFitIndex));
                }
                else if (worstFit.getSize() > p.getSize())
                {
                    allocatedHoles.AddLast(new hole(worstFit.getStart(), p.getSize(), "P" + p.getOrder().ToString()));
                    hole temp = holes.ElementAt(worstFitIndex);
                    holes.Remove(holes.ElementAt(worstFitIndex));
                    holes.AddLast(new hole(worstFit.getStart() + p.getSize(), worstFit.getSize() - p.getSize()));

                }

            }
            else
            {
                unallocatedprocesses.AddLast(p);
                processes.Remove(p);
            }

        }
        public void firstFit()
        {
            if (variables.alloc.getHoles().Count() > 0) this.refreshHoles(holes);
          
            for (int i=0;i<processes.Count();i++)
                {
                    firstFitAllocateProcess(processes.ElementAt(i));
                    this.refreshHoles(holes);
                    variables.alloc.firstFit();
                    break;
                }  
        }
        public void bestFit()
        {
            if (variables.alloc.getHoles().Count() > 0) this.refreshHoles(holes);
            for (int i = 0; i < processes.Count(); i++)
            {
                bestFitAllocateProcess(processes.ElementAt(i));
                this.refreshHoles(holes);
                variables.alloc.bestFit();
                break;
            }
        }
        public void worstFit()
        {
            if (variables.alloc.getHoles().Count() > 0) this.refreshHoles(holes);
            for (int i = 0; i < processes.Count(); i++)
            {
                worstFitAllocateProcess(processes.ElementAt(i));
                this.refreshHoles(holes);
                variables.alloc.worstFit();
                break;
            }
        }




    }
}
