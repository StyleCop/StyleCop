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

namespace StyleCop.ReSharper61.QuickFixes.Framework
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Psi;

    using StyleCop.ReSharper61.Options;
    using StyleCop.ReSharper61.Violations;

    #endregion

    /// <summary>
    /// DisableHighlightingActionProvider for StyleCop rules.
    /// </summary>
    [CustomHighlightingActionProvider(typeof(CSharpProjectFileType))]
    public class ChangeStyleCopRule : ICustomHighlightingActionProvider
    {
        #region Implemented Interfaces

        #region IDisableHighlightingActionProvider

        /// <summary>
        /// Gets the actions for changing the highlight options for StyleCop rules.
        /// </summary>
        /// <param name="highlighting">
        /// The current highlighting.
        /// </param>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="highlightingRange">
        /// The current highlighting range.
        /// </param>
        /// <param name="sourceFile">
        /// The file.
        /// </param>
        /// <returns>
        /// The available actions.
        /// </returns>
        public IEnumerable<ICustomHighlightingAction> GetActions(IHighlighting highlighting, ISolution solution, DocumentRange highlightingRange, IPsiSourceFile sourceFile)
        {
            var violation = highlighting as StyleCopViolationBase;

            if (violation == null)
            {
                return JB::JetBrains.Util.EmptyArray<ICustomHighlightingAction>.Instance;
            }

            var ruleID = violation.CheckId;
            var highlightID = HighlightingRegistering.GetHighlightID(ruleID);

            return new ICustomHighlightingAction[] { new ChangeStyleCopRuleAction { HighlightID = highlightID, Text = "Inspection Options for \"" + violation.ToolTip + "\"" } };
        }

        #endregion

        #endregion
    }
}