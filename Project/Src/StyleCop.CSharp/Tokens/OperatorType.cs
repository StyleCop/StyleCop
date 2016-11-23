// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatorType.cs" company="https://github.com/StyleCop">
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
//   The various operator types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various operator types.
    /// </summary>
    /// <subcategory>token</subcategory>
    public enum OperatorType
    {
        #region Relational Operators

        /// <summary>
        /// A conditional equals symbol: '=='.
        /// </summary>
        ConditionalEquals, 

        /// <summary>
        /// A NOT equals symbol: '!='.
        /// </summary>
        NotEquals, 

        /// <summary>
        /// A less-then sign.
        /// </summary>
        LessThan, 

        /// <summary>
        /// A greater-than sign.
        /// </summary>
        GreaterThan, 

        /// <summary>
        /// A less than or equals sign.
        /// </summary>
        LessThanOrEquals, 

        /// <summary>
        /// A greater than or equals sign.
        /// </summary>
        GreaterThanOrEquals, 

        #endregion Relational Operators

        #region Logical Operators

        /// <summary>
        /// A logical AND symbol.
        /// </summary>
        LogicalAnd, 

        /// <summary>
        /// A logical OR symbol: '|'.
        /// </summary>
        LogicalOr, 

        /// <summary>
        /// A logical XOR symbol: '^'.
        /// </summary>
        LogicalXor, 

        /// <summary>
        /// A conditional AND symbol.
        /// </summary>
        ConditionalAnd, 

        /// <summary>
        /// A conditional OR symbol: '||'.
        /// </summary>
        ConditionalOr, 

        /// <summary>
        /// A null coalescing symbol: '??'.
        /// </summary>
        NullCoalescingSymbol, 

        #endregion Logical Operators

        #region Assignment Operators

        /// <summary>
        /// An equals sign: '='.
        /// </summary>
        Equals, 

        /// <summary>
        /// A plus equals symbol: '+='.
        /// </summary>
        PlusEquals, 

        /// <summary>
        /// A minus equals symbol: '-='.
        /// </summary>
        MinusEquals, 

        /// <summary>
        /// A times equals symbol: '*='.
        /// </summary>
        MultiplicationEquals, 

        /// <summary>
        /// A divide equals symbol: '/='.
        /// </summary>
        DivisionEquals, 

        /// <summary>
        /// A left-shift equals sign.
        /// </summary>
        LeftShiftEquals, 

        /// <summary>
        /// A right-shift equals sign.
        /// </summary>
        RightShiftEquals, 

        /// <summary>
        /// An AND equals symbol.
        /// </summary>
        AndEquals, 

        /// <summary>
        /// An OR equals symbol: '|='.
        /// </summary>
        OrEquals, 

        /// <summary>
        /// An XOR equals symbol: '^='.
        /// </summary>
        XorEquals, 

        #endregion Assignment Operators

        #region Arithmetic Operators

        /// <summary>
        /// A plus sign: '+'.
        /// </summary>
        Plus, 

        /// <summary>
        /// A minus sign: '-'.
        /// </summary>
        Minus, 

        /// <summary>
        /// A multiplication sign: '*'.
        /// </summary>
        Multiplication, 

        /// <summary>
        /// A division sign: '/'.
        /// </summary>
        Division, 

        /// <summary>
        /// A MOD symbol: '%'.
        /// </summary>
        Mod, 

        /// <summary>
        /// A MOD equals symbol: '%='.
        /// </summary>
        ModEquals, 

        #endregion Arithmetic Operators

        #region Shift Operators

        /// <summary>
        /// A left-shift symbol.
        /// </summary>
        LeftShift, 

        /// <summary>
        /// A right-shift symbol.
        /// </summary>
        RightShift, 

        #endregion Shift Operators

        #region Conditional Operators

        /// <summary>
        /// A colon: ':'.
        /// </summary>
        ConditionalColon, 

        /// <summary>
        /// A question mark: '?'.
        /// </summary>
        ConditionalQuestionMark,

        /// <summary>
        /// The null conditional operator ?.
        /// </summary>
        NullConditional,

        #endregion Conditional Operators

        #region Increment/Decrement Operators

        /// <summary>
        /// An increment symbol: '++'.
        /// </summary>
        Increment, 

        /// <summary>
        /// A decrement symbol: '--'.
        /// </summary>
        Decrement, 

        #endregion Increment/Decrement Operators

        #region Unary Operators

        /// <summary>
        /// A NOT symbol: '!'.
        /// </summary>
        Not, 

        /// <summary>
        /// A tilde symbol: '~'.
        /// </summary>
        BitwiseCompliment, 

        /// <summary>
        /// A positive sign: '+'.
        /// </summary>
        Positive, 

        /// <summary>
        /// A negative sign: '-'.
        /// </summary>
        Negative, 

        #endregion Unary Operators

        #region Reference Operators

        /// <summary>
        /// A dereference symbol: '*'.
        /// </summary>
        Dereference, 

        /// <summary>
        /// An address-of symbol.
        /// </summary>
        AddressOf, 

        /// <summary>
        /// A pointer symbol: '->'.
        /// </summary>
        Pointer, 

        /// <summary>
        /// A member access operator: '.'.
        /// </summary>
        MemberAccess, 

        /// <summary>
        /// A qualified alias operator: '::'.
        /// </summary>
        QualifiedAlias, 

        #endregion Reference Operators

        #region Lambda Operators

        /// <summary>
        /// The lambda operator: =>
        /// </summary>
        Lambda

        #endregion Lambda Operators
    }
}