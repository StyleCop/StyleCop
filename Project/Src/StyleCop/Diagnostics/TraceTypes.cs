// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraceTypes.cs" company="https://github.com/StyleCop">
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
//   Represents the binary switch values used to turn on/off the various types of trace message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Diagnostics
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Represents the binary switch values used to turn on/off the various types of trace message.
    /// </summary>
    [Flags]
    public enum TraceTypes
    {
        /// <summary>
        /// No Tracing.
        /// </summary>
        None = 0, 

        /// <summary>
        /// Trace in and out of methods and code blocks.
        /// </summary>
        InOut = 1, 

        /// <summary>
        /// Trace output of error conditions.
        /// </summary>
        Error = 2, 

        /// <summary>
        /// Trace output of warning conditions.
        /// </summary>
        Warning = 4, 

        /// <summary>
        /// Trace output of general information.
        /// </summary>
        Info = 8, 

        /// <summary>
        /// Trace the full details of sensitive information. This flag only has an effect in debug
        /// builds - release builds will always obscure sensitive information.
        /// </summary>
        SensitiveData = 64, 

        /// <summary>
        /// Includes the .NET Thread name with the message output.
        /// </summary>
        IncludeThreadName = 128, 

        /// <summary>
        /// Include the .Net Thread Hash with the message output.
        /// </summary>
        IncludeThreadId = 256, 

        /// <summary>
        /// Trace output that is considered highly verbose.
        /// Also modifies the tracing produced from In/Out so that reference types are expanded.  
        /// </summary>
        Verbose = 512, 
    }
}