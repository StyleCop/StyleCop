// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeReader.cs" company="https://github.com/StyleCop">
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
//   Reads code from a text reader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    /// Reads code from a text reader.
    /// </summary>
    public class CodeReader
    {
        #region Constants

        /// <summary>
        /// The number of characters to read at a time from the text reader.
        /// </summary>
        private const int CharacterBlockSize = 80;

        #endregion

        #region Fields

        /// <summary>
        /// Contains the code to read.
        /// </summary>
        private readonly TextReader code;

        /// <summary>
        /// The number of characters in the buffer.
        /// </summary>
        private int bufferLength;

        /// <summary>
        /// Cached characters read from the text reader.
        /// </summary>
        private char[] charBuffer;

        /// <summary>
        /// The position of the next unread character in the character buffer.
        /// </summary>
        private int position;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CodeReader class.
        /// </summary>
        /// <param name="code">
        /// Contains the code to read.
        /// </param>
        public CodeReader(TextReader code)
        {
            Param.RequireNotNull(code, "code");
            this.code = code;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the next character from the code without advancing the internal pointer.
        /// </summary>
        /// <returns>Returns the next character from the code or char.MinValue if there are no more characters to read.</returns>
        public char Peek()
        {
            if (!this.LoadBuffer(1))
            {
                return char.MinValue;
            }

            return this.charBuffer[this.position];
        }

        /// <summary>
        /// Gets the next character from the code without advancing the internal pointer.
        /// </summary>
        /// <param name="index">
        /// The index of the character to retrieve, advanced from the current index.
        /// </param>
        /// <returns>
        /// Returns the next character from the code or char.MinValue if there are no more characters to read.
        /// </returns>
        [SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", Justification = "There is no danger of overflow.")]
        public char Peek(int index)
        {
            Param.Ignore(index);

            if (!this.LoadBuffer(index + 1))
            {
                return char.MinValue;
            }

            return this.charBuffer[this.position + index];
        }

        /// <summary>
        /// Gets the next non-whitespace character from the code without advancing the internal pointer.
        /// </summary>
        /// <param name="index">
        /// The index of the character to retrieve, advanced from the current index.
        /// </param>
        /// <returns>
        /// Returns the next non-whitespace character from the code or <see cref="char.MinValue"/> if there are no more 
        /// non-whitespace characters to read.
        /// </returns>
        public char PeekNonWhitespace(int index)
        {
            Param.Ignore(index);

            while (true)
            {
                char currChar = this.Peek(index);

                if (char.IsWhiteSpace(currChar) == false)
                {
                    // Found a non-whitespace character (could be char.MinValue) - return it.
                    return currChar;
                }

                // Keep looping.
                index++;
            }
        }

        /// <summary>
        /// Reads the next character from the code and advances the internal index.
        /// </summary>
        /// <returns>Returns the next character from the code or char.MinValue if there are no more characters to read.</returns>
        public char ReadNext()
        {
            if (!this.LoadBuffer(1))
            {
                return char.MinValue;
            }

            return this.charBuffer[this.position++];
        }

        /// <summary>
        /// Reads the given number of characters from the code and advances the internal index.
        /// </summary>
        /// <param name="count">
        /// The number of characters to read.
        /// </param>
        /// <returns>
        /// Returns the characters or null if all of the characters could not be read.
        /// </returns>
        public char[] ReadNext(int count)
        {
            Param.RequireGreaterThanOrEqualToZero(count, "count");

            if (!this.LoadBuffer(count))
            {
                return null;
            }

            char[] data = new char[count];
            for (int i = 0; i < count; ++i)
            {
                data[i] = this.charBuffer[this.position++];
            }

            return data;
        }

        /// <summary>
        /// Reads the given number of characters from the code as a string and advances the internal index.
        /// </summary>
        /// <param name="count">
        /// The number of characters to read.
        /// </param>
        /// <returns>
        /// Returns the string or null if all of the characters could not be read.
        /// </returns>
        public string ReadString(int count)
        {
            Param.RequireGreaterThanOrEqualToZero(count, "count");

            char[] characters = this.ReadNext(count);
            if (characters == null)
            {
                return null;
            }

            return new string(characters);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the internal character buffer with the requested number of characters.
        /// </summary>
        /// <param name="count">
        /// The number of characters to load.
        /// </param>
        /// <returns>
        /// Returns true if the characters were loaded, or false if the end 
        /// of the character source was reached before all the characters were loaded.
        /// </returns>
        private bool LoadBuffer(int count)
        {
            Param.AssertGreaterThanOrEqualToZero(count, "count");

            // Check whether there are already enough characters in the current buffer.
            if (this.bufferLength > this.position + count - 1)
            {
                Debug.Assert(this.charBuffer != null && this.charBuffer.Length > this.position + count - 1, "The buffer position is invalid.");
                return true;
            }

            // Create a new buffer large enough to contain the left over characters from the previous
            // buffer, as well as the new characters to read from the code.
            char[] newBuffer;

            int leftOverCharacterCount = this.bufferLength - this.position;

            if (this.charBuffer == null || ((CharacterBlockSize + leftOverCharacterCount) > this.charBuffer.Length))
            {
                // allocate a bigger buffer
                newBuffer = new char[CharacterBlockSize + leftOverCharacterCount];
            }
            else
            {
                // reuse the old buffer
                newBuffer = this.charBuffer;
            }

            if (this.charBuffer != null)
            {
                // Fill in any characters left over from the previous buffer.
                for (int i = 0; i < leftOverCharacterCount; ++i)
                {
                    newBuffer[i] = this.charBuffer[this.position + i];
                }
            }

            // Read the new set of characters from the code buffer.
            int numberOfCharactersRead = this.code.ReadBlock(newBuffer, leftOverCharacterCount, CharacterBlockSize);

            // Set the correct number of characters in the new buffer.
            this.bufferLength = leftOverCharacterCount + numberOfCharactersRead;

            // Save the new buffer and reset the position.
            this.position = 0;
            this.charBuffer = newBuffer;

            // Return true if the requested number of characters are in the buffer.
            return this.bufferLength >= count;
        }

        #endregion
    }
}