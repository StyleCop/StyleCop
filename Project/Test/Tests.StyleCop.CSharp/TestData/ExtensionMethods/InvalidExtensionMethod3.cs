using System;
using System.Collections.Generic;
using System.Text;

namespace MS.StyleCop.CSharpParserTest.TestData.ExtensionMethods
{
    public static class InvalidExtensionMethod3
    {
        // An invalid extension method. The method is not static and the this keyword is not on the first parameter.
        public void ExtensionMethod(string x, this int y)
        {
        }
    }
}
