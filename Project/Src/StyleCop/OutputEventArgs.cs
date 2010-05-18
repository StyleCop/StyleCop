//-----------------------------------------------------------------------
// <copyright file="OutputEventArgs.cs" company="Microsoft">
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
namespace Microsoft.StyleCop
{
    using System;
    using Microsoft.Build.Framework;

    /// <summary>
    /// Event argument for output generated event.
    /// </summary>
    public class OutputEventArgs : EventArgs
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the OutputEventArgs class.
        /// </summary>
        /// <param name="text">The output text.</param>
        public OutputEventArgs(string text) : this(text, MessageImportance.Normal)
        {
            Param.RequireNotNull(text, "text");
        }

        /// <summary>
        /// Initializes a new instance of the OutputEventArgs class.
        /// </summary>
        /// <param name="text">The output text.</param>
        /// <param name="importance">The level of importance for this output event.</param>
        public OutputEventArgs(string text, MessageImportance importance)
        {
            Param.RequireNotNull(text, "text");
            Param.Ignore(importance);

            this.Output = text;
            this.Importance = importance;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the output text.
        /// </summary>
        public string Output { get; private set; }

        /// <summary>
        /// Gets the importance of the message.
        /// </summary>
        public MessageImportance Importance { get; private set; }

        #endregion Public Properties
    }
}
