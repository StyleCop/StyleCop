//-----------------------------------------------------------------------
// <copyright file="Program.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace PerfHarness
{
    using System;
    using System.IO;
    using StyleCop;

    /// <summary>
    /// The main entry point to the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entrypoint to the application.
        /// </summary>
        /// <param name="args">The arguments passed to the executable.</param>
        public static void Main(string[] args)
        {
            int iterations = 10;
            string file = null;

            if (args.Length > 0)
            {
                int index = 0;

                if (args[0].StartsWith("-n:", StringComparison.Ordinal))
                {
                    iterations = int.Parse(args[0].Substring(3, args[0].Length - 3));
                    ++index;
                }

                if (args.Length > index)
                {
                    file = args[index];
                }
            }

            if (!string.IsNullOrEmpty(file))
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine("The file " + file + " does not exist");
                    file = null;
                }
            }

            if (!string.IsNullOrEmpty(file))
            {
                DateTime start = DateTime.Now;
                Console.WriteLine("Start time: " + start.ToLongTimeString());

                for (int i = 0; i < iterations; ++i)
                {
                    Console.WriteLine("Iteration " + (i + 1));

                    StyleCopConsole console = new StyleCopConsole(null, false, null, null, true, "Perf");

                    Configuration configuration = new Configuration(new string[] { });
                    CodeProject project = new CodeProject(0, Environment.CurrentDirectory, configuration);
                    console.Core.Environment.AddSourceCode(project, file, null);

                    console.Start(new CodeProject[] { project }, true);
                }

                DateTime end = DateTime.Now;
                Console.WriteLine("End time: " + end.ToLongTimeString());
                Console.WriteLine();

                TimeSpan elapsedTime = end - start;
                Console.WriteLine("Elapsed time: " + elapsedTime);
            }
            else
            {
                Console.WriteLine("Usage: StyleCopPerfHarness {-n:X} FileToTest.cs");
            }
        }
    }
}
