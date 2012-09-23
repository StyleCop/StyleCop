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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper700.BulbItems.Documentation
{
    #region Using Directives

    using System.Xml;

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper700.BulbItems.Framework;
    using StyleCop.ReSharper700.Core;

    #endregion

    /// <summary>
    /// SA1650: ElementDocumentationMustBeSpelledCorrectly.
    /// </summary>
    public class SA1650ElementDocumentationMustBeSpelledCorrectlyBulbItem : V5BulbItemImpl
    {
        /// <summary>
        /// Gets or sets the deprecated word.
        /// </summary>
        public string DeprecatedWord { get; set; }

        /// <summary>
        /// Gets or sets the word that we will use to replace the deprecated word.
        /// </summary>
        public string AlternateWord { get; set; }

        #region Public Methods

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
            var declaration = Utils.GetTypeClosestToTextControl<IDeclaration>(solution, textControl);

            var declarationHeader = new DeclarationHeader(declaration);
            
            this.SwapWord(declarationHeader.XmlNode, this.DeprecatedWord, this.AlternateWord);

            declarationHeader.Update();
        }

        private void SwapWord(XmlNode node, string word, string alternativeWord)
        {
            for (var i = 0; i < node.ChildNodes.Count; i++)
            {
                var childNode = node.ChildNodes[i];

                if (childNode is XmlText && i == 0)
                {
                    if (childNode.InnerText.Contains(word))
                    {
                        childNode.InnerText = childNode.InnerText.Replace(word, alternativeWord);
                    }
                }

                this.SwapWord(childNode, word, alternativeWord);
            }
        }

        #endregion
    }
}