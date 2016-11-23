// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopSwitch.cs" company="https://github.com/StyleCop">
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
//   A custom  class allowing more trace levels than the default switch.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Diagnostics
{
    #region Using Directives

    using System;
    using System.Diagnostics;

    #endregion

    /// <summary>
    /// A custom <see cref="TraceSwitch"/> class allowing more trace levels than the default switch.
    /// </summary>
    /// <remarks>
    /// This is a replacement for the default <see cref="TraceSwitch"/> class. This class publishes the <see cref="Level"/> as 
    /// an <see cref="int"/> rather than as an <see cref="Enum"/> as with the default implementation. This allows us to use any 
    /// value for the tracing level rather than the restricted 5 values of the default class.
    /// </remarks>
    [DebuggerStepThrough]
    public sealed class StyleCopSwitch : Switch
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopSwitch"/> class with the default trace level.
        /// </summary>
        /// <param name="displayName">
        /// The name of the switch.
        /// </param>
        /// <param name="description">
        /// A description of the switch.
        /// </param>
        public StyleCopSwitch(string displayName, string description)
            : this(displayName, description, TraceTypes.Warning | TraceTypes.Error)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopSwitch"/> class with a specified enumerated trace level.
        /// </summary>
        /// <param name="displayName">
        /// The name of the switch.
        /// </param>
        /// <param name="description">
        /// A description of the switch.
        /// </param>
        /// <param name="level">
        /// The trace level as a combination of <see cref="TraceTypes"/> values.
        /// </param>
        public StyleCopSwitch(string displayName, string description, TraceTypes level)
            : this(displayName, description, (int)level)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopSwitch"/> class with a specified trace level.
        /// </summary>
        /// <param name="displayName">
        /// The name of the switch.
        /// </param>
        /// <param name="description">
        /// A description of the switch.
        /// </param>
        /// <param name="level">
        /// The trace level.
        /// </param>
        public StyleCopSwitch(string displayName, string description, int level)
            : base(displayName, description)
        {
            this.SwitchSetting = level;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the current trace level.
        /// </summary>
        public int Level
        {
            get
            {
                return this.SwitchSetting;
            }

            set
            {
                this.SwitchSetting = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether tracing of errors is enabled.
        /// </summary>
        public bool TraceError { get; private set; }

        /// <summary>
        /// Gets a value indicating whether tracing in and out of method bodies is enabled.
        /// </summary>
        public bool TraceInOut { get; private set; }

        /// <summary>
        /// Gets a value indicating whether tracing of informational messages is enabled.
        /// </summary>
        public bool TraceInfo { get; private set; }

        /// <summary>
        /// Gets a value indicating whether tracing of sensitive data is enabled.
        /// </summary>
        public bool TraceSensitiveData { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the managed thread identifier should be included in the trace output.
        /// </summary>
        public bool TraceThreadId { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the managed thread name should be included in the trace output.
        /// </summary>
        public bool TraceThreadName { get; private set; }

        /// <summary>
        /// Gets a value indicating whether tracing of verbose information is enabled.
        /// </summary>
        public bool TraceVerbose { get; private set; }

        /// <summary>
        /// Gets a value indicating whether tracing of warnings is enabled.
        /// </summary>
        public bool TraceWarning { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// On switch setting changed.
        /// </summary>
        protected override void OnSwitchSettingChanged()
        {
            int value = this.SwitchSetting;
            this.TraceInOut = (value & (int)TraceTypes.InOut) != 0;
            this.TraceError = (value & (int)TraceTypes.Error) != 0;
            this.TraceWarning = (value & (int)TraceTypes.Warning) != 0;
            this.TraceInfo = (value & (int)TraceTypes.Info) != 0;
            this.TraceVerbose = (value & (int)TraceTypes.Verbose) != 0;
            this.TraceSensitiveData = (value & (int)TraceTypes.SensitiveData) != 0;
            this.TraceThreadId = (value & (int)TraceTypes.IncludeThreadId) != 0;
            this.TraceThreadName = (value & (int)TraceTypes.IncludeThreadName) != 0;
        }

        #endregion
    }
}