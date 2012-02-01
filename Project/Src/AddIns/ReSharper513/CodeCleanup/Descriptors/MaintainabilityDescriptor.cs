// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaintainabilityDescriptor.cs" company="http://stylecop.codeplex.com">
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
//   Code Clean Up Description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper513.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper513.CodeCleanup.Options;

    #endregion

    /// <summary>
    /// Code Clean Up Description.
    /// </summary>
    [Category("StyleCop")]
    [DisplayName("Maintainability")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MaintainabilityDescriptor : CodeCleanupOptionDescriptor<MaintainabilityOptions>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MaintainabilityDescriptor"/> class. 
        /// </summary>
        public MaintainabilityDescriptor()
            : base("StyleCop.Maintainability")
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        public override void Load(CodeCleanupProfile profile, XmlElement element)
        {
            var options = new MaintainabilityOptions();
            var optionsElement = (XmlElement)element.SelectSingleNode(this.Name);

            if (optionsElement != null)
            {
                try
                {
                    options.SA1119StatementMustNotUseUnnecessaryParenthesis =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1119StatementMustNotUseUnnecessaryParenthesis"));
                }
                catch (ArgumentException)
                {
                }
            }

            profile.SetSetting(this, options);
        }

        /// <summary>
        /// Presents the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <returns>
        /// Specified profile.
        /// </returns>
        public override string Present(CodeCleanupProfile profile)
        {
            return profile.GetSetting(this).ToString();
        }

        /// <summary>
        /// Saves the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        public override void Save(CodeCleanupProfile profile, XmlElement element)
        {
            var options = profile.GetSetting(this);
            var optionsElement = JB::JetBrains.Util.XmlUtil.CreateElement(element, this.Name);

            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1119StatementMustNotUseUnnecessaryParenthesis", options.SA1119StatementMustNotUseUnnecessaryParenthesis.ToString());
        }

        #endregion
    }
}