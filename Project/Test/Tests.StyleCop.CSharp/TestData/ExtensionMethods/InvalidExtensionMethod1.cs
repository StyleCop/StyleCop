using System;
using System.Collections.Generic;
using System.Text;

namespace MS.StyleCop.CSharpParserTest.TestData.ExtensionMethods
{
    public static class InvalidExtensionMethod1
    {
        // An invalid extension method. The method is not static.
        public void ExtensionMethod(this string x, int y)
        {
        }
    }
}
