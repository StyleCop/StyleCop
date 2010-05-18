<?xml version="1.0"?>
<doc>
    <assembly>
        <name>Microsoft.VisualStudio.Modeling.Sdk.Shell</name>
    </assembly>
    <members>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands">
            <summary>
            Defines CommandID objects for shared commands.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.ModelExplorerDeleteAll">
            <summary>
            Definition of the "DeleteAll" command in the model explorer.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.ModelExplorerAddModelElement">
            <summary>
            Definition of the "Add Model Element" command in the model explorer.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.CompartmentShapeExpandCollapse">
            <summary>
            Definition of the "Expand/Collapse" command in the compartment shapes.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.CompartmentItemAdd">
            <summary>
            Definition of the "Add List Item" command in the compartment list.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.CompartmentItemEdit">
            <summary>
            Definition of the "Edit" command in the compartment list item.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.CompartmentShapeAddItem">
            <summary>
            Definition of the "Add Item" command in the compartment shape.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.SwimlaneAddBefore">
            <summary>
            Definition of the "Add Before" command on the swimlane header.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.SwimlaneAddAfter">
            <summary>
            Definition of the "Add Before" command on the swimlane header.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.Validate">
            <summary>
            Definition of the Validate command.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.ValidateModel">
            <summary>
            Definition of the ValidateModel command.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.Properties">
            <summary>
            Definition of the "Properties" command.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.RerouteLine">
            <summary>
            Reroute command Id.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.PageSetup">
            <summary>
            Page Setup command Id.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.CommonModelingCommands.Print">
            <summary>
            Print command Id.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.CommonModelingPackage">
            <summary>
            Package that offers services, menu commands, etc. which are shared among designers
            built using our framework.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes">
            <summary>
            Types of navigation info nodes
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes.Unknown">
            <summary>
            An unknown type
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes.Project">
            <summary>
            A project node (also known as 'package' or 'physical container')
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes.Namespace">
            <summary>
            A namespace node
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes.Class">
            <summary>
            A class node
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes.Member">
            <summary>
            A member node
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode">
            <summary>
            A single node from a navigation info data object
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.Initialize(Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes,System.String,System.String,System.String)">
            <summary>
            Initialize a navigation info node
            </summary>
            <param name="infoType">type</param>
            <param name="projectName">project name</param>
            <param name="referenceName">reference name</param>
            <param name="fullName">full name</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.Equals(System.Object)">
            <summary>
            Equals override. Defers to Compare function.
            </summary>
            <param name="obj">An item to compare to this object</param>
            <returns>True if the items are equal</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.GetHashCode">
            <summary>
            GetHashCode override
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.op_Equality(Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode,Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode)">
            <summary>
            Equals operator. Defers to Compare.
            </summary>
            <param name="operand1">Left operand</param>
            <param name="operand2">Right operand</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.Compare(Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode,Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode)">
            <summary>
            Compare two VirtualTreeItemInfo structures
            </summary>
            <param name="operand1">Left operand</param>
            <param name="operand2">Right operand</param>
            <returns>true if operands are equal</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.op_Inequality(Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode,Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode)">
            <summary>
            Not equal operator. Defers to Compare.
            </summary>
            <param name="operand1">Left operand</param>
            <param name="operand2">Right operand</param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.ReferenceName">
            <summary>
            Returns the reference name of the drag object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.ProjectName">
            <summary>
            The name of the project this item is contained in
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.FullName">
            <summary>
            The fully qualified, dot (.) delimited name of the element.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoNode.InfoType">
            <summary>
            The type of node of this node
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfo">
            <summary>
            Helper class for decoding navigation info data objects
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfo.ClipFormat">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfo.IsDataPresent(System.Windows.Forms.IDataObject)">
            <summary>
            Does this data object contain navigation info data?
            </summary>
            <param name="data">A data object</param>
            <returns>true if data is present</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfo.IsDataPresent(System.Windows.Forms.IDataObject,Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfoTypes,System.Boolean,System.Boolean)">
            <summary>
            Test whether data of a given format is present in the string
            </summary>
            <param name="data">The data object to test</param>
            <param name="nodeTypes">The types of info to look for</param>
            <param name="allowMultiples">True multiple nodes of infoType are allowed.</param>
            <param name="allowOtherTypes">True if other types can be returned as well.
            Other node types types will be returned by GetData and ignored by the caller.</param>
            <returns>true if the required information is present in the data object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewNavigationInfo.GetData(System.Windows.Forms.IDataObject)">
            <summary>
            Get the navigation nodes from this data object.
            </summary>
            <param name="data">A data object</param>
            <returns>ClassViewNavigationInfoNode array</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DialogBase">
            <summary>
            Base class for dialogs that will be hosted in the VS shell.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.OnLoad(System.EventArgs)">
            <summary>
            
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.#ctor(System.IServiceProvider)">
            <summary>
            Constructor take a service provider. The dialog owner will be the main VS window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.OnUserPreferenceChanged(System.Object,Microsoft.Win32.UserPreferenceChangedEventArgs)">
            <summary>
            Virtual which is called when user's preference is changed.
            </summary>
            <param name="sender">Since the user preference changes are global changes, this sender object is always a null</param>
            <param name="e">A UserPreferenceChangedEventArgs that contains the event data</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.OnHelpRequested(System.Windows.Forms.HelpEventArgs)">
            <summary>
            Override to show help via the Visual Studio help system
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.WndProc(System.Windows.Forms.Message@)">
            <summary>
            Process window messages for the dialog.  Translates clicks on the "?" button to F1 help requests.
            </summary>
            <param name="m"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.ProcessDialogKey(System.Windows.Forms.Keys)">
            <summary>
            Overridden to make sure that only critical exceptions ripple up to the base class.
            Any exceptions which reach there will result invoke the WinForms unhandled exeption dlg. 
            In Visual Studio 2005 that means an IDE crash.
            </summary>
            <param name="keyData"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.ProcessDialogChar(System.Char)">
            <summary>
            Overridden to make sure that only critical exceptions ripple up to the base class.
            Any exceptions which reach there will result invoke the WinForms unhandled exeption dlg. 
            In Visual Studio 2005 that means an IDE crash.
            </summary>
            <param name="charCode"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DialogBase.OnClosed(System.EventArgs)">
            <summary>
            Cleans up resources being used.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DialogBase.DisableSafeWindowTargetHardeningCheck">
            <summary>
            Returns whether to disable SafeWindowTarget hardening check in the debug build. By default, DialogBase derived forms
            will check each and every child control to make sure it's hardened
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DialogBase.ServiceProvider">
            <summary>
            Service provider used to get shell services.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DialogBase.CreateParams">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DialogBase.EnableModeless">
            <summary>
            Gets modless property on the form. Form modal by default.
            Provided override functionality instead of allowing to set the property as this is used in CreateParams, which is 
            called before constructor as well. 
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DialogBase.FormBorderStyle">
            <summary>
            Hide base implementation here so we can provide appropriate handling of FormBorderStyle.Sizable.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DialogBase.F1Keyword">
            <summary>
            Override to specify the F1 keyword for this dialog.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DialogBase.DialogFont">
            <summary>
            The font that Dialogs should use according to IUIService, based on system and application settings.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DocumentSavedEventArgs">
            <summary>
            EventArgs class to carry data about a file save operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocumentSavedEventArgs.#ctor(System.String,System.String)">
            <summary>
            Constructor
            </summary>
            <param name="oldFileName"></param>
            <param name="newFileName"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocumentSavedEventArgs.OldFileName">
            <summary>
            The name of the document before the save operation
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocumentSavedEventArgs.NewFileName">
            <summary>
            The name of the document after the save operation
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DocData">
            <summary>
            Abstract base class representing a file in memory.  This class implements the IVsPersistDocData2
            interface, which the shell calls through to load and save the document.  This class
            also handled listening to external file change events, and prompting the user to reload the file.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.cookie">
            <summary>
            handle that represents this document
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.myHierarchy">
            <summary>
            hierarchy item for this document
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.myItemid">
            <summary>
            itemid for this document
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.fileName">
            <summary>
            name of this document
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.docViews">
            <summary>
            list of DocViews currently open on this DocData
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.serviceProvider">
            <summary>
            used to get services from the VS shell
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.isReadOnly">
            <summary>
            true iff the file corresponding to this in-memory document read-only
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.undoManager">
            <summary>
            Wrapper for shell undo manager.  Unless overriden by derived classes, there is a 1-1 relationship between the undo manager and the document
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.editorId">
            <summary>
            Unique ID of the editor factory that created us.  Used to implement IVsPersistDocData2.GetGuidEditorType
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.fileChangeCookie">
            <summary>
            File change events cookie
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.ignoreFileChangeCount">
            <summary>
            Incremented/decremented in IgnoreFileChanges, this gives external parties like SCC (source code control)
            the ability to tell us to ignore file changes.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.fileChangeTimer">
            <summary>
            Timer we kick off when we get a file change notification.  This is the 
            recommended (but rather rough) way of batching up multiple file change events.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.loaded">
            <summary>
            Indicates whether this DocData has been loaded.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.viewContext">
            <summary>
            Provides additional context to the editor factory when creating a view
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.encoding">
            <summary>
            the encoding that will be used to persist this doc data
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.codeMarkers">
            <summary>
            Code markers to measure performance
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.backupDirtyFlag">
            <summary>
            Flag to note whether the document has a backup that matches its current state
            </summary>
            <remarks>
            True means backup is dirty with respect to document's current state.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.#ctor(System.IServiceProvider,System.Guid)">
            <summary>
            Initialize the DocData.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.GetGuidEditorType(System.Guid@)">
            <summary>
            Returns the unique identifier of the editor factory that created the IVsPersistDocData object.
            </summary>
            <param name="editor">The Guid of the editor factory.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.IsDocDataDirty(System.Int32@)">
            <summary>
            Determines whether the document data has changed since the last save.
            </summary>
            <param name="isDirty">1 if the document needs to be saved.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SetDocDataDirty(System.Int32)">
            <summary>
            Sets the dirty flag for the document data.
            </summary>
            <param name="isDirty">1 if the document is dirty.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SetUntitledDocPath(System.String)">
            <summary>
            Unused.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.HandleLoadDocDataException(System.String,System.Exception,System.Boolean)">
            <summary>
            Called to handle exception thrown during LoadDocData (if any)
            </summary>
            <param name="fileName">Name of the file LoadDocData was called for.</param>
            <param name="exception">Exception thrown.</param>
            <param name="isReload">True if reload, false otherwise.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.HandleSaveDocDataException(System.String,System.Exception)">
            <summary>
            Called to handle exception thrown during SaveDocData (if any)
            </summary>
            <param name="fileName">Name of the file SaveDocData was called for.</param>
            <param name="exception">Exception thrown.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.LoadDocData(System.String)">
            <summary>
            Loads the document data from a given file name.
            </summary>
            <param name="fileName">Filename from which to load the document data.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.LoadDocData(System.String,System.Boolean)">
            <summary>
            Loads the document data from a given file name.  Called by IVsPersistDocData2.LoadDocData
            and IVsPersistDocData2.ReloadDocData
            </summary>
            <param name="fileName">Filename from which to load the document data.</param>
            <param name="isReload">True if the DocData is reloading.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SaveDocData(Microsoft.VisualStudio.Shell.Interop.VSSAVEFLAGS,System.String@,System.Int32@)">
            <summary>
            Saves the document data to a given location. May need to display the Save As dialog.
            </summary>
            <param name="flags">Flags that describe how to save the document.</param>
            <param name="fileName">Name of the file that was saved.</param>
            <param name="saveCanceled">1 if the save was cancelled.</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.CanSave(System.Boolean)">
            <summary>
            Provides derived classes a mechanism to cancel a save operation.
            </summary>
            <param name="allowUserInterface">True if UI may be displayed (will be false in the case of a silent save).</param>
            <returns>True if save should continue, false otherwise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Close">
            <summary>
            Called by the shell when it wants to close the document.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnRegisterDocData(System.UInt32,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)">
            <summary>
            Called by the RDT (running documents table) when it registers the document data.
            </summary>
            <param name="cookie">Abstract handle for the document to be registered.</param>
            <param name="hierarchy">Hierarchy for the document.</param>
            <param name="itemId">Item id of the document to be registered.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.RenameDocData(System.UInt32,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32,System.String)">
            <summary>
            Called by the shell when it wants to rename a document.
            </summary>
            <param name="attributes">Attributes of the document to be renamed.</param>
            <param name="hierarchy">Hierarchy for the document.</param>
            <param name="itemId">Item id of the document.</param>
            <param name="fileName">New name of the document.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.IsDocDataReloadable(System.Int32@)">
            <summary>
            Determines whether or not the document data can be reloaded.
            </summary>
            <param name="isReloadable">1 if the document can be reloaded.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.ReloadDocData(System.UInt32)">
            <summary>
            Reloads the document data.
            </summary>
            <param name="flags">Indicates whether or not to ignore the next file change when reloading the document data.</param>
            <returns></returns>
            <remarks>
            Notes about flags parameter:
            We always discard the undo stack on reload, so the RDD_RemoveUndoStack flag is ignored.
            We support IVsFileChangeControl, so we should not be called with RDD_IgnoreFileChange.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.ReloadDocDataWorker(System.UInt32)">
            <summary>
            Overridable implementation for handling ReloadDocData.
            </summary>
            <param name="flags">Indicates whether or not to ignore the next file change when reloading the document data.</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.IsDocDataReadOnly(System.Int32@)">
            <summary>
            Determines if the document data is read-only.
            </summary>
            <param name="isReadOnly">1 if the document is read-only.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SetDocDataReadOnly(System.Int32)">
            <summary>
            Sets the readOnly flag for the document.
            </summary>
            <param name="newValue">nonzero value indicates that the document is readonly.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.FilesChanged(System.UInt32,System.String[],System.UInt32[])">
            <summary>
            Notifies clients of changes made to one or more files.
            </summary>
            <param name="count">Number of files that have changed.</param>
            <param name="files">An array containing the changed files.</param>
            <param name="changes">An array containing the change to each file.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.DirectoryChanged(System.String)">
            <summary>
            Unused.
            </summary>
            <param name="directory">Directory that changed.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.GetClassID(System.Guid@)">
            <summary>
            Returns the GUID of our editor factory.
            </summary>
            <param name="classId">Contains the GUID.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Microsoft#VisualStudio#Shell#Interop#IPersistFileFormat#GetClassID(System.Guid@)">
            <summary>
            Returns the GUID of our editor factory.
            </summary>
            <param name="classId">Contains the GUID.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.GetCurFile(System.String@,System.UInt32@)">
            <summary>
            Returns the current file name.
            </summary>
            <param name="fileName">Name of the current file.</param>
            <param name="formatIndex">Format index. Not used.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.GetFormatList(System.String@)">
            <summary>
            Returns the list of file formats we support so that the shell can 
            display the Save As dialog.
            </summary>
            <param name="formatList">The list of supported file formats.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.InitNew(System.UInt32)">
            <summary>
            Initializes a document data class.
            </summary>
            <param name="formatIndex">Index of the format we are using to represent the document.</param>
            <remarks>We only support a single file format so the parameter is redundant.</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.IsDirty(System.Int32@)">
            <summary>
            Repeats the functionality provided by IVsPersistDocData2.IsDocDataDirty.
            </summary>
            <param name="dirty">1 if the document is dirty.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Load(System.String,System.UInt32,System.Int32)">
            <summary>
            Loads a file.
            </summary>
            <param name="fileName">File to load.</param>
            <param name="mode">Not used.</param>
            <param name="isReadOnly">Not used.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Save(System.String,System.Int32,System.UInt32)">
            <summary>
            Saves a document.
            </summary>
            <param name="fileName">File to save.</param>
            <param name="remember">1 if we should retain this file name as the name of the document.</param>
            <param name="formatIndex">Not used.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SaveCompleted(System.String)">
            <summary>
            Called when the save operation is complete.
            </summary>
            <param name="fileName">Name of the file that was saved.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.IgnoreFileChanges(System.Int32)">
            <summary>
            IVsDocDataFileChangeControl interface implementation.  Allows clients such as SCC to
            inform the DocData to ignore file changes (in the case a file is reloaded from SCC,
            for example).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.System#IDisposable#Dispose">
            <summary>
            Cleans up resources allocated by the doc data. Allows us to pre-empt the GC.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Dispose(System.Boolean)">
            <summary>
            Disposes the state of this object.
            </summary>
            <param name="disposing">If this method is called from Dispose (true) or Finalizer (false).</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Load(System.String,System.Boolean)">
            <summary>
            Overriden by derived classes to load the document.
            </summary>
            <param name="fileName">Name of the file</param>
            <param name="isReload">True when this method is being called as a result of a reload (from SCC or external file changes)</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Save(System.String)">
            <summary>
            Overriden by derived classes to save the document.
            </summary>
            <param name="fileName">Name of the file.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SaveSubordinateFile(Microsoft.VisualStudio.Modeling.Shell.DocData,System.String)">
            <summary>
            Save the given document that is subordinate to this document.
            </summary>
            <remarks>
            If this document has any subordinate files for which it usually maintains the data (such as diagram files)
            then it must save the data for that file here as the subordinate has been explicitly asked to save itself.
            </remarks>
            <param name="subordinateDocument"></param>
            <param name="fileName"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentLoading(System.EventArgs)">
            <summary>
            Called before the document is initially loaded with data.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentLoaded(System.EventArgs)">
            <summary>
            Called after the document has been initially loaded.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentReloading(System.EventArgs)">
            <summary>
            Called before the document is reloaded.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentReloaded(System.EventArgs)">
            <summary>
            Called after the document has been reloaded.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentSaving(System.EventArgs)">
            <summary>
            Called before the document is saved.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentSaved(System.EventArgs)">
            <summary>
            Called after the document has been saved.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnFileNameChanged(System.EventArgs)">
            <summary>
            Called when the document's filename changes.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnHierarchyChanged(System.EventArgs)">
            <summary>
            Called when the document's hierarchy or itemid changes
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentClosing(System.EventArgs)">
            <summary>
            Called before the document is closed
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentClosed(System.EventArgs)">
            <summary>
            Called after the document is closed
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OnDocumentReadOnlyChanged(System.EventArgs)">
            <summary>
            Called when the ReadOnly state of the document changes.
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.FlushUndoManager">
            <summary>
            Clears the undo/redo stacks
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.OpenView(System.Guid,System.Object)">
            <summary>
            Called to open a particular view on this DocData.
            </summary>
            <param name="viewContext">Object that gives further context about the view to open.  The editor factory that
            supports the given logical view must be able to interpret this object.</param>
            <param name="logicalView">Guid that specifies the view to open.  Must match the value specified in the
            registry for the editor that supports this view.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SetFileName(System.String)">
            <summary>
            Called to initialize/change the filename
            </summary>
            <param name="fileName"></param>
            <returns>true if the filename changed.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SetHierarchyInfo(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)">
            <summary>
            Called to initialize/change the hierarchy.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.QuerySaveFile">
            <summary>
            Helper to perform an SCC QuerySaveFiles call on the file represented by this DocData.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.QuerySaveFile(System.String,Microsoft.VisualStudio.Shell.Interop.tagVSQuerySaveFlags)">
            <summary>
            Helper to perform an SCC QuerySaveFiles call.
            </summary>
            <param name="fileName">File to query.</param>
            <param name="querySaveFlags">QuerySaveFlags.</param>
            <returns>true if OK to save the file.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.QueryEditFile">
            <summary>
            Helper to perform an SCC QueryEditFiles on the file represented by this DocData.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.QueryEditFile(System.String,Microsoft.VisualStudio.Shell.Interop.tagVSQueryEditFlags)">
            <summary>
            Helper to perform an SCC QueryEditFiles call.
            </summary>
            <param name="fileName">File to query.</param>
            <param name="vsQueryEditFlags">QueryEditFlags.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.ProcessQueryEditResult(System.String,Microsoft.VisualStudio.Modeling.Shell.QueryEditResult)">
            <summary>
            Display an error list message if DocData's call to QueryEditFile resulted in a failed attempt to reload the file.
            </summary>
            <param name="filename">File that was queried.</param>
            <param name="queryEditResult">structure containing information about the result returned from QueryEditFile.</param>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.errorList">
            <summary>
            An error list service provider used to display and clear error messages to the Error List.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DocData.checkoutNotPossibleErrorMessage">
            <summary>
            This message is displayed when an attempt to check-out the server version of an application 
            diagram (.ad) file fails because we do not support reloading the diagram in this situation.  
            (see VSWhidbey bug 434864 for more details.)
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.ShowCheckoutNotPossibleErrorMessage(System.String)">
            <summary>
            Show the message in the Error List.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.ClearCheckoutNotPossibleErrorMessage">
            <summary>
            Clear the message from the Error List, if it exists.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SuspendFileChangeNotification(System.String)">
            <summary>
            Suspend file change notifications for the given file.  Helpful to avoid spurious file reload messages
            for subordinate files.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.ResumeFileChangeNotification(System.String)">
            <summary>
            Resume file change notifications for the given file.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.ShowSaveOptionsDlg(System.UInt32,System.IntPtr,System.IntPtr)">
            <summary>
            Implementation of IVsSaveOptionsDlg.ShowSaveOptionsDlg. Display the AdvancedSaveDialog to gather
            the encoding from the user.
            </summary>
            <param name="dwReserved"></param>
            <param name="hwndDlgParent"></param>
            <param name="pszFilename"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.SetData(System.Guid@,System.Object)">
            <summary>
            Implementation of IVsUserData.SetData
            Called by IVsCodePageSelection.ShowEncodingDialog to return the selected encoding.
            </summary>
            <param name="riidKey">The type of data being set.</param>
            <param name="vtData">the actual data set.</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.GetData(System.Guid@,System.Object@)">
            <summary>
            Implementation of IVsUserData.GetData
            </summary>
            <param name="riidKey">The type of data being requested.</param>
            <param name="pvtData">the data we return.</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Microsoft#VisualStudio#TextManager#Interop#IVsFileBackup#BackupFile(System.String)">
            <summary>
            Make a single file backup of this document.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.Microsoft#VisualStudio#TextManager#Interop#IVsFileBackup#IsBackupFileObsolete(System.Int32@)">
            <summary>
            Is the backup file dirty with respect to this document?
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.BackupFile(System.String)">
            <summary>
            Make a single file backup of this document. Returns whether the document is expected to re-load without data loss.
            If there are any actual save errors then an exception should be raised.
            </summary>
            <param name="backupFileName"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DocData.MarkDocumentChangedForBackup">
            <summary>
            Mark that the document has changed and thus a new backup should be created
            </summary>
            <remarks>
            Call this method when you change the document's content
            </remarks>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.UndoManagerIsShared">
            <summary>
            If derived classes need share the same undo manager among
            multiple DocData instances, they should override this property to return
            true.  Derived classes that return true here are also responsible for
            handling undo manager disposal.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.FormatList">
            <summary>
            Overriden in derived classes to return a string used to filter the Save As... dialog.
            Each string should be terminated with a newline (\n) character. The last string in the 
            buffer must be terminated with the newline character as well. The caller can replace each newline 
            character with a NULL (\0) character. Then, the caller can have a string that is the same as the 
            lpstrFilter member of the WinAPI OPENFILENAME structure. The first string in each pair is a 
            display string that describes the filter, such as "Text Only (*.txt)". The second string specifies 
            the filter pattern, such as "*.txt". To specify multiple filter patterns for a single display string, 
            use a semicolon to separate the patterns: "*.htm;*.html;*.asp". A pattern string can be a combination 
            of valid file name characters and the asterisk (*) wildcard character. Do not include spaces in the 
            pattern string. The following string is an example of a file pattern string: 
            "HTML File (*.htm; *.html; *.asp)\n*.htm;*.html;*.asp\nText File (*.txt)\n*.txt\n."
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentLoading">
            <summary>
            Fires before the document is intitially loaded with data.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentLoaded">
            <summary>
            Fires after the document has been initially loaded.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentReloading">
            <summary>
            Fires before the document is reloaded.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentReloaded">
            <summary>
            Fires after the document has been reloaded.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentSaving">
            <summary>
            Fires before the document is saved.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentSaved">
            <summary>
            Fires after the document has been saved.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.FileNameChanged">
            <summary>
            Fired when the document's filename changes.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.HierarchyChanged">
            <summary>
            Fired when the document's hierarhcy or itemid changes
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentClosing">
            <summary>
            Fired before the document is closed
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentClosed">
            <summary>
            Fired after the document is closed
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DocData.DocumentReadOnlyChanged">
            <summary>
            Fired when the ReadOnly state of the document changes.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.DocViews">
            <summary>
            Retrieves the collection of views currently open on this document.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.UndoManager">
            <summary>
            Returns the undo manager for the DocData.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.VSUndoManager">
            <summary>
            Provides access to the VS undo manager interface.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.FileName">
            <summary>
            Gets the filename corresponding to this document
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.Cookie">
            <summary>
            Gets the cookie used to indentify this document in the RDT (running documents table).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.Hierarchy">
            <summary>
            Gets the hierarchy this document belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.ItemId">
            <summary>
            Gets the itemid which identifies this document within its hierarchy.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.ServiceProvider">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.ResourceManager">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.IsLoaded">
            <summary>
            Indicates whether this DocData has been loaded.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.ViewContext">
            <summary>
            Object used by the editor factory to further specify the view to open.  
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.Encoding">
            <summary>
            Gets or sets the encoding that this doc data is persisted in
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DocData.IsBackupFileObsolete">
            <summary>
            Is the backup file dirty with respect to this document?
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult">
            <summary>
            Struct that encapsulates the results of a call to IVsQueryEditQuerySave.QueryEditFiles
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.#ctor(Microsoft.VisualStudio.Shell.Interop.tagVSQueryEditResult,Microsoft.VisualStudio.Shell.Interop.tagVSQueryEditResultFlags)">
            <summary>
            Construct a new QueryEditResult
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.Equals(System.Object)">
            <summary>
            Compares this object to another.
            </summary>
            <param name="obj">The other object.</param>
            <returns>Whether objects are equal.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.op_Equality(Microsoft.VisualStudio.Modeling.Shell.QueryEditResult,Microsoft.VisualStudio.Modeling.Shell.QueryEditResult)">
            <summary>
            Gets whether arguments are equal.
            </summary>
            <param name="arg1">First argument.</param>
            <param name="arg2">Second argument.</param>
            <returns>True if arguments are equal.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.op_Inequality(Microsoft.VisualStudio.Modeling.Shell.QueryEditResult,Microsoft.VisualStudio.Modeling.Shell.QueryEditResult)">
            <summary>
            Gets whether arguments are not equal.
            </summary>
            <param name="arg1">First argument.</param>
            <param name="arg2">Second argument.</param>
            <returns>True if arguments are not equal.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.GetHashCode">
            <summary>
            Get hash-code for this object.
            </summary>
            <returns>Hashcode.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.Result">
            <summary>
            Detailed result returned from QueryEdit.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.MoreInfo">
            <summary>
            Flags returned from QueryEdit
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.CanEditFile">
            <summary>
            Indicates whether editing of the file is allowed.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.QueryEditResult.FileReloaded">
            <summary>
            Indicates whether the file was reloaded as a result of the QueryEdit call.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult">
            <summary>
            Struct that encapsulates the results of a call to IVsQueryEditQuerySave.QuerySaveFiles
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.#ctor(Microsoft.VisualStudio.Shell.Interop.tagVSQuerySaveResult)">
            <summary>
            Construct a new QueryEditResult
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.Equals(System.Object)">
            <summary>
            Compares this object to another.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.op_Equality(Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult,Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult)">
            <summary>
            Equality.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.op_Inequality(Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult,Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult)">
            <summary>
            Inequality.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.GetHashCode">
            <summary>
            Gets a hashcode for this object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.Result">
            <summary>
            Detailed result returned from QuerySave.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.CanSaveFile">
            <summary>
            True iff the Save operation should continue.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.QuerySaveResult.ForceSaveAs">
            <summary>
            True iff the Save operation should be converted to a Save As.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.FileCancelException">
            <summary>
            FileCancelException.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.FileCancelException.#ctor">
            <summary>
            Constructor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.FileCancelException.#ctor(System.String)">
            <summary>
            Constructor.
            </summary>
            <param name="message">Message.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.FileCancelException.#ctor(System.String,System.Exception)">
            <summary>
            Constructor.
            </summary>
            <param name="message">Message.</param>
            <param name="innerException">Inner Exception.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.FileCancelException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Constructor.
            </summary>
            <param name="serializationInfo">SerializationInfo.</param>
            <param name="streamingContext">StreamingContext.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DynamicStatusMenuCommand">
            <summary>
            Alias for the VsMenuCommand. It is intendend to reduce the merge conflicts during
            Lab22dev to Lab23 integrations and must be deleted in Lab23 when the integration
            is done.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DynamicStatusMenuCommand.#ctor(System.EventHandler,System.EventHandler,System.ComponentModel.Design.CommandID)">
            <summary>
            Construct a new DynamicStatusMenuCommand
            </summary>
            <param name="statusHandler">Event handler called when command status needs to be updated.</param>
            <param name="invokeHandler">Event handler called when command is invoked.</param>
            <param name="id">Command ID</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData">
            <summary>
            DocData object that represents a subordinate file in memory (represented as a child project item in the Solution Explorer).
            </summary>
            <remarks>
            Subordinate files are assumed to have some "parent" DocData object that handles actual serialization.
            This class exists so that the subordinate file can be registered in the VS Running Documents Table
            and tracked by the VS shell.
            </remarks>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.inReload">
            <summary>
            IsReload.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Shell.DocData)">
            <summary>
            Creates a SubordinateDocData instance.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.Load(System.String,System.Boolean)">
            <summary>
            Subordinate files are assumed to have some "parent" DocData object that handles actual serialization, so Load operation is a no-op.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.Save(System.String)">
            <summary>
            Subordinate files are assumed to have some "parent" DocData object that usually handles actual serialization
            Save operation is a no-op except in the case of SaveAs.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.IsDocDataDirty(System.Int32@)">
            <summary>
            By default, the subordinate document is considered dirty if the parent is dirty.
            </summary>
            <param name="isDirty"></param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.ParentDocData">
            <summary>
            Retrieves the parent DocData for this subordinate document.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.InReload">
            <summary>
            InReload.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocData.FormatList">
            <summary>
            List of format specifiers for the SubordinateDocData.
            </summary>
            <remarks>
            Returns String.Empty since the SubordinateDocData doesn't support loading files directly.
            </remarks>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder">
            <summary>
            Manages an edit lock on a subordinate file in the running documents table.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Shell.DocData,System.String,System.UInt32)">
            <summary>
            Creates a new SubordinateDocumentLockHolder.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.UnregisterSubordinateDocument">
            <summary>
            Unregisters the subordinate document and removes it from memory. This method does not save the document.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.CloseDocumentHolder(System.UInt32)">
            <summary>
            Releases the lock on the subordinate document and unregisters the lock holder.
            </summary>
            <param name="dwSaveOptions"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.ShowDocumentHolder">
            <summary>
            Shows the first view associated with the parent document.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.Finalize">
            <summary>
            Finalizer
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.Dispose">
            <summary>
            Dispose this instance
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.Dispose(System.Boolean)">
            <summary>
            Dispose pattern implementation
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SubordinateDocumentLockHolder.SubordinateDocData">
            <summary>
            Retrieves the subordinate DocData managed by this lock holder.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.SubordinateFileHelper">
            <summary>
            Helper methods for managing subordinate files (files that appear nested within project items in the solution explorer).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateFileHelper.GetChildProjectItemId(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32,System.String)">
            <summary>
            Gets the item id of the first subordinate file with the given extension.
            </summary>
            <param name="parentHierarchy">Parent hierarchy.</param>
            <param name="parentItemId">Item id identifying parent file.</param>
            <param name="extension">Extension to find (including the ".").</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateFileHelper.GetChildProjectItemIds(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)">
            <summary>
            Gets the item ids of all subordinate files.
            </summary>
            <param name="parentHierarchy">Parent hierarchy.</param>
            <param name="parentItemId">Item id identifying parent file.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateFileHelper.GetChildProjectItemFileNames(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)">
            <summary>
            Gets a list of file names of all subordinate files.
            </summary>
            <param name="parentHierarchy">Parent hierarchy.</param>
            <param name="parentItemId">Item id identifying parent file.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateFileHelper.LockSubordinateDocument(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Shell.DocData,System.String,System.UInt32)">
            <summary>
            Creates and returns an invisible editor for the given file.
            </summary>
            <param name="serviceProvider">Service provider used to retrieve shell services.</param>
            <param name="parentDocData">Parent document.</param>
            <param name="childFileName">File to create the lock holder for.</param>
            <param name="childItemId">Item id identifying subordinate document.</param>
            <returns>IVsInvisibleEditor object representing the file in memory.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SubordinateFileHelper.LockSubordinateDocument(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Shell.DocData,System.UInt32)">
            <summary>
            Creates and returns an invisible editor for the given file.
            </summary>
            <param name="serviceProvider">Service provider used to retrieve shell services.</param>
            <param name="parentDocData">Parent document.</param>
            <param name="childItemId">Item id identifying child file.</param>
            <returns>IVsInvisibleEditor object representing the file in memory.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.UndoManager">
            <summary>
            Helper class which wraps the VS shell's undo manager.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoManager.undoManager">
            <summary>
            Undo manager we are wrapping.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoManager.undoCommandTarget">
            <summary>
            Command target for undo events, obtained through QI on the undoManager.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoManager.serviceProvider">
            <summary>
            ServiceProvider for shell services.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoManager.isDirty">
            <summary>
            This is so we can support setting IsDirty to true, which is required by IVsPersistDocData2
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoManager.advisedForLinkedUndo">
            <summary>
            Keeps track of whether we've advised the IVsLinkedUndoClient interface
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoManager.OLEUndoManagerGuid">
            <summary>
            Guid of the undo manager, passed to ILocalRegistry::CreateInstance
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoManager.processingExec">
            <summary>
            State variables used to batch DiscardUndoStacks calls made during undo/redo processing. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.#ctor(System.IServiceProvider)">
            <summary>
            Create a new UndoManager.  This CoCreates the shell's undo manager.
            </summary>
            <param name="serviceProvider">service provider used to retrieve shell services.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.#ctor(System.IServiceProvider,Microsoft.VisualStudio.OLE.Interop.IOleUndoManager)">
            <summary>
            Create a new UndoManager with the specified service provider and OLEUndoManager.
            If the specified OLEUndoManager is null, then a new OLEUndoManager is created and sited
            with the service provider.
            If on the other hand an OLEUndoManager is passed in it is assumed that it has already
            been sited with a service provider. It is required that the supplied undo manager 
            implement IOleCommandTarget. It is expected that it implement IVsLinkCapableUndoManager,
            if not then linked undo will not be available.
            </summary>
            <param name="serviceProvider">service provider used to retrieve shell services.</param>
            <param name="oleUndoManager">An externally provided OLEUndoManager, or null to have one created.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.DiscardUndoStacks(System.Boolean)">
            <summary>
            Throws away undo/redo stacks. If the bool is true, then in addition to discarding the
            undostack the routine will mark the stack as clean.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.OnInterveningUnitBlockingLinkedUndo">
            <summary>
            This is called in the case that there is a strictly linked undo across multiple
            documents, and the user wants to undo past the point of the linked undo.
            The intent is that the designer will put up some UI informing the user of
            this. It turns out that currently you have to implement this if you ever want your undo 
            manager to participate in linked undo, whether or not you use strict linking.
            We just return E_FAIL, which directs the shell to put up the default UI.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.Exec(System.Guid@,System.UInt32,System.UInt32,System.IntPtr,System.IntPtr)">
            <summary>
            Implementation of IOleCommandTarget interface.  Passes call through to undoCommandTarget.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.QueryStatus(System.Guid@,System.UInt32,Microsoft.VisualStudio.OLE.Interop.OLECMD[],System.IntPtr)">
            <summary>
            Implementation of IOleCommandTarget interface.  Passes call through to undoCommandTarget.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.Add(Microsoft.VisualStudio.OLE.Interop.IOleUndoUnit)">
            <summary>
            Adds an undo unit to the stack and updates the UI.
            </summary>
            <param name="undoUnit"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.DiscardBottom">
            <summary>
            Discards 1 undo item from the bottom of the undo stack
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.Finalize">
            <summary>
            Finalizer.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.Dispose">
            <summary>
            Cleans up resources allocated by the doc data. Allows us to pre-empt the GC.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoManager.Dispose(System.Boolean)">
            <summary>
            Disposes the state of this object.
            </summary>
            <param name="disposing">True if called from Dispose(), false if from finalizer.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.UndoManager.IsDirty">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.UndoManager.VSUndoManager">
            <summary>
            This is what should be pushed to the SEID for a window frame that wants to use this 
            undo manager.  We can't wrap IOleUndoManager in a managed object because the property
            browser QI's for MS.VS.NativeMethods.IOleCommandTarget, which is private, so we can't 
            implement it on this class. 
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ContainerBase">
            <summary>
            This is the base class for the main control in tool windows.  It performs such things as drawing a border, a watermark, and any other common tool window operations.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ContainerBase.WatermarkBorderOffset">
            <summary>
            WatermarkBorderOffset from the bounding rectangle.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ContainerBase.#ctor(System.IServiceProvider)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ContainerBase.OnPaint(System.Windows.Forms.PaintEventArgs)">
            <summary>
            Event handler when window is being repainted
            </summary>
            <param name="e">Event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ContainerBase.WndProc(System.Windows.Forms.Message@)">
            <summary>
            Overriding the window callback function
            </summary>
            <param name="m">Windows message</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ContainerBase.Watermark">
            <summary>
            Watermark
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ContainerBase.BorderRectangle">
            <summary>
            Border Rect
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ContainerBase.HasBorder">
            <summary>
            Always has a border
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor">
            <summary>
            Summary Description for ExplorerElementVisitor.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.treeNodeHash">
            <summary>
            Table of TreeNodes, hashed by represented Element
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.treeContainer">
            <summary>
            ServiceProvider
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.visitedRoot">
            <summary>
            Tracks whether we've visited the root element in the traversal
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.#ctor(Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer)">
            <summary>
            Constructor
            </summary>
            <param name="treeContainer">tree container class</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.Visit(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Visit
            </summary>
            <param name="walker">The ElementWalker that is currently traversing the model</param>
            <param name="modelElement">Model Element</param>
            <returns>True always</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.StartTraverse(Microsoft.VisualStudio.Modeling.ElementWalker)">
            <summary>
            Starting Traverse
            </summary>
            <param name="walker">The ElementWalker that is currently traversing the model</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.EndTraverse(Microsoft.VisualStudio.Modeling.ElementWalker)">
            <summary>
            Ending Traverse
            </summary>
            <param name="walker">The ElementWalker that is currently traversing the model</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.PruneTree">
            <summary>
            Prune Tree
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.PruneTree(System.Windows.Forms.TreeNode)">
            <summary>
            Prune Tree
            </summary>
            <param name="parentNode">TreeNode</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.TreeNodeHash">
            <summary>
            TreeNode Hash
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.TreeView">
            <summary>
            Return the TreeView control (hosted within the ModelexplorerContainer) used by the visiter
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExplorerElementVisitor.TreeContainer">
            <summary>
            Return the the ModelexplorerContainer used by this visiter
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.GetModelElementDisplayNameEventHandler">
            <summary>
            Delegate call back for allowing the generated designer to proffer an different display name shown in the 
            ModelExplorer
            </summary>
            <param name="modelElement">modelElement which will be displayed in the ModelExplorer</param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode">
            <summary>
            Our own TreeNode implementation for displaying properties and relationships
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode.keepNode">
            <summary>
            Used to prune tree during updates
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode.#ctor">
            <summary>
            Constructor. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode.UpdateNodeText">
            <summary>
            Force an update of the text of the node
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode.ProvideNodeText">
            <summary>
            Supply the text for the node
            </summary>
            <returns>The text for the node</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode.KeepNode">
            <summary>
            Used to prune tree during updates
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode">
            <summary>
            TreeNode implementation for displaying a ModelElement
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode.modelElement">
            <summary>
            Hold on to current referenced ModelElement
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode.#ctor(Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            ctor
            </summary>
            <param name="container">container object which hosts the TreeView control</param>
            <param name="modelElement">ModelElement represented by this node</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode.#ctor(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Internal ctor for testing purpose
            </summary>
            <param name="modelElement"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode.OnNameChanged(System.Object,Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs)">
            <summary>
            Event Handler
            </summary>
            <param name="sender">Sender</param>
            <param name="e">Event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode.ProvideNodeText">
            <summary>
            Suppply the text for the node
            </summary>
            <returns>The text for the node</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode.ModelElement">
            <summary>
            Read-only accessor for ModelElement being shown
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelElementTreeNode.ShowDomainClass">
            <summary>
            Get/Set whether to show the DomainClass Name right after the ModelElement name (e.g "foo (Foo)" in the tree node text)
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.RoleGroupTreeNode">
            <summary>
            RoleGroupTreeNode is the tree node which sits between the parent role player and it’s children in an 1-many embedding domain relationship. 
            The RoleGroupTreeNode text comes from the DomainRole.PropertyDisplayName of the side of the child role player.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RoleGroupTreeNode.metaRole">
            <summary>
            Hold on to current metaRoleInfo
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RoleGroupTreeNode.#ctor(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Constructor
            </summary>
            <param name="metaRole">Role represented by this node</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RoleGroupTreeNode.ProvideNodeText">
            <summary>
            Suppply the text for the node
            </summary>
            <returns>The text for the node</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.RoleGroupTreeNode.RoleInfo">
            <summary>
            Read-only accessor for ModelElement being shown
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.RoleTreeNode">
            <summary>
            Model explorer node displayed that displays a relationship with Cardinality=One.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RoleTreeNode.rolePlayer">
            <summary>
            Hold on to relationship
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RoleTreeNode.#ctor(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Constructor
            </summary>
            <param name="metaRole">Role whose name should be displayed.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RoleTreeNode.ProvideNodeText">
            <summary>
            Suppply the text for the node
            </summary>
            <returns>The text for the node</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.RoleTreeNode.RolePlayer">
            <summary>
            Read-only accessor for element currently playing the role shown.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.RoleTreeNode.RoleInfo">
            <summary>
            Read-only accessor for role being shown
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.RoleTreeNode.ShowDomainClass">
            <summary>
            Get/Set whether to show the DomainClass Name right after the ModelElement name (e.g "foo (Foo)" in the tree node text)
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelExplorer.ModelExplorer">
            <summary>
              A strongly-typed resource class, for looking up localized strings, etc.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorer.ModelExplorer.ResourceManager">
            <summary>
              Returns the cached ResourceManager instance used by this class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorer.ModelExplorer.Culture">
            <summary>
              Overrides the current thread's CurrentUICulture property for all
              resource lookups using this strongly typed resource class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorer.ModelExplorer.ModelBrowser">
            <summary>
              Looks up a localized string similar to Model Browser.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow">
            <summary>
            This is the tool window class that houses the Model Browser
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ToolWindow">
            <summary>
            Provides a base class for tool windows.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane">
            <summary>
            Contains glue for hosting Modeling-based designers in the shell that applies to both tool windows and document views.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.localServiceProvider">
            <summary>
            Service provider local to this window frame,
            used to get selection service from the shell
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.menuService">
            <summary>
            Command service local to this window frame which derived classes and hosted 
            controls can add commands to.  Commands added here will only appear when this
            window has focus.  Note that command placement depends on the .ctc file, this
            object only associates handlers with existing commands.
            
            Note : we use this instead of the base class implementation of IOleCommandTarget in order
            to support chaining command services together
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.primarySelection">
            <summary>
            The "primary" object in the selection collection.  
            Not all designers will support this concept.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.selectedElements">
            <summary>
            Stores the elements currently selected in this window
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.frame">
            <summary>
            Cached frame pointer.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.activeInPlaceEditWindow">
            <summary>
            Currently active in-place edit control.  Clipboard commands get routed here.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.commandTarget">
            <summary>
            Can't implement IOleCommandTarget on class itself, because it is implemented on a base class
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.selectionHelpService">
            <summary>
            Help service corresponsing to context bag for the current selection.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.#ctor(System.IServiceProvider)">
            <summary>
            
            </summary>
            <param name="serviceProvider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SetSite(System.Object)">
            <summary>
            Implementation of IObjectWithSite.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetSite(System.Guid@,System.IntPtr@)">
            <summary>
            Implementation of IObjectWithSite.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.CommitPendingEditForCommand(System.ComponentModel.Design.CommandID)">
            <summary>
            Gives derived classes a chance to commit outstanding edits before a 
            command is executed.  This is called frequently, so only lightweight
            processing should be done here.  This is preferable to
            IVsWindowPaneCommit.CommitPendingEdit, because it allows derived classes
            to make the decision to commit for some commands but not others. 
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetService(System.Type)">
            <summary>
            Override to return our menu command service implementation.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.PreProcessMessage(System.Windows.Forms.Message@)">
            <summary>
            Allows us to handle window messages.
            </summary>
            <param name="m">Message to be handled.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.Dispose(System.Boolean)">
            <summary>
            Dispose of resources
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.OnClose">
            <summary>
            Called when window is closed. Overridden here to remove our objects from the selection context so that 
            the property browser doesn't call back on our objects after the window is closed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.CountObjects(System.UInt32,System.UInt32@)">
            <summary>
            Implementation of ISelectionContainer interface.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetObjects(System.UInt32,System.UInt32,System.Object[])">
            <summary>
            Implementation of ISelectionContainer interface.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SelectObjects(System.UInt32,System.Object[],System.UInt32)">
            <summary>
            Implementation of ISelectionContainer interface.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.CountSelectedObjects">
            <summary>
            Implementation of ISelectionContainer interface.
            </summary>
            <returns>Count of Selected Objects.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.CountAllObjects">
            <summary>
            mplementation of ISelectionContainer interface.
            </summary>
            <returns>Count of All Objects.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetSelectedObjects(System.UInt32,System.Object[])">
            <summary>
            ISelectionContainer.GetObjects (Selected).
            </summary>
            <param name="count">Count of Objects to get.</param>
            <param name="objects">Array of Objects to return.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetAllObjects(System.UInt32,System.Object[])">
            <summary>
            ISelectionContainer.GetObjects (All).
            </summary>
            <param name="count">Count of Objects to get.</param>
            <param name="objects">Array of Objects to return.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.DoSelectObjects(System.UInt32,System.Object[],System.UInt32)">
            <summary>
            Derived classes should override to support selection via ISelectionContainer.SelectObjects.
            For instance, The drop-down above the VS property browser uses this mechanism, as does automation.
            </summary>
            <param name="count">Count of Objects to select.</param>
            <param name="objects">Array of Objects to select.</param>
            <param name="flags">Flags.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetComponentSelected(System.Object)">
            <summary>
            Returns true iff obj is currently selected.
            </summary>
            <param name="obj">Object to test</param>
            <returns>Returns true iff obj is currently selected.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetContainerSelected(System.Object)">
            <summary>
            Implementation identical to GetComponentSelected.
            </summary>
            <param name="value">Object to test</param>
            <returns>Returns true iff value is currently selected.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.GetSelectedComponents">
            <summary>
            Returns a read-only collection of currently selected components.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SetSelectedComponents(System.Collections.ICollection)">
            <summary>
            Pushes components into the selection container (replaces currently selected components), and notifies the
            shell of a selection change.
            </summary>
            <param name="components">Collection of componets to select.  Passing null is allowed, it is equivalent to passing an empty collection.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.OnSelectionChanged(System.EventArgs)">
            <summary>
            Called when the selection changes.  Derived classes that override this method
            should make sure to call the base class so event listeners are notified.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.OnSelectionChanging(System.EventArgs)">
            <summary>
            Called prior to a selection change.  Derived classes that override this method
            should make sure to call the base class so event listeners are notified.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SetSelectedComponents(System.Collections.ICollection,System.ComponentModel.Design.SelectionTypes)">
            <summary>
            Not used.  Implemenation of ISelectionService interface.
            </summary>
            <param name="components"></param>
            <param name="selectionType"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.Show">
            <summary>
            Shows this window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.ShowNoActivate">
            <summary>
            Shows this window without activating it.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.Hide">
            <summary>
            Hides this window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.ServiceProvider">
            <summary>
            Gets the service provider local to this window frame
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.ActiveInPlaceEditWindow">
            <summary>
            May be set to provide an active in-place edit window
            Clipboard commands will be routed to this window.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.HasSelectableObjects">
            <summary>
            If this property returns false, we do not expose objects via ISelectionContainer 
            to avoid handing out disposed objects to the property browser.
            Base class returns true. Can be overridden in derived classes to return false when
            a document or window is closed.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.PrimarySelection">
            <summary>
            Returns the current primary selection.  If one hasn't been set,
            returns the first object in the collection
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SelectionCount">
            <summary>
            A count of the currently selected objects.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SelectionChanged">
            <summary>
            This event gets fired after a selection change in this window.  Clients that
            want notification of selection changes to this window should register an event
            handler.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SelectionChanging">
            <summary>
            This event gets fired just prior to a selection change in this window.  Clients that
            want notification of selection changes to this window should register an event
            handler.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SelectedElements">
            <summary>
            Stores the elements currently selected in this window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.Frame">
            <summary>
            Provides access to the IVsWindowFrame corresponding to this window.
            In most cases, direct access to this interface is not necessary
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.MenuService">
            <summary>
            Gets the IMenuCommandService which derived classes and hosted controls can use to add commands.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.HelpService">
            <summary>
            Help context managed by this window.  Keywords and attributes placed in this context will 
            have priority HelpContextType.Window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.SelectionHelpService">
            <summary>
            Help context managed by this window.  Help keywords and attributes placed in this context 
            have priority HelpContextType.Selection for document windows and HelpContextType.ToolWindowSelection
            for tool windows.  The context is cleared on each selection change, so derived class that use this
            context should override OnSelectionChanged to keep it up-to-date.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.ModelingWindowPaneCommandTarget.Microsoft#VisualStudio#OLE#Interop#IOleCommandTarget#Exec(System.Guid@,System.UInt32,System.UInt32,System.IntPtr,System.IntPtr)">
            <devdoc>
             Executes the given command.
            </devdoc>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingWindowPane.ModelingWindowPaneCommandTarget.Microsoft#VisualStudio#OLE#Interop#IOleCommandTarget#QueryStatus(System.Guid@,System.UInt32,Microsoft.VisualStudio.OLE.Interop.OLECMD[],System.IntPtr)">
            <devdoc>
             Inquires about the status of a command.  A command's status indicates
             it's availability on the menu, it's visibility, and it's checked state.
            </devdoc>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.currentView">
            <summary>
            the currently focused document view,
            or null if one of our document windows isn't focused.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.#ctor(System.IServiceProvider)">
            <summary>
            Construct a tool window.
            </summary>
            <param name="serviceProvider">service provider used to retrieve shell services</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.Dispose(System.Boolean)">
            <summary>
            Dispose of resources.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.Initialize">
            <summary>
            Perform initializaton.  ToolWindow base class set frame properties here.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.OnCreate">
            <summary>
            Called when the ToolWindow is created.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.OnToolWindowCreate">
            <summary>
            Called when the ToolWindow is created.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.OnDocumentChanged(System.Object,Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionEventArgs)">
             <summary>
             We use this to listen for frame changes from the shell.  When we get one, we test the associated ModelingDocView
             to see if it is one of ours.  If it is, we pass it along to any derived classes that want to know about it.
             </summary>
            
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.OnDocumentWindowChanged(Microsoft.VisualStudio.Modeling.Shell.ModelingDocView,Microsoft.VisualStudio.Modeling.Shell.ModelingDocView)">
            <summary>
            Derived classes can override this to receive notification when the document window
            changes in the shell.  The new view is stored in the CurrentView property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.HasSelectableObjects">
            <summary>
            Overridden here to return false when the document we are tracking is closed.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.DocData">
            <summary>
            Gets the currently focused document data.  This will be null if this is not
            an instance of our DocData object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.EnableUndo">
            <summary>
            Used by derived classes to turn on/off handling of undo commands.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.BitmapResource">
            <summary>
            Overriden in derived classes to specify the resource id of the bitmap to display
            next to the tool window name in tabbed mode.  This must be an index into the
            unmanaged satellite dll corresponding to this package.
            If -1 is returned, the toolwindow is considered to not have a Bitmap. b409435
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.BitmapIndex">
            <summary>
            Overriden in derived classes to specify the index of the bitmap to display next
            to the tool window name in tabbed mode.  This must be an index into the image
            resource specified by the BitmapResource property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.WindowTitle">
            <summary>
            Overriden in derived classes to specify title for the tool window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.HasToolBar">
            <summary>
            Overriden in derived classes that want to host a toolbar.  Placement and toolbar
            to display should be set in the derived class via the ToolbarHost.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.ToolBarHost">
            <summary>
            Provides derived classes access to the shell implementation of
            IVsToolWindowToolbarHost, used to manage toolbars in the the tool
            window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ToolWindow.ToolWindowFont">
            <summary>
            Returns the font used by the VS shell for dialog boxes and tool windows.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.treeContainer">
            <summary>
            Model Browser
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.#ctor(System.IServiceProvider)">
            <summary>
            Constructor
            </summary>
            <param name="serviceProvider">Service Provider</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.OnDocumentWindowChanged(Microsoft.VisualStudio.Modeling.Shell.ModelingDocView,Microsoft.VisualStudio.Modeling.Shell.ModelingDocView)">
            <summary>
            Called when document window changes
            </summary>
            <param name="oldView">old ModelingDocView</param>
            <param name="newView">new ModelingDocView</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.OnToolWindowCreate">
            <summary>
            Called when the control hosted within the tool window is first created.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.Dispose(System.Boolean)">
            <summary>
            Called when the tool window is disposed.
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.CreateTreeContainer">
            <summary>
            Create TreeContainer
            </summary>
            <returns>ModelExplorerTreeContainer</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.Window">
            <summary>
            Create main control
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.EnableUndo">
            <summary>
            The Window uses undo
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.WindowTitle">
            <summary>
            Window Title
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow.TreeContainer">
            <summary>
            Model Browser
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer">
            <summary>
            Tree Container
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.DefaultModelElementTreeNodeImageIndex">
            <summary>
            Return the default stock model element image index.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.DefaultRoleGroupTreeNodeImageIndex">
            <summary>
            Return the default RoleGroupTreeNode image index in the ImageList
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.DefaultRoleTreeNodeImageIndex">
            <summary>
            Return the default RoleTreeNode image index in the ImageList
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.objectModelBrowser">
            <summary>
            Model browser
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.serviceProvider">
            <summary>
            Tool Window
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.modelingDocData">
            <summary>
            DocData
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.selectionService">
            <summary>
            Selection
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.elementVisitor">
            <summary>
            Element Visitor
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.elementVisitorFilter">
            <summary>
            Element Visitor Filter
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.rootElements">
            <summary>
            Root Elements
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.getModelElementDisplayNameEventHandler">
            <summary>
            Call back function for the generated designer to supply the display name shown in the ModelExplorer
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.hiddenPaths">
            <summary>
            Records the hidden path if there's any
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.imageList">
            <summary>
            Records the imagelist used in the treeview 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.typeList">
            <summary>
            records the corresponding mapping index for all the domian class info user specified.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.showDomainClassList">
            <summary>
            records the corresponding mapping index to determine whetehr we need to show the DomainClass in the tree node (e.g. "foo (Foo)" as 
            the node name
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.addModelElementMenuCommand">
            <summary>
            Track the add menu command we created initially.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.#ctor(System.IServiceProvider)">
            <summary>
            Constructor
            </summary>
            <param name="serviceProvider">Service</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ClearTreeView">
            <summary>
            Clear Tree
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.RefreshBrowserView">
            <summary>
            Refresh
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.TreeViewLostFocus(System.Object,System.EventArgs)">
            <summary>
            Control loses focus
            </summary>
            <param name="obj"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.TreeViewOnMouseDown(System.Object,System.Windows.Forms.MouseEventArgs)">
            <summary>
            Set selection on a right-click.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.TreeViewBeforeCollapse(System.Object,System.Windows.Forms.TreeViewCancelEventArgs)">
            <summary>
            Prevent root node from being collapsed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.TreeViewAfterSelectEvent(System.Object,System.Windows.Forms.TreeViewEventArgs)">
            <summary>
            After Select
            </summary>
            <param name="sender">Sender</param>
            <param name="e">Event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.InsertTreeNode(System.Windows.Forms.TreeNodeCollection,Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode)">
            <summary>
            Method to insert the incoming node into the TreeNodeCollection. This allows the derived class to change the sorting behavior
            </summary>
            <param name="siblingNodes"></param>
            <param name="node"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.TreeNodeTextChanged(Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode)">
            <summary>
            Virtual method to indicate ModelElementTreeNode TreeNode text has been changed.
            </summary>
            <param name="node"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.OnGotFocus(System.EventArgs)">
            <summary>
            Got Focus
            </summary>
            <param name="e">Event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.WndProc(System.Windows.Forms.Message@)">
            <summary>
            Process window messages.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ShowContextMenu(System.Int32,System.Int32)">
            <summary>
            Helper method to show a context menu at the given coordinates.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.UnsubscribeToImsEvent(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Unsubscribe IMS events
            </summary>
            <param name="oldStore">Store</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.SubscribeToImsEvent(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Subscribe IMS events
            </summary>
            <param name="newStore">Store</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ElementEventsEndedEventHandlerImpl(System.Object,Microsoft.VisualStudio.Modeling.ElementEventsEndedEventArgs)">
            <summary>
            Event Handler
            </summary>
            <param name="sender">Sender</param>
            <param name="e">Event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddCommandHandlers(System.ComponentModel.Design.IMenuCommandService)">
            <summary>
            Adds command handlers for commands that appear in the context menu.  Base implementation
            will only add command handlers if a handler is not already registered, to allow derived
            classes to override handling of a particular command.  For this reason, derived classes
            should add commands first before calling the base class.
            </summary>
            <param name="menuCommandService">IMenuCommandService to which commands should be added.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ProcessOnStatusDeleteCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the Delete menu status handler. 
            </summary>
            <param name="cmd">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ProcessOnMenuDeleteCommand">
            <summary>
            Virtual method to process the menu Delete operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ProcessOnStatusDeleteAllCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the DeleteAll menu status handler. 
            </summary>
            <param name="cmd">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ProcessOnMenuDeleteAllCommand">
            <summary>
             Virtual method to process the menu DeleteAll operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ProcessOnStatusPropertiesCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the Properties menu status handler. 
            </summary>
            <param name="cmd">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ProcessOnMenuPropertiesCommand">
            <summary>
             Virtual method to process the menu Properties operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.OnStatusDelete(System.Object,System.EventArgs)">
            <summary>
            Eventhandler for handling when the Delete menu is about to be invoked from Visual Studio
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.OnMenuDelete(System.Object,System.EventArgs)">
            <summary>
            Eventhandler for handling when the Delete menu is selected from Visual Studio
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.OnStatusDeleteAll(System.Object,System.EventArgs)">
            <summary>
             Eventhandler for handling when the Delete All menu is about to be invoked from Visual Studio
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.OnMenuDeleteAll(System.Object,System.EventArgs)">
            <summary>
            Eventhandler for handling when the DeleteAll menu is selected from Visual Studio
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.OnStatusProperties(System.Object,System.EventArgs)">
            <summary>
            Eventhandler for handling when the Properties menu is about to be invoked from Visual Studio
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.OnMenuProperties(System.Object,System.EventArgs)">
            <summary>
            Eventhandler for handling when the Properities menu is selected from Visual Studio
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.CreateElementVisitor">
            <summary>
            Create IElementVisitor
            </summary>
            <returns>IElementVisitor</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.CreateElementVisitorFilter">
            <summary>
            Create IElementVisitorFilter
            </summary>
            <returns>IElementVisitorFilter</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddRootElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Add Root Element
            </summary>
            <param name="rootElement">Root</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddHiddenPath(System.Collections.Generic.ICollection{System.Guid})">
            <summary>
            Retrns the current collection of Paths (in Guid form) for elements to be hidden from the model explorer.
            </summary>
            <param name="path">A list of guids which indicate a hidden path which we'd like to hide from the model explorer</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.RemoveRootElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Remove Root Element
            </summary>
            <param name="rootElement">Root</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.FindRootElements(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Finds all orphaned nodes in a store
            </summary>
            <param name="store">Store</param>
            <returns>List of orphaned ModelElement objects</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.FindNodeForElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Finds the tree node in the model explorer corresponding to the given ModelElement.
            If the element does not have a corresponding node in the tree, this method returns null.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.CanHostStore(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData)">
            <summary>
            Determine whether the passed in candidate doc data can be hosted under the container.
            </summary>
            <param name="candidate"></param>
            <returns></returns>
            <remarks>
            Each language has its own Language-specific model explorer tool window. We can't blindly push modelingDocData 
            into the model explorer.
            Each tool window will now have an abstract RootDomainClassId which describes what root element (i.e. language) it can support.
            We can just check the incoming modelingDocData's root element. Only push the new modelingDocData if the tool window
            supports the model.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.CreateModelElementTreeNode(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Extension point for supplying user defined TreeNode.
            </summary>
            <param name="modelElement">model element to be represented by the to be created ModelElementTreeNode in the tree view</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.CreateRoleGroupTreeNode(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Extension point for supplying user defined TreeNode which represents role multiplicity 0..* or 1..*
            </summary>
            <param name="targetRoleInfo">DomainRoleInfo to be represented by the to be created RoleGroupTreeNode in the tree view</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.CreateRoleTreeNode(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Extension point for supplying user defined TreeNode which represents role multiplicity 1 or 0..1
            </summary>
            <param name="targetRoleInfo">DomainRoleInfo to be represented by the to be created RoleTreeNode in the tree view</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddExplorerNodeCustomSetting(System.Guid,System.Drawing.Image,System.Boolean)">
            <summary>
            Method allows the user to associate image with the domainClass object. This allows the user 
            to customize the image used for each type of modelelement.
            </summary>
            <param name="domainClassId">domainclass where the image is assoiciated.</param>
            <param name="treeNodeImage">Image to be used</param>
            <param name="showDomainClassName">to show className rigth next to the model element name.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.GetExplorerNodeCustomSettings(Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Int32@,System.Boolean@)">
            <summary>
            Helper method to determine the image index to be used.
            </summary>
            <param name="domainClassInfo"></param>
            <param name="imageIndexPos"></param>
            <param name="showDomainClassName">whether to show the domain class name after the model element name</param>
            <returns>index position to the image (defined in the TreeView.ImageList)</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.Dispose(System.Boolean)">
            <summary>
            Disposes the state of this object.
            </summary>
            <param name="disposing">If this method is called from Dispose (true) or Finalizer (false).</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ElementOperations">
            <summary>
            Returns the current diagram 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.SelectedElement">
            <summary>
            Returns the model element currently selected in the explorer window.  Returns null if 
            no model element is selected.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.SelectedRole">
            <summary>
            Returns the role currently selected in the explorer window.  Returns null if 
            no role is selected.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.CurrentParentElement">
            <summary>
            Returns the parent of the model element currently selected in the explorer window.  Returns null if 
            there is no parent.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.VisitRelationships">
            <summary>
            Indicates whether relationships (links) should be included as part of the element traversal.
            The default value is true.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.GetModelElementDisplayNameEventHandler">
            <summary>
            Returns the event handler which allows the derived class to supply tree node display name
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ObjectModelBrowser">
            <summary>
            Selection
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ServiceProvider">
            <summary>
            ServiceProvider
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.SelectionService">
            <summary>
            Selection
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ModelingDocData">
            <summary>
            DocData
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.IsValidDocData">
            <summary>
            Is the DocData valid (do we care about it?)
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ElementVisitor">
            <summary>
            Element Visitor
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ElementVisitorFilter">
            <summary>
            Element Visitor Filter
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.RootElements">
            <summary>
            Root Elements
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.RootElementDomainClassId">
            <summary>
            Returns the root elements domain class Id. The is the very top level tree node in the TreeView
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.ContextMenuCommandId">
            <summary>
            Specifies the context menu that should be shown for the model explorer.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand">
            <summary>
            AddModelElement dynamic item start command.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.ResetValidAddTypes">
            <summary>
            Reset the current valid types. The reason being that for role.IsOne, we can only add one child. Once it's created, 
            there's no reason to show the menu item. We do so by reset this.currentRolePlayer. Doing so would cause the ValidAddTypes to be 
            re-populated next time when user right mouse action the tree node.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.IncludeChildTypeUnderParentElement(Microsoft.VisualStudio.Modeling.ElementOperations,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            method to determine whether we need to allow the childInfo to be a valid menu items under the parentElement. It will first go thru
            the list and see if it's been added beforehand. If not, it will continue to check to see if it can be merged under the parentElement
            via the EGP mechanism
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.ExistInCurrentAssociatedTypes(Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Method to determine if the passed in ChildInfo is already defined in the associatedvalidAddTypes list.
            </summary>
            <param name="childInfo"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.CanMergeChildTypeUnderParentElement(Microsoft.VisualStudio.Modeling.ElementOperations,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            method to determine whether we need to allow the childInfo to be a valid menu items under the parentElement. It will first go thru
            the list and see if it's been added beforehand. If not, it will continue to check to see if it can be merged under the parentElement
            via the EGP mechanism
            </summary>
            <returns>true if we need to inclue it under the parent.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.CurrentDomainClass">
            <summary>
            Returns the current DomainClass from the ValidAddTypes list.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.CurrentEmbeddingDomainRole">
            <summary>
            Returns the current embedding DomainRole from the ValidAddTypes list.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.ChildElementCreationInfo">
            <summary>
            private class for staging the *can be* created child element. It includes both the child domain class info and the opposite
            embedding role 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.ChildElementCreationInfo.ChildDomainClassInfo">
            <summary>
            returns the to be created child domain class info
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelExplorerTreeContainer.AddModelElementMenuCommand.ChildElementCreationInfo.EmbeddingRoleInfo">
            <summary>
            Returns the embedding role info
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker">
            <summary>
            Implement our own walker for we want to support hidden path
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter)">
            <summary>
            Constructor that takes an ElementVisitor.
            This defaults to depth first traversal, pre-Order visitation of the graph with no element links.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter,System.Boolean)">
            <summary>
            Constructor that takes an ElementVisitor.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
            <param name="includeLinks">request element links be included in the visitation</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker.RecordElementWithHiddenChildren(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo)">
            <summary>
            For the given sourceElement and the domain relationshpinfo. This method records that all the links (of type domainRelationshipInfo)
            under the sourceEleemnt will be hidden.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker.IsElementChildrenNotTraversedBasedOnHiddenPath(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo)">
            <summary>
            For the given element, this method will take a look at the internal list and determine it's children is not being traversed due to 
            hidden path user passes in.
            </summary>
            <param name="element"></param>
            <param name="relationshipInfo"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker.BeginTraverseElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Virtual method indicates the walker is about to traverse into the given element
            </summary>
            <param name="element">Element is about to be traversed.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker.EndTraverseElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Virtual method indicates the walker is done with traversing into the given element
            </summary>
            <param name="element">Element which is just been traversed.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerWalker.CurrentTraverseHistory">
            <summary>
            Returns the current travseral history at any given point. The beginning of the list is the starting top root element.
            The end of the list contains the very last element (or link) visited.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerFilter">
            <summary>
            DslModelExplorerFilter is the filer which decides what relationship we should not visit
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerFilter.ShouldVisitRelationship(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Called to ask the filter if a particular relationship from a source element is marked
            Aggregate and should be included in the traversal
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
            <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
            <param name="targetRelationship">Relationship in question</param>
            <returns>true if the relationship should be traversed</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerFilter.HideElementBasedOnHiddenPath(System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo)">
            <summary>
            method to determine whether we need to skip visiting this relationshp based on the original given paths. For the detail mechanism.
            refer to comment in the code
            </summary>
            <returns>true if we want to skip this relationship</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DslModelExplorerFilter.ResolvePathGuidsToDomainClassInfo(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            private helper method to resolve all the domainClass/relationship GUid into DomainClassInfo object. The purpose is for per.
            so we don't hit the meta data directory a lot!!
            </summary>
            <param name="store"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages">
            <summary>
            Provides access to the image list used by the VS Class View, Object Browser, and intellisense
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.AccessTypeCount">
            <summary>
            Number of each glyph based on access type
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.ConstantIndex">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.EnumMemberIndex">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.EventIndex">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.FieldIndex">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.MethodIndex">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.PropertyIndex">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.ErrorIndex">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.PublicModifier">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.InternalModifier">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.FriendModifier">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.ProtectedModifier">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.PrivateModifier">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ClassViewImages.GetImageList(System.IServiceProvider)">
            <summary>
            Provides access to the image list used by the VS Class View, Object Browser, and intellisense.
            </summary>
            <param name="serviceProvider">Used to retrieve the image list via IVsShell.GetProperty</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.MarginsD">
            <summary>
            The class keeps the margin values as double to preserve the accuracy. 
            The build-in Margins class stores margins in integers in 1/100 inches, 
            which is sufficient when using inches in the page setup dialog. However, 
            in if "millimeter" is used, i.e., in the culture where metric units are adopted, 
            since the margins are stored internally 1/100 inches, the conversion from 
            millimeters to inches will lose one-digit of accuracy. For example, a user enters
            1.00 for the left margin and save the setterings; next time he/she opens the dialog 
            and will see "0.99" as the left margin. By storing a float-point version of margins 
            can solve this tiny but annoying problem. 
            Internally, this class does not contain any units information. It is is users' responsiblity
            to preseve the consistency.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MarginsD.#ctor">
            <summary>
            Default constructor. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MarginsD.#ctor(System.Double,System.Double,System.Double,System.Double)">
            <summary>
            Constructor, taking values from parameter list. 
            </summary>
            <param name="left">Left margin value</param>
            <param name="right">Right margin value</param>
            <param name="top">Top margin value</param>
            <param name="bottom">Bottom margin value</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MarginsD.Clone">
            <summary>
            Creates of copy of the object.
            </summary>
            <returns>A copy of the object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MarginsD.ToMargins">
            <summary>
            Converts inch margins to device margins.
            </summary>
            <returns>Margins in device units.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.MarginsD.Left">
            <summary>
            Gets or sets the left margin.
            </summary>
            <value>Left margin</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.MarginsD.Right">
            <summary>
            Gets or sets the right margin.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.MarginsD.Top">
            <summary>
            Gets or sets the top margin.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.MarginsD.Bottom">
            <summary>
            Gets or sets the bottom margin.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.MarginsD.Default">
            <summary>
            Gets default value of margins for our designers.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings">
            <summary>
            This class extends the System.Drawing.Printing.PageSettings to include the additional data needed for the 
            custom page setup dialog. It also provides some additional helper methods to handle persisting margin 
            accuracy and computing minimum margins.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.marginsInDouble">
            <summary>
            The margins stores in float-point values, in inches. It is used to replace the build-in the Margins class,
            which stores margins in integers in 1/100 inches therefore does not preserve ncessary accuracy. However, 
            the build-in Marings in the PageSettings object is indeed needed by other methods in PageSettings class. 
            Therefore, the method DesignerPageSettings.PersistMargins() are called whenever necessary.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.horizontalPagesFitTo">
            <summary>
            The number of pages on which the diagram will be printed, in the horizontal direction.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.verticalPagesFitTo">
            <summary>
            The number of pages on which the diagram will be printed, in the vertical direction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.#ctor(System.Drawing.Printing.PrinterSettings)">
            <summary>
            Constructor. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.#ctor">
            <summary>
            Constructor.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.MarginsD">
            <summary>
            Gets margins (of type double, in inches).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.PrintableBounds">
            <summary>
            Gets the printable bounds, considering the current page orientation and margin settings, in 1/100 inches.
            This property is VERY EXPENSIVE and it can't be cached! Call once and reuse the value!
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.HorizontalPagesFitTo">
            <summary>
            The number of pages in the horizontal direction on which the diagram will be printed.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings.VerticalPagesFitTo">
            <summary>
            The number of pages in the vertical direction on which the diagram will be printed.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog">
            <summary>
            This class enables users to enter (or select) page settings data from a dialog.
            The page settings are stored in a DesignerPageSettings object.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.#ctor(Microsoft.VisualStudio.Modeling.Shell.DiagramDocView,Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings)">
            <summary>
            Constructor.
            </summary>
            <param name="diagramDocView">Diagram.</param>
            <param name="pageSettings">Initial page settings.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.WndProc(System.Windows.Forms.Message@)">
            <summary>
            Process window messages for the dialog.  not to show F1 help requests in 
            the Help System if the active Control is some child control. In the case,
            a pop up window will be shown to the user by HelpProvider
            If both display, a RPC_E_CANTCALLOUT_ININPUTSYNCCALL will be thrown from 
            DisplayTopicFromF1Keyword.
            </summary>
            <param name="m"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.InitializeComponent">
            <summary>
            Required method for Designer support - do not modify
            the contents of this method with the code editor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.ShowWaitCursor">
            <summary>
            Displays wait cursor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.GetValidMargin(System.Windows.Forms.TextBox,System.Double)">
            <summary>
            Gets valid margin value from the given margin text box.
            </summary>
            <param name="marginTextBox">One of the margin text-boxes.</param>
            <param name="minMagin">Low bound for the returned margin value.</param>
            <returns>Max of value from the text box and minMargin.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.ValidateMargin(System.Windows.Forms.TextBox,System.Double)">
            <summary>
            Validates margin text box value and fixes it if required.
            </summary>
            <param name="marginTextBox">One of the margin text-boxes.</param>
            <param name="minMargin">Low bound for the value contained in the text box.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.MarginToString(System.Double)">
            <summary>
            Converts margin specified in inches to a string representing a margin value in
            current culture unites (inches or metric).
            </summary>
            <param name="margin">Margin value in inches.</param>
            <returns>String representation of the margin.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.DisplayErrorMessage(System.String,System.Windows.Forms.TextBox)">
            <summary>
            Displays error message. If the second parameter "TextBox textBox" is not null, this method
            will set focus and highlight on that textbox.
            </summary>
            <param name="errorMessage">Error message</param>
            <param name="textBox">Control to set focus or null.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.F1Keyword">
            <summary>
            Gets F1 help keyword for this dialog.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.PageSettings">
            <summary>
            Gets page settings corresponding to user choices in the dialog.
            The value of this property is valid only after ShowDialog has returned DialogResult.OK.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.MinMargins">
            <summary>
            Gets minimal page margins corresponding to the paper size, source and layout
            choices on the dialog. Note, that this might be slow in times.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DesignerPageSetupDialog.ComboBoxItem`1">
            <summary>
            A helper class to populate combo boxes with strongly typed named objects.
            </summary>
            <typeparam name="T">Type of combo box items.</typeparam>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument">
            <summary>
            This class implements printing the diagram. 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.horizontalPages">
            <summary>
            The number of pages (in the horizontal direction) needed to print the diagram.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.verticalPages">
            <summary>
            The number of pages (in the vertical direction) needed to print the diagram, starting from 0.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.currentHorizontalPage">
            <summary>
            The current page number (in the horizontal direction) in printing, starting from 0.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.currentVerticalPage">
            <summary>
            The current page number (in the vertical direction) in printing.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.horizontalViewLocations">
            <summary>
            A ViewLocation is the top-left corner on the diagram page to be printed. 
            A diagram is devided into one or more pages each of which is printed seperately. 
            The array horizontalViewLocations store the x-coordinates of all the ViewLocations, in world units (inches)
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.verticalViewLocations">
            <summary>
            The y-coordinates of the viewlocations, in world units.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.zoomFactor">
            <summary>
            The zoom factor.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.pageSettings">
            <summary>
            The page settings.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.diagram">
            <summary>
            The diagram to be printed.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.printableBounds">
            <summary>
            The rectangle that defines the printable bounds within a page, in device units (1/100 inches).
            The origin (0,0) is not the top-left corner of the physical page, but the top-left corner of the 
            maximumally printable rectangles within the physical page. 
            Its size is the the same as what a user has specified through margin settings in the PageSetup dialog.
            The margins entered in the page setup dialog are checked to make sure they are at least as large as 
            the minimum margins allowed by the current page setttings and printer settings.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.pageReset">
            <summary>
            The flag that indiciates if a new printableBounds rectangle needs to be computed. 
            For example, the printableBounds is recomputed at the begining of the printing and whenever 
            the page settings are changed on the fly during printing. 
            This flag is used to avoid unnecessary computation cost. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.#ctor">
            <summary>
            Constructor.
            Adds the Event handlers.
            These event handling methods are executed after PrintDocument.Print() is called, 
            in the order of OnBeginPrint->OnQueryPageSettings->OnPrintPage->OnEndPrint.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.OnBeginPrint(System.Drawing.Printing.PrintEventArgs)">
            <summary>
            Handles the event which occurs when PrintDocument.Print() starts executing but before OnPrintPage() is call.
            It calculates the zoom factor, viewlocations, as well as the number of pages required for printing the diagram.
            </summary>
            <param name="e">Event arguments</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.OnPrintPage(System.Drawing.Printing.PrintPageEventArgs)">
            <summary>
            Handles the event when printing each page is ongoing.
            It keeps track of the current progress in printing and provides the updated view locations to 
            the underlying printing method.
            This method is executed recursively. The recursion terminates when all pages are printed.
            </summary>
            <param name="e">Event arguments</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.OnEndPrint(System.Drawing.Printing.PrintEventArgs)">
            <summary>
            Handlers the event which occurs when printing is finished but prior to the returning from the call to PrintDocument.Print().
            It resets some parameters.
            </summary>
            <param name="e">Event arguments</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.OnQueryPageSettings(System.Drawing.Printing.QueryPageSettingsEventArgs)">
            <summary>
            This event handling method is executed after OnBeginPrint() but before OnPrintPage().
            It ensures that the current page setting that is recognized by printer is updated.
            </summary>
            <param name="e">Event arguments</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.CalculatePages(System.Double,System.Double,System.Single,System.Double,System.Double,System.Double,System.Double,System.Int32@,System.Int32@)">
            <summary>
            Calculates the number of pages required, given the diagram size, page size, zooming scale, and ovelapping.
            This is a static method.
            </summary>
            <param name="diagramWidth">The width of the diagram, in inches</param>
            <param name="diagramHeight">The height of the diagram, in inches</param>
            <param name="zoomFactor">The zoom factor, 1.0f = 100%</param>
            <param name="pageWidth">The width of each page printed, in inches</param>
            <param name="pageHeight">The height of each page printed, in inches </param>
            <param name="horizontalOverlap">The overlap in the horizontal direction, in inches</param>
            <param name="verticalOverlap">The overlap in the veritical direction, in inches</param>
            <param name="horizontalPages">The computed horizontal pages required, output parameter</param>
            <param name="verticalPages">The computed vertical pages requrred, output parameter</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.CalculatePages(System.Single,Microsoft.VisualStudio.Modeling.Diagrams.Diagram,Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings,System.Int32@,System.Int32@)">
            <summary>
            Calculates the number of pages required, given a zoom factor, diagram, and pageSettings.
            This is a static method.
            </summary>
            <param name="zoomFactor">The zoom factor, 1.0f = 100%</param>
            <param name="diagram">The diagram to be printed</param>
            <param name="pageSettings">The pageSettings used for printing the diagram</param>
            <param name="horizontalPages">The computed horizontal pages required, output parameter </param>
            <param name="verticalPages">The computed vertical pages requried, output parameter</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.CalculateSkippedPages(System.Single,Microsoft.VisualStudio.Modeling.Diagrams.Diagram,Microsoft.VisualStudio.Modeling.Shell.DesignerPageSettings,System.Int32,System.Int32,System.Int32@,System.Int32@,System.Int32@,System.Int32@)">
            <summary>
            Calculate the number of rows of pages to skip printing on the top and bottom
            of the diagram, and the number of colums to skip on the left and right of
            the diagram. We skip a row/column if it is blank and is not used for spacing. I.e, if the 
            row/column is skipped if it is blank, and it is not between two rows/colums that are not
            blank
            </summary>
            <param name="zoomFactor">The zoom factor used to print the diagram</param>
            <param name="diagram">The diagram we are printing</param>
            <param name="pageSettings">the page settings we are using to print</param>
            <param name="horizontalPages">The number of horizontal pages we are going to print (before subtracting the skipped pages)</param>
            <param name="verticalPages">The number of vertical pages we are going to print (before subtracting the skipped pages)</param>
            <param name="topRowsSkipped">The number of rows to skip on top</param>
            <param name="bottomRowsSkipped">The number of rows to skip on the bottom</param>
            <param name="leftColsSkipped">The number of columns to skip on the left</param>
            <param name="rightColsSkipped">The number of columns to skip on the right</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.CalculateZoomFactor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Int32,System.Int32,System.Single@,System.Int32@,System.Int32@)">
            <summary>
            Calcualate the zoom factor, given the number of pages fitted to each direction, diagram size, page size, and overlapping.
            It also re-calcuates the number of pages required for printing based on the zoom factor computed. 
            This is a static method.
            </summary>
            <param name="diagramWidth">The width of the diagram, in inches</param>
            <param name="diagramHeight">The height of the diagram, in inches</param>
            <param name="pageWidth">The width of each page printed, in inches</param>
            <param name="pageHeight">The height of each page printed, in inches</param>
            <param name="horizontalOverlap">The overlap in the horizontal direction, in inches</param>
            <param name="verticalOverlap">The overlap in the vertical direction, in inches</param>
            <param name="horizontalPagesFitTo">The number of pages fitted to the horizontal direction</param>
            <param name="verticalPagesFitTo">The number of pages fitted to the vertical direction</param>
            <param name="zoomFactor">The zoom factor, output parameter</param>
            <param name="horizontalPages">The number of pages required in the horizontal direction, output parameter</param>
            <param name="verticalPages">The number of pages required in the vertical direction, output parameter</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.CalculateViewLocations(System.Double,System.Double,System.Double,System.Double,Microsoft.VisualStudio.Modeling.Diagrams.PointD,System.Int32,System.Int32)">
            <summary>
            Calcuates the arrays of view locations in both directions. 
            </summary>
            <param name="pageWidth">The width of the page printed</param>
            <param name="pageHeight">The height of the page printed</param>
            <param name="horizontalOverlap">The overlap in the horizontal direction</param>
            <param name="verticalOverlap">The overlap in the vertical direction</param>
            <param name="origin">The origin of the diagram, normally (0,0)</param>
            <param name="topRowsSkipped">The number of rows on top to skip</param>
            <param name="leftColsSkipped">The number of columns on the left to skip</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.Diagram">
            <summary>
            Gets or Sets the diagram.
            </summary>
            <value>Diagram</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintDocument.DefaultPageSettings">
            <summary>
            Gets or Sets the pageSettings.
            </summary>
            <value>DesignerPageSettings</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants">
            <summary>
            Defines constants that are used in multiple classes that implement printing.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.InchToMillimeter">
            <summary>
            The factor for converting inches to millimeters. 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.WorldToDeviceImperial">
            <summary>
            The factor for converting word unit (in inch) to device unit (in 1/100 inch). 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.WorldToDeviceMetric">
            <summary>
            The factor for converting word unit (in centimeter) to device unit (in 1/100 inch).
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.DefaultMarginImperial">
            <summary>
            The default margin value in inches, used in Non-Metric culture. This number is determined by the PM.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.DefaultMarginMetric">
            <summary>
            The default margin value in inches, used in Metric culture. This number is determined by the PM. 
            The reason for using 5 is because 0.25 (inches) * 25.4 = 6.35(mm), which is rounded to be 5(mm). 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.MinPrintablePageSizeImperial">
            <summary>
            The mininum printable size (in inches) in both dimensions, use in Non-Metric culture.
            This constant is used for checking if the margin settings are too wide. This number is determined by the
            PM to ensure the overlapping can always be preserved.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.MinPrintablePageSizeMetric">
            <summary>
            The mininum printable size (in inches) in both dimensions, used in Metric culture, determined by the PM.
            0.75(inches) * 25.4 = 19 (mm), which is rounded to be 15 (mm).
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.PrintingOverlapImperial">
            <summary>
            The amount (in inches) of overlapping when printing multiple pages, used in Non-Metric culture.
            This number is determined by the PM. 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.PrintingOverlapMetric">
            <summary>
            The amount (in inches) of overlapping when printing multiple pages, used in Metric culture, determined by PM.
            0.25 (inches) * 25.4 = 6.35 (mm) and is rounded to be 5 (mm).
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.MaxZoomFactor">
            <summary>
            Maximum zoom factor. 10.0f = 1000%. This number is determined by the PM.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.ConvertFactortFromInchesToCurrentUnit">
            <summary>
            The factor usef for converting inches to the current unit, which could be either inches or millimeters.
            </summary>
            <value>25.4 if current local is metric, 1.00 otherwise</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.DefaultMargin">
            <summary>
            Gets the default settings for margins, in inches.
            </summary>
            <value>Default margin value</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.MinPrintablePageSize">
            <summary>
            Gets the value for minimum printable size, in device unit (1/100 inches).
            </summary>
            <value>Minimum printable size</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.PrintingConstants.PrintingOverlap">
            <summary>
            Gets the amount of overlap for printing.
            </summary>
            <value>Printing overlap</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintManager">
            <summary>
            This class integrates dialog classes (DesignerPrintDialog and DesignerPageSetupDialog) from where users enter 
            (or select) settings, and the DesignerPrintDocument class that handles printing based on the diagram to be printed 
            and the settings for pages and printers. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintManager.ShowPrintDialog(Microsoft.VisualStudio.Modeling.Shell.DiagramDocView)">
            <summary>
            Displays Print dialog.
            </summary>
            <param name="docView">Current DiagramDocView, from which the current diagram can be accessed </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintManager.ShowPageSetupDialog(Microsoft.VisualStudio.Modeling.Shell.DiagramDocView)">
            <summary>
            Displays Page Setup dialog.
            </summary>
            <param name="docView">Current DiagramDocView, from which the current diagram can be accessed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintManager.GetOrCreatePageSettings">
            <summary>
            Creates page settings for a given diagram.
            </summary>
            <returns>Initialized page settings instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintManager.CreatePrintDocument(Microsoft.VisualStudio.Modeling.Shell.DiagramDocView)">
            <summary>
            Creates a print document for the given diagram.
            </summary>
            <param name="diagramDocView">Diagram to create document for.</param>
            <returns>Created print document.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DesignerPrintManager.ShowWaitCursor(System.IServiceProvider)">
            <summary>
            Displays wait cursor.
            </summary>
            <param name="serviceProvider">Service provider.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView">
            <summary>
            DocView designed to contain one or more Diagram PresentationElement.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView">
            <summary>
            Base class for document windows
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.docData">
            <summary>
            document this is a view of.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.filterAttributes">
            <summary>
            cached collection of toolbox item filters
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.windowClosed">
            <summary>
            State flag set to mark this window as closed.  We do not expose objects via ISelectionContainer if this flag
            is set, to avoid handing out disposed objects to the property browser.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.#ctor(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData,System.IServiceProvider)">
            <summary>
            Create a new view, given a DocData.
            </summary>
            <param name="docData">Document this is a view of.</param>
            <param name="serviceProvider">serviceProvider used to get shell services.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.Initialize">
            <summary>
            Overriden to publish context bag.  For editors, general context should be associated with the SEID
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.OnCreate">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.Dispose(System.Boolean)">
            <summary>
            Called by the shell when our tool window is closed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.OnUndoManagerChanged(System.Object,Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionEventArgs)">
            <summary>
            We use this to push our undo manager to the shell.  This allows the
            property browser to use it as well.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.PublishUndoManager">
            <summary>
            Inform the environment of the availability of the associated document's undo manager so so that other 
            windows such as the Properties window can add undo actions to the document's undo stack, and so that 
            the documents undo stack is available in such windows.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.Microsoft#VisualStudio#Shell#Interop#IVsStatusbarUser#SetInfo">
            <summary>
            Called by the shell when it's time for us to set info on the status bar.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.SetInfo">
            <summary>
            Override to set status bar info.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.IsSupported(Microsoft.VisualStudio.OLE.Interop.IDataObject)">
            <summary>
            Implementation of IVsToolboxUser interface.  Determines if we support the referenced data object.
            </summary>
            <param name="data">Object from the toolbox.</param>
            <returns>Returns S_OK if we support this item, E_FAIL if we don't.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.IsDataObjectSupported(System.Windows.Forms.IDataObject)">
            <summary>
            
            </summary>
            <param name="data"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.ItemPicked(Microsoft.VisualStudio.OLE.Interop.IDataObject)">
            <summary>
            Implementation of IVsToolboxUser interface.  Sends notification that an item in the toolbox is selected through a left-click, or by pressing Enter.
            </summary>
            <param name="data">Object that has been selected.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.OnToolboxItemSelected(System.Windows.Forms.IDataObject)">
            <summary>
            
            </summary>
            <param name="data"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.LoadView">
            <summary>
            Called when the associated DocData is finished loading or reloading.  
            Derived classes should perform any initialization that requires the 
            DocData to be loaded here.
            </summary>
            <returns>true if the document was able to be loaded.  A return value
            of false indicates that the view should be closed.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.BaseLoadView">
            <summary>
            To be called when the associated DocData is finished loading or reloading,
            primarily from DocView.LoadView(). Performs any basic initialization 
            required after loading a new DocData into the view.
            </summary>
            <returns>true if the document was able to be loaded.  A return value
            of false indicates that the view should be closed.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.ProvideViewHelper">
            <summary>
            Should we attempt to install ourselves as a ViewHelper?
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.IsPrimaryView">
            <summary>
            True if this is the primary view of the designer. The "primary view" owns the artifact document locks that are created 
            by the VSHost during sync'ing. If an artifact is opened in an incompatible editor (e.g. the binary editor), the primary
            view is closed. This should shut down all other views.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.HasSelectableObjects">
            <summary>
            Overridden here to return false when the docview window is closed.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.ToolboxItemSelected">
            <summary>
            
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.DefaultToolboxTabName">
            <summary>
            String indicating the toolbox tab name that should be selected when this view gets focus.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.DefaultToolboxTabToolboxItemsCount">
            <summary>
            Returns the toolbox items count in the default tool box tab.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.DocData">
            <summary>
            Gets the document this view corresponds to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.ToolboxService">
            <summary>
            Provides access to the toolbox service
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocView.TargetToolboxItemFilterAttributes">
            <summary>
            Returns a collection of filter attributes for this DocView.  These attributes are used
            to determine items that are enabled/disabled in the toolbox.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.selectionFilters">
            <summary>
            Selection Filters
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.diagramFilters">
            <summary>
            Diagram Filters
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.toolboxFilters">
            <summary>
            Toolbox Filters
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.toolboxSelectionHelper">
            <summary>
            Toolbox selection helper.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.printManager">
            <summary>
            DesignerPrintManager handle's all the printing work
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.#ctor(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData,System.IServiceProvider)">
            <summary>
            Constructor.
            </summary>
            <param name="docData">DocData</param>
            <param name="serviceProvider">Service Provider</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.Dispose(System.Boolean)">
            <summary>
            Called when our window is closed.
            </summary>
            <param name="disposing">Disposing</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.CommitPendingEditForCommand(System.ComponentModel.Design.CommandID)">
            <summary>
            Gives derived classes a chance to commit outstanding edits before a 
            command is executed.  This is called frequently, so only lightweight
            processing should be done here.  This is preferable to
            IVsWindowPaneCommit.CommitPendingEdit, because it allows derived classes
            to make the decision to commit for some commands but not others. 
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.UpdateToolboxFilters(Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxItemFilterType,System.Boolean)">
            <summary>
            Call to indicate that toolbox filter collections are invalid and need to be refreshed.  Note that this does not actually refresh the toolbox.  Clients may choose to do that based on the return value.
            </summary>
            <param name="filterToUpdate">Indicates which filter collection(s) need to be updated.</param>
            <param name="calculateChanges">Indicates whether the method should calculate whether there have been changes to the collection (otherwise, it assemues there have been).  This is expensive when dealing with large collections.</param>
            <returns>True if the toolbox filter collection changed as a result of the update.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.OnSelectionChanged(System.EventArgs)">
            <summary>
            Overriden to recalculate toolbox item filters
            </summary>
            <param name="e">Args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxOnToolboxItemSelected(System.Object,System.Windows.Forms.DragEventArgs)">
            <summary>
            Called on selection of a ToolboxItem. (A selection is a double-click, or pressing Enter).
            </summary>
            <param name="sender">The object that generated this event.</param>
            <param name="e">The DragEventArgs wrapping the Toolbox Item selected.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetProperty(System.UInt32,System.Object@)">
            <summary>
            Return the object that was requested.  Our implementation only supports VSFTPROPID_DocName.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetSearchImage(System.UInt32,Microsoft.VisualStudio.TextManager.Interop.IVsTextSpanSet[],Microsoft.VisualStudio.TextManager.Interop.IVsTextImage@)">
            <summary>
            Not implemented.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetFindState(System.Object@)">
            <summary>
            Not implemented.
            </summary>
            <returns>The object that is being asked</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.Find(System.String,System.UInt32,System.Int32,Microsoft.VisualStudio.TextManager.Interop.IVsFindHelper,System.UInt32@)">
            <summary>
            Not implemented.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.NavigateTo(Microsoft.VisualStudio.TextManager.Interop.TextSpan[])">
            <summary>
            Not implemented.
            </summary>
            <param name="pts">Location where to move the cursor to</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetCurrentSpan(Microsoft.VisualStudio.TextManager.Interop.TextSpan[])">
            <summary>
            Get current cursor location
            </summary>
            <param name="pts">Current location</param>
            <returns>Hresult</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.MarkSpan(Microsoft.VisualStudio.TextManager.Interop.TextSpan[])">
            <summary>
            Not implemented.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.Replace(System.String,System.String,System.UInt32,System.Int32,Microsoft.VisualStudio.TextManager.Interop.IVsFindHelper,System.Int32@)">
            <summary>
            Not implemented.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.SetFindState(System.Object)">
            <summary>
            Not implemented.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.NotifyFindTarget(System.UInt32)">
            <summary>
            Unused.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetCapabilities(System.Boolean[],System.UInt32[])">
            <summary>
            Specify which search option we support.
            </summary>
            <param name="pfImage">Do we support IVsTextImage?</param>
            <param name="pgrfOptions">Supported options</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.CountAllObjects">
            <summary>
            ISelectionContainer.CountObjects (All).
            </summary>
            <returns>Count of All Objects.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetAllObjects(System.UInt32,System.Object[])">
            <summary>
            ISelectionContainer.GetObjects (Selected).
            </summary>
            <param name="count">Count of Objects to get.</param>
            <param name="objects">Array of Objects to return.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.DoSelectObjects(System.UInt32,System.Object[],System.UInt32)">
            <summary>
            ISelectionContainer.SelectObjects.
            </summary>
            <param name="count">Count of Objects to select.</param>
            <param name="objects">Array of Objects to select.</param>
            <param name="flags">Flags.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.IsObjectBrowsable(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Test to see if the Browsable attribute is not set to false on the shape
            </summary>
            <remarks>
            Items are not presented or counted in the "All" selection group if they're not browsable.
            </remarks>
            <param name="shape"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.CountShapes(Microsoft.VisualStudio.Modeling.Diagrams.ShapeElement)">
            <summary>
            Private Helper.
            </summary>
            <param name="parentShapeElement">Current Parent.</param>
            <returns>Count of Shapes under and including Parent.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GrabObjects(Microsoft.VisualStudio.Modeling.Diagrams.ShapeElement,System.UInt32,System.UInt32,System.Object[])">
            <summary>
            Private Helper.
            </summary>
            <param name="parentShapeElement">Current Parent.</param>
            <param name="index">Array Index.</param>
            <param name="count">Array Length.</param>
            <param name="objects">Array.</param>
            <returns>Index, -1 for failure.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.CreateDiagramView">
            <summary>
            Creates a new VSDiagramView with default settings.
            </summary>
            <returns>DiagramView</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.DesignerZoomChanged(System.Object,Microsoft.VisualStudio.Modeling.Diagrams.DiagramEventArgs)">
            <summary>
            Event Handler
            </summary>
            <param name="sender">Sender</param>
            <param name="e">Args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.DesignerMouseUpEvent(System.Object,Microsoft.VisualStudio.Modeling.Diagrams.DiagramPointEventArgs)">
            <summary>
            Event Handler
            </summary>
            <param name="sender">Sender</param>
            <param name="mouseArgs">Location</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.OnContextMenuRequested(Microsoft.VisualStudio.Modeling.Diagrams.DiagramPointEventArgs)">
            <summary>
            Processes context menu requested event from the client view.
            By default shows context menu returned from ContextMenuId property.
            </summary>
            <param name="mouseArgs">Mouse event arguments relative to that diagram view.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ShowContextMenu(System.ComponentModel.Design.CommandID,System.Drawing.Point)">
            <summary>
            Shows context menu at specified point on the screen.
            </summary>
            <param name="contextMenuId">Context menu to show.</param>
            <param name="pt">Point on the screen.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.CompareFilterCollections(System.Collections.ICollection,System.Collections.ICollection)">
            <summary>
            Compares two collections of toolbox item filters.
            </summary>
            <param name="oldFilters">Old Filters</param>
            <param name="newFilters">New Filters</param>
            <returns>True if Filters differ, false otherwise</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetDiagramFromPhysicalView(System.Guid)">
            <summary>
            Retrieves the diagram corresponding to our physical view from the store.
            </summary>
            <param name="diagramDomainClassId">Meta Class Id for the diagram to be retrieved.</param>
            <returns>Diagram</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.GetToolboxItemFilterAttributes">
            <summary>
            Returns an array of ToolboxFilterItemAttributes for 
            creating toolbox items that will be available when this doc view is active
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ContextMenuId">
            <summary>
            Context menu that should be displayed when the design surface is right-clicked on
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.TargetToolboxItemFilterAttributes">
            <summary>
            Override to add in filter attributes on the current diagram.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.CurrentDiagram">
            <summary>
            Current Diagram
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.CurrentDesigner">
            <summary>
            Current Designer
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.IsContextMenuShowing">
            <summary>
            Gets a value indicating whether the context menu is showing.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ContextMenuMousePosition">
            <summary>
            Gets the mouse position in absolute world coordinates when the context menu was invoked.
            This is valid when IsContextMenuShowing returns true.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.DesignerPrintManager">
            <summary>
            Handles print settings for this doc view.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxItemFilterType">
            <summary>
            Enumeration used to indicate a particular toolbox filter collection.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxItemFilterType.None">
            <summary>
            No value.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxItemFilterType.Selection">
            <summary>
            Filters associated with the current selection
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxItemFilterType.Diagram">
            <summary>
            Filters associated with the current diagram
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxItemFilterType.All">
            <summary>
            All filter types
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper">
            <summary>
            Helper class that manages what happens when the user selects a toolbox item.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.ignoreSelectionChangedEvent">
            <summary>
            Flag indicating if we should ignore shape selection changed events.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.repeatDrop">
            <summary>
            Flag indicating whether we should repeat the double-click action 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.repeatDropTargetSelection">
            <summary>
            When we're repeating a select action, this cached target should be used.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.repeatDropToolboxItem">
            <summary>
            When we're repeating a select action, this cached toolbox item should be dropped.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.toolboxService">
            <summary>
            A reference to the IToolboxService.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.#ctor(System.IServiceProvider)">
            <summary>
            Creates the ToolboxSelectionHelper.
            </summary>
            <param name="serviceProvider">A service provider.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.ShapeSelectionChanged(System.Object,System.EventArgs)">
            <summary>
            When the user changes the selection, reset our repeat-drop flag.
            </summary>
            <param name="sender">The event sender.</param>
            <param name="e">The event args.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.ItemSelected(Microsoft.VisualStudio.Modeling.Diagrams.DiagramClientView,System.Windows.Forms.DragEventArgs)">
            <summary>
            Drops a toolbox item onto the design surface.  If this is the first time the item
            has been dropped onto the design surface, we drop it onto the currently selected shape
            (or one of its parent shape, if necessary).  Otherwise, if this is a repeat-action,
            we drop the toolbox item onto the cached parent shape.
            </summary>
            <param name="diagramClientView">The client view to drop onto.</param>
            <param name="e">The drag event args to use in the drop.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramDocView.ToolboxSelectionHelper.FindTarget(Microsoft.VisualStudio.Modeling.Diagrams.ShapeElement,Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem)">
            <summary>
            Finds a shape to drop onto.  Queries ShapeElement.ShouldTryParentShapeMergeOnToolboxDoubleClick
            to see if we should walk up the parent chain to find a drop target.
            </summary>
            <param name="currentTarget">The shape to start search from.</param>
            <param name="selectedToolboxItem">The toolbox item we're trying to drop.</param>
            <returns>The ShapeElement that we should drop on, or null if no ShapeElement was found.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView">
            <summary>
            Class that hosts a single diagram within a view
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.diagram">
            <summary>
            Single diagram displayed within this view
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.diagramView">
            <summary>
            View to host the single diagram maintained by this class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.#ctor(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData,System.IServiceProvider)">
            <summary>
            Constructs a SingleDiagramDocView
            </summary>
            <param name="docData">DocData</param>
            <param name="serviceProvider">Service Provider</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.Dispose(System.Boolean)">
            <summary>
            
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.UserPreferenceChanged(System.Object,Microsoft.Win32.UserPreferenceChangedEventArgs)">
            <summary>
            Event Handler
            </summary>
            <param name="sender">Sender</param>
            <param name="e">Args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.DesignerGotFocus(System.Object,System.EventArgs)">
            <summary>
            Pass focus on to the DiagramClientView
            </summary>
            <param name="sender">Sender</param>
            <param name="e">Args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.SetFonts">
            <summary>
            Set Fonts
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.Window">
            <summary>
            Called by the ShellWindow during IVsWindowPane::CreatePaneWindow.  Returns the single
            DesignSurface control hosted by this view
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.CurrentDesigner">
            <summary>
            Current Designer
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.CurrentDiagram">
            <summary>
            Current Diagram
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SingleDiagramDocView.Diagram">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter">
            <summary>
            An exporter capable of finding diagram files in a solution, and exporting them to disk as images.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.#ctor(System.IServiceProvider)">
            <summary>
            Initializes a new instance of the DiagramExporter clss.
            </summary>
            <param name="serviceProvider">Service provider containing VS shell and UI services.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.ExportDiagram(System.String,System.String,System.Drawing.Imaging.ImageFormat,System.Boolean)">
            <summary>
            Export a single diagram.
            </summary>
            <param name="diagramFileName">The name of the diagram file.</param>
            <param name="exportPath">The path to export the image to.</param>
            <param name="imageFormat">The format of the image to create.</param>
            <param name="overwriteExistingFiles">Indicates whether use wants to overwrite files if they exist in disk.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.ExportDiagrams(System.Collections.Generic.IList{System.String},System.String,System.Boolean)">
            <summary>
            Export diagrams as images.
            </summary>
            <param name="diagramFiles">List of diagram files to export.</param>
            <param name="exportPath">The path to export the images to.</param>
            <param name="overwriteExistingFiles">Indicates whether use wants to overwrite files if they exist in disk.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.ExportDiagrams(System.Collections.Generic.IList{System.String},System.String,System.Drawing.Imaging.ImageFormat,System.Boolean)">
            <summary>
            Export diagrams as images.
            </summary>
            <param name="diagramFiles">List of diagram files to export.</param>
            <param name="exportPath">The path to export the images to.</param>
            <param name="format">The format of the exported images.</param>
            <param name="overwriteExistingFiles">Indicates whether use wants to overwrite files if they exist in disk.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.ImageFormatExtension(System.Drawing.Imaging.ImageFormat)">
            <summary>
            Get a file extension for supported image formats.
            </summary>
            <param name="format">The image format we need an extension for.</param>
            <returns>A file extension corresponding to the provided image format.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.CreateImageForItem(System.String,System.Drawing.Imaging.ImageFormat,System.String)">
            <summary>
            Create a bitmap or metafile representation for a diagram in a project. This will open the document in the background
            if not already already opened, extract the image, and close the view if opened by this method.
            </summary>
            <param name="path">The path of the diagram document to obtain a bitmap representation for.</param>
            <param name="imageFormat">The type of image to create.</param>
            <param name="destinationFileName">
            The full path for the destination file. Only the ImageFormat.Emf and ImageFormat.Wmf 
            use this parameter. This parameter can be null for all other formats.
            </param>
            <returns>Bitmap or Metafile representation of the diagram document</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.GetDocDataFromRdt(System.String)">
            <summary>
            Obtains a pointer to the DocData for an item in the running document table.
            </summary>
            <param name="fileName">Filename of the document that's in the RDT</param>
            <returns>A pointer to the DocData for a project item, null if the document could not be found in the RDT.</returns>
            <remarks>Caller needs to release the returned pointer.</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.OpenDocument(System.String)">
            <summary>
            Opens a document in the background.
            </summary>
            <param name="path">The path of the project item to open.</param>
            <returns>The WindowFrame of the opened project item.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.OnExportErrorEvent(System.Int32,System.String,System.Exception)">
            <summary>
            Fire ExportErrorEvent.
            </summary>
            <param name="itemCount">The number of diagrams exported thus far.</param>
            <param name="projectItem">The name of the current item being exported.</param>
            <param name="e">The exception thrown, if any.</param>
            <returns>True if the users want to continue exporting diagrams, false otherwise.</returns>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.ExportErrorEvent">
            <summary>
            Occurs when an error was encountered while exporting a diagram.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.DiagramExporter.ExportQueryUserActionEvent">
            <summary>
            Occurs when a response is required from the user.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ExportUserAction">
            <summary>
            public enum represent what type of response is required from the user action.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ExportUserAction.FileAlreadyExist">
            <summary>
            Indicates that the file is already exist
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.UserActionEventArgs">
            <summary>
            Event args for passing the information back to the user.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UserActionEventArgs.#ctor(System.String,Microsoft.VisualStudio.Modeling.Shell.ExportUserAction)">
            <summary>
            ctor to create an event args for notifying the user.
            </summary>
            <param name="fileName">file name which requires the user action</param>
            <param name="cause">The cause of the problem</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.UserActionEventArgs.Continue">
            <summary>
            Get/Sets the continue flag.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.UserActionEventArgs.Cause">
            <summary>
            Returns the cause which requires users attention.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.UserActionEventArgs.FileName">
            <summary>
            File name which is having problem.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs">
            <summary>
            Arguments related to an ExportErrorEvent.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs.#ctor(System.Int32,System.String)">
            <summary>
            Initialize an ExportErrorEventArgs instance.
            </summary>
            <param name="exportedDiagramsCount">The number of items already exported in the current operation.</param>
            <param name="projectItem">The file name of the current item being exported.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs.#ctor(System.Int32,System.String,System.Exception)">
            <summary>
            Initialize an ExportErrorEventArgs instance.
            </summary>
            <param name="exportedDiagramsCount">The number of items already exported in the current operation.</param>
            <param name="projectFile">The file name of the current item being exported.</param>
            <param name="exception">The exception related to the current error, if any.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs.Exception">
            <summary>
            The exception encountered while exporting the current item.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs.ProjectFile">
            <summary>
            The file name of the current item being exported.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs.ErrorMessage">
            <summary>
            The error message corresponding to this export error.
            </summary>
            <remarks>Derived from the exception's Message field, if an exception was provided.</remarks>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs.Continue">
            <summary>
            Whether to continue. Event handlers can set Continue to false if they do not
            wish to continue the export operation.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ExportErrorEventArgs.ExportedDiagramsCount">
            <summary>
            The number of diagrams exported thus far.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.IncludeResults">
            <summary>
            Enumeration returned from the IncludeInResultsCallback to specify whether current
            item should be included in the list, and whether search should continue.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.IncludeResults.Exclude">
            <summary>
            Default value, excludes this node from the search results.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.IncludeResults.Include">
            <summary>
            Includes this node in the search results.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.IncludeResults.StopCurrentHierarchySearch">
            <summary>
            halts search of the current hierarchy.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.IncludeResults.StopSearch">
            <summary>
            halts search of the any further hierarchies after the current one.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.IncludeResults.StopDescendingHierarchy">
            <summary>
            halts search of child hierarchies.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.IncludeInResultsCallback">
            <summary>
            Represents the method that will decide if a file should be included in the search results.
            </summary>
            <param name="fileName">The name of the project file.</param>
            <param name="itemId">ItemID of the project file</param>
            <param name="hierarchy">IVsHierarchy of the project file</param>
            <returns>True if the file should be included in the search results, false otherwise.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ShellUtility">
            <summary>
            Utility methods for searching solutions and the RDT.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.VirtualFolderItemType">
            <summary>
            Solution Folder Project Type Guid.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.IsVirtualFolder(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy)">
            <summary>
            Is Virtual Folder.
            </summary>
            <param name="vsHierarchy">IVsHierarchy.</param>
            <returns>True if the IVsHierarchy is a virtual folder, false otherwise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindFilesInSolution(System.String,System.IServiceProvider,System.Boolean)">
            <summary>
            Find files of a given extension in the current solution.
            </summary>
            <param name="fileExtension">The extension of files to search for.</param>
            <param name="serviceProvider">ServiceProvider containing the SVsSolution service.</param>
            <param name="includeInvisibleNodes">True to include invisible nodes, false otherwise.</param>
            <returns>A list of files in the current solution matching the given file extension.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindFilesInSolution(System.Collections.Generic.IList{System.String},System.IServiceProvider,System.Boolean)">
            <summary>
            Find files of a given extension in the current solution.
            </summary>
            <param name="fileExtensions">The extensions of files to search for.</param>
            <param name="serviceProvider">ServiceProvider containing the SVsSolution service.</param>
            <param name="includeInvisibleNodes">True to include invisible nodes, false otherwise.</param>
            <returns>A list of files in the current solution matching the given file extensions.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindFilesInSolution(Microsoft.VisualStudio.Modeling.Shell.IncludeInResultsCallback,System.IServiceProvider,System.Boolean)">
            <summary>
            Find files of a given extension in the current solution.
            </summary>
            <param name="callback">A method that can determine whether a given file should be included in the result set.</param>
            <param name="serviceProvider">ServiceProvider containing the SVsSolution service.</param>
            <param name="includeInvisibleNodes">True to include invisible nodes, false otherwise.</param>
            <returns>A list of files in the current solution that matched according to the given callback method.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindFilesInSolutionHelper(Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer,System.IServiceProvider,System.Boolean)">
            <summary>
            Helper workhorse method; searches through the current VS solution and builds a result set based
            on the given project file comparer.
            </summary>
            <param name="comparer">Comparer used to determine whether a project file should be included in the result set.</param>
            <param name="serviceProvider">ServiceProvider containing the SVsSolution service.</param>
            <param name="includeInvisibleNodes">True to include invisible nodes, false otherwise.</param>
            <returns>A set of files found within the current solution matched according to the given comparer.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindProjectFiles(System.Collections.Generic.IList{Microsoft.VisualStudio.Shell.Interop.IVsHierarchy},Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer,System.Boolean)">
            <summary>
            Find files in a VsHierarchy, searching recursively.
            </summary>
            <param name="projects">List of projects to search through.</param>
            <param name="comparer">Comparer used to determine whether a project file should be included in the result set.</param>
            <param name="includeInvisibleNodes">True to include invisible nodes, false otherwise.</param>
            <returns>A list of files in the projects matched according to the given comparer.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.WalkVSHierarchy(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32,Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer,System.Boolean,System.Boolean,Microsoft.VisualStudio.Modeling.Shell.IncludeResults@)">
            <summary>
            Recursively walk the VS hierarchy, building a result set matched by the given comparer.
            </summary>
            <param name="hier">The IVsHierarchy to walk through.</param>
            <param name="root">The VSITEMID root of the hierarchy.</param>
            <param name="comparer">Comparer used to determine whether a project file should be included in the result set.</param>
            <param name="includeInvisibleNodes">True to include invisible nodes, false otherwise.</param>
            <param name="checkRoot">True to check root, false otherwise.</param>
            <param name="result">Indicates whether search should continue past this hierarhcy.</param>
            <returns>A list of files in the hierarchy matched according to the given hierarchy.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindProjectsInSolution(Microsoft.VisualStudio.Shell.Interop.IVsSolution)">
            <summary>
            Find the list of projects in the current solution.
            </summary>
            <returns>A list of projects hierarchies from the current solution.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindOpenedFiles(System.String,System.IServiceProvider)">
            <summary>
            Finds opened files in the solution that end in the given file extension.
            </summary>
            <param name="fileExtension">The file extension of files to find</param>
            <param name="serviceProvider">ServiceProvider providing the IVsRunningDocumentTable service.</param>
            <returns>List of opened files that end in the given file extension.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindOpenedFiles(System.Collections.Generic.IList{System.String},System.IServiceProvider)">
            <summary>
            Finds opened files in the solution that end in one of the given file extensions
            </summary>
            <param name="fileExtensions">The file extensions of files to find</param>
            <param name="serviceProvider">ServiceProvider providing the IVsRunningDocumentTable service.</param>
            <returns>List of opened files that end in the given file extensions.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindOpenedFiles(Microsoft.VisualStudio.Modeling.Shell.IncludeInResultsCallback,System.IServiceProvider)">
            <summary>
            Finds opened files in the solution that match according to the given callback.
            </summary>
            <param name="callback">A method that can determine whether a given file should be included in the result set.</param>
            <param name="serviceProvider">ServiceProvider providing the IVsRunningDocumentTable service.</param>
            <returns>List of opened files that match according to the given callback.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.FindOpenedFilesHelper(Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer,System.IServiceProvider)">
            <summary>
            Helper workhorse method; searches through the current VS solution and builds a result set based
            on the given project file comparer.
            </summary>
            <param name="comparer">Comparer used to determine whether a project file should be included in the result set.</param>
            <param name="serviceProvider">ServiceProvider providing the IVsRunningDocumentTable service.</param>
            <returns>List of opened files that match accordinging to the given comparer.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.GetAvailableTypeFullNames(Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>
            For the given rootElement, this method returns types (in short name form) in the current project where the DocData of this rootElement resides.
            </summary>
            <param name="rootElement">RootElement associdate with the ModelingDocData</param>
            <param name="includeTypesInReferenceAssemblies">Indicates whether to include types in the referenced assemblies of the project</param>
            <returns>A dictionary where key is name and value is System.Type</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer">
            <summary>
            A comparison object, capable of determing whether a given file should be
            included in the search result set.
            </summary>
            <remarks>
            There is more than one way
            to compare whether a project file should be compared in the result set,
            namely, if it matches a given file extension or if a callback determines
            that it should be included in the result set. This structure encapsulates
            the specific method of comparison, abstracting it away from the code using the
            results of the comparison.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer.#ctor(System.Collections.Generic.IList{System.String})">
            <summary>
            Construct a comparer that compares based on a list of file extensions.
            </summary>
            <param name="fileExtensions">List of file extensions to compare a filename against.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer.#ctor(Microsoft.VisualStudio.Modeling.Shell.IncludeInResultsCallback)">
            <summary>
            Construct a comparer that compares based on the result of a callback.
            </summary>
            <param name="callback">IncludeInResultsCallback that can determine whether a file should be included in the result set.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ShellUtility.ProjectFileComparer.IncludeInResults(System.String,System.UInt32,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy)">
            <summary>
            Decide whether the given file should be included in the search result set.
            </summary>
            <param name="filename">Fully qualified name of the project file.</param>
            <param name="itemID">ItemID of the project file.</param>
            <param name="hierarchy">VSHierarchy of the project file.</param>
            <returns>Value indicating whether current item should be included in the search, and whether or not search should continue.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction">
            <summary>
            Class that handles opening and closing of a VS Globally linked transaction through the
            IVsLinkedUndoTransactionManager class.  Also manages an IMS transaction
            within this linked transaction
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.transaction">
            <summary>
            IMS transaction we're wrapping
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.linkedUndoManager">
            <summary>
            reference to the shell's linked undo manager
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.#ctor(System.String,System.IServiceProvider,Microsoft.VisualStudio.Modeling.Shell.ModelingDocData)">
            <summary>
            Create a transaction that can potentially span multiple designers.  First opens
            a linked undo transaction, then opens an IMS transaction.
            </summary>
            <param name="description">description which appears in the undo/redo drop-down menus</param>
            <param name="serviceProvider">service provider used to get IVsLinkedUndoTransactionManager</param>
            <param name="docData">DocData initiating the linked transaction.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.#ctor(System.String,System.IServiceProvider)">
            <summary>
            Create a transaction that can potentially span multiple designers.  First opens
            a linked undo transaction, then opens an IMS transaction. This version uses the currently
            opened document.
            </summary>
            <param name="description">description which appears in the undo/redo drop-down menus</param>
            <param name="serviceProvider">service provider used to get IVsLinkedUndoTransactionManager</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.InitializeAndCreateLinkedTransaction(System.String,Microsoft.VisualStudio.Modeling.Shell.ModelingDocData,System.IServiceProvider)">
            <summary>
            Create a transaction that can potentially span multiple designers.  First opens
            a linked undo transaction, then opens an IMS transaction.
            </summary>
            <param name="description">description which appears in the undo/redo drop-down menus</param>
            <param name="docData">ModelingDocData which is initiating the transaction</param>
            <param name="serviceProvider">service provider used to get IVsLinkedUndoTransactionManager</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.Commit">
            <summary>
            Commit the transaction.  First commits the IMS transaction, then the linked undo transaction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.Rollback">
            <summary>
            Roll back the transaction.  First rolls back the IMS transaction, then aborts 
            linked undo transaction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.Dispose">
            <summary>
            implement IDisposable.Dispose()
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.Finalize">
            <summary>
            Finalizer.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.Dispose(System.Boolean)">
            <summary>
            Private implementation of Dispose as per pattern
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.GlobalUndoContext">
            <summary>
            A value put into a transaction's context to indicate that it is a global undo.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.IsActive">
            <summary>
            True iff the wrapped IMS transaction is active
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.HasPendingChanges">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.LinkedTransaction.Transaction">
            <summary>
            Returns the IMS transaction we're wrapping
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.CommandContextBoundMenuCommand">
            <summary>
            Represents a menu command bound to a particular UI context.  This command will only be visible
            if the given command UI context is active.  These commands should be used in conjunction with
            entries in the VISIBILITY_SECTION of the CTC file.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandContextBoundMenuCommand.#ctor(System.IServiceProvider,System.EventHandler,System.ComponentModel.Design.CommandID,System.Guid[])">
            <summary>
            Construct a new CommandContextBoundMenuCommand
            </summary>
            <param name="serviceProvider">Service provider used to get shell services.  Necessary to access IMonitorSelectionService.</param>
            <param name="handler">Handler to execute the command.</param>
            <param name="commandContext">Guid(s) indicating the command context this command is tied to.</param>
            <param name="id">Command id that identifies this menu command.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData">
            <summary>
            Abstract base class representing a file in memory that is backed by an IMS store.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.primaryStore">
            <summary>
            The store for this document.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.errorListProvider">
            <summary>
            A ModelingErrorListProvider object that allows this ModelingDocData to report error/warning messages
            to VS Error List window.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.cachedCurrentModel">
            <summary>
            A cached model in string format. Cached this so we can supply the same model in IVsTextBufferProvider.GetTextBuffer. This cache will be cleared
            when IMS event ended occurred.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.#ctor(System.IServiceProvider,System.Guid)">
            <summary>
            Constructor.
            </summary>
            <param name="serviceProvider">ServiceProvider used to retrieve shell services.</param>
            <param name="editorId">Guid of the editor factory that created the DocData.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.Dispose(System.Boolean)">
            <summary>
            Cleans up resources allocated by the doc data. Allows us to pre-empt the GC.
            </summary>
            <param name="disposing">Disposing.</param>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.inLoad">
            <summary>
            InReload.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.inReload">
            <summary>
            IsReload.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.LoadDocData(System.String,System.Boolean)">
            <summary>
            Loads the document data from a given file name.
            </summary>
            <param name="fileName">Filename from which to load the document data.</param>
            <param name="isReload">True if the DocData is reloading.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.OnHierarchyChanged(System.EventArgs)">
            <summary>
            When Hierarchy changes, notify the associated ErrorListProvider.
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.OnDocumentClosed(System.EventArgs)">
            <summary>
            When document closed, clear the error list content.
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.FlushUndoManager">
            <summary>
            Flushes the Modeling undo manager, in addition to the base behavior.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.OpenView(System.Guid,System.Object)">
            <summary>
            Called to open a particular view on this DocData.
            </summary>
            <param name="viewContext">Object that gives further context about the view to open.  The editor factory that
            supports the given logical view must be able to interpret this object.</param>
            <param name="logicalView">Guid that specifies the view to open.  Must match the value specified in the
            registry for the editor that supports this view.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.Initialize">
            <summary>
            Initialize.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.Initialize(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Initialize.
            </summary>
            <param name="sharedStore">Primary Store.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.CleanupStores">
            <summary>
            Cleanup method, called when the DocData must be reloaded.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.ConnectExistingStore(Microsoft.VisualStudio.Modeling.Store,Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore@)">
            <summary>
            Connect the ModelingDocData to the existing Store.
            </summary>
            <param name="existingStore">The existing Store that this object should connect to.</param>
            <param name="docStore">The ModelingDocStore structure where this should be store.  This must be set before CreateStore completes so that callback functions can retrieve the correct store.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.CreateStore">
            <summary>
            Create a Store object for a given key.
            </summary>
            <returns>Store.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.CreateModelingDocStore(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Creates a ModelingDocStore object for the given store.  Derived classes
            may override to customize per-store behaviors.
            </summary>
            <param name="store"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.CreateStore(Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore@)">
            <summary>
            Constructs the ModelingDocData's Store and loads its meta-models into it.
            </summary>
            <param name="docStore">The DocStore structure where this should be store.  This must be set before CreateStore completes so that callback functions can retrieve the correct store.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.GetDomainModels">
            <summary>
            Derived classes can override this to return a collection of the SubStores types that they request loaded into the store.  This list doesnt contain SubStores that providers request loaded into the Store.
            </summary>
            <returns>Type[].</returns>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.rootElement">
            <summary>
            The Root Element.  Can be null.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.SetRootElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Set Root Element.
            </summary>
            <param name="rootElement">Root Element.  Can be null.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.RemoveModelingEventHandlers">
            <summary>
            Removes all Modeling event handlers from the store.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.AddPostLoadModelingEventHandlers">
            <summary>
            Adds Modeling event handlers to the store.  This adds handlers which don't need to repsond to events during a file load.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.OnStoreUndoStackFlushed(System.Object,System.EventArgs)">
            <summary>
            Event handler for processing the store undo manager flush event. We will discard the undo stacks 
            maintained by the VS.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.OnElementEventsEnded(System.Object,Microsoft.VisualStudio.Modeling.ElementEventsEndedEventArgs)">
            <summary>
            Ensure the dirty flag for this document is updated if necessary
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.SupportsLogicalView(System.Guid)">
            <summary>
            override to specify which types of views are supported by 
            this doc data.
            </summary>
            <param name="logicalView"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.AddErrorListItem(Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListItem)">
            <summary>
            Add an error/warning for this doc data, which will be displayed into the VS Error/List window.
            </summary>
            <param name="task">Task to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.ShowErrorListItems">
            <summary>
            Show all error/warning messages in VS Error List window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.HideErrorListItems">
            <summary>
            Hide all error/warning messages in VS Error List window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.ClearErrorListItems">
            <summary>
            Clear all error/warning messages
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.SuspendErrorListRefresh">
            <summary>
            Prevents the error list from updating synchronously each time an item is added for this doc data.
            Calling SuspendErrorListRefresh before adding a large number of items to the error list results in better performance.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.ResumeErrorListRefresh">
            <summary>
            Resumes error list refresh each time an item is added for this doc data.
            Should be called after SuspendErrorListRefresh, usually right after the last item of a batch has been added.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.GetTextBuffer(Microsoft.VisualStudio.TextManager.Interop.IVsTextLines@)">
            <summary>
            Loads the text into the buffer. This method will allocate a VSTextManagerInterop::IVsTextLines will be created 
            and loaded with the model
            </summary>
            <param name="ppTextBuffer">newly created buffer loaded with the model file (in XML string form)</param>
            <returns>VSConstants.S_OK if operation successful</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.LockTextBuffer(System.Int32)">
            <summary>
            LockTextBuffer; Currently, there's no code implemented for this method
            </summary>
            <param name="fLock"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.SetTextBuffer(Microsoft.VisualStudio.TextManager.Interop.IVsTextLines)">
            <summary>
            SetTextBuffer; Currently, there's no code implemented for this method
            </summary>
            <param name="pTextBuffer"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.CreateObject(Microsoft.VisualStudio.Shell.Interop.ILocalRegistry,System.Guid,System.Guid)">
            <summary>
            Creates an object
            </summary>
            <param name="localRegistry">Establishes a locally-registered COM object relative to the local Visual Studio registry hive</param>
            <param name="clsid">GUID if object to be created</param>
            <param name="typeId">GUID assotiated with specified System.Type</param>
            <returns>An object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.SetTextIntoTextBuffer(Microsoft.VisualStudio.TextManager.Interop.IVsTextLines,System.String)">
            <summary>
            This is a helper routine to replace the contents of the Text Buffer with given text.
            This function handles the interop of passing the string as a block of memory via an IntPtr. 
            It uses a CoTaskMemAlloc to allocate a block of memory at a fixed location.
            </summary>
            <remarks>Throws an exception if unmanaged operations fail.</remarks>
            <param name="textLines">The TextBuffer to receive the text.</param>
            <param name="newText">The string value that assigns the TextBuffer.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.InLoad">
            <summary>
            InLoad.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.InReload">
            <summary>
            InReload.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.UndoManager">
            <summary>
            Overriden to retrieve the undo manager associated with the ModelingDocStore.  This
            allows ModelingDocData's that share a primary store to also share an undo manager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.UndoManagerIsShared">
            <summary>
            ModelingDocData provides an undo manager sharing mechanism.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.RootElement">
            <summary>
            The Root Element that identifies the portion of the store owned by this DocData.  Can be null, if the DocData represents the entire store.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.Store">
            <summary>
            Gets the Modeling Store associated with this DocData.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.ModelingDocStore">
            <summary>
            Gets the ModelingDocStore associated with this DocData.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.ErrorListProvider">
            <summary>
            Gets the ErrorListProvider for doc data, which can be used to report error/warning messages to 
            VS Error List window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.HasErrorListItems">
            <summary>
            True if there're items in the error list for this doc data.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocData.SerializedModel">
            <summary>
            Return the model in XML format
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore">
            <summary>
            Class that maintains a 1-1 relationship with the store.  Per-store functionality should 
            go here, as opposed to per-file functionality, which should be
            placed on the ModeingingDocData
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.serviceProvider">
            <summary>
            Service provider used to retrieve shell services.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.context">
            <summary>
            Context.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.store">
            <summary>
            Store.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.undoManager">
            <summary>
            UndoManager maintained by the ModelingDocStore.  
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.docDataList">
            <summary>
            ModelingDocData objects (files) sharing this store.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.ModelingDocStoreKey">
            <summary>
            Key used to index the ModelingDocStore in the store's property bag.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            ModelingDocStore constructor
            </summary>
            <param name="serviceProvider">Interface for retrieving a service object</param>
            <param name="store">Store which is referenced by this object. </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.Initialize">
            <summary>
            Called after the store is loaded, to allow derived classes to perform initialization, such
            as adding event handlers, etc., that requires a loaded store.
            </summary>
            TODO : see if we can make ModelingDocData.InitializeStore private in favor of this as a way to
            allow derived classes to do store-specific initialization, this would make the document/store 
            distinction clearer.
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.Dispose">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.Dispose(System.Boolean)">
            <summary>
            
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.ConnectDocData(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData)">
            <summary>
            Create a connection between the DocStore and a DocData.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.RemoveDocData(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData)">
            <summary>
            Remove a connection between the DocStore and a DocData.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.CreateUndoUnit(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Create Undo Unit.
            </summary>
            <param name="undoableTransaction">TransactionItem which represents the transaction to be undone.</param>
            <returns>UndoUnit which wraps the given TransactionItem.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.FlushUndoManager">
            <summary>
            Flush the transactions maintained by the IMS. Once it’s flushed, one will not be able to undo/redo transactions.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.OnElementEventsEnded(System.Object,Microsoft.VisualStudio.Modeling.ElementEventsEndedEventArgs)">
            <summary>
            After all of the element events have fired, we can safely  fire our queued selection changed event.
            </summary>
            <param name="sender">Sender.</param>
            <param name="e">Event Args.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.OnUndoItemAdded(System.Object,Microsoft.VisualStudio.Modeling.UndoItemEventArgs)">
            <summary>
            Update the shells undo stack when an undo item is added in the Store
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.OnUndoItemDiscarded(System.Object,Microsoft.VisualStudio.Modeling.UndoItemEventArgs)">
            <summary>
            Update the shells undo stack when an undo item is discarded from the Store's
            undo stack because it exceeded the maximum allowed length of the undo stack.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.CanUndoRedo(System.Boolean,Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Query whether Undo/Redo can proceed based on external criteria.
            </summary>
            <param name="isUndo">True if Undo, false if Redo.</param>
            <param name="transaction">TransactionItem to Undo/Redo.</param>
            <returns>True to allow Undo/Redo, false to decline.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.CanCommit(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Query whether top-level transaction commit can proceed based on external criteria.
            </summary>
            <param name="transaction">Transaction to commit.</param>
            <returns>True to allow commit, false to decline.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.ModelingDocuments">
            <summary>
            Collection of ModelingDocData objects sharing this ModelingDocStore.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.ShouldDisposeStore">
            <summary>
            By default, the ModelingDocStore disposes of the store when the last editor is finished with it.
            Derived classes that want to control the store lifetime can override this to prevent store disposal.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.ShareCount">
            <summary>
            Flag indicating if the store is shared by multiple DocData objects.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.CanRefreshPropertyBrowser">
            <summary>
            If this returns false, then the property browser will not be automatically refreshed.  This callback is required for transaction commit during delete scenarios.  In this case, the undo unit pulls the before selection from the current window, so it must be correct.  However, the property browser cannot refresh a deleted ModelElement.  This enables derived classes to block the RefreshPropertyBrowser callback.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.Store">
            <summary>
            Store managed by this ModelingDocStore.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.Context">
            <summary>
            Context managed by this ModelingDocStore.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.UndoManager">
            <summary>
            UndoManager maintained by this ModelingDocStore.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocStore.ServiceProvider">
            <summary>
            Service provider, used to retrieve shell services.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory">
            <summary>
            Modeling version of the Editor factory. The editor factory allows the VS shell
            to get an editor for a particular file type.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.serviceProvider">
            <summary>
            used to get shell services
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.cancelEditorCreate">
            <summary>
            Flag to cancel the creation of editor instance.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.flags">
            <summary>
            Provides access to the createFlags passed in calls to CreateEditorInstance.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.errorListProviders">
            <summary>
            The ModelingEditorFactory will manage one ErrorListProvider for each created ModelDocData, which can be used by the doc data
            to report error/warning to VS Error List window. The ErrorListProvider is separated from the ModelDocData, because when a doc
            data fails to create, we still want to report the error, so the TaskList has a longer lifetime than the doc data.
            The ModelingEditorFactory manages these ModelingErrorListProvider objects by creating one for each ModelingDocData, so it needs
            to be keyed by the doc data's identity.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.slnEventsCookie">
            <summary>
            IVsSolutionEvents cookie.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.#ctor(System.IServiceProvider)">
            <summary>
            Public constructor for our editor factory.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.HandleEditorCreationException(System.String,System.Exception)">
            <summary>
            Called to handle exception thrown during CreateEditorInstance (if any)
            </summary>
            <param name="fileName">Name of the file CreateEditorInstance was called for.</param>
            <param name="exception">Exception thrown.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.CreateEditorInstance(System.UInt32,System.String,System.String,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32,System.IntPtr,System.IntPtr@,System.IntPtr@,System.String@,System.Guid@,System.Int32@)">
            <summary>
            Creates a new editor.
            </summary>
            <param name="createFlags">Flags defining how the editor should be created.</param>
            <param name="fileName">Name of the file to be edited.</param>
            <param name="physicalView">Name of the editor view.</param>
            <param name="hierarchy">IVsHierarchy for the project containing the file.</param>
            <param name="itemId">ID of the project node that represents the file.</param>
            <param name="existingDocData">If the file has already been opened in VS this points to the file's data object.</param>
            <param name="docView">A reference to the editor's view object.</param>
            <param name="docData">A reference to the editor's doc object.</param>
            <param name="editorCaption">Caption for the editor.</param>
            <param name="cmdUI">Menu Guid.</param>
            <param name="createDocWinFlags">Flags to be passed to CreateDocumentWindow.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider)">
            <summary>
            Implementation of the IVsEditorFactory interface.
            </summary>
            <param name="site">An IServiceProvider that we can use to find and proffer services.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.Close">
            <summary>
            Implementation of the IVsEditorFactory interface.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.MapLogicalView(System.Guid@,System.String@)">
            <summary>
            Maps a logical view to a physical view.
            This method is called before CreateEditorInstance to allow us to map 
            logical views to physical ones.
            </summary>
            <param name="logicalView">Guid of the logical view to display in the editor.</param>
            <param name="viewName">Name of the view.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.IsDocDataSupported(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData)">
            <summary>
            Derived classes should overload this to return false if they 
            only support certain types of DocData
            </summary>
            <param name="data"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.GetDocData(System.Object)">
            <summary>
            Derived classes should override to get a existing instance of 
            a concrete DocData.
            </summary>
            <param name="existingDocData">Existing DocData.</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.CreateDocData(System.String,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)">
            <summary>
            Derived classes should override to create a new instance of 
            a concrete DocData.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.CreateDocData">
            <summary>
            Derived classes should override to create a new instance of 
            a concrete DocData.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.CreateDocView(Microsoft.VisualStudio.Modeling.Shell.ModelingDocData,System.String,System.String@)">
            <summary>
            Derived classes can override to create a new instance of 
            a DocView of the specified kind.
            </summary>
            <param name="docData">DocData this view is being created for</param>
            <param name="physicalView">String containing extra information particular to this instance of the view</param>
            <param name="editorCaption">text such as [code] that appears next to the file name on the document tab</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.MapLogicalView(System.Guid,System.Object)">
            <summary>
            Called when the shell asks us to map a logical view to a physical one.  Logical
            views correspond to view types, physical views correspond to view instances.  Because we potentially
            want to support multiple physical views of a given logical view open at once, we
            also pass along an object which derived classes can use to differentiate the physical
            views.  For example, in the case of multiple web services being viewed in the Service Designer,
            the logical view (GUID of the Service Designer) would be the same, but the viewContext would
            allow derived classes to distiguish between designer instances and return a different
            physical view (it might be a some IMS element, for example).
            
            Derived classes must handle the case where the viewContext is null.  This will occur when the user
            double-clicks on a file as opposed to drilling down to a different view from one of our editors.
            Most likely they will just return the default physical view, the empty string.  Note that this means there may be only one physical view 
            for the default logical view for a file (this would correspond to the ApplicationDesigner, for example).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnModelingErrorListProviderHierarchyChanged(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32,Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider)">
            <summary>
            Called when the Hierarchy of the ModelingDocData using this error list provider changes.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnAfterCloseSolution(System.Object)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnAfterLoadProject(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnAfterOpenProject(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.Int32)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnAfterOpenSolution(System.Object,System.Int32)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnBeforeCloseProject(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.Int32)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnBeforeCloseSolution(System.Object)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnBeforeUnloadProject(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnQueryCloseProject(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.Int32,System.Int32@)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnQueryCloseSolution(System.Object,System.Int32@)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.OnQueryUnloadProject(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.Int32@)">
            <summary>
            IVsSolutionEvents.OnAfterCloseSolution
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.CancelEditorCreate">
            <summary>
            If set to value greater than 0 during DocData or DocView creation, the create editor operation will be cancelled.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.Flags">
            <summary>
            Provides access to the createFalgs passed in calls to CreateEditorInstance.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory.ServiceProvider">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider">
            <summary>
            ModelingErrorListProvider provides a way for ModelingdocData to report error/warning messages to VS 
            Error List window. 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.serviceProvider">
            <summary>
            IServiceProvider.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.editorFactory">
            <summary>
            Associated editor factory.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.identity">
            <summary>
            Identity of the doc data using this error list provider.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.rdtCookie">
            <summary>
            Cookie for RDT events.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.errorListProvider">
            <summary>
            ErrorListProvider used by this ModelingErrorListProvider instance.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.items">
            <summary>
            Items that will be shown.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.shown">
            <summary>
            Whether the error list items are shown or not.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Shell.ModelingEditorFactory,Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Finalize">
            <summary>
            Destructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Dispose">
            <summary>
            Dispose
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Dispose(System.Boolean)">
            <summary>
            Dispose
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.AddItem(Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListItem)">
            <summary>
            Add a new item to the list.
            </summary>
            <param name="newItem">Item to be added.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.SuspendRefresh">
            <summary>
            Prevents the error list from updating synchronously each time an item is added.
            Calling SuspendRefresh before adding a large number of items to the error list results in better performance.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.ResumeRefresh">
            <summary>
            Resumes error list refresh each time an item is added.
            Should be called after SuspendRefresh, usually right after the last item of a batch has been added.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Clear">
            <summary>
            Clear the items.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.ShowItems">
            <summary>
            Show items in Error List window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.HideItems">
            <summary>
            Removes the items from Error List window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.ShowErrorOnIdle">
            <summary>
            Called when a doc data fails to open. When the doc data fails to open, we want to show the errors to the user; we
            do this by navigating to the first error in the list when we get an idle callback. 
            We need to wait for idle so that the failed LoadDocData() call can complete and return correctly.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.ShowErrorOnIdleCallback(System.Object,System.EventArgs)">
            <summary>
            Called on idle to navigate to the first error in the list.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.OnHierarchyChanged(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)">
            <summary>
            Called when the Hierarchy of the ModelingDocData using this error list provider changes.
            </summary>
            <param name="hier">New IVsHierarchy.</param>
            <param name="itemid">New Itemid</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.ShowDocument(System.IServiceProvider,System.String,System.Guid,System.Guid)">
            <summary>
            Show a document
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Microsoft#VisualStudio#Shell#Interop#IVsRunningDocTableEvents#OnAfterAttributeChange(System.UInt32,System.UInt32)">
            <summary>
            IVsRunningDocTableEvents.OnAfterAttributeChange
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Microsoft#VisualStudio#Shell#Interop#IVsRunningDocTableEvents#OnAfterDocumentWindowHide(System.UInt32,Microsoft.VisualStudio.Shell.Interop.IVsWindowFrame)">
            <summary>
            IVsRunningDocTableEvents.OnAfterDocumentWindowHide
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Microsoft#VisualStudio#Shell#Interop#IVsRunningDocTableEvents#OnAfterFirstDocumentLock(System.UInt32,System.UInt32,System.UInt32,System.UInt32)">
            <summary>
            IVsRunningDocTableEvents.OnAfterFirstDocumentLock
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Microsoft#VisualStudio#Shell#Interop#IVsRunningDocTableEvents#OnAfterSave(System.UInt32)">
            <summary>
            IVsRunningDocTableEvents.OnAfterSave
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Microsoft#VisualStudio#Shell#Interop#IVsRunningDocTableEvents#OnBeforeDocumentWindowShow(System.UInt32,System.Int32,Microsoft.VisualStudio.Shell.Interop.IVsWindowFrame)">
            <summary>
            IVsRunningDocTableEvents.OnBeforeDocumentWindowShow
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Microsoft#VisualStudio#Shell#Interop#IVsRunningDocTableEvents#OnBeforeLastDocumentUnlock(System.UInt32,System.UInt32,System.UInt32,System.UInt32)">
            <summary>
            IVsRunningDocTableEvents.OnBeforeLastDocumentUnlock
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Count">
            <summary>
            Number of items current in the list.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListProvider.Identity">
            <summary>
            Identity of the doc data using this error list provider.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity">
            <summary>
            The ModelingEditorFactory will manage one TaskList for each created ModelDocData, which can be used by the doc data
            to report error/warning to VS Error List window. The TaskList is separated from the ModelDocData, because when a doc
            data fails to create, we still want to report the error, so the TaskList has a longer lifetime than the doc data.
            The ModelingEditorFactory manages that TaskList objects by creating one TaskList for each ModelingDocData, so it needs
            to be keyed by the doc data's identity, which is a tuple of the IVsHierarchy and the ItemId, wrapped into a ModelingDocDataIdentity
            instance defined here.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.hier">
            <summary>
            IVsHierarchy of the project.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.itemid">
            <summary>
            ItemId of the ModelingDocData.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.hashCode">
            <summary>
            Hashcode of this identity.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.#ctor(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)">
            <summary>
            Constructor
            </summary>
            <param name="hier"></param>
            <param name="itemid"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.op_Equality(Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity,Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity)">
            <summary>
            Operator ==
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.op_Inequality(Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity,Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity)">
            <summary>
            Operator != 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.Equals(System.Object)">
            <summary>
            Equals()
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.GetHashCode">
            <summary>
            GetHashCode()
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.InHierarchy(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy)">
            <summary>
            If the represented ModelingDocData is in the given IVsHierarchy.
            </summary>
            <param name="hier">Hierarchy to check.</param>
            <returns>True if the represented ModelingDocData is in the given hierarchy, false otherwise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.IsSameHierarchy(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy)">
            <summary>
            Tells if two hierarchies are the same one.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.Hierarchy">
            <summary>
            The Hierarchy of this identity.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingDocDataIdentity.Itemid">
            <summary>
            The hierarchy Itemid of this identity.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListItem">
            <summary>
            Represents an item that can be handled in ModelingErrorListProvider.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListItem.errorListProvider">
            <summary>
            Container ModelingErrorListProvider.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListItem.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingErrorListItem.ErrorListProvider">
            <summary>
            Container ModelingErrorListProvider.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage">
            <summary>
            Base class for creating packages.  Provides toolbox support and package-level menu support
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.toolWindows">
            <summary>
            table containing all the tool windows for this package, hashed by Guid.  If a tool window hasn't
            been created yet, the table will contain it's type, otherwise it will contain it's instance.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.menuCommandService">
            <summary>
            Need to cache this because we demand-create it for two different interfaces, IMenuCommandService and
            IOleCommandTarget, and we need to ensure the same instance is used in both cases.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.locator">
            <summary>
            Helper to navigate to model element references.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.GetResourceString(System.String)">
            <summary>
            Gets the string of the passed resource Id.
            </summary>
            <param name="resourceId">The resource Id of the resource string to get.</param>
            <returns>The resource string obtained.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.GetResourceString(System.String,System.Object[])">
            <summary>
            Gets a string formatted to the resource string formatter specified.
            </summary>
            <param name="resourceId">The resource Id of the resource string to be used as the formatter.</param>
            <param name="args">The arguments to be used in the formatting.</param>
            <returns>A formatted string.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.#ctor">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.Initialize">
            <summary>
            Derived classes should override this method to do package-specific work such as
            registering editor factories
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.OnCreateService(System.ComponentModel.Design.IServiceContainer,System.Type)">
            <summary>
            Retrieve a service from the shell.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.CreateLocator">
            <summary>
            Factory method to create a ModelElementLocator instance for this package.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.CreateToolboxItems">
            <summary>
            When overriden in a derived class, returns the list of toolbox items provided by this package.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.SetupDynamicToolbox">
            <summary>
            Forces the toolbox to be set up
            </summary>
            <remarks>
            This should not normally be used by a productio designer as its toolbox will be constructed at devenv /setup time.
            However, it can be used at debug time to force the IDE to be reset in a cheaper way than a full reset toolbox.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.OnToolboxInitialized(System.Object,System.EventArgs)">
            <summary>
            Resets the default tools on the toolbox. Fetches the ToolBoxItemInfos from the registered Modeling based editors 
            and registers them with the toolbox. 
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.AddToolboxItems(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem})">
            <summary>
            Add the passed array of ModelingToolboxItem into the Visual Studio toolbox.
            </summary>
            <param name="items">An array of ModelingToolboxItem to be added.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.AddOrReplaceToolboxItem(System.Drawing.Design.IToolboxService,Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem)">
            <summary>
            Add a toolbox item if it is not present.  Will replace an existing toolbox item if the item is already present
            </summary>
            <param name="toolbox">the toolbox service</param>
            <param name="toolboxItem">the new toolbox item</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.SortToolboxItems(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem})">
            <summary>
            Sorts the passed list of ModelingToolboxItem and removes duplicates. 
            </summary>
            <param name="items">The list of ModelingToolboxItem to sort and remove duplicates from.</param>
            <returns>An array of ModelingToolboxItem sorted and without duplicates.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.CreateToolWindow(System.Guid@,System.UInt32)">
            <summary>
            Create the specified tool window.
            </summary>
            <param name="rguidPersistenceSlot"></param>
            <param name="dwToolWindowId"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.AddToolWindow(System.Type)">
            <summary>
            We will provide basic tool window support for now, to see if things work.  This should be done at the
            base Package level, in a similar fashion to proferred services.
            </summary>
            <param name="toolWindowType">ToolWindow-derived type which is proferred by this package.  Tool window instances are demand-created.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.GetToolWindow(System.Type)">
            <summary>
            Returns the tool window instance corresponding to the given type.  We only support
            single-instance tool windows, so this will always be a 1-1 mapping.
            </summary>
            <param name="toolWindowType"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.GetToolWindow(System.Type,System.Boolean)">
            <summary>
            Returns the tool window instance corresponding to the given type.  We only support
            single-instance tool windows, so this will always be a 1-1 mapping.
            </summary>
            <param name="toolWindowType">Type of tool window to retrieve</param>
            <param name="forceCreate">True if tool window should be created if it hasn't been already.</param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.ModelingResManager">
            <summary>
            Gets the resource manager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.Locator">
            <summary>
            Helper for locating model element references.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.SetupMode">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelingPackage.DesignTimeRunMode">
            <summary>
            Is this designer in DesignTimeRun mode?
            </summary>
            <remarks>
            DesignTimeRun mode is how a designer is run when it is launched from the IDE that is designing it.
            It may be running under the debugger or not, but it is expected to work even if full registration hasn't happened.
            </remarks>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.PackageUtility">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.PackageUtility.ShowError(System.IServiceProvider,System.String)">
            <summary>
            Helper method to show an error message within the shell.  This should be used
            instead of MessageBox.Show();
            </summary>
            <param name="serviceProvider">The service provider.</param>
            <param name="errorText">Text to display.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.PackageUtility.ShowError(System.IServiceProvider,System.String,System.String)">
            <summary>
            Helper method to show an error message within the shell.  This should be used
            instead of MessageBox.Show();
            </summary>
            <param name="serviceProvider">The service provider.</param>
            <param name="errorText">Text to display.</param>
            <param name="f1Keyword">F1-keyword.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.PackageUtility.ShowMessageBox(System.IServiceProvider,System.String)">
            <summary>
            Helper method to show a message box within the shell.  Defaults to showing only an OK button.
            </summary>
            <param name="serviceProvider"></param>
            <param name="messageText"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.PackageUtility.ShowMessageBox(System.IServiceProvider,System.String,Microsoft.VisualStudio.Shell.Interop.OLEMSGBUTTON,Microsoft.VisualStudio.Shell.Interop.OLEMSGDEFBUTTON,Microsoft.VisualStudio.Shell.Interop.OLEMSGICON)">
            <summary>
            Helper method to show a message box within the shell.  
            </summary>
            <param name="serviceProvider"></param>
            <param name="messageText">Text to show.</param>
            <param name="messageButtons">Buttons which should appear in the dialog.</param>
            <param name="defaultButton">Default button (invoked when user presses return).</param>
            <param name="messageIcon">Icon (warning, error, informational, etc.) to display</param>
            <returns>result corresponding to the button clicked by the user.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.PackageUtility.ShowMessageBox(System.IServiceProvider,System.String,System.String,Microsoft.VisualStudio.Shell.Interop.OLEMSGBUTTON,Microsoft.VisualStudio.Shell.Interop.OLEMSGDEFBUTTON,Microsoft.VisualStudio.Shell.Interop.OLEMSGICON)">
            <summary>
            Helper method to show a message box within the shell.  
            </summary>
            <param name="serviceProvider"></param>
            <param name="messageText">Text to show.</param>
            <param name="f1Keyword">F1-keyword.</param>
            <param name="messageButtons">Buttons which should appear in the dialog.</param>
            <param name="defaultButton">Default button (invoked when user presses return).</param>
            <param name="messageIcon">Icon (warning, error, informational, etc.) to display</param>
            <returns>result corresponding to the button clicked by the user.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.IVsTshell">
            <summary>
            IVsTshell was removed from the PIAs, so we have to maintain our own version of the interface.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelingSchemaResolver">
            <summary>
            An implementation of ISchemaResolver that resolves schema target namespace to a collection of schemas that define the namespace.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ModelingSchemaResolver.sp">
            <summary>
            ServiceProvider to be used by this resolver.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingSchemaResolver.#ctor(System.IServiceProvider)">
            <summary>
            Constructor
            </summary>
            <param name="sp">IServiceProvider to be used by this resolver.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelingSchemaResolver.ResolveSchema(System.String)">
            <summary>
            This method takes a target namespace string and returns a collection of schema files that define the namespace.
            </summary>
            <param name="targetNamespace">Target namespace to resolve.</param>
            <returns>
            A list of file paths of schemas that define the given target namespace, null or empty list if the given target namespace
            cannot be resolved.
            </returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionEventArgs">
            <summary>
            Arguments for events of MonitorSelectionService.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionEventArgs.#ctor(System.Object,System.Object)">
            <summary>
            Constructor.
            </summary>
            <param name="oldValue">Previous selection value.</param>
            <param name="newValue">New selection value.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionEventArgs.OldValue">
            <summary>
            Previous selection value.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionEventArgs.NewValue">
            <summary>
            New selection value.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.CommandContextChangedEventArgs">
            <summary>
            EventArgs catpturing information about a command context change event.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandContextChangedEventArgs.#ctor(System.UInt32,System.Boolean)">
            <summary>
            Constructor.
            </summary>
            <param name="cookie">Cookie corresponding to command context that is changing.</param>
            <param name="active">True if the command context if being activated, false if the context is being deactivated.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandContextChangedEventArgs.IsActive">
            <summary>
            True if the command context if being activated, false if the context is being deactivated.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandContextChangedEventArgs.Cookie">
            <summary>
            Cookie corresponding to command context that is changing.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService">
            <summary>	
            Monitors current selection state in the shell.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.IsCommandContextActive(System.Guid)">
            <summary>
            Returns true if the given command context is currently active
            </summary>
            <param name="commandContext">command context to test</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.IsCommandContextActive(System.UInt32)">
            <summary>
            Returns true if the command context corresponding to the given cookie is currently active
            </summary>
            <param name="cookie">command context cookie to test</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.GetCommandContextCookie(System.Guid)">
            <summary>
            Returns the cookie for the given context guid.
            </summary>
            <param name="commandContext"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.CurrentDocument">
            <summary>
            Retrieves the DocData object corresponding to the active document.
            Usually, this object will implement at least the IVsPersistDocData2
            interface.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.CurrentDocumentView">
            <summary>
            Retrieves the currently active DocView.  Note that this can be different
            from the CurrentWindow, as the CurrentWindow property also tracks tool
            windows
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.CurrentWindow">
            <summary>
            Retrieves the window pane object associated with the currently
            focused window.  This could be a document or a tool window.
            Usually, this object will implement at least the IVsWindowPane
            interface.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.CurrentWindowFrame">
            <summary>
            Retrieves the window frame associated with the currently focussed window. This will always be an IVsWindowFrame (or null).
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.CurrentSelectionContainer">
            <summary>
            Retrieves the currently active selection container.  Note that this may be different from the
            currently active window, since not all windows are selection containers.  Command handlers which are driven
            off of the current selection should use this property, rather than the current window.  This is
            because the selection container may not be the focused window.  The distinction is particularly
            important in the case of the Command Window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.CurrentUndoManager">
            <summary>
            Retrieves the undo manager associated with the currently focused window.
            </summary>
            <value></value>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.WindowChanged">
            <summary>
            Called when the window frame changes
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.DocumentChanged">
            <summary>
            Called when the document changes
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.DocumentWindowChanged">
            <summary>
            Called when the document window changes
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.UndoManagerChanged">
            <summary>
            Called when the current undo manager changes
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.SelectionChanged">
            <summary>
            Called when selection changes
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Shell.IMonitorSelectionService.CommandContextChanged">
            <summary>
            Called when a command UI context is activated/deactivated.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionService.Microsoft#VisualStudio#Shell#Interop#IVsSelectionEvents#OnSelectionChanged(Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32,Microsoft.VisualStudio.Shell.Interop.IVsMultiItemSelect,Microsoft.VisualStudio.Shell.Interop.ISelectionContainer,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32,Microsoft.VisualStudio.Shell.Interop.IVsMultiItemSelect,Microsoft.VisualStudio.Shell.Interop.ISelectionContainer)">
            <summary>
            Called by the VS shell when selection changes anywhere in the environment.
            Derived classes can override this to if they need notification of all
            selection changes.
            </summary>
            <param name="pHierOld"></param>
            <param name="itemidOld"></param>
            <param name="pMISOld"></param>
            <param name="pSCOld"></param>
            <param name="pHierNew"></param>
            <param name="itemidNew"></param>
            <param name="pMISNew"></param>
            <param name="pSCNew"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionService.Microsoft#VisualStudio#Shell#Interop#IVsSelectionEvents#OnElementValueChanged(System.UInt32,System.Object,System.Object)">
            <summary>
            This is called by the VS shell whenever any element of the SEID (this is 
            basically a selection property bag) changes.
            We use this to listen for frame changes from the shell.  If our frame has
            become active, we notify the selection monitor service.
            </summary>
            <param name="elementid">one of the SEID_* values</param>
            <param name="oldValue">old value</param>
            <param name="newValue">new value</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.MonitorSelectionService.Microsoft#VisualStudio#Shell#Interop#IVsSelectionEvents#OnCmdUIContextChanged(System.UInt32,System.Int32)">
            <summary>
            Called by the shell when a command context is activated or deactivated.  Fires the CommandContextChanged event.
            </summary>
            <param name="cookie"></param>
            <param name="fActive"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.NativeMethods">
            <summary>
            Contains useful constants for interacting with the unmanaged world.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem">
            <summary>
            This class translate a SerializationMessage into a VS Error List window task.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem.serviceProvider">
            <summary>
            ServiceProvider.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem.navigationLogicalView">
            <summary>
            LogicalView used in nagivation.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem.navigationEditorFactoryGuid">
            <summary>
            Editor factory Guid used in nagivation if the item needs to be re-opened.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.SerializationMessage)">
            <summary>
            Constructor, using TextView as the default navigation logical view, and XML editor as navigation editor.
            </summary>
            <param name="serviceProvider">SerivceProvider for this item. If null, the navigate functionalitity won't work.</param>
            <param name="serializationMessage">The SerializationMessage to be translated.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem.#ctor(System.IServiceProvider,System.Guid,System.Guid,Microsoft.VisualStudio.Modeling.SerializationMessage)">
            <summary>
            Constructor
            </summary>
            <param name="serviceProvider">SerivceProvider for this item. If null, the navigate functionalitity won't work.</param>
            <param name="navigationLogicalView">
            If a file contains error, most likely it can't be opened in default editor view, so we need an alternative view to open it, e.g.
            CodeView. This parameter specifies which view should be used when opening the item during navigation (double-click in Error List window).
            The value is the same logical view Guids used in IVsUIShellOpenDocuments methods.
            </param>
            <param name="navigationEditorFactoryId">
            When the specified "navigationLogicalView" is not the view of the already opened editor, the item needs to be closed and reopened. This
            editor factory guid specifies which editor should be used when the file is re-opened.
            </param>
            <param name="serializationMessage">The SerializationMessage to be translated.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem.OnNavigate(System.EventArgs)">
            <summary>
            Called when user double-click the message in Error List window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.SerializationErrorListItem.ErrorListProvider">
            <summary>
            ModelingErrorListProvider of this item.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ShellStrings">
            <summary>
              A strongly-typed resource class, for looking up localized strings, etc.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ResourceManager">
            <summary>
              Returns the cached ResourceManager instance used by this class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.Culture">
            <summary>
              Overrides the current thread's CurrentUICulture property for all
              resource lookups using this strongly typed resource class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.AddCompartmentItemMenu">
            <summary>
              Looks up a localized string similar to Add new {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.AddDiagram">
            <summary>
              Looks up a localized string similar to Create View.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.AddedMessage">
             <summary>
               Looks up a localized string similar to Added: {0}
            .
             </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.AdditionalEditorExtensionAttributeLogRegistered">
            <summary>
              Looks up a localized string similar to Additional Editor Extension: &apos;{0}&apos;: &apos;{1}&apos; priority {2}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.AdditionalEditorExtensionAttributeLogUnregistered">
            <summary>
              Looks up a localized string similar to Additional Editor Extension: &apos;{0}&apos;: &apos;{1}&apos; priority {2}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.AllSynchronizations">
            <summary>
              Looks up a localized string similar to All Synchronizations.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.BeginConstraintValidationOutput">
             <summary>
               Looks up a localized string similar to ------ Validation started: Model elements validated: {0} ------
                
            .
             </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.BitmapError">
            <summary>
              Looks up a localized string similar to Invalid prototype image.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CaptionError">
            <summary>
              Looks up a localized string similar to Caption cannot contain white space..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CdPrototypeDefaultBitmapFilename">
            <summary>
              Looks up a localized string similar to WebServicePort.bmp.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CdPrototypeString">
            <summary>
              Looks up a localized string similar to Class Designer Prototypes.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CheckoutFailed">
            <summary>
              Looks up a localized string similar to The checkout has failed or been cancelled.\n\nAny subsequent edits made to the file must be saved to a different file using the Save As command..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CollapseMenuText">
            <summary>
              Looks up a localized string similar to &amp;Collapse.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CommonFileSuffix">
            <summary>
              Looks up a localized string similar to prototype.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CompleteDiagramTemplate">
            <summary>
              Looks up a localized string similar to {0} [Complete].
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ConstraintValidationOutputWindowPane">
            <summary>
              Looks up a localized string similar to Constraint Validation.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CustomCategoryRequired">
            <summary>
              Looks up a localized string similar to At least one custom category must be specified.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.CustomPrototypeSaveErrorCaption">
            <summary>
              Looks up a localized string similar to Error saving prototype.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.DeleteFromModel">
            <summary>
              Looks up a localized string similar to &amp;Delete From Model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.DeleteTransactionName">
            <summary>
              Looks up a localized string similar to Delete.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.DeleteViewMenuText">
            <summary>
              Looks up a localized string similar to &amp;Delete View.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.DiagramCannotBeNull">
            <summary>
              Looks up a localized string similar to Diagram cannot be null.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.DsPrototypeDefaultBitmapFilename">
            <summary>
              Looks up a localized string similar to ASPWebService.bmp.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.DsPrototypeString">
            <summary>
              Looks up a localized string similar to AD Prototypes.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.EndConstraintValidationOutput">
            <summary>
              Looks up a localized string similar to ========== Validation complete: {0} errors, {1} warnings, {2} information messages ==========.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorArgumentInvalidType">
            <summary>
              Looks up a localized string similar to value must be of type {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorCouldNotObtainDiagram">
            <summary>
              Looks up a localized string similar to Could not obtain diagram for file &apos;{0}&apos;.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorExportPathIsNull">
            <summary>
              Looks up a localized string similar to Export path cannot be null..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorMessageDescriptionArgument">
            <summary>
              Looks up a localized string similar to Supplied message does not have a Description..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorNotAValidDiagramDocument">
            <summary>
              Looks up a localized string similar to &apos;{0}&apos; is not a valid diagram document..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorNotAValidDirectory">
            <summary>
              Looks up a localized string similar to &apos;{0}&apos; is not a valid directory..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorOpeningDocument">
            <summary>
              Looks up a localized string similar to Error opening document &apos;{0}&apos;..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ErrorZeroDiagramFiles">
            <summary>
              Looks up a localized string similar to One or more diagrams are required for exporting..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ExpandCollapseShape">
            <summary>
              Looks up a localized string similar to Expand-collapse Shape.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ExpandMenuText">
            <summary>
              Looks up a localized string similar to E&amp;xpand.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ExportProgress">
            <summary>
              Looks up a localized string similar to Exporting {0} ....
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ExtensionNeedsDot">
            <summary>
              Looks up a localized string similar to You must prepend file extension with a dot.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.FormatDocAlreadyLocked">
             <summary>
               Looks up a localized string similar to File Locked for Editing
            	
            The document {0} is open. Close the document?.
             </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.InvalidDomainClassId">
            <summary>
              Looks up a localized string similar to Invalid domain class identifier.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.InvalidFactoryType">
            <summary>
              Looks up a localized string similar to Factory type must be a string, Guid or System.Type.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.LoggingEnabled">
            <summary>
              Looks up a localized string similar to Logging Enabled.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.LsaPrototypeDefaultBitmapFilename">
            <summary>
              Looks up a localized string similar to IISHost.bmp.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.LsaPrototypeString">
            <summary>
              Looks up a localized string similar to LDD Prototypes.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerAddElementCommandText">
            <summary>
              Looks up a localized string similar to Add New {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerAddElementUndoText">
            <summary>
              Looks up a localized string similar to Add {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerAutoLayoutShapesText">
            <summary>
              Looks up a localized string similar to AutoPlace Shapes.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerCascadePopulateUndoText">
            <summary>
              Looks up a localized string similar to Cascade Populate {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerDeleteAllUndoText">
            <summary>
              Looks up a localized string similar to Delete All {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerDeleteUndoText">
            <summary>
              Looks up a localized string similar to Delete {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerEmptyRoleFormat">
            <summary>
              Looks up a localized string similar to {0} (empty).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerFullRoleFormat">
            <summary>
              Looks up a localized string similar to {0} {1} ({2}).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerNodeFormat">
            <summary>
              Looks up a localized string similar to {0} ({1}).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ModelExplorerPopulateUndoText">
            <summary>
              Looks up a localized string similar to Populate {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.MultipleDiagramsInModel">
            <summary>
              Looks up a localized string similar to More than one diagram found in a model..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.NewListCompartmentItem">
            <summary>
              Looks up a localized string similar to Add New List Compartment Item.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.NewViewMenuText">
            <summary>
              Looks up a localized string similar to &amp;New View.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PageSetupErrorMessageBoxCaption">
            <summary>
              Looks up a localized string similar to Page Setup.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PageSetupFitToSheetsAcrossInValid">
            <summary>
              Looks up a localized string similar to Number of sheets across: the number must be between 1 and {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PageSetupFitToSheetsDownInValid">
            <summary>
              Looks up a localized string similar to Number of sheets down: the number must be between 1 and {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PageSetupMarginsGroupBoxTextImperial">
            <summary>
              Looks up a localized string similar to Margins (inches).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PageSetupMarginsGroupBoxTextMetric">
            <summary>
              Looks up a localized string similar to Margins (millimeters).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PageSetupMarginsTooLarge">
             <summary>
               Looks up a localized string similar to The margins overlap or they are off the paper.
            Enter a different margin size..
             </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PageSetupNotAValidPrinter">
            <summary>
              Looks up a localized string similar to You need to install a printer before you can perform page setup. .
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PartialDiagramTemplate">
            <summary>
              Looks up a localized string similar to View{0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PathTooLongError">
            <summary>
              Looks up a localized string similar to The path is too long.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PopulateDisabledWarning">
            <summary>
              Looks up a localized string similar to The Populate command cannot be used with the role &apos;{0}&apos; as its max multiplicity is greater than 1..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.Properties">
            <summary>
              Looks up a localized string similar to P&amp;roperties.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.PrototypeNameError">
            <summary>
              Looks up a localized string similar to Invalid prototype name.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ProvideCommandLineSwitchLogRegistered">
            <summary>
              Looks up a localized string similar to Command-line switch: {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ProvideCommandLineSwitchLogUnregistered">
            <summary>
              Looks up a localized string similar to Command-line switch: {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ProvideRelatedFileInvalidOptions">
            <summary>
              Looks up a localized string similar to Mutually exclusive options used for {0}.{1} in project {2}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ProvideRelatedFileInvalidProjectGuid">
            <summary>
              Looks up a localized string similar to Invalid project system guid &apos;{2}&apos; for {0}.{1}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ProvideRelatedFileLogFailed">
            <summary>
              Looks up a localized string similar to Related file registration failed for {0}.{1} in project {2}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ProvideRelatedFileLogRegistered">
            <summary>
              Looks up a localized string similar to Related file: {0}.{1} in project {2}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.ProvideRelatedFileLogUnregistered">
            <summary>
              Looks up a localized string similar to Related file: {0}.{1} in project {2}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.RemoveDiagram">
            <summary>
              Looks up a localized string similar to Delete View.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.RemovedMessage">
             <summary>
               Looks up a localized string similar to Removed: {0}
            .
             </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.RenameDiagram">
            <summary>
              Looks up a localized string similar to Rename View.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.RenameViewMenuText">
            <summary>
              Looks up a localized string similar to &amp;Rename View.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.RerouteUndoItem">
            <summary>
              Looks up a localized string similar to Reroute.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.SavePrototypeFileTitle">
            <summary>
              Looks up a localized string similar to Save File.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.SccCheckoutFailed">
            <summary>
              Looks up a localized string similar to Source Code Control Checkout Failed..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.SccFileReloaded">
            <summary>
              Looks up a localized string similar to Source Code Control Checkout Caused File Reload..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.SelectionTypesNotImplemented">
            <summary>
              Looks up a localized string similar to SelectionTypes is not implemented..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.SeparatorItem">
            <summary>
              Looks up a localized string similar to -.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.SetDiagramName">
            <summary>
              Looks up a localized string similar to Set Diagram Name.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.SortIndexError">
            <summary>
              Looks up a localized string similar to Invalid sorting index.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.StoreCannotBeNull">
            <summary>
              Looks up a localized string similar to Store cannot be null.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.StoreNotEditable">
            <summary>
              Looks up a localized string similar to DocumentDirtyEventArgs created while Store is not editable..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.TabStripInUnknownMode">
            <summary>
              Looks up a localized string similar to TabStrip in unknown mode.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.UndoUnitTransaction">
            <summary>
              Looks up a localized string similar to UndoUnit Transaction.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ShellStrings.UnknownActionValue">
            <summary>
              Looks up a localized string similar to Unknown TabEventArgs.Action value.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.TransactionCommitHandler">
            <summary>
            Delegate definitions for committing a transaction and determining
            a description prior to a transaction commit.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DescriptionHandler">
            <summary>
            
            </summary>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.UndoUnit">
            <summary>
            Wrapper for Modeling transactions so they can be used by the shell's
            IOleUndoManager interface.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.inUndoState">
            <summary>
            True iff the next call to Do() should perform an undo.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.transactionItem">
            <summary>
            The Modeling TransactionItem wrapped by this undo unit
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.serviceProvider">
            <summary>
            A service provider we can use to get shell services.  We need the IVsUIShell interface to
            refresh the property browser.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.commitHandler">
            <summary>
            If this undo unit is created without a transaction, this delegate should be non-null,
            and will be used to obtain the transaction when necessary
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.descriptionHandler">
            <summary>
            If this undo unit is created without a transaction and this delegate is non-null, it
            will be used to obtain the description to avoid committing the transaction.  Note that
            once the transaction has committed, this will no longer be used, rather, Transaction.Name
            will specify description.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.window">
            <summary>
            Last instance of one of our windows to be focused when the undo unit was created.
            This is used to refocus that window when the unit is undone/redone.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.context">
            <summary>
            This is the Context within the store that the transaction is part of.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Context,Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Constructs a new undo unit.
            </summary>
            <param name="serviceProvider"></param>
            <param name="context"></param>
            <param name="transactionItem">The transactionItem to wrap.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Context,Microsoft.VisualStudio.Modeling.Shell.TransactionCommitHandler,Microsoft.VisualStudio.Modeling.Shell.DescriptionHandler)">
            <summary>
            Creates an undo unit without a transaction, but with a delegate it can use to obtain
            the transaction later, when necessary.  Also specifies a delegate that can be used to
            obtain the description of this action, to avoid a commit.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Context,Microsoft.VisualStudio.Modeling.Shell.TransactionCommitHandler)">
            <summary>
            Creates an undo unit without a transaction, but with a delegate it can use to obtain
            the transaction later, when necessary.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.OnNextAdd">
            <summary>
            Called when a new undo unit is added on top of this one on the undo stack.
            We don't need to do anything here.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.Do(Microsoft.VisualStudio.OLE.Interop.IOleUndoManager)">
            <summary>
            Performs undo/redo based on the internal state of this undo unit.
            Also, undo unit is responsible for adding itself to the *opposite* 
            stack.
            </summary>
            <param name="undoManager">Undo manager, used for adding undo unit to appropriate undo/redo stack</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.GetUnitType(System.Guid@,System.Int32@)">
            <summary>
            Used by undo manager to provide special handling for certain undo units based on
            their type -- we don't use this method
            </summary>
            <param name="unitGuid"></param>
            <param name="unitId"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.GetDescription(System.String@)">
            <summary>
            Gets a text description for this undo unit, which is displayed by the shell
            </summary>
            <param name="description">text description</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.UndoUnit.ActiveModelingWindow">
            <summary>
            Get's the currently active mdoeling window. Returns null if the active window is not a ModelingWindowPane
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView">
            <summary>
            Diagram view hosted inside VS.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.alreadyDisposed">
            <summary>
            Flags if this object has already been disposed
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.#ctor">
            <summary>
            Constructor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.Dispose(System.Boolean)">
            <summary>
            Unregister event handlers on disposal
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnDiagramAssociated(System.Object,System.EventArgs)">
            <summary>
            subscribe to the selection changed events when a diagram is associated
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnDiagramDisassociating(System.Object,System.EventArgs)">
            <summary>
            unsubscribe from the the selction changed events when a diagram is disassociated
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnShapeSelectionChanged(System.Object,System.EventArgs)">
            <summary>
            This is called whenever the selection list changes
            </summary>
            <param name="sender">event originator</param>
            <param name="e">event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnMouseDown(System.Windows.Forms.MouseEventArgs)">
            <summary>
            
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnMouseUp(System.Windows.Forms.MouseEventArgs)">
            <summary>
            
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnClientViewDragDrop(System.Object,System.Windows.Forms.DragEventArgs)">
            <summary>
            Listens to the DiagramView's client window for DragDrop. 
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
            <remarks>
            The DocView is somehow unaware when one of its descendant
            windows, the DiagramView client window, gets the focus after 
            drag/drop. The net effect is that the status of the commands 
            are not getting re-queried.
            To work around this, DocView.Show() is explicitly called.
            This has the unwanted side effect of taking the focus away from 
            the DiagramView's client window, so the focus is explicitly set back.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnClientViewDragLeave(System.Object,System.EventArgs)">
            <summary>
            See remarks in OnClientViewDragDrop.  We need to do the same if a drag operation is cancelled.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.OnWatermarkCreated">
            <summary>
            Customizes the watermark font to match VS
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.MouseUpEvent">
            <summary>
            Occurs when mouse button is release.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.DocView">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.DocData">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.SelectionService">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.VsWatermarkFont">
            <summary>
            Gets the VS watermark font.
            </summary>
            <value>The VS watermark font.</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramView.VsWatermarkForeColor">
            <summary>
            Gets the VS watermark forecolor.
            </summary>
            <value>The VS watermark forecolor.</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.VSDiagramViewSite">
            <summary>
            Used to site the design surface control.  Provides access to shell services.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VSDiagramViewSite.GetService(System.Type)">
            <summary>
            Gets service of specified type.
            </summary>
            <param name="serviceType">Service type.</param>
            <returns>Service instance.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramViewSite.Component">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramViewSite.Container">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramViewSite.DesignMode">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VSDiagramViewSite.Name">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.VsOutputWindow">
            <summary>
            Wrapper class for the output window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsOutputWindow.EnsurePane(System.IServiceProvider,System.Guid@,System.String)">
            <summary>
            Returns the designated "Constraint Validation" output pane in the VS.
            </summary>
            <param name="provider"></param>
            <param name="rguidPane"></param>
            <param name="paneName"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsOutputWindow.ClearOutputWindowPane(System.IServiceProvider,System.Guid@,System.String)">
            <summary>
            Clears the "Constraint validation" output pane.
            </summary>
            <param name="provider"></param>
            <param name="rguidPane"></param>
            <param name="paneName"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsOutputWindow.EnsureOutputWindowPaneVisible(System.IServiceProvider,System.Guid@,System.String)">
            <summary>
            Ensure the output window is visible.
            </summary>
            <param name="sp"></param>
            <param name="rguidPane"></param>
            <param name="paneName"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsOutputWindow.AddOutputString(System.IServiceProvider,System.Guid@,System.String,System.String)">
            <summary>
            Add the string into the designated output window pane
            </summary>
            <param name="provider"></param>
            <param name="rguidPane"></param>
            <param name="paneName"></param>
            <param name="outputString"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsOutputWindow.FindToolWindow(System.IServiceProvider,System.Guid)">
            <summary>
            Find the IVsWindowFrame for the given tool window ID
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand">
            <summary>
            Represents a menu command entry on the context menu for a validation item in the error list.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand.#ctor">
            <summary>
            Constructor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand.#ctor(System.Int32)">
            <summary>
            Constructor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand.DoCommand">
            <summary>
            Executes the command.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand.MenuText">
            <summary>
            Gets the text associated with this menu command entry
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand.Priority">
            <summary>
            Indicates the priority of the command. Commands with lower
            numbers are shown earlier in the list, and the first
            command is executed on double-click.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenu">
            <summary>
            A variant of menu command used to manage a cascading menu which will 
            be dynamically populated.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenu.#ctor(System.ComponentModel.Design.CommandID,System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand})">
            <summary>
            
            </summary>
            <param name="id"></param>
            <param name="menuPopulation"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenuCommand">
            <summary>
            A variant of menu command used to manage a dynamically populated list of menu commands
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenuCommand.#ctor(System.ComponentModel.Design.CommandID,System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.Shell.TaskMenuCommand})">
            <summary>
            constructor
            </summary>
            <param name="id"></param>
            <param name="commandList"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenuCommand.DynamicItemMatch(System.Int32)">
            <summary>
            
            </summary>
            <param name="cmdId"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenuCommand.OnStatusMenuCommandHelper(System.Object,System.EventArgs)">
            <summary>
            
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenuCommand.CurrentItemName">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.DynamicCascadingMenuCommand.MenuItem">
            <summary>
            
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver">
            <summary>
            ErrorListObserver monitors changes after VsValidationController finishes the validation. 
            It reports the error/warning/message in the VS ErrorList and Output window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.#ctor(System.IServiceProvider)">
            <summary>
            constructor
            </summary>
            <param name="serviceProvider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.Dispose">
            <summary>
            Do not make this method virtual. A derived class should not be able to override this method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.Dispose(System.Boolean)">
            <summary>
            Dispose(bool disposing) executes in two distinct scenarios. 
            If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources
            can be disposed.
            If disposing equals false, the method has been called by the runtime from inside the finalizer and you should not reference 
            other objects. Only unmanaged resources can be disposed.
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.Finalize">
            <summary>
            Use C# destructor syntax for finalization code. This destructor will run only if the Dispose method 
            does not get called. It gives your base class the opportunity to finalize.
            Do not provide destructors in types derived from this class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.OnValidationBeginning(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Overriddable method to capture the validation beginning stats
            </summary>
            <param name="context">validation context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.OnValidationEnded(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Overriddable method to capture the validation ended notification.
            </summary>
            <param name="context">validation context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.OnValidationMessagesChanging(System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage})">
            <summary>
            Override to process a change to the message collection.
            </summary>
            <remarks>
            methods are called in this order:
            1. OnValidationMessagesChanging
            2. OnValidationMessageRemoved - called once for each message removed.
            3. OnValidationMessageAdded - called once for each message added.
            4. OnValidationMessagesChangedSummary
            </remarks>
            <param name="messagesBeforeUpdate"></param>
            <param name="messagesRemoved"></param>
            <param name="messagesAdded"></param>
            <param name="messagesAfterUpdate"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.OnValidationMessageRemoved(Microsoft.VisualStudio.Modeling.Validation.ValidationMessage)">
            <summary>
            Report removed messages to the task list.
            </summary>
            <remarks>
            methods are called in this order:
            1. OnValidationMessagesChanging
            2. OnValidationMessageRemoved - called once for each message removed.
            3. OnValidationMessageAdded - called once for each message added.
            4. OnValidationMessagesChangedSummary
            </remarks>
            <param name="removedMessage"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.OnValidationMessageAdded(Microsoft.VisualStudio.Modeling.Validation.ValidationMessage)">
            <summary>
            Report added messages to the task list.
            </summary>
            <remarks>
            methods are called in this order:
            1. OnValidationMessagesChanging
            2. OnValidationMessageRemoved - called once for each message removed.
            3. OnValidationMessageAdded - called once for each message added.
            4. OnValidationMessagesChangedSummary
            </remarks>
            <param name="addedMessage"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.ShouldReportToOutputWindow(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            For the given context, this method determines whether to write the status to the output window or not
            </summary>
            <param name="context"></param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ErrorListObserver.TaskProvider">
            <summary>
            provides access to the Task List.
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ValidationTaskProvider">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ValidationTaskProvider.#ctor(System.IServiceProvider)">
            <summary>
            constructor
            </summary>
            <param name="provider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ValidationTaskProvider.ShowValidationErrors">
            <summary>
            Ensure Build Errors List is visible and listing validation errors.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator">
            <summary>
            Helper class for working with model element references.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.#ctor(System.IServiceProvider)">
            <summary>
            constructor
            </summary>
            <param name="serviceProvider">A service provider for this object to obtain VS services</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.FindModelingDocData(System.Guid,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Searches the running document table to find a ModelingDocData containing the identified element, supporting the given logicalView. Because several SDM docDatas can share the same IMS store, it is possible for more than one DocData to be returned.
            </summary>
            <param name="logicalView">Guid for the elements's logical view</param>
            <param name="modelElement">Model element for which containing docData is need</param>
            <returns>List of ModelingDocDatas supporting the docData, one of which contains the identified diagram. The list may be empty.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.FindDocView(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.Diagram)">
            <summary>
            Finds a ModelingDocView displaying this diagam (if one exists).  
            May return null.
            </summary>
            <param name="logicalView">Guid for the diagram's logical view</param>
            <param name="diagram">diagram for which containing docData is need</param>
            <returns>DocView displaying the supplied diagram.  May return null.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.FindAndOpenDocView(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.Diagram)">
            <summary>
            Finds a ModelingDocView displaying this diagam. If the DocView cannot
            be found in already-opened views, then open the views on each
            candidate DocData.
            May return null.
            </summary>
            <param name="logicalView">Guid for the diagram's logical view</param>
            <param name="diagram">diagram for which containing docData is need</param>
            <returns>ModelingDocView displaying the supplied diagram.  May return null.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.FindDocView(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.Diagram,System.Boolean)">
            <summary>
            Finds a ModelingDocView displaying this diagam (if one exists).  
            May return null.
            If open is true, then call OpenView on candidate DocData before
            looking through its views.
            </summary>
            <param name="logicalView"></param>
            <param name="diagram"></param>
            <param name="openView">true means call OpenView on the DocData
            when trying to find the docView</param>
            <returns>DocView displaying the supplied diagram.  May return null.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.NavigateTo(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.ShapeElement)">
            <summary>
            Display and select the supplied shape.
            </summary>
            <param name="logicalView"></param>
            <param name="targetShape"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.NavigateTo(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.Diagram)">
            <summary>
            Open the target diagram.
            </summary>
            <param name="logicalView"></param>
            <param name="targetDiagram"></param>
            <returns>true if successful</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.NavigateTo(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.Diagram,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.Diagrams.DiagramItem})">
            <summary>
            Display the target diagram and select the target shapes.
            All of the target shapes are expected to be in the target diagram.
            The First shape in the list is the primary selection.
            </summary>
            <param name="logicalView"></param>
            <param name="targetDiagram"></param>
            <param name="targetSelection">collection of ShapeElements to select (expected to be on targetDiagram.)</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.NavigateTo(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.DiagramItem,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.Diagrams.DiagramItem})">
            <summary>
            Display the targetShape's diagram and select the shape (extend the 
            selection to include the extendedSelection.)
            </summary>
            <param name="logicalView"></param>
            <param name="diagramItem">DiagramItem to navigte to and select</param>
            <param name="extendedSelection">collection of ShapeElements to also select, may be an empty list or null.</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.NavigateTo(System.Guid,Microsoft.VisualStudio.Modeling.Diagrams.DiagramItem,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.Diagrams.DiagramItem},System.Boolean)">
            <summary>
            Display the targetShape's diagram and, if desired, select the
            shape (extend the selection to include the extendedSelection.)
            </summary>
            <param name="logicalView"></param>
            <param name="targetDiagramItem">shape to navigte to and select</param>
            <param name="extendedSelection">collection of ShapeElements to also select, may be an empty list or null.</param>
            <param name="changeSelection">whether to actually change the selection.</param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.ModelingDocDatasFromRunningDocumentTable">
            <summary>
            Creates a new list of ModelingDocData objects listed in the Running Document Table.
            </summary>
            <remarks>
            This property MUST remain private, given that its datatype is a generic list.
            </remarks>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.ServiceProvider">
            <summary>
            Returns our IServiceProvider.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator.MonitorSelection">
            <summary>
            Retruns the IMonitorSelectionService of our service provider.
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.NavigateToModelExplorerTreeNodeCommand">
            <summary>
            Validation navigation command that navigates to the model explorer window.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.NavigateToModelExplorerTreeNodeCommand.#ctor(Microsoft.VisualStudio.Modeling.Shell.ModelExplorerToolWindow,Microsoft.VisualStudio.Modeling.Shell.ExplorerTreeNode,System.Int32)">
            <summary>
            Constructor.
            </summary>
            <param name="modelElementTreeNode"></param>
            <param name="modelExplorerToolWindow"></param>
            <param name="priority"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.NavigateToModelExplorerTreeNodeCommand.DoCommand">
            <summary>
            Performs the navigation command.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.NavigateToModelExplorerTreeNodeCommand.MenuText">
            <summary>
            Text displayed in the menu.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.NavigateToShapesOnDiagramCommand">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.NavigateToShapesOnDiagramCommand.#ctor(Microsoft.VisualStudio.Modeling.Shell.ModelElementLocator,Microsoft.VisualStudio.Modeling.Diagrams.Diagram,System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.Diagrams.DiagramItem},System.Int32)">
            <summary>
            constructor
            </summary>
            <param name="locator"></param>
            <param name="targetDiagram">diagram to navigate to</param>
            <param name="targetSelection">collection of ShapeElements to select(expected to be on targetDiagram)</param>
            <param name="priority">Priority of this command.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.NavigateToShapesOnDiagramCommand.DoCommand">
            <summary>
            Navigate to the targetDiagram and select the targetSelection.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.NavigateToShapesOnDiagramCommand.MenuText">
            <summary>
            gets the text which is to be displayed for this menu item.
            Corona diagrams don't have specific names
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage">
            <summary>
            TaskValidationMessages are supplied by the VsValidationContext (i.e. ConstructValidationMessage override).
            It contains the information to work with the VS ErrorList tool window. It's capable to navigate to the shape  
            in the diagram from the offending model element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationContext,System.String,Microsoft.VisualStudio.Shell.TaskCategory,System.String,Microsoft.VisualStudio.Modeling.Validation.ViolationType,System.String)">
            <summary>
            ctor
            </summary>
            <param name="context"></param>
            <param name="description">problem description (this text will be surfaced to the UI</param>
            <param name="category"></param>
            <param name="code"></param>
            <param name="violationType"></param>
            <param name="helpKeyword"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.IsMatch(EnvDTE.TaskItem)">
            <summary>
            determines if the specified taskItem represents this message.
            </summary>
            <param name="taskItem">taskItem to check</param>
            <returns>true if the taskItem represents this message</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.IsMatch(Microsoft.VisualStudio.Shell.Interop.IVsTaskItem)">
            <summary>
            determines if the specified taskItem represents this message.
            </summary>
            <param name="taskItem">taskItem to check</param>
            <returns>true if the taskItem represents this message</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.Configure(Microsoft.VisualStudio.Modeling.Shell.ValidationTask)">
            <summary>
            configures the supplied task with values of this message.
            </summary>
            <value></value>
            <param name="task"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.Category">
            <summary>
            Task category.
            </summary>
            <value>Comment, Build Error, User, Shortcut, Policy</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.Hierarchy">
            <summary>
            Returns the Hierarchy for the DocData where the offending model element resides.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.DocData">
            <summary>
            Returns the DocData where the offending model element resides.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.File">
            <summary>
            return the name of the first referenced file, if one exists, otherwise null.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.TaskValidationMessage.ErrorMessageType">
            <summary>
            priority of this task message
            </summary>
            <value>Low, Normal, High</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ValidationMessageCommandIds">
            <summary>
            CommandIDs for the Application Designer package.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ValidationMessageCommandIds.guidTaskListMenuGroup">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ValidationMessageCommandIds.TaskListNavigateMenu">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ValidationMessageCommandIds.TaskListNavigate">
            <summary>
            
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ValidationTask">
            <summary>
            Validation task.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ValidationTask.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationMessage)">
            <summary>
            Constructor.
            </summary>
            <param name="message">Message to display in the ask.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ValidationTask.IsMatch(Microsoft.VisualStudio.Modeling.Shell.ValidationTask)">
            <summary>
            Gets whether this task has same message as another one.
            </summary>
            <param name="task">Task to compare to.</param>
            <returns>Whether task messages match.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ValidationTask.Message">
            <summary>
            Associated validation message.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext">
            <summary>
            Context specific to the VS Shell. It derives from ValidationContext.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(System.String[],Microsoft.VisualStudio.Modeling.ModelElement,System.IServiceProvider)">
            <summary>
            Constructor.
            </summary>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <param name="subject">root object to be validated</param>
            <param name="serviceProvider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(System.String[],System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.IServiceProvider)">
            <summary>
            Constructor.
            </summary>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <param name="subjects">object to be validated</param>
            <param name="serviceProvider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories,Microsoft.VisualStudio.Modeling.ModelElement,System.IServiceProvider)">
            <summary>
            Constructor.
            </summary>
            <param name="categories"></param>
            <param name="subject">root object to be validated</param>
            <param name="serviceProvider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.IServiceProvider)">
            <summary>
            Constructor.
            </summary>
            <param name="categories"></param>
            <param name="subjects">object to be validated</param>
            <param name="serviceProvider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(System.String[],Microsoft.VisualStudio.Modeling.ModelElement,System.IServiceProvider,System.Type)">
            <summary>
            Constructor.
            </summary>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <param name="subject">root object to be validated</param>
            <param name="serviceProvider"></param>
            <param name="modelExplorerToolWindowType"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(System.String[],System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.IServiceProvider,System.Type)">
            <summary>
            Constructor.
            </summary>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <param name="subjects">object to be validated</param>
            <param name="serviceProvider"></param>
            <param name="modelExplorerToolWindowType"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories,Microsoft.VisualStudio.Modeling.ModelElement,System.IServiceProvider,System.Type)">
            <summary>
            Constructor.
            </summary>
            <param name="categories"></param>
            <param name="subject">root object to be validated</param>
            <param name="serviceProvider"></param>
            <param name="modelExplorerToolWindowType"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.IServiceProvider,System.Type)">
            <summary>
            Constructor.
            </summary>
            <param name="categories"></param>
            <param name="subjects">object to be validated</param>
            <param name="serviceProvider"></param>
            <param name="modelExplorerToolWindowType"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.ConstructValidationMessage(System.String,System.String,Microsoft.VisualStudio.Modeling.Validation.ViolationType,Microsoft.VisualStudio.Modeling.ModelElement[])">
            <summary>
            Overrideable method to allow the derived class to create messages.
            </summary>
            <param name="description"></param>
            <param name="code"></param>
            <param name="violationType"></param>
            <param name="elements"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.OnNavigateToTask(Microsoft.VisualStudio.Modeling.Shell.ValidationTask)">
            <summary>
            Override to implement OnNavigate behavior for the supplied validation task list item.
            The default implementation calls DoCommand on the first item in DiagramNavigateCommands,
            and executes the ExplorerNavigateCommand, if available.
            </summary>
            <param name="task">Task List item</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.OnDeleteTask(Microsoft.VisualStudio.Modeling.Shell.ValidationTask)">
            <summary>
            Override to implement OnDelete behavior for the supplied validation task list item.
            </summary>
            <param name="task"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.GetNavigationCommands(Microsoft.VisualStudio.Modeling.Validation.ValidationMessage)">
            <summary>
            Full list of navigation commands for this validation message. Default implementation
            concatentates the DiagramNavigateCommands with the ExplorerNavigateCommand.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.GetDiagramNavigationCommands(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Override to supply one or more diagram navigation commands for the referenced elements.
            </summary>
            <value>An IList of DynamicMenuCommands</value>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.GetDiagramNavigationTargets(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Get the list of shapes associated with the referenced 
            model elements, that we can target for navigation.  
            </summary>
            <value></value>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.GetDiagramNavigationTargetSubstitutes(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets a list of zero-or-more substitute shapes for the given target.
            </summary>
            <param name="target">original navigation target (expected not to be a ShapeElement)</param>
            <returns>a list of substitute navigation targets (expected to be ShapeElements), may be null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.GetPresentationLinks(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Returns a collection of PresentationViewsSubject links where the targetElement is MEL in the PEL-->MEL relationship
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.GetExplorerNavigationCommand(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Returns a TaskMenuCommand capable of navigating to the appropriate node in the model explorer
            window for this validation message. If no corresponding node exists in the model explorer, this
            property returns null.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.GetNavigationProxyModelElements(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Returns the substitutes model element for the passed in model element. Consider the case where the *viewed* presentation model 
            element(s) (PELs) represents the model element(s) which are proxies to the actual offending model element reported during
            the model validation.
            </summary>
            <param name="fromElement">the reported offending model element</param>
            <returns>A readonly collection of all all the proxy elements which represents the passed in model element.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.ServiceProvider">
            <summary>
            Returns the service associated with this context.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.Locator">
            <summary>
            helper for working with model element references.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VsValidationContext.ModelExplorerToolWindow">
            <summary>
            Gets the model explorer tool window associated with this validation context.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.VsValidationController">
            <summary>
            VS model validation controller.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.#ctor(System.IServiceProvider)">
            <summary>
            Constructor.
            </summary>
            <param name="serviceProvider"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.#ctor(System.IServiceProvider,System.Type)">
            <summary>
            Constructor.
            </summary>
            <param name="serviceProvider"></param>
            <param name="modelExplorerToolWindowType"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.Validate(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Do validation for a set of elements
            </summary>
            <param name="subjects">The list of subjects to validate</param>
            <param name="categories"></param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.ValidateCustom(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.String[])">
            <summary>
            Do validation for a set of elements based on the custom specified string
            </summary>
            <param name="subjects"></param>
            <param name="customCategories">
            A list of custom specified strings. This allows the validation method with the given strings to be validated.
            Note: At least one custom string needs to be specified, or exception will be thrown.
            </param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.SetWaitCursor">
            <summary>
            Create the wait cursor. It will be cleared when the next windows message kicks in.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.ClearMessages">
            <summary>
            Clears all validation messages
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.CreateValidationContext(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Provide a context class for the validation
            </summary>
            <param name="subjects"></param>
            <param name="categories"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.CreateValidationContext(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.String[])">
            <summary>
            Provide a context class for the validation
            </summary>
            <param name="subjects"></param>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.VsValidationController.ServiceProvider">
            <summary>
            Returns the service provider.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute">
            <summary>
            Attribute class to provide the registry entries for contributing a command-line switch
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute.#ctor(System.String,System.String)">
            <summary>
            Create a new ProvideCommandLineSwitch attribute
            </summary>
            <param name="name">The text of the command line switch</param>
            <param name="helpText">The resource Id of help string</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute.Register(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Register a new command line switch
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute.Unregister(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Unregister a command-line switch
            </summary>
            <param name="context"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute.Name">
            <summary>
            The name of the command-line switch
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute.Arguments">
            <summary>
            The number of arguments to the command-line switch
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute.DemandLoad">
            <summary>
            Whether the command-line switch shoudl cause deman-loading
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideCommandLineSwitchAttribute.HelpText">
            <summary>
            The help string for the command-line switch
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType">
            <summary>
            Flag enumeration to specifiy the related file behavior
            </summary>
            <remarks>
            None, Simple, Filename and CultureInfo are mutually exclusive.
            Other flags can be OR'd in to one of those four.
            </remarks>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType.None">
            <summary>
            No related files
            Mutually exlusive with Simple, Filename and CultureInfo
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType.Simple">
            <summary>
            Related files are based on filename, without extension
            Mutually exlusive with None, FileName and CultureInfo
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType.FileName">
            <summary>
            Related files are based on full filename
            Mutually exlusive with None, Simple and CultureInfo
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType.CultureInfo">
            <summary>
            Related files are culture info based
            Mutually exlusive with None, Simple and Filename
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType.ChildIsNeverHidden">
            <summary>
            Dependent related file is never hidden in the solution explorer, even
            in project view in project types that normally hide dependent files.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType.AllowSccOperationsOnChild">
            <summary>
            Source Code Control operations are allowed on the dependent related file, separately
            from the parent related file (so the file is not an SCC "special" file.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.RelatedFileType.RemoveOnReplacingParent">
            <summary>
            Specifies that the related file
            is to be removed when the parent file is replaced in the project.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute">
            <summary>
            Attribute class to provide the registry entries for asking the shell to manage the
            relationship between a nested file and its parent in the solution explorer
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.CSharpProjectGuid">
            <summary>
            Guid of the C# Project System
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.VisualBasicProjectGuid">
            <summary>
            Guid of the Visual Basic Project System
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.#ctor(System.String,System.String)">
            <summary>
            Create a new ProvideRelatedFile attribute
            </summary>
            <param name="name"></param>
            <param name="helpText"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.Register(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Register a new command line switch
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.Unregister(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Unregister a command-line switch
            </summary>
            <param name="context"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.ParentExtension">
            <summary>
            The extension of the parent file
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.ChildExtension">
            <summary>
            The extension of the child file
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.ProjectSystem">
            <summary>
            The project system that this code generator is registered with
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.ProvideRelatedFileAttribute.FileOptions">
            <summary>
            Options for how the related file is managed
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.CommandSet">
            <summary>
            Commands supported by this designer
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.#ctor(System.IServiceProvider)">
            <summary>
            Creates a new CommandSet
            </summary>
            <param name="serviceProvider">Service provider used to retrieve Visual Studio services.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.Initialize">
            <summary>
            Initialize the command set
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.GetMenuCommands">
            <summary>
            Provide the menu commands that this commandset implements
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnStatusSelectAllCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the SelectAll menu status handler. 
            </summary>
            <param name="command">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnMenuSelectAllCommand">
            <summary>
            Virtual method to process the menu SelectAll operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnStatusRerouteLineCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the RerouteLine menu status handler. 
            </summary>
            <param name="command">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnMenuRerouteLineCommand">
            <summary>
            Virtual method to process the menu RerouteLine operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnStatusDeleteCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the Delete menu status handler. 
            </summary>
            <param name="command">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnMenuDeleteCommand">
            <summary>
            Virtual method to process the menu Delete operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnStatusExpandCollapseCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the ExpandCollapse menu status handler. 
            </summary>
            <param name="command">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnMenuExpandCollapseCommand">
            <summary>
            Virtual method to process the menu ExpandCollapse operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnStatusEditCompartmentItemCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the EditCompartmentItem menu status handler. 
            </summary>
            <param name="command">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnMenuEditCompartmentItemCommand">
            <summary>
            Virtual method to process the menu EditCompartmentItem operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnStatusPageSetupCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the PageSetup menu status handler. 
            </summary>
            <param name="command">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnMenuPageSetupCommand">
            <summary>
            Virtual method to process the menu PageSetup operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnStatusPrintCommand(System.ComponentModel.Design.MenuCommand)">
            <summary>
            Virtual method for processing the Print menu status handler. 
            </summary>
            <param name="command">Menu command called from the Visual Studio</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ProcessOnMenuPrintCommand">
            <summary>
            Virtual method to process the menu Print operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnStatusSelectAll(System.Object,System.EventArgs)">
            <summary>
            This version of SelectAll is called when you hit Ctrl+A, or choose Edit|Select All
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnMenuSelectAll(System.Object,System.EventArgs)">
            <summary>
            
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnStatusDelete(System.Object,System.EventArgs)">
            <summary>
            
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnMenuDelete(System.Object,System.EventArgs)">
            <summary>
            
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnStatusExpandCollapse(System.Object,System.EventArgs)">
            <summary>
            Check if the expand/collapse menu item should be visible.
            Update the menu text to appropriate state.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnMenuExpandCollapse(System.Object,System.EventArgs)">
            <summary>
            Toggle the expand/collapse state on the selected node shape.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnStatusAddCompartmentItem(System.Object,System.EventArgs)">
            <summary>
            Check if the Add new Item menu item should be visible and
            set its name to the appropriate item type being created.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnMenuAddCompartmentItem(System.Object,System.EventArgs)">
            <summary>
            Add a new compartment item of the appropriate type.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnStatusEditCompartmentItem(System.Object,System.EventArgs)">
            <summary>
            Checks if the Edit item command should be visible and enabled.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnMenuEditCompartmentItem(System.Object,System.EventArgs)">
            <summary>
            Edit the selected list item.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnStatusAddCompartmentShapeItem(System.Object,System.EventArgs)">
            <summary>
            Check if the Add sub menu item should be visible and
            set its name to the appropriate item type being created.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.OnMenuAddCompartmentShapeItem(System.Object,System.EventArgs)">
            <summary>
            Add a new compartment shape item of the appropriate type.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.IsDiagramSelected">
            <summary>
            
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.IsAnyDocumentSelectionCompartment">
            <summary>
            Returns whether any of the items in the selection list is a compartment.
            </summary>
            <returns>True means that at least one of the items is a compartment.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.IsExpandableShape">
            <summary>
            Returns whether or not the single selection can expand or collapse.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.IsSingleSelection">
            <summary>
            Returns whether or not there is only one selected item on the active window.  This could be a document or tool window.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.IsSingleDocumentSelection">
            <summary>
            Returns whether or not there is only one selected item on the active document.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.IsCurrentDiagramEmpty">
            <summary>
            Returns true if diagram has no children.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.CommandSet.GetDiagramClientView">
            <summary>
            Gets the currently focused DiagramClientView
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.ServiceProvider">
            <summary>
            Service provider used to retrieve Visual Studio services.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.MenuService">
            <summary>
            Menu command service used to manage command handlers.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.MonitorSelection">
            <summary>
            Service used to track selection in the Visual Studio shell.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.CurrentSelection">
            <summary>
            Returns the collection of selected elements in the active window.  This could be a document window or tool window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.CurrentDocumentSelection">
            <summary>
            Returns the collection of selected elements in the active document window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.SingleSelection">
            <summary>
            Returns the primary selected object in active window.  This could be a document window or tool window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.SingleDocumentSelection">
            <summary>
            Returns the primary selected object in the active document window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.CurrentDocData">
            <summary>
            Currently focused document
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.CurrentWindow">
            <summary>
            Currently focused document view
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.CommandSet.CurrentDocView">
            <summary>
            Currently focused document view
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.AddCompartmentShapeItemMenuCommand">
            <summary>
            CompartmentShape.AddItem dynamic item start command.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.AddCompartmentShapeItemMenuCommand.ShouldIncludeInTheTypeCollection(Microsoft.VisualStudio.Modeling.ElementOperations,Microsoft.VisualStudio.Modeling.Diagrams.ElementListCompartment,Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Internal helper method to determine whether a domain class info should be included in the collection.
            </summary>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.AddSwimlaneMenuCommand">
            <summary>
            Command class for Add Before/Add After menu items of swimlanes.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.RegisterAdditionalEditorExtensionAttribute">
            <summary>
            Attribute class to provide a way to add extra file extension handling to existing editors without altering anything else
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RegisterAdditionalEditorExtensionAttribute.#ctor(System.Object,System.String,System.Int32)">
            <summary>
            Creates a new RegisterAdditionalEditorExtensionAttribute.
            </summary>
            <param name="factoryType">Type representing the existing editor factory to register an additional extension with.</param>
            <param name="extension">File extension to register.  Must begin with a '.'</param>
            <param name="priority">Priority of this editor for the file extension being registered.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RegisterAdditionalEditorExtensionAttribute.Register(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Register additional editor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RegisterAdditionalEditorExtensionAttribute.Unregister(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Unregister the editor
            </summary>
            <param name="context"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.RegisterAdditionalEditorExtensionAttribute.Extension">
            <summary>
            File extension to register.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.RegisterAdditionalEditorExtensionAttribute.Factory">
            <summary>
            Guid identifying the editor factory to register.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Shell.RegisterAdditionalEditorExtensionAttribute.Priority">
            <summary>
            Priority of the this editor for the extension being registered.  Larger values indicate higher editor priority.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.RegisterAsDslToolsEditorAttribute">
            <summary>
            This attribute is used to tag a DSL Tools Designer that has been created with the Designer Wizard.
            It enables the Designer Wizard to advise against re-using file extensions handled by other non-DSLTools designers, and 
            enables it to remove old DSL designers without removing other packages that handle the same file extension.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RegisterAsDslToolsEditorAttribute.Register(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Registers the package as a DSL tool.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.RegisterAsDslToolsEditorAttribute.Unregister(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)">
            <summary>
            Removes the DSL tool registration key.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Shell.WaitCursor">
            <summary>
            Simple class to put up the Wait cursor during its lifetime.
            </summary>
            <remarks>
            This class is designed to be used with the 'using' statement.
            </remarks>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.WaitCursor.control">
            <summary>
            The control to set the cursor for
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Shell.WaitCursor.originalCursor">
            <summary>
            Temporary store for the original cursor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.WaitCursor.#ctor(System.Windows.Forms.Control)">
            <summary>
            Constructor
            </summary>
            <param name="control"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.WaitCursor.Clear">
            <summary>
            Restore the original cursor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.WaitCursor.Finalize">
            <summary>
            Ensure that the cursor is cleared when the object is disposed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Shell.WaitCursor.Dispose">
            <summary>
            Ensure that the cursor is cleared when the object is disposed.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SafeWindowTarget">
            <summary>
            Exception hardening work.  This class can be used to filter messages sent to a control,
            and catch/display all non-critical exceptions.  Otherwise, Watson will
            be invoked and will take down the process, potentially resulting in data loss.  See
            document referenced in bug 427820 for more details.	 Use this class to wrap an existing 
            IWindowTarget as follows (c is a Control):
            
            c.WindowTarget = new SafeWindowTarget(c.WindowTarget);
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SafeWindowTarget.System#Windows#Forms#IWindowTarget#OnMessage(System.Windows.Forms.Message@)">
            <devdoc>
            The main wndproc for the control.  Wrapped to display non-critical exceptions to the user.
            </devdoc>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SafeWindowTarget.ReplaceWindowTargetRecursive(System.IServiceProvider,System.Collections.ICollection)">
            <summary>
            Replaces the WindowTarget for all child controls of the specified collection.
            In Debug builds, this will assert that any child controls added after this call must have their WindowTarget replaced as well.
            </summary>
            <param name="serviceProvider">The ServiceProvider.</param>
            <param name="controls">The collection of controls to recurse through and replace their target.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SafeWindowTarget.ReplaceWindowTargetRecursive(System.IServiceProvider,System.Collections.ICollection,System.Boolean)">
            <summary>
            Replaces the WindowTarget for all child controls of the specified collection.
            </summary>
            <param name="serviceProvider">The ServiceProvider.</param>
            <param name="controls">The collection of controls to recurse through and replace their target.</param>
            <param name="checkControlAdded">If true, in Debug builds, this will assert that any controls 
            added after this call must have their WindowTarget replaced as well.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ErrorAnalyzer.IsErrorCodeRelatedToTextBufferLocked(System.Int32)">
            <summary>
            This internal method will analyze if the returned error code related
            to locked text buffer
            </summary>
            <param name="code"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ErrorAnalyzer.IsErrorCodeRelatedToCanceling(System.Int32)">
            <summary>
            This internal method will analyze if the returned error code related
            to cancellation of the check-out dialog
            </summary>
            <param name="code"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ErrorAnalyzer.RethrowIfOperationHasBeenCanceled(System.Exception)">
            <summary>
            Checks if the exception related to cancellation of the checkout dialog. If yes, 
            this method will throw CheckoutException.Canceled
            </summary>
            <param name="ex"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ErrorAnalyzer.RethrowIfOperationHasBeenCanceled(System.Int32)">
            <summary>
            Checks if the exception related to cancellation of the checkout dialog. If yes, 
            this method will throw CheckoutException.Canceled
            </summary>
            <param name="errorCode"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CriticalException.IsCriticalException(System.Exception)">
            <summary>
            	Gets whether exception is a critical one and can't be ignored with corrupting
            	AppDomain state.
            </summary>
            <param name="ex">Exception to test.</param>
            <returns>True if exception should not be swallowed.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CriticalException.ThrowOrShow(System.IServiceProvider,System.Exception)">
            <summary>
            	Shows non-critical exceptions to the user and returns false or
            	returns true for critical exceptions.
            </summary>
            <param name="serviceProvider">Service provider to use to display error message.</param>
            <param name="ex">Exception to handle.</param>
            <returns>True if exception is critical and can't be ignored.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.CriticalException.DisableExceptionFilter">
            <summary>
            	Gets whether exception filtering is disabled base on registry settings.
            </summary>
        </member>
    </members>
</doc>
