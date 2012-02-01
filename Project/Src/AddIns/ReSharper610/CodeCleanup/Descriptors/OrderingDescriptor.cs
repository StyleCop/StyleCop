// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderingDescriptor.cs" company="http://stylecop.codeplex.com">
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

namespace StyleCop.ReSharper610.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper610.CodeCleanup.Options;
    using StyleCop.ReSharper610.CodeCleanup.Styles;

    #endregion

    /// <summary>
    /// Code Clean Up Description.
    /// </summary>
    [Category("StyleCop")]
    [DisplayName("Ordering")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OrderingDescriptor : CodeCleanupOptionDescriptor<OrderingOptions>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderingDescriptor"/> class.
        /// </summary>
        public OrderingDescriptor()
            : base("StyleCop.Ordering")
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the specified profile.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The options.
        /// </returns>
        public override OrderingOptions Load(XmlElement element)
        {
            var options = new OrderingOptions();

            try
            {
                options.AlphabeticalUsingDirectives =
                    (AlphabeticalUsingsStyle)Enum.Parse(typeof(AlphabeticalUsingsStyle), JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "AlphabeticalUsingDirectives"));
                options.ExpandUsingDirectives = (ExpandUsingsStyle)Enum.Parse(typeof(ExpandUsingsStyle), JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "ExpandUsingDirectives"));
                options.SA1212PropertyAccessorsMustFollowOrder = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1212PropertyAccessorsMustFollowOrder"));
                options.SA1213EventAccessorsMustFollowOrder = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1213EventAccessorsMustFollowOrder"));
            }
            catch (ArgumentNullException)
            {
            }
            catch (ArgumentException)
            {
            }

            return options;
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
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="options">
        /// The options to save.
        /// </param>
        public override void Save(XmlElement element, OrderingOptions options)
        {
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "AlphabeticalUsingDirectives", options.AlphabeticalUsingDirectives.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "ExpandUsingDirectives", options.ExpandUsingDirectives.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1212PropertyAccessorsMustFollowOrder", options.SA1212PropertyAccessorsMustFollowOrder.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1213EventAccessorsMustFollowOrder", options.SA1213EventAccessorsMustFollowOrder.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}