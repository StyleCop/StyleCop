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

namespace StyleCop.ReSharper611.QuickFixes.Framework
{
    #region Using Directives

    using System.Windows.Forms;

    using JetBrains.Application;
    using JetBrains.Application.Settings;
    using JetBrains.IDE;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Daemon.Impl;
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.TextControl;
    using JetBrains.UI.Application;

    #endregion

    /// <summary>
    /// Adds changing the display option for the style cop rule as context menu.
    /// </summary>
    public class ChangeStyleCopRuleAction : ICustomHighlightingAction, IBulbItem
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the highlight id of the current violation.
        /// </summary>
        /// <value>
        /// The highlight id of the current violation.
        /// </value>
        public string HighlightID { get; set; }

        /// <summary>
        /// Gets the entries in the context menu.
        /// </summary>
        /// <value>
        /// The entries in the context menu.
        /// </value>
        public IBulbItem[] Items
        {
            get
            {
                return new IBulbItem[] { this };
            }
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        public int Priority
        {
            get
            {
                return 50;
            }
        }

        /// <summary>
        /// Gets or sets text to be used as the cookie name.
        /// </summary>
        /// <value>
        /// The text of the context menu entry.
        /// </value>
        public string Text { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Performs the QuickFix, inserts the configured modifier into the location specified by
        /// the violation.
        /// </summary>
        /// <param name="solution">
        /// Current Solution.
        /// </param>
        /// <param name="textControl">
        /// Current Text Control to modify.
        /// </param>
        public void Execute(ISolution solution, ITextControl textControl)
        {
            using (ChangeSeverityDialog dialog = new ChangeSeverityDialog())
            {
                ////var settings = HighlightingSettingsManager.Instance.Settings.Clone();

                ////var severityItem = HighlightingSettingsManager.Instance.GetSeverityItem(this.HighlightID);

                ////dialog.Severity = settings.GetSeverity(this.HighlightID);
                ////dialog.Text = "Inspection options for \"" + severityItem.Title + "\"";

                ////if (dialog.ShowDialog(Shell.Instance.GetComponent<UIApplication>().MainWindow) == DialogResult.OK)
                ////{
                ////    settings.SetSeverity(this.HighlightID, dialog.Severity);
                ////    HighlightingSettingsManager.Instance.Settings = settings;

                ////    Daemon.GetInstance(solution).Invalidate();
                ////}
                IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, solution);
                IContextBoundSettingsStore contextBoundSettingsStore =
                    settingsStore.SettingsStore.BindToContextTransient(ContextRange.Smart(textControl.Document.ToDataContext()));
                HighlightingSettingsManager settingsManager = HighlightingSettingsManager.Instance;
                HighlightingSettingsManager.ConfigurableSeverityItem item = settingsManager.GetSeverityItem(this.HighlightID);
                dialog.Severity = settingsManager.GetConfigurableSeverity(this.HighlightID, solution);
                dialog.Text = string.Format("Inspection Options for \"{0}\"", item.FullTitle);
                dialog.CanBeError = !item.SolutionAnalysisRequired;
                if (dialog.ShowDialog(Shell.Instance.GetComponent<UIApplication>().MainWindow) == DialogResult.OK)
                {
                    contextBoundSettingsStore.SetIndexedValue(HighlightingSettingsAccessor.InspectionSeverities, this.HighlightID, dialog.Severity);
                }
            }
        }

        /// <summary>
        /// Determines whether the specified cache is available.
        /// </summary>
        /// <param name="cache">
        /// The cache.
        /// </param>
        /// <returns>
        /// <c>True.</c>if the specified cache is available; otherwise, 
        /// <c>False.</c>.
        /// </returns>
        public bool IsAvailable(JB::JetBrains.Util.IUserDataHolder cache)
        {
            return true;
        }

        #endregion
    }
}