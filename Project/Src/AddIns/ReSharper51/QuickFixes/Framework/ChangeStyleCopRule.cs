// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeStyleCopRule.cs" company="http://stylecop.codeplex.com">
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
//   DisableHighlightingActionProvider for StyleCop rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper.QuickFixes.Framework
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Feature.Services.Bulbs;

    using StyleCop.ReSharper.Options;
    using StyleCop.ReSharper.Violations;

    #endregion

    /// <summary>
    /// DisableHighlightingActionProvider for StyleCop rules.
    /// </summary>
    [DisableHighlightingActionProvider]
    public class ChangeStyleCopRule : IDisableHighlightingActionProvider
    {
        #region Implemented Interfaces

        #region IDisableHighlightingActionProvider

        /// <summary>
        /// Gets the actions for changing the highlight options for StyleCop rules.
        /// </summary>
        /// <param name="highlighting">
        /// The current highlighting.
        /// </param>
        /// <param name="highlightingRange">
        /// The current highlighting range.
        /// </param>
        /// <returns>
        /// The available actions.
        /// </returns>
        public IEnumerable<IDisableHighlightingAction> Actions(IHighlighting highlighting, DocumentRange highlightingRange)
        {
            var violation = highlighting as StyleCopViolationBase;

            if (violation == null)
            {
                return JB::JetBrains.Util.EmptyArray<IDisableHighlightingAction>.Instance;
            }

            var ruleID = violation.CheckId;
            var highlightID = HighlightingRegistering.GetHighlightID(ruleID);

            return new IDisableHighlightingAction[] { new ChangeStyleCopRuleAction { HighlightID = highlightID, Text = "Inspection Options for \"" + violation.ToolTip + "\"" } };
        }

        #endregion

        #endregion
    }
}