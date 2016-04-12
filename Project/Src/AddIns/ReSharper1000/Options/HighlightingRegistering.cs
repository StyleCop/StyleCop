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

namespace StyleCop.ReSharper1000.Options
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using JetBrains.Application;
    using JetBrains.Application.Catalogs;
    using JetBrains.Application.Environment;
    using JetBrains.Application.FileSystemTracker;
    using JetBrains.Application.Parts;
    using JetBrains.Application.Settings;
    using JetBrains.DataFlow;
    using JetBrains.Metadata.Utils;
    using JetBrains.ReSharper.Feature.Services.Daemon;
    using JetBrains.Util.dataStructures.Sources;

    using StyleCop.ReSharper1000.Core;

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

        private readonly IPartCatalogSet partsCatalogueSet;

        private readonly SequentialLifetimes registrationLifetimes;

        /// <summary>
        /// Initializes a new instance of the HighlightingRegistering class.
        /// </summary>
        /// <param name="lifetime">Lifetime of the component</param>
        /// <param name="jetEnvironment">The jet environment</param>
        /// <param name="settingsStore">The settings store.</param>
        /// <param name="fileSystemTracker">The file System Tracker.</param>
        public HighlightingRegistering(Lifetime lifetime, JetEnvironment jetEnvironment, ISettingsStore settingsStore, IFileSystemTracker fileSystemTracker)
        {
            this.partsCatalogueSet = jetEnvironment.FullPartCatalogSet;
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

        private static PartCatalogueAttribute CreatePartAttribute(Attribute attribute, IPartCatalogueFactory factory)
        {
            // OK, this is getting out of hand. It seemed like a good idea to replace
            // reflection with a fake catalogue, but ReSharper 10 has changed things.
            // Implementing your own catalogue is non-trivial, and the wrapper for
            // legacy catalogues has issues with attribute properties (including ctor
            // args). It expects a string instance to be represented with a StringSource,
            // and tries to unbox an enum directly into a ulong, which fails. We can work
            // around these by replacing the actual value in the properties with one that
            // will work. But it also tries to unbox a bool into a ulong, which also fails,
            // and we can't work around that (it asserts that the value in the property is
            // also a bool). So, we totally fudge it. It just so happens that the values
            // we want to use are false, and HighlightSettingsManagerImpl will handle
            // missing values nicely, defaulting to false. So, rip em out.
            // Perhaps reflection was the better idea... (well, strictly speaking not having
            // "dynamically" loaded highlightings is a better idea!)
            var originalPartAttribute = PartHelpers.CreatePartAttribute(attribute, factory);
            var newProperties = from p in originalPartAttribute.GetProperties()
                                where !(p.Value is bool && (bool)p.Value == false)
                                select new PartCatalogueAttributeProperty(p.Name, WrapValue(p.Value), p.Disposition);

            return new PartCatalogueAttribute(originalPartAttribute.Type, newProperties, originalPartAttribute.ConstructorFormalParameterTypes);
        }

        private static object WrapValue(object value)
        {
            var s = value as string;
            if (s != null)
            {
                StringSource ss = s;
                return ss;
            }

            if (value != null && value.GetType().IsEnum)
            {
                int i = (int)value;
                return (ulong)i;
            }

            return value;
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
                        PartCatalog catalog = catalogue.WrapLegacy();
                        this.partsCatalogueSet.Catalogs.Add(lifetime, catalog, null);
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
                assemblyAttributes.Add(CreatePartAttribute(groupAttribute, factory));

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
                    assemblyAttributes.Add(CreatePartAttribute(itemAttribute, factory));

                    ConfigurableSeverityHighlightingAttribute configurableSeverityHighlightingAttribute = new ConfigurableSeverityHighlightingAttribute(highlightID, "CSHARP");
                    configurableSeverityAttributes.Add(PartHelpers.CreatePartAttribute(configurableSeverityHighlightingAttribute, factory));
                }
            }

            assembly.AssignAttributes(assemblyAttributes);

            PartCatalogueType fakeConfigurableSeverityHighlight;
            factory.GetOrCreateType("Fake", PartCatalogTypeKind.Regular, assembly, out fakeConfigurableSeverityHighlight);
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