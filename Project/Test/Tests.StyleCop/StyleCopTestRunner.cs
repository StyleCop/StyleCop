//-----------------------------------------------------------------------
// <copyright file="StyleCopTestRunner.cs">
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Security;
    using System.Threading;
    using System.Xml;
    using StyleCop;
    using Tests.StyleCop;

    /// <summary>
    /// Runs the test.
    /// </summary>
    public class StyleCopTestRunner
    {
        #region Private Fields

        /// <summary>
        /// The test description document.
        /// </summary>
        private XmlDocument testDescription;

        /// <summary>
        /// The test results output document.
        /// </summary>
        private XmlDocument resultsOutput;

        /// <summary>
        /// The InnerTests node within the results output document.
        /// </summary>
        private XmlElement innerTestsNode;

        /// <summary>
        /// The location to output the test results.
        /// </summary>
        private string resultsOutputLocation;

        /// <summary>
        /// The location of the test data files.
        /// </summary>
        private string testDataLocation;

        /// <summary>
        /// The path to the folder containing test input files.
        /// </summary>
        private string testInputPath;

        /// <summary>
        /// The overall name of the test being run.
        /// </summary>
        private string overallTestName = string.Empty;

        /// <summary>
        /// The simulation of framework version to check only new specifications.
        /// </summary>
        private double frameworkVersion;

        /// <summary>
        /// Keeps of track of whether any tests have failed.
        /// </summary>
        private bool failure;

        /// <summary>
        /// Indicates whether to run in "auto-fix" mode.
        /// </summary>
        private bool autoFix;

        /// <summary>
        /// Additional add-in files to copy to the test bin directory.
        /// </summary>
        private IEnumerable<string> addinFiles;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the StyleCopTestRunner class.
        /// </summary>
        /// <param name="testInputPath">The path to the folder containing test input files.</param>
        /// <param name="testDescription">The test description document.</param>
        /// <param name="testDataLocation">The location of the test documents.</param>
        /// <param name="resultsOutputLocation">The location to output the test results.</param>
        /// <param name="autoFix">Indicates whether to run StyleCop in "auto-fix" mode.</param>
        /// <param name="addinFiles">Additional add-in files to copy to the test bin directory.</param>
        /// <param name="simulationFrameworkVersion">The simulation framework version.</param>
        internal StyleCopTestRunner(string testInputPath, XmlDocument testDescription, string testDataLocation, string resultsOutputLocation, bool autoFix, IEnumerable<string> addinFiles, double simulationFrameworkVersion)
        {
            Debug.Assert(!string.IsNullOrEmpty(testInputPath), "The string is invalid");
            Debug.Assert(testDescription != null, "The parameter must not be null");
            Debug.Assert(testDataLocation != null, "The parameter must not be null");
            Debug.Assert(!string.IsNullOrEmpty(resultsOutputLocation), "The string is invalid");
            
            this.testInputPath = testInputPath;
            this.testDescription = testDescription;
            this.testDataLocation = testDataLocation;
            this.resultsOutputLocation = resultsOutputLocation;
            this.autoFix = autoFix;
            this.addinFiles = addinFiles;
            this.frameworkVersion = simulationFrameworkVersion;
        }

        #endregion Internal Constructors

        #region Public Static Methods

        /// <summary>
        /// Runs the test.
        /// </summary>
        /// <param name="testName">The name of the test.</param>
        /// <param name="testRoot">The root folder which contains the test data folder.</param>
        /// <param name="testInputLocation">The test run input location.</param>
        /// <param name="testOutputLocation">The test run output location.</param>
        /// <param name="autoFix">Indicates whether to run StyleCop in "auto-fix" mode.</param>
        /// <param name="simulationFrameworkVersion">The framework version to simulate.</param>
        /// <param name="addinFiles">Additional add-in files to copy to the test bin directory.</param>
        /// <returns>
        /// Returns true if the test passes.
        /// </returns>
        public static bool Run(string testName, string testRoot, string testInputLocation, string testOutputLocation, bool autoFix, double simulationFrameworkVersion, params string[] addinFiles)
        {
            Param.RequireValidString(testName, "testName");
            Param.RequireValidString(testRoot, "testRoot");
            Param.RequireValidString(testInputLocation, "testInputLocation");
            Param.RequireValidString(testOutputLocation, "testOutputLocation");
            Param.Ignore(simulationFrameworkVersion);
            Param.Ignore(autoFix);
            Param.Ignore(addinFiles);

            string resultsOutputLocation = Path.Combine(testOutputLocation, testName + "Results.xml");
            string testDataLocation = Path.Combine(testOutputLocation, testName);
            string testDescriptionLocation = Path.Combine(testDataLocation, "TestDescription.xml");

            if (!File.Exists(testDescriptionLocation))
            {
                Console.WriteLine(Strings.MissingTestDescriptionFile, testDescriptionLocation);
            }
            else
            {
                Exception exception = null;
                XmlDocument testDescriptionDocument = new XmlDocument();

                try
                {
                    testDescriptionDocument.Load(testDescriptionLocation);
                }
                catch (XmlException xmlex)
                {
                    exception = xmlex;
                }
                catch (SecurityException secex)
                {
                    exception = secex;
                }
                catch (UnauthorizedAccessException unauthex)
                {
                    exception = unauthex;
                }
                catch (ArgumentException argex)
                {
                    exception = argex;
                }

                if (exception != null)
                {
                    Console.WriteLine(Strings.TestDescriptionFileNotLoaded, testDescriptionLocation, exception.Message);
                }
                else
                {
                    StyleCopTestRunner runner = new StyleCopTestRunner(testInputLocation, testDescriptionDocument, testDataLocation, resultsOutputLocation, autoFix, addinFiles, simulationFrameworkVersion);
                    return runner.RunTests();
                }
            }

            return false;
        }

        #endregion Public Static Methods

        #region Internal Methods

        /// <summary>
        /// Runs the test and outputs the result.
        /// </summary>
        /// <returns>Returns true if the test passes.</returns>
        internal bool RunTests()
        {
            // Copy the test data files into the test run directory.
            CopyTestDataFiles(this.testDataLocation, Path.Combine(this.testInputPath, "_OriginalFiles"));
            CopyAdditionalAddinFiles(this.testInputPath, this.addinFiles);

            // Get the name of the test.
            XmlAttribute testName = this.testDescription.DocumentElement.Attributes["TestName"];
            if (testName == null || string.IsNullOrEmpty(testName.Value))
            {
                this.AddTestResult(false, Strings.UnknownTestSuite, null, Strings.MissingOverallTestName);
            }
            else
            {
                // Set up the test results output document.
                this.PrepareTestResultsOutputDocument(testName.Value);

                // Run each of the tests.
                XmlNodeList tests = this.testDescription.SelectNodes("StyleCopTestDescription/Test");
                if (tests != null)
                {
                    foreach (XmlNode test in tests)
                    {
                        this.RunTest(test, this.autoFix);
                    }
                }
            }

            // Add the overall test result.
            XmlElement overallResults = this.resultsOutput.CreateElement("TestResult");
            overallResults.InnerText = this.failure ? "Failed" : "Passed";
            this.resultsOutput.DocumentElement.AppendChild(overallResults);

            // Add the InnerTests tag.
            this.resultsOutput.DocumentElement.AppendChild(this.innerTestsNode);

            // Save the results document.
            this.SaveResultsOutputDocument();

            return !this.failure;
        }

        #endregion Internal Methods

        #region Private Static Methods

        /// <summary>
        /// Extracts information about a violation from the given node.
        /// </summary>
        /// <param name="violationNode">The violation node.</param>
        /// <returns>Returns the violation information.</returns>
        private static ViolationInfo ExtractViolationInfo(XmlNode violationNode)
        {
            // Load the section.
            string section = null;
            XmlAttribute attribute = violationNode.Attributes["Section"];
            if (attribute != null)
            {
                section = attribute.Value;
            }

            // Load the rule name.
            string ruleName = null;
            attribute = violationNode.Attributes["Rule"];
            if (attribute != null)
            {
                ruleName = attribute.Value;
            }

            // Load the rule namespace.
            string ruleNamespace = null;
            attribute = violationNode.Attributes["RuleNamespace"];
            if (attribute != null)
            {
                ruleNamespace = attribute.Value;
            }

            // Load the line number.
            int lineNumber = -1;
            attribute = violationNode.Attributes["LineNumber"];
            if (attribute != null)
            {
                int temp;
                if (int.TryParse(attribute.Value, out temp))
                {
                    lineNumber = temp;
                }
            }

            // Load the start line number.
            int startLineNumber = -1;
            attribute = violationNode.Attributes["StartLine"];
            if (attribute != null)
            {
                int temp;
                if (int.TryParse(attribute.Value, out temp))
                {
                    startLineNumber = temp;
                }
            }

            // Load the end line number.
            int endLineNumber = -1;
            attribute = violationNode.Attributes["EndLine"];
            if (attribute != null)
            {
                int temp;
                if (int.TryParse(attribute.Value, out temp))
                {
                    endLineNumber = temp;
                }
            }

            // Load the start column number.
            int startColumnNumber = -1;
            attribute = violationNode.Attributes["StartColumn"];
            if (attribute != null)
            {
                int temp;
                if (int.TryParse(attribute.Value, out temp))
                {
                    startColumnNumber = temp;
                }
            }

            // Load the end column number.
            int endColumnNumber = -1;
            attribute = violationNode.Attributes["EndColumn"];
            if (attribute != null)
            {
                int temp;
                if (int.TryParse(attribute.Value, out temp))
                {
                    endColumnNumber = temp;
                }
            }
            
            ViolationInfo violation = new ViolationInfo(section, lineNumber, startLineNumber, startColumnNumber, endLineNumber, endColumnNumber, ruleNamespace, ruleName);
            return violation;
        }

        /// <summary>
        /// Loads the list of expected violations from the given test node.
        /// </summary>
        /// <param name="resultsFilePath">The path to the test results file.</param>
        /// <returns>Returns the list of expected violations.</returns>
        private static List<ViolationInfo> LoadActualViolations(string resultsFilePath)
        {
            List<ViolationInfo> list = new List<ViolationInfo>();

            if (File.Exists(resultsFilePath))
            {
                try
                {
                    XmlDocument resultsDocument = new XmlDocument();
                    resultsDocument.Load(resultsFilePath);

                    XmlNodeList violationNodes = resultsDocument.SelectNodes("StyleCopViolations/Violation");
                    if (violationNodes != null)
                    {
                        foreach (XmlNode violationNode in violationNodes)
                        {
                            ViolationInfo violation = ExtractViolationInfo(violationNode);
                            list.Add(violation);
                        }
                    }
                }
                catch (XmlException)
                {
                }
                catch (IOException)
                {
                }
                catch (SecurityException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }

            return list;
        }

        /// <summary>
        /// Loads the list of expected violations from the given test node.
        /// </summary>
        /// <param name="testNode">The test node.</param>
        /// <returns>Returns the list of expected violations.</returns>
        private static List<ViolationInfo> LoadExpectedViolations(XmlNode testNode)
        {
            List<ViolationInfo> list = new List<ViolationInfo>();

            XmlNodeList expectedViolationNodes = testNode.SelectNodes("ExpectedViolations/Violation");
            if (expectedViolationNodes != null)
            {
                foreach (XmlNode expectedViolationNode in expectedViolationNodes)
                {
                    ViolationInfo violation = ExtractViolationInfo(expectedViolationNode);
                    list.Add(violation);
                }
            }

            return list;
        }

        /// <summary>
        /// Loads an Xml file.
        /// </summary>
        /// <param name="fileLocation">The location of the file to load.</param>
        /// <param name="errorMessage">Returns an error message if the file could not be loaded.</param>
        /// <returns>Returns the document.</returns>
        private static XmlDocument LoadXmlDocument(string fileLocation, out string errorMessage)
        {
            Debug.Assert(!string.IsNullOrEmpty(fileLocation), "The string is invalid");

            errorMessage = null;
            XmlDocument document = null;

            if (File.Exists(fileLocation))
            {
                document = new XmlDocument();

                try
                {
                    document.Load(fileLocation);
                }
                catch (XmlException xmlex)
                {
                    document = null;
                    errorMessage = xmlex.Message;
                }
                catch (IOException ioex)
                {
                    document = null;
                    errorMessage = ioex.Message;
                }
                catch (SecurityException secex)
                {
                    document = null;
                    errorMessage = secex.Message;
                }
                catch (UnauthorizedAccessException unauthex)
                {
                    document = null;
                    errorMessage = unauthex.Message;
                }
            }

            return document;
        }

        /// <summary>
        /// Determines whether the violation matches the given expected violation.
        /// </summary>
        /// <param name="expectedViolation">The expected violation.</param>
        /// <param name="actualViolation">The actual violation.</param>
        /// <returns>Returns true if there is a match.</returns>
        private static bool MatchesExpectedViolation(ViolationInfo expectedViolation, ViolationInfo actualViolation)
        {
            Debug.Assert(expectedViolation != null, "The parameter must not be null");
            Debug.Assert(actualViolation != null, "The parameter must not be null");

            // Compare the line numbers.
            if (expectedViolation.LineNumber >= 0)
            {
                if (actualViolation.LineNumber != expectedViolation.LineNumber)
                {
                    return false;
                }
            }

            if (expectedViolation.StartLineNumber >= 0)
            {
                if (actualViolation.StartLineNumber != expectedViolation.StartLineNumber)
                {
                    return false;
                }
            }

            if (expectedViolation.StartColumnNumber >= 0)
            {
                if (actualViolation.StartColumnNumber != expectedViolation.StartColumnNumber)
                {
                    return false;
                }
            }

            if (expectedViolation.EndLineNumber >= 0)
            {
                if (actualViolation.EndLineNumber != expectedViolation.EndLineNumber)
                {
                    return false;
                }
            }

            if (expectedViolation.EndColumnNumber >= 0)
            {
                if (actualViolation.EndColumnNumber != expectedViolation.EndColumnNumber)
                {
                    return false;
                }
            }

            // Compare the rule names.
            if (expectedViolation.RuleName != null)
            {
                if (actualViolation.RuleName == null || !string.Equals(expectedViolation.RuleName, actualViolation.RuleName, StringComparison.Ordinal))
                {
                    return false;
                }
            }

            // Compare the rule namespaces.
            if (expectedViolation.RuleNamespace != null)
            {
                if (actualViolation.RuleNamespace == null || !string.Equals(expectedViolation.RuleNamespace, actualViolation.RuleNamespace, StringComparison.Ordinal))
                {
                    return false;
                }
            }

            // Compare the sections.
            if (expectedViolation.Section != null)
            {
                if (actualViolation.Section == null || !string.Equals(expectedViolation.Section, actualViolation.Section, StringComparison.Ordinal))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sets up a CodeProject for use during the test.
        /// </summary>
        /// <param name="testInfo">The test information.</param>
        /// <param name="console">The console which will run the test.</param>
        /// <param name="autoFix">Indicates whether the test is running in auto-fix mode.</param>
        /// <param name="copy">Indicates whether to create the file copy.</param>
        /// <param name="simulationFrameworkVersion">The framework version to simulate.</param>
        /// <returns>
        /// Returns the CodeProject.
        /// </returns>
        private static CodeProject PrepareCodeProjectForTest(TestInfo testInfo, StyleCopConsole console, bool autoFix, bool copy, double simulationFrameworkVersion)
        {
            // Create an empty configuration.
            Configuration configuration = new Configuration(null);

            // Create a CodeProject for the test file.
            CodeProject project = new CodeProject(
                "TheProject".GetHashCode(),
                Path.GetDirectoryName(testInfo.StyleCopSettingsFileLocation),
                configuration, 
                simulationFrameworkVersion);

            // Add each source file to this project.
            foreach (TestCodeFileInfo sourceFile in testInfo.TestCodeFiles)
            {
                if (autoFix)
                {
                    string autoFixFile = testInfo.AutoFixFileName(sourceFile.CodeFile);
                    console.Core.Environment.AddSourceCode(project, autoFixFile, null);

                    if (copy)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(autoFixFile));
                        File.Copy(sourceFile.CodeFile, autoFixFile);
                    }
                }
                else
                {
                    console.Core.Environment.AddSourceCode(project, sourceFile.CodeFile, null);
                }
            }

            return project;
        }

        /// <summary>
        /// Sets up a StyleCopConsole to run the given test.
        /// </summary>
        /// <param name="testInfo">Information about the test to run.</param>
        /// <param name="autoFix">Indicates whether StyleCop should automatically fix the violations it finds.</param>
        /// <returns>Returns the StyleCopConsole.</returns>
        private static StyleCopConsole PrepareStyleCopConsoleForTest(TestInfo testInfo, bool autoFix)
        {
            Debug.Assert(testInfo != null, "The parameter must not be null");

            // Create a list of addin paths and add the path to the currently executing test assembly.
            List<string> addinPaths = new List<string>(1);

            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            addinPaths.Add(Path.GetDirectoryName(assemblyLocation));
            addinPaths.Add(Path.GetDirectoryName(Path.Combine(testInfo.TestOutputPath, @"..\..\")));
            
            // Create the StyleCop console.
            StyleCopConsole console = new StyleCopConsole(
                testInfo.StyleCopSettingsFileLocation,
                false,
                testInfo.StyleCopOutputLocation,
                addinPaths,
                false,
                testInfo.TestOutputPath);

            return console;
        }

        /// <summary>
        /// Writes information about the given violation to the log node.
        /// </summary>
        /// <param name="violationInfo">The violation information.</param>
        /// <param name="root">The log node to write the information into.</param>
        private static void WriteViolationDetailToLog(ViolationInfo violationInfo, XmlNode root)
        {
            Debug.Assert(violationInfo != null, "The parameter must not be null");
            Debug.Assert(root != null, "The parameter must not be null");

            XmlElement violation = root.OwnerDocument.CreateElement("Violation");

            if (!string.IsNullOrEmpty(violationInfo.Section))
            {
                XmlAttribute section = root.OwnerDocument.CreateAttribute("Section");
                section.Value = violationInfo.Section;
                violation.Attributes.Append(section);
            }

            if (violationInfo.LineNumber >= 0)
            {
                XmlAttribute lineNumber = root.OwnerDocument.CreateAttribute("LineNumber");
                lineNumber.Value = violationInfo.LineNumber.ToString(CultureInfo.CurrentCulture);
                violation.Attributes.Append(lineNumber);
            }

            if (violationInfo.StartLineNumber >= 0)
            {
                XmlAttribute startLineNumber = root.OwnerDocument.CreateAttribute("StartLine");
                startLineNumber.Value = violationInfo.StartLineNumber.ToString(CultureInfo.CurrentCulture);
                violation.Attributes.Append(startLineNumber);
            }

            if (violationInfo.StartColumnNumber >= 0)
            {
                XmlAttribute startColumnNumber = root.OwnerDocument.CreateAttribute("StartColumn");
                startColumnNumber.Value = violationInfo.StartColumnNumber.ToString(CultureInfo.CurrentCulture);
                violation.Attributes.Append(startColumnNumber);
            }

            if (violationInfo.EndLineNumber >= 0)
            {
                XmlAttribute endLineNumber = root.OwnerDocument.CreateAttribute("EndLine");
                endLineNumber.Value = violationInfo.EndLineNumber.ToString(CultureInfo.CurrentCulture);
                violation.Attributes.Append(endLineNumber);
            }

            if (violationInfo.EndColumnNumber >= 0)
            {
                XmlAttribute endColumnNumber = root.OwnerDocument.CreateAttribute("EndColumn");
                endColumnNumber.Value = violationInfo.EndColumnNumber.ToString(CultureInfo.CurrentCulture);
                violation.Attributes.Append(endColumnNumber);
            }

            if (!string.IsNullOrEmpty(violationInfo.RuleNamespace))
            {
                XmlAttribute ruleNamespace = root.OwnerDocument.CreateAttribute("RuleNamespace");
                ruleNamespace.Value = violationInfo.RuleNamespace;
                violation.Attributes.Append(ruleNamespace);
            }

            if (!string.IsNullOrEmpty(violationInfo.RuleName))
            {
                XmlAttribute ruleName = root.OwnerDocument.CreateAttribute("Rule");
                ruleName.Value = violationInfo.RuleName;
                violation.Attributes.Append(ruleName);
            }

            root.AppendChild(violation);
        }

        /// <summary>
        /// Copies each additional add-in file to the test bin directory.
        /// </summary>
        /// <param name="testBinDirectory">The test bin directory.</param>
        /// <param name="addinFiles">The collection of additional add-in files.</param>
        private static void CopyAdditionalAddinFiles(string testBinDirectory, IEnumerable<string> addinFiles)
        {
            Debug.Assert(testBinDirectory != null, "The parameter cannot be null.");

            try
            {
                if (!Directory.Exists(testBinDirectory))
                {
                    Directory.CreateDirectory(testBinDirectory);
                }

                if (addinFiles != null)
                {
                    foreach (string addinFile in addinFiles)
                    {
                        if (!string.IsNullOrEmpty(addinFile) && File.Exists(addinFile))
                        {
                            try
                            {
                                File.Copy(addinFile, Path.Combine(testBinDirectory, Path.GetFileName(addinFile)), true);
                            }
                            catch (IOException)
                            {
                                // We get some of these because the files we're copying are in use y our mult proc test running
                            }
                        }
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("IOException occurred while copying data files into test bin dir: " + ioex.Message);
            }
            catch (UnauthorizedAccessException unauthex)
            {
                Console.WriteLine("UnauthorizedAccessException occurred while copying data files into test bin dir: " + unauthex.Message);
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine("ArgumentException occurred while copying data files into test bin dir: " + argex.Message);
            }
        }

        /// <summary>
        /// Copies each of the test data files into the test run directory.
        /// </summary>
        /// <param name="testDataFilesLocation">The location of the test data files to copy.</param>
        /// <param name="testRunDirectory">The test run directory to copy the files into.</param>
        private static void CopyTestDataFiles(string testDataFilesLocation, string testRunDirectory)
        {
            Debug.Assert(testDataFilesLocation != null, "The parameter cannot be null");
            Debug.Assert(testRunDirectory != null, "testRunDirectory");

            try
            {
                if (!Directory.Exists(testRunDirectory))
                {
                    Directory.CreateDirectory(testRunDirectory);
                }

                string[] files = Directory.GetFiles(testDataFilesLocation);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);

                    if (!string.Equals(fileName, "TestDescription.xml", StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(file, Path.Combine(testRunDirectory, fileName), true);
                    }
                }

                string[] directories = Directory.GetDirectories(testDataFilesLocation);

                foreach (string directory in directories)
                {
                    string directoryName = Path.GetFileName(directory);

                    CopyTestDataFiles(directory, Path.Combine(testRunDirectory, directoryName));
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("IOException occurred while copying data files into test run dir: " + ioex.Message);
            }
            catch (UnauthorizedAccessException unauthex)
            {
                Console.WriteLine("UnauthorizedAccessException occurred while copying data files into test run dir: " + unauthex.Message);
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine("ArgumentException occurred while copying data files into test run dir: " + argex.Message);
            }
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Runs a test.
        /// </summary>
        /// <param name="testNode">Contains information about the test to run.</param>
        /// <param name="autoFix">Indicates whether to run StyleCop in "auto-fix" mode.</param>
        private void RunTest(XmlNode testNode, bool autoFix)
        {
            Debug.Assert(testNode != null, "The parameter must not be null");

            // Extract the test information.
            TestInfo testInfo = this.PrepareTest(testNode);
            if (testInfo != null)
            {
                this.RunTest(testInfo, autoFix);
            }
        }

        /// <summary>
        /// Runs a test.
        /// </summary>
        /// <param name="testInfo">Contains information about the test to run.</param>
        /// <param name="autoFix">Indicates whether to run StyleCop in "auto-fix" mode.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "This is test code.")]
        private void RunTest(TestInfo testInfo, bool autoFix)
        {
            bool run = true;
            if (autoFix)
            {
                run = this.PrepareFixedFiles(testInfo);
            }

            // Set up the source analysis settings file to use for the test.
            if (run && this.PrepareStyleCopSettingsFile(testInfo))
            {
                // Set up the StyleCop console which will run the test.
                StyleCopConsole testConsole = PrepareStyleCopConsoleForTest(testInfo, false);

                CodeProject project = PrepareCodeProjectForTest(testInfo, testConsole, autoFix, false, this.frameworkVersion);

                // Run the test and capture any exceptions.
                Exception testException = null;

                try
                {
                    // Run StyleCop.
                    testConsole.Start(new CodeProject[] { project }, true);
                }
                catch (OutOfMemoryException)
                {
                    throw;
                }
                catch (ThreadAbortException)
                {
                    // The thread is being aborted.
                }
                catch (Exception ex)
                {
                    // Catch and log all other exceptions thrown during the test. 
                    testException = ex;
                }

                // If an exception occurred, log it; otherwise analyze the test results.
                if (testException != null)
                {
                    this.AddTestResult(false, testInfo.TestName, null, Strings.TestException, testException.Message);
                }
                else
                {
                    // Process the results.
                    this.AnalyzeTestResults(testInfo);
                }
            }
        }

        /// <summary>
        /// Runs StyleCop in auto-fix mode to clean up violations in the files.
        /// </summary>
        /// <param name="testInfo">The test information.</param>
        /// <returns>Returns false if StyleCop encountered an error.</returns>
        private bool PrepareFixedFiles(TestInfo testInfo)
        {
            // Set up the source analyis settings file to use for the test.
            if (this.PrepareStyleCopSettingsFile(testInfo))
            {
                // Set up the StyleCop console which will run the test.
                StyleCopConsole testConsole = PrepareStyleCopConsoleForTest(testInfo, true);

                CodeProject project = PrepareCodeProjectForTest(testInfo, testConsole, true, true, this.frameworkVersion);

                // Run the test and capture any exceptions.
                Exception testException = null;

                try
                {
                    // Run StyleCop.
                    testConsole.Start(new CodeProject[] { project }, true);
                }
                catch (OutOfMemoryException)
                {
                    throw;
                }
                catch (ThreadAbortException)
                {
                    // The thread is being aborted.
                }
                catch (Exception ex)
                {
                    // Catch and log all other exceptions thrown during the test. 
                    testException = ex;
                }

                // If an exception occurred, log it; otherwise analyze the test results.
                if (testException != null)
                {
                    this.AddTestResult(false, testInfo.TestName, null, Strings.TestException, testException.Message);
                    return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Prepares to run a test.
        /// </summary>
        /// <param name="testNode">The node containing information about the test.</param>
        /// <returns>Returns the information needed for running the test.</returns>
        private TestInfo PrepareTest(XmlNode testNode)
        {
            Debug.Assert(testNode != null, "The parameter must not be null");

            // Get the name of the test.
            XmlAttribute testNameAttribute = testNode.Attributes["Name"];
            if (testNameAttribute == null || string.IsNullOrEmpty(testNameAttribute.Value))
            {
                this.AddTestResult(false, Strings.UnknownTest, null, Strings.MissingTestName);
                return null;
            }

            // Get the collection of code files to test.
            XmlNodeList codeFileNodes = testNode.SelectNodes("TestCodeFile");
            if (codeFileNodes == null || codeFileNodes.Count == 0)
            {
                this.AddTestResult(false, testNameAttribute.Value, null, Strings.MissingTestCodeFiles);
                return null;
            }

            List<TestCodeFileInfo> codeFiles = new List<TestCodeFileInfo>();
            foreach (XmlNode codeFileNode in codeFileNodes)
            {
                if (string.IsNullOrEmpty(codeFileNode.InnerText))
                {
                    this.AddTestResult(false, testNameAttribute.Value, null, Strings.MissingTestCodeFile, codeFileNode.InnerText);
                    return null;
                }

                string codeFilePath = Path.Combine(Path.Combine(this.testInputPath, "_OriginalFiles"), codeFileNode.InnerText);

                if (!File.Exists(codeFilePath))
                {
                    this.AddTestResult(false, testNameAttribute.Value, null, Strings.MissingTestCodeFile, codeFileNode.InnerText);
                    return null;
                }

                TestCodeFileInfo file = new TestCodeFileInfo();
                file.CodeFile = codeFilePath;

                // Determine whether to test the parser object model for this file.
                XmlAttribute testObjectModel = codeFileNode.Attributes["TestObjectModel"];
                if (testObjectModel != null)
                {
                    bool enabled = false;
                    if (bool.TryParse(testObjectModel.Value, out enabled) && enabled)
                    {
                        file.TestObjectModel = true;
                    }
                }

                codeFiles.Add(file);
            }

            // Fill in the TestInfo and return it.
            return new TestInfo(testNode, testNameAttribute.Value, codeFiles, this.testInputPath);
        }

        /// <summary>
        /// Analyzes the results of the test run and outputs the results file.
        /// </summary>
        /// <param name="testInfo">Contains the test results.</param>
        private void AnalyzeTestResults(TestInfo testInfo)
        {
            bool allTestsAreParserTests = true; 

            // Check each of the code files to see whether we should compare the 
            // parser object models.
            foreach (TestCodeFileInfo codeFileInfo in testInfo.TestCodeFiles)
            {
                if (codeFileInfo.TestObjectModel)
                {
                    this.AnalyzeCodeFileObjectModel(testInfo, codeFileInfo.CodeFile);
                }
                else
                {
                    allTestsAreParserTests = false;
                }
            }

            if (!allTestsAreParserTests)
            {
                // Load the expected violations.
                List<ViolationInfo> expectedViolations = LoadExpectedViolations(testInfo.TestDescription);
                if (expectedViolations != null)
                {
                    this.AnalyzeViolations(testInfo, expectedViolations);
                }
            }
        }

        /// <summary>
        /// Compares the list of expected violations against the actual violations produced by the test.
        /// </summary>
        /// <param name="testInfo">The test information.</param>
        /// <param name="expectedViolations">The list of expected violations.</param>
        private void AnalyzeViolations(TestInfo testInfo, List<ViolationInfo> expectedViolations)
        {
            Param.AssertNotNull(testInfo, "testInfo");
            Param.AssertNotNull(expectedViolations, "expectedViolations");

            // Open the results file.
            string errorMessage;
            XmlDocument styleCopAnalysisResultsDocument = LoadXmlDocument(testInfo.StyleCopOutputLocation, out errorMessage);

            if (styleCopAnalysisResultsDocument == null)
            {
                this.AddTestResult(false, testInfo.TestName, null, Strings.MissingResultsFile, testInfo.StyleCopOutputLocation);
            }
            else
            {
                // Load the actual violations.
                List<ViolationInfo> actualViolations = LoadActualViolations(testInfo.StyleCopOutputLocation);

                // Manually verify that the violations are the same.
                int expectedViolationIndex = 0;
                while (expectedViolations.Count > 0 && expectedViolationIndex < expectedViolations.Count)
                {
                    ViolationInfo expectedViolation = expectedViolations[expectedViolationIndex];

                    bool found = false;

                    foreach (ViolationInfo actualViolation in actualViolations)
                    {
                        if (MatchesExpectedViolation(expectedViolation, actualViolation))
                        {
                            expectedViolations.Remove(expectedViolation);
                            actualViolations.Remove(actualViolation);

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        ++expectedViolationIndex;
                    }
                }

                XmlDocument detailLog = null;

                if (expectedViolations.Count > 0 || actualViolations.Count > 0)
                {
                    detailLog = new XmlDocument();
                    detailLog.AppendChild(detailLog.CreateElement("StyleCopTestFailureDetails"));

                    if (expectedViolations.Count > 0)
                    {
                        // There were more expected violations than actual violations.
                        XmlElement root = detailLog.CreateElement("MissingExpectedViolations");
                        detailLog.DocumentElement.AppendChild(root);

                        foreach (ViolationInfo violationInfo in expectedViolations)
                        {
                            WriteViolationDetailToLog(violationInfo, root);
                        }
                    }

                    if (actualViolations.Count > 0)
                    {
                        // There were more actual violations than expected violations.
                        XmlElement root = detailLog.CreateElement("ExtraActualViolations");
                        detailLog.DocumentElement.AppendChild(root);

                        foreach (ViolationInfo violationInfo in actualViolations)
                        {
                            WriteViolationDetailToLog(violationInfo, root);
                        }
                    }

                    string detailLogPath = this.SaveViolationDetailLog(testInfo, detailLog);

                    this.AddTestResult(false, testInfo.TestName, detailLogPath, Strings.MismatchedViolations);
                }
            }
        }

        /// <summary>
        /// Analyzes the resulting object model for the given code file against the expected
        /// object model, to test the parser output.
        /// </summary>
        /// <param name="testInfo">The test information.</param>
        /// <param name="codeFile">The the code file to check.</param>
        private void AnalyzeCodeFileObjectModel(TestInfo testInfo, string codeFile)
        {
            // Extract the name of the code file.
            string fileName = Path.GetFileNameWithoutExtension(codeFile);

            // Figure out the path to the expected object model file and the actual
            // object model file.
            string expectedObjectModelFilePath = Path.Combine(this.testDataLocation, fileName + "ObjectModel.xml");
            string actualObjectModelFilePath = Path.Combine(testInfo.TestOutputPath, fileName + "ObjectModelResults.xml");
            
            // Load both of the files.
            string errorMessage;
            XmlDocument expectedObjectModel = LoadXmlDocument(expectedObjectModelFilePath, out errorMessage);
            if (expectedObjectModel == null)
            {
                this.AddTestResult(false, testInfo.TestName, null, Strings.MissingExpectedObjectModelFile, expectedObjectModelFilePath);
                return;
            }

            XmlDocument actualObjectModel = LoadXmlDocument(actualObjectModelFilePath, out errorMessage);
            if (actualObjectModel == null)
            {
                this.AddTestResult(false, testInfo.TestName, null, Strings.MissingActualObjectModelFile, actualObjectModelFilePath);
                return;
            }

            // Compare the two documents to see if they are equal.
            if (!this.CompareXmlDocuments(expectedObjectModel, actualObjectModel))
            {
                this.AddTestResult(false, testInfo.TestName, actualObjectModelFilePath, Strings.ParserObjectModelMismatch);
            }
        }

        /// <summary>
        /// Compares two Xml documents to ensure that they are identical.
        /// </summary>
        /// <param name="document1">The first document to compare.</param>
        /// <param name="document2">The second document to compare.</param>
        /// <returns>Returns true if the documents are identical; otherwise false.</returns>
        private bool CompareXmlDocuments(XmlDocument document1, XmlDocument document2)
        {
            Param.AssertNotNull(document1, "document1");
            Param.AssertNotNull(document2, "document2");

            return this.CompareXmlNodes(document1.DocumentElement, document2.DocumentElement);
        }

        /// <summary>
        /// Compares two Xml nodes to ensure that they are identical.
        /// </summary>
        /// <param name="node1">The first node to compare.</param>
        /// <param name="node2">The second node to compare.</param>
        /// <returns>Returns true if the nodes are identical; otherwise false.</returns>
        private bool CompareXmlNodes(XmlNode node1, XmlNode node2)
        {
            Param.AssertNotNull(node1, "node1");
            Param.AssertNotNull(node2, "node2");

            // Ensure that the names of the nodes are the same.
            if (string.Compare(node1.Name, node2.Name, StringComparison.Ordinal) != 0)
            {
                return false;
            }

            // Ensure that the nodes have the same number of attributes.
            if (node1.Attributes.Count != node2.Attributes.Count)
            {
                return false;
            }

            // Ensure that the names and values of all attributes are the same.
            for (int i = 0; i < node1.Attributes.Count; ++i)
            {
                XmlAttribute node1Attribute = node1.Attributes[i];
                XmlAttribute node2Attribute = node2.Attributes[i];

                if (string.Compare(node1Attribute.Name, node2Attribute.Name, StringComparison.Ordinal) != 0)
                {
                    return false;
                }

                if (string.Compare(node1Attribute.Value, node2Attribute.Value, StringComparison.Ordinal) != 0)
                {
                    return false;
                }
            }

            // Ensure that the nodes have the same number of child nodes.
            if (node1.ChildNodes.Count != node2.ChildNodes.Count)
            {
                return false;
            }

            if (node1.ChildNodes.Count == 0)
            {
                // Compare the inner text of the two nodes.
                if (string.Compare(node1.InnerText, node2.InnerText, StringComparison.Ordinal) != 0)
                {
                    return false;
                }
            }
            else
            {
                // Compare the contents of the child nodes.
                for (int i = 0; i < node1.ChildNodes.Count; ++i)
                {
                    XmlNode node1Child = node1.ChildNodes[i];
                    XmlNode node2Child = node2.ChildNodes[i];

                    if (!this.CompareXmlNodes(node1Child, node2Child))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Saves the given violation detail log.
        /// </summary>
        /// <param name="testInfo">Contains information about the test.</param>
        /// <param name="detailLog">The detail log to save.</param>
        /// <returns>Returns the path to the log file.</returns>
        private string SaveViolationDetailLog(TestInfo testInfo, XmlDocument detailLog)
        {
            Debug.Assert(detailLog != null, "The parameter must not be null");

            string path = Path.Combine(
                Path.GetDirectoryName(this.resultsOutputLocation),
                string.Concat(testInfo.TestName, "_ExpectedViolationMismatchDetail.xml"));

            try
            {
                detailLog.Save(path);
            }
            catch (XmlException xmlex)
            {
                Console.WriteLine(Strings.CouldNotWriteDetailLog, path, xmlex.Message);
            }
            catch (IOException ioex)
            {
                Console.WriteLine(Strings.CouldNotWriteDetailLog, path, ioex.Message);
            }
            catch (SecurityException secex)
            {
                Console.WriteLine(Strings.CouldNotWriteDetailLog, path, secex.Message);
            }
            catch (UnauthorizedAccessException unauthex)
            {
                Console.WriteLine(Strings.CouldNotWriteDetailLog, path, unauthex.Message);
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine(Strings.CouldNotWriteDetailLog, path, argex.Message);
            }

            return path;
        }

        /// <summary>
        /// Prepares the results output document for use.
        /// </summary>
        /// <param name="testName">The name of the test.</param>
        private void PrepareTestResultsOutputDocument(string testName)
        {
            this.resultsOutput = new XmlDocument();

            XmlElement rootElement = this.resultsOutput.CreateElement("SummaryResult");
            this.resultsOutput.AppendChild(rootElement);

            XmlElement testNameNode = this.resultsOutput.CreateElement("TestName");
            testNameNode.InnerText = testName;
            this.overallTestName = testName;
            rootElement.AppendChild(testNameNode);

            this.innerTestsNode = this.resultsOutput.CreateElement("InnerTests");
        }

        /// <summary>
        /// Saves the results document.
        /// </summary>
        private void SaveResultsOutputDocument()
        {
            Exception exception = null;

            try
            {
                this.resultsOutput.Save(this.resultsOutputLocation);
            }
            catch (XmlException xmlex)
            {
                exception = xmlex;
            }
            catch (SecurityException secex)
            {
                exception = secex;
            }
            catch (UnauthorizedAccessException unauthex)
            {
                exception = unauthex;
            }
            catch (IOException ioex)
            {
                exception = ioex;
            }
            catch (ArgumentException argex)
            {
                exception = argex;
            }

            if (exception != null)
            {
                Console.WriteLine(Strings.CouldNotWriteResultsFile, this.overallTestName);
            }
        }

        /// <summary>
        /// Adds test result information to the output file.
        /// </summary>
        /// <param name="passed">Indicates whether the test passed or failed.</param>
        /// <param name="testName">The name of the test.</param>
        /// <param name="detailedResultsFilePath">The path to the detailed results file for the test.</param>
        /// <param name="message">The test results message.</param>
        /// <param name="messageParameters">Optional parameters for the message string.</param>
        private void AddTestResult(bool passed, string testName, string detailedResultsFilePath, string message, params string[] messageParameters)
        {
            Debug.Assert(!string.IsNullOrEmpty(testName), "The string is invalid");
            Debug.Assert(!string.IsNullOrEmpty(message), "The string is invalid");

            XmlNode innerTestNode = this.resultsOutput.CreateElement("InnerTest");

            XmlNode testNameNode = this.resultsOutput.CreateElement("TestName");
            testNameNode.InnerText = testName;
            innerTestNode.AppendChild(testNameNode);

            XmlNode testResultNode = this.resultsOutput.CreateElement("TestResult");
            testResultNode.InnerText = passed ? "Passed" : "Failed";
            innerTestNode.AppendChild(testResultNode);

            XmlNode testMessageNode = this.resultsOutput.CreateElement("ErrorMessage");
            testMessageNode.InnerText = string.Format(CultureInfo.CurrentCulture, message, messageParameters);
            innerTestNode.AppendChild(testMessageNode);

            if (!string.IsNullOrEmpty(detailedResultsFilePath))
            {
                // Add the path to the detailed results file.
                XmlNode detailedResultsNode = this.resultsOutput.CreateElement("DetailedResultsFile");
                detailedResultsNode.InnerText = detailedResultsFilePath;
                innerTestNode.AppendChild(detailedResultsNode);
            }

            this.innerTestsNode.AppendChild(innerTestNode);

            if (!passed)
            {
                this.failure = true;
            }
        }

        /// <summary>
        /// Sets up a StyleCop settings file for use during the test.
        /// </summary>
        /// <param name="testInfo">The test information.</param>
        /// <returns>Returns true on success; false on error.</returns>
        private bool PrepareStyleCopSettingsFile(TestInfo testInfo)
        {
            XmlDocument settings = new XmlDocument();

            // Add the root node.
            XmlElement root = settings.CreateElement("StyleCopSettings");

            XmlAttribute attribute = settings.CreateAttribute("Version");
            attribute.Value = "4.3";
            root.Attributes.Append(attribute);

            settings.AppendChild(root);

            // Add any settings provided in the test description document.
            XmlNode additionalSettings = testInfo.TestDescription.SelectSingleNode("Settings");
            if (additionalSettings != null)
            {
                foreach (XmlNode child in additionalSettings.ChildNodes)
                {
                    XmlNode importedChild = settings.ImportNode(child, true);
                    root.AppendChild(importedChild);
                }
            }

            // Try to save the settings file.
            Exception exception = null;

            try
            {
                settings.Save(testInfo.StyleCopSettingsFileLocation);
            }
            catch (XmlException xmlex)
            {
                exception = xmlex;
            }
            catch (IOException ioex)
            {
                exception = ioex;
            }
            catch (SecurityException secex)
            {
                exception = secex;
            }
            catch (UnauthorizedAccessException unauthex)
            {
                exception = unauthex;
            }

            if (exception != null)
            {
                this.AddTestResult(
                    false,
                    testInfo.TestName,
                    null,
                    Strings.CouldNotSaveSettingsFile,
                    testInfo.StyleCopSettingsFileLocation,
                    exception.Message);

                return false;
            }

            return true;
        }

        #endregion Private Methods
    }
}