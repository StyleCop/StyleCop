// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordParser.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <summary>
//   The word parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Spelling
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Text;

    /// <summary>
    /// The word parser.
    /// </summary>
    public class WordParser
    {
        // Fields
        #region Constants

        private const char NullChar = '\0';

        #endregion

        #region Fields

        private readonly StringBuilder buffer;

        private readonly string text;

        private readonly WordParserOptions wordParserOptions;

        private int index;

        private string peekedWord;

        private char prefixChar;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordParser"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        public WordParser(string text, WordParserOptions options)
            : this(text, options, '\0')
        {
        }

        internal WordParser(string text, WordParserOptions options, char prefixChar)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if ((options < WordParserOptions.None) || (options > (WordParserOptions.SplitCompoundWords | WordParserOptions.IgnoreMnemonicsIndicators)))
            {
                throw new InvalidEnumArgumentException("options", (int)options, typeof(WordParserOptions));
            }

            this.text = text;
            this.wordParserOptions = options;
            this.buffer = new StringBuilder(text.Length);
            this.prefixChar = prefixChar;
        }

        #endregion

        #region Properties

        private bool SkipMnemonics
        {
            get
            {
                return (this.wordParserOptions & WordParserOptions.IgnoreMnemonicsIndicators) == WordParserOptions.IgnoreMnemonicsIndicators;
            }
        }

        private bool SplitCompoundWords
        {
            get
            {
                return (this.wordParserOptions & WordParserOptions.SplitCompoundWords) == WordParserOptions.SplitCompoundWords;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <returns>
        /// The System.Collections.ObjectModel.Collection.
        /// </returns>
        public static Collection<string> Parse(string text, WordParserOptions options)
        {
            return Parse(text, options, '\0');
        }

        /// <summary>
        /// The next word.
        /// </summary>
        /// <returns>
        /// The System.String.
        /// </returns>
        public string NextWord()
        {
            if (this.peekedWord == null)
            {
                return this.NextWordCore();
            }

            string returnValue = this.peekedWord;
            this.peekedWord = null;
            return returnValue;
        }

        /// <summary>
        /// The peek word.
        /// </summary>
        /// <returns>
        /// The System.String.
        /// </returns>
        public string PeekWord()
        {
            return this.peekedWord ?? (this.peekedWord = this.NextWordCore());
        }

        #endregion

        #region Methods

        internal static bool ContainsWord(string text, WordParserOptions options, params string[] words)
        {
            return ContainsWord(text, options, '\0', words);
        }

        internal static bool ContainsWord(string text, WordParserOptions options, char prefix, params string[] words)
        {
            string str;
            if (words == null)
            {
                throw new ArgumentNullException("words");
            }

            WordParser parser = new WordParser(text, options, prefix);
            while ((str = parser.NextWord()) != null)
            {
                foreach (string str2 in words)
                {
                    if (string.Equals(str, str2, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal static Collection<string> Parse(string text, WordParserOptions options, char prefix)
        {
            string str;
            WordParser parser = new WordParser(text, options, prefix);
            Collection<string> collection = new Collection<string>();
            while ((str = parser.NextWord()) != null)
            {
                collection.Add(str);
            }

            return collection;
        }

        private static bool IsDigit(char c)
        {
            return char.IsDigit(c);
        }

        private static bool IsHexDigit(char c)
        {
            switch (c)
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                    return true;
            }

            return IsDigit(c);
        }

        private static bool IsIntraWordPunctuation(char c)
        {
            switch (c)
            {
                case '\x00ad':
                case '’':
                case '\'':
                case '-':
                    return true;
            }

            return false;
        }

        private static bool IsLetterOrDigit(char c)
        {
            return char.IsLetterOrDigit(c);
        }

        private static bool IsLetterWithoutCase(char c)
        {
            return (char.IsLetter(c) && !char.IsUpper(c)) && !char.IsLower(c);
        }

        private static bool IsLower(char c)
        {
            return char.IsLower(c);
        }

        private static bool IsUpper(char c)
        {
            return char.IsUpper(c);
        }

        private bool IsIgnored(char c)
        {
            if (!this.SkipMnemonics)
            {
                return false;
            }

            if (c != '&')
            {
                return c == '_';
            }

            return true;
        }

        private string NextWordCore()
        {
            this.buffer.Length = 0;
            if (this.ParseNext())
            {
                return this.buffer.ToString();
            }

            return null;
        }

        private void ParseAllCaps()
        {
            char ch;
            do
            {
                this.Read();
                ch = this.Peek();
            }
            while (IsUpper(ch));
            if (ch == 's')
            {
                this.Read();
                ch = this.Peek();
            }

            while (IsLower(ch))
            {
                this.Unread();
                ch = this.Peek();
            }
        }

        private void ParseHex()
        {
            do
            {
                this.Read();
            }
            while (IsHexDigit(this.Peek()));
        }

        private void ParseInteger()
        {
            do
            {
                this.Read();
            }
            while (IsDigit(this.Peek()));
        }

        private void ParseLatex()
        {
            bool doubleDollar = false;

            // reads the first '$'
            this.Read();

            // second $ like $$thoptkhpoktphok$$
            if (this.Peek() == '$')
            {
                doubleDollar = true;
            }

            do
            {
                this.Read();
            }
            while (this.Peek() != '$' && this.Peek() != '\0');

            if (this.Peek() != '\0')
            {
                // the last '$' (or 2nd to last if $$.....$$ )
                this.Read();

                if (doubleDollar && this.Peek() == '$')
                {
                    this.Read();
                }
            }
        }

        private void ParseLowercase()
        {
            do
            {
                this.Read();
            }
            while (IsLower(this.Peek()));
        }

        private bool ParseNext()
        {
            char ch;
            if (this.TryParsePrefix())
            {
                return true;
            }

            char ch2 = '\0';
            while ((ch = this.Peek()) != '\0')
            {
                if (!this.TryParseWord(ch))
                {
                    if (ch2 != '\0')
                    {
                        this.Unread();
                        this.Skip();
                        return true;
                    }

                    this.Skip();
                }
                else
                {
                    ch = this.Peek();
                    if (IsIntraWordPunctuation(ch))
                    {
                        ch2 = ch;
                        this.Read();
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            if (ch2 != '\0')
            {
                this.Unread();
                return true;
            }

            return false;
        }

        private void ParseNumeric()
        {
            if (this.Peek() == '0')
            {
                char ch = this.Peek(2);
                if (((ch == 'x') || (ch == 'X')) && IsHexDigit(this.Peek(3)))
                {
                    this.Read();
                    this.Read();
                    this.ParseHex();
                    return;
                }
            }

            this.ParseInteger();
        }

        private void ParseUppercase()
        {
            this.Read();
            char c = this.Peek();
            if (IsUpper(c))
            {
                this.ParseAllCaps();
            }
            else if (IsLower(c))
            {
                this.ParseLowercase();
            }
        }

        private void ParseWholeWord()
        {
            do
            {
                this.Read();
            }
            while (IsLetterOrDigit(this.Peek()));
        }

        private void ParseWithoutCase()
        {
            do
            {
                this.Read();
            }
            while (IsLetterWithoutCase(this.Peek()));
        }

        private char Peek()
        {
            return this.Peek(1);
        }

        private char Peek(int lookAhead)
        {
            for (int i = this.index; i < this.text.Length; i++)
            {
                char c = this.text[i];
                if (!this.IsIgnored(c) && (--lookAhead == 0))
                {
                    return c;
                }
            }

            return '\0';
        }

        private void Read()
        {
            char ch = this.Peek();
            this.buffer.Append(ch);
            this.Skip();
        }

        private void Skip()
        {
            while (this.index < this.text.Length)
            {
                char c = this.text[this.index++];
                if (!this.IsIgnored(c))
                {
                    return;
                }
            }
        }

        private bool TryParsePrefix()
        {
            if (this.prefixChar != '\0')
            {
                if ((this.Peek() == this.prefixChar) && !IsLower(this.Peek(2)))
                {
                    this.Read();
                    this.prefixChar = '\0';
                    return true;
                }

                this.prefixChar = '\0';
            }

            return false;
        }

        private bool TryParseWord(char c)
        {
            if (this.SplitCompoundWords)
            {
                if (IsUpper(c))
                {
                    this.ParseUppercase();
                    return true;
                }

                if (IsLower(c))
                {
                    this.ParseLowercase();
                    return true;
                }

                if (IsDigit(c))
                {
                    this.ParseNumeric();
                    return true;
                }

                if (IsLetterWithoutCase(c))
                {
                    this.ParseWithoutCase();
                    return true;
                }

                if ((c == '#') && IsHexDigit(this.Peek(2)))
                {
                    this.ParseHex();
                    return true;
                }

                if (c == '$')
                {
                    int i = 2;
                    char peek;
                    do
                    {
                        peek = this.Peek(i);
                        i++;
                    }
                    while (peek != '$' && peek != '\0');

                    if (peek == '$')
                    {
                        this.ParseLatex();
                        return true;
                    }
                }
            }
            else if (IsLetterOrDigit(c))
            {
                this.ParseWholeWord();
                return true;
            }

            return false;
        }

        private void Unread()
        {
            while (this.index >= 0)
            {
                char c = this.text[--this.index];
                if (!this.IsIgnored(c))
                {
                    break;
                }
            }

            this.buffer.Length--;
        }

        #endregion
    }
}