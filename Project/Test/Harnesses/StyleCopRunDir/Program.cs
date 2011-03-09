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
namespace StyleCop.StyleCopRunDir
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using StyleCop;

    /// <summary>
    /// The main entrypoint into the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The number of issues encountered.
        /// </summary>
        private static int issues;

        /// <summary>
        /// The number of files to process.
        /// </summary>
        private static int filesCount;

        /// <summary>
        /// The root directory.
        /// </summary>
        private static string rootDir;

        /// <summary>
        /// The path to the settings file.
        /// </summary>
        private static string settingsPath;

        /// <summary>
        /// Indicates whether to run in estimates-only mode.
        /// </summary>
        private static bool estimateMode;
        
        /// <summary>
        /// Indicates whether to run in fuzz mode.
        /// </summary>
        private static bool fuzzMode;

        /// <summary>
        /// The current source file.
        /// </summary>
        private static string currentFile;

        /// <summary>
        /// Used for matching source files.
        /// </summary>
        /// <param name="file">A source file.</param>
        /// <returns>Returns true if the file matches; false otherwise.</returns>
        private delegate bool FileComparer(string file);

        /// <summary>
        /// The entrypoint into the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>Returns the exit status code.</returns>
        public static int Main(string[] args)
        {
            string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine("StyleCopRunDir v{0}", ver);

            string mode = "n";

            for (int i = 0; i < args.Length; ++i)
            {
                if (i == 0)
                {
                    if (args[i].StartsWith("-m:"))
                    {
                        mode = args[i].Substring(3, 1);
                    }
                    else
                    {
                        rootDir = args[i];
                    }
                }
                else if (i == 1)
                {
                    if (rootDir == null)
                    {
                        rootDir = args[i];
                    }
                    else
                    {
                        settingsPath = args[i];
                    }
                }
                else if (i == 2)
                {
                    if (settingsPath == null)
                    {
                        settingsPath = args[i];
                    }
                }
                else
                {
                    break;
                }
            }

            if (rootDir == null)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("  StyleCopRunDir <mode> <folder to analyze> <path to settings file>");
                Console.WriteLine("Example:");
                Console.WriteLine("  StyleCopRunDir -m: d:\\sd\\mcos d:\\stylecop.settings");
                Console.WriteLine("Modes:");
                Console.WriteLine("  -m:e - estimate amount of work");
                Console.WriteLine("  -m:n - new project for each file");
                Console.WriteLine("  -m:o - one project for all files");
                Console.WriteLine("  -m:f - fuzz analyzers feeding them non-C# files");
                return -1;
            }

            if (!Directory.Exists(rootDir))
            {
                Console.WriteLine("Folder '{0}' does not exist", rootDir);
                return -1;
            }

            if (settingsPath != null && !File.Exists(settingsPath))
            {
                Console.WriteLine("File '{0}' does not exist", settingsPath);
                return -1;
            }

            issues = 0;
            filesCount = 0;

            if (mode == "e")
            {
                Estimate();
                return 0;
            }

            Directory.CreateDirectory("ViolationFiles");
            Stopwatch sw = Stopwatch.StartNew();

            switch (mode)
            {
                case "n": RunMultiProject(); 
                    break;
                case "o": RunSingleProject(); 
                    break;
                case "f": Fuzz(); 
                    break;

                default:
                    Console.WriteLine("Invalid mode ({0})", mode);
                    return -1;
            }

            TimeSpan duration = sw.Elapsed;

            if (filesCount > 0)
            {
                Console.WriteLine("Analysis completed");
                Console.WriteLine("  Files processed: {0,6}", filesCount);
                Console.WriteLine("  Issues found:    {0,6}", issues);
                Console.WriteLine("  Total time:      {0,6} sec", duration.TotalSeconds.ToString("F"));
                Console.WriteLine("  Time per file:   {0,6} msec", (duration.TotalMilliseconds / filesCount).ToString("F"));
            }
            else
            {
                Console.WriteLine("No files to analyze");
            }

            return 0;
        }

        /// <summary>
        /// Runs the tool, creating a project for each source file.
        /// </summary>
        private static void RunMultiProject()
        {
            Console.WriteLine("Mode n: new project for each file.");

            List<string> tmp = new List<string>();
            tmp.Add(string.Empty);

            foreach (string file in GetSources(rootDir))
            {
                currentFile = file;

                tmp[0] = file;
                Process(settingsPath, tmp);
                ShowCurrentInfoOnSpacePressed();
            }
        }

        /// <summary>
        /// Runs the tool, creating one project for all source files.
        /// </summary>
        private static void RunSingleProject()
        {
            Console.WriteLine("Mode o: one project for all files.");
            Process(settingsPath, GetSources(rootDir));
        }

        /// <summary>
        /// Runs the tool, providing fuzzed test files.
        /// </summary>
        private static void Fuzz()
        {
            Console.WriteLine("Mode f: fuzz source files");
            fuzzMode = true;

            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempFilename = Path.Combine(currentDir, "file.cs");

            if (File.Exists(tempFilename))
            {
                File.SetAttributes(tempFilename, FileAttributes.Normal);
                File.Delete(tempFilename);
            }

            List<string> tmp = new List<string>();
            tmp.Add(tempFilename);

            foreach (string file in GetNonCSharpFiles(rootDir))
            {
                currentFile = file;
                bool copyError = false;

                try
                {
                    File.Copy(file, tempFilename, true);
                    File.SetAttributes(tempFilename, FileAttributes.Normal);
                }
                catch
                {
                    copyError = true;
                }

                if (!copyError)
                {
                    Process(settingsPath, tmp);
                }

                ShowCurrentInfoOnSpacePressed();
            }

            File.Delete(tempFilename);
        }

        /// <summary>
        /// Estimate the time needed to run the rool.
        /// </summary>
        private static void Estimate()
        {
            Console.WriteLine("Mode e: estimate amount of work.");
            estimateMode = true;

            List<string> tmp = new List<string>();
            tmp.Add(string.Empty);

            int no = 100;

            TimeSpan processingDuration = TimeSpan.Zero;
            Stopwatch sw = Stopwatch.StartNew();

            foreach (string file in GetSources(rootDir))
            {
                currentFile = file;

                if (filesCount < no)
                {
                    tmp[0] = file;
                    Process(settingsPath, tmp);
                    continue;
                }

                if (filesCount == no)
                {
                    processingDuration = sw.Elapsed;
                }

                filesCount++;
                ShowCurrentInfoOnSpacePressed();
            }

            if (filesCount < no)
            {
                no = filesCount;
                processingDuration = sw.Elapsed;
            }

            Console.WriteLine("Files found: {0}", filesCount);

            if (filesCount > 0)
            {
                TimeSpan duration = sw.Elapsed + TimeSpan.FromMilliseconds(((double)processingDuration.TotalMilliseconds / no) * (filesCount - no));
                TimeSpan rounded = new TimeSpan(0, (int)duration.TotalMinutes, 0);
                Console.WriteLine("Estimated analysis time in Mode n: {0}", rounded.ToString());
            }
        }

        /// <summary>
        /// Finds source files to run against.
        /// </summary>
        /// <param name="dir">The directory to search.</param>
        /// <returns>Returns the source files.</returns>
        private static IEnumerable<string> GetSources(string dir)
        {
            return GetSources(dir, file =>
                {
                    return file.EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
                });
        }

        /// <summary>
        /// Finds all non-C# source files to run against.
        /// </summary>
        /// <param name="dir">The directory to search.</param>
        /// <returns>Returns the source files.</returns>
        private static IEnumerable<string> GetNonCSharpFiles(string dir)
        {
            return GetSources(dir, file =>
            {
                return !file.EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
            });
        }

        /// <summary>
        /// Finds source files to run against.
        /// </summary>
        /// <param name="dir">The directory to search.</param>
        /// <returns>Returns the source files.</returns>
        private static IEnumerable<string> GetSources(string dir, FileComparer comparer)
        {
            string[] files;

            try
            {
                files = Directory.GetFiles(dir, "*.*");
            }
            catch
            {
                yield break;
            }

            foreach (string f in files)
            {
                if (comparer(f))
                {
                    yield return f;
                }
            }

            string[] directories;

            try
            {
                directories = Directory.GetDirectories(dir);
            }
            catch
            {
                yield break;
            }

            foreach (string d in directories)
            {
                foreach (string file in GetSources(d))
                {
                    yield return file;
                }
            }
        }

        /// <summary>
        /// Processes a collection of files.
        /// </summary>
        /// <param name="settingsPath">The path to the settings file.</param>
        /// <param name="files">The files to process.</param>
        private static void Process(string settingsPath, IEnumerable<string> files)
        {
            StyleCopConsole console = null;
            CodeProject project = null;

            try
            {
                Configuration configuration = new Configuration(new string[] { "DEBUG" });
                project = new CodeProject(1, "default", configuration);

                console = new StyleCopConsole(settingsPath, false, null, null, true);

                foreach (string file in files)
                {
                    console.Core.Environment.AddSourceCode(project, file, null);
                }

                filesCount += project.SourceCodeInstances.Count;

                if (!estimateMode)
                {
                    if (fuzzMode)
                    {
                        console.ViolationEncountered += OnFuzzViolationEncountered;
                        console.OutputGenerated += OnFuzzOutputGenerated;
                    }
                    else
                    {
                        console.ViolationEncountered += OnViolationEncountered;
                        console.OutputGenerated += OnOutputGenerated;
                    }
                }

                console.Start(new CodeProject[] { project }, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception in StyleCop.\r\n{0}", e.ToString());

                if (project != null)
                {
                    if (project.SourceCodeInstances.Count == 1)
                    {
                        Console.WriteLine(project.SourceCodeInstances[0]);
                    }
                }
            }
            finally
            {
                if (console != null)
                {
                    if (!estimateMode)
                    {
                        if (fuzzMode)
                        {
                            console.ViolationEncountered -= OnFuzzViolationEncountered;
                            console.OutputGenerated -= OnFuzzOutputGenerated;
                        }
                        else
                        {
                            console.ViolationEncountered -= OnViolationEncountered;
                            console.OutputGenerated -= OnOutputGenerated;
                        }
                    }

                    console.Dispose();
                }
            }
        }

        /// <summary>
        /// Called when a violation is encountered in a source file.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private static void OnViolationEncountered(object sender, ViolationEventArgs e)
        {
            string checkId = e.Violation.Rule.CheckId;

            if (checkId.CompareTo("SA1000") < 0)
            {
                issues++;
                string id = String.Format("{0:0000}", issues);
                string path = e.Violation.SourceCode.Path;

                if (checkId == "SA0001" || checkId == "SA0101")
                {
                    Console.WriteLine("{0} {1}: {2} {3}", id, checkId, path, e.Violation.Message);
                }
                else
                {
                    Console.WriteLine("{0} {1}: {2}", id, checkId, e.Violation.Message);
                }

                string saveAs = String.Format("ViolationFiles\\{0}.cs", id);
                SaveViolationFile(path, saveAs, e.Violation.Line);
            }
        }

        /// <summary>
        /// Called when StyleCop output is generated.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private static void OnOutputGenerated(object sender, OutputEventArgs e)
        {
            if (e.Output.StartsWith("Exception", StringComparison.OrdinalIgnoreCase))
            {
                issues++;
                Console.WriteLine("{0:0000} {1}", issues, e.Output);
            }
        }

        /// <summary>
        /// Called when a violation is encoutered while running under fuzz test mode.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private static void OnFuzzViolationEncountered(object sender, ViolationEventArgs e)
        {
            string checkId = e.Violation.Rule.CheckId;

            if (checkId == "SA0001" || checkId == "SA0101")
            {
                issues++;
                string id = String.Format("{0:0000}", issues);
                string path = e.Violation.SourceCode.Path;

                Console.WriteLine("{0} {1}: {2} {3}", id, checkId, path, e.Violation.Message);

                string saveAs = String.Format("ViolationFiles\\{0}.cs", id);
                SaveViolationFile(path, saveAs, e.Violation.Line);
            }
        }

        /// <summary>
        /// Called when StyleCop output is generated during fuzz test mode.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private static void OnFuzzOutputGenerated(object sender, OutputEventArgs e)
        {
            if (e.Output.StartsWith("Exception", StringComparison.OrdinalIgnoreCase))
            {
                issues++;
                string id = String.Format("{0:0000}", issues);

                Console.WriteLine("{0} {1}", id, e.Output);
                Console.WriteLine("{0} Original file: {1}", id, currentFile);

                string saveAs = String.Format("ViolationFiles\\{0}.cs", id);
                File.Copy(currentFile, saveAs);
            }
        }

        /// <summary>
        /// Saves the violation file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="saveAs">The path to save as.</param>
        /// <param name="violationLine">The line number of the violation.</param>
        private static void SaveViolationFile(string path, string saveAs, int violationLine)
        {
            if (!File.Exists(path))
            {
                return;
            }

            using (TextReader tr = new StreamReader(path))
            using (TextWriter tw = new StreamWriter(saveAs))
            {
                for (int i = 0; i < violationLine - 1; i++)
                {
                    tw.WriteLine(tr.ReadLine());
                }

                tw.WriteLine(">>>>>>> " + tr.ReadLine());
                tw.Write(tr.ReadToEnd());
            }
        }

        /// <summary>
        /// Shows test status information when the spacebar is pressed in the Console window.
        /// </summary>
        private static void ShowCurrentInfoOnSpacePressed()
        {
            if (Console.KeyAvailable)
            {
                bool spacePressed = false;
                while (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        spacePressed = true;
                    }
                }

                if (spacePressed)
                {
                    Console.WriteLine("{0} {1}", filesCount, currentFile);
                }
            }
        }
    }
}

    /*
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
            if (args.Length == 0 || !Directory.Exists(args[0]))
            {
                throw new ArgumentException("Invalid arguments. Pass the path to a directory to run against.");
            }

            using (StyleCopConsole console = new StyleCopConsole(null, false, null, null, true, "RunDir"))
            {
                console.OutputGenerated += new EventHandler<OutputEventArgs>(StyleCopConsoleOutputGenerated);

                Configuration configuration = new Configuration(new string[] { });
                CodeProject project = new CodeProject(0, args[0], configuration);

                FindFiles(args[0], project, console);

                // Run.
                console.Start(new CodeProject[] { project }, true);
            }
        }

        /// <summary>
        /// Called when console output is generated.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private static void StyleCopConsoleOutputGenerated(object sender, OutputEventArgs e)
        {
            Console.WriteLine(e.Output);
        }

        /// <summary>
        /// Finds files along the given path.
        /// </summary>
        /// <param name="path">The path to search.</param>
        /// <param name="project">The project to add files into.</param>
        /// <param name="console">The console object.</param>
        private static void FindFiles(string path, CodeProject project, StyleCopConsole console)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                if (file.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                {
                    console.Core.Environment.AddSourceCode(project, Path.Combine(path, file), null);
                }
            }

            foreach (string directory in Directory.GetDirectories(path))
            {
                FindFiles(Path.Combine(path, directory), project, console);
            }
        }
    }
}
    */