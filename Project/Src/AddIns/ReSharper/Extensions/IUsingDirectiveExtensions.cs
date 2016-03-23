// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUsingDirectiveExtensions.cs" company="http://stylecop.codeplex.com">
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
//   Extension methods for the  class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Extensions
{
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    /// Extension methods for the <see cref="IUsingDirective"/> class.
    /// </summary>
    public static class IUsingDirectiveExtensions
    {
        /// <summary>
        /// Gets the full namespace for the Using directive with any aliases expanded.
        /// </summary>
        /// <param name="directive">
        /// The directive to use.
        /// </param>
        /// <returns>
        /// The fully qualified namespace.
        /// </returns>
        internal static string GetFullyQualifiedNamespace(this IUsingDirective directive)
        {
            if (directive is IUsingAliasDirective)
            {
                IUsingAliasDirective aliasDirective = directive as IUsingAliasDirective;

                DeclaredElementInstance<IDeclaredElement> declaredElementInstance = aliasDirective.DeclaredElement.GetAliasedSymbol();

                INamespace aliasedNamespace = declaredElementInstance == null ? null : declaredElementInstance.Element as INamespace;

                string returnValue = aliasedNamespace == null ? aliasDirective.ImportedSymbolName.QualifiedName : aliasedNamespace.QualifiedName;

                return returnValue;
            }

            return directive.ImportedSymbolName.QualifiedName;
        }
    }
}