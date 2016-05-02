// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopHighlighting.cs" company="http://stylecop.codeplex.com">
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
//   Highlighting class for a StyleCop Violation set to severity level Error.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Violations
{
    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Feature.Services.Daemon;

    [ConfigurableSeverityHighlighting("", "CSHARP")]
    public class StyleCopHighlighting : StyleCopHighlightingBase, ICustomSeverityHighlighting, ICustomConfigurableSeverityIdHighlighting
    {
        private readonly Severity severity;

        private readonly string highlightID;

        public StyleCopHighlighting(ViolationEventArgs violationEventArgs, DocumentRange documentRange, Severity severity, string highlightID)
            : base(violationEventArgs, documentRange)
        {
            this.severity = severity;
            this.highlightID = highlightID;
        }

        /// <summary>
        /// The severity of the highlighting.
        /// </summary>
        public Severity Severity
        {
            get
            {
                return this.severity;
            }
        }

        /// <summary>
        /// The ID of the highlighting.
        /// </summary>
        public string ConfigurableSeverityId
        {
            get
            {
                return this.highlightID;
            }
        }
    }
}