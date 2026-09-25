using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Extensions;

namespace AppStarter
{
    [Serializable]
    public class StartInfo
    {
        public string Filename = "";
        public string Arguments = "";
        public bool UseShellExecute = false;
        public ProcessWindowStyle WindowStyle = ProcessWindowStyle.Normal;
        public bool CreateNoWindow = false;

        public override string ToString()
        {
            if (Arguments.Length > 0)
            {
                return Filename + " " + Arguments + " (" + WindowStyle + ")";
            }
            else
            {
                return Filename + " (" + WindowStyle + ")";
            }
        }
    }
}
