// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachedCodeStrings.cs" company="http://stylecop.codeplex.com">
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
//   Loaded and cached code strings used within the DocumentationRules analyzer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Core
{
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using JetBrains.DataFlow;
    using JetBrains.ProjectModel;
    using JetBrains.Util;

    using StyleCop.ReSharper.ShellComponents;

    /// <summary>
    /// Loaded and cached code strings used within the DocumentationRules analyzer.
    /// </summary>
    public static class CachedCodeStrings
    {
        private static Assembly rulesAssembly;

        // I don't like this, but we need to break the reference between ReSharper and
        // StyleCop.CSharp.Rules. Because StyleCop scans all files in a folder looking
        // for rules, we have to put the files in a sub-folder, or it will scan all of
        // ReSharper's assemblies. But if we do that, the installer can't find it when
        // verifying references from the ReSharper plugin. So, we have to remove the
        // references, which means loosely coupling on these strings. Not ideal, but it
        // does the trick.
        private static string GetPropertyValue([CallerMemberName] string propertyName = "")
        {
            Assertion.AssertNotNull(rulesAssembly, "rulesAssembly != null");

            var type = rulesAssembly.GetType("StyleCop.CSharp.CachedCodeStrings");
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(null, null) as string;
            }
            return string.Empty;
        }

        public static string StructText
        {
            get { return GetPropertyValue(); }
        }

        public static string ClassText
        {
            get { return GetPropertyValue(); }
        }

        public static string HeaderSummaryForStaticConstructor
        {
            get { return GetPropertyValue(); }
        }

        public static string ExampleHeaderSummaryForStaticConstructor
        {
            get { return GetPropertyValue(); }
        }

        public static string ExampleHeaderSummaryForPrivateInstanceConstructor
        {
            get { return GetPropertyValue(); }
        }

        public static string ExampleHeaderSummaryForInstanceConstructor
        {
            get { return GetPropertyValue(); }
        }

        public static string ExampleHeaderSummaryForDestructor
        {
            get { return GetPropertyValue(); }
        }

        public static string HeaderSummaryForPrivateInstanceConstructor
        {
            get { return GetPropertyValue(); }
        }

        public static string HeaderSummaryForInstanceConstructor
        {
            get { return GetPropertyValue(); }
        }

        public static string HeaderSummaryForDestructor
        {
            get { return GetPropertyValue(); }
        }

        public static void Initialise(ISolution solution)
        {
            Lifetimes.Using(
                l =>
                    {
                        var styleCopApi = solution.GetComponent<StyleCopApiPool>().GetInstance(l);
                        var sourceAnalyzer = styleCopApi.Core.GetAnalyzer("StyleCop.CSharp.NamingRules");
                        rulesAssembly = sourceAnalyzer.GetType().Assembly;
                    });
        }
    }
}