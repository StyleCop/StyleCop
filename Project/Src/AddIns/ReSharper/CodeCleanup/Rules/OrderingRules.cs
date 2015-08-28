// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderingRules.cs" company="http://stylecop.codeplex.com">
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
//   Fixes SA1208, SA1209, SA1210, and SA1211.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper800.CodeCleanup.Rules
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper800.CodeCleanup.Options;
    using StyleCop.ReSharper800.CodeCleanup.Styles;

    #endregion

    /// <summary>
    /// Fixes SA1208, SA1209, SA1210, and SA1211.
    /// </summary>
    public class OrderingRules
    {
        #region Public Methods and Operators

        /// <summary>
        /// Ensures if the declaration has more than 1 accessor that they are in the correct order.
        /// </summary>
        /// <param name="declarationNode">
        /// The node to use.
        /// </param>
        public static void CheckAccessorOrder(IAccessorOwnerDeclaration declarationNode)
        {
            TreeNodeCollection<IAccessorDeclaration> accessorDeclarations = declarationNode.AccessorDeclarations;

            if (accessorDeclarations.Count < 2)
            {
                // don't need to reorder because there's only 1 (or none)
                return;
            }

            // we now know we have 2 accessors
            IAccessorDeclaration firstAccessor = accessorDeclarations[0];
            IAccessorDeclaration secondAccessor = accessorDeclarations[1];

            if (firstAccessor.Kind == AccessorKind.GETTER || firstAccessor.Kind == AccessorKind.ADDER)
            {
                return;
            }

            IAccessorDeclaration newAccessor = firstAccessor.CopyWithResolve();

            declarationNode.AddAccessorDeclarationAfter(newAccessor, secondAccessor);
            declarationNode.RemoveAccessorDeclaration(firstAccessor);

            LayoutRules.ClosingCurlyBracketMustBeFollowedByBlankLine(declarationNode);
        }

        /// <summary>
        /// Orders the files usings statements.
        /// </summary>
        /// <param name="options">
        /// The options to use.
        /// </param>
        /// <param name="file">
        /// The file to process.
        /// </param>
        public static void OrderUsings(OrderingOptions options, ICSharpFile file)
        {
            AlphabeticalUsingsStyle organiseUsingsFormatOption = options.AlphabeticalUsingDirectives;
            ExpandUsingsStyle expandUsingsFormatOption = options.ExpandUsingDirectives;

            // Exit if both options are to ignore
            if (organiseUsingsFormatOption == AlphabeticalUsingsStyle.Ignore && expandUsingsFormatOption == ExpandUsingsStyle.Ignore)
            {
                return;
            }

            foreach (ICSharpNamespaceDeclaration namespaceDeclaration in file.NamespaceDeclarations)
            {
                ProcessImports(namespaceDeclaration.Imports, organiseUsingsFormatOption, expandUsingsFormatOption, namespaceDeclaration);
            }

            ProcessImports(file.Imports, organiseUsingsFormatOption, expandUsingsFormatOption, file);
        }

        /// <summary>
        /// Run the OrderingRules Fix.
        /// </summary>
        /// <param name="options">
        /// OrderingOptions for the Fix.
        /// </param>
        /// <param name="file">
        /// File that the fix will be performed on.
        /// </param>
        public void Execute(OrderingOptions options, ICSharpFile file)
        {
            StyleCopTrace.In(options, file);

            OrderUsings(options, file);

            this.OrderPropertyIndexerAndEventDeclarations(options, file);
            StyleCopTrace.Out();
        }

        #endregion

        #region Methods

        private static void ProcessImports(
            IList<IUsingDirective> newImportsList, 
            AlphabeticalUsingsStyle organiseUsingsFormatOption, 
            ExpandUsingsStyle expandUsingsFormatOption, 
            ICSharpTypeAndNamespaceHolderDeclaration declaration)
        {
            if (newImportsList == null || newImportsList.Count == 0)
            {
                return;
            }

            List<IUsingDirective> arrayList = new List<IUsingDirective>();
            arrayList.AddRange(newImportsList);

            if (organiseUsingsFormatOption == AlphabeticalUsingsStyle.Alphabetical)
            {
                arrayList.Sort(new UsingStatementSorter());
            }

            foreach (IUsingDirective directive in arrayList)
            {
                IUsingDirective newUsingDirective;

                if (expandUsingsFormatOption == ExpandUsingsStyle.FullyQualify)
                {
                    if (directive is IUsingAliasDirective)
                    {
                        IUsingAliasDirective aliasDirective = directive as IUsingAliasDirective;
                        newUsingDirective =
                            CSharpElementFactory.GetInstance(declaration.GetPsiModule())
                                                .CreateUsingDirective(aliasDirective.AliasName + " = " + directive.GetFullyQualifiedNamespace());

                        IUsingAliasDirective n = newUsingDirective as IUsingAliasDirective;
                        n.SetImportedSymbolName(aliasDirective.ImportedSymbolName);
                    }
                    else
                    {
                        newUsingDirective = CSharpElementFactory.GetInstance(declaration.GetPsiModule()).CreateUsingDirective(directive.GetFullyQualifiedNamespace());
                    }
                }
                else
                {
                    newUsingDirective = directive.CopyWithResolve();
                }

                declaration.RemoveImport(directive);
                declaration.AddImportBefore(newUsingDirective, null);
            }
        }

        private static void ProcessMemberDeclarations(IDeclaration declaration, OrderingOptions options)
        {
            bool propertyAccessorsMustFollowOrder = options.SA1212PropertyAccessorsMustFollowOrder;
            bool eventAccessorsMustFollowOrder = options.SA1213EventAccessorsMustFollowOrder;

            if (declaration is IIndexerDeclaration && propertyAccessorsMustFollowOrder)
            {
                CheckAccessorOrder(declaration as IIndexerDeclaration);
            }
            else if (declaration is IPropertyDeclaration && propertyAccessorsMustFollowOrder)
            {
                CheckAccessorOrder(declaration as IPropertyDeclaration);
            }
            else if (declaration is IEventDeclaration && eventAccessorsMustFollowOrder)
            {
                CheckAccessorOrder(declaration as IEventDeclaration);
            }
        }

        private void OrderPropertyIndexerAndEventDeclarations(OrderingOptions options, ICSharpFile file)
        {
            foreach (ICSharpNamespaceDeclaration namespaceDeclaration in file.NamespaceDeclarations)
            {
                this.ProcessTypeDeclarations(options, namespaceDeclaration.TypeDeclarations);
            }

            this.ProcessTypeDeclarations(options, file.TypeDeclarations);
        }

        private void ProcessNestedTypeDeclarations(OrderingOptions options, IEnumerable<ITypeDeclaration> typeDeclarations)
        {
            foreach (ITypeDeclaration typeDeclaration in typeDeclarations)
            {
                foreach (ITypeMemberDeclaration memberDeclaration in typeDeclaration.MemberDeclarations)
                {
                    ProcessMemberDeclarations(memberDeclaration, options);
                }

                this.ProcessNestedTypeDeclarations(options, typeDeclaration.NestedTypeDeclarations);
            }
        }

        private void ProcessTypeDeclarations(OrderingOptions options, IEnumerable<ICSharpTypeDeclaration> typeDeclarations)
        {
            foreach (ICSharpTypeDeclaration typeDeclaration in typeDeclarations)
            {
                foreach (ICSharpTypeMemberDeclaration memberDeclaration in typeDeclaration.MemberDeclarations)
                {
                    ProcessMemberDeclarations(memberDeclaration, options);
                }

                this.ProcessNestedTypeDeclarations(options, typeDeclaration.NestedTypeDeclarations);
            }
        }

        #endregion

        /// <summary>
        /// A custom sorter for IUsingDirectives.
        /// </summary>
        internal class UsingStatementSorter : IComparer<IUsingDirective>
        {
            #region Public Methods and Operators

            /// <summary>
            /// Compares the IUsingDirectives provided.
            /// </summary>
            /// <param name="usingDirectiveA">
            /// The first Using Directive.
            /// </param>
            /// <param name="usingDirectiveB">
            /// The second Using Directive.
            /// </param>
            /// <returns>
            /// An integer indicating the comparison.
            /// </returns>
            public int Compare(IUsingDirective usingDirectiveA, IUsingDirective usingDirectiveB)
            {
                bool usingDirectiveAIsAlias = usingDirectiveA is IUsingAliasDirective;
                bool usingDirectiveBIsAlias = usingDirectiveB is IUsingAliasDirective;

                if (usingDirectiveAIsAlias && !usingDirectiveBIsAlias)
                {
                    return 1;
                }

                if (!usingDirectiveAIsAlias && usingDirectiveBIsAlias)
                {
                    return -1;
                }

                if (usingDirectiveAIsAlias)
                {
                    IUsingAliasDirective usingAliasDirectiveA = usingDirectiveA as IUsingAliasDirective;
                    IUsingAliasDirective usingAliasDirectiveB = usingDirectiveB as IUsingAliasDirective;

                    if (usingAliasDirectiveA != null)
                    {
                        if (usingAliasDirectiveB != null)
                        {
                            return string.Compare(usingAliasDirectiveA.AliasName, usingAliasDirectiveB.AliasName, StringComparison.OrdinalIgnoreCase);
                        }
                    }
                }

                string usingNamespaceDirectiveAQualifiedNamespace = usingDirectiveA.GetFullyQualifiedNamespace();
                string usingNamespaceDirectiveBQualifiedNamespace = usingDirectiveB.GetFullyQualifiedNamespace();

                bool usingNamespaceDirectiveATextStartsWithSystem = usingNamespaceDirectiveAQualifiedNamespace.StartsWith("System");
                bool usingNamespaceDirectiveBTextStartsWithSystem = usingNamespaceDirectiveBQualifiedNamespace.StartsWith("System");

                if (usingNamespaceDirectiveATextStartsWithSystem && !usingNamespaceDirectiveBTextStartsWithSystem)
                {
                    return -1;
                }

                if (!usingNamespaceDirectiveATextStartsWithSystem && usingNamespaceDirectiveBTextStartsWithSystem)
                {
                    return 1;
                }

                return string.Compare(
                    usingNamespaceDirectiveAQualifiedNamespace.SubstringBefore(';'), 
                    usingNamespaceDirectiveBQualifiedNamespace.SubstringBefore(';'), 
                    StringComparison.OrdinalIgnoreCase);
            }

            #endregion
        }
    }
}