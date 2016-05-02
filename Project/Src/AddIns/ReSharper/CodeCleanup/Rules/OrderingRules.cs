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
namespace StyleCop.ReSharper.CodeCleanup.Rules
{
    using System;
    using System.Collections.Generic;

    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper.Extensions;

    /// <summary>
    /// Fixes SA1208, SA1209, SA1210, and SA1211.
    /// </summary>
    public class OrderingRules
    {
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
        /// Run the OrderingRules Fix.
        /// </summary>
        /// <param name="file">
        /// File that the fix will be performed on.
        /// </param>
        /// <param name="settings">
        /// The settings to use.
        /// </param>
        public static void ExecuteAll(ICSharpFile file, Settings settings)
        {
            StyleCopTrace.In(file, settings);

            var analyzerSettings = new AnalyzerSettings(settings, "StyleCop.CSharp.OrderingRules");

            OrderUsings(file, analyzerSettings);
            OrderPropertyIndexerAndEventDeclarations(file, analyzerSettings);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Orders the files usings statements.
        /// </summary>
        /// <param name="file">
        /// The file to process.
        /// </param>
        /// <param name="analyzerSettings">
        /// The settings for the analyzer.
        /// </param>
        private static void OrderUsings(ICSharpFile file, AnalyzerSettings analyzerSettings)
        {
            bool organiseUsings = analyzerSettings.IsRuleEnabled("UsingDirectivesMustBeOrderedAlphabeticallyByNamespace");

            // TODO: Does this have a related setting?
            // It used to be a code cleanup setting, but doesn't seem to have a related StyleCop setting.
            // If there's no StyleCop setting (and therefore rule) we shouldn't do anything
            bool expandUsings = true;

            // Exit if both options are to ignore
            if (!organiseUsings && !expandUsings)
            {
                return;
            }

            foreach (ICSharpNamespaceDeclaration namespaceDeclaration in file.NamespaceDeclarations)
            {
                ProcessImports(namespaceDeclaration.Imports, organiseUsings, expandUsings, namespaceDeclaration);
            }

            ProcessImports(file.Imports, organiseUsings, expandUsings, file);
        }

        private static void ProcessImports(
            IList<IUsingDirective> originalImportsList, 
            bool organiseUsings, 
            bool expandUsings, 
            ICSharpTypeAndNamespaceHolderDeclaration declaration)
        {
            if (originalImportsList == null || originalImportsList.Count == 0)
            {
                return;
            }

            List<IUsingDirective> sortedImportsList = new List<IUsingDirective>();
            sortedImportsList.AddRange(originalImportsList);

            if (organiseUsings)
            {
                sortedImportsList.Sort(new UsingStatementSorter());
            }

            bool alreadySorted = true;
            bool alreadyExpanded = true;
            for (int i = 0; i < originalImportsList.Count; i++)
            {
                if (originalImportsList[i] != sortedImportsList[i])
                {
                    alreadySorted = false;
                    break;
                }

                IUsingAliasDirective aliasDirective = originalImportsList[i] as IUsingAliasDirective;
                if (aliasDirective != null)
                {
                    if (aliasDirective.ImportedSymbolName.GetText() != aliasDirective.GetFullyQualifiedNamespace())
                    {
                        alreadyExpanded = false;
                        break;
                    }
                }
            }

            if (alreadySorted && alreadyExpanded)
                return;

            foreach (IUsingDirective directive in sortedImportsList)
            {
                IUsingDirective newUsingDirective;

                if (expandUsings)
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

        private static void ProcessMemberDeclarations(IDeclaration declaration, bool propertyAccessorsMustFollowOrder, bool eventAccessorsMustFollowOrder)
        {
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

        private static void OrderPropertyIndexerAndEventDeclarations(ICSharpFile file, AnalyzerSettings analyzerSettings)
        {
            bool propertyAccessorsMustFollowOrder = analyzerSettings.IsRuleEnabled("PropertyAccessorsMustFollowOrder");
            bool eventAccessorsMustFollowOrder = analyzerSettings.IsRuleEnabled("EventAccessorsMustFollowOrder");

            foreach (ICSharpNamespaceDeclaration namespaceDeclaration in file.NamespaceDeclarations)
            {
                ProcessTypeDeclarations(namespaceDeclaration.TypeDeclarations, propertyAccessorsMustFollowOrder, eventAccessorsMustFollowOrder);
            }

            ProcessTypeDeclarations(file.TypeDeclarations, propertyAccessorsMustFollowOrder, eventAccessorsMustFollowOrder);
        }

        private static void ProcessNestedTypeDeclarations(IEnumerable<ITypeDeclaration> typeDeclarations, bool propertyAccessorsMustFollowOrder, bool eventAccessorsMustFollowOrder)
        {
            foreach (ITypeDeclaration typeDeclaration in typeDeclarations)
            {
                foreach (ITypeMemberDeclaration memberDeclaration in typeDeclaration.MemberDeclarations)
                {
                    ProcessMemberDeclarations(memberDeclaration, propertyAccessorsMustFollowOrder, eventAccessorsMustFollowOrder);
                }

                ProcessNestedTypeDeclarations(typeDeclaration.NestedTypeDeclarations, propertyAccessorsMustFollowOrder, eventAccessorsMustFollowOrder);
            }
        }

        private static void ProcessTypeDeclarations(TreeNodeCollection<ICSharpTypeDeclaration> typeDeclarations, bool propertyAccessorsMustFollowOrder, bool eventAccessorsMustFollowOrder)
        {
            foreach (ICSharpTypeDeclaration typeDeclaration in typeDeclarations)
            {
                foreach (ICSharpTypeMemberDeclaration memberDeclaration in typeDeclaration.MemberDeclarations)
                {
                    ProcessMemberDeclarations(memberDeclaration, propertyAccessorsMustFollowOrder, eventAccessorsMustFollowOrder);
                }

                ProcessNestedTypeDeclarations(typeDeclaration.NestedTypeDeclarations, propertyAccessorsMustFollowOrder, eventAccessorsMustFollowOrder);
            }
        }

        /// <summary>
        /// A custom sorter for IUsingDirectives.
        /// </summary>
        internal class UsingStatementSorter : IComparer<IUsingDirective>
        {
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
        }
    }
}