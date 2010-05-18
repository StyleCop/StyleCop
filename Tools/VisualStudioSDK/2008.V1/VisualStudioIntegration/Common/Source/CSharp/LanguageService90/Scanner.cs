using System;

namespace Microsoft.VisualStudio.Package {
    /// <include file='doc\Scanner.uex' path='docs/doc[@for="IScanner"]/*' />
    /// <summary>
    /// Scans individual source lines and provides coloring and trigger information about tokens.
    /// </summary>
    public interface IScanner {
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="IScanner.SetSource"]/*' />
        /// <summary>
        /// Used to (re)initialize the scanner before scanning a small portion of text, such as single source line for syntax coloring purposes
        /// </summary>
        /// <param name="source">The source text portion to be scanned</param>
        /// <param name="offset">The index of the first character to be scanned</param>
        void SetSource(string source, int offset);

        /// <include file='doc\Scanner.uex' path='docs/doc[@for="IScanner.ScanTokenAndProvideInfoAboutIt"]/*' />
        /// <summary>
        /// Scan the next token and fill in syntax coloring details about it in tokenInfo.
        /// </summary>
        /// <param name="tokenInfo">Keeps information about token.</param>
        /// <param name="state">Keeps track of scanner state. In: state after last token. Out: state after current token.</param>
        /// <returns></returns>
        bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state);
    }
    /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenColor"]/*' />
    public enum TokenColor {
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenColor.Text"]/*' />
        Text,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenColor.Keyword"]/*' />
        Keyword,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenColor.Comment"]/*' />
        Comment,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenColor.Identifier"]/*' />
        Identifier,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenColor.String"]/*' />
        String,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenColor.Number"]/*' />
        Number
    }
    /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo"]/*' />
    public class TokenInfo {
        int startIndex;
        int endIndex;
        TokenColor color;
        TokenType type;
        TokenTriggers trigger;
        int token;

        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.StartIndex;"]/*' />
        public int StartIndex {
            get { return this.startIndex; }
            set { this.startIndex = value; }
        }
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.EndIndex;"]/*' />
        public int EndIndex {
            get { return this.endIndex; }
            set { this.endIndex = value; }
        }
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.Color;"]/*' />
        public TokenColor Color {
            get { return this.color; }
            set { this.color = value; }
        }
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.Type;"]/*' />
        public TokenType Type {
            get { return this.type; }
            set { this.type = value; }
        }
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.Trigger;"]/*' />
        public TokenTriggers Trigger {
            get { return this.trigger; }
            set { this.trigger = value; }
        }

        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.StartIndex;"]/*' />
        /// <summary>Language Specific</summary>
        public int Token {
            get { return token; }
            set { token = value; }
        }
        
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.TokenInfo"]/*' />
        public TokenInfo() { }
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenInfo.TokenInfo1"]/*' />
        public TokenInfo(int startIndex, int endIndex, TokenType type) { this.startIndex = startIndex; this.endIndex = endIndex; this.type = type; }
    }

    /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers"]/*' />
    /// <summary>
    /// TokenTriggers:
    /// If a character has (a) trigger(s) associated with it, it may
    /// fire one or both of the following triggers:
    /// MemberSelect - a member selection tip window
    /// MatchBraces - highlight matching braces
    /// or the following trigger:
    /// MethodTip - a method tip window
    ///     
    /// The following triggers exist for speed reasons: the (fast) lexer 
    /// determines when a (slow) parse might be needed. 
    /// The Trigger.MethodTip trigger is subdivided in 4 
    /// other triggers. It is the best to be as specific as possible;
    /// it is better to return Trigger.ParamStart than Trigger.Param
    /// (or Trigger.MethodTip) 
    /// </summary>
    [FlagsAttribute]
    public enum TokenTriggers {
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.None"]/*' />
        None = 0x00,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.MemberSelect"]/*' />
        MemberSelect = 0x01,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.MatchBraces"]/*' />
        MatchBraces = 0x02,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.MethodTip"]/*' />
        MethodTip = 0xF0,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.ParamStart"]/*' />
        ParameterStart = 0x10,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.ParamNext"]/*' />
        ParameterNext = 0x20,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.ParamEnd"]/*' />
        ParameterEnd = 0x40,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenTriggers.Param"]/*' />
        Parameter = 0x80
    }

    /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType"]/*' />
    public enum TokenType {
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Unknown"]/*' />
        Unknown,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Text"]/*' />
        Text,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Keyword"]/*' />
        Keyword,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Identifier"]/*' />
        Identifier,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.String"]/*' />
        String,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Literal"]/*' />
        Literal,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Operator"]/*' />
        Operator,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Delimiter"]/*' />
        Delimiter,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.WhiteSpace"]/*' />
        WhiteSpace,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.LineComment"]/*' />
        LineComment,
        /// <include file='doc\Scanner.uex' path='docs/doc[@for="TokenType.Comment"]/*' />
        Comment,
    }
}
