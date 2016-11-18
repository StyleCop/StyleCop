using System;
using System.Collections.Generic;
using System.Text;

namespace MS.StyleCop.CSharpParserTest.TestData.ExtensionMethods
{
    public static class InvalidExtensionMethod4
    {
        // An invalid extension method. There is a this keyword on the second parameter.
        public static void ExtensionMethod(this string x, this int y)
        {
        }
    }
}
