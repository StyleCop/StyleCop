// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Number.cs" company="https://github.com/StyleCop">
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
//   Describes a numeric token.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes a numeric token.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class Number : CsToken
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Number class.
        /// </summary>
        /// <param name="token">
        /// The token string.
        /// </param>
        /// <param name="location">
        /// The location of the number in the code.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal Number(string token, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(token, CsTokenType.Number, CsTokenClass.Number, location, parent, generated)
        {
            Param.Ignore(token, location, parent, generated);
        }

        #endregion
    }
}