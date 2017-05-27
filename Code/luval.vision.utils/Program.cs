using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.utils
{
    class Program
    {
        static void Main(string[] args)
        {
            var ar = new Arguments(args);
            try
            {
                DirConvert(ar);
            }
            catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Failed: {0}", ex);
            }
        }

        static bool DirConvert(Arguments args)
        {
            if (!args.DoDirConvert()) return false;
            var conv = new ImageConverter(args);
            Console.WriteLine();
            Console.WriteLine("Converting images in the folder");
            Console.WriteLine();
            conv.ConvertDir();
            Console.WriteLine();
            return true;
        }
    }
}
