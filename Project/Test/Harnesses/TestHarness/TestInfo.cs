//-----------------------------------------------------------------------
// <copyright file="TestInfo.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
namespace MS.StyleCop.TestHarness
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Contains information required for running a test.
    /// </summary>
    internal class TestInfo
    {
        #region Private Fields

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

        #endregion Private Field

        #region Public Constructors

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

        #endregion Public Constructors

        #region Public Properties

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

        #endregion Public Properties
    }
}
