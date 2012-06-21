// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeStyleCopRuleAction.cs" company="http://stylecop.codeplex.com">
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
//   Adds changing the display option for the style cop rule as context menu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

extern alias JB;

namespace StyleCop.ReSharper700.QuickFixes.Framework
{
    #region Using Directives

    using JetBrains.Application.Settings;
    using JetBrains.DocumentModel;
    using JetBrains.Interop.WinApi;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Daemon.Impl;
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Intentions.Extensibility.Menu;
    using JetBrains.TextControl;
    using JetBrains.UI.CrossFramework;
    using JetBrains.UI.Icons;

    #endregion

    /// <summary>
    ///   Adds changing the display option for the style cop rule as context menu.
    /// </summary>
    public class ChangeStyleCopRuleAction : IBulbItem
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
        /// Initializes a new instance of the ChangeStyleCopRuleAction class.
        /// </summary>
        /// <param name="highlightingSettingsManager">The settings manager to use.</param>
        /// <param name="settingsStore">The settings store.</param>
        /// <param name="severityId">The severityId.</param>
        /// <param name="commonIconsComponent">The icon to use.</param>
        public ChangeStyleCopRuleAction(HighlightingSettingsManager highlightingSettingsManager, ISettingsStore settingsStore, string severityId, IThemedIconManager commonIconsComponent)
        {
            this.highlightingSettingsManager = highlightingSettingsManager;
            this.settingsStore = settingsStore;
            this.commonIconsComponent = commonIconsComponent;
            this.HighlightID = severityId;
        }

        #region Public Properties

        /// <summary>
        ///   Gets or sets the highlight id of the current violation.
        /// </summary>
        /// <value> The highlight id of the current violation. </value>
        public string HighlightID { get; set; }

        /// <summary>
        ///   Gets the entries in the context menu.
        /// </summary>
        /// <value> The entries in the context menu. </value>
        public IBulbItem[] Items
        {
            get
            {
                return new IBulbItem[] { this };
            }
        }

        /// <summary>
        ///   Gets the priority.
        /// </summary>
        public int Priority
        {
            get
            {
                return 500;
            }
        }

        /// <summary>
        ///   Gets or sets text to be used as the cookie name.
        /// </summary>
        /// <value> The text of the context menu entry. </value>
        public string Text { get; set; }

        #endregion
        
        #region Public Methods and Operators

        /// <summary>
        ///   Arranges the BulbItems in the correct section.
        /// </summary>
        /// <param name="menu"> The BulbMenu to add the items too. </param>
        public void CreateBulbItems(BulbMenu menu)
        {
            menu.ArrangeContextActions(this.Items);
        }

        /// <summary>
        ///   Performs the QuickFix, inserts the configured modifier into the location specified by the violation.
        /// </summary>
        /// <param name="solution"> Current Solution. </param>
        /// <param name="textControl"> Current Text Control to modify. </param>
        public void Execute(ISolution solution, ITextControl textControl)
        {
            JB::JetBrains.DataFlow.LifetimeDefinition definition = JB::JetBrains.DataFlow.Lifetimes.Define(solution.GetLifetime());
            var lifetime = definition.Lifetime;
            try
            {
                unsafe
                {
                    var dialog = new ChangeInspectionSeverityDialog(lifetime, this.commonIconsComponent);
                    var contextBoundSettingsStore = this.settingsStore.BindToContextTransient(ContextRange.Smart(textControl.Document.ToDataContext()));
                    HighlightingSettingsManager.ConfigurableSeverityItem item = this.highlightingSettingsManager.GetSeverityItem(this.HighlightID);

                    dialog.Severity = this.highlightingSettingsManager.GetConfigurableSeverity(this.HighlightID, contextBoundSettingsStore);
                    dialog.SeverityOptionsTitle = string.Format(item.FullTitle + ":");
                    dialog.CanBeError = !item.SolutionAnalysisRequired;

                    if (dialog.ShowDialog(User32Dll.GetForegroundWindow()) == true)
                    {
                        var store = contextBoundSettingsStore;
                        if (dialog.SelectedSettingsLayer != null)
                        {
                            store = dialog.SelectedSettingsLayer.Model.SettingsStoreContext;
                        }

                        store.SetIndexedValue(HighlightingSettingsAccessor.InspectionSeverities, this.HighlightID, dialog.Severity);
                    }
                }
            }
            finally
            {
                definition.Terminate();
            }
        }

        /// <summary>
        ///   Determines whether the specified cache is available.
        /// </summary>
        /// <param name="cache"> The cache. </param>
        /// <returns> <c>True.</c> if the specified cache is available; otherwise, <c>False.</c> . </returns>
        public bool IsAvailable(JB::JetBrains.Util.IUserDataHolder cache)
        {
            return true;
        }

        #endregion
    }
}