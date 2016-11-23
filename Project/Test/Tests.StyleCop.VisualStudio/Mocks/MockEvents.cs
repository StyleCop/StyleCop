// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockEvents.cs" company="https://github.com/StyleCop">
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
//   The mock events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;

    using EnvDTE;

    /// <summary>
    /// The mock events.
    /// </summary>
    internal class MockEvents : EnvDTE.Events
    {
        #region Constants and Fields

        private readonly MockBuildEvents _buildEvents = new MockBuildEvents();

        #endregion

        #region Properties

        /// <summary>
        /// Gets BuildEvents.
        /// </summary>
        public BuildEvents BuildEvents
        {
            get
            {
                return this._buildEvents;
            }
        }

        /// <summary>
        /// Gets DTEEvents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public DTEEvents DTEEvents
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets DebuggerEvents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public DebuggerEvents DebuggerEvents
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets FindEvents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public FindEvents FindEvents
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets MiscFilesEvents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ProjectItemsEvents MiscFilesEvents
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets SelectionEvents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public SelectionEvents SelectionEvents
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets SolutionEvents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public SolutionEvents SolutionEvents
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets SolutionItemsEvents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ProjectItemsEvents SolutionItemsEvents
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region Implemented Interfaces

        #region Events

        /// <summary>
        /// The get object.
        /// </summary>
        /// <param name="Name">
        /// The name.
        /// </param>
        /// <returns>
        /// The get object.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public object GetObject(string Name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ command bar events.
        /// </summary>
        /// <param name="CommandBarControl">
        /// The command bar control.
        /// </param>
        /// <returns>
        /// The get_ command bar events.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public object get_CommandBarEvents(object CommandBarControl)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ command events.
        /// </summary>
        /// <param name="Guid">
        /// The guid.
        /// </param>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public CommandEvents get_CommandEvents(string Guid, int ID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ document events.
        /// </summary>
        /// <param name="Document">
        /// The document.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public DocumentEvents get_DocumentEvents(Document Document)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ output window events.
        /// </summary>
        /// <param name="Pane">
        /// The pane.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public OutputWindowEvents get_OutputWindowEvents(string Pane)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ task list events.
        /// </summary>
        /// <param name="Filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public TaskListEvents get_TaskListEvents(string Filter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ text editor events.
        /// </summary>
        /// <param name="TextDocumentFilter">
        /// The text document filter.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public TextEditorEvents get_TextEditorEvents(TextDocument TextDocumentFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ window events.
        /// </summary>
        /// <param name="WindowFilter">
        /// The window filter.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public WindowEvents get_WindowEvents(Window WindowFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}