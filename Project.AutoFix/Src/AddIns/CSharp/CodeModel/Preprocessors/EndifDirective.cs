//-----------------------------------------------------------------------
// <copyright file="EndifDirective.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;

    /// <summary>
    /// Describes an endif directive.
    /// </summary>
    /// <subcategory>preprocessor</subcategory>
    public sealed class EndifDirective : ConditionalCompilationDirective
    {
        /// <summary>
        /// Initializes a new instance of the EndifDirective class.
        /// </summary>
        /// <param name="text">The text within the directive.</param>
        /// <param name="proxy">The proxy.</param>
        /// <param name="body">The body expression.</param>
        internal EndifDirective(string text, CodeUnitProxy proxy, Expression body)
            : base(text, proxy, PreprocessorType.Elif, body)
        {
            Param.Ignore(text, proxy, body);
        }
    }
}
