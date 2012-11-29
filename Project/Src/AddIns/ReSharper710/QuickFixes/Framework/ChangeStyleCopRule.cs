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

namespace StyleCop.ReSharper710.QuickFixes.Framework
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.Application.Settings;
    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Daemon.Src.Bulbs.Resources;
    using JetBrains.ReSharper.Intentions.Extensibility;
    using JetBrains.ReSharper.Intentions.Extensibility.Menu;
    using JetBrains.ReSharper.Psi;
    using JetBrains.UI.Application;
    using JetBrains.UI.Icons;

    using StyleCop.ReSharper710.Options;
    using StyleCop.ReSharper710.Violations;

    #endregion

    /// <summary>
    ///   DisableHighlightingActionProvider for StyleCop rules.
    /// </summary>
    [CustomHighlightingActionProvider(typeof(CSharpProjectFileType))]
    public class ChangeStyleCopRule : ICustomHighlightingActionProvider
    {
        #region Fields

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

        #endregion

        #region Constructors and Destructors

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
            HighlightingSettingsManager highlightingSettingsManager, ISettingsStore settingsStore, UIApplication application, IThemedIconManager commonIconsComponent)
        {
            this.highlightingSettingsManager = highlightingSettingsManager;
            this.settingsStore = settingsStore;
            this.commonIconsComponent = commonIconsComponent;
        }

        #endregion

        #region Public Methods and Operators

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
        public IEnumerable<JB::JetBrains.Util.Pair<IBulbAction, BulbMenuItemViewDescription>> GetActions(
            IHighlighting highlighting, ISolution solution, DocumentRange highlightingRange, IPsiSourceFile sourceFile)
        {
            StyleCopHighlightingBase violation = highlighting as StyleCopHighlightingBase;

            if (violation == null)
            {
                yield break;
            }

            string ruleId = violation.CheckId;
            string highlightId = HighlightingRegistering.GetHighlightID(ruleId);

            ChangeStyleCopRuleAction changeStyleCopRuleAction = new ChangeStyleCopRuleAction(
                this.highlightingSettingsManager, this.settingsStore, highlightId, this.commonIconsComponent)
                                                                    {
                                                                        Text =
                                                                            "Inspection Options for \"" + violation.ToolTip
                                                                            + "\""
                                                                    };

            yield return
                JB::JetBrains.Util.Pair.Of<IBulbAction, BulbMenuItemViewDescription>(
                    changeStyleCopRuleAction, 
                    new BulbMenuItemViewDescription(AnchorsForConfigureHighlightingSubmenu.ConfigureItem, BulbThemedIcons.DisableBulb.Id, changeStyleCopRuleAction.Text));
        }

        #endregion
    }
}