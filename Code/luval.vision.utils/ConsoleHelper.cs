using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.utils
{
    public static class ConsoleHelper
    {
        public static void ShowProgress(double total, double current)
        {
            var progress = Math.Round(((current / total) * 100), 2);
            Console.Write("\rProgress: {0}% ", progress);
        }
    }
}
