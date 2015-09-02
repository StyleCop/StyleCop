using System;
using System.Collections.Generic;
using System.Text;

namespace MS.StyleCop.CSharpParserTest.TestData
{
    public static class ValidExtensionMethods
    {
        // A regular valid instance method.
        public void ValidMethod(string x, int y)
        {
        }

        // A regular valid static method.
        public static void ValidStaticMethod(string x, int y)
        {
        }

        // A valid extension method.
        public static void ValidExtensionMethod(this string x, int y)
        {
        }
    }
}
