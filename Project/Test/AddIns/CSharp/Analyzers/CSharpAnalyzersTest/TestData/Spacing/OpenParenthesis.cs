using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    class OpenParenthesis
    {
        public void M(Action a)
        {
            M(a: () => Console.WriteLine());
        }
   }
}
