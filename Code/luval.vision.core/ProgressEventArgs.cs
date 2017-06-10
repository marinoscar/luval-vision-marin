using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ProgressEventArgs : EventArgs
    {
        public int CurrentIteration { get; set; }
        public int TotalIterations { get; set; }
        public double Progress { get { return Math.Round(((double)CurrentIteration / (double)TotalIterations) * 100, 2); } }
        public bool Cancel { get; set; }
    }
}
