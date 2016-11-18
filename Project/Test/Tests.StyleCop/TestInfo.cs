//-----------------------------------------------------------------------
// <copyright file="TestInfo.cs">
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
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Contains information required for running a test.
    /// </summary>
    internal class TestInfo
    {
        /// <summary>
        /// The name of the test.
        /// </summary>
        private string testName;

        /// <summary>
        /// The code files to run through StyleCop.
        /// </summary>
        private ICollection<TestCodeFileInfo> testCodeFiles;

        /// <summary>
        /// The path where test output should be stored.
        /// </summary>
        private string testOutputPath;

        /// <summary>
        /// Contains information about the test to run.
        /// </summary>
        private XmlNode testDescription;

        /// <summary>
        /// Initializes a new instance of the TestInfo class.
        /// </summary>
        /// <param name="testDescription">Contains information about the test to run.</param>
        /// <param name="testName">The name of the test.</param>
        /// <param name="testCodeFiles">The collection of code files to run through StyleCop during the test.</param>
        /// <param name="testOutputPath">The path where test output should be stored.</param>
        public TestInfo(XmlNode testDescription, string testName, ICollection<TestCodeFileInfo> testCodeFiles, string testOutputPath)
        {
            Debug.Assert(testDescription != null, "The parameter must not be null");
            Debug.Assert(!string.IsNullOrEmpty(testName), "The string is invalid");
            Debug.Assert(testCodeFiles != null && testCodeFiles.Count > 0, "There must be at least one code file.");
            Debug.Assert(!string.IsNullOrEmpty(testOutputPath), "The string is invalid");

            this.testDescription = testDescription;
            this.testName = testName;
            this.testCodeFiles = testCodeFiles;
            this.testOutputPath = testOutputPath;
        }

        /// <summary>
        /// Gets a node containing information about the test to run.
        /// </summary>
        public XmlNode TestDescription
        {
            get
            {
                return this.testDescription;
            }
        }

        /// <summary>
        /// Gets the name of the test.
        /// </summary>
        public string TestName
        {
            get
            {
                return this.testName;
            }
        }

        /// <summary>
        /// Gets an extension which is added to the name of auto-fixed files.
        /// </summary>
        public string AutoFixFileExtension
        {
            get
            {
                return "_AutoFixFiles_" + this.testName;
            }
        }

        /// <summary>
        /// Gets the collection of code files to run through StyleCop during the test.
        /// </summary>
        public ICollection<TestCodeFileInfo> TestCodeFiles
        {
            get
            {
                return this.testCodeFiles;
            }
        }

        /// <summary>
        /// Gets the path to the temporary StyleCop output file.
        /// </summary>
        public string StyleCopOutputLocation
        {
            get
            {
                return Path.Combine(this.testOutputPath, this.testName + "_StyleCopResults.xml");
            }
        }

        /// <summary>
        /// Gets the path to the temporary StyleCop settings file location.
        /// </summary>
        public string StyleCopSettingsFileLocation
        {
            get
            {
                return Path.Combine(this.testOutputPath, this.testName + "_Settings.StyleCop");
            }
        }

        /// <summary>
        /// Gets the path to the location where all test output should be stored.
        /// </summary>
        public string TestOutputPath
        {
            get
            {
                return this.testOutputPath;
            }
        }

        /// <summary>
        /// Gets a name which can be used for an autoFix version of the given file.
        /// </summary>
        /// <param name="filePath">The path to the original file.</param>
        /// <returns>Returns the new file name.</returns>
        public string AutoFixFileName(string filePath)
        {
            string originalPath = Path.GetDirectoryName(filePath);
            if (originalPath.EndsWith("\\_OriginalFiles", StringComparison.OrdinalIgnoreCase))
            {
                originalPath = originalPath.Substring(0, originalPath.Length - 15);
            }

            return Path.Combine(Path.Combine(originalPath, this.AutoFixFileExtension), Path.GetFileName(filePath));
        }
    }
}