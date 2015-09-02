using System;
using System.Linq;
using System.Collections;

class Program
{
    static void Main()
    {
        var q = from int x in Enumerable.Range(1, 10) select -x;
    }
}
