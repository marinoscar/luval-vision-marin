using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.app
{
    public class StringForGrid
    {
        private string _value;

        public StringForGrid()
        {
            _value = default(string);
        }

        public StringForGrid(string s)
        {
            _value = s;
        }

        public string Value { get { return _value; } set { _value = value; } }

        public override string ToString()
        {
            return Value;
        }
    }
}
