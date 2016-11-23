// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionalCompilationDirectiveType.cs" company="https://github.com/StyleCop">
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
//   The various types of conditional compilation directives.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various types of conditional compilation directives.
    /// </summary>
    /// <subcategory>token</subcategory>
    public enum ConditionalCompilationDirectiveType
    {
        /// <summary>
        /// An if directive.
        /// </summary>
        If, 

        /// <summary>
        /// An elif directive.
        /// </summary>
        Elif, 

        /// <summary>
        /// An else directive.
        /// </summary>
        Else, 

        /// <summary>
        /// An endif directive.
        /// </summary>
        Endif
    }
}