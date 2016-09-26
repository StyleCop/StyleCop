using System;
using System.Collections.Generic;

namespace StringFormatCSharp6
{
    public class Class1
    {
        public const string test = "test";
        public string string1 = string.Format("string format {0}", test);
        string string2 = $"string interpolation {test}";

        public void Method1(string item)
        {
            string1 = string.Format("string format {0}", string1);
            string2 = $"string interpolation {string2}";
        }

        public void Method2()
        {
            Method1(string.Format("string format {0}", string1));
            Method1($"string interpolation {string2}");
        }

        public void Method3()
        {
            string argumentName = "Test";
            int argIndex = 1;
            string[] arguments = new string[10];

            arguments[0] = "Test";
            arguments[1] = "Test1";

            Console.WriteLine($"{argumentName}[{argIndex}] = \"{arguments[argIndex]}\"");
            var test = $"{argumentName}[{argIndex}] = \"{arguments[argIndex]}\"";

            test = @"This is a test of double quote ""test"""""""""""" "" test";
            test = @"This is a test of double quote ""test"" "" test";
            test = @"This is a test of double quote """"""";

            Console.WriteLine(@"This is a test of double quote """"""");
            Console.WriteLine(@"This is a test of double quote ""test"" "" test");
            Console.WriteLine(@"This is a test of double quote ""test"""""""""""" "" test");
        }
    }

    public class ConstVariables
    {
        public const string test = "test";
        private readonly string x = string.Format("string format {0}", test);
        private readonly string y = $"string interpolation {test}";
    }
}
