// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccessModifierType.cs" company="https://github.com/StyleCop">
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
//   The various access modifier types for code elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    // These are listed in the order that they should appear in the code.

    /// <summary>
    /// The various access modifier types for code elements.
    /// </summary>
    /// <subcategory>element</subcategory>
    public enum AccessModifierType
    {
        /// <summary>
        /// A publicly exposed element.
        /// </summary>
        Public = 0, 

        /// <summary>
        /// An internally exposed element.
        /// </summary>
        Internal = 1, 

        /// <summary>
        /// A protected and internally exposed element.
        /// </summary>
        ProtectedInternal = 2, 

        /// <summary>
        /// A protected element, exposed only to deriving classes.
        /// </summary>
        Protected = 3, 

        /// <summary>
        /// A private, unexposed element.
        /// </summary>
        Private = 4, 

        /// <summary>
        /// A protected element that is inside of an internal element.
        /// </summary>
        ProtectedAndInternal = 5
    }
}