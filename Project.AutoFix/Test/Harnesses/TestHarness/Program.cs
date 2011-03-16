//-----------------------------------------------------------------------
// <copyright file="Program.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.Test
{
    using System;
    using System.IO;
    using System.Security;
    using System.Xml;

    /// <summary>
    /// Contains the main entrypoint for the program.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Prevents a default instance of the Program class from being created.
        /// </summary>
        private Program()
        {
        }

        /// <summary>
        /// The main entrypoint for the program.
        /// </summary>
        /// <param name="args">The event arguments.</param>
        public static void Main(string[] args)
        {
            string testInputLocation = null;
            string testOutputLocation = null;
            string testroot = null;
            string testname = null;
            bool help = false;
            bool autoFix = false;

            foreach (string arg in args)
            {
                if (arg.StartsWith("/i:", StringComparison.OrdinalIgnoreCase))
                {
                    testInputLocation = arg.Substring(3, arg.Length - 3);
                }
                else if (arg.StartsWith("/o:", StringComparison.OrdinalIgnoreCase))
                {
                    testOutputLocation = arg.Substring(3, arg.Length - 3);
                }
                else if (arg.StartsWith("/testname:", StringComparison.OrdinalIgnoreCase))
                {
                    testname = arg.Substring(10, arg.Length - 10);
                }
                else if (arg.StartsWith("/testroot:", StringComparison.OrdinalIgnoreCase))
                {
                    testroot = arg.Substring(10, arg.Length - 10);
                }
                else if (arg.Equals("/fix", StringComparison.OrdinalIgnoreCase))
                {
                    autoFix = true;
                }
                else if (arg.Equals("/?", StringComparison.Ordinal))
                {
                    help = true;
                    break;
                }
            }

            if (help ||
                string.IsNullOrEmpty(testname) ||
                string.IsNullOrEmpty(testroot) ||
                string.IsNullOrEmpty(testInputLocation) ||
                string.IsNullOrEmpty(testOutputLocation))
            {
                Help();
            }
            else
            {
                StyleCopTestRunner.Run(testname, testroot, testInputLocation, testOutputLocation, autoFix);
            }
        }

        /// <summary>
        /// Displays help information on the console output.
        /// </summary>
        private static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("Usage: StyleCopTestHarness /i:{path to test input dir} /o:{path to results output file}");
            Console.WriteLine("    Optional parameter: /d:{name of test description file}");
            Console.WriteLine();
            Console.WriteLine("If the /d parameter is ommitted, the test description file must be named 'StyleCopTestDescription.xml'");
            Console.WriteLine();
        }
    }
}
