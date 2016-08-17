//-----------------------------------------------------------------------
// <copyright file="CommandIdList.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.VisualStudio
{
    using System.ComponentModel.Design;

    /// <summary>
    /// CommandID's that define the menu items.
    /// </summary>
    /// <remarks>The guids defined in this class must match those in commands.h.</remarks>
    internal static class CommandIdList
    {
        #region Public Static Readonly Fields

        /// <summary>
        /// Menu Command ID for the menu item that starts analysis of a project.
        /// </summary>
        public static readonly CommandID AnalyzeProject = new CommandID(GuidList.StyleCopCommandSetId, (int)0x100);

        /// <summary>
        /// Menu Command ID for the menu item that starts analysis of a Analyze Project Folder.
        /// </summary>
        public static readonly CommandID AnalyzeFolder = new CommandID(GuidList.StyleCopCommandSetId, (int)0x110);

        /// <summary>
        /// Menu Command ID for the menu item that starts analysis of a single item.
        /// </summary>
        public static readonly CommandID AnalyzeItem = new CommandID(GuidList.StyleCopCommandSetId, (int)0x120);

        /// <summary>
        /// Menu Command ID for the menu item that starts analysis of an open file.
        /// </summary>
        public static readonly CommandID AnalyzeThisFile = new CommandID(GuidList.StyleCopCommandSetId, (int)0x130);

        /// <summary>
        /// Menu Command ID for the menu item that excludes the analysis of an open file.
        /// </summary>
        public static readonly CommandID ExcludeThisFile = new CommandID(GuidList.StyleCopCommandSetId, (int)0x140);

        /// <summary>
        /// Menu Command ID for the menu item that includes the analysis of an open file.
        /// </summary>
        public static readonly CommandID IncludeThisFile = new CommandID(GuidList.StyleCopCommandSetId, (int)0x145);

        /// <summary>
        /// Menu Command ID for the menu item that starts analysis of the solution.
        /// </summary>
        public static readonly CommandID AnalyzeSolution = new CommandID(GuidList.StyleCopCommandSetId, (int)0x150);

        /// <summary>
        /// Menu Command ID for the menu item that starts analysis of the solution.
        /// </summary>
        public static readonly CommandID ReanalyzeSolution = new CommandID(GuidList.StyleCopCommandSetId, (int)0x160);

        /// <summary>
        /// Menu Command ID for the menu item that starts re-analysis of the project.
        /// </summary>
        public static readonly CommandID ReanalyzeProject = new CommandID(GuidList.StyleCopCommandSetId, (int)0x170);

        /// <summary>
        /// Menu Command ID for the menu item that excludes this item.
        /// </summary>
        public static readonly CommandID ExcludeItem = new CommandID(GuidList.StyleCopCommandSetId, (int)0x180);

        /// <summary>
        /// Menu Command ID for the menu item that includes this item.
        /// </summary>
        public static readonly CommandID IncludeItem = new CommandID(GuidList.StyleCopCommandSetId, (int)0x190);

        /// <summary>
        /// Menu Command ID for the menu item that shows the project settings dialog.
        /// </summary>
        public static readonly CommandID ProjectSettings = new CommandID(GuidList.StyleCopCommandSetId, (int)0x240);

        /// <summary>
        /// Menu Command ID for the menu item that cancels a running analysis.
        /// </summary>
        public static readonly CommandID Cancel = new CommandID(GuidList.StyleCopCommandSetId, (int)0x250);

        #endregion Public Static Readonly Fields
    }
}