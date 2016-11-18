//--------------------------------------------------------------------------
// <copyright file="EnvDTEExtensions.cs">
//  MS-PL
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
namespace StyleCop.VisualStudio
{
    using System;
    using EnvDTE;

    /// <summary>
    /// Extension methods for Visual Studio environment.
    /// </summary>
    internal static class EnvDTEExtensions
    {
        #region Internal Static Methods

        /// <summary>
        /// Sends a text line to the OutputWindowPane window.
        /// </summary>
        /// <remarks>Usual OutputString method does not automatically add newline characters to the string.</remarks>
        /// <param name="pane">The output window pane being used.</param>
        /// <param name="text">The text characters to send to the window.</param>
        internal static void OutputLine(this OutputWindowPane pane, string text)
        {
            string line = text + Environment.NewLine;
            pane.OutputString(line);
        }

        #endregion Internal Static Methods
    }
}