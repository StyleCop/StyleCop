// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsTokenClass.cs" company="https://github.com/StyleCop">
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
//   The varies token classes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The varies token classes.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public enum CsTokenClass
    {
        /// <summary>
        /// An attribute token.
        /// </summary>
        Attribute, 

        /// <summary>
        /// A generic type token.
        /// </summary>
        GenericType, 

        /// <summary>
        /// A number token.
        /// </summary>
        Number, 

        /// <summary>
        /// A preprocessor directive token.
        /// </summary>
        PreprocessorDirective, 

        /// <summary>
        /// A region directive token.
        /// </summary>
        RegionDirective, 

        /// <summary>
        /// A conditional compilation directive token.
        /// </summary>
        ConditionalCompilationDirective, 

        /// <summary>
        /// A type token.
        /// </summary>
        Type, 

        /// <summary>
        /// A whitespace token.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace", 
            Justification = "API has already been published and should not be changed.")]
        Whitespace, 

        /// <summary>
        /// An Xml header token.
        /// </summary>
        XmlHeader, 

        /// <summary>
        /// An operator symbol token.
        /// </summary>
        OperatorSymbol, 

        /// <summary>
        /// A curly bracket, square bracket, parenthesis, attribute bracket, or generic bracket.
        /// </summary>
        Bracket, 

        /// <summary>
        /// A constructor constraint token.
        /// </summary>
        ConstructorConstraint, 

        /// <summary>
        /// A standard token.
        /// </summary>
        Token
    }
}