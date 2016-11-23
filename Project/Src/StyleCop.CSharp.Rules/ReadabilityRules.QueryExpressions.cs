// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadabilityRules.QueryExpressions.cs" company="https://github.com/StyleCop">
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
//   The readability rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// The readability rules.
    /// </summary>
    /// <content>
    /// Checks rules related to formatting of query expressions.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Methods

        /// <summary>
        /// Processes the given query expression.
        /// </summary>
        /// <param name="element">
        /// The element that contains the expression.
        /// </param>
        /// <param name="queryExpression">
        /// The query expression.
        /// </param>
        private void CheckQueryExpression(CsElement element, QueryExpression queryExpression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(queryExpression, "queryExpression");

            QueryClause previousClause = null;

            bool clauseOnSameLine = false;
            bool clauseOnSeparateLine = false;

            this.ProcessQueryClauses(element, queryExpression, queryExpression.ChildClauses, ref previousClause, ref clauseOnSameLine, ref clauseOnSeparateLine);
        }

        /// <summary>
        /// Analyzes the given query clauses.
        /// </summary>
        /// <param name="element">
        /// The element containing the clauses.
        /// </param>
        /// <param name="expression">
        /// The expression containing the clauses.
        /// </param>
        /// <param name="clauses">
        /// The list of clauses to analyze.
        /// </param>
        /// <param name="previousClause">
        /// The previous clause in the expression, if any.
        /// </param>
        /// <param name="clauseOnSameLine">
        /// Indicates whether any clause has been seen previously which
        /// starts on the same line as the clause before it.
        /// </param>
        /// <param name="clauseOnSeparateLine">
        /// Indicates whether any clause has been seen previously which
        /// starts on the line after the clause before it.
        /// </param>
        /// <returns>
        /// Returns true to continue checking the query clause, or false to quit.
        /// </returns>
        private bool ProcessQueryClauses(
            CsElement element, 
            QueryExpression expression, 
            ICollection<QueryClause> clauses, 
            ref QueryClause previousClause, 
            ref bool clauseOnSameLine, 
            ref bool clauseOnSeparateLine)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(clauses, "clauses");
            Param.Ignore(previousClause);
            Param.Ignore(clauseOnSameLine);
            Param.Ignore(clauseOnSeparateLine);

            foreach (QueryClause clause in clauses)
            {
                if (previousClause != null)
                {
                    // Figure out the line number that the previous clause ends on. For most 
                    // clauses, this is simply the end point of the clause location property,
                    // but for continuation clauses we want to use the location of the 'into' variable,
                    // which conceptually represents the end of the continuation line.
                    int previousClauseEndLineNumber = previousClause.Location.EndPoint.LineNumber;

                    if (previousClause.QueryClauseType == QueryClauseType.Continuation)
                    {
                        previousClauseEndLineNumber = ((QueryContinuationClause)previousClause).Variable.Location.LineNumber;
                    }

                    // Ensure that the clause either starts on the same line as the expression, or 
                    // on the very next line.
                    if (clause.LineNumber == previousClauseEndLineNumber)
                    {
                        // This is only ok if the previous clause does not span multiple lines.
                        if (previousClause.Location.LineSpan > 1)
                        {
                            this.AddViolation(element, clause.LineNumber, Rules.QueryClauseMustBeginOnNewLineWhenPreviousClauseSpansMultipleLines);
                            return false;
                        }

                        // The rest of the checks are only applied when the clause is not a query continuation clause. A continuation
                        // clause is allowed to begin at the end of the previous clause, on the same line.
                        if (clause.QueryClauseType != QueryClauseType.Continuation)
                        {
                            // The clause starts on the same line as the ending of the previous clause.
                            // This is ok as long as we have not previously seen a clause which starts
                            // on its own line. The one exception is that query continuation clauses
                            // are allowed to be inserted at the end of the previous claus.
                            if (clauseOnSeparateLine)
                            {
                                this.AddViolation(element, clause.LineNumber, Rules.QueryClausesMustBeOnSeparateLinesOrAllOnOneLine);
                                return false;
                            }

                            // If the clause spans multiple lines, it must begin on its own line. The exception is query continuation
                            // clauses, which are allowed to begin at the end of the previous claus.
                            if (clause.Location.LineSpan > 1)
                            {
                                this.AddViolation(element, clause.LineNumber, Rules.QueryClausesSpanningMultipleLinesMustBeginOnOwnLine);
                                return false;
                            }

                            // Indicate that we have seen a clause which starts on the same line as the
                            // previous clause.
                            clauseOnSameLine = true;
                        }
                    }
                    else if (clause.LineNumber == previousClauseEndLineNumber + 1)
                    {
                        // The clause starts on the line just after the previous clause. 
                        // This is fine unless we have previously seen two clauses on the same line.
                        if (clauseOnSameLine)
                        {
                            this.AddViolation(element, clause.LineNumber, Rules.QueryClausesMustBeOnSeparateLinesOrAllOnOneLine);
                            return false;
                        }

                        // Indicate that we have seen a clause which begins on the line after
                        // the previous clause.
                        clauseOnSeparateLine = true;
                    }
                    else if (clause.LineNumber > previousClauseEndLineNumber + 1)
                    {
                        // The clause does not start on the line after the previous clause.
                        this.AddViolation(element, clause.LineNumber, Rules.QueryClauseMustFollowPreviousClause);
                        return false;
                    }
                }

                previousClause = clause;

                if (clause.QueryClauseType == QueryClauseType.Continuation)
                {
                    QueryContinuationClause continuationClause = (QueryContinuationClause)clause;
                    if (
                        !this.ProcessQueryClauses(
                            element, expression, continuationClause.ChildClauses, ref previousClause, ref clauseOnSameLine, ref clauseOnSeparateLine))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}