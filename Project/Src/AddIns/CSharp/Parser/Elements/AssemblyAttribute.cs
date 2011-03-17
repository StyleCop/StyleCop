//-----------------------------------------------------------------------
// <copyright file="AssemblyAttribute.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes the contents of an assembly attribute.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class AssemblyAttribute : CsElement
    {
        #region Private Fields
        
        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the AssemblyAttribute class.
        /// </summary>
        /// <param name="document">The document that contains the element.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="declaration">The declaration code for this element.</param>
        /// <param name="generated">Indicates whether the code element was generated or written by hand.</param>
        internal AssemblyAttribute(
            CsDocument document,
            CsElement parent,
            Declaration declaration,
            bool generated)
            : base(
            document,
            parent,
            ElementType.AssemblyAttribute,
            "assembly attribute " + declaration.Name,
            null,
            null,
            declaration,
            false,
            generated)
        {
            Param.Ignore(document, parent, declaration, generated);
        }

        #endregion Internal Constructors
    }
}