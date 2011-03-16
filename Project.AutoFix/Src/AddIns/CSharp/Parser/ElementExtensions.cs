//-----------------------------------------------------------------------
// <copyright file="ElementExtensions.cs">
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
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics;
    using StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Extension methods for the <see cref="Element" /> class.
    /// </summary>
    public static class ElementExtensions
    {
        /// <summary>
        /// Gets the analyzer tag for the given element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>Returns the analyzer tag.</returns>
        public static object GetAnalyzerTag(this Element element)
        {
            Param.RequireNotNull(element, "element");

            ElementWrapper wrapper = ElementWrapper.Wrapper(element);
            if (wrapper == null)
            {
                throw new InvalidOperationException();
            }

            return wrapper.AnalyzerTag;
        }

        /// <summary>
        /// Gets the analyzer tag for the given element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value to set.</param>
        public static void SetAnalyzerTag(this Element element, object value)
        {
            Param.RequireNotNull(element, "element");
            Param.Ignore(value);

            ElementWrapper wrapper = ElementWrapper.Wrapper(element);
            if (wrapper == null)
            {
                throw new InvalidOperationException();
            }

            wrapper.AnalyzerTag = value;
        }
    }
}
