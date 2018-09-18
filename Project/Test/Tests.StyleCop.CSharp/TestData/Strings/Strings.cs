using System;
using System.Collections.Generic;

namespace Strings
{
    public class StringsTest
    {
        public const string test = "test";
        public string string1 = string.Format("string format");
        string string2 = $"string interpolation {test}";
        string string3 = $"string \"interpolation\" {test}";
        string string4 = $"string {{interpolation}} {test + "x"}";
        string string5 = $"string interpolation {test + "\"x\""}";
        string string6 = $"string interpolation {test + $"\"x\"{"y"}"}";
        string string7 = $@"Test ""literal"" with at sign";
        string string8 = $@"Test
{"multi"}
line";
        string string9 = $"Test with {$"nested interpolated {"\"strings\""}"}";

        public void Method1(string item)
        {
            string1 = string.Format("string format {0}", string1);
            string2 = $"string interpolation {string2}";
            string2 = @"This is a test of double quote """"";
        }

        public void Method2()
        {
            Method1(string.Format("string format {0}", string1));
            Method1($"string interpolation {string2}");
        }

        public void Issue14()
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

            var strippedStatement = Regex.Replace("input string", @"(?<S>(^|\W+)?)Mev\.(?<E>($|\W+)?)", @"${S}${E}");
        }

        public void InterpolationWithLiteral()
        {
            string argumentName = "Test";
            int argIndex = 1;
            string[] arguments = new string[10];

            arguments[0] = "Test";
            arguments[1] = "Test1";

            Console.WriteLine($@"{argumentName}[{argIndex}] = ""{arguments[argIndex]}""");
            var test = $@"{argumentName}[{argIndex}] = ""{arguments[argIndex]}""";

            test = $@"This is a test of double quote ""test"""""""""""" "" test";
            test = $@"This is a test of double quote ""test"" "" test";
            test = $@"This is a test of double quote """"""";

            Console.WriteLine($@"This is a test of double quote """"""");
            Console.WriteLine($@"This is a test of double quote ""test"" "" test");
            Console.WriteLine($@"This is a test of double quote ""test"""""""""""" "" test");
        }
    }

    public class StringsConstTest
    {
        public const string test = "test";
        private readonly string x = string.Format("string format {0}", test);
        private readonly string y = $"string interpolation {test}";
        var message = $"ConnectionString missing: {ConfigurationManager.AppSettings["ConnectionStringName"]}";
    }

    public class CSSAsString
    {
        public static string GetStyle()
        {
            return @"<style>
body
{
    padding-right: 0px;
    padding-left: 0px;
    font-size: 8pt;
    padding-bottom: 0px;
    margin: 0px;
    padding-top: 0px;
    font-family: arial, helvetica, sans-serif;
    background-color: #cccccc;
}
form
{
    padding-right: 0px;
    padding-left: 0px;
    padding-bottom: 0px;
    margin: 0px;
    padding-top: 0px;
}
</style>";
        }

        public static string GetStyleWithDoubleQuotes()
        {
            return @"<style>
body
{
    padding-right: 0px;
    padding-left: 0px;
    font-size: 8pt;
    padding-bottom: 0px;
    margin: 0px;
    padding-top: 0px;
    font-family: arial, helvetica, sans-serif;
    background-color: #cccccc; ""this is another test"" 
}
form
{
    padding-right: 0px;
    padding-left: 0px;
    padding-bottom: 0px;
    margin: 0px;
    padding-top: 0px;
}
</style>";
        }
    }

    public class Issue88
    {
        var foo1 = @"c:\foo\";
        var foo2 = @"c:\foo";
        var foo3 = $@"{foo2}\";
        // Regression check: Non-verbatim interpolated string ending with backslash
        var foo4 = $"{foo2}\\";

        var issue192 = $"123 {@"c:\temp\"}";
    }
}
