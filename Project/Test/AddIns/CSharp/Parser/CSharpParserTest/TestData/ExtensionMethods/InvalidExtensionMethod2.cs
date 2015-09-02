using System;
using System.Collections.Generic;
using System.Text;

namespace MS.StyleCop.CSharpParserTest.TestData.ExtensionMethods
{
    public static class InvalidExtensionMethod2
    {
        // An invalid extension method. The this keyword is not on the first parameter.
        public static void ExtensionMethod(string x, this int y)
        {
        }
    }
}
