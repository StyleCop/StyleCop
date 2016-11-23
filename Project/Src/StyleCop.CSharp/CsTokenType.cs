// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsTokenType.cs" company="https://github.com/StyleCop">
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
//   The various <see cref="CsToken" /> types from a C# document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The various <see cref="CsToken"/> types from a C# document.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public enum CsTokenType
    {
        /// <summary>
        /// An open parenthesis: '('.
        /// </summary>
        OpenParenthesis, 

        /// <summary>
        /// A close parenthesis: ')'.
        /// </summary>
        CloseParenthesis, 

        /// <summary>
        /// An opening curly bracket: '{'.
        /// </summary>
        OpenCurlyBracket, 

        /// <summary>
        /// A closing curly bracket: '}'.
        /// </summary>
        CloseCurlyBracket, 

        /// <summary>
        /// An open square bracket: '['.
        /// </summary>
        OpenSquareBracket, 

        /// <summary>
        /// A close square bracket: ']'.
        /// </summary>
        CloseSquareBracket, 

        /// <summary>
        /// The opening bracket in a generic statement (a less-than sign).
        /// </summary>
        OpenGenericBracket, 

        /// <summary>
        /// The closing bracket in a generic statement (a greater-than sign).
        /// </summary>
        CloseGenericBracket, 

        /// <summary>
        /// An operator symbol.
        /// </summary>
        OperatorSymbol, 

        /// <summary>
        /// A colon preceding a base class initialization.
        /// </summary>
        BaseColon, 

        /// <summary>
        /// A colon in a 'where' statement.
        /// </summary>
        WhereColon, 

        /// <summary>
        /// A colon in an attribute.
        /// </summary>
        AttributeColon, 

        /// <summary>
        /// A colon after a label, case, or default keyword.
        /// </summary>
        LabelColon, 

        /// <summary>
        /// A comma: ','.
        /// </summary>
        Comma, 

        /// <summary>
        /// A semicolon ending a line of code: ';'.
        /// </summary>
        Semicolon, 

        /// <summary>
        /// A <c>nullable-type</c> symbol: '?'.
        /// </summary>
        NullableTypeSymbol, 

        /// <summary>
        /// The keyword 'abstract'.
        /// </summary>
        Abstract, 

        /// <summary>
        /// The keyword 'add'.
        /// </summary>
        Add, 

        /// <summary>
        /// The keyword 'alias'.
        /// </summary>
        Alias, 

        /// <summary>
        /// The keyword 'as'.
        /// </summary>
        As, 

        /// <summary>
        /// The keyword 'ascending'.
        /// </summary>
        Ascending, 

        /// <summary>
        /// The keyword 'base'.
        /// </summary>
        Base, 

        /// <summary>
        /// The keyword 'break'.
        /// </summary>
        Break, 

        /// <summary>
        /// The keyword 'by'.
        /// </summary>
        By, 

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
        /// The keyword 'default', as used in a switch statement.
        /// </summary>
        Default, 

        /// <summary>
        /// The keyword 'default', as used in a default-value expression.
        /// </summary>
        DefaultValue, 

        /// <summary>
        /// The keyword 'delegate'.
        /// </summary>
        Delegate, 

        /// <summary>
        /// The keyword 'descending'.
        /// </summary>
        Descending, 

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
        /// The keyword 'equals'.
        /// </summary>
        Equals, 

        /// <summary>
        /// The keyword 'event'.
        /// </summary>
        Event, 

        /// <summary>
        /// The keyword 'explicit'.
        /// </summary>
        Explicit, 

        /// <summary>
        /// The keyword 'extern' in a method declaration.
        /// </summary>
        Extern, 

        /// <summary>
        /// The keyword 'extern' in an extern alias directive.
        /// </summary>
        ExternDirective, 

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
        /// The keyword 'from'.
        /// </summary>
        From, 

        /// <summary>
        /// The keyword 'get'.
        /// </summary>
        Get, 

        /// <summary>
        /// The keyword 'goto'.
        /// </summary>
        Goto, 

        /// <summary>
        /// The keyword 'group'.
        /// </summary>
        Group, 

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
        /// The keyword 'into'.
        /// </summary>
        Into, 

        /// <summary>
        /// The keyword 'is'.
        /// </summary>
        Is, 

        /// <summary>
        /// The keyword 'join'.
        /// </summary>
        Join, 

        /// <summary>
        /// The keyword 'let'.
        /// </summary>
        Let, 

        /// <summary>
        /// The keyword 'lock'.
        /// </summary>
        Lock,

        /// <summary>
        /// The keyword 'nameof'.
        /// </summary>
        Nameof,

        /// <summary>
        /// The keyword 'namespace'.
        /// </summary>
        Namespace, 

        /// <summary>
        /// The keyword 'new'.
        /// </summary>
        New, 

        /// <summary>
        /// The keyword 'Null'.
        /// </summary>
        Null, 

        /// <summary>
        /// The keyword 'On'.
        /// </summary>
        On, 

        /// <summary>
        /// The keyword 'Operator'.
        /// </summary>
        Operator, 

        /// <summary>
        /// The keyword 'OrderBy'.
        /// </summary>
        OrderBy, 

        /// <summary>
        /// The keyword 'Out'.
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
        /// The keyword 'partial'.
        /// </summary>
        Partial, 

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
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Readonly", 
            Justification = "API has already been published and should not be changed.")]
        Readonly, 

        /// <summary>
        /// The keyword 'ref'.
        /// </summary>
        Ref, 

        /// <summary>
        /// The keyword 'remove'.
        /// </summary>
        Remove, 

        /// <summary>
        /// The keyword 'return'.
        /// </summary>
        Return, 

        /// <summary>
        /// The keyword 'sealed'.
        /// </summary>
        Sealed, 

        /// <summary>
        /// The keyword 'select'.
        /// </summary>
        Select, 

        /// <summary>
        /// The keyword 'set'.
        /// </summary>
        Set, 

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
        /// The keyword 'using' in a using-statement.
        /// </summary>
        Using, 

        /// <summary>
        /// The keyword 'using' in a using-directive.
        /// </summary>
        UsingDirective, 

        /// <summary>
        /// The keyword 'virtual'.
        /// </summary>
        Virtual, 

        /// <summary>
        /// The keyword 'volatile'.
        /// </summary>
        Volatile, 

        /// <summary>
        /// The keyword 'where'.
        /// </summary>
        Where, 

        /// <summary>
        /// The keyword 'while'.
        /// </summary>
        While, 

        /// <summary>
        /// The keyword 'while' at the end of a do/while statement.
        /// </summary>
        WhileDo, 

        /// <summary>
        /// The keyword 'yield'.
        /// </summary>
        Yield, 

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
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi", 
            Justification = "Named to be consistent with casing of SingleLineComment.")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "MultiLine", 
            Justification = "Named to be consistent with casing of SingleLineComment.")]
        MultiLineComment, 

        /// <summary>
        /// A preprocessor directive.
        /// </summary>
        PreprocessorDirective, 

        /// <summary>
        /// An element or assembly attribute.
        /// </summary>
        Attribute, 

        /// <summary>
        /// A square bracket opening an attribute.
        /// </summary>
        OpenAttributeBracket, 

        /// <summary>
        /// A square bracket closing an attribute.
        /// </summary>
        CloseAttributeBracket, 

        /// <summary>
        /// An Xml header.
        /// </summary>
        XmlHeader, 

        /// <summary>
        /// A line within an Xml header.
        /// </summary>
        XmlHeaderLine, 

        /// <summary>
        /// The tilde before the name of a destructor.
        /// </summary>
        DestructorTilde, 

        /// <summary>
        /// The async keyword.
        /// </summary>
        Async, 

        /// <summary>
        /// The await keyword.
        /// </summary>
        Await,

        /// <summary>
        /// The when keyword.
        /// </summary>
        When,
    }
}