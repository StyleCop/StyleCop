//-----------------------------------------------------------------------
// <copyright file="SymbolManager.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Provides support for reading through a symbol list.
    /// </summary>
    internal class SymbolManager
    {
        #region Private Fields

        /// <summary>
        /// The symbol list.
        /// </summary>
        private List<Symbol> symbols;

        /// <summary>
        /// The current index into the list.
        /// </summary>
        private int index = -1;

        /// <summary>
        /// Keeps a count of the number of generated blocks currently entered into.
        /// </summary>
        private int generatedCodeCount;

        /// <summary>
        /// Holds the region stack.
        /// </summary>
        private Stack<RegionDirective> regions = new Stack<RegionDirective>();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the SymbolManager class.
        /// </summary>
        /// <param name="symbols">The list of symbols to manage.</param>
        public SymbolManager(List<Symbol> symbols)
        {
            Param.AssertNotNull(symbols, "symbols");
            this.symbols = symbols;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the symbol at the current index is within a generated code block.
        /// </summary>
        public bool Generated
        {
            get
            {
                return this.generatedCodeCount > 0;
            }
        }

        /// <summary>
        /// Gets the current symbol.
        /// </summary>
        public Symbol Current
        {
            get
            {
                if (this.index >= 0 && this.index < this.symbols.Count)
                {
                    return this.symbols[this.index];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the current index.
        /// </summary>
        public int CurrentIndex
        {
            get
            {
                return this.index;
            }

            set
            {
                Param.RequireGreaterThanOrEqualToZero(value, "CurrentIndex");
                this.index = value;
            }
        }

        #endregion Public Properties

        #region Public Indexers

        /// <summary>
        /// Gets the symbol at the given index.
        /// </summary>
        /// <param name="symbolIndex">The index of the symbol to retrieve.</param>
        /// <returns>Returns the symbol at the given index.</returns>
        public Symbol this[int symbolIndex]
        {
            get
            {
                if (symbolIndex >= 0 && symbolIndex < this.symbols.Count)
                {
                    return this.symbols[symbolIndex];
                }

                return null;
            }
        }

        #endregion Public Indexers

        #region Public Methods

        /// <summary>
        /// Advances to the next index.
        /// </summary>
        public void Advance()
        {
            ++this.index;
        }

        /*
        /// <summary>
        /// Advances the index by the specified amount.
        /// </summary>
        /// <param name="count">The number of indexes to advance.</param>
        public void Advance(int count)
        {
            Param.Ignore(count);
            this.index += count;
        }
        */

        /// <summary>
        /// Gets the symbol at the given location in the list, without advancing the current index.
        /// </summary>
        /// <param name="count">The number of indexes to jump ahead of the current index.</param>
        /// <returns>Returns the symbol or null if the end of the list has been exceeded.</returns>
        public Symbol Peek(int count)
        {
            Param.Ignore(count);

            if (this.index + count < this.symbols.Count)
            {
                return this.symbols[this.index + count];
            }

            return null;
        }

        /// <summary>
        /// Increments the generated code blocks counter.
        /// </summary>
        public void IncrementGeneratedCodeBlocks()
        {
            ++this.generatedCodeCount;
        }

        /// <summary>
        /// Decrements the generated code blocks counter.
        /// </summary>
        public void DecrementGeneratedCodeBlocks()
        {
            --this.generatedCodeCount;
        }

        /// <summary>
        /// Pushes a region onto the region stack.
        /// </summary>
        /// <param name="region">The region to add.</param>
        public void PushRegion(RegionDirective region)
        {
            Param.AssertNotNull(region, "region");

            this.regions.Push(region);
            if (region.IsGeneratedCodeRegion)
            {
                this.IncrementGeneratedCodeBlocks();
            }
        }

        /// <summary>
        /// Pops a region from the region stack.
        /// </summary>
        /// <returns>Returns the popped region.</returns>
        public RegionDirective PopRegion()
        {
            if (this.regions.Count > 0)
            {
                RegionDirective region = this.regions.Pop();
                if (region != null && region.IsGeneratedCodeRegion)
                {
                    this.DecrementGeneratedCodeBlocks();
                }

                return region;
            }

            return null;
        }

        /// <summary>
        /// Combines a range of symbols into a single symbol.
        /// </summary>
        /// <param name="startIndex">The start peek index of the first symbol to combine.</param>
        /// <param name="endIndex">The end peek index of the last symbol to combine.</param>
        /// <param name="text">The text for the new symbol.</param>
        /// <param name="type">The type of the new symbol.</param>
        public void Combine(int startIndex, int endIndex, string text, SymbolType type)
        {
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Param.AssertGreaterThanOrEqualTo(endIndex, startIndex, "endIndex");
            Param.AssertValidString(text, "text");
            Param.Ignore(type);

            // Adjust the indexes.
            int adjustedStartIndex = startIndex + this.index;
            int adjustedEndIndex = endIndex + this.index;

            Debug.Assert(adjustedStartIndex >= 0 && adjustedStartIndex < this.symbols.Count, "The adjusted start index should be within the symbol list");
            Debug.Assert(adjustedEndIndex >= 0 && adjustedEndIndex < this.symbols.Count, "The adjusted end index should be within the symbol list");

            // Map the new location of the combined symbol.
            CodeLocation location = CodeLocation.Join(
                this.symbols[adjustedStartIndex].Location, this.symbols[adjustedEndIndex].Location);

            // Create the new symbol.
            var symbol = new Symbol(text, type, location);

            // Replace the first symbol.
            this.symbols[adjustedStartIndex] = symbol;

            // Remove the rest of the symbols.
            ++adjustedStartIndex;
            if (adjustedStartIndex <= adjustedEndIndex)
            {
                this.symbols.RemoveRange(adjustedStartIndex, adjustedEndIndex - adjustedStartIndex + 1);
            }
        }

        #endregion Public Methods
    }
}
