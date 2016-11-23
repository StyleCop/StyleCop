// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopRunner.cs" company="https://github.com/StyleCop">
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
//   Object model for hosting StyleCop in a simplified manner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Object model for hosting StyleCop in a simplified manner.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    public abstract class StyleCopRunner
    {
        #region Fields

        private bool captureViolations;

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private StyleCopCore core;

        /// <summary>
        /// The violation count.
        /// </summary>
        private int violationCount;

        /// <summary>
        /// The violations document.
        /// </summary>
        private XmlDocument violations = new XmlDocument();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopRunner class.
        /// </summary>
        protected StyleCopRunner()
        {
            this.Reset();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Event that is fired when output is generated from the console during an analysis.
        /// </summary>
        public event EventHandler<OutputEventArgs> OutputGenerated;

        /// <summary>
        /// Event that is fired when output is generated from the console during an analysis.
        /// </summary>
        public event EventHandler<ViolationEventArgs> ViolationEncountered;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the StyleCop core instance.
        /// </summary>
        public StyleCopCore Core
        {
            get
            {
                return this.core;
            }

            protected set
            {
                if (value != this.core)
                {
                    this.core = value;
                    this.core.DisplayUI = false;
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether we should capture the violations.
        /// </summary>
        protected bool CaptureViolations
        {
            get
            {
                return this.captureViolations;
            }

            set
            {
                if (!this.captureViolations && value)
                {
                    this.core.ViolationEncountered += this.CoreViolationEncountered;
                    this.core.OutputGenerated += this.CoreOutputGenerated;
                }
                else if (this.captureViolations && !value)
                {
                    this.core.ViolationEncountered -= this.CoreViolationEncountered;
                    this.core.OutputGenerated -= this.CoreOutputGenerated;
                }

                this.captureViolations = value;
            }
        }

        /// <summary>
        /// Gets the violation count.
        /// </summary>
        protected int ViolationCount
        {
            get
            {
                return this.violationCount;
            }
        }

        /// <summary>
        /// Gets the violations document.
        /// </summary>
        protected XmlDocument Violations
        {
            get
            {
                return this.violations;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when output is generated during an analysis. This can be called simultaneously from several threads and so any code must be thread safe.
        /// </summary>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        protected void OnOutputGenerated(OutputEventArgs e)
        {
            Param.RequireNotNull(e, "e");

            // Make sure we cache the delegate locally to avoid other threads unsubscribing before we call them.
            // See http://piers7.blogspot.com/2010/03/3-races-with-net-events.html for info.
            EventHandler<OutputEventArgs> handlers = this.OutputGenerated;

            if (handlers != null)
            {
                handlers(this, e);
            }
        }

        /// <summary>
        /// Called when a violation is encountered during an analysis. This can be called simultaneously from several threads and so any code must be thread safe.
        /// </summary>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        protected void OnViolationEncountered(ViolationEventArgs e)
        {
            Param.RequireNotNull(e, "e");

            // Make sure we cache the delegate locally to avoid other threads unsubscribing before we call them.
            // See http://piers7.blogspot.com/2010/03/3-races-with-net-events.html for info.
            EventHandler<ViolationEventArgs> handlers = this.ViolationEncountered;

            if (handlers != null)
            {
                handlers(this, e);
            }
        }

        /// <summary>
        /// Resets the violation count.
        /// </summary>
        protected void Reset()
        {
            this.violations = new XmlDocument();
            this.violations.AppendChild(this.violations.CreateElement("StyleCopViolations"));
            this.violationCount = 0;
        }

        /// <summary>
        /// Creates a safe version of the element name that can be outputted to Xml.
        /// </summary>
        /// <param name="originalName">
        /// The original name.
        /// </param>
        /// <returns>
        /// Returns the safe name.
        /// </returns>
        private static string CreateSafeSectionName(string originalName)
        {
            Param.Ignore(originalName);

            if (originalName == null)
            {
                return null;
            }

            int index = originalName.IndexOf('<');
            if (index == -1)
            {
                return originalName;
            }

            StringBuilder builder = new StringBuilder(originalName.Length * 2);

            int startTagCount = 0;

            for (int i = 0; i < originalName.Length; ++i)
            {
                char character = originalName[i];

                if (character == '<')
                {
                    ++startTagCount;
                    builder.Append('`');
                }
                else if (startTagCount > 0)
                {
                    if (character == '>')
                    {
                        --startTagCount;
                    }
                    else if (character == ',')
                    {
                        builder.Append('`');
                    }
                    else if (!char.IsWhiteSpace(character))
                    {
                        builder.Append(character);
                    }
                }
                else
                {
                    builder.Append(character);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Called when output should be added to the Output pane.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CoreOutputGenerated(object sender, OutputEventArgs e)
        {
            Param.Ignore(sender, e);

            lock (this)
            {
                this.OnOutputGenerated(new OutputEventArgs(e.Output, e.Importance));
            }
        }

        /// <summary>
        /// Called when a violation is found.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CoreViolationEncountered(object sender, ViolationEventArgs e)
        {
            Param.Ignore(sender, e);

            lock (this)
            {
                // Create the violation element.
                XmlElement violation = this.violations.CreateElement("Violation");
                XmlAttribute attrib = null;

                // Add the element section if it's not empty.
                if (e.Element != null)
                {
                    attrib = this.violations.CreateAttribute("Section");
                    attrib.Value = CreateSafeSectionName(e.Element.FullyQualifiedName);
                    violation.Attributes.Append(attrib);
                }

                // Add the line number.
                attrib = this.violations.CreateAttribute("LineNumber");
                attrib.Value = e.LineNumber.ToString(CultureInfo.InvariantCulture);
                violation.Attributes.Append(attrib);

                if (e.Location != null)
                {
                    // Add the detailed location if avail.
                    attrib = this.violations.CreateAttribute("StartLine");
                    attrib.Value = e.Location.Value.StartPoint.LineNumber.ToString(CultureInfo.InvariantCulture);
                    violation.Attributes.Append(attrib);

                    attrib = this.violations.CreateAttribute("StartColumn");
                    attrib.Value = e.Location.Value.StartPoint.IndexOnLine.ToString(CultureInfo.InvariantCulture);
                    violation.Attributes.Append(attrib);

                    attrib = this.violations.CreateAttribute("EndLine");
                    attrib.Value = e.Location.Value.EndPoint.LineNumber.ToString(CultureInfo.InvariantCulture);
                    violation.Attributes.Append(attrib);

                    attrib = this.violations.CreateAttribute("EndColumn");
                    attrib.Value = e.Location.Value.EndPoint.IndexOnLine.ToString(CultureInfo.InvariantCulture);
                    violation.Attributes.Append(attrib);
                }

                // Get the source code that this element is in.
                SourceCode sourceCode = e.SourceCode;
                if (sourceCode == null && e.Element != null && e.Element.Document != null)
                {
                    sourceCode = e.Element.Document.SourceCode;
                }

                // Add the source code path.
                if (sourceCode != null)
                {
                    attrib = this.violations.CreateAttribute("Source");
                    attrib.Value = sourceCode.Path;
                    violation.Attributes.Append(attrib);
                }

                // Add the rule namespace.
                attrib = this.violations.CreateAttribute("RuleNamespace");
                attrib.Value = e.Violation.Rule.Namespace;
                violation.Attributes.Append(attrib);

                // Add the rule name.
                attrib = this.violations.CreateAttribute("Rule");
                attrib.Value = e.Violation.Rule.Name;
                violation.Attributes.Append(attrib);

                // Add the rule ID.
                attrib = this.violations.CreateAttribute("RuleId");
                attrib.Value = e.Violation.Rule.CheckId;
                violation.Attributes.Append(attrib);

                violation.InnerText = e.Message;

                this.violations.DocumentElement.AppendChild(violation);
                this.violationCount++;
            }

            // Forward event
            this.OnViolationEncountered(new ViolationEventArgs(e.Violation));
        }

        #endregion
    }
}