// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceCode.cs" company="https://github.com/StyleCop">
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
//   Describes source code to parse and analyze.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
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
        #region Fields

        /// <summary>
        /// The list of configurations for the document.
        /// </summary>
        private readonly IEnumerable<Configuration> configurations;

        /// <summary>
        /// The parser that handles this source code document.
        /// </summary>
        private readonly SourceParser parser;

        /// <summary>
        /// The project that contains the source code document.
        /// </summary>
        private readonly CodeProject project;

        /// <summary>
        /// The list of violations in this document.
        /// </summary>
        private readonly Dictionary<int, Violation> violations = new Dictionary<int, Violation>();

        /// <summary>
        /// The settings for the project.
        /// </summary>
        private Settings settings;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SourceCode class.
        /// </summary>
        /// <param name="project">
        /// The project that contains this document.
        /// </param>
        /// <param name="parser">
        /// The parser that created this document.
        /// </param>
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
        /// <param name="project">
        /// The project that contains this document.
        /// </param>
        /// <param name="parser">
        /// The parser that created this document.
        /// </param>
        /// <param name="configurations">
        /// The list of configurations for the document.
        /// </param>
        protected SourceCode(CodeProject project, SourceParser parser, IEnumerable<Configuration> configurations)
            : this(project, parser)
        {
            Param.Ignore(project, parser, configurations);
            this.configurations = configurations;
        }

        #endregion

        #region Public Properties

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
        /// Gets a value indicating whether the source code document currently exists and is accessible.
        /// </summary>
        public abstract bool Exists { get; }

        /// <summary>
        /// Gets the name of the source code document.
        /// </summary>
        public abstract string Name { get; }

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
        /// Gets the full path to the source code document.
        /// </summary>
        public abstract string Path { get; }

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

        /// <summary>
        /// Gets the time that the source code was last edited or updated.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "TimeStamp", 
            Justification = "API has already been published and should not be changed.")]
        public abstract DateTime TimeStamp { get; }

        /// <summary>
        /// Gets the type of code that the document contains.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
        public abstract string Type { get; }

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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Reads the contents of the source code into a TextReader.
        /// </summary>
        /// <returns>Returns the TextReader containing the source code.</returns>
        public abstract TextReader Read();

        #endregion

        #region Methods

        /// <summary>
        /// Adds one violation to this element.
        /// </summary>
        /// <param name="violation">
        /// The violation to add.
        /// </param>
        /// <returns>
        /// Returns false if there is already an identical violation in the element.
        /// </returns>
        internal bool AddViolation(Violation violation)
        {
            Param.AssertNotNull(violation, "violation");
            int key = violation.Key;

            if (!this.violations.ContainsKey(key))
            {
                this.violations.Add(violation.Key, violation);
                return true;
            }

            return false;
        }

        #endregion
    }
}