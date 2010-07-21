//-----------------------------------------------------------------------
// <copyright file="EmptyElement.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes an element consisting only of a single semicolon.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class EmptyElement : Element
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the EmptyElement class.
        /// </summary>
        /// <param name="proxy">Proxy objecgt for the empty element.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal EmptyElement(CodeUnitProxy proxy, bool unsafeCode)
            : base(proxy, ElementType.EmptyElement, Strings.EmptyElement, null, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(unsafeCode);
        }

        #endregion Internal Constructors

        #region Protected Override Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected override IEnumerable<string> AllowedModifiers
        {
            get
            {
                return new string[] { };
            }
        }

        /// <summary>
        /// Gets the default access modifier for this type.
        /// </summary>
        protected override AccessModifierType DefaultAccessModifierType
        {
            get
            {
                return AccessModifierType.Public;
            }
        }

        #endregion Protected Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            return Strings.EmptyElement;
        }

        #endregion Protected Override Methods
    }
}
