// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectFileExtensions.cs" company="http://stylecop.codeplex.com">
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
//   Extension methods for IProjectFile types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JetBrains.ProjectModel
{
    #region Using Directives

    using System;
    using System.Xml;

    using StyleCop.ReSharper513.Diagnostics;

    #endregion

    /// <summary>
    /// Extension methods for IProjectFile types.
    /// </summary>
    public static class IProjectFileExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns true if the project file has been excluded from stylecop in the csproj file.
        /// </summary>
        /// <param name="projectFile">
        /// The IProjectFile to check.
        /// </param>
        /// <returns>
        /// True if its been excluded.
        /// </returns>
        public static bool ProjectFileIsExcludedFromStyleCop(this IProjectFile projectFile)
        {
            StyleCopTrace.In();

            if (projectFile == null)
            {
                StyleCopTrace.Out();

                return false;
            }

            var project = projectFile.GetProject();

            if (project == null)
            {
                StyleCopTrace.Out();

                return false;
            }

            if (project.ProjectFile == null)
            {
                StyleCopTrace.Out();

                return false;
            }

            try
            {
                var xmlDocument = new XmlDocument();

                var relativePathToCsFile = projectFile.Location.ConvertToRelativePath(project.Location).ToString();

                xmlDocument.Load(project.ProjectFile.Location.FullPath);

                var namespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
                namespaceManager.AddNamespace("a", "http://schemas.microsoft.com/developer/msbuild/2003");
                var xmlNode = xmlDocument.SelectSingleNode(string.Format("//a:Project/a:ItemGroup/a:Compile[@Include='{0}'][a:ExcludeFromStyleCop='true']", relativePathToCsFile), namespaceManager);

                if (xmlNode != null)
                {
                    StyleCopTrace.Out();

                    return true;
                }
            }
            catch
            {
            }

            StyleCopTrace.Out();
            return false;
        }

        #endregion
    }
}