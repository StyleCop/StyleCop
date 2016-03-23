// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMethodDeclarationExtensions.cs" company="http://stylecop.codeplex.com">
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
//   I method declaration extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Extensions
{
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Impl;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    /// I method declaration extensions.
    /// </summary>
    public static class IMethodDeclarationExtensions
    {
        /// <summary>
        /// Get return type.
        /// </summary>
        /// <param name="declaration">
        /// The declaration.
        /// </param>
        /// <returns>
        /// An IType for the return type.
        /// </returns>
        public static IType GetReturnType(this IMethodDeclaration declaration)
        {
            IMethodDeclaration methodDeclarationNode = declaration;

            if (methodDeclarationNode == null)
            {
                return null;
            }

            ITypeUsage typeUsage = methodDeclarationNode.TypeUsage;

            if (typeUsage == null)
            {
                return null;
            }

            return CSharpTypeFactory.CreateType(typeUsage);
        }

        /// <summary>
        /// Indicates whether this method is declared with the new keyword.
        /// </summary>
        /// <param name="declaration">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <c>true</c> if the declaration is declared with new otherwise <c>false</c>.
        /// </returns>
        public static bool IsNew(this IMethodDeclaration declaration)
        {
            return declaration != null && ModifiersUtil.GetNew(declaration as IModifiersListOwner);
        }
    }
}