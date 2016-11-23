// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="https://github.com/StyleCop">
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
//   Describes one compilation configuration style for a code document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes one compilation configuration style for a code document.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces", Justification = "Configuration is an appropriate name for the class.")]
    public class Configuration
    {
        #region Fields

        /// <summary>
        /// The list of conditional compilation flags for this configuration.
        /// </summary>
        private readonly Dictionary<string, string> conditionalCompilationDefinitions;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Configuration class.
        /// </summary>
        /// <param name="conditionalCompilationDefinitions">
        /// The list of conditional compilation flags for 
        /// this configuration.
        /// </param>
        public Configuration(string[] conditionalCompilationDefinitions)
        {
            Param.Ignore(conditionalCompilationDefinitions);

            if (conditionalCompilationDefinitions != null && conditionalCompilationDefinitions.Length > 0)
            {
                this.conditionalCompilationDefinitions = new Dictionary<string, string>();
                foreach (string flag in conditionalCompilationDefinitions)
                {
                    if (!this.conditionalCompilationDefinitions.ContainsKey(flag))
                    {
                        this.conditionalCompilationDefinitions.Add(flag, flag);
                    }
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of flags defined in the configuration.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "API has already been published and should not be changed.")
        ]
        public ICollection<string> Flags
        {
            get
            {
                if (this.conditionalCompilationDefinitions != null)
                {
                    return this.conditionalCompilationDefinitions.Keys;
                }

                return new string[] { };
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the given flag is contained in the configuration.
        /// </summary>
        /// <param name="definition">
        /// The flag to search for.
        /// </param>
        /// <returns>
        /// Returns true if the flag is contained in the configuration.
        /// </returns>
        public bool Contains(string definition)
        {
            Param.RequireNotNull(definition, "definition");

            if (this.conditionalCompilationDefinitions != null)
            {
                return this.conditionalCompilationDefinitions.ContainsKey(definition);
            }

            return false;
        }

        /// <summary>
        /// Gets the value of the given flag.
        /// </summary>
        /// <param name="definition">
        /// The defined flag to retrieve.
        /// </param>
        /// <returns>
        /// Returns the value of the flag.
        /// </returns>
        public string GetValue(string definition)
        {
            Param.RequireNotNull(definition, "definition");

            if (this.conditionalCompilationDefinitions != null)
            {
                return this.conditionalCompilationDefinitions[definition];
            }

            return null;
        }

        #endregion
    }
}