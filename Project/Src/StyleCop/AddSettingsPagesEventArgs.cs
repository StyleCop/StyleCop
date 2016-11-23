// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSettingsPagesEventArgs.cs" company="https://github.com/StyleCop">
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
//   Event arguments for the <see cref="StyleCopCore.AddSettingsPages" /> event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Event arguments for the <see cref="StyleCopCore.AddSettingsPages" /> event.
    /// </summary>
    public class AddSettingsPagesEventArgs : EventArgs
    {
        #region Fields

        /// <summary>
        /// The pages that have been added.
        /// </summary>
        private readonly List<IPropertyControlPage> pages = new List<IPropertyControlPage>();

        /// <summary>
        /// The path to the settings file.
        /// </summary>
        private readonly string settingsPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AddSettingsPagesEventArgs"/> class.
        /// </summary>
        /// <param name="settingsPath">
        /// The path to the settings file.
        /// </param>
        internal AddSettingsPagesEventArgs(string settingsPath)
        {
            Param.AssertValidString(settingsPath, "settingsPath");
            this.settingsPath = settingsPath;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the pages that were added to the StyleCop settings dialog.
        /// </summary>
        public IEnumerable<IPropertyControlPage> Pages
        {
            get
            {
                return this.pages;
            }
        }

        /// <summary>
        /// Gets the path to the StyleCop settings file.
        /// </summary>
        public string SettingsPath
        {
            get
            {
                return this.settingsPath;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a page to be displayed on the StyleCop project settings dialog.
        /// </summary>
        /// <param name="page">
        /// The page to add.
        /// </param>
        public void Add(IPropertyControlPage page)
        {
            Param.RequireNotNull(page, "page");

            if (page != null)
            {
                this.pages.Add(page);
            }
        }

        #endregion
    }
}