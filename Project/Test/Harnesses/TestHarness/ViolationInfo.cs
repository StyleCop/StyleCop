//-----------------------------------------------------------------------
// <copyright file="ViolationInfo.cs" company="Microsoft">
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
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes one StyleCop violation.
    /// </summary>
    internal class ViolationInfo
    {
        #region Private Fields

        /// <summary>
        /// The code section that contains the violation.
        /// </summary>
        private string section;

        /// <summary>
        /// The line in the code on which the violation appears.
        /// </summary>
        private int lineNumber;

        /// <summary>
        /// The namespace of the rule that caused the violation.
        /// </summary>
        private string ruleNamespace;

        /// <summary>
        /// The name of the rule that caused the violation.
        /// </summary>
        private string ruleName;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the ViolationInfo class.
        /// </summary>
        /// <param name="section">The code section that contains the violation.</param>
        /// <param name="lineNumber">The line in the code on which the violation appears.</param>
        /// <param name="ruleNamespace">The namespace of the rule that caused the violation.</param>
        /// <param name="ruleName">The name of the rule that caused the violation.</param>
        public ViolationInfo(string section, int lineNumber, string ruleNamespace, string ruleName)
        {
            this.section = section;
            this.lineNumber = lineNumber;
            this.ruleNamespace = ruleNamespace;
            this.ruleName = ruleName;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the code section that contains the violation.
        /// </summary>
        public string Section
        {
            get
            {
                return this.section;
            }
        }

        /// <summary>
        /// Gets the line in the code on which the violation appears.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.lineNumber;
            }
        }

        /// <summary>
        /// Gets the namespace of the rule that caused the violation.
        /// </summary>
        public string RuleNamespace
        {
            get
            {
                return this.ruleNamespace;
            }
        }

        /// <summary>
        /// Gets the name of the rule that caused the violation.
        /// </summary>
        public string RuleName
        {
            get
            {
                return this.ruleName;
            }
        }

        #endregion Public Properties
    }
}
