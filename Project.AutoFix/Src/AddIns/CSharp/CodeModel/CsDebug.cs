//-----------------------------------------------------------------------
// <copyright file="CsDebug.cs">
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
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Static debug functionality.
    /// </summary>
    public class CsDebug
    {
        /// <summary>
        /// Initializes a new instance of the CsDebug class.
        /// </summary>
        internal CsDebug()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to throw an exception whenever an assert occurs.
        /// </summary>
        public bool ThrowOnAssert
        {
            get;
            set;
        }

        /// <summary>
        /// Checks for a condition and displays a message if the condition is false.
        /// </summary>
        /// <param name="condition">true to prevent a message being displayed; otherwise, false.</param>
        /// <param name="message">A message to display.</param>
        public void Assert(bool condition, string message)
        {
            Param.Ignore(condition, message);

            if (this.ThrowOnAssert && !condition)
            {
                throw new CodeModelAssertException(message);
            }
            else
            {
                System.Diagnostics.Debug.Assert(condition, message);
            }
        }

        /// <summary>
        /// Checks for a condition and displays both specified messages if the condition is false.
        /// </summary>
        /// <param name="condition">true to prevent a message being displayed; otherwise, false.</param>
        /// <param name="message">A message to display.</param>
        /// <param name="detailMessage">A detailed message to display.</param>
        public void Assert(bool condition, string message, string detailMessage)
        {
            Param.Ignore(condition, message, detailMessage);

            if (this.ThrowOnAssert && !condition)
            {
                throw new CodeModelAssertException(message);
            }
            else
            {
                System.Diagnostics.Debug.Assert(condition, message, detailMessage);
            }
        }

        /// <summary>
        /// Emits the specified error message.
        /// </summary>
        /// <param name="message">A message to emit.</param>
        public void Fail(string message)
        {
            Param.Ignore(message);

            if (this.ThrowOnAssert)
            {
                throw new CodeModelAssertException(message);
            }
            else
            {
                System.Diagnostics.Debug.Fail(message);
            }
        }

        /// <summary>
        /// Emits an error message and a detailed error message.
        /// </summary>
        /// <param name="message">A message to emit.</param>
        /// <param name="detailMessage">A detailed message to emit.</param>
        public void Fail(string message, string detailMessage)
        {
            Param.Ignore(message, detailMessage);

            if (this.ThrowOnAssert)
            {
                throw new CodeModelAssertException(message);
            }
            else
            {
                System.Diagnostics.Debug.Fail(message, detailMessage);
            }
        }
    }
}
