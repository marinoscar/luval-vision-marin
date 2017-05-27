using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.utils
{
    public class Arguments
    {
        private List<string> _args;

        public Arguments(IEnumerable<string> args)
        {
            _args = new List<string>(args);
        }

        public string GetSourceDir()
        {
            if (!_args.Contains("-s")) return null;
            return GetVal(_args.IndexOf("-s"));
        }

        public string GetFilter()
        {
            if (!_args.Contains("-f")) return null;
            return GetVal(_args.IndexOf("-f"));
        }

        public string GetDestinationFolder()
        {
            if (!_args.Contains("-d")) return null;
            return GetVal(_args.IndexOf("-d"));
        }

        public bool DoDirConvert()
        {
            return _args.Contains("/dirConvert");
        }

        private string GetVal(int idx)
        {
            if (idx >= _args.Count) return null;
            return _args[idx+1];
        }
    }
}
