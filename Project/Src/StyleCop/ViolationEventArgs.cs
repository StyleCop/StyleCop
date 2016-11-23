// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViolationEventArgs.cs" company="https://github.com/StyleCop">
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
//   Contains event information for violation events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;

    /// <summary>
    /// Contains event information for violation events.
    /// </summary>
    public class ViolationEventArgs : EventArgs
    {
        #region Fields

        /// <summary>
        /// The violation.
        /// </summary>
        private readonly Violation violation;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ViolationEventArgs class.
        /// </summary>
        /// <param name="violation">
        /// The violation.
        /// </param>
        internal ViolationEventArgs(Violation violation)
        {
            Param.AssertNotNull(violation, "violation");
            this.violation = violation;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the element of code that the violation appears in.
        /// </summary>
        public ICodeElement Element
        {
            get
            {
                return this.violation.Element;
            }
        }

        /// <summary>
        /// Gets the line number in the code where the violation appears. 1 based.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.violation.Line;
            }
        }

        /// <summary>
        /// Gets the location in the code where the violation appears or null if only the line number is known.
        /// </summary>
        public CodeLocation? Location
        {
            get
            {
                return this.violation.Location;
            }
        }

        /// <summary>
        /// Gets the context message string for the violation.
        /// </summary>
        public string Message
        {
            get
            {
                return this.violation.Message;
            }
        }

        /// <summary>
        /// Gets the source code that contains the violation.
        /// </summary>
        public SourceCode SourceCode
        {
            get
            {
                return this.violation.SourceCode;
            }
        }

        /// <summary>
        /// Gets the violation.
        /// </summary>
        public Violation Violation
        {
            get
            {
                return this.violation;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this violation is only a warning.
        /// </summary>
        public bool Warning
        {
            get
            {
                return this.violation.Rule.Warning;
            }
        }

        #endregion
    }
}