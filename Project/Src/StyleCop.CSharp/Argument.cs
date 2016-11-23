// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Argument.cs" company="https://github.com/StyleCop">
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
//   Describes an argument passed to a method, constructor, indexer, etc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics;

    /// <summary>
    /// Describes an argument passed to a method, constructor, indexer, etc.
    /// </summary>
    /// <subcategory>other</subcategory>
    [DebuggerDisplay("{Expression.Text}")]
    public class Argument : ICodePart
    {
        #region Fields

        /// <summary>
        /// The expression that forms the body of the argument.
        /// </summary>
        private readonly Expression argumentExpression;

        /// <summary>
        /// Indicates whether the argument is located within a block of generated code.
        /// </summary>
        private readonly bool generated;

        /// <summary>
        /// The location of the argument.
        /// </summary>
        private readonly CodeLocation location;

        /// <summary>
        /// The argument modifiers, if any.
        /// </summary>
        private readonly ParameterModifiers modifiers;

        /// <summary>
        /// The optional argument name.
        /// </summary>
        private readonly CsToken name;

        /// <summary>
        /// The parent code part.
        /// </summary>
        private readonly Reference<ICodePart> parent;

        /// <summary>
        /// The tokens that make up the argument.
        /// </summary>
        private readonly CsTokenList tokens;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Argument class.
        /// </summary>
        /// <param name="name">
        /// The optional name of the argument.
        /// </param>
        /// <param name="modifiers">
        /// Modifiers applied to this argument.
        /// </param>
        /// <param name="argumentExpression">
        /// The expression that forms the body of the argument.
        /// </param>
        /// <param name="location">
        /// The location of the argument in the code.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="tokens">
        /// The tokens that form the argument.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the argument is located within a block of generated code.
        /// </param>
        internal Argument(
            CsToken name, 
            ParameterModifiers modifiers, 
            Expression argumentExpression, 
            CodeLocation location, 
            Reference<ICodePart> parent, 
            CsTokenList tokens, 
            bool generated)
        {
            Param.Ignore(name);
            Param.Ignore(modifiers);
            Param.AssertNotNull(argumentExpression, "argumentExpression");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(tokens);
            Param.Ignore(generated);

            this.name = name;
            this.modifiers = modifiers;
            this.argumentExpression = argumentExpression;
            this.location = location;
            this.parent = parent;
            this.tokens = tokens;
            this.generated = generated;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of this code part.
        /// </summary>
        public CodePartType CodePartType
        {
            get
            {
                return CodePartType.Argument;
            }
        }

        /// <summary>
        /// Gets the expression that forms the body of the argument.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return this.argumentExpression;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the argument is located within a block of generated code.
        /// </summary>
        public bool Generated
        {
            get
            {
                return this.generated;
            }
        }

        /// <summary>
        /// Gets the line number that the argument appears on in the code.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.location.LineNumber;
            }
        }

        /// <summary>
        /// Gets the location of the argument in the code.
        /// </summary>
        public CodeLocation Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this argument.
        /// </summary>
        public ParameterModifiers Modifiers
        {
            get
            {
                return this.modifiers;
            }
        }

        /// <summary>
        /// Gets the optional argument name.
        /// </summary>
        public CsToken Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the parent of the argument.
        /// </summary>
        public ICodePart Parent
        {
            get
            {
                return this.parent.Target;
            }
        }

        /// <summary>
        /// Gets the tokens that form the argument.
        /// </summary>
        public CsTokenList Tokens
        {
            get
            {
                return this.tokens;
            }
        }

        #endregion
    }
}