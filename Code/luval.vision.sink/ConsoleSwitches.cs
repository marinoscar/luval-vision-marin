using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.app
{
    /// <summary>
    /// Provides an abstraction to handle common console switches
    /// </summary>
    public class ConsoleSwitches
    {
        private List<string> _args;

        /// <summary>
        /// Creates an instance of the class
        /// </summary>
        /// <param name="args">Collection of arguments</param>
        public ConsoleSwitches(IEnumerable<string> args)
        {
            _args = new List<string>(args);
        }

        /// <summary>
        /// Gets the value for the switch in the argument collection
        /// </summary>
        /// <param name="name">The name of the switch</param>
        /// <returns>The switch value if present, otherwise null</returns>
        public string this[string name]
        {
            get
            {
                var idx = _args.IndexOf(name);
                if (idx == (_args.Count - 1)) return null;
                return _args[idx + 1];
            }
        }

        public bool RunBatch { get { return ContainsSwitch("/batch"); } }
        public string Folder { get { return this["/folder"]; } }
        public string Filter { get { return this["/filter"]; } }

        /// <summary>
        /// Indicates if the switch exists in the argument collection
        /// </summary>
        /// <param name="name">The name of the switch</param>
        /// <returns>True if the switch name is on the colleciton, otherwise false</returns>
        public bool ContainsSwitch(string name)
        {
            return _args.Contains(name);
        }
    }
}
