// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionalCompilationDirective.cs" company="https://github.com/StyleCop">
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
//   Describes a conditional compilation directive token.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes a conditional compilation directive token.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class ConditionalCompilationDirective : Preprocessor
    {
        #region Fields

        /// <summary>
        /// The expression that makes up the body of the directive.
        /// </summary>
        private readonly Expression body;

        /// <summary>
        /// The type of the directive.
        /// </summary>
        private readonly ConditionalCompilationDirectiveType type;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ConditionalCompilationDirective class.
        /// </summary>
        /// <param name="text">
        /// The line text.
        /// </param>
        /// <param name="type">
        /// The type of the directive.
        /// </param>
        /// <param name="body">
        /// The expression that makes up the body of the directive.
        /// </param>
        /// <param name="location">
        /// The location of the preprocessor in the code.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the directive lies within a block of generated code.
        /// </param>
        internal ConditionalCompilationDirective(
            string text, ConditionalCompilationDirectiveType type, Expression body, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(text, CsTokenClass.ConditionalCompilationDirective, location, parent, generated)
        {
            Param.AssertValidString(text, "text");
            Param.Ignore(type);
            Param.Ignore(body);
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            this.type = type;
            this.body = body;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression that makes up the body of the directive.
        /// </summary>
        public Expression Body
        {
            get
            {
                return this.body;
            }
        }

        /// <summary>
        /// Gets the type of the conditional compilation directive.
        /// </summary>
        public ConditionalCompilationDirectiveType ConditionalCompilationDirectiveType
        {
            get
            {
                return this.type;
            }
        }

        #endregion
    }
}