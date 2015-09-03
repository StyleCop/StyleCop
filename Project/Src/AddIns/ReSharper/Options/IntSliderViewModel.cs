// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntSliderViewModel.cs" company="http://stylecop.codeplex.com">
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
//   View model to represent a numeric setting as a slider control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Options
{
    using System.Collections.Generic;

    using JetBrains.Application.Settings;
    using JetBrains.DataFlow;
    using JetBrains.UI.Options;
    using JetBrains.UI.Options.OptionsDialog2.SimpleOptions;
    using JetBrains.UI.RichText;

    /// <summary>
    /// View model for an numeric base slider option value
    /// </summary>
    public class IntSliderViewModel : OptionEntityPrimitive, IOptionCanBeEnabled
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntSliderViewModel"/> class.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime of the view model
        /// </param>
        /// <param name="context">
        /// The settings context
        /// </param>
        /// <param name="settingsScalarEntry">
        /// The settings entry this view model is bound to
        /// </param>
        /// <param name="text">
        /// The text to display for this option
        /// </param>
        /// <param name="minValue">
        /// The minimum allowed value
        /// </param>
        /// <param name="maxValue">
        /// The maximum allowed value
        /// </param>
        /// <param name="minValueText">
        /// The text to be displayed next to the lower end of the slider
        /// </param>
        /// <param name="maxValueText">
        /// The text to be displayed next to the upper end of the slider
        /// </param>
        /// <param name="toolTipText">
        /// The text to be shown in a tooltip. If left null, defaults to the description of the bound settings entry
        /// </param>
        public IntSliderViewModel(
            Lifetime lifetime,
            IContextBoundSettingsStoreLive context,
            SettingsScalarEntry settingsScalarEntry,
            string text,
            int minValue,
            int maxValue,
            string minValueText,
            string maxValueText,
            string toolTipText)
        {
            this.Text = text;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.MinValueText = minValueText;
            this.MaxValueText = maxValueText;
            this.ToolTipText = toolTipText ?? settingsScalarEntry.Description;
            this.IntProperty = new Property<int>(lifetime, "IntProperty");
            this.IsEnabledProperty = new Property<bool>(lifetime, "IntProperty") { Value = true };

            context.SetBinding(lifetime, settingsScalarEntry, this.IntProperty);
        }

        /// <summary>
        /// Gets the live property that represents the bound value.
        /// </summary>
        public Property<int> IntProperty { get; private set; }

        /// <summary>
        /// Gets the text to display for the option.
        /// </summary>
        public RichText Text { get; private set; }

        /// <summary>
        /// Gets the minimum allowed value.
        /// </summary>
        public int MinValue { get; private set; }

        /// <summary>
        /// Gets the maximum allowed value.
        /// </summary>
        public int MaxValue { get; private set; }

        /// <summary>
        /// Gets the text to be displayed next to the lower end of the slider.
        /// </summary>
        public string MinValueText { get; private set; }

        /// <summary>
        ///  Gets the text to be displayed next to the upper end of the slider.
        /// </summary>
        public string MaxValueText { get; private set; }

        /// <summary>
        /// Gets the tooltip to be displayed for the slider.
        /// </summary>
        public string ToolTipText { get; private set; }

        /// <summary>
        /// Gets the live property that represents the enabled state of the view.
        /// </summary>
        public IProperty<bool> IsEnabledProperty { get; private set; }

        /// <summary>
        /// Retrieves keywords for searching
        /// </summary>
        /// <returns>
        /// Returns a collection of keywords for searching.
        /// </returns>
        public override IEnumerable<OptionsPageKeyword> GetKeywords()
        {
            yield return new OptionsPageKeyword(this.Text);
            yield return new OptionsPageKeyword(this.MinValueText);
            yield return new OptionsPageKeyword(this.MaxValueText);
            if (!string.IsNullOrEmpty(this.ToolTipText))
            {
                yield return new OptionsPageKeyword(this.ToolTipText);
            }
        }
    }
}