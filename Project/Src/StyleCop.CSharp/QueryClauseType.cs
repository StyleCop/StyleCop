// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryClauseType.cs" company="https://github.com/StyleCop">
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
//   The various <see cref="QueryClause" /> types in a C# document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various <see cref="QueryClause"/> types in a C# document.
    /// </summary>
    public enum QueryClauseType
    {
        /// <summary>
        /// A query continuation clause.
        /// </summary>
        Continuation, 

        /// <summary>
        /// A from clause.
        /// </summary>
        From, 

        /// <summary>
        /// A group clause.
        /// </summary>
        Group, 

        /// <summary>
        /// A join clause.
        /// </summary>
        Join, 

        /// <summary>
        /// A let clause.
        /// </summary>
        Let, 

        /// <summary>
        /// An order-by clause.
        /// </summary>
        OrderBy, 

        /// <summary>
        /// A select clause.
        /// </summary>
        Select, 

        /// <summary>
        /// A where clause.
        /// </summary>
        Where
    }
}