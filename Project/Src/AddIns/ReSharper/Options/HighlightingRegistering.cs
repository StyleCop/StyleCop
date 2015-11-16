// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HighlightingRegistering.cs" company="http://stylecop.codeplex.com">
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
//   Registers StyleCop Highlighters to allow their severity to be set.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Options
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using JetBrains.Application;
    using JetBrains.Application.FileSystemTracker;
    using JetBrains.Application.Parts;
    using JetBrains.Application.Settings;
    using JetBrains.DataFlow;
    using JetBrains.Metadata.Utils;
    using JetBrains.ReSharper.Feature.Services.Daemon;

    using StyleCop.ReSharper.Core;

    /// <summary>
    /// Registers StyleCop Highlighters to allow their severity to be set.
    /// </summary>
    [ShellComponent]
    public class HighlightingRegistering
    {
        /// <summary>
        /// The template to be used for the group title.
        /// </summary>
        private const string GroupTitleTemplate = "StyleCop - {0}";

        /// <summary>
        /// The template to be used for the highlight ID's.
        /// </summary>
        private const string HighlightIdTemplate = "StyleCop.{0}";

        private readonly PartsCatalogueSet partsCatalogueSet;

        private readonly SequentialLifetimes registrationLifetimes;

        /// <summary>
        /// Initializes a new instance of the HighlightingRegistering class.
        /// </summary>
        /// <param name="lifetime">Lifetime of the component</param>
        /// <param name="partsCatalogueSet">The catalogue set</param>
        /// <param name="settingsStore">The settings store.</param>
        /// <param name="fileSystemTracker">
        /// The file System Tracker.
        /// </param>
        public HighlightingRegistering(Lifetime lifetime, PartsCatalogueSet partsCatalogueSet, ISettingsStore settingsStore, IFileSystemTracker fileSystemTracker)
        {
            this.partsCatalogueSet = partsCatalogueSet;
            this.registrationLifetimes = new SequentialLifetimes(lifetime);

            // TODO: We shouldn't be doing any of this at runtime, especially not on each load
            // Registering highlightings should happen declaratively
            // Create this instance directly, rather than use the pool, because the pool needs to
            // be per-solution, as it caches settings for files in the solution
            Lifetimes.Using(
                temporaryLifetime =>
                    {
                        // We don't really need the file system tracker - it's only used when we get
                        // settings, which we don't do as part of highlighting initialisation
                        StyleCopCore core = StyleCopCoreFactory.Create(temporaryLifetime, settingsStore, fileSystemTracker);
                        this.Register(core);
                    });
        }

        /// <summary>
        /// Gets the highlight ID for this rule.
        /// </summary>
        /// <param name="ruleID">
        /// The rule ID.
        /// </param>
        /// <returns>
        /// The highlight ID.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// RuleID is null.
        /// </exception>
        public static string GetHighlightID(string ruleID)
        {
            if (string.IsNullOrEmpty(ruleID))
            {
                throw new ArgumentNullException("ruleID");
            }

            return string.Format(HighlightIdTemplate, ruleID);
        }

        /// <summary>
        /// Reregisters the highlights with the given core
        /// </summary>
        /// <param name="core">The core API</param>
        public void Reregister(StyleCopCore core)
        {
            this.Register(core);
        }

        private static string SplitCamelCase(string input)
        {
            string output = Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();

            return output;
        }

        private void Register(StyleCopCore core)
        {
            this.registrationLifetimes.Next(
                lifetime =>
                    {
                        Dictionary<SourceAnalyzer, List<StyleCopRule>> analyzerRulesDictionary = StyleCopRule.GetRules(core);

                        // Not the best way of doing this, but better than reflection. Create a "fake" parts catalogue
                        // that contains parts representing the attributes that we would specify if we were doing this
                        // "properly" and not dynamically based on the rules loaded by StyleCop and any addins (this is
                        // compounded by allowing addins to be different per-solution, thanks to the settings subsystem).
                        // Adding the catalogue to the global parts catalogue causes ReSharper to automatically evaluate
                        // it, and automatically remove it when the lifetime is terminated.
                        IPartsCatalogue catalogue = this.CreateFakeCatalogue(analyzerRulesDictionary);
                        this.partsCatalogueSet.Add(lifetime, catalogue);
                    });
        }

        private IPartsCatalogue CreateFakeCatalogue(Dictionary<SourceAnalyzer, List<StyleCopRule>> analyzerRules)
        {
            IPartCatalogueFactory factory = new FlyweightPartFactory();

            PartCatalogueAssembly assembly = new PartCatalogueAssembly(AssemblyNameInfo.Create("StyleCopHighlightings", null), null);

            List<PartCatalogueAttribute> assemblyAttributes = new List<PartCatalogueAttribute>();
            List<PartCatalogueAttribute> configurableSeverityAttributes = new List<PartCatalogueAttribute>();
            foreach (KeyValuePair<SourceAnalyzer, List<StyleCopRule>> analyzerRule in analyzerRules)
            {
                string analyzerName = analyzerRule.Key.Name;
                string groupName = string.Format(GroupTitleTemplate, analyzerName);

                var groupAttribute = new RegisterConfigurableHighlightingsGroupAttribute(groupName, groupName);
                assemblyAttributes.Add(PartHelpers.CreatePartAttribute(groupAttribute, factory));

                foreach (StyleCopRule rule in analyzerRule.Value)
                {
                    string ruleName = rule.RuleID + ": " + SplitCamelCase(rule.Name);
                    string highlightID = GetHighlightID(rule.RuleID);

                    RegisterConfigurableSeverityAttribute itemAttribute =
                        new RegisterConfigurableSeverityAttribute(
                            highlightID,
                            null,
                            groupName,
                            ruleName,
                            rule.Description,
                            Severity.WARNING,
                            false);
                    assemblyAttributes.Add(PartHelpers.CreatePartAttribute(itemAttribute, factory));

                    ConfigurableSeverityHighlightingAttribute configurableSeverityHighlightingAttribute = new ConfigurableSeverityHighlightingAttribute(highlightID, "CSHARP");
                    configurableSeverityAttributes.Add(PartHelpers.CreatePartAttribute(configurableSeverityHighlightingAttribute, factory));
                }
            }

            assembly.AssignAttributes(assemblyAttributes);

            PartCatalogueType fakeConfigurableSeverityHighlight;
            factory.GetOrCreateType("Fake", PartCatalogueType.TypeKind.Regular, assembly, out fakeConfigurableSeverityHighlight);
            fakeConfigurableSeverityHighlight.AssignRecursiveTypes(new PartCatalogueType.RecursiveData
                                          {
                                              Attributes = configurableSeverityAttributes
                                          });

            IList<PartCatalogueAssembly> assemblies = new List<PartCatalogueAssembly>()
                                                          {
                                                              assembly
                                                          };

            IList<PartCatalogueType> parts = new List<PartCatalogueType>();
            parts.Add(fakeConfigurableSeverityHighlight);
            return new PartsCatalogue(parts, assemblies);
        }
    }
}