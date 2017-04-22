// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatementType.cs" company="https://github.com/StyleCop">
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
//   The various <see cref="Statement" /> types in a C# document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various <see cref="Statement"/> types in a C# document.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public enum StatementType
    {
        /// <summary>
        /// An await statement.
        /// </summary>
        Await,

        /// <summary>
        /// A block statement.
        /// </summary>
        Block, 

        /// <summary>
        /// A break statement.
        /// </summary>
        Break, 

        /// <summary>
        /// A catch statement.
        /// </summary>
        Catch, 

        /// <summary>
        /// A checked statement.
        /// </summary>
        Checked, 

        /// <summary>
        /// A constructor initialization statement.
        /// </summary>
        ConstructorInitializer, 

        /// <summary>
        /// A continue statement.
        /// </summary>
        Continue, 

        /// <summary>
        /// A do-while statement.
        /// </summary>
        DoWhile, 

        /// <summary>
        /// An else statement.
        /// </summary>
        Else, 

        /// <summary>
        /// An empty statement.
        /// </summary>
        Empty, 

        /// <summary>
        /// An expression statement.
        /// </summary>
        Expression, 

        /// <summary>
        /// A finally statement.
        /// </summary>
        Finally, 

        /// <summary>
        /// A fixed statement.
        /// </summary>
        Fixed, 

        /// <summary>
        /// A foreach statement.
        /// </summary>
        Foreach, 

        /// <summary>
        /// A for statement.
        /// </summary>
        For, 

        /// <summary>
        /// A goto statement.
        /// </summary>
        Goto, 

        /// <summary>
        /// An if statement.
        /// </summary>
        If, 

        /// <summary>
        /// A label statement.
        /// </summary>
        Label, 

        /// <summary>
        /// A lock statement.
        /// </summary>
        Lock,

        /// <summary>
        /// A return statement.
        /// </summary>
        Return, 

        /// <summary>
        /// A switch case statement.
        /// </summary>
        SwitchCase, 

        /// <summary>
        /// A switch default statement.
        /// </summary>
        SwitchDefault, 

        /// <summary>
        /// A switch statement.
        /// </summary>
        Switch, 

        /// <summary>
        /// A throw statement.
        /// </summary>
        Throw, 

        /// <summary>
        /// A try statement.
        /// </summary>
        Try, 

        /// <summary>
        /// An unchecked statement.
        /// </summary>
        Unchecked, 

        /// <summary>
        /// An unsafe statement.
        /// </summary>
        Unsafe, 

        /// <summary>
        /// A using statement.
        /// </summary>
        Using, 

        /// <summary>
        /// A variable declaration statement.
        /// </summary>
        VariableDeclaration, 

        /// <summary>
        /// A while statement.
        /// </summary>
        While,

        /// <summary>
        /// A yield statement.
        /// </summary>
        Yield,

        /// <summary>
        /// a bodied statement.
        /// </summary>
        Bodied,

        /// <summary>
        /// The nameof statement.
        /// </summary>
        NameOf,

        /// <summary>
        /// A When statement.
        /// </summary>
        When,

        /// <summary>
        /// A local function statement.
        /// </summary>
        LocalFunction,
    }
}