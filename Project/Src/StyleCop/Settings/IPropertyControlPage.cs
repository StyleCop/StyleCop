// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyControlPage.cs" company="https://github.com/StyleCop">
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
//   Interface which must be implemented by a page that appears on the <see cref="PropertyControl" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// Interface which must be implemented by a page that appears on the <see cref="PropertyControl"/>.
    /// </summary>
    public interface IPropertyControlPage
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the page is dirty.
        /// </summary>
        bool Dirty { get; set; }

        /// <summary>
        /// Gets the text displayed on the page tab.
        /// </summary>
        string TabName { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called whenever the page is being shown or hidden.
        /// </summary>
        /// <param name="activated">
        /// True if the page is being show, false if it is being hidden.
        /// </param>
        void Activate(bool activated);

        /// <summary>
        /// Saves the data on the page and resets any internal dirty flags.
        /// </summary>
        /// <returns>Returns true if the page settings were applied.</returns>
        bool Apply();

        /// <summary>
        /// Initializes the page object.
        /// </summary>
        /// <param name="propertyControl">
        /// The property control that hosts the page.
        /// </param>
        void Initialize(PropertyControl propertyControl);

        /// <summary>
        /// Allows the property page to perform an action after the settings for all pages have been applied.
        /// </summary>
        /// <param name="wasDirty">
        /// Indicates whether the page was dirty before it was applied.
        /// </param>
        void PostApply(bool wasDirty);

        /// <summary>
        /// Allows the property page to perform an action before any of the settings pages have been applied.
        /// </summary>
        /// <returns>Returns false if no pages should be applied.</returns>
        bool PreApply();

        /// <summary>
        /// Called when the merged settings have changed.
        /// </summary>
        void RefreshSettingsOverrideState();

        #endregion
    }
}