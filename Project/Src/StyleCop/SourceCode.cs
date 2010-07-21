//-----------------------------------------------------------------------
// <copyright file="SourceCode.cs" company="Microsoft">
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
namespace Microsoft.StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    /// Describes source code to parse and analyze.
    /// </summary>
    /// <remarks>Each piece of source code to be parsed and analyzed by StyleCop must be 
    /// described by a SourceCode object. A SourceCode object may only be used once. After the 
    /// SourceCode has been processed by StyleCop, it cannot be sent to StyleCop 
    /// a second time for analysis.</remarks>
    public abstract class SourceCode
    {
        #region Private Fields

        /// <summary>
        /// The project that contains the source code document.
        /// </summary>
        private CodeProject project;

        /// <summary>
        /// The settings for the project.
        /// </summary>
        private Settings settings;

        /// <summary>
        /// The parser that handles this source code document.
        /// </summary>
        private SourceParser parser;

        /// <summary>
        /// The list of violations in this document.
        /// </summary>
        private Dictionary<string, Violation> violations = new Dictionary<string, Violation>();

        /// <summary>
        /// The list of configurations for the document.
        /// </summary>
        private IEnumerable<Configuration> configurations;

        #endregion Private Fields

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the SourceCode class.
        /// </summary>
        /// <param name="project">The project that contains this document.</param>
        /// <param name="parser">The parser that created this document.</param>
        protected SourceCode(CodeProject project, SourceParser parser)
        {
            Param.RequireNotNull(project, "project");
            Param.RequireNotNull(parser, "parser");

            this.project = project;
            this.parser = parser;
        }

        /// <summary>
        /// Initializes a new instance of the SourceCode class.
        /// </summary>
        /// <param name="project">The project that contains this document.</param>
        /// <param name="parser">The parser that created this document.</param>
        /// <param name="configurations">The list of configurations for the document.</param>
        protected SourceCode(CodeProject project, SourceParser parser, IEnumerable<Configuration> configurations)
            : this(project, parser)
        {
            Param.Ignore(project, parser, configurations);
            this.configurations = configurations;
        }

        #endregion Protected Constructors

        #region Public Abstract Properties

        /// <summary>
        /// Gets the name of the source code document.
        /// </summary>
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Gets the full path to the source code document.
        /// </summary>
        public abstract string Path
        {
            get;
        }

        /// <summary>
        /// Gets the type of code that the document contains.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public abstract string Type
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the source code document currently exists and is accessible.
        /// </summary>
        public abstract bool Exists
        {
            get;
        }

        /// <summary>
        /// Gets the time that the source code was last edited or updated.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1702:CompoundWordsShouldBeCasedCorrectly", 
            MessageId = "TimeStamp",
            Justification = "API has already been published and should not be changed.")]
        public abstract DateTime TimeStamp
        {
            get;
        }

        #endregion Public Abstract Properties

        #region Public Properties

        /// <summary>
        /// Gets the project that contains the document.
        /// </summary>
        public CodeProject Project
        {
            get
            {
                return this.project;
            }
        }

        /// <summary>
        /// Gets the parser that created this document.
        /// </summary>
        public SourceParser Parser
        {
            get
            {
                return this.parser;
            }
        }

        /// <summary>
        /// Gets the violations found within this document.
        /// </summary>
        public ICollection<Violation> Violations
        {
            get
            {
                return this.violations.Values;
            }
        }

        /// <summary>
        /// Gets the list of configurations for the file.
        /// </summary>
        public IEnumerable<Configuration> Configurations
        {
            get
            {
                return this.configurations;
            }
        }

        /// <summary>
        /// Gets or sets the settings for this source code.
        /// </summary>
        public Settings Settings
        {
            get
            {
                if (this.settings != null)
                {
                    return this.settings;
                }

                if (this.project != null)
                {
                    return this.project.Settings;
                }

                return null;
            }

            set
            {
                Param.Ignore(value);
                this.settings = value;
            }
        }

        #endregion Public Properties

        #region Public Abstract Methods

        /// <summary>
        /// Reads the contents of the source code into a TextReader.
        /// </summary>
        /// <returns>Returns the TextReader containing the source code.</returns>
        public abstract TextReader Read();

        #endregion Public Abstract Methods

        #region Internal Methods

        /// <summary>
        /// Adds one violation to this element.
        /// </summary>
        /// <param name="violation">The violation to add.</param>
        /// <returns>Returns false if there is already an identical violation in the element.</returns>
        internal bool AddViolation(Violation violation)
        {
            Param.AssertNotNull(violation, "violation");
            string key = violation.Key;

            if (!this.violations.ContainsKey(key))
            {
                this.violations.Add(violation.Key, violation);
                return true;
            }

            return false;
        }

        #endregion Internal Methods
    }
}
