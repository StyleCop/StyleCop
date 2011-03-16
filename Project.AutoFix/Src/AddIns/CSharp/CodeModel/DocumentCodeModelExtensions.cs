//-----------------------------------------------------------------------
// <copyright file="DocumentCodeModelExtensions.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this ditribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extension methods for the <see cref="CsDocument" /> class which allow creation of new elements to be added to the model.
    /// </summary>
    public static class DocumentCodeModelExtensions
    {
        #region CodeUnits

        /// <summary>
        /// Creates an <see cref="Argument" />.
        /// </summary>
        /// <param name="document">The document which the argument will be added to.</param>
        /// <param name="argumentExpression">The argument expression.</param>
        /// <param name="modifiers">The parameter modifiers.</param>
        /// <returns>Returns the list.</returns>
        public static Argument CreateArgument(this CsDocument document, Expression argumentExpression, ParameterModifiers modifiers = ParameterModifiers.None)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(argumentExpression, "argumentExpression");
            Param.Ignore(modifiers, "modifiers");

            ValidateDocument(document, argumentExpression, "argumentExpression");

            CodeUnitProxy proxy = new CodeUnitProxy(document);

            if ((modifiers & ~(ParameterModifiers.Ref | ParameterModifiers.In | ParameterModifiers.Out)) != 0)
            {
                // Other modifier types are not supported.
                throw new ArgumentException("modifiers");
            }

            if ((modifiers & ParameterModifiers.Ref) != 0)
            {
                if ((modifiers & (ParameterModifiers.In | ParameterModifiers.Out)) != 0)
                {
                    // Ref plus In or Out is not supported.
                    throw new ArgumentException("modifiers");
                }

                Add(proxy, document.CreateRefToken());
                Add(proxy, document.CreateSpace());
            }
            else
            {
                // In and Out may both be present.
                if ((modifiers & ParameterModifiers.In) != 0)
                {
                    Add(proxy, document.CreateInToken());
                    Add(proxy, document.CreateSpace());
                }

                if ((modifiers & ParameterModifiers.Out) != 0)
                {
                    Add(proxy, document.CreateOutToken());
                    Add(proxy, document.CreateSpace());
                }
            }

            Add(proxy, argumentExpression);

            return new Argument(proxy, modifiers, argumentExpression);
        }

        /// <summary>
        /// Creates an <see cref="ArgumentList" />.
        /// </summary>
        /// <param name="document">The document which the argument will be added to.</param>
        /// <param name="arguments">The colletion of arguments within the list.</param>
        /// <returns>Returns the argument list.</returns>
        public static ArgumentList CreateArgumentList(this CsDocument document, IEnumerable<Argument> arguments = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(arguments);

            CodeUnitProxy proxy = new CodeUnitProxy(document);

            Add(proxy, document.CreateOpenParenthesisToken());

            if (arguments == null)
            {
                Add(proxy, document.CreateCloseParenthesisToken());
                return new ArgumentList(proxy);
            }
            else
            {
                int argumentIndex = 0;
                foreach (Argument argument in arguments)
                {
                    Param.RequireNotNull(argument, "argument");
                    ValidateDocument(document, argument, "argument");

                    if (argumentIndex > 0)
                    {
                        Add(proxy, document.CreateCommaToken());
                        Add(proxy, document.CreateSpace());
                    }

                    Add(proxy, argument);

                    ++argumentIndex;
                }

                Add(proxy, document.CreateCloseParenthesisToken());
                return new ArgumentList(proxy, arguments);
            }
        }

        /// <summary>
        /// Creates a <see cref="GenericTypeParameterList" />.
        /// </summary>
        /// <param name="document">The document which the list will be added to.</param>
        /// <param name="parameter">The single generic type parameter.</param>
        /// <returns>Returns the list.</returns>
        public static GenericTypeParameterList CreateGenericTypeParameterList(this CsDocument document, GenericTypeParameter parameter)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(parameter, "parameter");

            return document.CreateGenericTypeParameterList(new[] { parameter });
        }

        /// <summary>
        /// Creates a <see cref="GenericTypeParameterList" />.
        /// </summary>
        /// <param name="document">The document which the list will be added to.</param>
        /// <param name="parameters">The generic type parameters.</param>
        /// <returns>Returns the list.</returns>
        public static GenericTypeParameterList CreateGenericTypeParameterList(this CsDocument document, ICollection<GenericTypeParameter> parameters)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidCollection(parameters, "parameters");

            CodeUnitProxy proxy = new CodeUnitProxy(document);

            int i = 0;
            foreach (GenericTypeParameter p in parameters)
            {
                Add(proxy, p);

                if (i < parameters.Count - 1)
                {
                    Add(proxy, document.CreateCommaToken());
                    Add(proxy, document.CreateSpace());
                }

                ++i;
            }

            return new GenericTypeParameterList(proxy);
        }

        /// <summary>
        /// Creates a <see cref="FileHeader" />.
        /// </summary>
        /// <param name="document">The document which the header will be added to.</param>
        /// <param name="fileHeaderElements">The elements within the header.</param>
        /// <returns>Returns the header.</returns>
        public static FileHeader CreateFileHeader(this CsDocument document, params SingleLineComment[] fileHeaderElements)
        {
            Param.Ignore(document, fileHeaderElements);
            return document.CreateFileHeader((ICollection<SingleLineComment>)fileHeaderElements);
        }

        /// <summary>
        /// Creates a <see cref="FileHeader" />.
        /// </summary>
        /// <param name="document">The document which the header will be added to.</param>
        /// <param name="fileHeaderElements">The elements within the header.</param>
        /// <returns>Returns the header.</returns>
        public static FileHeader CreateFileHeader(this CsDocument document, ICollection<SingleLineComment> fileHeaderElements)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidCollection(fileHeaderElements, "fileHeaderElements");

            CodeUnitProxy proxy = new CodeUnitProxy(document);

            int i = 0;
            foreach (SingleLineComment member in fileHeaderElements)
            {
                Add(proxy, member);
                if (i < fileHeaderElements.Count - 1)
                {
                    Add(proxy, document.CreateEndOfLine());
                }

                ++i;
            }

            return new FileHeader(proxy);
        }

        /// <summary>
        /// Creates a <see cref="ElementHeader" />.
        /// </summary>
        /// <param name="document">The document which the header will be added to.</param>
        /// <param name="elementHeaderLines">The lines within the header.</param>
        /// <returns>Returns the header.</returns>
        public static ElementHeader CreateElementHeader(this CsDocument document, params ElementHeaderLine[] elementHeaderLines)
        {
            Param.Ignore(document, elementHeaderLines);
            return document.CreateElementHeader((ICollection<ElementHeaderLine>)elementHeaderLines);
        }

        /// <summary>
        /// Creates a <see cref="ElementHeader" />.
        /// </summary>
        /// <param name="document">The document which the header will be added to.</param>
        /// <param name="elementHeaderLines">The lines within the header.</param>
        /// <returns>Returns the header.</returns>
        public static ElementHeader CreateElementHeader(this CsDocument document, ICollection<ElementHeaderLine> elementHeaderLines)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidCollection(elementHeaderLines, "elementHeaderLines");

            CodeUnitProxy proxy = new CodeUnitProxy(document);

            int i = 0;
            foreach (ElementHeaderLine member in elementHeaderLines)
            {
                Add(proxy, member);
                if (i < elementHeaderLines.Count - 1)
                {
                    Add(proxy, document.CreateEndOfLine());
                }

                ++i;
            }

            return new ElementHeader(proxy);
        }
        
        #endregion CodeUnits

        #region LexicalElements

        /// <summary>
        /// Creates a <see cref="Whitespace" /> containing a single space.
        /// </summary>
        /// <param name="document">The document which the whitespace will be added to.</param>
        /// <returns>Returns the whitespace.</returns>
        public static Whitespace CreateSpace(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new Whitespace(document, " ");
        }

        /// <summary>
        /// Creates a <see cref="Whitespace" /> containing multiple spaces.
        /// </summary>
        /// <param name="document">The document which the whitespace will be added to.</param>
        /// <param name="spaceCount">The number of spaces within the whitespace.</param>
        /// <returns>Returns the whitespace.</returns>
        public static Whitespace CreateSpaces(this CsDocument document, int spaceCount)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireGreaterThanZero(spaceCount, "spaceCount");

            char[] chars = new char[spaceCount];
            for (int i = 0; i < chars.Length; ++i)
            {
                chars[i] = ' ';
            }

            return new Whitespace(document, new string(chars));
        }

        /// <summary>
        /// Creates a <see cref="Whitespace" /> containing a single tab.
        /// </summary>
        /// <param name="document">The document which the whitespace will be added to.</param>
        /// <returns>Returns the whitespace.</returns>
        public static Whitespace CreateTab(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new Whitespace(document, "\t");
        }

        /// <summary>
        /// Creates a <see cref="Whitespace" /> containing multiple tabs.
        /// </summary>
        /// <param name="document">The document which the whitespace will be added to.</param>
        /// <param name="tabCount">The number of tabs within the whitespace.</param>
        /// <returns>Returns the whitespace.</returns>
        public static Whitespace CreateTabs(this CsDocument document, int tabCount)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireGreaterThanZero(tabCount, "tabCount");

            char[] chars = new char[tabCount];
            for (int i = 0; i < chars.Length; ++i)
            {
                chars[i] = '\t';
            }

            return new Whitespace(document, new string(chars));
        }

        /// <summary>
        /// Creates a <see cref="EndOfLine" /> containing a single newline.
        /// </summary>
        /// <param name="document">The document which the end-of-line will be added to.</param>
        /// <returns>Returns the end-of-line.</returns>
        public static EndOfLine CreateEndOfLine(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new EndOfLine(document);
        }

        /// <summary>
        /// Creates an <see cref="ElementHeaderLine" />.
        /// </summary>
        /// <param name="document">The document which the header line will be added to.</param>
        /// <param name="text">The header line text.</param>
        /// <returns>Returns the header line.</returns>
        public static ElementHeaderLine CreateElementHeaderLine(this CsDocument document, string text)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(text, "text");

            if (!text.StartsWith("///"))
            {
                throw new ArgumentException(Strings.ElementHeaderLineMustBeginWithTripleSlash, "text");
            }

            if (text.StartsWith("////"))
            {
                throw new ArgumentException(Strings.ElementHeaderLineMustNotBeginWithQuadrupleSlash, "text");
            }

            if (text.Contains("\n"))
            {
                throw new ArgumentException(Strings.ElementHeaderLineMustNotContainNewline, "text");
            }

            if (text.EndsWith(" ") || text.EndsWith("	"))
            {
                bool containsText = false;
                for (int i = 4; i < text.Length; ++i)
                {
                    if (!char.IsWhiteSpace(text[i]))
                    {
                        containsText = true;
                        break;
                    }
                }

                if (containsText)
                {
                    throw new ArgumentException(Strings.ElementHeaderLineMustNotContainsTrailingWhitespace, "text");
                }
            }

            return new ElementHeaderLine(document, text);
        }

        /// <summary>
        /// Creates a <see cref="SingleLineComment" />.
        /// </summary>
        /// <param name="document">The document which the comment will be added to.</param>
        /// <param name="text">The comment text.</param>
        /// <returns>Returns the comment.</returns>
        public static SingleLineComment CreateSingleLineComment(this CsDocument document, string text)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(text, "text");

            if (!text.StartsWith("//"))
            {
                throw new ArgumentException(Strings.SingleLineCommentMustBeginWithDoubleSlash, "text");
            }

            if (text.StartsWith("///") && !text.StartsWith("////"))
            {
                throw new ArgumentException(Strings.TripleSlashIsReservedForDocumentHeaders, "text");
            }

            if (text.Contains("\n"))
            {
                throw new ArgumentException(Strings.SingleLineCommentMustNotContainNewline, "text");
            }

            if (text.EndsWith(" ") || text.EndsWith("	"))
            {
                bool containsText = false;
                for (int i = 3; i < text.Length; ++i)
                {
                    if (!char.IsWhiteSpace(text[i]))
                    {
                        containsText = true;
                        break;
                    }
                }

                if (containsText)
                {
                    throw new ArgumentException(Strings.SingleLineCommentMustNotContainsTrailingWhitespace, "text");
                }
            }

            return new SingleLineComment(document, text);
        }

        /// <summary>
        /// Creates a n <see cref="MultilineComment" />.
        /// </summary>
        /// <param name="document">The document which the comment will be added to.</param>
        /// <param name="text">The comment text.</param>
        /// <returns>Returns the comment.</returns>
        public static MultilineComment CreateMultilineComment(this CsDocument document, string text)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(text, "text");

            if (!text.StartsWith("/*") || !text.EndsWith("*/"))
            {
                throw new ArgumentException(Strings.MultilineCommentMustBeginAndEndWithCommentSyntax, "text");
            }

            bool foundNonWhitespace = false;
            for (int i = 2; i < text.Length - 2; ++i)
            {
                if (!char.IsWhiteSpace(text[i]))
                {
                    foundNonWhitespace = true;
                    break;
                }
            }

            if (!foundNonWhitespace)
            {
                throw new ArgumentException(Strings.MultilineCommentMustContainText, "text");
            }

            return new MultilineComment(document, text);
        }

        #endregion LexicalElements

        #region Tokens

        /// <summary>
        /// Creates an <see cref="AbstractToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static AbstractToken CreateAbstractToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AbstractToken(document);
        }

        /// <summary>
        /// Creates an <see cref="AddToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static AddToken CreateAddToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AddToken(document);
        }

        /// <summary>
        /// Creates an <see cref="AliasToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static AliasToken CreateAliasToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AliasToken(document);
        }

        /// <summary>
        /// Creates an <see cref="AscendingToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static AscendingToken CreateAscendingToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AscendingToken(document);
        }

        /// <summary>
        /// Creates an <see cref="AsToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static AsToken CreateAsToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AsToken(document);
        }

        /// <summary>
        /// Creates an <see cref="AttributeColonToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static AttributeColonToken CreateAttributeColonToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AttributeColonToken(document);
        }

        /// <summary>
        /// Creates a <see cref="BaseColonToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static BaseColonToken CreateBaseColonToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new BaseColonToken(document);
        }

        /// <summary>
        /// Creates a <see cref="BaseToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static BaseToken CreateBaseToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new BaseToken(document);
        }

        /// <summary>
        /// Creates a <see cref="BreakToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static BreakToken CreateBreakToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new BreakToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ByToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ByToken CreateByToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ByToken(document);
        }

        /// <summary>
        /// Creates a <see cref="CaseToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static CaseToken CreateCaseToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new CaseToken(document);
        }

        /// <summary>
        /// Creates a <see cref="CatchToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static CatchToken CreateCatchToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new CatchToken(document);
        }

        /// <summary>
        /// Creates a <see cref="CheckedToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static CheckedToken CreateCheckedToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new CheckedToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ClassToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ClassToken CreateClassToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ClassToken(document);
        }

        /// <summary>
        /// Creates a <see cref="CloseAttributeBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching opening attribute bracket.</param>
        /// <returns>Returns the token.</returns>
        public static CloseAttributeBracketToken CreateCloseAttributeBracketToken(this CsDocument document, OpenAttributeBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new CloseAttributeBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates a <see cref="CloseCurlyBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching opening curly bracket.</param>
        /// <returns>Returns the token.</returns>
        public static CloseCurlyBracketToken CreateCloseCurlyBracketToken(this CsDocument document, OpenCurlyBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new CloseCurlyBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates a <see cref="CloseGenericBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching opening generic bracket.</param>
        /// <returns>Returns the token.</returns>
        public static CloseGenericBracketToken CreateCloseGenericBracketToken(this CsDocument document, OpenGenericBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new CloseGenericBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates a <see cref="CloseParenthesisToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingParenthesis">Optionally sets the matching opening parenthesis.</param>
        /// <returns>Returns the token.</returns>
        public static CloseParenthesisToken CreateCloseParenthesisToken(this CsDocument document, OpenParenthesisToken matchingParenthesis = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingParenthesis);

            var bracket = new CloseParenthesisToken(document);

            if (matchingParenthesis != null)
            {
                ValidateDocument(document, matchingParenthesis, "matchingBracket");
                bracket.MatchingBracket = matchingParenthesis;
            }

            return bracket;
        }

        /// <summary>
        /// Creates a <see cref="CloseSquareBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching opening square bracket.</param>
        /// <returns>Returns the token.</returns>
        public static CloseSquareBracketToken CreateCloseSquareBracketToken(this CsDocument document, OpenSquareBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new CloseSquareBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates a <see cref="CommaToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static CommaToken CreateCommaToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new CommaToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ConstructorConstraintToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ConstructorConstraintToken CreateConstructorConstraintToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a <see cref="ConstToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ConstToken CreateConstToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ConstToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ContinueToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ContinueToken CreateContinueToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ContinueToken(document);
        }

        /// <summary>
        /// Creates a <see cref="DefaultToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static DefaultToken CreateDefaultToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DefaultToken(document);
        }

        /// <summary>
        /// Creates a <see cref="DefaultValueToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static DefaultValueToken CreateDefaultValueToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DefaultValueToken(document);
        }

        /// <summary>
        /// Creates a <see cref="DelegateToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static DelegateToken CreateDelegateToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DelegateToken(document);
        }

        /// <summary>
        /// Creates a <see cref="DescendingToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static DescendingToken CreateDescendingToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DescendingToken(document);
        }

        /// <summary>
        /// Creates a <see cref="DestructorTildeToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static DestructorTildeToken CreateDestructorTildeToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DestructorTildeToken(document);
        }

        /// <summary>
        /// Creates a <see cref="DoToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static DoToken CreateDoToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DoToken(document);
        }

        /// <summary>
        /// Creates an <see cref="ElseToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ElseToken CreateElseToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ElseToken(document);
        }

        /// <summary>
        /// Creates an <see cref="EnumToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static EnumToken CreateEnumToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new EnumToken(document);
        }

        /// <summary>
        /// Creates an <see cref="EqualsToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static EqualsToken CreateEqualsToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new EqualsToken(document);
        }

        /// <summary>
        /// Creates an <see cref="EventToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static EventToken CreateEventToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new EventToken(document);
        }

        /// <summary>
        /// Creates an <see cref="ExplicitToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ExplicitToken CreateExplicitToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ExplicitToken(document);
        }

        /// <summary>
        /// Creates an <see cref="ExternDirectiveToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ExternDirectiveToken CreateExternDirectiveToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ExternDirectiveToken(document);
        }

        /// <summary>
        /// Creates an <see cref="ExternToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ExternToken CreateExternToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ExternToken(document);
        }

        /// <summary>
        /// Creates a <see cref="FalseToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static FalseToken CreateFalseToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new FalseToken(document);
        }

        /// <summary>
        /// Creates a <see cref="FinallyToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static FinallyToken CreateFinallyToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new FinallyToken(document);
        }

        /// <summary>
        /// Creates a <see cref="FixedToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static FixedToken CreateFixedToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new FixedToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ForeachToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ForeachToken CreateForeachToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ForeachToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ForToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ForToken CreateForToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ForToken(document);
        }

        /// <summary>
        /// Creates a <see cref="FromToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static FromToken CreateFromToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new FromToken(document);
        }

        /// <summary>
        /// Creates a <see cref="GenericTypeToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="name">The generic type name.</param>
        /// <param name="parameter">The single type parameter.</param>
        /// <returns>Returns the token.</returns>
        public static GenericTypeToken CreateGenericTypeToken(this CsDocument document, LiteralToken name, GenericTypeParameter parameter)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(name, "name");
            Param.RequireNotNull(parameter, "parameter");

            return document.CreateGenericTypeToken(name, new[] { parameter });
        }

        /// <summary>
        /// Creates a <see cref="GenericTypeToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="name">The generic type name.</param>
        /// <param name="parameters">The generic type parameters.</param>
        /// <returns>Returns the token.</returns>
        public static GenericTypeToken CreateGenericTypeToken(this CsDocument document, LiteralToken name, ICollection<GenericTypeParameter> parameters)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(name, "name");
            Param.RequireValidCollection(parameters, "parameters");

            CodeUnitProxy proxy = new CodeUnitProxy(document);

            Add(proxy, name);
            Add(proxy, document.CreateOpenGenericBracketToken());
            Add(proxy, document.CreateGenericTypeParameterList(parameters));
            Add(proxy, document.CreateCloseGenericBracketToken());

            return new GenericTypeToken(proxy);
        }

        /// <summary>
        /// Creates a <see cref="GetToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static GetToken CreateGetToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new GetToken(document);
        }

        /// <summary>
        /// Creates a <see cref="GotoToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static GotoToken CreateGotoToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new GotoToken(document);
        }

        /// <summary>
        /// Creates a <see cref="GroupToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static GroupToken CreateGroupToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new GroupToken(document);
        }

        /// <summary>
        /// Creates an <see cref="IfToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static IfToken CreateIfToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new IfToken(document);
        }

        /// <summary>
        /// Creates an <see cref="ImplicitToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ImplicitToken CreateImplicitToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ImplicitToken(document);
        }

        /// <summary>
        /// Creates an <see cref="InterfaceToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static InterfaceToken CreateInterfaceToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new InterfaceToken(document);
        }

        /// <summary>
        /// Creates an <see cref="InternalToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static InternalToken CreateInternalToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new InternalToken(document);
        }

        /// <summary>
        /// Creates an <see cref="InToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static InToken CreateInToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new InToken(document);
        }

        /// <summary>
        /// Creates an <see cref="IntoToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static IntoToken CreateIntoToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new IntoToken(document);
        }

        /// <summary>
        /// Creates an <see cref="IsToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static IsToken CreateIsToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new IsToken(document);
        }

        /// <summary>
        /// Creates a <see cref="JoinToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static JoinToken CreateJoinToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new JoinToken(document);
        }

        /// <summary>
        /// Creates a <see cref="LabelColonToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static LabelColonToken CreateLabelColonToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LabelColonToken(document);
        }

        /// <summary>
        /// Creates a <see cref="LetToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static LetToken CreateLetToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LetToken(document);
        }

        /// <summary>
        /// Creates a <see cref="LiteralToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="text">The text within the token.</param>
        /// <returns>Returns the token.</returns>
        public static LiteralToken CreateLiteralToken(this CsDocument document, string text)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(text, "text");

            return new LiteralToken(document, text);
        }

        /// <summary>
        /// Creates a <see cref="LockToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static LockToken CreateLockToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LockToken(document);
        }

        /// <summary>
        /// Creates a <see cref="NamespaceToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static NamespaceToken CreateNamespaceToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NamespaceToken(document);
        }

        /// <summary>
        /// Creates a <see cref="NewToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static NewToken CreateNewToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NewToken(document);
        }

        /// <summary>
        /// Creates a <see cref="NullableTypeToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static NullableTypeToken CreateNullableTypeToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NullableTypeToken(document);
        }

        /// <summary>
        /// Creates a <see cref="NullToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static NullToken CreateNullToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NullToken(document);
        }

        /// <summary>
        /// Creates a <see cref="NumberToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="number">The number.</param>
        /// <returns>Returns the token.</returns>
        public static NumberToken CreateNumberToken(this CsDocument document, int number)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(number, "number");

            return new NumberToken(document, number.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Creates a <see cref="NumberToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="number">The number.</param>
        /// <returns>Returns the token.</returns>
        public static NumberToken CreateNumberToken(this CsDocument document, short number)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(number, "number");

            return new NumberToken(document, number.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Creates a <see cref="NumberToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="number">The number.</param>
        /// <returns>Returns the token.</returns>
        public static NumberToken CreateNumberToken(this CsDocument document, long number)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(number, "number");

            return new NumberToken(document, number.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Creates a <see cref="NumberToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="number">The number.</param>
        /// <returns>Returns the token.</returns>
        public static NumberToken CreateNumberToken(this CsDocument document, string number)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(number, "number");

            return new NumberToken(document, number);
        }

        /// <summary>
        /// Creates an <see cref="OnToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static OnToken CreateOnToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new OnToken(document);
        }

        /// <summary>
        /// Creates an <see cref="OpenAttributeBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching closing attribute bracket.</param>
        /// <returns>Returns the token.</returns>
        public static OpenAttributeBracketToken CreateOpenAttributeBracketToken(this CsDocument document, CloseAttributeBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new OpenAttributeBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates an <see cref="OpenCurlyBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching closing curly bracket.</param>
        /// <returns>Returns the token.</returns>
        public static OpenCurlyBracketToken CreateOpenCurlyBracketToken(this CsDocument document, CloseCurlyBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new OpenCurlyBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates an <see cref="OpenGenericBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching closing generic bracket.</param>
        /// <returns>Returns the token.</returns>
        public static OpenGenericBracketToken CreateOpenGenericBracketToken(this CsDocument document, CloseGenericBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new OpenGenericBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates an <see cref="OpenParenthesisToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingParenthesis">Optionally sets the matching closing parenthesis.</param>
        /// <returns>Returns the token.</returns>
        public static OpenParenthesisToken CreateOpenParenthesisToken(this CsDocument document, CloseParenthesisToken matchingParenthesis = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingParenthesis);

            var bracket = new OpenParenthesisToken(document);

            if (matchingParenthesis != null)
            {
                ValidateDocument(document, matchingParenthesis, "matchingBracket");
                bracket.MatchingBracket = matchingParenthesis;
            }

            return bracket;
        }

        /// <summary>
        /// Creates an <see cref="OpenSquareBracketToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="matchingBracket">Optionally sets the matching closing square bracket.</param>
        /// <returns>Returns the token.</returns>
        public static OpenSquareBracketToken CreateOpenSquareBracketToken(this CsDocument document, CloseSquareBracketToken matchingBracket = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(matchingBracket);

            var bracket = new OpenSquareBracketToken(document);

            if (matchingBracket != null)
            {
                ValidateDocument(document, matchingBracket, "matchingBracket");
                bracket.MatchingBracket = matchingBracket;
            }

            return bracket;
        }

        /// <summary>
        /// Creates an <see cref="OperatorToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static OperatorToken CreateOperatorToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new OperatorToken(document);
        }

        /// <summary>
        /// Creates an <see cref="OrderByToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static OrderByToken CreateOrderByToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new OrderByToken(document);
        }

        /// <summary>
        /// Creates an <see cref="OutToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static OutToken CreateOutToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new OutToken(document);
        }

        /// <summary>
        /// Creates an <see cref="OverrideToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static OverrideToken CreateOverrideToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new OverrideToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ParamsToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ParamsToken CreateParamsToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ParamsToken(document);
        }

        /// <summary>
        /// Creates a <see cref="PartialToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static PartialToken CreatePartialToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new PartialToken(document);
        }

        /// <summary>
        /// Creates a <see cref="PrivateToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static PrivateToken CreatePrivateToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new PrivateToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ProtectedToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ProtectedToken CreateProtectedToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ProtectedToken(document);
        }

        /// <summary>
        /// Creates a <see cref="PublicToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static PublicToken CreatePublicToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new PublicToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ReadonlyToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ReadonlyToken CreateReadonlyToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ReadonlyToken(document);
        }

        /// <summary>
        /// Creates a <see cref="RefToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static RefToken CreateRefToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new RefToken(document);
        }

        /// <summary>
        /// Creates a <see cref="RemoveToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static RemoveToken CreateRemoveToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new RemoveToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ReturnToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ReturnToken CreateReturnToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ReturnToken(document);
        }

        /// <summary>
        /// Creates a <see cref="SealedToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static SealedToken CreateSealedToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new SealedToken(document);
        }

        /// <summary>
        /// Creates a <see cref="SelectToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static SelectToken CreateSelectToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new SelectToken(document);
        }

        /// <summary>
        /// Creates a <see cref="SemicolonToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static SemicolonToken CreateSemicolonToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new SemicolonToken(document);
        }

        /// <summary>
        /// Creates a <see cref="SetToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static SetToken CreateSetToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new SetToken(document);
        }

        /// <summary>
        /// Creates a <see cref="SizeofToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static SizeofToken CreateSizeofToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new SizeofToken(document);
        }

        /// <summary>
        /// Creates a <see cref="StackallocToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static StackallocToken CreateStackallocToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new StackallocToken(document);
        }

        /// <summary>
        /// Creates a <see cref="StaticToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static StaticToken CreateStaticToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new StaticToken(document);
        }

        /// <summary>
        /// Creates a <see cref="StringToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="text">The string text.</param>
        /// <returns>Returns the token.</returns>
        public static StringToken CreateStringToken(this CsDocument document, string text)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(text, "text");

            if ((!text.StartsWith("\"") && !text.StartsWith("@\"") && !text.StartsWith("'")) ||
                (text.StartsWith("\"") && (text.Length < 2 || !text.EndsWith("\""))) ||
                (text.StartsWith("@\"") && (text.Length < 3 || !text.EndsWith("\""))) ||
                (text.StartsWith("'") && (text.Length < 2 || !text.EndsWith("'"))))
            {
                throw new ArgumentException(Strings.ValueMustBeAString, "text");
            }

            return new StringToken(document, text);
        }

        /// <summary>
        /// Creates a <see cref="StructToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static StructToken CreateStructToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new StructToken(document);
        }

        /// <summary>
        /// Creates a <see cref="SwitchToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static SwitchToken CreateSwitchToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new SwitchToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ThisToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ThisToken CreateThisToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ThisToken(document);
        }

        /// <summary>
        /// Creates a <see cref="ThrowToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static ThrowToken CreateThrowToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ThrowToken(document);
        }

        /// <summary>
        /// Creates a <see cref="TrueToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static TrueToken CreateTrueToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new TrueToken(document);
        }

        /// <summary>
        /// Creates a <see cref="TryToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static TryToken CreateTryToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new TryToken(document);
        }

        /// <summary>
        /// Creates a <see cref="TypeofToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static TypeofToken CreateTypeofToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new TypeofToken(document);
        }

        /// <summary>
        /// Creates a <see cref="TypeToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="childItem">The child item that forms the type.</param>
        /// <returns>Returns the token.</returns>
        public static TypeToken CreateTypeToken(this CsDocument document, LexicalElement childItem)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(childItem, "childItem");

            return document.CreateTypeToken(new[] { childItem });
        }

        /// <summary>
        /// Creates a <see cref="TypeToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <param name="childItems">The collection of child items that form the type.</param>
        /// <returns>Returns the token.</returns>
        public static TypeToken CreateTypeToken(this CsDocument document, ICollection<LexicalElement> childItems)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidCollection(childItems, "childItems");

            CodeUnitProxy proxy = new CodeUnitProxy(document);

            foreach (LexicalElement item in childItems)
            {
                Add(proxy, item);
            }

            return new TypeToken(proxy);
        }

        /// <summary>
        /// Creates an <see cref="UncheckedToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static UncheckedToken CreateUncheckedToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new UncheckedToken(document);
        }

        /// <summary>
        /// Creates an <see cref="UnsafeToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static UnsafeToken CreateUnsafeToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new UnsafeToken(document);
        }

        /// <summary>
        /// Creates a <see cref="UsingDirectiveToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static UsingDirectiveToken CreateUsingDirectiveToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new UsingDirectiveToken(document);
        }

        /// <summary>
        /// Creates a <see cref="UsingToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static UsingToken CreateUsingToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new UsingToken(document);
        }

        /// <summary>
        /// Creates a <see cref="VirtualToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static VirtualToken CreateVirtualToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new VirtualToken(document);
        }

        /// <summary>
        /// Creates a <see cref="VolatileToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static VolatileToken CreateVolatileToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new VolatileToken(document);
        }

        /// <summary>
        /// Creates a <see cref="WhereColonToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static WhereColonToken CreateWhereColonToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new WhereColonToken(document);
        }

        /// <summary>
        /// Creates a <see cref="WhereToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static WhereToken CreateWhereToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new WhereToken(document);
        }

        /// <summary>
        /// Creates a <see cref="WhileDoToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static WhileDoToken CreateWhileDoToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new WhileDoToken(document);
        }

        /// <summary>
        /// Creates a <see cref="WhileToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static WhileToken CreateWhileToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new WhileToken(document);
        }

        /// <summary>
        /// Creates a <see cref="YieldToken" />.
        /// </summary>
        /// <param name="document">The document which the token will be added to.</param>
        /// <returns>Returns the token.</returns>
        public static YieldToken CreateYieldToken(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new YieldToken(document);
        }

        #endregion Tokens

        #region Operators

        /// <summary>
        /// Creates an <see cref="AddressOfOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static AddressOfOperator CreateAddressOfOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AddressOfOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="AndEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static AndEqualsOperator CreateAndEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new AndEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="BitwiseComplementOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static BitwiseComplementOperator CreateBitwiseComplementOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new BitwiseComplementOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="ConditionalAndOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static ConditionalAndOperator CreateConditionalAndOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ConditionalAndOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="ConditionalColonOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static ConditionalColonOperator CreateConditionalColonOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ConditionalColonOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="ConditionalEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static ConditionalEqualsOperator CreateConditionalEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ConditionalEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="ConditionalOrOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static ConditionalOrOperator CreateConditionalOrOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ConditionalOrOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="ConditionalQuestionMarkOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static ConditionalQuestionMarkOperator CreateConditionalQuestionMarkOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ConditionalQuestionMarkOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="DecrementOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static DecrementOperator CreateDecrementOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DecrementOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="DereferenceOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static DereferenceOperator CreateDereferenceOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DereferenceOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="DivisionEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static DivisionEqualsOperator CreateDivisionEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DivisionEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="DivisionOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static DivisionOperator CreateDivisionOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new DivisionOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="EqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static EqualsOperator CreateEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new EqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="GreaterThanOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static GreaterThanOperator CreateGreaterThanOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new GreaterThanOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="GreaterThanOrEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static GreaterThanOrEqualsOperator CreateGreaterThanOrEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new GreaterThanOrEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="IncrementOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static IncrementOperator CreateIncrementOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new IncrementOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LambdaOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LambdaOperator CreateLambdaOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LambdaOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LeftShiftEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LeftShiftEqualsOperator CreateLeftShiftEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LeftShiftEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LeftShiftOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LeftShiftOperator CreateLeftShiftOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LeftShiftOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LessThanOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LessThanOperator CreateLessThanOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LessThanOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LessThanOrEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LessThanOrEqualsOperator CreateLessThanOrEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LessThanOrEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LogicalAndOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LogicalAndOperator CreateLogicalAndOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LogicalAndOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LogicalOrOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LogicalOrOperator CreateLogicalOrOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LogicalOrOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="LogicalXorOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static LogicalXorOperator CreateLogicalXorOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new LogicalXorOperator(document);
        }

        /// <summary>
        /// Creates a <see cref="MemberAccessOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator will be added to.</param>
        /// <returns>Returns the operator.</returns>
        public static MemberAccessOperator CreateMemberAccessOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new MemberAccessOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="MinusEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static MinusEqualsOperator CreateMinusEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new MinusEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="MinusOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static MinusOperator CreateMinusOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new MinusOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="ModEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static ModEqualsOperator CreateModEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ModEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="ModOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static ModOperator CreateModOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new ModOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="MultiplicationEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static MultiplicationEqualsOperator CreateMultiplicationEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new MultiplicationEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="MultiplicationOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static MultiplicationOperator CreateMultiplicationOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new MultiplicationOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="NegativeOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static NegativeOperator CreateNegativeOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NegativeOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="NotEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static NotEqualsOperator CreateNotEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NotEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="NotOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static NotOperator CreateNotOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NotOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="NullCoalescingSymbolOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static NullCoalescingSymbolOperator CreateNullCoalescingSymbolOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new NullCoalescingSymbolOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="OrEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static OrEqualsOperator CreateOrEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new OrEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="PlusEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static PlusEqualsOperator CreatePlusEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new PlusEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="PlusOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static PlusOperator CreatePlusOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new PlusOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="PointerOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static PointerOperator CreatePointerOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new PointerOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="PositiveOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static PositiveOperator CreatePositiveOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new PositiveOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="QualifiedAliasOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static QualifiedAliasOperator CreateQualifiedAliasOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new QualifiedAliasOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="RightShiftEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static RightShiftEqualsOperator CreateRightShiftEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new RightShiftEqualsOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="RightShiftOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static RightShiftOperator CreateRightShiftOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new RightShiftOperator(document);
        }

        /// <summary>
        /// Creates an <see cref="XorEqualsOperator" />.
        /// </summary>
        /// <param name="document">The document which the operator token will be added to.</param>
        /// <returns>Returns the operator token.</returns>
        public static XorEqualsOperator CreateXorEqualsOperator(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");
            return new XorEqualsOperator(document);
        }

        #endregion Operators

        #region Expressions

        /// <summary>
        /// Creates an <see cref="AdditionExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static AdditionExpression CreateAdditionExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreatePlusOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new AdditionExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="AddressOfExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        /// <returns>Returns the expression.</returns>
        public static AddressOfExpression CreateAddressOfExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateAddressOfOperator());
            Add(expressionProxy, value);

            return new AddressOfExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="AndEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static AndEqualsExpression CreateAndEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateAndEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new AndEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates an <see cref="AnonymousMethodExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="body">The body of the anonymous method.</param>
        /// <returns>Returns the expression.</returns>
        //// todo: add unit tests.
        public static AnonymousMethodExpression CreateAnonymousMethodExpression(this CsDocument document, BlockStatement body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(body, "body");

            return document.CreateAnonymousMethodExpression(null, body);
        }

        /// <summary>
        /// Creates an <see cref="AnonymousMethodExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="argumentList">The method argument list.</param>
        /// <param name="body">The body of the anonymous method.</param>
        /// <returns>Returns the expression.</returns>
        //// todo: add unit tests.
        public static AnonymousMethodExpression CreateAnonymousMethodExpression(this CsDocument document, ArgumentList argumentList, BlockStatement body)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(argumentList);
            Param.RequireNotNull(body, "body");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);

            Add(expressionProxy, document.CreateDelegateToken());

            if (argumentList != null && argumentList.Count > 0)
            {
                ValidateDocument(document, argumentList, "argumentList");
                Add(expressionProxy, argumentList);
            }

            ValidateDocument(document, body, "body");
            Add(expressionProxy, body);

            return new AnonymousMethodExpression(expressionProxy);
        }

        /// <summary>
        /// Creates a <see cref="ArrayAccessExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static ArrayAccessExpression CreateArrayAccessExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="ArrayInitializerExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static ArrayInitializerExpression CreateArrayInitializerExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="AsExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type of the conversion.</param>
        /// <returns>Returns the expression.</returns>
        public static AsExpression CreateAsExpression(this CsDocument document, Expression value, LiteralExpression type)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");
            Param.RequireNotNull(type, "type");

            ValidateDocument(document, value, "value");
            ValidateDocument(document, type, "type");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, value);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateAsToken());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, type);

            return new AsExpression(expressionProxy, value, type);
        }

        /// <summary>
        /// Creates a <see cref="AttributeExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static AttributeExpression CreateAttributeExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="BitwiseComplementExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        /// <returns>Returns the expression.</returns>
        public static BitwiseComplementExpression CreateBitwiseComplementExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateBitwiseComplementOperator());
            Add(expressionProxy, value);

            return new BitwiseComplementExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="CastExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The cast type.</param>
        /// <param name="castedExpression">The expression being casted.</param>
        /// <returns>Returns the expression.</returns>
        public static CastExpression CreateCastExpression(this CsDocument document, LiteralExpression type, Expression castedExpression)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(type, "type");
            Param.RequireNotNull(castedExpression, "castedExpression");

            ValidateDocument(document, type, "type");
            ValidateDocument(document, castedExpression, "castedExpression");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateOpenParenthesisToken());
            Add(expressionProxy, type);
            Add(expressionProxy, document.CreateCloseParenthesisToken());
            Add(expressionProxy, castedExpression);

            return new CastExpression(expressionProxy, type, castedExpression);
        }

        /// <summary>
        /// Creates a <see cref="CheckedExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="internalExpression">The expression wrapped within the checked expression.</param>
        /// <returns>Returns the expression.</returns>
        public static CheckedExpression CreateCheckedExpression(this CsDocument document, Expression internalExpression)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(internalExpression, "internalExpression");

            ValidateDocument(document, internalExpression, "internalExpression");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateCheckedToken());
            Add(expressionProxy, document.CreateOpenParenthesisToken());
            Add(expressionProxy, internalExpression);
            Add(expressionProxy, document.CreateCloseParenthesisToken());

            return new CheckedExpression(expressionProxy, internalExpression);
        }

        /// <summary>
        /// Creates a <see cref="CollectionInitializerExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static CollectionInitializerExpression CreateCollectionInitializerExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="ConditionalExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="condition">The condition being evaluated.</param>
        /// <param name="trueValue">The expression that is evaluated if the condition is true.</param>
        /// <param name="falseValue">The expression that is evaluated if the condition is false.</param>
        /// <returns>Returns the expression.</returns>
        public static ConditionalExpression CreateConditionalExpression(
            this CsDocument document, Expression condition, Expression trueValue, Expression falseValue)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(condition, "condition");
            Param.RequireNotNull(trueValue, "trueValue");
            Param.RequireNotNull(falseValue, "falseValue");

            ValidateDocument(document, condition, "condition");
            ValidateDocument(document, trueValue, "trueValue");
            ValidateDocument(document, falseValue, "falseValue");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, condition);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateConditionalQuestionMarkOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, trueValue);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateConditionalColonOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, falseValue);

            return new ConditionalExpression(expressionProxy, condition, trueValue, falseValue);
        }

        /// <summary>
        /// Creates a <see cref="ConditionalAndExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static ConditionalAndExpression CreateConditionalAndExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateConditionalAndOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new ConditionalAndExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="ConditionalOrExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static ConditionalOrExpression CreateConditionalOrExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateConditionalOrOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new ConditionalOrExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a prefix <see cref="PrefixDecrementExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value being decremented.</param>
        /// <returns>Returns the expression.</returns>
        public static PrefixDecrementExpression CreatePrefixDecrementExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateDecrementOperator());
            Add(expressionProxy, value);

            return new PrefixDecrementExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a postfix <see cref="PostfixDecrementExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value being decremented.</param>
        /// <returns>Returns the expression.</returns>
        public static PostfixDecrementExpression CreatePostfixDecrementExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, value);
            Add(expressionProxy, document.CreateDecrementOperator());

            return new PostfixDecrementExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="DefaultValueExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The item to get the type of.</param>
        /// <returns>Returns the expression.</returns>
        public static DefaultValueExpression CreateDefaultValueExpression(this CsDocument document, LiteralExpression type)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(type, "type");

            ValidateDocument(document, type, "type");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateDefaultValueToken());
            Add(expressionProxy, document.CreateOpenParenthesisToken());
            Add(expressionProxy, type);
            Add(expressionProxy, document.CreateCloseParenthesisToken());

            return new DefaultValueExpression(expressionProxy, type);
        }

        /// <summary>
        /// Creates a <see cref="DereferenceExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        /// <returns>Returns the expression.</returns>
        public static DereferenceExpression CreateDereferenceExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateDereferenceOperator());
            Add(expressionProxy, value);

            return new DereferenceExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="DivisionExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static DivisionExpression CreateDivisionExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateDivisionOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new DivisionExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="DivisionEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static DivisionEqualsExpression CreateDivisionEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateDivisionEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new DivisionEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="EqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static EqualsExpression CreateEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new EqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="EqualToExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static EqualToExpression CreateEqualToExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new EqualToExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="EventDeclaratorExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static EventDeclaratorExpression CreateEventDeclaratorExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="GreaterThanExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static GreaterThanExpression CreateGreaterThanExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateGreaterThanOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new GreaterThanExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="GreaterThanOrEqualToExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static GreaterThanOrEqualToExpression CreateGreaterThanOrEqualToExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateGreaterThanOrEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new GreaterThanOrEqualToExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a prefix <see cref="PrefixIncrementExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value being incremented.</param>
        /// <returns>Returns the expression.</returns>
        public static PrefixIncrementExpression CreatePrefixIncrementExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateIncrementOperator());
            Add(expressionProxy, value);

            return new PrefixIncrementExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a postfix <see cref="PostfixIncrementExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value being incremented.</param>
        /// <returns>Returns the expression.</returns>
        public static PostfixIncrementExpression CreatePostfixIncrementExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, value);
            Add(expressionProxy, document.CreateIncrementOperator());

            return new PostfixIncrementExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="IsExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type of the conversion.</param>
        /// <returns>Returns the expression.</returns>
        public static IsExpression CreateIsExpression(this CsDocument document, Expression value, LiteralExpression type)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");
            Param.RequireNotNull(type, "type");

            ValidateDocument(document, value, "value");
            ValidateDocument(document, type, "type");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, value);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateIsToken());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, type);

            return new IsExpression(expressionProxy, value, type);
        }

        /// <summary>
        /// Creates a <see cref="LambdaExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static LambdaExpression CreateLambdaExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="LeftShiftExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static LeftShiftExpression CreateLeftShiftExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateLeftShiftOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new LeftShiftExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="LeftShiftEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static LeftShiftEqualsExpression CreateLeftShiftEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateLeftShiftEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new LeftShiftEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="LessThanExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static LessThanExpression CreateLessThanExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateLessThanOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new LessThanExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="LessThanOrEqualToExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static LessThanOrEqualToExpression CreateLessThanOrEqualToExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateLessThanOrEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new LessThanOrEqualToExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="LiteralExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="literalToken">The token that will be contained within the expression.</param>
        /// <returns>Returns the expression.</returns>
        public static LiteralExpression CreateLiteralExpression(this CsDocument document, Token literalToken)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(literalToken, "literalToken");

            ValidateDocument(document, literalToken, "literalToken");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, literalToken);

            return new LiteralExpression(expressionProxy, literalToken);
        }

        /// <summary>
        /// Creates a <see cref="LiteralExpression" /> containing a literal type.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="literalType">The literal type text contained within the expression.</param>
        /// <returns>Returns the expression.</returns>
        public static LiteralExpression CreateLiteralTypeExpression(this CsDocument document, string literalType)
        {
            // todo add unit tests
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(literalType, "literalType");

            var literalToken = document.CreateTypeToken(document.CreateLiteralToken(literalType));
            return document.CreateLiteralExpression(literalToken);
        }

        /// <summary>
        /// Creates a <see cref="LiteralExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="literal">The literal text contained within the expression.</param>
        /// <returns>Returns the expression.</returns>
        public static LiteralExpression CreateLiteralExpression(this CsDocument document, string literal)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(literal, "literal");

            var literalToken = document.CreateLiteralToken(literal);

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, literalToken);

            return new LiteralExpression(expressionProxy, literalToken);
        }

        /// <summary>
        /// Creates a <see cref="LogicalAndExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static LogicalAndExpression CreateLogicalAndExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateLogicalAndOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new LogicalAndExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="LogicalOrExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static LogicalOrExpression CreateLogicalOrExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateLogicalOrOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new LogicalOrExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="LogicalXorExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static LogicalXorExpression CreateLogicalXorExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateLogicalXorOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new LogicalXorExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="MemberAccessExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operator.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operator.</param>
        /// <returns>Returns the expression.</returns>
        public static MemberAccessExpression CreateMemberAccessExpression(this CsDocument document, Expression leftHandSide, string rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireValidString(rightHandSide, "rightHandSide");

            return document.CreateMemberAccessExpression(leftHandSide, document.CreateLiteralExpression(rightHandSide));
        }

        /// <summary>
        /// Creates a <see cref="MemberAccessExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operator.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operator.</param>
        /// <returns>Returns the expression.</returns>
        public static MemberAccessExpression CreateMemberAccessExpression(this CsDocument document, Expression leftHandSide, LiteralExpression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);

            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateMemberAccessOperator());
            Add(expressionProxy, rightHandSide);

            return new MemberAccessExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="MethodInvocationExpression" /> with no arguments passed to the method.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="name">The name of the method.</param>
        /// <returns>Returns the expression.</returns>
        public static MethodInvocationExpression CreateMethodInvocationExpression(this CsDocument document, Expression name)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(name, "name");

            return document.CreateMethodInvocationExpression(name, (ArgumentList)null);
        }

        /// <summary>
        /// Creates a <see cref="MethodInvocationExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="arguments">The collection of arguments to pass to the method.</param>
        /// <returns>Returns the expression.</returns>
        public static MethodInvocationExpression CreateMethodInvocationExpression(this CsDocument document, Expression name, IEnumerable<Argument> arguments)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(name, "name");
            Param.Ignore(arguments);

            return document.CreateMethodInvocationExpression(name, document.CreateArgumentList(arguments));
        }

        /// <summary>
        /// Creates a <see cref="MethodInvocationExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="argumentList">The method argument list.</param>
        /// <returns>Returns the expression.</returns>
        public static MethodInvocationExpression CreateMethodInvocationExpression(this CsDocument document, Expression name, ArgumentList argumentList)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(name, "name");
            Param.Ignore(argumentList);

            ValidateDocument(document, name, "name");

            if (argumentList != null)
            {
                ValidateDocument(document, argumentList, "argumentList");
            }
            else
            {
                // Create an empty argument list.
                argumentList = document.CreateArgumentList();
            }

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, name);
            Add(expressionProxy, argumentList);

            return new MethodInvocationExpression(expressionProxy, name, argumentList);
        }

        /// <summary>
        /// Creates a <see cref="MinusEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static MinusEqualsExpression CreateMinusEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateMinusEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new MinusEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="ModExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static ModExpression CreateModExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateModOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new ModExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="ModEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static ModEqualsExpression CreateModEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateModEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new ModEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="MultiplicationExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static MultiplicationExpression CreateMultiplicationExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateMultiplicationOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new MultiplicationExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="MultiplicationEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static MultiplicationEqualsExpression CreateMultiplicationEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateMultiplicationEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new MultiplicationEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="NegativeExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        /// <returns>Returns the expression.</returns>
        public static NegativeExpression CreateNegativeExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateNegativeOperator());
            Add(expressionProxy, value);

            return new NegativeExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="NewArrayExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static NewArrayExpression CreateNewArrayExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="NewExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static NewExpression CreateNewExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="NotExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        /// <returns>Returns the expression.</returns>
        public static NotExpression CreateNotExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateNotOperator());
            Add(expressionProxy, value);

            return new NotExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="NotEqualToExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static NotEqualToExpression CreateNotEqualToExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateNotEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new NotEqualToExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="NullCoalescingExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static NullCoalescingExpression CreateNullCoalescingExpression(this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateNullCoalescingSymbolOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new NullCoalescingExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates an <see cref="ObjectInitializerExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="initializers">The list of variable initializers within the expression.</param>
        /// <returns>Returns the expression.</returns>
        public static ObjectInitializerExpression CreateObjectInitializerExpression(this CsDocument document, ICollection<EqualsExpression> initializers)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(initializers, "initializers");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);

            Add(expressionProxy, document.CreateOpenCurlyBracketToken());

            int count = 0;
            foreach (EqualsExpression initializer in initializers)
            {
                Param.RequireNotNull(initializer, "initializer");
                ValidateDocument(document, initializer, "initializer");

                if (initializer.LeftHandSide.ExpressionType != ExpressionType.Literal)
                {
                    throw new CodeModelException(document, Strings.ObjectInitializerAssignmentLeftHandSideMustBeLiteral);
                }

                if (count > 0)
                {
                    Add(expressionProxy, document.CreateCommaToken());
                }

                Add(expressionProxy, document.CreateSpace());
                Add(expressionProxy, initializer);

                ++count;
            }

            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateCloseCurlyBracketToken());

            return new ObjectInitializerExpression(expressionProxy, initializers);
        }

        /// <summary>
        /// Creates a <see cref="OrEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static OrEqualsExpression CreateOrEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateOrEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new OrEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="ParenthesizedExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="innerExpression">The expression within the parenthesis.</param>
        /// <returns>Returns the expression.</returns>
        public static ParenthesizedExpression CreateParenthesizedExpression(this CsDocument document, Expression innerExpression)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(innerExpression, "innerExpression");

            ValidateDocument(document, innerExpression, "innerExpression");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateOpenParenthesisToken());
            Add(expressionProxy, innerExpression);
            Add(expressionProxy, document.CreateCloseParenthesisToken());

            return new ParenthesizedExpression(expressionProxy, innerExpression);
        }

        /// <summary>
        /// Creates a <see cref="PlusEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static PlusEqualsExpression CreatePlusEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreatePlusEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new PlusEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="PointerAccessExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operator.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operator.</param>
        /// <returns>Returns the expression.</returns>
        public static PointerAccessExpression CreatePointerAccessExpression(this CsDocument document, Expression leftHandSide, string rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireValidString(rightHandSide, "rightHandSide");

            return document.CreatePointerAccessExpression(leftHandSide, document.CreateLiteralExpression(rightHandSide));
        }

        /// <summary>
        /// Creates a <see cref="PointerAccessExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operator.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operator.</param>
        /// <returns>Returns the expression.</returns>
        public static PointerAccessExpression CreatePointerAccessExpression(this CsDocument document, Expression leftHandSide, LiteralExpression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);

            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreatePointerOperator());
            Add(expressionProxy, rightHandSide);

            return new PointerAccessExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="PositiveExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        /// <returns>Returns the expression.</returns>
        public static PositiveExpression CreatePositiveExpression(this CsDocument document, Expression value)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(value, "value");

            ValidateDocument(document, value, "value");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreatePositiveOperator());
            Add(expressionProxy, value);

            return new PositiveExpression(expressionProxy, value);
        }

        /// <summary>
        /// Creates a <see cref="QualifiedAliasExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operator.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operator.</param>
        /// <returns>Returns the expression.</returns>
        public static QualifiedAliasExpression CreateQualifiedAliasExpression(this CsDocument document, Expression leftHandSide, string rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireValidString(rightHandSide, "rightHandSide");

            return document.CreateQualifiedAliasExpression(leftHandSide, document.CreateLiteralExpression(rightHandSide));
        }

        /// <summary>
        /// Creates a <see cref="QualifiedAliasExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operator.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operator.</param>
        /// <returns>Returns the expression.</returns>
        public static QualifiedAliasExpression CreateQualifiedAliasExpression(this CsDocument document, Expression leftHandSide, LiteralExpression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);

            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateQualifiedAliasOperator());
            Add(expressionProxy, rightHandSide);

            return new QualifiedAliasExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="QueryExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static QueryExpression CreateQueryExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="RightShiftExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static RightShiftExpression CreateRightShiftExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateRightShiftOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new RightShiftExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="RightShiftEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static RightShiftEqualsExpression CreateRightShiftEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateRightShiftEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new RightShiftEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="SizeofExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The type to get the size of.</param>
        /// <returns>Returns the expression.</returns>
        public static SizeofExpression CreateSizeofExpression(this CsDocument document, Expression type)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(type, "type");

            ValidateDocument(document, type, "type");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateSizeofToken());
            Add(expressionProxy, document.CreateOpenParenthesisToken());
            Add(expressionProxy, type);
            Add(expressionProxy, document.CreateCloseParenthesisToken());

            return new SizeofExpression(expressionProxy, type);
        }

        /// <summary>
        /// Creates a <see cref="StackallocExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <returns>Returns the expression.</returns>
        public static StackallocExpression CreateStackallocExpression(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            // todo;
            return null;
        }

        /// <summary>
        /// Creates a <see cref="SubtractionExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static SubtractionExpression CreateSubtractionExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateMinusOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new SubtractionExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        /// <summary>
        /// Creates a <see cref="TypeofExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The item to get the type of.</param>
        /// <returns>Returns the expression.</returns>
        public static TypeofExpression CreateTypeofExpression(this CsDocument document, LiteralExpression type)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(type, "type");

            ValidateDocument(document, type, "type");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateTypeofToken());
            Add(expressionProxy, document.CreateOpenParenthesisToken());
            Add(expressionProxy, type);
            Add(expressionProxy, document.CreateCloseParenthesisToken());

            return new TypeofExpression(expressionProxy, type);
        }

        /// <summary>
        /// Creates a <see cref="UncheckedExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="internalExpression">The expression wrapped within the unchecked expression.</param>
        /// <returns>Returns the expression.</returns>
        public static UncheckedExpression CreateUncheckedExpression(this CsDocument document, Expression internalExpression)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(internalExpression, "internalExpression");

            ValidateDocument(document, internalExpression, "internalExpression");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, document.CreateUncheckedToken());
            Add(expressionProxy, document.CreateOpenParenthesisToken());
            Add(expressionProxy, internalExpression);
            Add(expressionProxy, document.CreateCloseParenthesisToken());

            return new UncheckedExpression(expressionProxy, internalExpression);
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclarationExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        /// <param name="declarators">The collection of declarators within the variable declaration expression.</param>
        /// <returns>Returns the expression.</returns>
        public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, ICollection<VariableDeclaratorExpression> declarators)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(type, "type");
            Param.RequireValidCollection<VariableDeclaratorExpression>(declarators, "declarators");

            return document.CreateVariableDeclarationExpression(document.CreateLiteralTypeExpression(type), declarators);
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclarationExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        /// <param name="declarator">The declarator within the variable declaration expression.</param>
        /// <returns>Returns the expression.</returns>
        public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, VariableDeclaratorExpression declarator)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(type, "type");
            Param.RequireNotNull(declarator, "declarator");

            return document.CreateVariableDeclarationExpression(document.CreateLiteralTypeExpression(type), declarator);
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclarationExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        /// <param name="identifier">The variable identifier.</param>
        /// <returns>Returns the expression.</returns>
        public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, string type, string identifier)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(type, "type");
            Param.RequireValidString(identifier, "identifier");

            return document.CreateVariableDeclarationExpression(document.CreateLiteralTypeExpression(type), document.CreateVariableDeclaratorExpression(identifier));
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclarationExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        /// <param name="declarator">The declarator within the variable declaration expression.</param>
        /// <returns>Returns the expression.</returns>
        public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, VariableDeclaratorExpression declarator)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(type, "type");
            Param.RequireNotNull(declarator, "declarator");

            return document.CreateVariableDeclarationExpression(type, new VariableDeclaratorExpression[] { declarator });
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclarationExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        /// <param name="declarators">The collection of declarators within the variable declaration expression.</param>
        /// <returns>Returns the expression.</returns>
        public static VariableDeclarationExpression CreateVariableDeclarationExpression(this CsDocument document, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(type, "type");
            Param.RequireValidCollection<VariableDeclaratorExpression>(declarators, "declarators");

            ValidateDocument(document, type, "type");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, type);
            Add(expressionProxy, document.CreateSpace());

            int count = 0;
            foreach (VariableDeclaratorExpression declarator in declarators)
            {
                ValidateDocument(document, declarator, "declarator");

                if (count > 0)
                {
                    Add(expressionProxy, document.CreateCommaToken());
                    Add(expressionProxy, document.CreateSpace());
                }

                Add(expressionProxy, declarator);
                ++count;
            }

            return new VariableDeclarationExpression(expressionProxy, type, declarators);
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclaratorExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="identifier">The identifier name of the variable.</param>
        /// <param name="initializer">The initialization expression for the variable.</param>
        /// <returns>Returns the expression.</returns>
        public static VariableDeclaratorExpression CreateVariableDeclaratorExpression(this CsDocument document, string identifier, Expression initializer = null)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireValidString(identifier, "identifier");
            Param.Ignore(initializer);

            return document.CreateVariableDeclaratorExpression(document.CreateLiteralExpression(identifier), initializer);
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclaratorExpression" />.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="identifier">The identifier name of the variable.</param>
        /// <param name="initializer">The initialization expression for the variable.</param>
        /// <returns>Returns the expression.</returns>
        public static VariableDeclaratorExpression CreateVariableDeclaratorExpression(this CsDocument document, LiteralExpression identifier, Expression initializer = null)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(identifier, "identifier");
            Param.Ignore(initializer);

            ValidateDocument(document, identifier, "identifier");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, identifier);

            if (initializer != null)
            {
                ValidateDocument(document, initializer, "initializer");

                Add(expressionProxy, document.CreateSpace());
                Add(expressionProxy, document.CreateEqualsOperator());
                Add(expressionProxy, document.CreateSpace());
                Add(expressionProxy, initializer);
            }

            return new VariableDeclaratorExpression(expressionProxy, identifier, initializer);
        }

        /// <summary>
        /// Creates a <see cref="XorEqualsExpression"/>.
        /// </summary>
        /// <param name="document">The document which the expression will be added to.</param>
        /// <param name="leftHandSide">The expression on the left-hand side of the operation.</param>
        /// <param name="rightHandSide">The expression on the right-hand side of the operation.</param>
        /// <returns>Returns the expression.</returns>
        public static XorEqualsExpression CreateXorEqualsExpression(
            this CsDocument document, Expression leftHandSide, Expression rightHandSide)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(leftHandSide, "leftHandSide");
            Param.RequireNotNull(rightHandSide, "rightHandSide");

            ValidateDocument(document, leftHandSide, "leftHandSide");
            ValidateDocument(document, rightHandSide, "rightHandSide");

            CodeUnitProxy expressionProxy = new CodeUnitProxy(document);
            Add(expressionProxy, leftHandSide);
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, document.CreateXorEqualsOperator());
            Add(expressionProxy, document.CreateSpace());
            Add(expressionProxy, rightHandSide);

            return new XorEqualsExpression(expressionProxy, leftHandSide, rightHandSide);
        }

        #endregion Expressions

        #region Statements

        /// <summary>
        /// Creates a <see cref="BlockStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="childStatements">The statements within the block statement.</param>
        /// <returns>Returns the statement.</returns>
        public static BlockStatement CreateBlockStatement(this CsDocument document, IEnumerable<Statement> childStatements = null)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(childStatements);

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateOpenCurlyBracketToken());
            Add(statementProxy, document.CreateEndOfLine());

            if (childStatements != null)
            {
                foreach (Statement childStatement in childStatements)
                {
                    ValidateDocument(document, childStatement, "childStatement");
                    Add(statementProxy, childStatement);
                    Add(statementProxy, document.CreateEndOfLine());
                }
            }

            Add(statementProxy, document.CreateCloseCurlyBracketToken());

            return new BlockStatement(statementProxy);
        }

        /// <summary>
        /// Appends a child statement at end end of the given block.
        /// </summary>
        /// <param name="block">The block of statements to append to.</param>
        /// <param name="childStatement">The statement to append.</param>
        public static void AppendChildStatement(this BlockStatement block, Statement childStatement)
        {
            Param.RequireNotNull(block, "block");
            Param.RequireNotNull(childStatement, "childStatement");

            ValidateDocument(block.Document, childStatement.Document, "childStatement");

            CodeUnit itemToInsertAfter = FindBlockAppendPoint(block);
            if (itemToInsertAfter == null)
            {
                throw new SyntaxException(block.Document, block.LineNumber);
            }

            InsertAfter(itemToInsertAfter, childStatement);
            InsertAfter(childStatement, block.Document.CreateEndOfLine());
        }

        /// <summary>
        /// Appends an end-of-line character at end end of the given block.
        /// </summary>
        /// <param name="block">The block of statements to append to.</param>
        public static void AppendNewline(this BlockStatement block)
        {
            Param.RequireNotNull(block, "block");

            CodeUnit itemToInsertAfter = FindBlockAppendPoint(block);
            if (itemToInsertAfter == null)
            {
                throw new SyntaxException(block.Document, block.LineNumber);
            }

            InsertAfter(itemToInsertAfter, block.Document.CreateEndOfLine());
        }

        /// <summary>
        /// Creates a <see cref="BreakStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static BreakStatement CreateBreakStatement(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateBreakToken());
            Add(statementProxy, document.CreateSemicolonToken());

            return new BreakStatement(statementProxy);
        }

        /// <summary>
        /// Creates a <see cref="CatchStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static CatchStatement CreateCatchStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="ConstructorInitializerStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static ConstructorInitializerStatement CreateConstructorInitializerStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="ContinueStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static ContinueStatement CreateContinueStatement(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateContinueToken());
            Add(statementProxy, document.CreateSemicolonToken());

            return new ContinueStatement(statementProxy);
        }

        /// <summary>
        /// Creates a <see cref="DoWhileStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="condition">The boolean condition expression.</param>
        /// <param name="body">A single expression representing the body of the foreach statement.</param>
        /// <returns>Returns the statement.</returns>
        public static DoWhileStatement CreateDoWhileStatement(this CsDocument document, Expression condition, Expression body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(condition, "condition");
            Param.RequireNotNull(body, "body");

            return document.CreateDoWhileStatement(condition, document.CreateExpressionStatement(body));
        }

        /// <summary>
        /// Creates a <see cref="DoWhileStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="condition">The boolean condition expression.</param>
        /// <param name="body">The body of the do-while-statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /// or a single statement of some other type.</param>
        /// <returns>Returns the statement.</returns>
        public static DoWhileStatement CreateDoWhileStatement(this CsDocument document, Expression condition, Statement body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(condition, "condition");
            Param.RequireNotNull(body, "body");

            ValidateDocument(document, condition, "condition");
            ValidateDocument(document, body, "body");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateDoToken());
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, body);
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, document.CreateWhileToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateOpenParenthesisToken());
            Add(statementProxy, condition);
            Add(statementProxy, document.CreateCloseParenthesisToken());

            return new DoWhileStatement(statementProxy, condition, body);
        }

        /// <summary>
        /// Creates a <see cref="EmptyStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static EmptyStatement CreateEmptyStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="ElseStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static ElseStatement CreateElseStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="ExpressionStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="expression">The expression within the statement.</param>
        /// <returns>Returns the statement.</returns>
        public static ExpressionStatement CreateExpressionStatement(this CsDocument document, Expression expression)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(expression, "expression");

            ValidateDocument(document, expression, "expression");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, expression);
            Add(statementProxy, document.CreateSemicolonToken());

            return new ExpressionStatement(statementProxy, expression);
        }

        /// <summary>
        /// Creates a <see cref="FinallyStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static FinallyStatement CreateFinallyStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates an <see cref="FixedStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="fixedVariable">The variable declared within the fixed statement.</param>
        /// <param name="body">A single expression representing the body of the foreach statement.</param>
        /// <returns>Returns the statement.</returns>
        public static FixedStatement CreateFixedStatement(this CsDocument document, VariableDeclarationExpression fixedVariable, Expression body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(fixedVariable, "fixedVariable");
            Param.RequireNotNull(body, "body");

            return document.CreateFixedStatement(fixedVariable, document.CreateExpressionStatement(body));
        }

        /// <summary>
        /// Creates an <see cref="FixedStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="fixedVariable">The variable declared within the fixed statement.</param>
        /// <param name="body">The body of the fixed statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /// or a single statement of some other type.</param>
        /// <returns>Returns the statement.</returns>
        public static FixedStatement CreateFixedStatement(this CsDocument document, VariableDeclarationExpression fixedVariable, Statement body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(fixedVariable, "fixedVariable");
            Param.RequireNotNull(body, "body");

            ValidateDocument(document, fixedVariable, "fixedVariable");
            ValidateDocument(document, body, "body");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateFixedToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateOpenParenthesisToken());
            Add(statementProxy, fixedVariable);
            Add(statementProxy, document.CreateCloseParenthesisToken());
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, body);

            return new FixedStatement(statementProxy, fixedVariable);
        }

        /// <summary>
        /// Creates a <see cref="ForeachStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="iterationVariable">The iteration variable declared in foreach statement declaration.</param>
        /// <param name="collection">The enumerable expression being iterated over.</param>
        /// <param name="body">A single expression representing the body of the foreach statement.</param>
        /// <returns>Returns the statement.</returns>
        public static ForeachStatement CreateForeachStatement(this CsDocument document, VariableDeclarationExpression iterationVariable, Expression collection, Expression body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(iterationVariable, "iterationVariable");
            Param.RequireNotNull(collection, "condition");
            Param.RequireNotNull(body, "body");

            return document.CreateForeachStatement(iterationVariable, collection, document.CreateExpressionStatement(body));
        }

        /// <summary>
        /// Creates a <see cref="ForeachStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="iterationVariable">The iteration variable declared in foreach statement declaration.</param>
        /// <param name="collection">The enumerable expression being iterated over.</param>
        /// <param name="body">The body of the foreach statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /// or a single statement of some other type.</param>
        /// <returns>Returns the statement.</returns>
        public static ForeachStatement CreateForeachStatement(this CsDocument document, VariableDeclarationExpression iterationVariable, Expression collection, Statement body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(iterationVariable, "iterationVariable");
            Param.RequireNotNull(collection, "collection");
            Param.RequireNotNull(body, "body");

            ValidateDocument(document, iterationVariable, "iterationVariable");
            ValidateDocument(document, collection, "condition");
            ValidateDocument(document, body, "body");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateForeachToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateOpenParenthesisToken());
            Add(statementProxy, iterationVariable);
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateInToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, collection);
            Add(statementProxy, document.CreateCloseParenthesisToken());
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, body);

            return new ForeachStatement(statementProxy, iterationVariable, collection);
        }

        /////// <summary>
        /////// Creates a <see cref="ForStatement"/>.
        /////// </summary>
        /////// <param name="document">The document which the statement will be added to.</param>
        /////// <param name="initializer">The variable declared in the for-statement declaration.</param>
        /////// <param name="condition">The condition expression.</param>
        /////// <param name="iterator">The iterator expression.</param>
        /////// <param name="body">A single expression representing the body of the for-statement.</param>
        /////// <returns>Returns the statement.</returns>
        ////public static ForStatement CreateForStatement(this CsDocument document, Expression initializer, Expression condition, Expression iterator, Expression body)
        ////{
        ////    Param.RequireNotNull(document, "document");
        ////    Param.Ignore(initializer, "initializer");
        ////    Param.Ignore(condition, "condition");
        ////    Param.Ignore(iterator, "iterator");
        ////    Param.RequireNotNull(body, "body");

        ////    return document.CreateForStatement(initializer, condition, iterator, document.CreateExpressionStatement(body));
        ////}

        /////// <summary>
        /////// Creates a <see cref="ForStatement"/>.
        /////// </summary>
        /////// <param name="document">The document which the statement will be added to.</param>
        /////// <param name="initializer">The variable declared in the for-statement declaration.</param>
        /////// <param name="condition">The condition expression.</param>
        /////// <param name="iterator">The iterator expression.</param>
        /////// <param name="body">The body of the for-statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /////// or a single statement of some other type.</param>
        /////// <returns>Returns the statement.</returns>
        ////public static ForStatement CreateForStatement(this CsDocument document, Expression initializer, Expression condition, Expression iterator, Statement body)
        ////{
        ////    Param.RequireNotNull(document, "document");
        ////    Param.Ignore(initializer, "initializer");
        ////    Param.Ignore(condition, "condition");
        ////    Param.Ignore(iterator, "iterator");
        ////    Param.RequireNotNull(body, "body");

        ////    ICollection<Expression> initializers = initializer == null ? new Expression[] { } : new Expression[] { initializer };
        ////    ICollection<Expression> iterators = initializer == null ? new Expression[] { } : new Expression[] { initializer };

        ////    return document.CreateForStatement(initializers, condition, iterators, body);
        ////}

        /// <summary>
        /// Creates a <see cref="ForStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="initializers">The variables declared in the for-statement declaration.</param>
        /// <param name="condition">The condition expression.</param>
        /// <param name="iterators">The iterator expressions.</param>
        /// <param name="body">A single expression representing the body of the for-statement.</param>
        /// <returns>Returns the statement.</returns>
        public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Expression body)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(initializers, "initializers");
            Param.Ignore(condition, "condition");
            Param.Ignore(iterators, "iterators");
            Param.RequireNotNull(body, "body");

            return document.CreateForStatement(initializers, condition, iterators, document.CreateExpressionStatement(body));
        }

        /// <summary>
        /// Creates a <see cref="ForStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="initializers">The variables declared in the for-statement declaration.</param>
        /// <param name="condition">The condition expression.</param>
        /// <param name="iterators">The iterator expressions.</param>
        /// <param name="body">The body of the for-statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /// or a single statement of some other type.</param>
        /// <returns>Returns the statement.</returns>
        public static ForStatement CreateForStatement(this CsDocument document, ICollection<Expression> initializers, Expression condition, ICollection<Expression> iterators, Statement body)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(initializers, "initializers");
            Param.Ignore(condition, "condition");
            Param.Ignore(iterators, "iterators");
            Param.RequireNotNull(body, "body");

            ValidateDocument(document, body, "body");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateForToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateOpenParenthesisToken());

            // Add each of the initializers.
            if (initializers == null)
            {
                initializers = Expression.EmptyExpressionArray;
            }

            int index = 0;
            foreach (Expression initializer in initializers)
            {
                Param.RequireNotNull(initializer, "initializer");
                ValidateDocument(document, initializer, "initializer");

                if (index > 0)
                {
                    Add(statementProxy, document.CreateCommaToken());
                    Add(statementProxy, document.CreateSpace());
                }

                Add(statementProxy, initializer);
                ++index;
            }

            Add(statementProxy, document.CreateSemicolonToken());

            // Add the condition expression.
            if (condition != null)
            {
                ValidateDocument(document, condition, "condition");

                Add(statementProxy, document.CreateSpace());
                Add(statementProxy, condition);
            }

            Add(statementProxy, document.CreateSemicolonToken());

            // Add each of the iterators.
            if (iterators == null)
            {
                iterators = Expression.EmptyExpressionArray;
            }

            index = 0;
            foreach (Expression iterator in iterators)
            {
                Param.RequireNotNull(iterator, "iterator");
                ValidateDocument(document, iterator, "iterator");

                if (index > 0)
                {
                    Add(statementProxy, document.CreateCommaToken());
                }

                Add(statementProxy, document.CreateSpace());
                Add(statementProxy, iterator);
                ++index;
            }

            Add(statementProxy, document.CreateCloseParenthesisToken());
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, body);

            return new ForStatement(statementProxy, initializers, condition, iterators);
        }

        /// <summary>
        /// Creates a <see cref="GotoStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static GotoStatement CreateGotoStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates an <see cref="IfStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="condition">The boolean condition expression.</param>
        /// <param name="body">A single expression representing the body of the foreach statement.</param>
        /// <returns>Returns the statement.</returns>
        public static IfStatement CreateIfStatement(this CsDocument document, Expression condition, Expression body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(condition, "condition");
            Param.RequireNotNull(body, "body");

            return document.CreateIfStatement(condition, document.CreateExpressionStatement(body));
        }

        /// <summary>
        /// Creates an <see cref="IfStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="condition">The boolean condition expression.</param>
        /// <param name="body">The body of the if-statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /// or a single statement of some other type.</param>
        /// <returns>Returns the statement.</returns>
        public static IfStatement CreateIfStatement(this CsDocument document, Expression condition, Statement body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(condition, "condition");
            Param.RequireNotNull(body, "body");

            ValidateDocument(document, condition, "condition");
            ValidateDocument(document, body, "body");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateIfToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateOpenParenthesisToken());
            Add(statementProxy, condition);
            Add(statementProxy, document.CreateCloseParenthesisToken());
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, body);

            return new IfStatement(statementProxy, condition);
        }

        /// <summary>
        /// Creates a <see cref="LabelStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static LabelStatement CreateLabelStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates an <see cref="LockStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="lockObject">The target of the lock.</param>
        /// <param name="body">A single expression representing the body of the lock statement.</param>
        /// <returns>Returns the statement.</returns>
        public static LockStatement CreateLockStatement(this CsDocument document, Expression lockObject, Expression body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(lockObject, "lockObject");
            Param.RequireNotNull(body, "body");

            return document.CreateLockStatement(lockObject, document.CreateExpressionStatement(body));
        }

        /// <summary>
        /// Creates an <see cref="LockStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="lockObject">The target of the lock.</param>
        /// <param name="body">The body of the lock statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /// or a single statement of some other type.</param>
        /// <returns>Returns the statement.</returns>
        public static LockStatement CreateLockStatement(this CsDocument document, Expression lockObject, Statement body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(lockObject, "lockObject");
            Param.RequireNotNull(body, "body");

            ValidateDocument(document, lockObject, "lockObject");
            ValidateDocument(document, body, "body");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateLockToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateOpenParenthesisToken());
            Add(statementProxy, lockObject);
            Add(statementProxy, document.CreateCloseParenthesisToken());
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, body);

            return new LockStatement(statementProxy, lockObject);
        }

        /// <summary>
        /// Creates a <see cref="ReturnStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static ReturnStatement CreateReturnStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="SwitchCaseStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static SwitchCaseStatement CreateSwitchCaseStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="SwitchDefaultStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static SwitchDefaultStatement CreateSwitchDefaultStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="SwitchStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static SwitchStatement CreateSwitchStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="ThrowStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static ThrowStatement CreateThrowStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="TryStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static TryStatement CreateTryStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="UncheckedStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static UncheckedStatement CreateUncheckedStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="UnsafeStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static UnsafeStatement CreateUnsafeStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="UsingStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static UsingStatement CreateUsingStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        /// <summary>
        /// Creates a <see cref="VariableDeclarationStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="variableDeclarationExpression">The variable declaration expression within this statement.</param>
        /// <param name="isConstant">Indicates whether the statement should include the 'const' keyword.</param>
        /// <returns>Returns the statement.</returns>
        public static VariableDeclarationStatement CreateVariableDeclarationStatement(this CsDocument document, VariableDeclarationExpression variableDeclarationExpression, bool isConstant = false)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(variableDeclarationExpression, "variableDeclarationExpression");
            Param.Ignore(isConstant);

            ValidateDocument(document, variableDeclarationExpression, "variableDeclarationExpression");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);

            if (isConstant)
            {
                Add(statementProxy, document.CreateConstToken());
                Add(statementProxy, document.CreateSpace());
            }

            Add(statementProxy, variableDeclarationExpression);
            Add(statementProxy, document.CreateSemicolonToken());

            return new VariableDeclarationStatement(statementProxy, variableDeclarationExpression, isConstant);
        }

        /// <summary>
        /// Creates a <see cref="WhileStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="condition">The boolean condition expression.</param>
        /// <param name="body">A single expression representing the body of the foreach statement.</param>
        /// <returns>Returns the statement.</returns>
        public static WhileStatement CreateWhileStatement(this CsDocument document, Expression condition, Expression body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(condition, "condition");
            Param.RequireNotNull(body, "body");

            return document.CreateWhileStatement(condition, document.CreateExpressionStatement(body));
        }

        /// <summary>
        /// Creates a <see cref="WhileStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <param name="condition">The boolean condition expression.</param>
        /// <param name="body">The body of the while-statement, which is typically either a <see cref="BlockStatement"/> containing multiple child statements, 
        /// or a single statement of some other type.</param>
        /// <returns>Returns the statement.</returns>
        public static WhileStatement CreateWhileStatement(this CsDocument document, Expression condition, Statement body)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(condition, "condition");
            Param.RequireNotNull(body, "body");

            ValidateDocument(document, condition, "condition");
            ValidateDocument(document, body, "body");

            CodeUnitProxy statementProxy = new CodeUnitProxy(document);
            Add(statementProxy, document.CreateWhileToken());
            Add(statementProxy, document.CreateSpace());
            Add(statementProxy, document.CreateOpenParenthesisToken());
            Add(statementProxy, condition);
            Add(statementProxy, document.CreateCloseParenthesisToken());
            Add(statementProxy, document.CreateEndOfLine());
            Add(statementProxy, body);

            return new WhileStatement(statementProxy, condition);
        }

        /// <summary>
        /// Creates a <see cref="YieldStatement"/>.
        /// </summary>
        /// <param name="document">The document which the statement will be added to.</param>
        /// <returns>Returns the statement.</returns>
        public static YieldStatement CreateYieldStatement(this CsDocument document)
        {
            // todo
            Param.RequireNotNull(document, "document");

            return null;
        }

        #endregion Statements

        #region Insertion

        /// <summary>
        /// Gets a location marker for the given code unit.
        /// </summary>
        /// <param name="document">The document which contains the the code unit.</param>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the location marker.</returns>
        public static CodeUnitLocationMarker GetCodeUnitLocationMarker(this CsDocument document, CodeUnit codeUnit)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(codeUnit, "codeUnit");

            return new CodeUnitLocationMarker(codeUnit);
        }

        /// <summary>
        /// Inserts the given item at the given location.
        /// </summary>
        /// <param name="document">The document to insert the code unit into.</param>
        /// <param name="itemToInsert">The code unit to insert.</param>
        /// <param name="locationMarker">The insertion location.</param>
        public static void Insert(this CsDocument document, CodeUnit itemToInsert, CodeUnitLocationMarker locationMarker)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(itemToInsert, "itemToInsert");
            Param.RequireNotNull(locationMarker, "locationMarker");

            ValidateReadWrite(document);

            if (locationMarker.PreviousSibling != null)
            {
                document.InsertAfter(itemToInsert, locationMarker.PreviousSibling);
            }
            else if (locationMarker.NextSibling != null)
            {
                document.InsertBefore(itemToInsert, locationMarker.NextSibling);
            }
            else if (locationMarker.Parent != null)
            {
                document.PrependChild(itemToInsert, locationMarker.Parent);
            }
            else
            {
                CsLanguageService.Debug.Fail("A location marker should never have a null parent, previous sibling, and next sibling.");
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Inserts the given item at the given location.
        /// </summary>
        /// <param name="document">The document to insert the code unit into.</param>
        /// <param name="itemToInsert">The code unit to insert.</param>
        /// <param name="itemToInsertAfter">The item to insert to code unit after.</param>
        public static void InsertAfter(this CsDocument document, CodeUnit itemToInsert, CodeUnit itemToInsertAfter)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(itemToInsert, "itemToInsert");
            Param.RequireNotNull(itemToInsertAfter, "itemToInsertAfter");

            ValidateReadWrite(document);
            ValidateDocument(document, itemToInsertAfter, "itemToInsertAfter");

            itemToInsertAfter.Parent.Children.InsertAfter(itemToInsert, itemToInsertAfter);
            document.IncrementEditVersion();
        }

        /// <summary>
        /// Inserts the given item at the given location.
        /// </summary>
        /// <param name="document">The document to insert the code unit into.</param>
        /// <param name="itemToInsert">The code unit to insert.</param>
        /// <param name="itemToInsertBefore">The item to insert to code unit before.</param>
        public static void InsertBefore(this CsDocument document, CodeUnit itemToInsert, CodeUnit itemToInsertBefore)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(itemToInsert, "itemToInsert");
            Param.RequireNotNull(itemToInsertBefore, "itemToInsertBefore");

            ValidateReadWrite(document);
            ValidateDocument(document, itemToInsertBefore, "itemToInsertBefore");

            itemToInsertBefore.Parent.Children.InsertBefore(itemToInsert, itemToInsertBefore);
            document.IncrementEditVersion();
        }

        /// <summary>
        /// Inserts the item as the first child of the given parent.
        /// </summary>
        /// <param name="document">The document to insert the code unit into.</param>
        /// <param name="itemToInsert">The code unit to insert.</param>
        /// <param name="parent">The parent item to insert the code unit under.</param>
        public static void PrependChild(this CsDocument document, CodeUnit itemToInsert, CodeUnit parent)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(itemToInsert, "itemToInsert");
            Param.RequireNotNull(parent, "parent");

            ValidateReadWrite(document);
            ValidateDocument(document, parent, "parent");

            parent.Children.InsertFirst(itemToInsert);
            document.IncrementEditVersion();
        }

        /// <summary>
        /// Inserts the item as the last child of the given parent.
        /// </summary>
        /// <param name="document">The document to insert the code unit into.</param>
        /// <param name="itemToInsert">The code unit to insert.</param>
        /// <param name="parent">The parent item to insert the code unit under.</param>
        public static void AppendChild(this CsDocument document, CodeUnit itemToInsert, CodeUnit parent)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(itemToInsert, "itemToInsert");
            Param.RequireNotNull(parent, "parent");

            ValidateReadWrite(document);
            ValidateDocument(document, parent, "parent");

            parent.Children.InsertLast(itemToInsert);
            document.IncrementEditVersion();
        }

        /// <summary>
        /// Replaces the given item with a new item.
        /// </summary>
        /// <param name="document">The document containing the item to replace.</param>
        /// <param name="original">The item to replace.</param>
        /// <param name="replacement">The replacement item.</param>
        public static void Replace(this CsDocument document, CodeUnit original, CodeUnit replacement)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(original, "original");
            Param.RequireNotNull(replacement, "replacement");

            ValidateReadWrite(document);
            ValidateDocument(document, original, "original");

            original.Parent.Children.Replace(original, replacement);
            document.IncrementEditVersion();
        }

        #endregion Insertion

        #region Private Methods

        /// <summary>
        /// Validates that the given code unit belongs to the given document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="item">The code unit.</param>
        /// <param name="identifier">The name of the code unit parameter or field.</param>
        private static void ValidateDocument(CsDocument document, CodeUnit item, string identifier)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(item, "item");
            Param.AssertValidString(identifier, "identifier");

            if (item.Document != document)
            {
                throw new CodeModelException(document, string.Format(Strings.CodeModelDocumentMismatch, identifier));
            }
        }

        /// <summary>
        /// Validates that the given expression is one of the given types.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="type">The type to check.</param>
        /// <param name="identifier">The name of the code unit parameter or field.</param>
        /// <param name="validTypes">The valid types.</param>
        /// <typeparam name="T">The type to validate.</typeparam>
        private static void ValidateType<T>(CsDocument document, T type, string identifier, T[] validTypes)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(type, "expressionType");
            Param.AssertValidString(identifier, "identifier");
            Param.AssertNotNull(validTypes, "validExpressionTypes");

            for (int i = 0; i < validTypes.Length; ++i)
            {
                if (type.Equals(validTypes[i]))
                {
                    return;
                }
            }

            StringBuilder validExpressionTypesString = new StringBuilder();
            for (int i = 0; i < validTypes.Length; ++i)
            {
                validExpressionTypesString.Append(validTypes[i].ToString());
                validExpressionTypesString.Append(" ");
            }

            throw new CodeModelException(document, string.Format(Strings.CodeModelTypeMismatch, identifier, type.ToString(), validExpressionTypesString));
        }

        /// <summary>
        /// Validates whether the document can be edited.
        /// </summary>
        /// <param name="document">The document.</param>
        private static void ValidateReadWrite(CsDocument document)
        {
            Param.AssertNotNull(document, "document");

            // TODO: Currently a no-op.
        }

        /// <summary>
        /// Given a block of statements, finds the position at which to append a new item to the end of the block.
        /// </summary>
        /// <param name="block">The block of statements.</param>
        /// <returns>Returns the insertion point or null if there is none.</returns>
        private static CodeUnit FindBlockAppendPoint(BlockStatement block)
        {
            Param.AssertNotNull(block, "block");

            // Find the closing curly bracket at the end of the block statement.
            var closingCurlyBracket = block.FindLastChild<CloseCurlyBracketToken>();
            if (closingCurlyBracket == null)
            {
                return null;
            }

            // Work backwards until we either find a newline, or the opening curly bracket.
            CodeUnit itemToInsertAfter = null;
            for (LexicalElement previous = closingCurlyBracket.FindPreviousSiblingLexicalElement(); previous != null; previous = previous.FindPreviousSiblingLexicalElement())
            {
                if (previous.Is(TokenType.OpenCurlyBracket))
                {
                    // Insert a newline just after the opening curly bracket, and use this as the insertion point.
                    var endOfLine = block.Document.CreateEndOfLine();
                    InsertAfter(previous, endOfLine);
                    itemToInsertAfter = endOfLine;
                    break;
                }
                else if (previous.LexicalElementType == LexicalElementType.EndOfLine)
                {
                    itemToInsertAfter = previous;
                    break;
                }
            }

            return itemToInsertAfter;
        }

        /// <summary>
        /// Adds an item to the given code unit proxy, at the end of the child code unit collection.
        /// </summary>
        /// <param name="proxy">The proxy to add the code unit to.</param>
        /// <param name="itemToAdd">The code unit to detach.</param>
        private static void Add(CodeUnitProxy proxy, CodeUnit itemToAdd)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(itemToAdd, "itemToAdd");

            CsLanguageService.Debug.Assert(itemToAdd.Document == proxy.Document, "Document mismatch");

            if (itemToAdd.ParentReference != null)
            {
                if (itemToAdd.ParentReference.Children == proxy.Children)
                {
                    throw new ArgumentException(Strings.ItemHasAlreadyBeenAddedToCollection);
                }

                ValidateReadWrite(proxy.Document);
                itemToAdd.Detach();
            }

            proxy.Children.Add(itemToAdd);
            proxy.Document.IncrementEditVersion();
        }

        /// <summary>
        /// Inserts an item into a code unit collection, just after the given item.
        /// </summary>
        /// <param name="itemToInsertAfter">The item to insert after.</param>
        /// <param name="itemToInsert">The item to insert.</param>
        private static void InsertAfter(CodeUnit itemToInsertAfter, CodeUnit itemToInsert)
        {
            Param.AssertNotNull(itemToInsertAfter, "itemToInsertAfter");
            Param.AssertNotNull(itemToInsert, "itemToInsert");
            
            CodeUnitProxy parentProxy = itemToInsertAfter.ParentReference;
            if (parentProxy == null || itemToInsertAfter.Document == null)
            {
                throw new ArgumentException(Strings.ItemHasNotBeenAddedToACollection);
            }

            if (itemToInsert.ParentReference != null)
            {
                if (itemToInsert.ParentReference.Children == parentProxy.Children)
                {
                    throw new ArgumentException(Strings.ItemHasAlreadyBeenAddedToCollection);
                }

                ValidateReadWrite(parentProxy.Document);
                itemToInsert.Detach();
            }

            parentProxy.Children.InsertAfter(itemToInsert, itemToInsertAfter);
            parentProxy.Document.IncrementEditVersion();
        }

        #endregion Private Methods
    }
}
