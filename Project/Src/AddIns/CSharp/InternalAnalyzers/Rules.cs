// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rules.cs" company="http://stylecop.codeplex.com">
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
//   The list of rules exported by the analyzers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Internal
{
    /// <summary>
    /// The list of rules exported by the analyzers.
    /// </summary>
    internal enum Rules
    {
        /// <summary>
        /// All parameters must be verified.
        /// </summary>
        ParametersMustBeVerified, 

        /// <summary>
        /// Out parameters do not need to be verified.
        /// </summary>
        OutParametersMustNotBeVerified, 

        /// <summary>
        /// Private methods must use asserts.
        /// </summary>
        PrivateMethodsMustUseAsserts, 

        /// <summary>
        /// Public methods must use requires.
        /// </summary>
        PublicMethodsMustUseRequires
    }
}