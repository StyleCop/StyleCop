/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Build.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Microsoft.VsSDK.UnitTestLibrary
{
    sealed public class MockBuildEngine : IBuildEngine4
    {
        private int messages = 0;
        private int warnings = 0;
        private int errors = 0;
        private string log = "";
        private string upperLog = null;
        private bool logToConsole = false;
        private MockLogger mockLogger = null;
        private Dictionary<object, object> objectCashe = new Dictionary<object, object>();

        public MockBuildEngine() : this(false)
        {
        }

        public int Messages
        {
            set { messages = value; }
            get { return messages; }
        }

        public int Warnings
        {
            set { warnings = value; }
            get { return warnings; }
        }

        public int Errors
        {
            set { errors = value; }
            get { return errors; }
        }

        public MockLogger MockLogger
        {
            get { return mockLogger; }
        }

        public MockBuildEngine(bool logToConsole)
        {
            mockLogger = new MockLogger();
            this.logToConsole = logToConsole;
        }


        public void LogErrorEvent(BuildErrorEventArgs eventArgs)
        {
            if (eventArgs.File != null && eventArgs.File.Length > 0)
            {
                if (logToConsole)
                    Console.Write("{0}({1},{2}): ", eventArgs.File, eventArgs.LineNumber, eventArgs.ColumnNumber);
                log += String.Format("{0}({1},{2}): ", eventArgs.File, eventArgs.LineNumber, eventArgs.ColumnNumber);
            }

            if (logToConsole)
                Console.Write("ERROR " + eventArgs.Code + ": ");
            log += "ERROR " + eventArgs.Code + ": ";
            ++errors;

            if (logToConsole)
                Console.WriteLine(eventArgs.Message);
            log += eventArgs.Message;
            log += "\n";
        }

        public void LogWarningEvent(BuildWarningEventArgs eventArgs)
        {
            if (eventArgs.File != null && eventArgs.File.Length > 0)
            {
                if (logToConsole)
                    Console.Write("{0}({1},{2}): ", eventArgs.File, eventArgs.LineNumber, eventArgs.ColumnNumber);
                log += String.Format("{0}({1},{2}): ", eventArgs.File, eventArgs.LineNumber, eventArgs.ColumnNumber);
            }

            if (logToConsole)
                Console.Write("WARNING " + eventArgs.Code + ": ");
            log += "WARNING " + eventArgs.Code + ": ";
            ++warnings;

            if (logToConsole)
                Console.WriteLine(eventArgs.Message);
            log += eventArgs.Message;
            log += "\n";
        }

        public void LogCustomEvent(CustomBuildEventArgs eventArgs)
        {
            if (logToConsole)
                Console.WriteLine(eventArgs.Message);
            log += eventArgs.Message;
            log += "\n";
        }

        public void LogMessageEvent(BuildMessageEventArgs eventArgs)
        {
            if (logToConsole)
                Console.WriteLine(eventArgs.Message);
            log += eventArgs.Message;
            log += "\n";
            ++messages;
        }

        public bool ContinueOnError
        {
            get
            {
                return false;
            }
        }

        public string ProjectFileOfTaskNode
        {
            get
            {
                return String.Empty;
            }
        }

        public int LineNumberOfTaskNode
        {
            get
            {
                return 0;
            }
        }

        public int ColumnNumberOfTaskNode
        {
            get
            {
                return 0;
            }
        }

        public string Log
        {
            set { log = value; }
            get { return log; }
        }

        public bool IsRunningMultipleNodes
        {
            get;
            set;
        }

        public bool BuildProjectFile
            (
            string projectFileName,
            string[] targetNames,
            IDictionary globalPropertiesPassedIntoTask,
            IDictionary targetOutputs
            )
        {
            return false;
        }

        public bool BuildProjectFile
            (
            string projectFileName,
            string[] targetNames,
            IDictionary globalPropertiesPassedIntoTask,
            IDictionary targetOutputs,
            string toolsVersion
            )
        {
            return false;
        }

        public bool BuildProjectFilesInParallel
        (
            string[] projectFileNames,
            string[] targetNames,
            IDictionary[] globalProperties,
            IDictionary[] targetOutputsPerProject,
            string[] toolsVersion,
            bool useResultsCache,
            bool unloadProjectsOnCompletion
        )
        {
            return false;
        }

        public BuildEngineResult BuildProjectFilesInParallel
        (
            string[] projectFileNames,
            string[] targetNames,
            IDictionary[] globalProperties,
            IList<string>[] undefineProperties,
            string[] toolsVersion,
            bool returnTargetOutputs
        )
        {
            return new BuildEngineResult();
        }

        public void Yield()
        {
        }

        public void Reacquire()
        {
        }

        public bool BuildProjectFile
            (
            string projectFileName
            )
        {
            return false;
        }

        public bool BuildProjectFile
            (
            string projectFileName,
            string[] targetNames
            )
        {
            return false;
        }

        public bool BuildProjectFile
            (
            string projectFileName,
            string targetName
            )
        {
            return false;
        }

        public void UnregisterAllLoggers
            (
            )
        {
        }

        public void UnloadAllProjects
            (
            )
        {
        }


        /// <summary>
        /// Assert that the mock log in the engine doesn't contain a certain message based on a resource string and some parameters
        /// </summary>
        public void AssertLogDoesntContainMessageFromResource(GetStringDelegate getString, string resourceName, params string[] parameters)
        {
            string resource = getString(resourceName);
            string stringToSearchFor = String.Format(resource, parameters);
            AssertLogDoesntContain(stringToSearchFor);
        }

        /// <summary>
        /// Assert that the mock log in the engine contains a certain message based on a resource string and some parameters
        /// </summary>
        public void AssertLogContainsMessageFromResource(GetStringDelegate getString, string resourceName, params string[] parameters)
        {
            string resource = getString(resourceName);
            string stringToSearchFor = String.Format(resource, parameters);
            AssertLogContains(stringToSearchFor);
        }

        /// <summary>
        /// Assert that the log file contains the given string.
        /// Case insensitive.
        /// First check if the string is in the log string. If not
        /// than make sure it is also check the MockLogger
        /// </summary>
        /// <param name="contains"></param>
        public void AssertLogContains(string contains)
        {
            if (upperLog == null)
            {
                upperLog = log;
                upperLog = upperLog.ToUpperInvariant();
            }

            // If we do not contain this string than pass it to
            // MockLogger. Since MockLogger is also registered as
            // a logger it may have this string.
            if (!upperLog.Contains
                (
                    contains.ToUpperInvariant()
                )
              )
            {
                Console.WriteLine(log);
                mockLogger.AssertLogContains(contains);
            }
        }

        /// <summary>
        /// Assert that the log doesnt contain the given string.
        /// First check if the string is in the log string. If not
        /// than make sure it is also not in the MockLogger
        /// </summary>
        /// <param name="contains"></param>
        public void AssertLogDoesntContain(string contains)
        {
            Console.WriteLine(log);

            if (upperLog == null)
            {
                upperLog = log;
                upperLog = upperLog.ToUpperInvariant();
            }

            Assert.IsTrue
            (
                !upperLog.Contains
                (
                    contains.ToUpperInvariant()
                )
            );

            // If we do not contain this string than pass it to
            // MockLogger. Since MockLogger is also registered as
            // a logger it may have this string.
            mockLogger.AssertLogDoesntContain
            (
                contains
            );
        }

        /// <summary>
        /// Delegate which will get the resource from the correct resoruce manager
        /// </summary>
        public delegate string GetStringDelegate(string resourceName);

        public object GetRegisteredTaskObject(object key, RegisteredTaskObjectLifetime lifetime)
        {
            return null;
        }

        public void RegisterTaskObject(object key, object obj, RegisteredTaskObjectLifetime lifetime, bool allowEarlyCollection)
        {
        }

        public object UnregisterTaskObject(object key, RegisteredTaskObjectLifetime lifetime)
        {
            return null;
        }
    }
}
