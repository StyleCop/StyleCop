// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodePoint.cs" company="https://github.com/StyleCop">
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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a point within a code file.
    /// </summary>
    /// <subcategory>other</subcategory>
    public struct CodePoint
    {
        #region Private Fields

        /// <summary>
        /// The index of the first character of the item within the document.
        /// </summary>
        private readonly int index;

        /// <summary>
        /// The index of the first character of the item within the line
        /// that it appears on.
        /// </summary>
        private readonly int indexOnLine;

        /// <summary>
        /// The line number that this item appears on.
        /// </summary>
        private int lineNumber;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the CodePoint struct.
        /// </summary>
        /// <param name="index">The index of the first character of the item within the document.</param>
        /// <param name="indexOnLine">The index of the last character of the item within the line
        /// that it appears on.</param>
        /// <param name="lineNumber">The line number that the item appears on. Must be greater than zero.</param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "OnLine",
            Justification = "On Line is two words in this context.")]
        public CodePoint(int index, int indexOnLine, int lineNumber)
        {
            Param.RequireGreaterThanOrEqualToZero(index, "index");
            Param.RequireGreaterThanOrEqualToZero(indexOnLine, "indexOnLine");
            Param.RequireGreaterThanZero(lineNumber, "lineNumber");

            this.index = index;
            this.indexOnLine = indexOnLine;
            this.lineNumber = lineNumber;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the index of the first character of the item within the document.
        /// </summary>
        public int Index
        {
            get
            {
                return this.index;
            }
        }

        /// <summary>
        /// Gets the index of the first character of the item within the line
        /// that it appears on.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "OnLine",
            Justification = "On Line is two words in this context.")]
        public int IndexOnLine
        {
            get
            {
                return this.indexOnLine;
            }
        }

        /// <summary>
        /// Gets the line number that this item appears on. Minimum is 1.
        /// </summary>
        public int LineNumber
        {
            get
            {
                if (this.lineNumber == 0)
                {
                    this.lineNumber = 1;
                }

                return this.lineNumber;
            }
        }

        #endregion Public Properties

        #region Public Static Methods

        /// <summary>
        /// Joins the two given points.
        /// </summary>
        /// <param name="point1">The first point to join.</param>
        /// <param name="point2">The second point to join.</param>
        /// <returns>Returns the joined <see cref="CodePoint"/>.</returns>
        public static CodePoint Join(CodePoint point1, CodePoint point2)
        {
            if (point1.lineNumber == 0 && point1.indexOnLine == 0 && point1.index == 0)
            {
                return point2;
            }

            if (point2.lineNumber == 0 && point2.indexOnLine == 0 && point2.index == 0)
            {
                return point1;
            }

            // Figure out which IndexOnLine to use.
            int indexOnLine;
            if (point1.LineNumber == point2.LineNumber)
            {
                indexOnLine = Math.Min(point1.IndexOnLine, point2.IndexOnLine);
            }
            else if (point1.LineNumber < point2.LineNumber)
            {
                indexOnLine = point1.IndexOnLine;
            }
            else
            {
                indexOnLine = point2.IndexOnLine;
            }

            return new CodePoint(Math.Min(point1.Index, point2.Index), indexOnLine, Math.Min(point1.LineNumber, point2.LineNumber));
        }

        #endregion Public Static Methods
    }
}