// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeLexer.MarkerData.cs" company="https://github.com/StyleCop">
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
//   The code lexer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The code lexer.
    /// </summary>
    /// <content>
    /// Contains the MarkerData sub-class.
    /// </content>
    internal partial class CodeLexer
    {
        /// <summary>
        /// The current marker in the code.
        /// </summary>
        internal class MarkerData
        {
            #region Fields

            /// <summary>
            /// The index of the marker in the code.
            /// </summary>
            private int index;

            /// <summary>
            /// The index of the marker in the line on which it appears.
            /// </summary>
            private int indexOnLine;

            /// <summary>
            /// The line number of the marker index in the code.
            /// </summary>
            private int lineNumber = 1;

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets or sets the index of the marker in the code string.
            /// </summary>
            public int Index
            {
                get
                {
                    return this.index;
                }

                set
                {
                    Param.RequireGreaterThanOrEqualToZero(value, "Index");
                    this.index = value;
                }
            }

            /// <summary>
            /// Gets or sets the index of the marker in the line on which it appears.
            /// </summary>
            public int IndexOnLine
            {
                get
                {
                    return this.indexOnLine;
                }

                set
                {
                    Param.RequireGreaterThanOrEqualToZero(value, "IndexOnLine");
                    this.indexOnLine = value;
                }
            }

            /// <summary>
            /// Gets or sets the line number of the marker index.
            /// </summary>
            public int LineNumber
            {
                get
                {
                    return this.lineNumber;
                }

                set
                {
                    Param.RequireGreaterThanZero(value, "LineNumber");
                    this.lineNumber = value;
                }
            }

            #endregion
        }
    }
}