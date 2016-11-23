// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopTrace.cs" company="https://github.com/StyleCop">
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
// <summary>
//   The central manager class for application tracing, through which all application tracing should be done.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Diagnostics
{
    #region Using Directives

    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;

    #endregion

    /// <summary>
    /// The central manager class for application tracing, through which all application tracing should be done.
    /// </summary>
    [DebuggerStepThrough]
    public static partial class StyleCopTrace
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="StyleCopTrace"/> class.
        /// </summary>
        static StyleCopTrace()
        {
            int defaultLevel = 0;
#if DEBUG
            defaultLevel = 15;
#endif
            string levelString = ConfigurationManager.AppSettings["StyleCopTraceLevel"];
            int level = levelString != null ? int.Parse(levelString, CultureInfo.InvariantCulture) : defaultLevel;

            // <!-- ================================================================================-->
            // <!-- Trace level is a bit mask of the following values:                              -->
            // <!-- 0 = Off                                                                         -->
            // <!-- 1 = InOut                                                                       -->
            // <!-- 2 = Error                                                                       -->
            // <!-- 4 = Warning                                                                     -->
            // <!-- 8 = Info                                                                        -->
            // <!-- 64 = SensitiveData (shows sensitive data unmasked, only works in debug builds)  -->
            // <!-- 128 = IncludeThreadName                                                         -->
            // <!-- 256 = IncludeThreadHash                                                         -->
            // <!-- 512 = Verbose                                                                   -->
            // <!-- If TraceLog is not an empty string, it will write to the log file.              -->
            // <!-- NOTE: This has a significant impact on performance                              -->
            // <!-- =============================================================================== -->
#if DEBUG

            // Add the Default Listener back as ReSharper removes it
            Trace.Listeners.Add(new DefaultTraceListener());
#endif
            string logPath = ConfigurationManager.AppSettings["StyleCopTraceLogPath"];

            if (level > 0 && !string.IsNullOrEmpty(logPath))
            {
                Directory.CreateDirectory(logPath);
                string fullPath = Path.Combine(
                    logPath, string.Format("StyleCop Trace [{0}].log", DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss-fff", CultureInfo.InvariantCulture)));
                Trace.Listeners.Add(new TextWriterTraceListener(fullPath));
            }

            Switch = new StyleCopSwitch("StyleCop", "Provides tracing for StyleCop", level);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the <see cref="StyleCopSwitch"/> that this class uses to decide whether to produce tracing messages.
        /// </summary>
        public static StyleCopSwitch Switch { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Write an error message containing the passed text.
        /// </summary>
        /// <param name="message">
        /// The text of the message.
        /// </param>
        public static void Error(string message)
        {
            if (Switch.TraceError)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Err", message);
            }
        }

        /// <summary>
        /// Write an error message containing the passed arguments in the given format.
        /// </summary>
        /// <param name="format">
        /// Format to be used when writing the args to a string.
        /// </param>
        /// <param name="args">
        /// The arguments to insert into the format string.
        /// </param>
        public static void Error(string format, params object[] args)
        {
            if (Switch.TraceError)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Err", format, args);
            }
        }

        /// <summary>
        /// Write an error message consisting of the details of an <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception">
        /// The <see cref="Exception"/> to write the message about.
        /// </param>
        public static void Error(Exception exception)
        {
            if (Switch.TraceError)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Err", exception.ToString());
            }
        }

        /// <summary>
        /// To be called on method entry. This overload is recommended for most purposes.
        /// </summary>
        /// <param name="parameters">
        /// The values of the parameters that were passed into the function that is calling this trace function.
        /// </param>
        public static void In(params object[] parameters)
        {
            if (Switch.TraceInOut)
            {
                new StyleCopTraceFormatter().WriteTraceIn(parameters);
            }
        }

        /// <summary>
        /// Write an information message containing the passed text.
        /// </summary>
        /// <param name="message">
        /// The text of the message.
        /// </param>
        public static void Info(string message)
        {
            if (Switch.TraceInfo)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Info", message);
            }
        }

        /// <summary>
        /// Write an information message containing the passed arguments in the given format.
        /// </summary>
        /// <param name="format">
        /// Format to be used when writing the args to a string.
        /// </param>
        /// <param name="args">
        /// The arguments to insert into the format string.
        /// </param>
        public static void Info(string format, params object[] args)
        {
            if (Switch.TraceInfo)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Info", format, args);
            }
        }

        /// <summary>
        /// To be called when leaving a method. This overload is recommended for functions that have only input
        /// parameters and which do not have a return value.
        /// </summary>
        public static void Out()
        {
            if (Switch.TraceInOut)
            {
                new StyleCopTraceFormatter().WriteTraceOut(null);
            }
        }

        /// <summary>
        /// To be called when leaving a method. This overload is recommended for functions that have only input
        /// parameters and which have a return value.
        /// </summary>
        /// <param name="returnValue">
        /// The return value of the method.
        /// </param>
        /// <returns>
        /// The passed in <paramref name="returnValue"/> parameter.
        /// </returns>
        public static object Out(object returnValue)
        {
            if (Switch.TraceInOut)
            {
                new StyleCopTraceFormatter().WriteTraceOut(returnValue);
            }

            return returnValue;
        }

        /// <summary>
        /// To be called when leaving a method. This overload is recommended for functions that have only input
        /// parameters and which have a return value.
        /// </summary>
        /// <typeparam name="T">
        /// The type of return value.
        /// </typeparam>
        /// <param name="returnValue">
        /// The return value of the method.
        /// </param>
        /// <returns>
        /// The passed in <paramref name="returnValue"/> parameter.
        /// </returns>
        public static T Out<T>(T returnValue)
        {
            if (Switch.TraceInOut)
            {
                new StyleCopTraceFormatter().WriteTraceOut(returnValue);
            }

            return returnValue;
        }

        /// <summary>
        /// Write a verbose informational message containing the passed text.
        /// </summary>
        /// <param name="message">
        /// The text of the message.
        /// </param>
        public static void Verbose(string message)
        {
            if (Switch.TraceVerbose)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Dbg", message);
            }
        }

        /// <summary>
        /// Write a verbose informational message containing the passed arguments in the given format.
        /// </summary>
        /// <param name="format">
        /// Format to be used when writing the args to a string.
        /// </param>
        /// <param name="args">
        /// The arguments to insert into the format string.
        /// </param>
        public static void Verbose(string format, params object[] args)
        {
            if (Switch.TraceVerbose)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Dbg", format, args);
            }
        }

        /// <summary>
        /// Write a Warning message containing the passed text.
        /// </summary>
        /// <param name="message">
        /// The text of the message.
        /// </param>
        public static void Warning(string message)
        {
            if (Switch.TraceWarning)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Warn", message);
            }
        }

        /// <summary>
        /// Write an Warning message consisting of the details of an <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception">
        /// The <see cref="Exception"/> to write the message about.
        /// </param>
        public static void Warning(Exception exception)
        {
            if (Switch.TraceWarning)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Warn", exception.ToString());
            }
        }

        /// <summary>
        /// Write a Warning message containing the passed arguments in the given format.
        /// </summary>
        /// <param name="format">
        /// Format to be used when writing the args to a string.
        /// </param>
        /// <param name="args">
        /// The arguments to insert into the format string.
        /// </param>
        public static void Warning(string format, params object[] args)
        {
            if (Switch.TraceWarning)
            {
                new StyleCopTraceFormatter().WriteTraceMessage("Warn", format, args);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the current processes private bytes.
        /// </summary>
        /// <returns>A long of the processes private bytes.</returns>
        private static long GetPrivateBytes()
        {
            return Process.GetCurrentProcess().PrivateMemorySize64;
        }

        #endregion
    }
}