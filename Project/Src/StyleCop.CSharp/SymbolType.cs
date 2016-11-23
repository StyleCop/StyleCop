// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SymbolType.cs" company="https://github.com/StyleCop">
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
//   The various symbol types from a C# document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various symbol types from a C# document.
    /// </summary>
    internal enum SymbolType
    {
        /// <summary>
        /// Open parenthesis: '('.
        /// </summary>
        OpenParenthesis, 

        /// <summary>
        /// Close parenthesis: ')'.
        /// </summary>
        CloseParenthesis, 

        /// <summary>
        /// Open Curly bracket: '{'.
        /// </summary>
        OpenCurlyBracket, 

        /// <summary>
        /// Close Curly bracket: '}'.
        /// </summary>
        CloseCurlyBracket, 

        /// <summary>
        /// Open square bracket: '['.
        /// </summary>
        OpenSquareBracket, 

        /// <summary>
        /// Close square bracket: ']'.
        /// </summary>
        CloseSquareBracket, 

        /// <summary>
        /// An equals sign: '='.
        /// </summary>
        Equals, 

        /// <summary>
        /// A conditional equals symbol: '=='.
        /// </summary>
        ConditionalEquals, 

        /// <summary>
        /// A plus sign: '+'.
        /// </summary>
        Plus, 

        /// <summary>
        /// A plus equals symbol: '+='.
        /// </summary>
        PlusEquals, 

        /// <summary>
        /// A minus sign: '-'.
        /// </summary>
        Minus, 

        /// <summary>
        /// A minus equals symbol: '-='.
        /// </summary>
        MinusEquals, 

        /// <summary>
        /// A multiplication sign: '*'.
        /// </summary>
        Multiplication, 

        /// <summary>
        /// A times equals symbol: '*='.
        /// </summary>
        MultiplicationEquals, 

        /// <summary>
        /// A division sign: '/'.
        /// </summary>
        Division, 

        /// <summary>
        /// A divide equals symbol: '/='.
        /// </summary>
        DivisionEquals, 

        /// <summary>
        /// A less-than sign.
        /// </summary>
        LessThan, 

        /// <summary>
        /// A less than or equals sign.
        /// </summary>
        LessThanOrEquals, 

        /// <summary>
        /// A left-shift symbol.
        /// </summary>
        LeftShift, 

        /// <summary>
        /// A left-shift equals sign.
        /// </summary>
        LeftShiftEquals, 

        /// <summary>
        /// A greater-than sign.
        /// </summary>
        GreaterThan, 

        /// <summary>
        /// A greater than or equals sign.
        /// </summary>
        GreaterThanOrEquals, 

        /// <summary>
        /// A right-shift symbol.
        /// </summary>
        RightShift, 

        /// <summary>
        /// A right-shift equals sign.
        /// </summary>
        RightShiftEquals, 

        /// <summary>
        /// An increment symbol: '++'.
        /// </summary>
        Increment, 

        /// <summary>
        /// A decrement symbol: '--'.
        /// </summary>
        Decrement, 

        /// <summary>
        /// A logical AND symbol.
        /// </summary>
        LogicalAnd, 

        /// <summary>
        /// An AND equals symbol.
        /// </summary>
        AndEquals, 

        /// <summary>
        /// A conditional AND symbol.
        /// </summary>
        ConditionalAnd, 

        /// <summary>
        /// A logical OR symbol: '|'.
        /// </summary>
        LogicalOr, 

        /// <summary>
        /// An OR equals symbol: '|='.
        /// </summary>
        OrEquals, 

        /// <summary>
        /// A conditional OR symbol: '||'.
        /// </summary>
        ConditionalOr, 

        /// <summary>
        /// A logical XOR symbol: '^'.
        /// </summary>
        LogicalXor, 

        /// <summary>
        /// An XOR equals symbol: '^='.
        /// </summary>
        XorEquals, 

        /// <summary>
        /// A NOT symbol: '!'.
        /// </summary>
        Not, 

        /// <summary>
        /// A NOT equals symbol: '!='.
        /// </summary>
        NotEquals, 

        /// <summary>
        /// A MOD symbol: '%'.
        /// </summary>
        Mod, 

        /// <summary>
        /// A MOD equals symbol: '%='.
        /// </summary>
        ModEquals, 

        /// <summary>
        /// A dot: '.'.
        /// </summary>
        Dot, 

        /// <summary>
        /// A pointer symbol: '->'.
        /// </summary>
        Pointer, 

        /// <summary>
        /// A colon: ':'.
        /// </summary>
        Colon, 

        /// <summary>
        /// A qualified alias symbol: '::'.
        /// </summary>
        QualifiedAlias, 

        /// <summary>
        /// A question mark: '?'.
        /// </summary>
        QuestionMark, 

        /// <summary>
        /// A null coalescing symbol: '??'.
        /// </summary>
        NullCoalescingSymbol, 

        /// <summary>
        /// A comma: ','.
        /// </summary>
        Comma, 

        /// <summary>
        /// A semicolon ending a line of code: ';'.
        /// </summary>
        Semicolon, 

        /// <summary>
        /// A tilde symbol: '~'.
        /// </summary>
        Tilde, 

        /// <summary>
        /// A lambda expression symbol: =>
        /// </summary>
        Lambda, 

        /// <summary>
        /// The keyword 'abstract'.
        /// </summary>
        Abstract, 

        /// <summary>
        /// The keyword 'as'.
        /// </summary>
        As, 

        /// <summary>
        /// The keyword 'base'.
        /// </summary>
        Base, 

        /// <summary>
        /// The keyword 'break'.
        /// </summary>
        Break, 

        /// <summary>
        /// The keyword 'case'.
        /// </summary>
        Case, 

        /// <summary>
        /// The keyword 'catch'.
        /// </summary>
        Catch, 

        /// <summary>
        /// The keyword 'checked'.
        /// </summary>
        Checked, 

        /// <summary>
        /// The keyword 'class'.
        /// </summary>
        Class, 

        /// <summary>
        /// The keyword <see langword="const"/>.
        /// </summary>
        Const, 

        /// <summary>
        /// The keyword 'continue'.
        /// </summary>
        Continue, 

        /// <summary>
        /// The keyword 'default'.
        /// </summary>
        Default, 

        /// <summary>
        /// The keyword 'delegate'.
        /// </summary>
        Delegate, 

        /// <summary>
        /// The keyword 'do'.
        /// </summary>
        Do, 

        /// <summary>
        /// The keyword 'else'.
        /// </summary>
        Else, 

        /// <summary>
        /// The keyword '<see cref="Enum"/>'.
        /// </summary>
        Enum, 

        /// <summary>
        /// The keyword 'event'.
        /// </summary>
        Event, 

        /// <summary>
        /// The keyword 'explicit'.
        /// </summary>
        Explicit, 

        /// <summary>
        /// The keyword 'extern'.
        /// </summary>
        Extern, 

        /// <summary>
        /// The keyword 'false'.
        /// </summary>
        False, 

        /// <summary>
        /// The keyword 'finally'.
        /// </summary>
        Finally, 

        /// <summary>
        /// The keyword 'fixed'.
        /// </summary>
        Fixed, 

        /// <summary>
        /// The keyword 'for'.
        /// </summary>
        For, 

        /// <summary>
        /// The keyword 'foreach'.
        /// </summary>
        Foreach, 

        /// <summary>
        /// The keyword 'goto'.
        /// </summary>
        Goto, 

        /// <summary>
        /// The keyword 'if'.
        /// </summary>
        If, 

        /// <summary>
        /// The keyword 'implicit'.
        /// </summary>
        Implicit, 

        /// <summary>
        /// The keyword 'in'.
        /// </summary>
        In, 

        /// <summary>
        /// The keyword 'interface'.
        /// </summary>
        Interface, 

        /// <summary>
        /// The keyword 'internal'.
        /// </summary>
        Internal, 

        /// <summary>
        /// The keyword 'is'.
        /// </summary>
        Is, 

        /// <summary>
        /// The keyword 'lock'.
        /// </summary>
        Lock, 

        /// <summary>
        /// The keyword 'namespace'.
        /// </summary>
        Namespace, 

        /// <summary>
        /// The keyword 'new'.
        /// </summary>
        New, 

        /// <summary>
        /// The keyword 'null'.
        /// </summary>
        Null, 

        /// <summary>
        /// The keyword 'operator'.
        /// </summary>
        Operator, 

        /// <summary>
        /// The keyword 'out'.
        /// </summary>
        Out, 

        /// <summary>
        /// The keyword 'override'.
        /// </summary>
        Override, 

        /// <summary>
        /// The keyword '<c>params</c>'.
        /// </summary>
        Params, 

        /// <summary>
        /// The keyword 'private'.
        /// </summary>
        Private, 

        /// <summary>
        /// The keyword 'protected'.
        /// </summary>
        Protected, 

        /// <summary>
        /// The keyword 'public'.
        /// </summary>
        Public, 

        /// <summary>
        /// The keyword 'readonly'.
        /// </summary>
        Readonly, 

        /// <summary>
        /// The keyword 'ref'.
        /// </summary>
        Ref, 

        /// <summary>
        /// The keyword 'return'.
        /// </summary>
        Return, 

        /// <summary>
        /// The keyword 'sealed'.
        /// </summary>
        Sealed, 

        /// <summary>
        /// The keyword 'sizeof'.
        /// </summary>
        Sizeof, 

        /// <summary>
        /// The keyword 'stackalloc'.
        /// </summary>
        Stackalloc, 

        /// <summary>
        /// The keyword 'static'.
        /// </summary>
        Static, 

        /// <summary>
        /// The keyword 'struct'.
        /// </summary>
        Struct, 

        /// <summary>
        /// The keyword 'switch'.
        /// </summary>
        Switch, 

        /// <summary>
        /// The keyword 'this'.
        /// </summary>
        This, 

        /// <summary>
        /// The keyword 'throw'.
        /// </summary>
        Throw, 

        /// <summary>
        /// The keyword 'true'.
        /// </summary>
        True, 

        /// <summary>
        /// The keyword 'try'.
        /// </summary>
        Try, 

        /// <summary>
        /// The keyword 'typeof'.
        /// </summary>
        Typeof, 

        /// <summary>
        /// The keyword 'unchecked'.
        /// </summary>
        Unchecked, 

        /// <summary>
        /// The keyword 'unsafe'.
        /// </summary>
        Unsafe, 

        /// <summary>
        /// The keyword 'using'.
        /// </summary>
        Using, 

        /// <summary>
        /// The keyword 'virtual'.
        /// </summary>
        Virtual, 

        /// <summary>
        /// The keyword 'volatile'.
        /// </summary>
        Volatile, 

        /// <summary>
        /// The keyword 'while'.
        /// </summary>
        While, 

        /// <summary>
        /// An unknown token.
        /// </summary>
        Other, 

        /// <summary>
        /// A group of whitespace.
        /// </summary>
        WhiteSpace, 

        /// <summary>
        /// An end-of-line character.
        /// </summary>
        EndOfLine, 

        /// <summary>
        /// A string constant.
        /// </summary>
        String, 

        /// <summary>
        /// A number constant.
        /// </summary>
        Number, 

        /// <summary>
        /// A single-line comment.
        /// </summary>
        SingleLineComment, 

        /// <summary>
        /// A multi-line comment.
        /// </summary>
        MultiLineComment, 

        /// <summary>
        /// A preprocessor line.
        /// </summary>
        PreprocessorDirective, 

        /// <summary>
        /// An element attribute.
        /// </summary>
        Attribute, 

        /// <summary>
        /// A line within an Xml header.
        /// </summary>
        XmlHeaderLine,

        /// <summary>
        /// The keyword 'nameof'.
        /// </summary>
        NameOf,

        /// <summary>
        /// The null conditional operator ?.
        /// </summary>
        NullConditional,
    }
}