using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ProgressEventArgs : EventArgs
    {

        public ProgressEventArgs()
        {

        }


        public ProgressEventArgs(int current, int total)
        {
            CurrentIteration = current;
            TotalIterations = total;
        }

        public ProgressEventArgs(string message, int current, int total): this(current, total)
        {
            Message = message;
        }

        public string Message { get; set; }
        public int CurrentIteration { get; set; }
        public int TotalIterations { get; set; }
        public double Progress { get { return Math.Round(((double)CurrentIteration / (double)TotalIterations) * 100, 2); } }
        public bool Cancel { get; set; }
    }
}
