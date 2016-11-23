// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeLocation.cs" company="https://github.com/StyleCop">
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
//   Describes a location within a code document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a location within a code document.
    /// </summary>
    /// <subcategory>other</subcategory>
    public struct CodeLocation
    {
        #region Static Fields

        /// <summary>
        /// An empty code location.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "A static value.")]
        public static readonly CodeLocation Empty = new CodeLocation();

        #endregion

        #region Fields

        /// <summary>
        /// The ending position within the code.
        /// </summary>
        private readonly CodePoint endPoint;

        /// <summary>
        /// The starting position within the code.
        /// </summary>
        private readonly CodePoint startPoint;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CodeLocation struct.
        /// </summary>
        /// <param name="index">
        /// The index of the first character of the item within the file.
        /// </param>
        /// <param name="endIndex">
        /// The index of the last character of the item within the file.
        /// </param>
        /// <param name="indexOnLine">
        /// The index of the first character of the item within the line
        /// that it appears on.
        /// </param>
        /// <param name="endIndexOnLine">
        /// The index of the last character of the item within the line
        /// that it appears on.
        /// </param>
        /// <param name="lineNumber">
        /// The line number that this item begins on.
        /// </param>
        /// <param name="endLineNumber">
        /// The line number that this item ends on.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "OnLine", Justification = "On Line is two words in this context.")]
        public CodeLocation(int index, int endIndex, int indexOnLine, int endIndexOnLine, int lineNumber, int endLineNumber)
        {
            Param.RequireGreaterThanOrEqualToZero(index, "index");
            Param.RequireGreaterThanOrEqualTo(endIndex, index, "endIndex");
            Param.RequireGreaterThanOrEqualToZero(indexOnLine, "indexOnLine");
            Param.RequireGreaterThanOrEqualToZero(endIndexOnLine, "endIndexOnLine");
            Param.RequireGreaterThanZero(lineNumber, "lineNumber");
            Param.RequireGreaterThanOrEqualTo(endLineNumber, lineNumber, "endLineNumber");

#if DEBUG
            // If the entire segment is on the same line, make sure the end index is greater or equal to the start index.
            if (lineNumber == endLineNumber)
            {
                Debug.Assert(endIndexOnLine >= indexOnLine, "The end index must be greater than the start index, since they are both on the same line.");
            }
#endif

            this.startPoint = new CodePoint(index, indexOnLine, lineNumber);
            this.endPoint = new CodePoint(endIndex, endIndexOnLine, endLineNumber);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the ending point within the code.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "EndPoint", 
            Justification = "EndPoint is two words in this context, to be consistent with StartPoint")]
        public CodePoint EndPoint
        {
            get
            {
                return this.endPoint;
            }
        }

        /// <summary>
        /// Gets the starting line number of this code location.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.startPoint.LineNumber;
            }
        }

        /// <summary>
        /// Gets the number of lines spanned by the start and end points.
        /// </summary>
        /// <remarks>The line span will always be at least one.</remarks>
        public int LineSpan
        {
            get
            {
                return this.endPoint.LineNumber - this.startPoint.LineNumber + 1;
            }
        }

        /// <summary>
        /// Gets the starting point within the code.
        /// </summary>
        public CodePoint StartPoint
        {
            get
            {
                return this.startPoint;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Joins the two given locations.
        /// </summary>
        /// <param name="location1">
        /// The first location to join.
        /// </param>
        /// <param name="location2">
        /// The second location to join.
        /// </param>
        /// <returns>
        /// Returns the joined <see cref="CodeLocation"/>.
        /// </returns>
        public static CodeLocation? Join(CodeLocation? location1, CodeLocation? location2)
        {
            Param.Ignore(location1, location2);

            if (location1 == null && location2 == null)
            {
                return null;
            }

            if (location1 == null)
            {
                return location2;
            }

            if (location2 == null)
            {
                return location1;
            }

            // Figure out which IndexOnLine and EndIndexOnLine to use.
            int indexOnLine;
            int endIndexOnLine;
            if (location1.Value.StartPoint.LineNumber == location2.Value.StartPoint.LineNumber)
            {
                indexOnLine = Math.Min(location1.Value.StartPoint.IndexOnLine, location2.Value.StartPoint.IndexOnLine);
                endIndexOnLine = Math.Max(location1.Value.EndPoint.IndexOnLine, location2.Value.EndPoint.IndexOnLine);
            }
            else if (location1.Value.StartPoint.LineNumber < location2.Value.StartPoint.LineNumber)
            {
                indexOnLine = location1.Value.StartPoint.IndexOnLine;
                endIndexOnLine = location2.Value.EndPoint.IndexOnLine;
            }
            else
            {
                indexOnLine = location2.Value.StartPoint.IndexOnLine;
                endIndexOnLine = location1.Value.EndPoint.IndexOnLine;
            }

            return new CodeLocation(
                Math.Min(location1.Value.StartPoint.Index, location2.Value.StartPoint.Index),
                Math.Max(location1.Value.EndPoint.Index, location2.Value.EndPoint.Index), 
                indexOnLine, 
                endIndexOnLine,
                Math.Min(location1.Value.StartPoint.LineNumber, location2.Value.StartPoint.LineNumber),
                Math.Max(location2.Value.EndPoint.LineNumber, location2.Value.EndPoint.LineNumber));
        }

        /// <summary>
        /// Joins the two given locations.
        /// </summary>
        /// <param name="location1">
        /// The first location to join.
        /// </param>
        /// <param name="location2">
        /// The second location to join.
        /// </param>
        /// <returns>
        /// Returns the joined <see cref="CodeLocation"/>.
        /// </returns>
        public static CodeLocation Join(CodeLocation location1, CodeLocation? location2)
        {
            Param.Ignore(location1, location2);
            
            if (location2 == null)
            {
                return location1;
            }

            // Figure out which IndexOnLine and EndIndexOnLine to use.
            int indexOnLine;
            int endIndexOnLine;
            if (location1.StartPoint.LineNumber == location2.Value.StartPoint.LineNumber)
            {
                indexOnLine = Math.Min(location1.StartPoint.IndexOnLine, location2.Value.StartPoint.IndexOnLine);
                endIndexOnLine = Math.Max(location1.EndPoint.IndexOnLine, location2.Value.EndPoint.IndexOnLine);
            }
            else if (location1.StartPoint.LineNumber < location2.Value.StartPoint.LineNumber)
            {
                indexOnLine = location1.StartPoint.IndexOnLine;
                endIndexOnLine = location2.Value.EndPoint.IndexOnLine;
            }
            else
            {
                indexOnLine = location2.Value.StartPoint.IndexOnLine;
                endIndexOnLine = location1.EndPoint.IndexOnLine;
            }

            return new CodeLocation(
                Math.Min(location1.StartPoint.Index, location2.Value.StartPoint.Index),
                Math.Max(location1.EndPoint.Index, location2.Value.EndPoint.Index),
                indexOnLine,
                endIndexOnLine,
                Math.Min(location1.StartPoint.LineNumber, location2.Value.StartPoint.LineNumber),
                Math.Max(location2.Value.EndPoint.LineNumber, location2.Value.EndPoint.LineNumber));
        }

        /// <summary>
        /// Joins the two given locations.
        /// </summary>
        /// <param name="location1">
        /// The first location to join.
        /// </param>
        /// <param name="location2">
        /// The second location to join.
        /// </param>
        /// <returns>
        /// Returns the joined <see cref="CodeLocation"/>.
        /// </returns>
        public static CodeLocation Join(CodeLocation location1, CodeLocation location2)
        {
            Param.Ignore(location1, location2);

            // Figure out which IndexOnLine and EndIndexOnLine to use.
            int indexOnLine;
            int endIndexOnLine;
            if (location1.StartPoint.LineNumber == location2.StartPoint.LineNumber)
            {
                indexOnLine = Math.Min(location1.StartPoint.IndexOnLine, location2.StartPoint.IndexOnLine);
                endIndexOnLine = Math.Max(location1.EndPoint.IndexOnLine, location2.EndPoint.IndexOnLine);
            }
            else if (location1.StartPoint.LineNumber < location2.StartPoint.LineNumber)
            {
                indexOnLine = location1.StartPoint.IndexOnLine;
                endIndexOnLine = location2.EndPoint.IndexOnLine;
            }
            else
            {
                indexOnLine = location2.StartPoint.IndexOnLine;
                endIndexOnLine = location1.EndPoint.IndexOnLine;
            }

            return new CodeLocation(
                Math.Min(location1.StartPoint.Index, location2.StartPoint.Index),
                Math.Max(location1.EndPoint.Index, location2.EndPoint.Index),
                indexOnLine,
                endIndexOnLine,
                Math.Min(location1.StartPoint.LineNumber, location2.StartPoint.LineNumber),
                Math.Max(location2.EndPoint.LineNumber, location2.EndPoint.LineNumber));
        }

        #endregion
    }
}