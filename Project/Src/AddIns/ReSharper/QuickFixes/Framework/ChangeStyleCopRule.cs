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

namespace StyleCop.ReSharper.QuickFixes.Framework
{
    using System.Collections.Generic;

    using JetBrains.Application.Settings;
    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Daemon;
    using JetBrains.ReSharper.Feature.Services.Intentions;
    using JetBrains.ReSharper.Feature.Services.Resources;
    using JetBrains.ReSharper.Psi;
    using JetBrains.UI.Application;
    using JetBrains.UI.BulbMenu;
    using JetBrains.UI.Icons;

    using StyleCop.ReSharper.Options;
    using StyleCop.ReSharper.Violations;

    /// <summary>
    ///   DisableHighlightingActionProvider for StyleCop rules.
    /// </summary>
    [CustomHighlightingActionProvider(typeof(CSharpProjectFileType))]
    public class ChangeStyleCopRule : ICustomHighlightingActionProvider
    {
        /// <summary>
        /// The common icons component.
        /// </summary>
        private readonly IThemedIconManager commonIconsComponent;

        /// <summary>
        /// The highlighting settings manager.
        /// </summary>
        private readonly HighlightingSettingsManager highlightingSettingsManager;

        /// <summary>
        /// The settings store.
        /// </summary>
        private readonly ISettingsStore settingsStore;

        /// <summary>
        /// Initializes a new instance of the ChangeStyleCopRule class.
        /// </summary>
        /// <param name="highlightingSettingsManager">
        /// The settings manager to use.
        /// </param>
        /// <param name="settingsStore">
        /// The settings store.
        /// </param>
        /// <param name="application">
        /// The UI application.
        /// </param>
        /// <param name="commonIconsComponent">
        /// The icon to use.
        /// </param>
        public ChangeStyleCopRule(
            HighlightingSettingsManager highlightingSettingsManager,
            ISettingsStore settingsStore,
            UIApplication application,
            IThemedIconManager commonIconsComponent)
        {
            this.highlightingSettingsManager = highlightingSettingsManager;
            this.settingsStore = settingsStore;
            this.commonIconsComponent = commonIconsComponent;
        }

        /// <summary>
        /// Gets the actions for changing the highlight options for StyleCop rules.
        /// </summary>
        /// <param name="highlighting">
        /// The current highlighting. 
        /// </param>
        /// <param name="highlightingRange">
        /// The current highlighting range. 
        /// </param>
        /// <param name="sourceFile">
        /// The file. 
        /// </param>
        /// <param name="configureAnchor">The anchor for configuration items</param>
        /// <returns>
        /// The available actions. 
        /// </returns>
        public IEnumerable<IntentionAction> GetActions(IHighlighting highlighting, DocumentRange highlightingRange, IPsiSourceFile sourceFile,
            IAnchor configureAnchor)
        {
            StyleCopHighlightingBase violation = highlighting as StyleCopHighlightingBase;

            if (violation == null)
            {
                yield break;
            }

            string ruleId = violation.CheckId;
            string highlightId = HighlightingRegistering.GetHighlightID(ruleId);

            ChangeStyleCopRuleAction changeStyleCopRuleAction = new ChangeStyleCopRuleAction(
                this.highlightingSettingsManager,
                this.settingsStore,
                highlightId,
                this.commonIconsComponent) { Text = "Inspection Options for \"" + violation.ToolTip + "\"" };

            yield return
                new IntentionAction(changeStyleCopRuleAction, changeStyleCopRuleAction.Text, BulbThemedIcons.ContextAction.Id, IntentionsAnchors.ContextActionsAnchor);
        }
    }
}