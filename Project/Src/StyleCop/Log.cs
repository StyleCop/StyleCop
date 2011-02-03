//-----------------------------------------------------------------------
// <copyright file="Log.cs">
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
namespace StyleCop
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Logging functionality for StyleCop.
    /// </summary>
    internal class Log : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// The current log level.
        /// </summary>
        private StyleCopLogLevel logLevel = StyleCopLogLevel.None;

        /// <summary>
        /// The trace listener.
        /// </summary>
        private Listener listener;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the Log class.
        /// </summary>
        /// <param name="core">The core instance.</param>
        public Log(StyleCopCore core)
        {
            Param.AssertNotNull(core, "core");

            object data = core.Registry.CUGetValue("Logging");
            if (data != null)
            {
                try
                {
                    int level = (int)data;
                    if (level > 0)
                    {
                        this.logLevel = StyleCopLogLevel.High;
                    }
                }
                catch (FormatException)
                {
                    // Do nothing here since data is registry is invalid.
                }
            }

            if (this.logLevel != StyleCopLogLevel.None)
            {
                this.listener = new Listener();
                Trace.Listeners.Add(this.listener);
            }
        }

        #endregion Public Constructors

        #region Public Static Methods

        /// <summary>
        /// Writes information to the log.
        /// </summary>
        /// <param name="text">The text to write to the log.</param>
        /// <param name="stringParameters">The parameters to insert into the text.</param>
        public static void Write(string text, params string[] stringParameters)
        {
            Param.AssertNotNull(text, "text");
            Param.Ignore(stringParameters);

            Trace.TraceInformation(text, stringParameters);
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            if (this.listener != null)
            {
                Trace.Listeners.Remove(this.listener);
                this.listener.Dispose();
                this.listener = null;
            }
        }

        #endregion Public Methods

        #region Private Classes

        /// <summary>
        /// The logging trace listener.
        /// </summary>
        private class Listener : TraceListener
        {
            #region Private Fields

            /// <summary>
            /// The file stream writer.
            /// </summary>
            private StreamWriter writer;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the Listener class.
            /// </summary>
            public Listener()
            {
                this.OpenLogFile();
            }

            #endregion Public Constructors

            #region Public Override Methods

            /// <summary>
            /// Writes the given message to the log.
            /// </summary>
            /// <param name="message">The message to write.</param>
            public override void Write(string message)
            {
                Param.Ignore(message);

                if (message != null && this.writer != null)
                {
                    this.writer.Write(message);
                    this.writer.Flush();
                }
            }

            /// <summary>
            /// Writes the given message to the log, followed by a newline.
            /// </summary>
            /// <param name="message">The message to write.</param>
            public override void WriteLine(string message)
            {
                Param.Ignore(message);

                if (message != null && this.writer != null)
                {
                    this.writer.WriteLine(message);
                    this.writer.Flush();
                }
            }

            #endregion Public Override Methods

            #region Protected Override Methods

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            /// <param name="disposing">Indicates whether to dispose managed resources.</param>
            protected override void Dispose(bool disposing)
            {
                Param.Ignore(disposing);
                base.Dispose(disposing);

                if (disposing)
                {
                    this.CloseLogFile();
                }
            }

            #endregion Protected Override Methods

            #region Private Methods

            /// <summary>
            /// Opens the log file.
            /// </summary>
            private void OpenLogFile()
            {
                Debug.Assert(this.writer == null, "The log file has already been created.");

                string applicationData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                applicationData = Path.Combine(applicationData, "StyleCop");

                try
                {
                    if (!Directory.Exists(applicationData))
                    {
                        Directory.CreateDirectory(applicationData);
                    }

                    string logFile = Path.Combine(applicationData, "StyleCopLog.log");

                    if (File.Exists(logFile))
                    {
                        File.SetAttributes(logFile, FileAttributes.Normal);
                        File.Delete(logFile);
                    }

                    this.writer = new StreamWriter(logFile, false);
                }
                catch (IOException)
                {
                    // Logging will be disabled on IO or security error.
                }
                catch (UnauthorizedAccessException)
                {
                    // Logging will be disabled on IO or security error.
                }
            }

            /// <summary>
            /// Closes the log file.
            /// </summary>
            private void CloseLogFile()
            {
                if (this.writer != null)
                {
                    this.writer.Close();
                    this.writer.Dispose();
                    this.writer = null;
                }
            }

            #endregion Private Methods
        }

        #endregion Private Classes
    }
}
