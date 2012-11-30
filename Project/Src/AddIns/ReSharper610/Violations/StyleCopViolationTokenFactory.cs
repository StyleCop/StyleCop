// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopViolationTokenFactory.cs" company="http://stylecop.codeplex.com">
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
//   Factory class for getting HighLights for StyleCop violations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper610.Violations
{
    #region Using Directives

    using StyleCop.CSharp;

    #endregion

    /// <summary>
    /// Factory class for getting HighLights for StyleCop violations.
    /// </summary>
    public static class StyleCopViolationTokenFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the <see cref="CsTokenType"/> for the specified StyleCop Violation.
        /// </summary>
        /// <param name="checkId">
        /// Rule check id of violation.
        /// </param>
        /// <returns>
        /// An <see cref="CsTokenType"/> for the specified check id.
        /// </returns>
        public static CsTokenType? GetTokenType(string checkId)
        {
            switch (checkId)
            {
                case "SA1007":
                    return CsTokenType.Operator;
                case "SA1008":
                    return CsTokenType.OpenParenthesis;
                case "SA1009":
                    return CsTokenType.CloseParenthesis;
                case "SA1010":
                    return CsTokenType.OpenSquareBracket;
                case "SA1011":
                    return CsTokenType.CloseSquareBracket;
                case "SA1012":
                    return CsTokenType.OpenCurlyBracket;
                case "SA1013":
                    return CsTokenType.CloseCurlyBracket;
                case "SA1016":
                    return CsTokenType.OpenAttributeBracket;
                case "SA1017":
                    return CsTokenType.CloseAttributeBracket;
                case "SA1024":
                    return CsTokenType.LabelColon;
                default:
                    return null;
            }
        }

        #endregion
    }
}