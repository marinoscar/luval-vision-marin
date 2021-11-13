using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.app
{
    public interface ICustomLog
    {
        void WriteError(string format, params object[] args);
        void WriteWarning(string format, params object[] args);
        void WriteInformation(string format, params object[] args);
        void Write(string category, string format, params object[] args);
    }
}
