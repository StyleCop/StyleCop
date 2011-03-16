//-----------------------------------------------------------------------
// <copyright file="ParamCheck.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.StyleCop;
    using Microsoft.StyleCop.CSharp_old;

    /// <summary>
    /// Checks the usage of the Param class to verify method parameters.
    /// </summary>
    [SuppressMessage(
        "Microsoft.Naming", 
        "CA1704:IdentifiersShouldBeSpelledCorrectly", 
        MessageId = "Param",
        Justification = "The naming is consistent with the name of the Param class.")]
    [SourceAnalyzer(typeof(CsParser))]
    public class ParamCheck : SourceAnalyzer
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the ParamCheck class.
        /// </summary>
        public ParamCheck()
        {
        }

        #endregion Public Constructors

        #region Public Override Methods

        /// <summary>
        /// Checks the methods within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        public override void AnalyzeDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            /*
            // Get the autoupdate setting.
            string flag = null;
            if (document.File.Project.LocalSettings != null)
            {
                flag = document.File.Project.LocalSettings.GetProperty("ParamCheckAutomatic");
                if (flag == null && document.File.Project.GlobalSettings != null)
                {
                    flag = document.File.Project.GlobalSettings.GetProperty("ParamCheckAutomatic");
                }
            }
             
            this.autoUpdate = (flag != null && flag == "1");
             */

            // Analyze the document.
            CsDocument csdocument = (CsDocument)document;
            if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
            {
                this.ProcessElement(csdocument, csdocument.RootElement);
            }
        }

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Gets the list of all tokens within Param statements found in the given element.
        /// </summary>
        /// <param name="element">The element to get the param tokens from.</param>
        /// <returns>Returns the list of param check tokens.</returns>
        private static List<ParamTokens> GetParamCheckTokens(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            List<ParamTokens> paramCheckTokens = new List<ParamTokens>();
            List<Node<CsToken>> tokenList = new List<Node<CsToken>>();

            bool param = false;

            Node<CsToken> paramTokenNode = null;
            int parenthesisCount = 0;

            for (Node<CsToken> tokenNode = element.Tokens.First; !element.Tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                if (param)
                {
                    if (tokenNode.Value.Text != ".")
                    {
                        paramTokenNode = null;
                    }

                    param = false;
                }
                else if (paramTokenNode != null)
                {
                    if (tokenNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                    {
                        ++parenthesisCount;
                    }
                    else if (tokenNode.Value.CsTokenType == CsTokenType.CloseParenthesis)
                    {
                        --parenthesisCount;
                        if (parenthesisCount == 0)
                        {
                            if (tokenList.Count > 0)
                            {
                                paramCheckTokens.Add(new ParamTokens(paramTokenNode, tokenList));
                                tokenList = new List<Node<CsToken>>();
                            }

                            paramTokenNode = null;
                        }
                    }
                    else if (tokenNode.Value.CsTokenType == CsTokenType.Semicolon || tokenNode.Value.CsTokenType == CsTokenType.OpenCurlyBracket)
                    {
                        if (parenthesisCount == 0)
                        {
                            if (tokenList.Count > 0)
                            {
                                paramCheckTokens.Add(new ParamTokens(paramTokenNode, tokenList));
                                tokenList = new List<Node<CsToken>>();
                            }

                            paramTokenNode = null;
                        }
                    }
                    else if (parenthesisCount > 0 && (tokenNode.Value.CsTokenType == CsTokenType.Other || tokenNode.Value.Text == "value"))
                    {
                        tokenList.Add(tokenNode);
                    }
                }
                else
                {
                    if (tokenNode.Value.Text == "Param")
                    {
                        paramTokenNode = tokenNode;
                        param = true;
                    }
                }
            }

            return paramCheckTokens;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Checks one element and its children.
        /// </summary>
        /// <param name="document">The document object representing the code file.</param>
        /// <param name="element">The element to check.</param>
        /// <returns>Returns false if the analyzer should quit.</returns>
        private bool ProcessElement(CsDocument document, CsElement element)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(element, "element");

            if (!this.Cancel)
            {
                if (!element.Generated)
                {
                    if (element.ElementType == ElementType.Method || element.ElementType == ElementType.Constructor)
                    {
                        if (!element.Declaration.ContainsModifier(CsTokenType.Abstract))
                        {
                            // Check the parameter verification.
                            this.CheckMethodParameterVerification(element);
                        }
                    }
                    else if (element.ElementType == ElementType.Accessor)
                    {
                        CsElement parent = element.FindParentElement();

                        if (parent != null && !parent.Declaration.ContainsModifier(CsTokenType.Abstract))
                        {
                            // Check the parameter verification.
                            if (parent.ElementType == ElementType.Indexer)
                            {
                                if (element.Declaration.Tokens.First.Value.Text == "set")
                                {
                                    this.CheckMethodParameterVerification(element);
                                }
                            }
                            else if (parent.ElementType == ElementType.Property)
                            {
                                if (element.Declaration.Tokens.First.Value.Text == "set")
                                {
                                    this.CheckPropertyParameterVerification(element);
                                }
                            }
                        }
                    }
                }

                // Do not check the methods and properties within interfaces.
                if (element.ElementType != ElementType.Interface)
                {
                    foreach (CsElement child in element.ChildElements)
                    {
                        if (!this.ProcessElement(document, child))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks that all method parameters are verified.
        /// </summary>
        /// <param name="element">The method to check.</param>
        private void CheckMethodParameterVerification(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            IParameterContainer parameterContainer = element as IParameterContainer;
            Debug.Assert(parameterContainer != null, "The element does not contain parameters.");

            // If there are no parameters, don't do anything.
            if (parameterContainer.Parameters.Count > 0)
            {
                // Get the list of param check tokens.
                List<ParamTokens> paramCheckTokens = GetParamCheckTokens(element);

                // Find each parameter.
                foreach (Parameter parameter in parameterContainer.Parameters)
                {
                    Node<CsToken> paramTokenNode = null;
                    foreach (ParamTokens paramTokens in paramCheckTokens)
                    {
                        bool found = false;

                        foreach (Node<CsToken> tokenNode in paramTokens.TokenNodes)
                        {
                            if (parameter.Name == tokenNode.Value.Text)
                            {
                                paramTokenNode = paramTokens.ParamTokenNode;
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            break;
                        }
                    }

                    if (paramTokenNode == null)
                    {
                        CsElement parent = element.FindParentElement();

                        if ((parameter.Modifiers & ParameterModifiers.Out) == 0 &&
                            (element.Declaration.Name != "Ignore" || (parent != null && parent.Declaration.Name != "Param")))
                        {
                            this.AddViolation(element, Rules.ParametersMustBeVerified, parameter.Name);
                        }
                    }
                    else
                    {
                        if ((parameter.Modifiers & ParameterModifiers.Out) != 0)
                        {
                            this.AddViolation(
                                element, paramTokenNode.Value.LineNumber, Rules.OutParametersMustNotBeVerified, parameter.Name);
                        }
                        else
                        {
                            // Get the param statement type.
                            if (paramTokenNode != null && paramTokenNode.Next != null)
                            {
                                Node<CsToken> paramCheckTypeNode = paramTokenNode.Next.Next;
                                if (paramCheckTypeNode != null && paramCheckTypeNode.Value.CsTokenType == CsTokenType.Other)
                                {
                                    if (element.ActualAccess == AccessModifierType.Private ||
                                        element.ActualAccess == AccessModifierType.Internal ||
                                        element.ActualAccess == AccessModifierType.ProtectedInternal)
                                    {
                                        if (paramCheckTypeNode.Value.Text.StartsWith("Require", StringComparison.Ordinal))
                                        {
                                            Rules type = Rules.PrivateMethodsMustUseAsserts;
                                            /*if (this.autoUpdate)
                                            {
                                                if (this.ChangeStatement(document, paramToken, true))
                                                {
                                                    type = ViolationID.ParamCheckPrivateRequireWarning;
                                                }
                                            }*/

                                            this.AddViolation(element, paramTokenNode.Value.LineNumber, type);
                                        }
                                    }
                                    else
                                    {
                                        if (paramCheckTypeNode.Value.Text.StartsWith("Assert", StringComparison.Ordinal))
                                        {
                                            Rules type = Rules.PublicMethodsMustUseRequires;
                                            /*if (this.autoUpdate)
                                            {
                                                if (this.ChangeStatement(document, paramToken, false))
                                                {
                                                    type = ViolationID.ParamCheckPublicAssertWarning;
                                                }
                                            }*/

                                            this.AddViolation(element, paramTokenNode.Value.LineNumber, type);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks that set properties verify the input value.
        /// </summary>
        /// <param name="element">The property to check.</param>
        private void CheckPropertyParameterVerification(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            // Determine whether the accessor has a body. If this is an automatic property,
            // there will be no body.
            bool hasBody = false;
            foreach (CsToken token in element.Tokens)
            {
                if (token.CsTokenType == CsTokenType.OpenCurlyBracket)
                {
                    hasBody = true;
                    break;
                }
            }

            if (hasBody)
            {
                // Get the list of param check words.
                List<ParamTokens> paramCheckTokens = GetParamCheckTokens(element);

                // Make sure the list contains "value".
                Node<CsToken> paramTokenNode = null;
                foreach (ParamTokens paramTokens in paramCheckTokens)
                {
                    foreach (Node<CsToken> tokenNode in paramTokens.TokenNodes)
                    {
                        if (tokenNode.Value.Text == "value")
                        {
                            paramTokenNode = paramTokens.ParamTokenNode;
                            break;
                        }
                    }
                }

                CsElement parent = element.FindParentElement();

                if (paramTokenNode == null)
                {
                    if (element.Declaration.Name != "Ignore" || (parent != null && parent.Declaration.Name != "Param"))
                    {
                        this.AddViolation(element, Rules.ParametersMustBeVerified, "value");
                    }
                }
                else
                {
                    if (parent != null &&
                        (parent.ActualAccess == AccessModifierType.Private ||
                         parent.ActualAccess == AccessModifierType.Internal ||
                         parent.ActualAccess == AccessModifierType.ProtectedInternal))
                    {
                        if (paramTokenNode.Value.Text.StartsWith("Param.Require", StringComparison.Ordinal))
                        {
                            Rules type = Rules.PrivateMethodsMustUseAsserts;
                            /*if (this.autoUpdate)
                            {
                                if (this.ChangeStatement(document, paramToken, true))
                                {
                                    type = ViolationID.ParamCheckPrivateRequireWarning;
                                }
                            }*/

                            this.AddViolation(element, paramTokenNode.Value.LineNumber, type);
                        }
                    }
                    else
                    {
                        if (paramTokenNode.Value.Text.StartsWith("Param.Assert", StringComparison.Ordinal))
                        {
                            Rules type = Rules.PublicMethodsMustUseRequires;
                            /*if (this.autoUpdate)
                            {
                                if (this.ChangeStatement(document, paramToken, false))
                                {
                                    type = ViolationID.ParamCheckPublicAssert;
                                }
                            }*/

                            this.AddViolation(element, paramTokenNode.Value.LineNumber, type);
                        }
                    }
                }
            }
        }

        /*
        /// <summary>
        /// Changes the Param.Require statement to Param.Assert, or vice-versa.
        /// </summary>
        /// <param name="document">The document containing the statement.</param>
        /// <param name="param">The statement to change.</param>
        /// <param name="changeToAssert">True to change Param.Require to Param.Assert, false to change
        /// Param.Assert to Param.Require.</param>
        /// <returns>Returns true if the code was successfully changed.</returns>
        private bool ChangeStatement(CsDocument document, Token param, bool changeToAssert)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(param, "param");
            Param.Ignore(changeToAssert);

            // Get the code editor for this document.
            CodeEditor editor = document.CodeEditor;
            if (editor != null)
            {
                string currentWord = changeToAssert ? "Require" : "Assert";
                string newWord = changeToAssert ? "Assert" : "Require";

                // The length of "Param.";
                const int ParamLength = 6;

                // Update the code.
                return editor.UpdateCode(
                    param.LineNumber,
                    param.Location.StartPoint.IndexOnLine + ParamLength + 1,
                    currentWord.Length,
                    newWord);
            }

            return false;
        }
        */

        #endregion Private Methods
    }
}
