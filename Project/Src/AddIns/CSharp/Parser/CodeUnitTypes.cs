//-----------------------------------------------------------------------
// <copyright file="CodeUnitTypes.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The various types of code units.
    /// </summary>
    public enum CodeUnitType
    {
        /// <summary>
        /// No code units match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// A primitive lexical element.
        /// </summary>
        LexicalElement = 0x01000000,

        /// <summary>
        /// An element.
        /// </summary>
        Element = 0x02000000,

        /// <summary>
        /// A statement.
        /// </summary>
        Statement = 0x03000000,

        /// <summary>
        /// An expression.
        /// </summary>
        Expression = 0x04000000,

        /// <summary>
        /// A query clause.
        /// </summary>
        QueryClause = 0x05000000,

        /// <summary>
        /// An attribute on an element.
        /// </summary>
        Attribute = 0x06000000,

        /// <summary>
        /// A type parameter constraint.
        /// </summary>
        TypeParameterConstraintClause = 0x07000000,

        /// <summary>
        /// A formal parameter list.
        /// </summary>
        ParameterList = 0x08000000,

        /// <summary>
        /// A parameter within a formal parameter list.
        /// </summary>
        Parameter = 0x09000000,

        /// <summary>
        /// An argument list.
        /// </summary>
        ArgumentList = 0x10000000,

        /// <summary>
        /// An argument with an argument list.
        /// </summary>
        Argument = 0x11000000,

        /// <summary>
        /// All types of code units.
        /// </summary>
        All = 0x7FFFFFFF // This is set to the largest positive number.
    }

    /// <summary>
    /// The various <see cref="LexicalElement"/> types from a C# document.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public enum LexicalElementType
    {
        /// <summary>
        /// No lexical element types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// A comment.
        /// </summary>
        Comment = 0x01010000,

        /// <summary>
        /// An end-of-line character.
        /// </summary>
        EndOfLine = 0x01020000,

        /// <summary>
        /// A preprocessor directive.
        /// </summary>
        PreprocessorDirective = 0x01030000,

        /// <summary>
        /// A code token.
        /// </summary>
        Token = 0x01040000,

        /// <summary>
        /// A group of whitespace.
        /// </summary>
        WhiteSpace = 0x01050000,
    }

    /// <summary>
    /// The various <see cref="Token"/> types from a C# document.
    /// </summary>
    /// <subcategory>token</subcategory>
    public enum TokenType
    {
        /// <summary>
        /// No token types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// An open parenthesis: '('.
        /// </summary>
        OpenParenthesis = 0x01040100,

        /// <summary>
        /// A close parenthesis: ')'.
        /// </summary>
        CloseParenthesis = 0x01040200,

        /// <summary>
        /// An opening curly bracket: '{'.
        /// </summary>
        OpenCurlyBracket = 0x01040300,

        /// <summary>
        /// A closing curly bracket: '}'.
        /// </summary>
        CloseCurlyBracket = 0x01040400,

        /// <summary>
        /// An open square bracket: '['.
        /// </summary>
        OpenSquareBracket = 0x01040500,

        /// <summary>
        /// A close square bracket: ']'.
        /// </summary>
        CloseSquareBracket = 0x01040600,

        /// <summary>
        /// The opening bracket in a generic statement (a less-than sign).
        /// </summary>
        OpenGenericBracket = 0x01040700,

        /// <summary>
        /// The closing bracket in a generic statement (a greater-than sign).
        /// </summary>
        CloseGenericBracket = 0x01040800,

        /// <summary>
        /// An operator symbol.
        /// </summary>
        OperatorSymbol = 0x01040900,

        /// <summary>
        /// A colon preceding a base class initialization.
        /// </summary>
        BaseColon = 0x01040a00,

        /// <summary>
        /// A colon in a 'where' statement.
        /// </summary>
        WhereColon = 0x01040b00,

        /// <summary>
        /// A colon in an attribute.
        /// </summary>
        AttributeColon = 0x01040c00,

        /// <summary>
        /// A colon after a label, case, or default keyword.
        /// </summary>
        LabelColon = 0x01040d00,

        /// <summary>
        /// A comma: ','.
        /// </summary>
        Comma = 0x01040e00,

        /// <summary>
        /// A semicolon ending a line of code: ';'.
        /// </summary>
        Semicolon = 0x01040f00,

        /// <summary>
        /// A nullable-type symbol: '?'.
        /// </summary>
        NullableTypeSymbol = 0x01041000,

        /// <summary>
        /// The keyword 'abstract'.
        /// </summary>
        Abstract = 0x01041100,

        /// <summary>
        /// The keyword 'add'.
        /// </summary>
        Add = 0x01041200,

        /// <summary>
        /// The keyword 'alias'.
        /// </summary>
        Alias = 0x01041300,

        /// <summary>
        /// The keyword 'as'.
        /// </summary>
        As = 0x01041400,

        /// <summary>
        /// The keyword 'ascending'.
        /// </summary>
        Ascending = 0x01041500,

        /// <summary>
        /// The keyword 'base'.
        /// </summary>
        Base = 0x01041600,

        /// <summary>
        /// The keyword 'break'.
        /// </summary>
        Break = 0x01041700,

        /// <summary>
        /// The keyword 'by'.
        /// </summary>
        By = 0x01041800,

        /// <summary>
        /// The keyword 'case'.
        /// </summary>
        Case = 0x01041900,

        /// <summary>
        /// The keyword 'catch'.
        /// </summary>
        Catch = 0x01041a00,

        /// <summary>
        /// The keyword 'checked'.
        /// </summary>
        Checked = 0x01041b00,

        /// <summary>
        /// The keyword 'class'.
        /// </summary>
        Class = 0x01041c00,

        /// <summary>
        /// The keyword 'const'.
        /// </summary>
        Const = 0x01041d00,

        /// <summary>
        /// The keyword 'continue'.
        /// </summary>
        Continue = 0x01041e00,

        /// <summary>
        /// The keyword 'default', as used in a switch statement.
        /// </summary>
        Default = 0x01041f00,

        /// <summary>
        /// The keyword 'default', as used in a default-value expression.
        /// </summary>
        DefaultValue = 0x01042000,

        /// <summary>
        /// The keyword 'delegate'.
        /// </summary>
        Delegate = 0x01042100,

        /// <summary>
        /// The keyword 'descending'.
        /// </summary>
        Descending = 0x01042200,

        /// <summary>
        /// The keyword 'do'.
        /// </summary>
        Do = 0x01042300,

        /// <summary>
        /// The keyword 'else'.
        /// </summary>
        Else = 0x01042400,

        /// <summary>
        /// The keyword 'enum'.
        /// </summary>
        Enum = 0x01042500,

        /// <summary>
        /// The keyword 'equals'.
        /// </summary>
        Equals = 0x01042600,

        /// <summary>
        /// The keyword 'event'.
        /// </summary>
        Event = 0x01042700,

        /// <summary>
        /// The keyword 'explicit'.
        /// </summary>
        Explicit = 0x01042800,

        /// <summary>
        /// The keyword 'extern' in a method declaration.
        /// </summary>
        Extern = 0x01042900,

        /// <summary>
        /// The keyword 'extern' in an extern alias directive.
        /// </summary>
        ExternDirective = 0x01042a00,

        /// <summary>
        /// The keyword 'false'.
        /// </summary>
        False = 0x01042b00,

        /// <summary>
        /// The keyword 'finally'.
        /// </summary>
        Finally = 0x01042c00,

        /// <summary>
        /// The keyword 'fixed'.
        /// </summary>
        Fixed = 0x01042d00,

        /// <summary>
        /// The keyword 'for'.
        /// </summary>
        For = 0x01042e00,

        /// <summary>
        /// The keyword 'foreach'.
        /// </summary>
        Foreach = 0x01042f00,

        /// <summary>
        /// The keyword 'from'.
        /// </summary>
        From = 0x01043000,

        /// <summary>
        /// The keyword 'get'.
        /// </summary>
        Get = 0x01043100,

        /// <summary>
        /// The keyword 'goto'.
        /// </summary>
        Goto = 0x01043200,

        /// <summary>
        /// The keyword 'group'.
        /// </summary>
        Group = 0x01043300,

        /// <summary>
        /// The keyword 'if'.
        /// </summary>
        If = 0x01043400,

        /// <summary>
        /// The keyword 'implicit'.
        /// </summary>
        Implicit = 0x01043500,

        /// <summary>
        /// The keyword 'in'.
        /// </summary>
        In = 0x01043600,

        /// <summary>
        /// The keyword 'interface'.
        /// </summary>
        Interface = 0x01043700,

        /// <summary>
        /// The keyword 'internal'.
        /// </summary>
        Internal = 0x01043800,

        /// <summary>
        /// The keyword 'into'.
        /// </summary>
        Into = 0x01043900,

        /// <summary>
        /// The keyword 'is'.
        /// </summary>
        Is = 0x01043a00,

        /// <summary>
        /// The keyword 'join'.
        /// </summary>
        Join = 0x01043b00,

        /// <summary>
        /// The keyword 'let'.
        /// </summary>
        Let = 0x01043c00,

        /// <summary>
        /// The keyword 'lock'.
        /// </summary>
        Lock = 0x01043d00,

        /// <summary>
        /// The keyword 'namespace'.
        /// </summary>
        Namespace = 0x01043e00,

        /// <summary>
        /// The keyword 'new'.
        /// </summary>
        New = 0x01043f00,

        /// <summary>
        /// The keyword 'null'.
        /// </summary>
        Null = 0x01044000,

        /// <summary>
        /// The keyword 'on'.
        /// </summary>
        On = 0x01044100,

        /// <summary>
        /// The keyword 'operator'.
        /// </summary>
        Operator = 0x01044200, 

        /// <summary>
        /// The keyword 'orderby'.
        /// </summary>
        OrderBy = 0x01044300,

        /// <summary>
        /// A literal name.
        /// </summary>
        Literal = 0x01044400,

        /// <summary>
        /// The keyword 'out'.
        /// </summary>
        Out = 0x01044500,

        /// <summary>
        /// The keyword 'override'.
        /// </summary>
        Override = 0x01044600,

        /// <summary>
        /// The keyword 'params'.
        /// </summary>
        Params = 0x01044700,

        /// <summary>
        /// The keyword 'partial'.
        /// </summary>
        Partial = 0x01044800,

        /// <summary>
        /// The keyword 'private'.
        /// </summary>
        Private = 0x01044900,

        /// <summary>
        /// The keyword 'protected'.
        /// </summary>
        Protected = 0x01044a00,

        /// <summary>
        /// The keyword 'public'.
        /// </summary>
        Public = 0x01044b00,

        /// <summary>
        /// The keyword 'readonly'.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "Readonly",
            Justification = "API has already been published and should not be changed.")]
        Readonly = 0x01044c00,

        /// <summary>
        /// The keyword 'ref'.
        /// </summary>
        Ref = 0x01044d00,

        /// <summary>
        /// The keyword 'remove'.
        /// </summary>
        Remove = 0x01044e00,

        /// <summary>
        /// The keyword 'return'.
        /// </summary>
        Return = 0x01044f00,

        /// <summary>
        /// The keyword 'sealed'.
        /// </summary>
        Sealed = 0x01045000,

        /// <summary>
        /// The keyword 'select'.
        /// </summary>
        Select = 0x01045100,

        /// <summary>
        /// The keyword 'set'.
        /// </summary>
        Set = 0x01045200,

        /// <summary>
        /// The keyword 'sizeof'.
        /// </summary>
        Sizeof = 0x01045300,

        /// <summary>
        /// The keyword 'stackalloc'.
        /// </summary>
        Stackalloc = 0x01045400,

        /// <summary>
        /// The keyword 'static'.
        /// </summary>
        Static = 0x01045500,

        /// <summary>
        /// The keyword 'struct'.
        /// </summary>
        Struct = 0x01045600,

        /// <summary>
        /// The keyword 'switch'.
        /// </summary>
        Switch = 0x01045700,

        /// <summary>
        /// The keyword 'this'.
        /// </summary>
        This = 0x01045800,

        /// <summary>
        /// The keyword 'throw'.
        /// </summary>
        Throw = 0x01045900,

        /// <summary>
        /// The keyword 'true'.
        /// </summary>
        True = 0x01045a00,

        /// <summary>
        /// The keyword 'try'.
        /// </summary>
        Try = 0x01045b00,

        /// <summary>
        /// A type token.
        /// </summary>
        Type = 0x01045c00,

        /// <summary>
        /// The keyword 'typeof'.
        /// </summary>
        Typeof = 0x01045d00,

        /// <summary>
        /// The keyword 'unchecked'.
        /// </summary>
        Unchecked = 0x01045e00,

        /// <summary>
        /// The keyword 'unsafe'.
        /// </summary>
        Unsafe = 0x01045f00,

        /// <summary>
        /// The keyword 'using' in a using-statement.
        /// </summary>
        Using = 0x01046000,

        /// <summary>
        /// The keyword 'using' in a using-directive.
        /// </summary>
        UsingDirective = 0x01046100,

        /// <summary>
        /// The keyword 'virtual'.
        /// </summary>
        Virtual = 0x01046200,

        /// <summary>
        /// The keyword 'volatile'.
        /// </summary>
        Volatile = 0x01046300,

        /// <summary>
        /// The keyword 'where'.
        /// </summary>
        Where = 0x01046400,

        /// <summary>
        /// The keyword 'while'.
        /// </summary>
        While = 0x01046500,

        /// <summary>
        /// The keyword 'while' at the end of a do/while statement.
        /// </summary>
        WhileDo = 0x01046600,

        /// <summary>
        /// The keyword 'yield'.
        /// </summary>
        Yield = 0x01046700,

        /// <summary>
        /// A string literal.
        /// </summary>
        String = 0x01046800,

        /// <summary>
        /// A number literal.
        /// </summary>
        Number = 0x01046900,

        /// <summary>
        /// A square bracket opening an attribute.
        /// </summary>
        OpenAttributeBracket = 0x01046a00,

        /// <summary>
        /// A square bracket closing an attribute.
        /// </summary>
        CloseAttributeBracket = 0x01046b00,

        /// <summary>
        /// The tilde before the name of a destructor.
        /// </summary>
        DestructorTilde = 0x01046c00,

        /// <summary>
        /// A constructor constraint keyword.
        /// </summary>
        ConstructorConstraint = 0x01046d00
    }

    /// <summary>
    /// The various operator types.
    /// </summary>
    /// <subcategory>token</subcategory>
    public enum OperatorType
    {
        /// <summary>
        /// No operator types match this value.
        /// </summary>
        None = 0,

        #region Relational Operators

        /// <summary>
        /// A conditional equals symbol: '=='.
        /// </summary>
        ConditionalEquals = 0x01040901,

        /// <summary>
        /// A NOT equals symbol: '!='.
        /// </summary>
        NotEquals = 0x01040902,

        /// <summary>
        /// A less-then sign.
        /// </summary>
        LessThan = 0x01040903,

        /// <summary>
        /// A greater-than sign.
        /// </summary>
        GreaterThan = 0x01040904,

        /// <summary>
        /// A less than or equals sign.
        /// </summary>
        LessThanOrEquals = 0x01040905,

        /// <summary>
        /// A greater than or equals sign.
        /// </summary>
        GreaterThanOrEquals = 0x01040906,

        #endregion Relational Operators

        #region Logical Operators

        /// <summary>
        /// A logical AND symbol.
        /// </summary>
        LogicalAnd = 0x01040907,

        /// <summary>
        /// A logical OR symbol: '|'.
        /// </summary>
        LogicalOr = 0x01040908,

        /// <summary>
        /// A logical XOR symbol: '^'.
        /// </summary>
        LogicalXor = 0x01040909,

        /// <summary>
        /// A conditional AND symbol.
        /// </summary>
        ConditionalAnd = 0x0104090a,

        /// <summary>
        /// A conditional OR symbol: '||'.
        /// </summary>
        ConditionalOr = 0x0104090b,

        /// <summary>
        /// A null coalescing symbol: '??'.
        /// </summary>
        NullCoalescingSymbol = 0x0104090c,

        #endregion Logical Operators

        #region Assignment Operators

        /// <summary>
        /// An equals sign: '='.
        /// </summary>
        Equals = 0x0104090d,

        /// <summary>
        /// A plus equals symbol: '+='.
        /// </summary>
        PlusEquals = 0x0104090e,

        /// <summary>
        /// A minus equals symbol: '-='.
        /// </summary>
        MinusEquals = 0x0104090f,

        /// <summary>
        /// A times equals symbol: '*='.
        /// </summary>
        MultiplicationEquals = 0x01040910,

        /// <summary>
        /// A divide equals symbol: '/='.
        /// </summary>
        DivisionEquals = 0x01040911,

        /// <summary>
        /// A left-shift equals sign.
        /// </summary>
        LeftShiftEquals = 0x01040912,

        /// <summary>
        /// A right-shift equals sign.
        /// </summary>
        RightShiftEquals = 0x01040913,

        /// <summary>
        /// An AND equals symbol.
        /// </summary>
        AndEquals = 0x01040914,

        /// <summary>
        /// An OR equals symbol: '|='.
        /// </summary>
        OrEquals = 0x01040915,

        /// <summary>
        /// An XOR equals symbol: '^='.
        /// </summary>
        XorEquals = 0x01040916,

        #endregion Assignment Operators

        #region Arithmetic Operators

        /// <summary>
        /// A plus sign: '+'.
        /// </summary>
        Plus = 0x01040917,

        /// <summary>
        /// A minus sign: '-'.
        /// </summary>
        Minus = 0x01040918,

        /// <summary>
        /// A multiplication sign: '*'.
        /// </summary>
        Multiplication = 0x01040919,

        /// <summary>
        /// A division sign: '/'.
        /// </summary>
        Division = 0x0104091a,

        /// <summary>
        /// A MOD symbol: '%'.
        /// </summary>
        Mod = 0x0104091b,

        /// <summary>
        /// A MOD equals symbol: '%='.
        /// </summary>
        ModEquals = 0x0104091c,

        #endregion Arithmetic Operators

        #region Shift Operators

        /// <summary>
        /// A left-shift symbol.
        /// </summary>
        LeftShift = 0x0104091d,

        /// <summary>
        /// A right-shift symbol.
        /// </summary>
        RightShift = 0x0104091e,

        #endregion Shift Operators

        #region Conditional Operators

        /// <summary>
        /// A colon: ':'.
        /// </summary>
        ConditionalColon = 0x0104091f,

        /// <summary>
        /// A question mark: '?'.
        /// </summary>
        ConditionalQuestionMark = 0x01040920,

        #endregion Conditional Operators

        #region Increment/Decrement Operators

        /// <summary>
        /// An increment symbol: '++'.
        /// </summary>
        Increment = 0x01040921,

        /// <summary>
        /// A decrement symbol: '--'.
        /// </summary>
        Decrement = 0x01040922,

        #endregion Increment/Decrement Operators

        #region Unary Operators

        /// <summary>
        /// A NOT symbol: '!'.
        /// </summary>
        Not = 0x01040923,

        /// <summary>
        /// A tilde symbol: '~'.
        /// </summary>
        BitwiseCompliment = 0x01040924,

        /// <summary>
        /// A positive sign: '+'.
        /// </summary>
        Positive = 0x01040925,

        /// <summary>
        /// A negative sign: '-'.
        /// </summary>
        Negative = 0x01040926,

        #endregion Unary Operators

        #region Reference Operators

        /// <summary>
        /// A dereference symbol: '*'.
        /// </summary>
        Dereference = 0x01040927,

        /// <summary>
        /// An address-of symbol.
        /// </summary>
        AddressOf = 0x01040928,

        /// <summary>
        /// A pointer symbol: '->'.
        /// </summary>
        Pointer = 0x01040929,

        /// <summary>
        /// A member access operator: '.'.
        /// </summary>
        MemberAccess = 0x0104092a,

        /// <summary>
        /// A qualified alias operator: '::'.
        /// </summary>
        QualifiedAlias = 0x0104092b,

        #endregion Reference Operators

        #region Lambda Operators

        /// <summary>
        /// The lambda operator: =>.
        /// </summary>
        Lambda = 0x0104092c

        #endregion Lambda Operators
    }

    /// <summary>
    /// The types of comments.
    /// </summary>
    public enum CommentType
    {
        /// <summary>
        /// No comment types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// A single-line style comment.
        /// </summary>
        SingleLineComment = 0x01010100,

        /// <summary>
        /// A multi-line style comment.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "MultilineComment", Justification = "Suggested casing is poor.")]
        MultilineComment = 0x01010200,

        /// <summary>
        /// A line within an Xml header.
        /// </summary>
        XmlHeaderLine = 0x01010300,
    }

    /// <summary>
    /// The various <see cref="QueryClause"/> types in a C# document.
    /// </summary>
    public enum QueryClauseType
    {
        /// <summary>
        /// No query clause types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// A query continuation clause.
        /// </summary>
        Continuation = 0x05010000,

        /// <summary>
        /// A from clause.
        /// </summary>
        From = 0x05020000,

        /// <summary>
        /// A group clause.
        /// </summary>
        Group = 0x05030000,

        /// <summary>
        /// A join clause.
        /// </summary>
        Join = 0x05040000,

        /// <summary>
        /// A let clause.
        /// </summary>
        Let = 0x05050000,

        /// <summary>
        /// An order-by clause.
        /// </summary>
        OrderBy = 0x05060000,

        /// <summary>
        /// A select clause.
        /// </summary>
        Select = 0x05070000,

        /// <summary>
        /// A where clause.
        /// </summary>
        Where = 0x05080000
    }

    /// <summary>
    /// The various <see cref="Expression"/> types in a C# document.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public enum ExpressionType
    {
        /// <summary>
        /// No expression types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// An anonymous method expression.
        /// </summary>
        AnonymousMethod = 0x04010000,

        /// <summary>
        /// An arithmetic expression.
        /// </summary>
        Arithmetic = 0x04020000,

        /// <summary>
        /// An array access expression.
        /// </summary>
        ArrayAccess = 0x04030000,

        /// <summary>
        /// An array initializer expression.
        /// </summary>
        ArrayInitializer = 0x04040000,

        /// <summary>
        /// An as-expression.
        /// </summary>
        As = 0x04050000,

        /// <summary>
        /// An assignment expression.
        /// </summary>
        Assignment = 0x04060000,

        /// <summary>
        /// An attribute call expression.
        /// </summary>
        Attribute = 0x04070000,

        /// <summary>
        /// A cast expression.
        /// </summary>
        Cast = 0x04080000,

        /// <summary>
        /// A checked expression.
        /// </summary>
        Checked = 0x04090000,

        /// <summary>
        /// A collection initializer expression.
        /// </summary>
        CollectionInitializer = 0x040a0000,

        /// <summary>
        /// A conditional expression.
        /// </summary>
        Conditional = 0x040b0000,

        /// <summary>
        /// A conditional logical expression.
        /// </summary>
        ConditionalLogical = 0x040c0000,

        /// <summary>
        /// A decrement expression.
        /// </summary>
        Decrement = 0x040d0000,

        /// <summary>
        /// A default value expression.
        /// </summary>
        DefaultValue = 0x040e0000,

        /// <summary>
        /// A comma-separated list of expressions.
        /// </summary>
        ExpressionList = 0x040f0000,

        /// <summary>
        /// An increment expression.
        /// </summary>
        Increment = 0x04100000,

        /// <summary>
        /// An is-expression.
        /// </summary>
        Is = 0x04110000,

        /// <summary>
        /// A lambda expression.
        /// </summary>
        Lambda = 0x04120000,

        /// <summary>
        /// A literal expression.
        /// </summary>
        Literal = 0x04130000,

        /// <summary>
        /// A logical expression.
        /// </summary>
        Logical = 0x04140000,

        /// <summary>
        /// A member access expression.
        /// </summary>
        MemberAccess = 0x04150000,

        /// <summary>
        /// A method invocation expression.
        /// </summary>
        MethodInvocation = 0x04160000,

        /// <summary>
        /// A new array allocation expression.
        /// </summary>
        NewArray = 0x04170000,

        /// <summary>
        /// A new allocation expression.
        /// </summary>
        New = 0x04180000,

        /// <summary>
        /// A null-coalescing expression.
        /// </summary>
        NullCoalescing = 0x04190000,

        /// <summary>
        /// An object initializer expression.
        /// </summary>
        ObjectInitializer = 0x041a0000,

        /// <summary>
        /// A parenthesized expression.
        /// </summary>
        Parenthesized = 0x041b0000,

        /// <summary>
        /// A query expression.
        /// </summary>
        Query = 0x041c0000,

        /// <summary>
        /// A relational expression.
        /// </summary>
        Relational = 0x041d0000,

        /// <summary>
        /// A sizeof expression.
        /// </summary>
        Sizeof = 0x041e0000,

        /// <summary>
        /// A stackalloc expression.
        /// </summary>
        Stackalloc = 0x041f0000,

        /// <summary>
        /// A typeof expression.
        /// </summary>
        Typeof = 0x04200000,

        /// <summary>
        /// A unary exprssion.
        /// </summary>
        Unary = 0x04210000,

        /// <summary>
        /// An unchecked expression.
        /// </summary>
        Unchecked = 0x04220000,

        /// <summary>
        /// An unsafe access expression.
        /// </summary>
        UnsafeAccess = 0x04230000,

        /// <summary>
        /// A variable declaration expression.
        /// </summary>
        VariableDeclaration = 0x04240000,

        /// <summary>
        /// A variable declarator expression.
        /// </summary>
        VariableDeclarator = 0x04250000
    }

    /// <summary>
    /// The types of preprocessor directives.
    /// </summary>
    public enum PreprocessorType
    {
        /// <summary>
        /// No preprocessor types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// A Line directive.
        /// </summary>
        Line = 0x01030100,

        /// <summary>
        /// A region directive.
        /// </summary>
        Region = 0x01030200,

        /// <summary>
        /// An end-region directive.
        /// </summary>
        EndRegion = 0x01030300,

        /// <summary>
        /// An if directive.
        /// </summary>
        If = 0x01030400,

        /// <summary>
        /// An elif directive.
        /// </summary>
        Elif = 0x01030500,

        /// <summary>
        /// An else directive.
        /// </summary>
        Else = 0x01030600,

        /// <summary>
        /// An endif directive.
        /// </summary>
        Endif = 0x01030700,

        /// <summary>
        /// A define directive.
        /// </summary>
        Define = 0x01030800,

        /// <summary>
        /// An undef directive.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Undef", Justification = "Matches the C# undef directive.")]
        Undef = 0x01030900,

        /// <summary>
        /// An error directive.
        /// </summary>
        Error = 0x01030a00,

        /// <summary>
        /// A warning directive.
        /// </summary>
        Warning = 0x01030b00,

        /// <summary>
        /// A pragma directive.
        /// </summary>
        Pragma = 0x01030700
    }

    /// <summary>
    /// The various <see cref="Statement"/> types in a C# document.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public enum StatementType
    {
        /// <summary>
        /// No statement types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// A block statement.
        /// </summary>
        Block = 0x03010000,

        /// <summary>
        /// A break statement.
        /// </summary>
        Break = 0x03020000,

        /// <summary>
        /// A catch statement.
        /// </summary>
        Catch = 0x03030000,

        /// <summary>
        /// A checked statement.
        /// </summary>
        Checked = 0x03040000,

        /// <summary>
        /// A constructor initialization statement.
        /// </summary>
        ConstructorInitializer = 0x03050000,

        /// <summary>
        /// A continue statement.
        /// </summary>
        Continue = 0x03060000,

        /// <summary>
        /// A do-while statement.
        /// </summary>
        DoWhile = 0x03070000,

        /// <summary>
        /// An else statement.
        /// </summary>
        Else = 0x03080000,

        /// <summary>
        /// An empty statement.
        /// </summary>
        Empty = 0x03090000,

        /// <summary>
        /// An expression statement.
        /// </summary>
        Expression = 0x030a0000,

        /// <summary>
        /// A finally statement.
        /// </summary>
        Finally = 0x030b0000,

        /// <summary>
        /// A fixed statement.
        /// </summary>
        Fixed = 0x030c0000,

        /// <summary>
        /// A foreach statement.
        /// </summary>
        Foreach = 0x030d0000,

        /// <summary>
        /// A for statement.
        /// </summary>
        For = 0x030e0000,

        /// <summary>
        /// A goto statement.
        /// </summary>
        Goto = 0x030f0000,

        /// <summary>
        /// An if statement.
        /// </summary>
        If = 0x03100000,

        /// <summary>
        /// A label statement.
        /// </summary>
        Label = 0x03110000,

        /// <summary>
        /// A lock statement.
        /// </summary>
        Lock = 0x03120000,

        /// <summary>
        /// A return statement.
        /// </summary>
        Return = 0x03130000,

        /// <summary>
        /// A switch case statement.
        /// </summary>
        SwitchCase = 0x03140000,

        /// <summary>
        /// A switch default statement.
        /// </summary>
        SwitchDefault = 0x03150000,

        /// <summary>
        /// A switch statement.
        /// </summary>
        Switch = 0x03160000,

        /// <summary>
        /// A throw statement.
        /// </summary>
        Throw = 0x03170000,

        /// <summary>
        /// A try statement.
        /// </summary>
        Try = 0x03180000,

        /// <summary>
        /// An unchecked statement.
        /// </summary>
        Unchecked = 0x03190000,

        /// <summary>
        /// An unsafe statement.
        /// </summary>
        Unsafe = 0x031a0000,

        /// <summary>
        /// A using statement.
        /// </summary>
        Using = 0x031b0000,

        /// <summary>
        /// A variable declaration statement.
        /// </summary>
        VariableDeclaration = 0x031c0000,

        /// <summary>
        /// A while statement.
        /// </summary>
        While = 0x031d0000,

        /// <summary>
        /// A yield statement.
        /// </summary>
        Yield = 0x031e0000
    }

    // The following elements are listed in the order they should appear in the code.

    /// <summary>
    /// The various types of elements in a C# code file.
    /// </summary>
    /// <subcategory>element</subcategory>
    public enum ElementType
    {
        /// <summary>
        /// No element types match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// A code file.
        /// </summary>
        File = 0x02010000,

        /// <summary>
        /// The root of a document.
        /// </summary>
        Root = 0x02020000,

        /// <summary>
        /// An extern alias directive.
        /// </summary>
        ExternAliasDirective  = 0x02030000,

        /// <summary>
        /// A using directive.
        /// </summary>
        UsingDirective = 0x02040000,

        /// <summary>
        /// A namespace element.
        /// </summary>
        Namespace = 0x02050000,

        /// <summary>
        /// A field element.
        /// </summary>
        Field = 0x02060000,

        /// <summary>
        /// A constructor element. 
        /// </summary>
        Constructor = 0x02070000,

        /// <summary>
        /// A destructor element.
        /// </summary>
        Destructor = 0x02080000,

        /// <summary>
        /// A delegate element.
        /// </summary>
        Delegate = 0x02090000,

        /// <summary>
        /// An event element.
        /// </summary>
        Event = 0x020a0000,

        /// <summary>
        /// An enum element.
        /// </summary>
        Enum = 0x020b0000,

        /// <summary>
        /// An interface element.
        /// </summary>
        Interface = 0x020c0000,

        /// <summary>
        /// A property element.
        /// </summary>
        Property = 0x020d0000,

        /// <summary>
        /// An accessor inside of a property, indexer, or event.
        /// </summary>
        Accessor = 0x020e0000,

        /// <summary>
        /// An indexer element.
        /// </summary>
        Indexer = 0x020f0000,

        /// <summary>
        /// A method element.
        /// </summary>
        Method = 0x02100000,

        /// <summary>
        /// A struct element.
        /// </summary>
        Struct = 0x02110000,

        /// <summary>
        /// A class element.
        /// </summary>
        Class = 0x02120000,

        /// <summary>
        /// An codeUnit in an enumeration.
        /// </summary>
        EnumItem = 0x02130000,

        /// <summary>
        /// The initialization code within a constructor's declaration.
        /// </summary>
        ConstructorInitializer = 0x02140000,

        /// <summary>
        /// An element consisting only of a single semicolon.
        /// </summary>
        EmptyElement = 0x02150000
    }

    /// <summary>
    /// Defines the masks used to reduce a code unit type value down to a specific type value.
    /// </summary>
    public enum FundamentalTypeMasks
    {
        /// <summary>
        /// No masks match this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// The mask for CodeUnit types.
        /// </summary>
        CodeUnit = 0x7F000000,

        /// <summary>
        /// The mask for LexicalElement types.
        /// </summary>
        LexicalElement = 0x7FFF0000,

        /// <summary>
        /// The mask for Token types.
        /// </summary>
        Token = 0x7FFFFF00,

        /// <summary>
        /// The mask for Operator types.
        /// </summary>
        Operator = 0x7FFFFFFF,

        /// <summary>
        /// The mask for Comment types.
        /// </summary>
        Comment = 0x7FFFFF00,

        /// <summary>
        /// The mask for Preprocessor types.
        /// </summary>
        Preprocessor = 0x7FFFFF00,

        /// <summary>
        /// The mask for QueryClause types.
        /// </summary>
        QueryClause = 0x7FFF0000,

        /// <summary>
        /// The mask for Expression types.
        /// </summary>
        Expression = 0x7FFF0000,

        /// <summary>
        /// The mask for Statement types.
        /// </summary>
        Statement = 0x7FFF0000,

        /// <summary>
        /// The mask for Element types.
        /// </summary>
        Element = 0x7FFF0000
    }
}
