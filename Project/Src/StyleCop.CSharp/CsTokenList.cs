// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsTokenList.cs" company="https://github.com/StyleCop">
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
//   A list of tokens.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A list of tokens.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The class represents a linked-list.")]
    public class CsTokenList : ItemList<CsToken>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CsTokenList class.
        /// </summary>
        /// <param name="masterList">
        /// The master list that this list points into.
        /// </param>
        public CsTokenList(MasterList<CsToken> masterList)
            : base(masterList)
        {
            Param.Ignore(masterList);
        }

        /// <summary>
        /// Initializes a new instance of the CsTokenList class.
        /// </summary>
        /// <param name="masterList">
        /// The master list that this list points into.
        /// </param>
        /// <param name="firstItemNode">
        /// The first item in the master list.
        /// </param>
        /// <param name="lastItemNode">
        /// The last item in the master list.
        /// </param>
        public CsTokenList(MasterList<CsToken> masterList, Node<CsToken> firstItemNode, Node<CsToken> lastItemNode)
            : base(masterList, firstItemNode, lastItemNode)
        {
            Param.Ignore(masterList, firstItemNode, lastItemNode);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the next non-whitespace, non-comment token.
        /// </summary>
        /// <param name="start">
        /// The first token.
        /// </param>
        /// <returns>
        /// Returns the next code token or null if there is none.
        /// </returns>
        public static Node<CsToken> GetNextCodeToken(Node<CsToken> start)
        {
            Param.RequireNotNull(start, "start");

            Node<CsToken> next = start.Next;
            while (next != null)
            {
                if (next.Value.CsTokenType != CsTokenType.WhiteSpace && next.Value.CsTokenType != CsTokenType.EndOfLine
                    && next.Value.CsTokenType != CsTokenType.SingleLineComment && next.Value.CsTokenType != CsTokenType.MultiLineComment)
                {
                    return next;
                }

                next = next.Next;
            }

            return null;
        }

        /// <summary>
        /// Determines whether the given token list contains the given strings, skipping whitespace tokens and
        /// comments.
        /// </summary>
        /// <param name="start">
        /// Begins matching the given strings with this token.
        /// </param>
        /// <param name="values">
        /// The collection of strings to match against.
        /// </param>
        /// <returns>
        /// Returns true if the tokens match the collection of strings.
        /// </returns>
        public static bool MatchTokens(Node<CsToken> start, params string[] values)
        {
            Param.RequireNotNull(start, "start");
            Param.RequireNotNull(values, "values");

            return CsTokenList.MatchTokens(StringComparison.Ordinal, start, values);
        }

        /// <summary>
        /// Determines whether the given token list contains the given strings, skipping whitespace tokens and
        /// comments.
        /// </summary>
        /// <param name="comparisonType">
        /// The string comparison type to use.
        /// </param>
        /// <param name="start">
        /// Begins matching the given strings with this token.
        /// </param>
        /// <param name="values">
        /// The collection of strings to match against.
        /// </param>
        /// <returns>
        /// Returns true if the tokens match the collection of strings.
        /// </returns>
        public static bool MatchTokens(StringComparison comparisonType, Node<CsToken> start, params string[] values)
        {
            Param.Ignore(comparisonType);
            Param.RequireNotNull(start, "start");
            Param.RequireNotNull(values, "values");

            int index = 0;
            Node<CsToken> token = start;

            while (token != null && index < values.Length)
            {
                if (!token.Value.Text.Equals(values[index], comparisonType))
                {
                    return false;
                }

                ++index;
                token = GetNextCodeToken(token);
            }

            return index >= values.Length;
        }

        /// <summary>
        /// Determines whether the token list contains the given strings, skipping whitespace tokens and
        /// comments.
        /// </summary>
        /// <param name="values">
        /// The collection of strings to match against.
        /// </param>
        /// <returns>
        /// Returns true if the tokens match the collection of strings.
        /// </returns>
        public bool MatchTokens(params string[] values)
        {
            Param.RequireNotNull(values, "values");

            return CsTokenList.MatchTokens(this.First, values);
        }

        /// <summary>
        /// Determines whether the token list contains the given strings, skipping whitespace tokens and
        /// comments.
        /// </summary>
        /// <param name="comparisonType">
        /// The string comparison type to use.
        /// </param>
        /// <param name="values">
        /// The collection of strings to match against.
        /// </param>
        /// <returns>
        /// Returns true if the tokens match the collection of strings.
        /// </returns>
        public bool MatchTokens(StringComparison comparisonType, params string[] values)
        {
            Param.RequireNotNull(values, "values");
            Param.Ignore(comparisonType);

            return CsTokenList.MatchTokens(comparisonType, this.First, values);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Removes whitespace and comments from the beginning and end of the token list.
        /// </summary>
        /// <returns>Returns the number of tokens that were trimmed from the beginning of the list.</returns>
        internal int Trim()
        {
            return this.Trim(CsTokenType.WhiteSpace, CsTokenType.EndOfLine, CsTokenType.SingleLineComment, CsTokenType.MultiLineComment);
        }

        /// <summary>
        /// Removes whitespace and comments from the beginning and end of the token list.
        /// </summary>
        /// <param name="types">
        /// The types to trim.
        /// </param>
        /// <returns>
        /// Returns the number of tokens that were trimmed from the beginning of the list.
        /// </returns>
        internal int Trim(params CsTokenType[] types)
        {
            Param.Ignore(types);

            if (types == null || types.Length == 0)
            {
                return 0;
            }

            Node<CsToken> begin = null;
            Node<CsToken> end = null;

            int trimCount = 0;

            // Trim the beginning of the list.
            for (Node<CsToken> tokenNode = this.First; !this.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                CsTokenType tokenType = tokenNode.Value.CsTokenType;

                bool match = false;
                for (int i = 0; i < types.Length; ++i)
                {
                    if (tokenType == types[i])
                    {
                        match = true;
                        break;
                    }
                }

                if (!match)
                {
                    begin = tokenNode;
                    break;
                }

                ++trimCount;
            }

            // Trim the end of the list.
            for (Node<CsToken> tokenNode = this.Last; !this.OutOfBounds(tokenNode); tokenNode = tokenNode.Previous)
            {
                CsTokenType tokenType = tokenNode.Value.CsTokenType;

                bool match = false;
                for (int i = 0; i < types.Length; ++i)
                {
                    if (tokenType == types[i])
                    {
                        match = true;
                        break;
                    }
                }

                if (!match)
                {
                    end = tokenNode;
                    break;
                }
            }

            this.First = begin;
            this.Last = end;

            return trimCount;
        }

        #endregion
    }
}