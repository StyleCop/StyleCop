// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadabilityRules.cs" company="http://stylecop.codeplex.com">
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
//   Readability rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper.CodeCleanup.Rules
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.Application;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.CSharp.Tree.Extensions;
    using JetBrains.ReSharper.Psi.ExtensionsAPI;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
    using JetBrains.ReSharper.Psi.Tree;

    using StyleCop.ReSharper.CodeCleanup.Options;
    using StyleCop.ReSharper.Core;
    using StyleCop.ReSharper.Diagnostics;
    using StyleCop.ReSharper.Extensions;

    #endregion

    /// <summary>
    /// Readability rules.
    /// </summary>
    internal class ReadabilityRules
    {
        /// <summary>
        /// The built-in type aliases for C#.
        /// </summary>
        private static readonly string[][] builtInTypes = new[]
        {
            new[] { "Boolean", "System.Boolean", "bool" },
            new[] { "Object", "System.Object", "object" },
            new[] { "String", "System.String", "string" },
            new[] { "Int16", "System.Int16", "short" },
            new[] { "UInt16", "System.UInt16", "ushort" },
            new[] { "Int32", "System.Int32", "int" },
            new[] { "UInt32", "System.UInt32", "uint" },
            new[] { "Int64", "System.Int64", "long" },
            new[] { "UInt64", "System.UInt64", "ulong" },
            new[] { "Double", "System.Double", "double" },
            new[] { "Single", "System.Single", "float" },
            new[] { "Byte", "System.Byte", "byte" },
            new[] { "SByte", "System.SByte", "sbyte" },
            new[] { "Char", "System.Char", "char" },
            new[] { "Decimal", "System.Decimal", "decimal" }
        };

        #region Public Methods

        /// <summary>
        /// Moves the comment token specified after the next available non whitespace char (normally an open curly bracket).
        /// </summary>
        /// <param name="commentTokenNode">
        /// The comment token to move.
        /// </param>
        public static void MoveCommentInsideNextOpenCurlyBracket(ITokenNode commentTokenNode)
        {
            using (WriteLockCookie.Create(true))
            {
                // move comment inside block curly bracket here
                // we copy it, then insert it and then delete the copied one
                var startOfTokensToDelete = Utils.GetFirstNonWhitespaceTokenToLeft(commentTokenNode).GetNextToken();
                var endOfTokensToDelete = Utils.GetFirstNewLineTokenToRight(commentTokenNode);
                var startOfTokensToFormat = startOfTokensToDelete.GetPrevToken();

                var openCurlyBracketTokenNode = Utils.GetFirstNonWhitespaceTokenToRight(commentTokenNode);
                var newCommentTokenNode = commentTokenNode.CopyElement(null);
                var tokenNodeToInsertAfter = Utils.GetFirstNewLineTokenToRight(openCurlyBracketTokenNode);
                LowLevelModificationUtil.AddChildAfter(tokenNodeToInsertAfter, new[] { newCommentTokenNode });
                LowLevelModificationUtil.AddChildAfter(newCommentTokenNode, newCommentTokenNode.InsertNewLineAfter());

                DeleteChildRange(startOfTokensToDelete, endOfTokensToDelete);
                var endOfTokensToFormat = newCommentTokenNode;

                CSharpFormatterHelper.FormatterInstance.Format(startOfTokensToFormat, endOfTokensToFormat);
            }
        }

        /// <summary>
        /// Moves the IStartRegion specified inside the next open curly bracket and moves the corrsponding endregion inside too.
        /// </summary>
        /// <param name="startRegionNode">
        /// The node to move.
        /// </param>
        public static void MoveRegionInsideNextOpenCurlyBracket(IStartRegionNode startRegionNode)
        {
            using (WriteLockCookie.Create(true))
            {
                var newLocationTokenNode = Utils.GetFirstNonWhitespaceTokenToRight(startRegionNode.Message);

                // if its a start region there is probably a corresponding end region
                // find it, and move it inside the block
                // find the position to delete from
                var startOfTokensToDelete = Utils.GetFirstNewLineTokenToLeft(startRegionNode.NumberSign);
                var endOfTokensToDelete = Utils.GetFirstNewLineTokenToRight(startRegionNode.Message);
                var startOfTokensToFormat = startOfTokensToDelete.GetPrevToken();

                var endRegionNode = startRegionNode.EndRegion;
                var newStartRegionNode = startRegionNode.CopyElement(null);
                var firstNonWhitespaceAfterBracket = Utils.GetFirstNonWhitespaceTokenToRight(newLocationTokenNode);

                LowLevelModificationUtil.AddChildBefore(firstNonWhitespaceAfterBracket, new[] { newStartRegionNode });

                newStartRegionNode.ToTreeNode().InsertNewLineAfter();

                LowLevelModificationUtil.DeleteChildRange(startOfTokensToDelete, endOfTokensToDelete);
                var endOfTokensToFormat = (IElement)newStartRegionNode;

                if (endRegionNode != null)
                {
                    startOfTokensToDelete = Utils.GetFirstNewLineTokenToLeft(endRegionNode.NumberSign);
                    endOfTokensToDelete = Utils.GetFirstNewLineTokenToRight(endRegionNode.NumberSign);

                    var newEndRegionNode = endRegionNode.CopyElement(null);
                    var newLineToken = Utils.GetFirstNonWhitespaceTokenToLeft(endRegionNode.NumberSign);
                    LowLevelModificationUtil.AddChildBefore(newLineToken, new[] { newEndRegionNode });

                    newEndRegionNode.InsertNewLineAfter();

                    LowLevelModificationUtil.DeleteChildRange(startOfTokensToDelete, endOfTokensToDelete);
                    endOfTokensToFormat = newLineToken;
                }

                CSharpFormatterHelper.FormatterInstance.Format(startOfTokensToFormat, endOfTokensToFormat);
            }
        }

        /// <summary>
        /// Remove empty comments.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        public static void RemoveEmptyComments(ITreeNode node)
        {
            // we don't remove empty lines from Element Doc Comments in here
            // the DeclarationHeader types take care of that.
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var commentNode = currentNode as ICommentNode;
                    if (commentNode != null && !(commentNode is IDocCommentNode))
                    {
                        if (commentNode.CommentText.Trim() == string.Empty)
                        {
                            var leftToken = Utils.GetFirstNewLineTokenToLeft((ITokenNode)currentNode);

                            var rightToken = Utils.GetFirstNewLineTokenToRight((ITokenNode)currentNode);

                            if (leftToken == null)
                            {
                                leftToken = (ITokenNode)currentNode;
                            }
                            else
                            {
                                leftToken = leftToken.GetNextToken();
                            }

                            if (rightToken == null)
                            {
                                rightToken = (ITokenNode)currentNode;
                            }
                            else
                            {
                                currentNode = rightToken.GetNextToken();
                            }

                            using (WriteLockCookie.Create(true))
                            {
                                LowLevelModificationUtil.DeleteChildRange(leftToken, rightToken);
                            }
                        }
                    }
                }

                if (currentNode != null && currentNode.FirstChild != null)
                {
                    RemoveEmptyComments(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Swap base to this unless local implementation.
        /// </summary>
        /// <param name="invocationExpression">
        /// The invocation expression.
        /// </param>
        public static void SwapBaseToThisUnlessLocalImplementation(IInvocationExpression invocationExpression)
        {
            var isOverride = false;

            var isNew = false;

            var invokedExpression = invocationExpression.InvokedExpression;

            if (invokedExpression != null)
            {
                var referenceExpressionNode = invokedExpression as IReferenceExpressionNode;

                if (referenceExpressionNode != null)
                {
                    var referenceExpression = invokedExpression as IReferenceExpression;
                    if (referenceExpression != null)
                    {
                        var qualifierExpression = referenceExpression.QualifierExpression;
                        if (qualifierExpression is IBaseExpression)
                        {
                            var methodName = referenceExpressionNode.NameIdentifier.Name;

                            var typeDeclaration = invocationExpression.GetContainingElement<ICSharpTypeDeclaration>(true);

                            if (typeDeclaration != null)
                            {
                                foreach (var memberDeclaration in typeDeclaration.MemberDeclarations)
                                {
                                    if (memberDeclaration.DeclaredName == methodName)
                                    {
                                        var methodDeclaration = memberDeclaration as IMethodDeclaration;
                                        if (methodDeclaration != null)
                                        {
                                            isOverride = methodDeclaration.IsOverride;
                                            isNew = methodDeclaration.IsNew();
                                            break;
                                        }
                                    }
                                }

                                if (isOverride || isNew)
                                {
                                    return;
                                }

                                using (WriteLockCookie.Create(true))
                                {
                                    // swap the base to this
                                    var expression = CSharpElementFactory.GetInstance(invocationExpression.GetPsiModule()).CreateExpression("this");

                                    referenceExpression.SetQualifierExpression(expression);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swap to built in type alias.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        public static void SwapToBuiltInTypeAlias(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                var typeArgumentListNode = currentNode as ITypeArgumentListNode;
                if (typeArgumentListNode != null)
                {
                    SwapGenericDeclarationToBuiltInType(typeArgumentListNode);
                }
                else
                {
                    var methodDeclarationNode = currentNode as IMethodDeclarationNode;
                    if (methodDeclarationNode != null)
                    {
                        SwapReturnTypeToBuiltInType(methodDeclarationNode);
                    }
                    else
                    {
                        var variableDeclaration = currentNode as IVariableDeclarationNode;
                        if (variableDeclaration != null)
                        {
                            SwapVariableDeclarationToBuiltInType(variableDeclaration);
                        }
                        else
                        {
                            var creationExpressionNode = currentNode as IObjectCreationExpressionNode;
                            if (creationExpressionNode != null)
                            {
                                SwapObjectCreationToBuiltInType(creationExpressionNode);
                            }
                            else
                            {
                                var arrayCreationNode = currentNode as IArrayCreationExpressionNode;
                                if (arrayCreationNode != null)
                                {
                                    SwapArrayCreationToBuiltInType(arrayCreationNode);
                                }
                                else
                                {
                                    var referenceExpressionNode = currentNode as IReferenceExpressionNode;
                                    if (referenceExpressionNode != null)
                                    {
                                        SwapReferenceExpressionToBuiltInType(referenceExpressionNode);
                                    }
                                }
                            }
                        }
                    }
                }

                if (currentNode != null && currentNode.FirstChild != null)
                {
                    SwapToBuiltInTypeAlias(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Executes the cleanup rules.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="file">
        /// The file to process.
        /// </param>
        public void Execute(ReadabilityOptions options, ICSharpFile file)
        {
            StyleCopTrace.In(options, file);
            var dontPrefixCallsWithBaseUnlessLocalImplementationExists = options.SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists;
            var codeMustNotContainEmptyStatements = options.SA1106CodeMustNotContainEmptyStatements;
            var blockStatementsMustNotContainEmbeddedComments = options.SA1108BlockStatementsMustNotContainEmbeddedComments;
            var blockStatementsMustNotContainEmbeddedRegions = options.SA1109BlockStatementsMustNotContainEmbeddedRegions;
            var commentsMustContainText = options.SA1120CommentsMustContainText;
            var useBuiltInTypeAlias = options.SA1121UseBuiltInTypeAlias;
            var useStringEmptyForEmptyStrings = options.SA1122UseStringEmptyForEmptyStrings;
            var dontPlaceRegionsWithinElements = options.SA1123DoNotPlaceRegionsWithinElements;
            var codeMustNotContainEmptyRegions = options.SA1124CodeMustNotContainEmptyRegions;

            if (dontPlaceRegionsWithinElements)
            {
                this.DoNotPlaceRegionsWithinElements(file.ToTreeNode().FirstChild);
            }

            if (blockStatementsMustNotContainEmbeddedComments)
            {
                this.BlockStatementsMustNotContainEmbeddedComments(file.ToTreeNode().FirstChild);
            }

            if (blockStatementsMustNotContainEmbeddedRegions)
            {
                this.BlockStatementsMustNotContainEmbeddedRegions(file.ToTreeNode().FirstChild);
            }

            if (codeMustNotContainEmptyStatements)
            {
                this.CodeMustNotContainEmptyStatements(file.ToTreeNode().FirstChild);
            }

            if (codeMustNotContainEmptyRegions)
            {
                this.CodeMustNotContainEmptyRegions(file.ToTreeNode().FirstChild);
            }

            if (useStringEmptyForEmptyStrings)
            {
                this.ReplaceEmptyStringsWithStringDotEmpty(file.ToTreeNode().FirstChild);
            }

            if (useBuiltInTypeAlias)
            {
                SwapToBuiltInTypeAlias(file.ToTreeNode().FirstChild);
            }

            if (commentsMustContainText)
            {
                RemoveEmptyComments(file.ToTreeNode().FirstChild);
            }

            if (dontPrefixCallsWithBaseUnlessLocalImplementationExists)
            {
                this.DoNotPrefixCallsWithBaseUnlessLocalImplementationExists(file.ToTreeNode().FirstChild);
            }

            StyleCopTrace.Out();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete child range.
        /// </summary>
        /// <param name="first">
        /// The first token to delete.
        /// </param>
        /// <param name="last">
        /// The last token to delete.
        /// </param>
        private static void DeleteChildRange(ITokenNode first, ITokenNode last)
        {
            using (WriteLockCookie.Create(true))
            {
                var a = new List<ITokenNode>();

                var tokenNodeToStopAt = last.GetNextToken();
                for (var foundToken = first; foundToken != tokenNodeToStopAt; foundToken = foundToken.GetNextToken())
                {
                    a.Add(foundToken);
                }

                foreach (var tokenNode in a)
                {
                    LowLevelModificationUtil.DeleteChild(tokenNode);
                }
            }
        }

        /// <summary>
        /// Process foreach variable declaration.
        /// </summary>
        /// <param name="foreachVariableDeclaration">
        /// The foreach variable declaration.
        /// </param>
        private static void ProcessForeachVariableDeclaration(IForeachVariableDeclaration foreachVariableDeclaration)
        {
            var variable = (ILocalVariable)foreachVariableDeclaration.DeclaredElement;
            if (variable != null)
            {
                if (!foreachVariableDeclaration.IsVar)
                {
                    using (WriteLockCookie.Create(true))
                    {
                        foreachVariableDeclaration.SetType(variable.Type);
                    }
                }
            }
        }

        /// <summary>
        /// Process local variable declaration.
        /// </summary>
        /// <param name="localVariableDeclaration">
        /// The local variable declaration.
        /// </param>
        private static void ProcessLocalVariableDeclaration(ILocalVariableDeclarationNode localVariableDeclaration)
        {
            var multipleDeclaration = MultipleLocalVariableDeclarationNodeNavigator.GetByDeclarator(localVariableDeclaration);

            if (multipleDeclaration.Declarators.Count > 1)
            {
                var newType = CSharpTypeFactory.CreateType(multipleDeclaration.TypeUsage);

                using (WriteLockCookie.Create(true))
                {
                    multipleDeclaration.SetTypeUsage(CSharpElementFactory.GetInstance(localVariableDeclaration.GetPsiModule()).CreateTypeUsageNode(newType));
                }
            }
            else
            {
                var variable = (ILocalVariable)localVariableDeclaration.DeclaredElement;
                if (variable != null)
                {
                    if (!multipleDeclaration.IsVar)
                    {
                        using (WriteLockCookie.Create(true))
                        {
                            localVariableDeclaration.SetType(variable.Type);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swap array creation to built in type.
        /// </summary>
        /// <param name="arrayCreationExpression">
        /// The array creation expression.
        /// </param>
        private static void SwapArrayCreationToBuiltInType(IArrayCreationExpression arrayCreationExpression)
        {
            if (!arrayCreationExpression.IsImplicitlyTypedArray)
            {
                using (WriteLockCookie.Create(true))
                {
                    var fileIsCSharp30 = Utils.IsCSharp30(arrayCreationExpression.GetProjectFile());

                    // If the array creation type is the same type as the initializer (and we are CSharp 3.0 or greater) remove it completely
                    var arrayType = arrayCreationExpression.Type() as IArrayType;
                    if ((arrayType != null) && arrayCreationExpression.ArrayInitializer != null && fileIsCSharp30 &&
                        arrayType.ElementType.Equals(arrayCreationExpression.ArrayInitializer.GetElementType(true)))
                    {
                        var dims = arrayCreationExpression.ToTreeNode().Dims;
                        arrayCreationExpression.SetArrayType(null);
                        for (var i = 0; i < (dims.Count - 1); i++)
                        {
                            using (WriteLockCookie.Create(true))
                            {
                                ModificationUtil.DeleteChild(dims[i]);
                            }
                        }

                        foreach (var size in arrayCreationExpression.Sizes)
                        {
                            if (size != null)
                            {
                                using (WriteLockCookie.Create(true))
                                {
                                    ModificationUtil.DeleteChild(size.ToTreeNode());
                                }
                            }
                        }
                    }
                    else
                    {
                        using (WriteLockCookie.Create(true))
                        {
                            arrayCreationExpression.SetArrayType(arrayType);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swap generic declaration to built in type.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private static void SwapGenericDeclarationToBuiltInType(ITypeArgumentListNode node)
        {
            var project = node.GetPsiModule();
            var typeUsageNodes = node.TypeArgumentNodes;
            var types = node.TypeArguments;

            using (WriteLockCookie.Create(true))
            {
                for (var i = 0; i < typeUsageNodes.Count; i++)
                {
                    if (!types[i].IsUnknown)
                    {
                        var newTypeUsageNode = CSharpElementFactory.GetInstance(project).CreateTypeUsageNode(types[i]);

                        using (WriteLockCookie.Create(true))
                        {
                            ModificationUtil.ReplaceChild(typeUsageNodes[i], newTypeUsageNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swap object creation to built in type.
        /// </summary>
        /// <param name="objectCreationExpressionNode">
        /// The object creation expression node.
        /// </param>
        private static void SwapObjectCreationToBuiltInType(IObjectCreationExpressionNode objectCreationExpressionNode)
        {
            var project = objectCreationExpressionNode.GetPsiModule();

            using (WriteLockCookie.Create(true))
            {
                var tmpExpression = (IObjectCreationExpressionNode)CSharpElementFactory.GetInstance(project).CreateExpression("new $0?()", new object[] { objectCreationExpressionNode.Type() });
                if (tmpExpression != null)
                {
                    objectCreationExpressionNode.SetCreatedTypeUsage(tmpExpression.CreatedTypeUsage);
                }
            }
        }

        /// <summary>
        /// Swap reference expression to built in type.
        /// </summary>
        /// <param name="referenceExpression">
        /// The reference expression.
        /// </param>
        private static void SwapReferenceExpressionToBuiltInType(IReferenceExpression referenceExpression)
        {
            var project = referenceExpression.GetPsiModule();
            var qualifierExpression = referenceExpression.QualifierExpression;

            if (qualifierExpression != null)
            {
                using (WriteLockCookie.Create(true))
                {
                    foreach (string[] builtInType in builtInTypes)
                    {
                        string text = qualifierExpression.GetText();
                        if (text == builtInType[0] || text == builtInType[1])
                        {
                            ICSharpExpression expression = CSharpElementFactory.GetInstance(project).CreateExpression(builtInType[2], new object[0]);
                            referenceExpression.SetQualifierExpression(expression);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swap return type to built in type.
        /// </summary>
        /// <param name="methodDeclaration">
        /// The method declaration.
        /// </param>
        private static void SwapReturnTypeToBuiltInType(IMethodDeclaration methodDeclaration)
        {
            using (WriteLockCookie.Create(true))
            {
                methodDeclaration.SetType(methodDeclaration.GetReturnType());
            }
        }

        /// <summary>
        /// Swap variable declaration to built in type.
        /// </summary>
        /// <param name="variableDeclaration">
        /// The variable declaration.
        /// </param>
        private static void SwapVariableDeclarationToBuiltInType(IVariableDeclaration variableDeclaration)
        {
            if (variableDeclaration is ILocalVariableDeclarationNode)
            {
                ProcessLocalVariableDeclaration((ILocalVariableDeclarationNode)variableDeclaration);
            }
            else if (variableDeclaration is IForeachVariableDeclarationNode)
            {
                ProcessForeachVariableDeclaration((IForeachVariableDeclarationNode)variableDeclaration);
            }
            else
            {
                var declaredElement = variableDeclaration.DeclaredElement;
                var typeOwner = (ITypeOwner)declaredElement;

                if (typeOwner != null)
                {
                    using (WriteLockCookie.Create(true))
                    {
                        variableDeclaration.SetType(typeOwner.Type);
                    }
                }
            }
        }

        /// <summary>
        /// Block statements must not contain embedded comments.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private void BlockStatementsMustNotContainEmbeddedComments(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.LBRACE)
                    {
                        var previousTokenNode = Utils.GetFirstNonWhitespaceTokenToLeft(tokenNode);
                        if (previousTokenNode.GetTokenType() == CSharpTokenType.END_OF_LINE_COMMENT)
                        {
                            var commentNode = previousTokenNode.GetContainingElement<ICommentNode>(true);
                            MoveCommentInsideNextOpenCurlyBracket(commentNode);
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.BlockStatementsMustNotContainEmbeddedComments(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Block statements must not contain embedded regions.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private void BlockStatementsMustNotContainEmbeddedRegions(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.LBRACE)
                    {
                        var previousTokenNode = Utils.GetFirstNonWhitespaceTokenToLeft(tokenNode);
                        var previousTokenNode2 = previousTokenNode.GetPrevToken();

                        if (previousTokenNode.GetTokenType() == CSharpTokenType.PP_MESSAGE && previousTokenNode2.GetTokenType() == CSharpTokenType.PP_START_REGION)
                        {
                            var startRegionNode = previousTokenNode.GetContainingElement<IStartRegionNode>(true);
                            if (startRegionNode != null)
                            {
                                MoveRegionInsideNextOpenCurlyBracket(startRegionNode);
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.BlockStatementsMustNotContainEmbeddedRegions(currentNode.FirstChild);
                }
            }
        }

        private void CodeMustNotContainEmptyRegions(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.PP_START_REGION)
                    {
                        var startRegionNode = tokenNode.GetContainingElement<IStartRegionNode>(true);

                        var endRegion = startRegionNode.EndRegion;

                        if (endRegion != null)
                        {
                            var previousTokenNode = Utils.GetFirstNonWhitespaceTokenToLeft(endRegion.NumberSign);

                            var a = previousTokenNode.GetContainingElement<IStartRegionNode>(true);

                            if (a != null && a.Equals(startRegionNode))
                            {
                                using (WriteLockCookie.Create(true))
                                {
                                    ModificationUtil.DeleteChild(startRegionNode);
                                    ModificationUtil.DeleteChild(endRegion);
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.CodeMustNotContainEmptyRegions(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Code must not contain empty statements.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private void CodeMustNotContainEmptyStatements(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.SEMICOLON && !(tokenNode.Parent is IForStatement))
                    {
                        var nextNonWhitespaceToken = Utils.GetFirstNonWhitespaceTokenToRight(tokenNode);

                        while (nextNonWhitespaceToken.GetTokenType() == CSharpTokenType.SEMICOLON)
                        {
                            using (WriteLockCookie.Create(true))
                            {
                                if (nextNonWhitespaceToken.GetNextToken().GetTokenType() == CSharpTokenType.WHITE_SPACE)
                                {
                                    LowLevelModificationUtil.DeleteChild(nextNonWhitespaceToken.GetNextToken());
                                }

                                // remove the spare semi colon
                                LowLevelModificationUtil.DeleteChild(nextNonWhitespaceToken);
                                nextNonWhitespaceToken = Utils.GetFirstNonWhitespaceTokenToRight(tokenNode);
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.CodeMustNotContainEmptyStatements(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Do not place regions within elements.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private void DoNotPlaceRegionsWithinElements(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.PP_START_REGION)
                    {
                        var startRegionNode = tokenNode.GetContainingElement<IStartRegionNode>(true);
                        if (startRegionNode != null)
                        {
                            if (startRegionNode.Parent is IBlock)
                            {
                                // we're in a block so remove the end and start region
                                var endRegionNode = startRegionNode.EndRegion;

                                using (WriteLockCookie.Create(true))
                                {
                                    LowLevelModificationUtil.DeleteChild(endRegionNode);
                                    LowLevelModificationUtil.DeleteChild(startRegionNode);
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.DoNotPlaceRegionsWithinElements(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Do not prefix calls with base unless local implementation exists.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private void DoNotPrefixCallsWithBaseUnlessLocalImplementationExists(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                var invocationExpression = currentNode as IInvocationExpression;
                if (invocationExpression != null)
                {
                    SwapBaseToThisUnlessLocalImplementation(invocationExpression);
                }

                if (currentNode.FirstChild != null)
                {
                    this.DoNotPrefixCallsWithBaseUnlessLocalImplementationExists(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Replace empty strings with string dot empty.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private void ReplaceEmptyStringsWithStringDotEmpty(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.STRING_LITERAL)
                    {
                        var attribute = tokenNode.GetContainingElement<IAttribute>(true);
                        var switchLabelStatement = tokenNode.GetContainingElement<ISwitchLabelStatement>(true);
                        var constantDeclaration = tokenNode.GetContainingElement<IConstantDeclaration>(true);

                        // Not for attributes switch labels or constant declarations
                        if (attribute == null && switchLabelStatement == null && constantDeclaration == null)
                        {
                            var text = currentNode.GetText();
                            if (text == "\"\"" || text == "@\"\"")
                            {
                                const string NewText = "string.Empty";
                                var newLiteral = (ITokenNode)CSharpTokenType.STRING_LITERAL.Create(new JB::JetBrains.Text.StringBuffer(NewText), new TreeOffset(0), new TreeOffset(NewText.Length));

                                using (WriteLockCookie.Create(true))
                                {
                                    LowLevelModificationUtil.ReplaceChildRange(currentNode, currentNode, new ITreeNode[] { newLiteral });
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.ReplaceEmptyStringsWithStringDotEmpty(currentNode.FirstChild);
                }
            }
        }

        #endregion
    }
}