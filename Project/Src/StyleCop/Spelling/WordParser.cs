
namespace StyleCop.Spelling
{
    using System;
    using System.Text;

    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class WordParser
    {
        // Fields
        private readonly StringBuilder m_buffer;

        private int m_index;

        private readonly WordParserOptions m_options;

        private string m_peekedWord;

        private char m_prefix;

        private readonly string m_text;

        private const char NullChar = '\0';

        // Methods
        public WordParser(string text, WordParserOptions options)
            : this(text, options, '\0')
        {
        }

        internal WordParser(string text, WordParserOptions options, char prefix)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            if ((options < WordParserOptions.None) || (options > (WordParserOptions.SplitCompoundWords | WordParserOptions.IgnoreMnemonicsIndicators)))
            {
                throw new InvalidEnumArgumentException("options", (int)options, typeof(WordParserOptions));
            }
            this.m_text = text;
            this.m_options = options;
            this.m_buffer = new StringBuilder(text.Length);
            this.m_prefix = prefix;
        }

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

        private bool IsIgnored(char c)
        {
            if (!this.SkipMnemonics)
            {
                return false;
            }
            if (c != '&')
            {
                return (c == '_');
            }
            return true;
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
            return ((char.IsLetter(c) && !char.IsUpper(c)) && !char.IsLower(c));
        }

        private static bool IsLower(char c)
        {
            return char.IsLower(c);
        }

        private static bool IsUpper(char c)
        {
            return char.IsUpper(c);
        }

        public string NextWord()
        {
            if (this.m_peekedWord == null)
            {
                return this.NextWordCore();
            }
            string peekedWord = this.m_peekedWord;
            this.m_peekedWord = null;
            return peekedWord;
        }

        private string NextWordCore()
        {
            this.m_buffer.Length = 0;
            if (this.ParseNext())
            {
                return this.m_buffer.ToString();
            }
            return null;
        }

        public static Collection<string> Parse(string text, WordParserOptions options)
        {
            return Parse(text, options, '\0');
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
            for (int i = this.m_index; i < this.m_text.Length; i++)
            {
                char c = this.m_text[i];
                if (!this.IsIgnored(c) && (--lookAhead == 0))
                {
                    return c;
                }
            }
            return '\0';
        }

        public string PeekWord()
        {
            if (this.m_peekedWord == null)
            {
                this.m_peekedWord = this.NextWordCore();
            }
            return this.m_peekedWord;
        }

        private void Read()
        {
            char ch = this.Peek();
            this.m_buffer.Append(ch);
            this.Skip();
        }

        private void Skip()
        {
            while (this.m_index < this.m_text.Length)
            {
                char c = this.m_text[this.m_index++];
                if (!this.IsIgnored(c))
                {
                    return;
                }
            }
        }

        private bool TryParsePrefix()
        {
            if (this.m_prefix != '\0')
            {
                if ((this.Peek() == this.m_prefix) && !IsLower(this.Peek(2)))
                {
                    this.Read();
                    this.m_prefix = '\0';
                    return true;
                }
                this.m_prefix = '\0';
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
            while (this.m_index >= 0)
            {
                char c = this.m_text[--this.m_index];
                if (!this.IsIgnored(c))
                {
                    break;
                }
            }
            this.m_buffer.Length--;
        }

        // Properties
        private bool SkipMnemonics
        {
            get
            {
                return ((this.m_options & WordParserOptions.IgnoreMnemonicsIndicators) == WordParserOptions.IgnoreMnemonicsIndicators);
            }
        }

        private bool SplitCompoundWords
        {
            get
            {
                return ((this.m_options & WordParserOptions.SplitCompoundWords) == WordParserOptions.SplitCompoundWords);
            }
        }
    }
}
 

