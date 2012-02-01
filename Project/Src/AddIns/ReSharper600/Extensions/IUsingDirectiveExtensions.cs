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
//   Extension methods for the <see cref="IUsingDirective" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JetBrains.ReSharper.Psi.CSharp.Tree
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for the <see cref="IUsingDirective"/> class.
    /// </summary>
    public static class IUsingDirectiveExtensions
    {
        #region Methods

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
                var aliasDirective = directive as IUsingAliasDirective;

                var aliasedNamespace = aliasDirective.DeclaredElement.GetAliasedNamespace();

                var returnValue = aliasedNamespace == null ? aliasDirective.ImportedSymbol.QualifiedName : aliasedNamespace.QualifiedName;

                return returnValue;
            }

            var namespaceDirective = directive as IUsingNamespaceDirective;

            return namespaceDirective.ImportedNamespace == null ? namespaceDirective.ImportedNamespaceReferenceName.QualifiedName : namespaceDirective.ImportedNamespace.QualifiedName;
        }

        /// <summary>
        /// Gets a fully formed using statement expanding any abbreviated statement beginning with using and ending with a semicolon.
        /// </summary>
        /// <param name="directive">
        /// The directive to use.
        /// </param>
        /// <returns>
        /// The qualified using statement.
        /// </returns>
        internal static string GetFullyQualifiedStatement(this IUsingDirective directive)
        {
            if (directive is IUsingAliasDirective)
            {
                var aliasDirective = directive as IUsingAliasDirective;

                return string.Format("using {0} = {1};", aliasDirective.AliasName, directive.GetFullyQualifiedNamespace());
            }

            var namespaceDirective = directive as IUsingNamespaceDirective;

            return namespaceDirective != null ? string.Format("using {0};", directive.GetFullyQualifiedNamespace()) : directive.GetText();
        }

        /// <summary>
        /// Gets the root namespace of the Using directive after expanding any abbreviations.
        /// </summary>
        /// <param name="directive">
        /// The directive to use.
        /// </param>
        /// <returns>
        /// The root namespace.
        /// </returns>
        internal static string GetRootNamespace(this IUsingDirective directive)
        {
            return directive.GetFullyQualifiedNamespace().SubstringBefore('.').SubstringBefore(';');
        }

        #endregion
    }
}