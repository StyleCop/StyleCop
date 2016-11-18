//-----------------------------------------------------------------------
// <copyright file="Utilities.cs">
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
namespace VSPackageUnitTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.Build.BuildEngine;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using StyleCop.VisualStudio;

    internal static class Utilities
    {
        public delegate void ThrowingFunction();

        public static bool OrderedCollectionsAreEqual<T>(IList<T> first, IList<T> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (first.Count != second.Count)
            {
                return false;
            }

            for (int i = 0; i < first.Count; ++i)
            {
                if (second.IndexOf(first[i]) != i)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasFunctionThrown<ExceptionType>(ThrowingFunction func) where ExceptionType : Exception
        {
            bool hasThrown = false;
            try
            {
                func();
            }
            catch (ExceptionType)
            {
                hasThrown = true;
            }
            catch (TargetInvocationException e)
            {
                hasThrown = (e.InnerException is ExceptionType);
            }
            return hasThrown;
        }

        static List<string> _tempFiles = new List<string>();

        static public void CleanUpTempFiles()
        {
            foreach (string file in _tempFiles)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                }
            }
            _tempFiles.Clear();
        }

        static public string CreateTempFile(string content, Encoding encoding, string extension)
        {
            string path = Path.GetTempFileName();
            if (extension != null)
            {
                path = Path.ChangeExtension(path, ".txt");
            }
            File.WriteAllText(path, content, encoding);
            _tempFiles.Add(path);
            return path;
        }

        static public string CreateTempTxtFile(string content, Encoding encoding)
        {
            return CreateTempFile(content, encoding, ".txt");
        }

        static public string CreateTempTxtFile(string content)
        {
            return CreateTempTxtFile(content, Encoding.Unicode);
        }

        static public string CreateTempFile(string content)
        {
            return CreateTempFile(content, Encoding.Unicode, null);
        }

        static public string CreateBigFile()
        {
            StringBuilder content = new StringBuilder();

            for (int i = 0; i < 1000000; ++i)
            {
                content.Append("abcd ");
            }

            return CreateTempFile(content.ToString());
        }

        static public List<T> ListFromEnum<T>(IEnumerable<T> enumerator)
        {
            List<T> result = new List<T>();

            foreach (T t in enumerator)
            {
                result.Add(t);
            }

            return result;
        }

        static public List<IVsTaskItem> TasksFromEnumerator(IVsEnumTaskItems enumerator)
        {
            List<IVsTaskItem> result = new List<IVsTaskItem>();

            IVsTaskItem[] items = new IVsTaskItem[] { null };
            uint[] fetched = new uint[] { 0 };

            for (enumerator.Reset(); enumerator.Next(1, items, fetched) == VSConstants.S_OK && fetched[0] == 1; /*nothing*/ )
            {
                result.Add(items[0]);
            }

            return result;
        }

        static public string CreateTermTable(IEnumerable<string> terms)
        {
            StringBuilder fileContent = new StringBuilder();

            fileContent.Append("<?xml version=\"1.0\"?>\n");
            fileContent.Append("<xmldata>\n");
            fileContent.Append("  <PLCKTT>\n");
            fileContent.Append("    <Lang>\n");

            foreach (string term in terms)
            {
                fileContent.Append("      <Term Term=\"" + term + "\" Severity=\"2\" TermClass=\"Geopolitical\">\n");
                fileContent.Append("        <Comment>For detailed info see - http://relevant-url-here.com</Comment>\n");
                fileContent.Append("      </Term>\n");
            }

            fileContent.Append("    </Lang>\n");
            fileContent.Append("  </PLCKTT>\n");
            fileContent.Append("</xmldata>\n");

            return CreateTempTxtFile(fileContent.ToString());
        }

#pragma warning disable 618
        static public Project SetupMSBuildProject()
        {
            // If you run these tests on a different machine, you may need to modify this path.
            Engine.GlobalEngine.BinPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            Project project = Engine.GlobalEngine.CreateNewProject();
            project.FullFileName = Path.GetTempFileName();
            return project;
        }
#pragma warning restore 618

        //static public Project SetupMSBuildProject(IList<string> filesToScan, IList<string> termTableFiles)
        //{
        //    Project project = SetupMSBuildProject();
        //    string projectFolder = Path.GetDirectoryName(project.FullFileName);

        //    if (filesToScan.Count > 0)
        //    {
        //        project.AddNewItem("ItemGroup1", Utilities.RelativePathFromAbsolute(filesToScan[0], projectFolder));
        //        if (filesToScan.Count > 1)
        //        {
        //            for (int i = 1; i < filesToScan.Count; ++i)
        //            {
        //                project.AddNewItem("ItemGroup2", Utilities.RelativePathFromAbsolute(filesToScan[i], projectFolder));
        //            }
        //        }
        //    }

        //    List<string> rootedTermTables = new List<string>(termTableFiles);
        //    List<string> relativeTermTables = rootedTermTables.ConvertAll<string>(
        //        delegate(string rootedPath)
        //        {
        //            return Utilities.RelativePathFromAbsolute(rootedPath, projectFolder);
        //        });

        //    Target target = project.Targets.AddNewTarget("AfterBuild");

        //    Microsoft.Build.BuildEngine.BuildTask newTask = target.AddNewTask("ScannerTask");
        //    newTask.Condition = "'$(RunCodeSweepAfterBuild)' == 'true'";
        //    newTask.ContinueOnError = false;
        //    newTask.SetParameterValue("FilesToScan", "@(ItemGroup1);@(ItemGroup2)");
        //    newTask.SetParameterValue("TermTables", Utilities.Concatenate(relativeTermTables, ";"));
        //    newTask.SetParameterValue("Project", "$(MSBuildProjectFullPath)");

        //    string usingTaskAssembly = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetLoadedModules()[0].FullyQualifiedName) + "\\BuildTask.dll";
        //    project.AddNewUsingTaskFromAssemblyFile("CodeSweep.BuildTask.ScannerTask", usingTaskAssembly);

        //    BuildPropertyGroup group = project.AddNewPropertyGroup(true);
        //    group.AddNewProperty("RunCodeSweepAfterBuild", "true");

        //    //TODO:project.AddNewImport(GetTargetsPath(), null);

        //    return project;
        //}

        //static internal string GetTargetsPath()
        //{
        //    return Utilities.EncodeProgramFilesVar(Path.GetDirectoryName(typeof(CodeSweep.BuildTask.ScannerTask).Module.FullyQualifiedName) + "\\CodeSweep.targets");
        //}

        //static internal void CopyTargetsFileToBinDir()
        //{
        //    string binDir = Path.GetDirectoryName(typeof(CodeSweep.BuildTask.ScannerTask).Module.FullyQualifiedName);
        //    string targetName = "CodeSweep.targets";
        //    string destinationPath = Path.Combine(binDir, targetName);
        //    if (!File.Exists(destinationPath))
        //    {
        //        string sourcePath = Path.Combine(binDir, Path.Combine("..\\..\\..\\..\\BuildTask", targetName));
        //        if (!File.Exists(sourcePath))
        //        {
        //            sourcePath = Path.Combine(Environment.GetEnvironmentVariable("suitebinaries"), targetName);
        //            if (!File.Exists(sourcePath))
        //            {
        //                throw new System.IO.FileNotFoundException(targetName);
        //            }
        //        }
        //        File.Copy(sourcePath, destinationPath);
        //    }
        //}
    }
}

