// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyOrModuleAttribute.cs" company="https://github.com/StyleCop">
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
//   Describes the contents of an assembly or module attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes the contents of an assembly or module attribute.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class AssemblyOrModuleAttribute : CsElement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the AssemblyOrModuleAttribute class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="declaration">
        /// The declaration code for this element.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        /// <param name="attributes">
        /// The actual attribute that this Assembly or Module level attribute contains.
        /// </param>
        internal AssemblyOrModuleAttribute(CsDocument document, CsElement parent, Declaration declaration, bool generated, ICollection<Attribute> attributes)
            : base(
                document, 
                parent, 
                ElementType.AssemblyOrModuleAttribute, 
                "assembly or module attribute " + declaration.Name, 
                null, 
                attributes, 
                declaration, 
                false, 
                generated)
        {
            Param.Ignore(document, parent, declaration, generated);
        }

        #endregion
    }
}