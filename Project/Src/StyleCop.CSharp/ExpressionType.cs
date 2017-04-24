// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionType.cs" company="https://github.com/StyleCop">
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
//   The various <see cref="Expression" /> types in a C# document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various <see cref="Expression"/> types in a C# document.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public enum ExpressionType
    {
        /// <summary>
        /// An anonymous method expression.
        /// </summary>
        AnonymousMethod, 

        /// <summary>
        /// An arithmetic expression.
        /// </summary>
        Arithmetic, 

        /// <summary>
        /// An array access expression.
        /// </summary>
        ArrayAccess, 

        /// <summary>
        /// An array initializer expression.
        /// </summary>
        ArrayInitializer, 

        /// <summary>
        /// An as-expression.
        /// </summary>
        As, 

        /// <summary>
        /// An assignment expression.
        /// </summary>
        Assignment, 

        /// <summary>
        /// An attribute call expression.
        /// </summary>
        Attribute, 

        /// <summary>
        /// An await expression.
        /// </summary>
        Await,

        /// <summary>
        /// A bodied expression.
        /// </summary>
        Bodied,

        /// <summary>
        /// A cast expression.
        /// </summary>
        Cast, 

        /// <summary>
        /// A checked expression.
        /// </summary>
        Checked, 

        /// <summary>
        /// A collection initializer expression.
        /// </summary>
        CollectionInitializer, 

        /// <summary>
        /// A conditional expression.
        /// </summary>
        Conditional, 

        /// <summary>
        /// A conditional logical expression.
        /// </summary>
        ConditionalLogical, 

        /// <summary>
        /// A decrement expression.
        /// </summary>
        Decrement, 

        /// <summary>
        /// A default value expression.
        /// </summary>
        DefaultValue, 

        /// <summary>
        /// A comma-separated list of expressions.
        /// </summary>
        ExpressionList, 

        /// <summary>
        /// An increment expression.
        /// </summary>
        Increment, 

        /// <summary>
        /// An is-expression.
        /// </summary>
        Is, 

        /// <summary>
        /// A lambda expression.
        /// </summary>
        Lambda, 

        /// <summary>
        /// A literal expression.
        /// </summary>
        Literal, 

        /// <summary>
        /// A logical expression.
        /// </summary>
        Logical, 

        /// <summary>
        /// A member access expression.
        /// </summary>
        MemberAccess, 

        /// <summary>
        /// A method invocation expression.
        /// </summary>
        MethodInvocation,

        /// <summary>
        /// A nameof expression.
        /// </summary>
        NameOf,

        /// <summary>
        /// A new array allocation expression.
        /// </summary>
        NewArray, 

        /// <summary>
        /// A new allocation expression.
        /// </summary>
        New, 

        /// <summary>
        /// A null-coalescing expression.
        /// </summary>
        NullCoalescing, 

        /// <summary>
        /// An object initializer expression.
        /// </summary>
        ObjectInitializer, 

        /// <summary>
        /// A parenthesized expression.
        /// </summary>
        Parenthesized, 

        /// <summary>
        /// A query expression.
        /// </summary>
        Query, 

        /// <summary>
        /// A relational expression.
        /// </summary>
        Relational, 

        /// <summary>
        /// A sizeof expression.
        /// </summary>
        Sizeof, 

        /// <summary>
        /// A stackalloc expression.
        /// </summary>
        Stackalloc, 

        /// <summary>
        /// A typeof expression.
        /// </summary>
        Typeof, 

        /// <summary>
        /// A unary expression.
        /// </summary>
        Unary, 

        /// <summary>
        /// An unchecked expression.
        /// </summary>
        Unchecked, 

        /// <summary>
        /// An unsafe access expression.
        /// </summary>
        UnsafeAccess, 

        /// <summary>
        /// A variable declaration expression.
        /// </summary>
        VariableDeclaration, 

        /// <summary>
        /// A variable declarator expression.
        /// </summary>
        VariableDeclarator, 

        /// <summary>
        /// An event declarator expression.
        /// </summary>
        EventDeclarator,

        /// <summary>
        /// A throw exception expression.
        /// </summary>
        Throw,
        
        /// <summary>
        /// A reference value expression. 
        /// </summary>
        Ref,

        /// <summary>
        /// A tuple expression.
        /// </summary>
        Tuple
    }
}