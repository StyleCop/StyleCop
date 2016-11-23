// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableModifiers.cs" company="https://github.com/StyleCop">
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
//   The various types of modifiers on a variable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The various types of modifiers on a variable.
    /// </summary>
    /// <subcategory>other</subcategory>
    [Flags]
    public enum VariableModifiers
    {
        /// <summary>
        /// No modifiers specified.
        /// </summary>
        None = 0x00, 

        /// <summary>
        /// The <see langword="const"/> modifier.
        /// </summary>
        Const = 0x01, 

        /// <summary>
        /// The 'readonly' modifier.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Readonly", 
            Justification = "API has already been published and should not be changed.")]
        Readonly = 0x02
    }
}