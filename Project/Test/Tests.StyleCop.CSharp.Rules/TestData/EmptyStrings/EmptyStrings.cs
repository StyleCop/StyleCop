using System;
using System.Collections.Generic;

namespace EmptyStrings
{
    public class Class1
    {
        string string1 = "";
        string string2 = @"";
        string string3 = " ";
        string string4 = @" ";
        string string5 = String.Empty;
        string string6 = $"";
        string string7 = $" ";

        public void Method1(string item)
        {
            string1 = "";
            string2 = @"";
            string3 = " ";
            string4 = @" ";
            string5 = String.Empty;
            string6 = $"";
            string7 = $" ";
        }

        public void Method2()
        {
            Method1("");
            Method1(@"");
            Method1(" ");
            Method1(@"
");
            Method1(String.Empty);
            Method1($"");
            Method1($" ");
        }

        public void Method3()
        {
            // The following empty string should be allowed without any violations, since it's 
            // impossible to use string.Empty in this case.
            string s = null;
            switch (s)
            {
                case "":
                    break;
            }
        }
    }

    /// <summary>
    /// A const variable cannot be set to string.Empty, it must be set to "".
    /// </summary>
    public class ConstVariables
    {
        private const string x = "";
        private readonly string y = "";
        private readonly string y = string.Empty;

        private const string aa = "", bb = "hello", cc = "";

        public void Method()
        {
            const string xx = "";
        }
    }

    class DefaultParameters
    {
        public void Method1(string parameter1 = "")
        {
        }        
    }   
}
