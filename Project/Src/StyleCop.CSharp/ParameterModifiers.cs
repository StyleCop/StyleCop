// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterModifiers.cs" company="https://github.com/StyleCop">
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
//   The various types of modifiers on a <see cref="Parameter" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;

    /// <summary>
    /// The various types of modifiers on a <see cref="Parameter"/>.
    /// </summary>
    /// <subcategory>other</subcategory>
    [Flags]
    public enum ParameterModifiers
    {
        /// <summary>
        /// No modifiers specified.
        /// </summary>
        None = 0x00, 

        /// <summary>
        /// The 'out' modifier.
        /// </summary>
        Out = 0x01, 

        /// <summary>
        /// The 'ref' modifier.
        /// </summary>
        Ref = 0x02, 

        /// <summary>
        /// The <c>'params'</c> modifier.
        /// </summary>
        Params = 0x04, 

        /// <summary>
        /// The 'this' modifier.
        /// </summary>
        This = 0x08, 

        /// <summary>
        /// The 'in' modifier.
        /// </summary>
        In = 0x10
    }
}