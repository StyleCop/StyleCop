//-----------------------------------------------------------------------
// <copyright file="StyleCopAddinExtensions.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using Microsoft.StyleCop.CSharp.CodeModel;

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
