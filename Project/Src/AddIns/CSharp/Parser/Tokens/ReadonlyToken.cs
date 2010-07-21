//-----------------------------------------------------------------------
// <copyright file="ReadonlyToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a readonly keyword.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Readonly", Justification = "Matches the C# keyword readonly.")]
    public sealed class ReadonlyToken : Token
    {
        /// <summary>
        /// Initializes a new instance of the ReadonlyToken class.
        /// </summary>
        /// <param name="text">The text of the codeUnit.</param>
        /// <param name="location">The location of the codeUnit.</param>
        /// <param name="generated">Indicates whether the codeUnit is generated.</param>
        internal ReadonlyToken(string text, CodeLocation location, bool generated)
            : base(text, TokenType.Readonly, location, generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }
    }
}
