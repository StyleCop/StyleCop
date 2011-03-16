//-----------------------------------------------------------------------
// <copyright file="StyleCopAddinExtensions.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Delegate for calling a violation fixer.
    /// </summary>
    /// <param name="violationContext">The violation context.</param>
    /// <param name="correctionContext">The optional context object.</param>
    /// <typeparam name="T">The type of the context object.</typeparam>
    public delegate void CorrectViolationHandler<T>(ViolationContext violationContext, T correctionContext);

    /// <summary>
    /// Context for a single instance of a source code violation.
    /// </summary>
    public struct ViolationContext
    {
        /// <summary>
        /// The element that the violation appears in.
        /// </summary>
        private Element element;

        /// <summary>
        /// The line number on which the violation appears.
        /// </summary>
        private int lineNumber;

        /// <summary>
        /// The optional violation message string values. 
        /// </summary>
        private object[] messageValues;

        /// <summary>
        /// Initializes a new instance of the ViolationContext struct.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="lineNumber">The line in the code where the violation occurs.</param>
        public ViolationContext(Element element, int lineNumber)
            : this(element, lineNumber, new object[] { })
        {
            Param.Ignore(element, lineNumber);
        }

        /// <summary>
        /// Initializes a new instance of the ViolationContext struct.
        /// </summary>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="lineNumber">The line in the code where the violation occurs.</param>
        /// <param name="messageValues">String parameters to insert into the violation string.</param>
        public ViolationContext(Element element, int lineNumber, params object[] messageValues)
        {
            Param.RequireNotNull(element, "element");
            Param.RequireGreaterThanZero(lineNumber, "lineNumber");
            Param.RequireNotNull(messageValues, "messageValues");

            this.element = element;
            this.lineNumber = lineNumber;
            this.messageValues = messageValues;
        }

        /// <summary>
        /// Gets the element that the violation appears in.
        /// </summary>
        public Element Element
        {
            get { return this.element; }
        }

        /// <summary>
        /// Gets the line number on which the violation appears.
        /// </summary>
        public int LineNumber
        {
            get { return this.lineNumber; }
        }

        /// <summary>
        /// Gets the optional violation message string values. 
        /// </summary>
        public object[] MessageValues
        {
            get { return this.messageValues; }
        }
    }

    /// <summary>
    /// Extensions for the StyleCopAddin class.
    /// </summary>
    public static class StyleCopAddinExtensions
    {
        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="addin">The addin being extended.</param>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation context string.</param>
        public static void AddViolation(this StyleCopAddIn addin, Element element, string ruleName, params object[] values)
        {
            Param.RequireNotNull(addin, "addin");
            Param.RequireNotNull(element, "element");
            Param.Ignore(ruleName, values);

            addin.AddViolation(ElementWrapper.Wrapper(element), ruleName, values);
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="addin">The addin being extended.</param>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation context string.</param>
        public static void AddViolation(this StyleCopAddIn addin, Element element, System.Enum ruleName, params object[] values)
        {
            Param.RequireNotNull(addin, "addin");
            Param.RequireNotNull(element, "element");
            Param.Ignore(ruleName, values);

            addin.AddViolation(ElementWrapper.Wrapper(element), ruleName, values);
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="addin">The addin being extended.</param>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="line">The line in the code where the violation occurs.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation string.</param>
        public static void AddViolation(this StyleCopAddIn addin, Element element, int line, string ruleName, params object[] values)
        {
            Param.RequireNotNull(addin, "addin");
            Param.RequireNotNull(element, "element");
            Param.Ignore(line, ruleName, values);

            addin.AddViolation(ElementWrapper.Wrapper(element), line, ruleName, values);
        }

        /// <summary>
        /// Adds one violation to the given code element.
        /// </summary>
        /// <param name="addin">The addin being extended.</param>
        /// <param name="element">The element that the violation appears in.</param>
        /// <param name="line">The line in the code where the violation occurs.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="values">String parameters to insert into the violation string.</param>
        public static void AddViolation(this StyleCopAddIn addin, Element element, int line, System.Enum ruleName, params object[] values)
        {
            Param.RequireNotNull(addin, "addin");
            Param.RequireNotNull(element, "element");
            Param.Ignore(line, ruleName, values);

            addin.AddViolation(ElementWrapper.Wrapper(element), line, ruleName, values);
        }

        /// <summary>
        /// Records or fixes an instance of a violation.
        /// </summary>
        /// <param name="addin">The addin being extended.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="violationContext">Context for the violation.</param>
        /// <param name="correctionCallback">Callback which fixes the violation.</param>
        public static void Violation(this StyleCopAddIn addin, System.Enum ruleName, ViolationContext violationContext, CorrectViolationHandler<object> correctionCallback)
        {
            Param.RequireNotNull(addin, "addin");
            Param.Ignore(ruleName);
            Param.RequireNotNull(violationContext, "violationContext");
            Param.RequireNotNull(correctionCallback, "correctViolationCallback");

            addin.Violation(ruleName, violationContext, correctionCallback, null);
        }

        /// <summary>
        /// Records or fixes an instance of a violation.
        /// </summary>
        /// <param name="addin">The addin being extended.</param>
        /// <param name="ruleName">The name of the rule that triggered the violation.</param>
        /// <param name="violationContext">Context for the violation.</param>
        /// <param name="correctionCallback">Callback which fixes the violation.</param>
        /// <param name="correctionContext">Optional callback context.</param>
        /// <typeparam name="T">The type of the callback context.</typeparam>
        public static void Violation<T>(this StyleCopAddIn addin, System.Enum ruleName, ViolationContext violationContext, CorrectViolationHandler<T> correctionCallback, T correctionContext)
        {
            Param.RequireNotNull(addin, "addin");
            Param.Ignore(ruleName);
            Param.RequireNotNull(violationContext, "violationContext");
            Param.RequireNotNull(correctionCallback, "correctViolationCallback");
            Param.Ignore(correctionContext, "correctViolationContext");

            if (addin.Core.RunContext.AutoFix)
            {
                Rule rule = addin.GetRule(ruleName.ToString());

                if (addin.IsRuleEnabled(CsDocumentWrapper.Wrapper(violationContext.Element.Document), rule.Name) &&
                    !addin.IsRuleSuppressed(ElementWrapper.Wrapper(violationContext.Element), rule))
                {
                    correctionCallback(violationContext, correctionContext);
                }
            }
            else
            {
                addin.AddViolation(violationContext.Element, violationContext.LineNumber, ruleName, violationContext.MessageValues);
            }
        }

        /// <summary>
        /// Gets a setting for the add-in.
        /// </summary>
        /// <param name="addin">The addin being extended.</param>
        /// <param name="document">The document containing the settings.</param>
        /// <param name="propertyName">The name of the setting property.</param>
        /// <returns>Returns the setting or null if it does not exist.</returns>
        public static PropertyValue GetSetting(this StyleCopAddIn addin, CsDocument document, string propertyName)
        {
            Param.RequireNotNull(addin, "addin");
            Param.RequireNotNull(document, "document");
            Param.Ignore(propertyName);

            return addin.GetSetting(CsDocumentWrapper.Wrapper(document).Settings, propertyName);
        }
    }
}
