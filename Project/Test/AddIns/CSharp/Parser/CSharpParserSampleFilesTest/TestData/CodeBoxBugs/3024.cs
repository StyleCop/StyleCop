using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StyleCopRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            var complete = (bool)(GetValue() ?? (object)false);
        }
        static object GetValue()
        {
            return null;
        }
    }
}

