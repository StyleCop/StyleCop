// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopOptionsPage.cs" company="http://stylecop.codeplex.com">
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
//   Defines the StyleCopOptionsPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Options
{
    using System;
    using System.Linq.Expressions;

    using JetBrains.DataFlow;
    using JetBrains.ProjectModel;
    using JetBrains.UI.Extensions.Commands;
    using JetBrains.UI.Options;
    using JetBrains.UI.Options.OptionsDialog2.SimpleOptions;
    using JetBrains.UI.Options.OptionsDialog2.SimpleOptions.ViewModel;
    using JetBrains.Util;

    /// <summary>
    /// Options page to allow the plugins options to be set from within the ReSharper Options window.
    /// </summary>
    [OptionsPage(PageId, "StyleCop", null, ParentId = "Tools")]
    public class StyleCopOptionsPage : CustomSimpleOptionsPage
    {
        /// <summary>
        /// The unique name of this options page.
        /// </summary>
        private const string PageId = "StyleCopOptionsPage";

        private readonly Lifetime lifetime;

        /// <summary>
        /// Initializes a new instance of the StyleCopOptionsPage class.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime of the options page.
        /// </param>
        /// <param name="settingsSmartContext">
        /// Our settings context. 
        /// </param>
        /// <param name="solution">
        /// The current solution. Will be null if no solution is currently open.
        /// </param>
        public StyleCopOptionsPage(Lifetime lifetime, OptionsSettingsSmartContext settingsSmartContext, ISolution solution = null)
            : base(lifetime, settingsSmartContext)
        {
            this.lifetime = lifetime;

            this.AddHeader("Options");

            // TODO: It would be nice to get rid of this option. It doesn't do what you think it does
            // It controls whether a one-time init handler checks options at startup, BUT only if the
            // install date is newer than the last init date. We don't even support the installed version...
            // I think we should do the check when showing the options. But what about at startup? Modal
            // dialogs are a little rude...
            // By providing the correct options in a settings file, we automatically get correct defaults, but
            // they can still be overridden in the global settings, and also per-solution
            // this.AddBoolOption(
            //    (StyleCopOptionsSettingsKey options) => options.CheckReSharperCodeStyleOptionsAtStartUp,
            //    "Check ReSharper code style options at startup");

            // Note that we have to check to see if the lifetime is terminated before accessing the
            // settings context because WPF will continue to call our CanExecute until a garbage collection
            // breaks the weak reference that WPF holds on command
            this.AddButton(
                "Reset code style options",
                new DelegateCommand(
                    () => CodeStyleOptions.CodeStyleOptionsReset(settingsSmartContext, solution),
                    () => !lifetime.IsTerminated && !CodeStyleOptions.CodeStyleOptionsValid(settingsSmartContext, solution)));

            this.AddHeader("Headers");
            this.AddBoolOption(
                (StyleCopOptionsSettingsKey options) => options.InsertTextIntoDocumentation,
                "Insert text into documentation and file headers");
            this.AddBoolOption(
                (StyleCopOptionsSettingsKey options) => options.UseSingleLineDeclarationComments,
                "Use single lines for declaration headers");
            this.AddBoolOption(
                (StyleCopOptionsSettingsKey options) => options.InsertToDoText,
                "Insert TODO into headers");
            this.AddIntOption(
                (StyleCopOptionsSettingsKey options) => options.DashesCountInFileHeader,
                "Number of dashes in file header text:");

            this.AddHeader("Analysis Performance");
            this.AddBoolOption(
                (StyleCopOptionsSettingsKey options) => options.AnalysisEnabled,
                "Run StyleCop as you type");
            BoolOptionViewModel nonUserFiles =
                this.AddBoolOption(
                    (StyleCopOptionsSettingsKey options) => options.AnalyzeReadOnlyFiles,
                    "Analyze non-user files (not recommended)");
            IntSliderViewModel performance =
                this.AddIntSliderOption(
                    (StyleCopOptionsSettingsKey options) => options.ParsingPerformance,
                    "Responsiveness:",
                    1,
                    9,
                    "Less resources\r\n(slower)",
                    "More resources\n(faster)");
            this.AddBinding(
                nonUserFiles,
                BindingStyle.IsEnabledProperty,
                (StyleCopOptionsSettingsKey options) => options.AnalysisEnabled,
                JetFunc<object>.Identity);
            this.AddBinding(
                performance,
                BindingStyle.IsEnabledProperty,
                (StyleCopOptionsSettingsKey options) => options.AnalysisEnabled,
                JetFunc<object>.Identity);

            this.AddHeader("Misc");
            this.AddBoolOption(
                (StyleCopOptionsSettingsKey options) => options.UseExcludeFromStyleCopSetting,
                "Use ExcludeFromStyleCop setting in csproj files");
            this.AddStringOption(
                (StyleCopOptionsSettingsKey options) => options.SuppressStyleCopAttributeJustificationText,
                "Justification for SuppressMessage attribute:");

            this.FinishPage();
        }

        private IntSliderViewModel AddIntSliderOption<T>(
            Expression<Func<T, int>> lambdaExpression,
            string text,
            int minValue,
            int maxValue,
            string minValueText,
            string maxValueText,
            string toolTipText = null)
        {
            var option = new IntSliderViewModel(
                this.lifetime,
                this.OptionsSettingsSmartContext,
                this.OptionsSettingsSmartContext.Schema.GetScalarEntry(lambdaExpression),
                text,
                minValue,
                maxValue,
                minValueText,
                maxValueText,
                toolTipText);
            this.OptionEntities.Add(option);
            return option;
        }
    }
}