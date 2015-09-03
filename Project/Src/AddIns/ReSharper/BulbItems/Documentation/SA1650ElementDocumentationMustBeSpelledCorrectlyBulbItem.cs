// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1650ElementDocumentationMustBeSpelledCorrectlyBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   SA1650: ElementDocumentationMustBeSpelledCorrectly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.BulbItems.Documentation
{
    using System;
    using System.Xml;

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.Core;

    /// <summary>
    /// SA1650: ElementDocumentationMustBeSpelledCorrectly.
    /// </summary>
    public class SA1650ElementDocumentationMustBeSpelledCorrectlyBulbItem : V5BulbItemImpl
    {
        /// <summary>
        /// Gets or sets the word that we will use to replace the deprecated word.
        /// </summary>
        public string AlternateWord { get; set; }

        /// <summary>
        /// Gets or sets the deprecated word.
        /// </summary>
        public string DeprecatedWord { get; set; }

        /// <summary>
        /// The execute transaction inner.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="textControl">
        /// The text control.
        /// </param>
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            IDeclaration declaration = Utils.GetTypeClosestToTextControl<IDeclaration>(solution, textControl);

            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

            this.ProcessXmlNode(declarationHeader.XmlNode, this.DeprecatedWord, this.AlternateWord);

            declarationHeader.Update();
        }

        private void ProcessXmlNode(XmlNode node, string word, string alternativeWord)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode childNode = node.ChildNodes[i];

                if (childNode is XmlText && i == 0)
                {
                    childNode.InnerText = this.ReplaceWord(childNode.InnerText, word, alternativeWord);
                }

                this.ProcessXmlNode(childNode, word, alternativeWord);
            }
        }

        private string ReplaceWord(string text, string word, string alternativeWord)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            int indexOfWord = -1;
            do
            {
                indexOfWord = text.IndexOf(word, indexOfWord + 1, StringComparison.CurrentCulture);
                if (indexOfWord > -1)
                {
                    if ((indexOfWord == 0 || !char.IsLetter(text, indexOfWord - 1)) && (indexOfWord == text.Length || !char.IsLetter(text, indexOfWord + word.Length)))
                    {
                        string firstPart = text.Substring(0, indexOfWord);
                        string secondPart = text.Substring(indexOfWord + word.Length);
                        text = string.Concat(firstPart, alternativeWord, secondPart);
                    }
                }
            }
            while (indexOfWord > -1);

            return text;
        }
    }
}