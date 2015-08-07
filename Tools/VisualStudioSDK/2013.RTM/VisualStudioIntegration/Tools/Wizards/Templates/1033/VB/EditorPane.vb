Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports Microsoft.VisualStudio
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop
Imports Microsoft.VisualStudio.TextManager.Interop
Imports Microsoft.VisualStudio.Shell
Imports EnvDTE
Imports tom

Imports ISysServiceProvider = System.IServiceProvider
Imports IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider
Imports VSStd97CmdID = Microsoft.VisualStudio.VSConstants.VSStd97CmdID

''' <summary>
''' This control host the editor (an extended RichTextBox) and is responsible for
''' handling the commands targeted to the editor as well as saving and loading
''' the document. This control also implement the search and replace functionalities.
''' </summary>

'/////////////////////////////////////////////////////////////////////////////
' Having an entry in the new file dialog.
'
' For our file type should appear under "General" in the new files dialog, we need the following:-
'     - A .vsdir file in the same directory as NewFileItems.vsdir (generally under Common7\IDE\NewFileItems).
'       In our case the file name is Editor.vsdir but we only require a file with .vsdir extension.
'     - An empty %Extension% file in the same directory as NewFileItems.vsdir. In
'       our case we chose %DefaultName%.%Extension%. Note this file name appears in Editor.vsdir
'       (see vsdir file format below)
'     - Three text strings in our language specific resource. File Resources.resx :-
'          - "Rich Text file" - this is shown next to our icon.
'          - "A blank rich text file" - shown in the description window
'             in the new file dialog.
'          - "%DefaultName%" - This is the base file name. New files will initially
'             be named as %DefaultName%1.%Extension%, %DefaultName%2.%Extension%... etc.
'/////////////////////////////////////////////////////////////////////////////
' Editor.vsdir contents:-
'    %DefaultName%.%Extension%|{3085E1D6-A938-478e-BE49-3546C09A1AB1}|#106|80|#109|0|401|0|#107
'
' The fields in order are as follows:-
'    - %DefaultName%.%Extension% - our empty %Extension% file
'    - {3085E1D6-A938-478e-BE49-3546C09A1AB1} - our Editor package guid
'    - #106 - the ID of "Rich Text file" in the resource
'    - 80 - the display ordering priority
'    - #109 - the ID of "A blank rich text file" in the resource
'    - 0 - resource dll string (we don't use this)
'    - 401 - the ID of our icon
'    - 0 - various flags (we don't use this - se vsshell.idl)
'    - #107 - the ID of "%Extension%"
'/////////////////////////////////////////////////////////////////////////////

'This is required for Find In files scenario to work properly. This provides a connection point 
'to the event interface
'IVsPersistDocData: Enable persistence functionality for document data
'IPersistFileFormat: Enable the programmatic loading or saving of an object in a format specified by the user.
'IVsFileChangeEvents: Notify the client when file changes on disk
'IVsDocDataFileChangeControl: Determine whether changes to files made outside 
'                             of the editor should be ignored
'IVsFileBackup: Support backup of files. Visual Studio File Recovery 
'               backs up all objects in the Running Document Table that 
'               support IVsFileBackup and have unsaved changes.
'IVsStatusbarUser: Support updating the status bar
'IVsFindTarget: Implement find and replace capabilities within the editor
'IVsTextImage: Support find and replace in a text image
'IVsTextSpanSet: Support find and replace in a text image
'IVsTextBuffer: Needed for Find and Replace to work appropriately
'IVsTextView: Needed for Find and Replace to work appropriately
'IVsCodeWindow: Needed for Find and Replace to work appropriately
'IVsTextLines: Needed for Find and Replace to work appropriately
'IExtensibleObject: Supply the Automation object
'IEditor: Automation interface for Editor
'IVsToolboxUser: Sends notification about Toolbox items to the owner of these items
<ComSourceInterfaces(GetType(IVsTextViewEvents)), ComVisible(True), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")> _
Public NotInheritable Class EditorPane
    Inherits Microsoft.VisualStudio.Shell.WindowPane
    Implements IVsPersistDocData, IPersistFileFormat, IVsFileChangeEvents, IVsDocDataFileChangeControl, IVsFileBackup, IVsStatusbarUser, IVsFindTarget, IVsTextImage, IVsTextSpanSet, IVsTextBuffer, IVsTextView, IVsCodeWindow, IVsTextLines, IExtensibleObject, IEditor, IVsToolboxUser
    Private Const MyFormat As UInteger = 0
    Private Const MyExtension As String = ".%Extension%"
    Private Shared fontSizeArray As String() = {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72"}

    Private Class EditorProperties
        Private editor As EditorPane
        Public Sub New(ByVal Editor As EditorPane)
            Me.editor = Editor
        End Sub

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        Public ReadOnly Property FileName() As String
            Get
                Return editor.FileName
            End Get
        End Property

        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
        Public ReadOnly Property DataChanged() As Boolean
            Get
                Return editor.DataChanged
            End Get
        End Property
    End Class

#Region "Fields"
    Private myPackage As %ProjectClass%Package

    Private fileName_Renamed As String = String.Empty
    Private isDirty_Renamed As Boolean
    ' Flag true when we are loading the file. It is used to avoid to change the isDirty flag
    ' when the changes are related to the load operation.
    Private loading As Boolean
    ' This flag is true when we are asking the QueryEditQuerySave service if we can edit the
    ' file. It is used to avoid to have more than one request queued.
    Private gettingCheckoutStatus As Boolean
    Private editorControl As MyEditor

    Private selContainer As Microsoft.VisualStudio.Shell.SelectionContainer
    Private trackSel As ITrackSelection
    Private vsFileChangeEx As IVsFileChangeEx

    Private FileChangeTrigger As Timer = New Timer()

    Private FNFStatusbarTrigger As Timer = New Timer()

    Private fileChangedTimerSet As Boolean
    Private ignoreFileChangeLevel As Integer
    Private backupObsolete As Boolean = True
    Private vsFileChangeCookie As UInteger
    Private fontListArray As String()

    Private findState As Object
    Private lockImage_Renamed As Boolean
    Private textSpanArray As ArrayList = New ArrayList()
    Private spTextImage As IVsTextImage

    Private extensibleObjectSite As IExtensibleObjectSite

#End Region

#Region "Window.Pane Overrides"
    ''' <summary>
    ''' Constructor that calls the Microsoft.VisualStudio.Shell.WindowPane constructor then
    ''' our initialization functions.
    ''' </summary>
    ''' <param name="package">Our %ProjectClass%Package instance.</param>
    Public Sub New(ByVal package As %ProjectClass%Package)
        MyBase.New(Nothing)
        PrivateInit(package)
    End Sub

    Protected Overrides Sub OnClose()
        editorControl.StopRecorder()

        MyBase.OnClose()
    End Sub

    ''' <summary>
    ''' This is a required override from the Microsoft.VisualStudio.Shell.WindowPane class.
    ''' It returns the extended rich text box that we host.
    ''' </summary>
    Public Overrides ReadOnly Property Window() As IWin32Window
        Get
            Return Me.editorControl
        End Get
    End Property
#End Region

    ''' <summary>
    ''' Initialization routine for the Editor. Loads the list of properties for the %Extension% document 
    ''' which will show up in the properties window 
    ''' </summary>
    ''' <param name="package"></param>
    Private Sub PrivateInit(ByVal package As %ProjectClass%Package)
        myPackage = package
        loading = False
        gettingCheckoutStatus = False
        trackSel = Nothing

        Control.CheckForIllegalCrossThreadCalls = False
        ' Create an ArrayList to store the objects that can be selected
        Dim listObjects As New ArrayList()

        ' Create the object that will show the document's properties
        ' on the properties window.
        Dim prop As New EditorProperties(Me)
        listObjects.Add(prop)

        ' Create the SelectionContainer object.
        selContainer = New Microsoft.VisualStudio.Shell.SelectionContainer(True, False)
        selContainer.SelectableObjects = listObjects
        selContainer.SelectedObjects = listObjects

        ' Create and initialize the editor

        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(EditorPane))
        Me.editorControl = New MyEditor()

        resources.ApplyResources(Me.editorControl, "editorControl", CultureInfo.CurrentUICulture)
        ' Event handlers for macro recording.
        AddHandler editorControl.RichTextBoxControl.TextChanged, AddressOf OnTextChange
        AddHandler editorControl.RichTextBoxControl.MouseDown, AddressOf OnMouseClick
        AddHandler editorControl.RichTextBoxControl.SelectionChanged, AddressOf OnSelectionChanged
        AddHandler editorControl.RichTextBoxControl.KeyDown, AddressOf OnKeyDown

        ' Handle Focus event
        AddHandler editorControl.RichTextBoxControl.GotFocus, AddressOf OnGotFocus

        ' Call the helper function that will do all of the command setup work
        setupCommands()
    End Sub

    ''' <summary>
    ''' returns the name of the file currently loaded
    ''' </summary>
    Public ReadOnly Property FileName() As String
        Get
            Return fileName_Renamed
        End Get
    End Property

    ''' <summary>
    ''' returns whether the contents of file have changed since the last save
    ''' </summary>
    Public ReadOnly Property DataChanged() As Boolean
        Get
            Return isDirty_Renamed
        End Get
    End Property

    ''' <summary>
    ''' returns an instance of the ITrackSelection service object
    ''' </summary>
    Private ReadOnly Property TrackSelection() As ITrackSelection
        Get
            If trackSel Is Nothing Then
                trackSel = CType(GetService(GetType(ITrackSelection)), ITrackSelection)
            End If
            Return trackSel
        End Get
    End Property

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly")> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then

                If Nothing IsNot editorControl And Nothing IsNot editorControl.RichTextBoxControl Then
                    RemoveHandler editorControl.RichTextBoxControl.TextChanged, AddressOf OnTextChange
                    RemoveHandler editorControl.RichTextBoxControl.MouseDown, AddressOf OnMouseClick
                    RemoveHandler editorControl.RichTextBoxControl.SelectionChanged, AddressOf OnSelectionChanged
                    RemoveHandler editorControl.RichTextBoxControl.KeyDown, AddressOf OnKeyDown
                    RemoveHandler editorControl.RichTextBoxControl.GotFocus, AddressOf OnGotFocus
                End If

                ' Dispose the timers
                If Nothing IsNot FileChangeTrigger Then
                    FileChangeTrigger.Dispose()
                    FileChangeTrigger = Nothing
                End If
                If Nothing IsNot FNFStatusbarTrigger Then
                    FNFStatusbarTrigger.Dispose()
                    FNFStatusbarTrigger = Nothing
                End If

                SetFileChangeNotification(Nothing, False)

                If editorControl IsNot Nothing Then
                    editorControl.RichTextBoxControl.Dispose()
                    editorControl.Dispose()
                    editorControl = Nothing
                End If
                If FileChangeTrigger IsNot Nothing Then
                    FileChangeTrigger.Dispose()
                    FileChangeTrigger = Nothing
                End If
                If extensibleObjectSite IsNot Nothing Then
                    extensibleObjectSite.NotifyDelete(Me)
                    extensibleObjectSite = Nothing
                End If
                GC.SuppressFinalize(Me)
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ''' <summary>
    ''' Gets an instance of the RunningDocumentTable (RDT) service which manages the set of currently open 
    ''' documents in the environment and then notifies the client that an open document has changed
    ''' </summary>
    Private Sub NotifyDocChanged()
        ' Make sure that we have a file name
        If fileName_Renamed.Length = 0 Then
            Return
        End If

        ' Get a reference to the Running Document Table
        Dim runningDocTable As IVsRunningDocumentTable = CType(GetService(GetType(SVsRunningDocumentTable)), IVsRunningDocumentTable)

        ' Lock the document
        Dim docCookie As UInteger
        Dim hierarchy As IVsHierarchy = Nothing
        Dim itemID As UInteger
        Dim docData As IntPtr = IntPtr.Zero
        
        Try
            Dim hr As Integer = runningDocTable.FindAndLockDocument(CUInt(_VSRDTFLAGS.RDT_ReadLock), fileName_Renamed, hierarchy, itemID, docData, docCookie)
            ErrorHandler.ThrowOnFailure(hr)

            ' Send the notification
            hr = runningDocTable.NotifyDocumentChanged(docCookie, CUInt(__VSRDTATTRIB.RDTA_DocDataReloaded))

            ' Unlock the document.
            ' Note that we have to unlock the document even if the previous call failed.
            ErrorHandler.ThrowOnFailure(runningDocTable.UnlockDocument(CUInt(_VSRDTFLAGS.RDT_ReadLock), docCookie))

            ' Check ff the call to NotifyDocChanged failed.
            ErrorHandler.ThrowOnFailure(hr)
        Finally
            If docData <> IntPtr.Zero Then
                Marshal.Release(docData)
            End If
        End Try
    End Sub

    ''' <summary>
    ''' This is an added command handler that will make it so the ITrackSelection.OnSelectChange
    ''' function gets called whenever the cursor position is changed and also so the position 
    ''' displayed on the status bar will update whenever the cursor position changes.
    ''' </summary>
    ''' <param name="sender"> Not used.</param>
    ''' <param name="e"> Not used.</param>
    Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Call the function that will update the position displayed on the status bar.
        Me.SetStatusBarPosition()

        ' Now call the OnSelectChange function using our stored TrackSelection and
        ' selContainer variables.
        Dim track As ITrackSelection = TrackSelection
        If Nothing IsNot track Then
            ErrorHandler.ThrowOnFailure(track.OnSelectChange(CType(selContainer, ISelectionContainer)))
        End If
    End Sub

#Region "Command Handling Functions"

    ''' <summary>
    ''' This helper function, which is called from the EditorPane's PrivateInit
    ''' function, does all the work involving adding commands.
    ''' </summary>
    Private Sub setupCommands()
        ' Now get the IMenuCommandService; this object is the one
        ' responsible for handling the collection of commands implemented by the package.

        Dim mcs As IMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), IMenuCommandService)
        If Nothing IsNot mcs Then
            ' Now create one object derived from MenuCommnad for each command defined in
            ' the CTC file and add it to the command service.

            ' For each command we have to define its id that is a unique Guid/integer pair, then
            ' create the OleMenuCommand object for this command. The EventHandler object is the
            ' function that will be called when the user will select the command. Then we add the 
            ' OleMenuCommand to the menu service.  The addCommand helper function does all this for us.

            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.SelectAll)), New EventHandler(AddressOf onSelectAll), Nothing)
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Copy)), New EventHandler(AddressOf onCopy), New EventHandler(AddressOf onQueryCopy))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Cut)), New EventHandler(AddressOf onCut), New EventHandler(AddressOf onQueryCutOrDelete))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Paste)), New EventHandler(AddressOf onPaste), New EventHandler(AddressOf onQueryPaste))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Delete)), New EventHandler(AddressOf onDelete), New EventHandler(AddressOf onQueryCutOrDelete))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Undo)), New EventHandler(AddressOf onUndo), New EventHandler(AddressOf onQueryUndo))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Redo)), New EventHandler(AddressOf onRedo), New EventHandler(AddressOf onQueryRedo))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Bold)), New EventHandler(AddressOf onBold), New EventHandler(AddressOf onQueryBold))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Italic)), New EventHandler(AddressOf onItalic), New EventHandler(AddressOf onQueryItalic))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.Underline)), New EventHandler(AddressOf onUnderline), New EventHandler(AddressOf onQueryUnderline))
            addCommand(mcs, GuidList.guid%ProjectClass%CmdSet, CInt(Fix(PkgCmdIDList.icmdStrike)), New EventHandler(AddressOf onStrikethrough), New EventHandler(AddressOf onQueryStrikethrough))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.JustifyCenter)), New EventHandler(AddressOf onJustifyCenter), New EventHandler(AddressOf onQueryJustifyCenter))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.JustifyLeft)), New EventHandler(AddressOf onJustifyLeft), New EventHandler(AddressOf onQueryJustifyLeft))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.JustifyRight)), New EventHandler(AddressOf onJustifyRight), New EventHandler(AddressOf onQueryJustifyRight))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.FontNameGetList)), New EventHandler(AddressOf onFontNameGetList), Nothing)
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.FontName)), New EventHandler(AddressOf onFontName), Nothing)
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.FontSizeGetList)), New EventHandler(AddressOf onFontSizeGetList), Nothing)
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.FontSize)), New EventHandler(AddressOf onFontSize), Nothing)
            addCommand(mcs, VSConstants.VSStd2K, CInt(Fix(VSConstants.VSStd2KCmdID.BULLETEDLIST)), New EventHandler(AddressOf onBulletedList), New EventHandler(AddressOf onQueryBulletedList))
            ' Support clipboard rings
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.PasteNextTBXCBItem)), New EventHandler(AddressOf onPasteNextTBXCBItem), New EventHandler(AddressOf onQueryPasteNextTBXCBItem))

            ' These two commands enable Visual Studio's default undo/redo toolbar buttons.  When these
            ' buttons are clicked it triggers a multi-level undo/redo (even when we are undoing/redoing
            ' only one action.  Note that we are not implementing the multi-level undo/redo functionality,
            ' we are just adding a handler for this command so these toolbar buttons are enabled (Note that
            ' we are just reusing the undo/redo command handlers).  To implement multi-level functionality
            ' we would need to properly handle these two commands as well as MultiLevelUndoList and
            ' MultiLevelRedoList.
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.MultiLevelUndo)), New EventHandler(AddressOf onUndo), New EventHandler(AddressOf onQueryUndo))
            addCommand(mcs, VSConstants.GUID_VSStandardCommandSet97, CInt(Fix(VSConstants.VSStd97CmdID.MultiLevelRedo)), New EventHandler(AddressOf onRedo), New EventHandler(AddressOf onQueryRedo))
        End If
    End Sub

    ''' <summary>
    ''' Helper function used to add commands using IMenuCommandService
    ''' </summary>
    ''' <param name="mcs"> The IMenuCommandService interface.</param>
    ''' <param name="menuGroup"> This guid represents the menu group of the command.</param>
    ''' <param name="cmdID"> The command ID of the command.</param>
    ''' <param name="commandEvent"> An EventHandler which will be called whenever the command is invoked.</param>
    ''' <param name="queryEvent"> An EventHandler which will be called whenever we want to query the status of
    ''' the command.  If null is passed in here then no EventHandler will be added.</param>
    Private Shared Sub addCommand(ByVal mcs As IMenuCommandService, ByVal menuGroup As Guid, ByVal cmdID As Integer, ByVal commandEvent As EventHandler, ByVal queryEvent As EventHandler)
        ' Create the OleMenuCommand from the menu group, command ID, and command event
        Dim menuCommandID As New CommandID(menuGroup, cmdID)
        Dim command As New OleMenuCommand(commandEvent, menuCommandID)

        ' Add an event handler to BeforeQueryStatus if one was passed in
        If Nothing IsNot queryEvent Then
            AddHandler command.BeforeQueryStatus, queryEvent
        End If

        ' Add the command using our IMenuCommandService instance
        mcs.AddCommand(command)
    End Sub

    ''' <summary>
    ''' Handler for out SelectAll command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onSelectAll(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.SelectAll()
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the copy command.  If there
    ''' is any text selected then it will set the Enabled property to true.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryCopy(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        If editorControl.RichTextBoxControl.SelectionLength > 0 Then
            command.Enabled = True
        Else
            command.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Handler for our Copy command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onCopy(ByVal sender As Object, ByVal e As EventArgs)
        Copy()
        editorControl.RecordCommand("Copy")
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the cut or delete
    ''' commands.  If there is any selected text then it will set the 
    ''' enabled property to true.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryCutOrDelete(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        If editorControl.RichTextBoxControl.SelectionLength > 0 Then
            command.Enabled = True
        Else
            command.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Handler for our Cut command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onCut(ByVal sender As Object, ByVal e As EventArgs)
        Cut()
        editorControl.RecordCommand("Cut")
    End Sub

    ''' <summary>
    ''' Handler for our Delete command.
    ''' </summary>
    Private Sub onDelete(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.SelectedText = ""
        editorControl.RecordCommand("Delete")
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the paste command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryPaste(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Enabled = editorControl.RichTextBoxControl.CanPaste(DataFormats.GetFormat(DataFormats.Text))
    End Sub

    ''' <summary>
    ''' Handler for our Paste command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onPaste(ByVal sender As Object, ByVal e As EventArgs)
        Paste()
        editorControl.RecordCommand("Paste")
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the clipboard ring.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryPasteNextTBXCBItem(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the Toolbox Service from the package
        Dim clipboardCycler As IVsToolboxClipboardCycler = TryCast(GetService(GetType(SVsToolbox)), IVsToolboxClipboardCycler)

        Dim itemsAvailable As Integer
        ErrorHandler.ThrowOnFailure(clipboardCycler.AreDataObjectsAvailable(CType(Me, IVsToolboxUser), itemsAvailable))

        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        If (itemsAvailable > 0) Then
            command.Enabled = (True)
        Else
            command.Enabled = (False)
        End If
    End Sub

    ''' <summary>
    ''' Handler for our Paste command.
    ''' </summary>
    ''' <param name="sender">  Not used.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onPasteNextTBXCBItem(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the Toolbox Service from the package
        Dim clipboardCycler As IVsToolboxClipboardCycler = TryCast(GetService(GetType(SVsToolbox)), IVsToolboxClipboardCycler)

        Dim pDO As Microsoft.VisualStudio.OLE.Interop.IDataObject = Nothing

        ErrorHandler.ThrowOnFailure(clipboardCycler.GetAndSelectNextDataObject(CType(Me, IVsToolboxUser), pDO))

        Dim textSelection As ITextSelection = editorControl.TextDocument.Selection

        ' Get the current position of the start of the current selection. 
        ' After the paste the positiono of the start of current selection
        ' will be moved to the end of inserted text, so it needs to
        ' move back to original position so that inserted text can be highlighted to 
        ' allow cycling through our clipboard items.
        Dim originalStart As Integer
        originalStart = textSelection.Start

        ' This will do the actual pasting of the object
        ItemPicked(pDO)

        ' Now move the start position backwards to the original position.
        Dim currentStart As Integer
        currentStart = textSelection.Start
        textSelection.MoveStart(CInt(Fix(tom.tomConstants.tomCharacter)), originalStart - currentStart)

        ' Select the pasted text
        textSelection.Select()
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the Undo command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryUndo(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Enabled = editorControl.RichTextBoxControl.CanUndo
    End Sub

    ''' <summary>
    ''' Handler for our Undo command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onUndo(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.Undo()
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the Redo command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryRedo(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Enabled = editorControl.RichTextBoxControl.CanRedo
    End Sub

    ''' <summary>
    ''' Handler for our Redo command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onRedo(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.Redo()
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the Bold command.  It will
    ''' always be enabled, but we want to check if the current text is bold or not
    ''' so we can set the Checked property which will change how the button looks
    ''' in the toolbar and the context menu.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryBold(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = editorControl.RichTextBoxControl.SelectionFont.Bold
    End Sub

    ''' <summary>
    ''' Handler for our Bold command.  Toggles the bold state of the selected text.
    ''' Or if there is no selected text then it toggles the bold state for 
    ''' newly entered text.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onBold(ByVal sender As Object, ByVal e As EventArgs)
        setFontStyle(FontStyle.Bold, editorControl.RichTextBoxControl.SelectionFont.Bold)
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the Italic command.  It will
    ''' always be enabled, but we want to check if the current text is Italic or not
    ''' so we can set the Checked property which will change how the button looks
    ''' in the toolbar and the context menu.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryItalic(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = editorControl.RichTextBoxControl.SelectionFont.Italic
    End Sub

    ''' <summary>
    ''' Handler for our Italic command.  Toggles the italic state of the selected text.
    ''' Or if there is no selected text then it toggles the italic state for 
    ''' newly entered text.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onItalic(ByVal sender As Object, ByVal e As EventArgs)
        setFontStyle(FontStyle.Italic, editorControl.RichTextBoxControl.SelectionFont.Italic)
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the Underline command.  It will
    ''' always be enabled, but we want to check if the current text is underlined or not
    ''' so we can set the Checked property which will change how the button looks
    ''' in the toolbar and the context menu.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryUnderline(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = editorControl.RichTextBoxControl.SelectionFont.Underline
    End Sub

    ''' <summary>
    ''' Handler for our Underline command.  Toggles the underline state of the selected
    ''' text.  Or if there is no selected text then it toggles the underline state for 
    ''' newly entered text.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onUnderline(ByVal sender As Object, ByVal e As EventArgs)
        setFontStyle(FontStyle.Underline, editorControl.RichTextBoxControl.SelectionFont.Underline)
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the Strikethrough command.  It will
    ''' always be enabled, but we want to check if the current text has Strikethrough or not
    ''' so we can set the Checked property which will change how the button looks
    ''' in the toolbar and the context menu.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryStrikethrough(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = editorControl.RichTextBoxControl.SelectionFont.Strikeout
    End Sub

    ''' <summary>
    ''' Handler for our Strikethrough command.  Toggles the strikethrough state of 
    ''' the selected text.  Or if there is no selected text then it toggles the 
    ''' strikethrough state for newly entered text.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onStrikethrough(ByVal sender As Object, ByVal e As EventArgs)
        setFontStyle(FontStyle.Strikeout, editorControl.RichTextBoxControl.SelectionFont.Strikeout)
    End Sub

    ''' <summary>
    ''' This helper function is called when we need to toggle the states bold,
    ''' underline, italic or strikeout.
    ''' </summary>
    ''' <param name="fontStyleToSet"> Which FontStyle to toggle (bold, italic, underline or strikeout).</param>
    ''' <param name="currentStateOn"> The current state of the font style.  If this is true then we
    ''' will turn the font style off and if it is false we will turn it on.</param>
    Private Sub setFontStyle(ByVal fontStyleToSet As FontStyle, ByVal currentStateOn As Boolean)
        ' Figure out what the new FontStyle should be based on the current one
        Dim fs As FontStyle
        If currentStateOn Then
            fs = editorControl.RichTextBoxControl.SelectionFont.Style And ((Not fontStyleToSet))
        Else
            fs = editorControl.RichTextBoxControl.SelectionFont.Style Or fontStyleToSet
        End If

        ' Create the new Font based on the current one and fs then set it
        Dim f As New Font(editorControl.RichTextBoxControl.SelectionFont, fs)
        editorControl.RichTextBoxControl.SelectionFont = f

        If f IsNot Nothing Then
            f.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the justify center command.  It will
    ''' always be enabled, but we want to check if the current text is center-justified or not
    ''' so we can set the Checked property which will change how the button looks in the toolbar.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryJustifyCenter(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = (editorControl.RichTextBoxControl.SelectionAlignment = HorizontalAlignment.Center)
    End Sub

    ''' <summary>
    ''' Handler for our Justify Center command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onJustifyCenter(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the justify left command.  It will
    ''' always be enabled, but we want to check if the current text is left-justified or not
    ''' so we can set the Checked property which will change how the button looks in the toolbar.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryJustifyLeft(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = (editorControl.RichTextBoxControl.SelectionAlignment = HorizontalAlignment.Left)
    End Sub

    ''' <summary>
    ''' Handler for our Justify Left command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onJustifyLeft(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the justify right command.  It will
    ''' always be enabled, but we want to check if the current text is right-justified or not
    ''' so we can set the Checked property which will change how the button looks in the toolbar.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryJustifyRight(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = (editorControl.RichTextBoxControl.SelectionAlignment = HorizontalAlignment.Right)
    End Sub

    ''' <summary>
    ''' Handler for our Justify Right command.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onJustifyRight(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    ''' <summary>
    ''' Helper function that fills the fontList array (of strings) with
    ''' all the available fonts.
    ''' </summary>
    Private Sub fillFontList()
        Dim fontFamilies As FontFamily()

        Dim installedFontCollection As New System.Drawing.Text.InstalledFontCollection()

        ' Get the array of FontFamily objects.
        fontFamilies = installedFontCollection.Families

        ' Create the font list array and fill it with the list of available fonts.
        fontListArray = New String(fontFamilies.Length - 1) {}
        For i As Integer = 0 To fontFamilies.Length - 1
            fontListArray(i) = fontFamilies(i).Name
        Next i
    End Sub

    ''' <summary>
    ''' This function is called when the drop down that lists the possible
    ''' fonts is clicked.  It is responsible for populating the list of fonts
    ''' with strings.  The fillFontList function is responsible for getting the
    ''' list of possible fonts and will be called from here the first time
    ''' this function is called.  Note that we use the EventArgs parameter to
    ''' pass back the list after casting it to an OleMenuCmdEventArgs object.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  We will cast this to an OleMenuCommandEventArgs
    ''' object and then use it to pass back the array of strings.</param>
    Private Sub onFontNameGetList(ByVal sender As Object, ByVal e As EventArgs)
        ' If this is the first time we are calling this function then
        ' we need to set up the fontListArray
        If Me.fontListArray Is Nothing Then
            fillFontList()
        End If

        ' Cast the EventArgs to an OleMenuCmdEventArgs object
        Dim args As OleMenuCmdEventArgs = CType(e, OleMenuCmdEventArgs)

        ' Set the out value of the OleMenuCmdEventArgs to our font list array
        Marshal.GetNativeVariantForObject(fontListArray, args.OutValue)
    End Sub

    ''' <summary>
    ''' This function will be called for two separate reasons.  It will be called constantly
    ''' to figure out what string needs to be displayed in the font name combo box.  In this
    ''' case we need to cast the EventArgs to OleMenuCmdEventArgs and set the OutValue to
    ''' the name of the currently used font.  It will also be called when the user selects a new
    ''' font.  In this case we need to cast EventArgs to OleMenuCmdEventArgs so that we can get the
    ''' name of the new font from InValue and set it for our hosted text editor.
    ''' </summary>
    ''' <param name="sender"> This can be cast to an OleMenuCommand.</param>
    ''' <param name="e"> We will cast this to an OleMenuCommandEventArgs and use it in
    ''' two ways.  If we are setting a new font we will get its name by casting the
    ''' InValue to a string.  Otherwise we will just set the OutValue to the name
    ''' of the current font.</param>
    Private Sub onFontName(ByVal sender As Object, ByVal e As EventArgs)
        Dim args As OleMenuCmdEventArgs = CType(e, OleMenuCmdEventArgs)

        ' If args.InValue is null then we just need to set the OutValue
        ' to the current font.  If it is not null then that means that we
        ' need to cast it to a string and set it as the font.
        If Nothing Is args.InValue Then
            Dim currentFont As String = editorControl.RichTextBoxControl.SelectionFont.FontFamily.Name
            Marshal.GetNativeVariantForObject(currentFont, args.OutValue)
        Else
            Dim fontName As String = CStr(args.InValue)
            Dim f As New Font(fontName, editorControl.RichTextBoxControl.SelectionFont.Size, editorControl.RichTextBoxControl.SelectionFont.Style)
            editorControl.RichTextBoxControl.SelectionFont = f

            If f IsNot Nothing Then
                f.Dispose()
            End If
        End If
    End Sub

    ''' <summary>
    ''' This function is called when the drop down that lists the possible
    ''' font sizes is clicked.  It is responsible for populating the list
    ''' with strings.  The static string array fontSizeArray is filled with the most
    ''' commonly used font sizes, although the user can enter any number they want. 
    ''' Note that we use the EventArgs parameter to pass back the list after
    ''' casting it to an OleMenuCmdEventArgs object.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  We will cast this to an OleMenuCommandEventArgs
    ''' object and then use it to pass back the array of strings.</param>
    Private Sub onFontSizeGetList(ByVal sender As Object, ByVal e As EventArgs)
        ' Cast the EventArgs to an OleMenuCmdEventArgs object
        Dim args As OleMenuCmdEventArgs = CType(e, OleMenuCmdEventArgs)

        ' Set the out value of the OleMenuCmdEventArgs to our font size array
        Marshal.GetNativeVariantForObject(fontSizeArray, args.OutValue)
    End Sub

    ''' <summary>
    ''' This function will be called for two separate reasons.  It will be called constantly
    ''' to figure out what string needs to be displayed in the font size combo box.  In this
    ''' case we need to cast the EventArgs to OleMenuCmdEventArgs and set the OutValue to
    ''' the current font size.  It will also be called when the user changes the font size.
    ''' In this case we need to cast EventArgs to OleMenuCmdEventArgs so that we can get the
    ''' new font size and set it for our hosted text editor.
    ''' </summary>
    ''' <param name="sender"> This can be cast to an OleMenuCommand.</param>
    ''' <param name="e"> We will cast this to an OleMenuCommandEventArgs and use it in
    ''' two ways.  If we are setting a new font size we will get its name by casting the
    ''' InValue to a string.  Otherwise we will just set the OutValue to the current 
    ''' font size.</param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId:="System.Convert.ToString(System.Int32)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId:="System.Convert.ToSingle(System.String)")> _
    Private Sub onFontSize(ByVal sender As Object, ByVal e As EventArgs)
        Dim args As OleMenuCmdEventArgs = CType(e, OleMenuCmdEventArgs)

        ' If args.InValue is null then we just need to set the OutValue
        ' to the current font size.  If it is not null then that means that we
        ' need to cast it to a string and set it as the new font size.
        If Nothing Is args.InValue Then
            Dim currentSize As String = Convert.ToString(Convert.ToInt32(editorControl.RichTextBoxControl.SelectionFont.Size), CultureInfo.InvariantCulture)
            Marshal.GetNativeVariantForObject(currentSize, args.OutValue)
        Else
            Dim fontSize As String = CStr(args.InValue)
            Dim f As New Font(editorControl.RichTextBoxControl.SelectionFont.FontFamily, Convert.ToSingle(fontSize, CultureInfo.InvariantCulture), editorControl.RichTextBoxControl.SelectionFont.Style)
            editorControl.RichTextBoxControl.SelectionFont = f

            If f IsNot Nothing Then
                f.Dispose()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Handler for when we want to query the status of the justify right command.  It will
    ''' always be enabled, but we want to check if this is active in the current text so
    ''' we can change the look of the command in the toolbar and context menu.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onQueryBulletedList(ByVal sender As Object, ByVal e As EventArgs)
        Dim command As OleMenuCommand = CType(sender, OleMenuCommand)
        command.Checked = editorControl.RichTextBoxControl.SelectionBullet
    End Sub

    ''' <summary>
    ''' Handler for our Bulleted List command.  This simply toggles the state
    ''' of the SelectionBullet property.
    ''' </summary>
    ''' <param name="sender">  This can be cast to an OleMenuCommand.</param>
    ''' <param name="e">  Not used.</param>
    Private Sub onBulletedList(ByVal sender As Object, ByVal e As EventArgs)
        editorControl.RichTextBoxControl.SelectionBullet = Not editorControl.RichTextBoxControl.SelectionBullet
    End Sub

    ''' <summary>
    ''' This is an extra command handler that we will use to intercept right
    ''' mouse click events so that we can call our function to display the
    ''' context menu.
    ''' </summary>
    Private Sub OnMouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim mouseDownLocation As New System.Drawing.Point(e.X, e.Y)

            ' Convert the point to screen coordinates and pass it into
            ' our DisplayContextMenuAt function
            Dim screenCoordinates As System.Drawing.Point = Me.editorControl.RichTextBoxControl.PointToScreen(mouseDownLocation)
            DisplayContextMenuAt(screenCoordinates)
        End If
    End Sub

    ''' <summary>
    ''' Function that we use to display our context menu.  This function
    ''' makes use of the IMenuCommandService's ShowContextMenu function.
    ''' </summary>
    ''' <param name="point"> The point that we want to display the context menu at.
    ''' Note that this must be in screen coordinates.</param>
    Private Sub DisplayContextMenuAt(ByVal point As System.Drawing.Point)
        ' Pass in the GUID:ID pair for the context menu.
        Dim contextMenuID As New CommandID(GuidList.guid%ProjectClass%CmdSet, PkgCmdIDList.IDMX_RTF)

        ' Get the OleMenuCommandService from the package
        Dim menuService As IMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), IMenuCommandService)

        If Nothing IsNot menuService Then
            ' Note: point must be in screen coordinates
            menuService.ShowContextMenu(contextMenuID, point.X, point.Y)
        End If
    End Sub

#End Region

#Region "IEditor Implementation"

    ' Note that all functions implemented here call functions from the rich
    ' edit control's text object model.

    ''' <summary>
    ''' This property gets/sets the default tab width.
    ''' </summary>
    Public Property DefaultTabStop() As Single Implements IEditor.DefaultTabStop
        Get
            Return editorControl.TextDocument.DefaultTabStop
        End Get
        Set(ByVal value As Single)
            editorControl.TextDocument.DefaultTabStop = value
        End Set
    End Property

    ''' <summary>
    ''' This property gets our editor's current ITextRange interface.  ITextRange is part
    ''' of the rich edit control's text object model.
    ''' </summary>
    Public ReadOnly Property Range() As ITextRange Implements IEditor.Range
        Get
            Return editorControl.TextRange
        End Get
    End Property

    ''' <summary>
    ''' This property gets our editor's current ITextSelection interface.  ITextSelection
    ''' is part of the rich edit control's text object model.
    ''' </summary>
    Public ReadOnly Property Selection() As ITextSelection Implements IEditor.Selection
        Get
            Return editorControl.TextSelection
        End Get
    End Property

    ''' <summary>
    ''' This property gets/sets the selection properties that contain certain information
    ''' about our editor's current selection.
    ''' </summary>
    Public Property SelectionProperties() As Integer Implements IEditor.SelectionProperties
        Get
            Return editorControl.TextSelection.Flags
        End Get
        Set(ByVal value As Integer)
            editorControl.TextSelection.Flags = value
        End Set
    End Property

    ''' <summary>
    ''' This function finds a string and returns the length of the matched string.
    ''' Note that this function does not move the cursor to the string that it finds.
    ''' </summary>
    ''' <param name="textToFind"> The string that we want to look for.</param>
    ''' <returns> The length of the matched string.</returns>
    Public Function FindText(ByVal textToFind As String) As Integer Implements IEditor.FindText
        Return editorControl.TextRange.FindText(textToFind, CInt(Fix(tom.tomConstants.tomForward)), 0)
    End Function

    ''' <summary>
    ''' This function has the same effect as typing the passed in string into the editor.
    ''' Our implementation will just call TypeText since for now we want them both to do
    ''' the same thing.
    ''' </summary>
    ''' <param name="textToSet"> The string to set/</param>
    ''' <returns> HResult that indicates success/failure.</returns>
    Public Function SetText(ByVal textToSet As String) As Integer Implements IEditor.SetText
        ' Just delegate to TypeText
        Return TypeText(textToSet)
    End Function

    ''' <summary>
    ''' This function has the same effect as typing the passed in string into the editor.
    ''' </summary>
    ''' <param name="textToType"> The string to type.</param>
    ''' <returns> HResult that indicates success/failure.</returns>
    Public Function TypeText(ByVal textToType As String) As Integer Implements IEditor.TypeText
        editorControl.TextSelection.TypeText(textToType)
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' This function performs the cut operation in the editor.
    ''' </summary>
    ''' <returns> HResult that indicates success/failure.</returns>
    Public Function Cut() As Integer Implements IEditor.Cut
        Dim o As Object = Nothing
        editorControl.TextSelection.Cut(o)
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' This function performs the copy operation in the editor.
    ''' </summary>
    ''' <returns> HResult that indicates success/failure.</returns>
    Public Function Copy() As Integer Implements IEditor.Copy
        Dim o As Object = Nothing
        editorControl.TextSelection.Copy(o)
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' This function performs the paste operation in the editor.
    ''' </summary>
    ''' <returns> HResult that indicates success/failure.</returns>
    Public Function Paste() As Integer Implements IEditor.Paste
        Dim o As Object = Nothing
        editorControl.TextSelection.Paste(o, 0)
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' This function performs a delete in the editor.
    ''' </summary>
    ''' <param name="unit"> The type of units that we are going to delete.  The two valid options
    ''' for this are TOMWord and TOMCharacter, which are defined in the TOMConstants enumeration.</param>
    ''' <param name="count"> The number of units that we are going to delete.  Passing in a negative number
    ''' will be similar to pressing backspace and passing in a positive number will be similar to
    ''' pressing delete.</param>
    ''' <returns> HResult that indicates success/failure.</returns>
    Public Function Delete(ByVal unit As Long, ByVal count As Long) As Integer Implements IEditor.Delete
        editorControl.TextSelection.Delete(CInt(Fix(unit)), CInt(Fix(count)))
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' This function will move up by the specified number of lines/paragraphs in the editor.
    ''' </summary>
    ''' <param name="unit"> The type of unit to move up by.  The two valid options for this are
    ''' TOMLine and TOMParagraph, which are defined in the TOMConstants enumeration.</param>
    ''' <param name="count"> The number of units to move.</param>
    ''' <param name="extend"> This should be set to TOMExtend if we want to select as we move
    ''' or TOMMove if we don't.  These values are defined in the TOMConstants enumeration.</param>
    ''' <returns> The number of units that the cursor moved up.</returns>
    Public Function MoveUp(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer Implements IEditor.MoveUp
        Return editorControl.TextSelection.MoveUp(unit, count, extend)
    End Function

    ''' <summary>
    ''' This function will move down by the specified number of lines/paragraphs in the editor.
    ''' </summary>
    ''' <param name="unit"> The type of unit to move down by.  The two valid options for this are
    ''' TOMLine and TOMParagraph, which are defined in the TOMConstants enumeration.</param>
    ''' <param name="count"> The number of units to move.</param>
    ''' <param name="extend"> This should be set to TOMExtend if we want to select as we move
    ''' or TOMMove if we don't.  These values are defined in the TOMConstants enumeration.</param>
    ''' <returns> The number of units that the cursor moved down.</returns>
    Public Function MoveDown(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer Implements IEditor.MoveDown
        Return editorControl.TextSelection.MoveDown(unit, count, extend)
    End Function

    ''' <summary>
    ''' This function will move to the left by the specified number of characters/words in the editor.
    ''' </summary>
    ''' <param name="unit"> The type of unit to move left by.  The two valid options for this are
    ''' TOMWord and TOMCharacter, which are defined in the TOMConstants enumeration.</param>
    ''' <param name="count"> The number of units to move.</param>
    ''' <param name="extend"> This should be set to TOMExtend if we want to select as we move
    ''' or TOMMove if we don't.  These values are defined in the TOMConstants enumeration.</param>
    ''' <returns> The number of units that the cursor moved to the left.</returns>
    Public Function MoveLeft(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer Implements IEditor.MoveLeft
        Return editorControl.TextSelection.MoveLeft(unit, count, extend)
    End Function

    ''' <summary>
    ''' This function will move to the right by the specified number of characters/words in the editor.
    ''' </summary>
    ''' <param name="unit"> The type of unit to move right by.  The two valid options for this are
    ''' TOMWord and TOMCharacter, which are defined in the TOMConstants enumeration.</param>
    ''' <param name="count"> The number of units to move.</param>
    ''' <param name="extend"> This should be set to TOMExtend if we want to select as we move
    ''' or TOMMove if we don't.  These values are defined in the TOMConstants enumeration.</param>
    ''' <returns> The number of units that the cursor moved to the right.</returns>
    Public Function MoveRight(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer Implements IEditor.MoveRight
        Return editorControl.TextSelection.MoveRight(unit, count, extend)
    End Function

    ''' <summary>
    ''' This function will either move the cursor to either the end of the current line or the end of the document.
    ''' </summary>
    ''' <param name="unit"> If this value is equal to TOMLine it will move the cursor to the end of the line.  If
    ''' it is set to TOMStory then it will move to the end of the document.  These values are defined in the
    ''' TOMConstants enumeration.</param>
    ''' <param name="extend"> This should be set to TOMExtend if we want to select as we move
    ''' or TOMMove if we don't.  These values are defined in the TOMConstants enumeration.</param>
    ''' <returns> The number of characters that the operation moved the cursor by.  This value
    ''' should always be positive since we are moving "forward" in the text buffer.</returns>
    Public Function EndKey(ByVal unit As Integer, ByVal extend As Integer) As Integer Implements IEditor.EndKey
        Return editorControl.TextSelection.EndKey(unit, extend)
    End Function

    ''' <summary>
    ''' This function will either move the cursor to either the beggining of the current line or
    ''' the beginning of the document.
    ''' </summary>
    ''' <param name="unit"> If this value is equal to TOMLine it will move the cursor to the beginning of the line.
    ''' If it is set to TOMStory then it will move to the beginning of the document.  These values are defined in the
    ''' TOMConstants enumeration.</param>
    ''' <param name="extend"> This should be set to TOMExtend if we want to select as we move
    ''' or TOMMove if we don't.  These values are defined in the TOMConstants enumeration.</param>
    ''' <returns> The number of characters that the operation moved the cursor by.  This value
    ''' should always be negative since we are moving "backward" in the text buffer.</returns>
    Public Function HomeKey(ByVal unit As Integer, ByVal extend As Integer) As Integer Implements IEditor.HomeKey
        Return editorControl.TextSelection.HomeKey(unit, extend)
    End Function

#End Region

#Region "IExtensibleObject Implementation"

    ''' <summary>
    ''' This function is used for Macro playback.  Whenever a macro gets played this function will be
    ''' called and then the IEditor functions will be called on the object that ppDisp is set to.
    ''' Since EditorPane implements IEditor we will just set it to "Me".
    ''' </summary>
    ''' <param name="Name"> Passing in either null, empty string or "Document" will work.  Anything
    ''' else will result in ppDisp being set to null.</param>
    ''' <param name="pParent"> An object of type IExtensibleObjectSite.  We will keep a reference to this
    ''' so that in the Dispose method we can call the NotifyDelete function.</param>
    ''' <param name="ppDisp"> The object that this is set to will act as the automation object for macro
    ''' playback.  In our case since IEditor is the automation interface and EditorPane
    ''' implements it we will just be setting this parameter to "Me".</param>
    Private Sub GetAutomationObject(ByVal Name As String, ByVal pParent As IExtensibleObjectSite, <System.Runtime.InteropServices.Out()> ByRef ppDisp As Object) Implements IExtensibleObject.GetAutomationObject
        ' null or empty string just means the default object, but if a specific string
        ' is specified, then make sure it's the correct one, but don't enforce case
        If (Not String.IsNullOrEmpty(Name)) AndAlso (Not Name.Equals("Document", StringComparison.CurrentCultureIgnoreCase)) Then
            ppDisp = Nothing
            Return
        End If

        ' Set the out value to "Me"
        ppDisp = CType(Me, IEditor)

        ' Store the IExtensibleObjectSite object, it will be used in the Dispose method
        extensibleObjectSite = pParent
    End Sub

#End Region

    Private Function GetClassIdentity(<System.Runtime.InteropServices.Out()> ByRef pClassID As Guid) As Integer Implements Microsoft.VisualStudio.OLE.Interop.IPersist.GetClassID
        pClassID = GuidList.guid%ProjectClass%EditorFactory
        Return VSConstants.S_OK
    End Function

#Region "IPersistFileFormat Members"

    ''' <summary>
    ''' Notifies the object that it has concluded the Save transaction
    ''' </summary>
    ''' <param name="pszFilename">Pointer to the file name</param>
    ''' <returns>S_OK if the function succeeds</returns>
    Private Function SaveCompleted(ByVal pszFilename As String) As Integer Implements IPersistFileFormat.SaveCompleted
        ' TODO:  Add Editor.SaveCompleted implementation
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Returns the path to the object's current working file 
    ''' </summary>
    ''' <param name="ppszFilename">Pointer to the file name</param>
    ''' <param name="pnFormatIndex">Value that indicates the current format of the file as a zero based index
    ''' into the list of formats. Since we support only a single format, we need to return zero. 
    ''' Subsequently, we will return a single element in the format list through a call to GetFormatList.</param>
    ''' <returns></returns>
    Private Function GetCurFile(<System.Runtime.InteropServices.Out()> ByRef ppszFilename As String, <System.Runtime.InteropServices.Out()> ByRef pnFormatIndex As UInteger) As Integer Implements IPersistFileFormat.GetCurFile
        ' We only support 1 format so return its index
        pnFormatIndex = MyFormat
        ppszFilename = fileName_Renamed
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Initialization for the object 
    ''' </summary>
    ''' <param name="nFormatIndex">Zero based index into the list of formats that indicates the current format 
    ''' of the file</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function InitNew(ByVal nFormatIndex As UInteger) As Integer Implements IPersistFileFormat.InitNew
        If nFormatIndex <> MyFormat Then
            Return VSConstants.E_INVALIDARG
        End If
        ' until someone change the file, we can consider it not dirty as
        ' the user would be annoyed if we prompt him to save an empty file
        isDirty_Renamed = False
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Returns the class identifier of the editor type
    ''' </summary>
    ''' <param name="pClassID">pointer to the class identifier</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function GetClassID(<System.Runtime.InteropServices.Out()> ByRef pClassID As Guid) As Integer Implements IPersistFileFormat.GetClassID
        ErrorHandler.ThrowOnFailure(CType(Me, Microsoft.VisualStudio.OLE.Interop.IPersist).GetClassID(pClassID))
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Provides the caller with the information necessary to open the standard common "Save As" dialog box. 
    ''' This returns an enumeration of supported formats, from which the caller selects the appropriate format. 
    ''' Each string for the format is terminated with a newline (\n) character. 
    ''' The last string in the buffer must be terminated with the newline character as well. 
    ''' The first string in each pair is a display string that describes the filter, such as "Text Only 
    ''' (*.txt)". The second string specifies the filter pattern, such as "*.txt". To specify multiple filter 
    ''' patterns for a single display string, use a semicolon to separate the patterns: "*.htm;*.html;*.asp". 
    ''' A pattern string can be a combination of valid file name characters and the asterisk (*) wildcard character. 
    ''' Do not include spaces in the pattern string. The following string is an example of a file pattern string: 
    ''' "HTML File (*.htm; *.html; *.asp)\n*.htm;*.html;*.asp\nText File (*.txt)\n*.txt\n."
    ''' </summary>
    ''' <param name="ppszFormatList">Pointer to a string that contains pairs of format filter strings</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function GetFormatList(<System.Runtime.InteropServices.Out()> ByRef ppszFormatList As String) As Integer Implements IPersistFileFormat.GetFormatList
        Dim Endline As Char = CChar(ControlChars.Lf)
        Dim FormatList As String = String.Format(CultureInfo.InvariantCulture, "My Editor (*{0}){1}*{0}{1}{1}", MyExtension, Endline)
        ppszFormatList = FormatList
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Loads the file content into the textbox
    ''' </summary>
    ''' <param name="pszFilename">Pointer to the full path name of the file to load</param>
    ''' <param name="grfMode">file format mode</param>
    ''' <param name="fReadOnly">determines if the file should be opened as read only</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function Load(ByVal pszFilename As String, ByVal grfMode As UInteger, ByVal fReadOnly As Integer) As Integer Implements IPersistFileFormat.Load
        If pszFilename Is Nothing Then
            Return VSConstants.E_INVALIDARG
        End If

        loading = True
        Dim hr As Integer = VSConstants.S_OK
        Try
            ' Show the wait cursor while loading the file
            Dim VsUiShell As IVsUIShell = CType(GetService(GetType(SVsUIShell)), IVsUIShell)
            If VsUiShell IsNot Nothing Then
                ' Note: we don't want to throw or exit if this call fails, so
                ' don't check the return code.
                hr = VsUiShell.SetWaitCursor()
            End If

            ' Load the file
            Dim str As New StreamReader(pszFilename)
            Dim rtfSignature As String = "{\rtf"
            Dim lineRead As String = Nothing
            Try
                lineRead = str.ReadLine()
            Finally
                str.Close()
            End Try
            If lineRead IsNot Nothing AndAlso lineRead.Contains(rtfSignature) Then
                'try loading with Rich Text initially
                editorControl.RichTextBoxControl.LoadFile(pszFilename, RichTextBoxStreamType.RichText)
            Else
                editorControl.RichTextBoxControl.LoadFile(pszFilename, RichTextBoxStreamType.PlainText)
            End If

            isDirty_Renamed = False

            'Determine if the file is read only on the file system
            Dim fileAttrs As FileAttributes = File.GetAttributes(pszFilename)

            Dim isReadOnly As Integer = CInt(Fix(fileAttrs)) And CInt(Fix(FileAttributes.ReadOnly))

            'Set readonly if either the file is readonly for the user or on the file system
            If 0 = isReadOnly AndAlso 0 = fReadOnly Then
                SetReadOnly(False)
            Else
                SetReadOnly(True)
            End If


            ' Notify to the property window that some of the selected objects are changed
            Dim track As ITrackSelection = TrackSelection
            If Nothing IsNot track Then
                hr = track.OnSelectChange(CType(selContainer, ISelectionContainer))
                If ErrorHandler.Failed(hr) Then
                    Return hr
                End If
            End If

            ' Hook up to file change notifications
            If String.IsNullOrEmpty(fileName_Renamed) OrElse 0 <> String.Compare(fileName_Renamed, pszFilename, True, CultureInfo.CurrentCulture) Then
                fileName_Renamed = pszFilename
                SetFileChangeNotification(pszFilename, True)

                ' Notify the load or reload
                NotifyDocChanged()
            End If
        Finally
            loading = False
        End Try
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Determines whether an object has changed since being saved to its current file
    ''' </summary>
    ''' <param name="pfIsDirty">true if the document has changed</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function IsDirty(<System.Runtime.InteropServices.Out()> ByRef pfIsDirty As Integer) As Integer Implements IPersistFileFormat.IsDirty
        If isDirty_Renamed Then
            pfIsDirty = 1
        Else
            pfIsDirty = 0
        End If
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Save the contents of the textbox into the specified file. If doing the save on the same file, we need to
    ''' suspend notifications for file changes during the save operation.
    ''' </summary>
    ''' <param name="pszFilename">Pointer to the file name. If the pszFilename parameter is a null reference 
    ''' we need to save using the current file
    ''' </param>
    ''' <param name="remember">Boolean value that indicates whether the pszFileName parameter is to be used 
    ''' as the current working file.
    ''' If remember != 0, pszFileName needs to be made the current file and the dirty flag needs to be cleared after the save.
    '''                   Also, file notifications need to be enabled for the new file and disabled for the old file 
    ''' If remember == 0, this save operation is a Save a Copy As operation. In this case, 
    '''                   the current file is unchanged and dirty flag is not cleared
    ''' </param>
    ''' <param name="nFormatIndex">Zero based index into the list of formats that indicates the format in which 
    ''' the file will be saved</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function Save(ByVal pszFilename As String, ByVal fRemember As Integer, ByVal nFormatIndex As UInteger) As Integer Implements IPersistFileFormat.Save
        Dim hr As Integer = VSConstants.S_OK
        Dim doingSaveOnSameFile As Boolean = False
        ' If file is null or same --> SAVE
        If pszFilename Is Nothing OrElse pszFilename = fileName_Renamed Then
            fRemember = 1
            doingSaveOnSameFile = True
        End If

        'Suspend file change notifications for only Save since we don't have notifications setup
        'for SaveAs and SaveCopyAs (as they are different files)
        If doingSaveOnSameFile Then
            Me.SuspendFileChangeNotification(pszFilename, 1)
        End If

        Try
            editorControl.RichTextBoxControl.SaveFile(pszFilename, RichTextBoxStreamType.RichText)
        Catch e1 As ArgumentException
            hr = VSConstants.E_FAIL
        Catch e2 As IOException
            hr = VSConstants.E_FAIL
        Finally
            'restore the file change notifications
            If doingSaveOnSameFile Then
                Me.SuspendFileChangeNotification(pszFilename, 0)
            End If
        End Try

        If VSConstants.E_FAIL = hr Then
            Return hr
        End If

        'Save and Save as
        If fRemember <> 0 Then
            'Save as
            If Nothing IsNot pszFilename AndAlso (Not fileName_Renamed.Equals(pszFilename)) Then
                SetFileChangeNotification(fileName_Renamed, False) 'remove notification from old file
                SetFileChangeNotification(pszFilename, True) 'add notification for new file
                fileName_Renamed = pszFilename 'cache the new file name
            End If
            isDirty_Renamed = False
            SetReadOnly(False) 'set read only to false since you were successfully able
            'to save to the new file                                                    
        End If

        Dim track As ITrackSelection = TrackSelection
        If Nothing IsNot track Then
            hr = track.OnSelectChange(CType(selContainer, ISelectionContainer))
        End If

        ' Since all changes are now saved properly to disk, there's no need for a backup.
        backupObsolete = False
        Return hr
    End Function

#End Region


#Region "IVsPersistDocData Members"

    ''' <summary>
    ''' Used to determine if the document data has changed since the last time it was saved
    ''' </summary>
    ''' <param name="pfDirty">Will be set to 1 if the data has changed</param>
    ''' <returns>S_OK if the function succeeds</returns>
    Private Function IsDocDataDirty(<System.Runtime.InteropServices.Out()> ByRef pfDirty As Integer) As Integer Implements IVsPersistDocData.IsDocDataDirty
        Return (CType(Me, IPersistFileFormat)).IsDirty(pfDirty)
    End Function

    ''' <summary>
    ''' Saves the document data. Before actually saving the file, we first need to indicate to the environment
    ''' that a file is about to be saved. This is done through the "SVsQueryEditQuerySave" service. We call the
    ''' "QuerySaveFile" function on the service instance and then proceed depending on the result returned as follows:
    ''' If result is QSR_SaveOK - We go ahead and save the file and the file is not read only at this point.
    ''' If result is QSR_ForceSaveAs - We invoke the "Save As" functionality which will bring up the Save file name 
    '''                                dialog 
    ''' If result is QSR_NoSave_Cancel - We cancel the save operation and indicate that the document could not be saved
    '''                                by setting the "pfSaveCanceled" flag
    ''' If result is QSR_NoSave_Continue - Nothing to do here as the file need not be saved
    ''' </summary>
    ''' <param name="dwSave">Flags which specify the file save options:
    ''' VSSAVE_Save        - Saves the current file to itself.
    ''' VSSAVE_SaveAs      - Prompts the User for a filename and saves the file to the file specified.
    ''' VSSAVE_SaveCopyAs  - Prompts the user for a filename and saves a copy of the file with a name specified.
    ''' VSSAVE_SilentSave  - Saves the file without prompting for a name or confirmation.  
    ''' </param>
    ''' <param name="pbstrMkDocumentNew">Pointer to the path to the new document</param>
    ''' <param name="pfSaveCanceled">value 1 if the document could not be saved</param>
    ''' <returns></returns>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")> _
    Private Function SaveDocData(ByVal dwSave As Microsoft.VisualStudio.Shell.Interop.VSSAVEFLAGS, <System.Runtime.InteropServices.Out()> ByRef pbstrMkDocumentNew As String, <System.Runtime.InteropServices.Out()> ByRef pfSaveCanceled As Integer) As Integer Implements IVsPersistDocData.SaveDocData
        pbstrMkDocumentNew = Nothing
        pfSaveCanceled = 0
        Dim hr As Integer = VSConstants.S_OK

        Select Case dwSave
            Case VSSAVEFLAGS.VSSAVE_Save, VSSAVEFLAGS.VSSAVE_SilentSave
                Dim queryEditQuerySave As IVsQueryEditQuerySave2 = CType(GetService(GetType(SVsQueryEditQuerySave)), IVsQueryEditQuerySave2)

                ' Call QueryEditQuerySave
                Dim result As UInteger = 0
                hr = queryEditQuerySave.QuerySaveFile(fileName_Renamed, 0, Nothing, result) ' result
                If ErrorHandler.Failed(hr) Then
                    Return hr
                End If

                ' Process according to result from QuerySave
                Select Case CType(result, tagVSQuerySaveResult)
                    Case tagVSQuerySaveResult.QSR_NoSave_Cancel
                        ' Note that this is also case tagVSQuerySaveResult.QSR_NoSave_UserCanceled because these
                        ' two tags have the same value.
                        pfSaveCanceled = Not 0

                    Case tagVSQuerySaveResult.QSR_SaveOK
                        ' Call the shell to do the save for us
                        Dim uiShell As IVsUIShell = CType(GetService(GetType(SVsUIShell)), IVsUIShell)
                        hr = uiShell.SaveDocDataToFile(dwSave, CType(Me, IPersistFileFormat), fileName_Renamed, pbstrMkDocumentNew, pfSaveCanceled)
                        If ErrorHandler.Failed(hr) Then
                            Return hr
                        End If

                    Case tagVSQuerySaveResult.QSR_ForceSaveAs
                        ' Call the shell to do the SaveAS for us
                        Dim uiShell As IVsUIShell = CType(GetService(GetType(SVsUIShell)), IVsUIShell)
                        hr = uiShell.SaveDocDataToFile(VSSAVEFLAGS.VSSAVE_SaveAs, CType(Me, IPersistFileFormat), fileName_Renamed, pbstrMkDocumentNew, pfSaveCanceled)
                        If ErrorHandler.Failed(hr) Then
                            Return hr
                        End If

                    Case tagVSQuerySaveResult.QSR_NoSave_Continue
                        ' In this case there is nothing to do.

                    Case Else
                        Throw New NotSupportedException("Unsupported result from QEQS")
                End Select
                Exit Select
            Case VSSAVEFLAGS.VSSAVE_SaveAs, VSSAVEFLAGS.VSSAVE_SaveCopyAs
                ' Make sure the file name as the right extension
                If String.Compare(MyExtension, System.IO.Path.GetExtension(fileName_Renamed), True, CultureInfo.CurrentCulture) <> 0 Then
                    fileName_Renamed &= MyExtension
                End If
                ' Call the shell to do the save for us
                Dim uiShell As IVsUIShell = CType(GetService(GetType(SVsUIShell)), IVsUIShell)
                hr = uiShell.SaveDocDataToFile(dwSave, CType(Me, IPersistFileFormat), fileName_Renamed, pbstrMkDocumentNew, pfSaveCanceled)
                If ErrorHandler.Failed(hr) Then
                    Return hr
                End If
                Exit Select
            Case Else
                Throw New ArgumentException("Unsupported Save flag")
        End Select

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Loads the document data from the file specified
    ''' </summary>
    ''' <param name="pszMkDocument">Path to the document file which needs to be loaded</param>
    ''' <returns>S_Ok if the method succeeds</returns>
    Private Function LoadDocData(ByVal pszMkDocument As String) As Integer Implements IVsPersistDocData.LoadDocData
        Return (CType(Me, IPersistFileFormat)).Load(pszMkDocument, 0, 0)
    End Function

    ''' <summary>
    ''' Used to set the initial name for unsaved, newly created document data
    ''' </summary>
    ''' <param name="pszDocDataPath">String containing the path to the document. We need to ignore this parameter
    ''' </param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function SetUntitledDocPath(ByVal pszDocDataPath As String) As Integer Implements IVsPersistDocData.SetUntitledDocPath
        Return (CType(Me, IPersistFileFormat)).InitNew(MyFormat)
    End Function

    ''' <summary>
    ''' Returns the Guid of the editor factory that created the IVsPersistDocData object
    ''' </summary>
    ''' <param name="pClassID">Pointer to the class identifier of the editor type</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function GetGuidEditorType(<System.Runtime.InteropServices.Out()> ByRef pClassID As Guid) As Integer Implements IVsPersistDocData.GetGuidEditorType
        Return (CType(Me, IPersistFileFormat)).GetClassID(pClassID)
    End Function

    ''' <summary>
    ''' Close the IVsPersistDocData object
    ''' </summary>
    ''' <returns>S_OK if the function succeeds</returns>
    Private Function CloseObj() As Integer Implements IVsPersistDocData.Close
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Determines if it is possible to reload the document data
    ''' </summary>
    ''' <param name="pfReloadable">set to 1 if the document can be reloaded</param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function IsDocDataReloadable(<System.Runtime.InteropServices.Out()> ByRef pfReloadable As Integer) As Integer Implements IVsPersistDocData.IsDocDataReloadable
        ' Allow file to be reloaded
        pfReloadable = 1
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Renames the document data
    ''' </summary>
    ''' <param name="grfAttribs"></param>
    ''' <param name="pHierNew"></param>
    ''' <param name="itemidNew"></param>
    ''' <param name="pszMkDocumentNew"></param>
    ''' <returns></returns>
    Private Function RenameDocData(ByVal grfAttribs As UInteger, ByVal pHierNew As IVsHierarchy, ByVal itemidNew As UInteger, ByVal pszMkDocumentNew As String) As Integer Implements IVsPersistDocData.RenameDocData
        ' TODO:  Add EditorPane.RenameDocData implementation
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Reloads the document data
    ''' </summary>
    ''' <param name="grfFlags">Flag indicating whether to ignore the next file change when reloading the document data.
    ''' This flag should not be set for us since we implement the "IVsDocDataFileChangeControl" interface in order to 
    ''' indicate ignoring of file changes
    ''' </param>
    ''' <returns>S_OK if the method succeeds</returns>
    Private Function ReloadDocData(ByVal grfFlags As UInteger) As Integer Implements IVsPersistDocData.ReloadDocData
        Return (CType(Me, IPersistFileFormat)).Load(fileName_Renamed, grfFlags, 0)
    End Function

    ''' <summary>
    ''' Called by the Running Document Table when it registers the document data. 
    ''' </summary>
    ''' <param name="docCookie">Handle for the document to be registered</param>
    ''' <param name="pHierNew">Pointer to the IVsHierarchy interface</param>
    ''' <param name="itemidNew">Item identifier of the document to be registered from VSITEM</param>
    ''' <returns></returns>
    Private Function OnRegisterDocData(ByVal docCookie As UInteger, ByVal pHierNew As IVsHierarchy, ByVal itemidNew As UInteger) As Integer Implements IVsPersistDocData.OnRegisterDocData
        'Nothing to do here
        Return VSConstants.S_OK
    End Function

#End Region

#Region "IVsFileChangeEvents Members"

    ''' <summary>
    ''' Notify the editor of the changes made to one or more files
    ''' </summary>
    ''' <param name="cChanges">Number of files that have changed</param>
    ''' <param name="rgpszFile">array of the files names that have changed</param>
    ''' <param name="rggrfChange">Array of the flags indicating the type of changes</param>
    ''' <returns></returns>
    Private Function FilesChanged(ByVal cChanges As UInteger, ByVal rgpszFile As String(), ByVal rggrfChange As UInteger()) As Integer Implements IVsFileChangeEvents.FilesChanged
        Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, Microsoft.VisualBasic.Constants.vbTab & "**** Inside FilesChanged ****"))

        'check the different parameters
        If 0 = cChanges OrElse Nothing Is rgpszFile OrElse Nothing Is rggrfChange Then
            Return VSConstants.E_INVALIDARG
        End If

        'ignore file changes if we are in that mode
        If ignoreFileChangeLevel <> 0 Then
            Return VSConstants.S_OK
        End If

        For i As UInteger = 0 To CType(cChanges - 1, UInteger)
            If (Not String.IsNullOrEmpty(rgpszFile(CInt(i)))) AndAlso String.Compare(rgpszFile(CInt(i)), fileName_Renamed, True, CultureInfo.CurrentCulture) = 0 Then
                ' if the readonly state (file attributes) have changed we can immediately update
                ' the editor to match the new state (either readonly or not readonly) immediately
                ' without prompting the user.
                If 0 <> (rggrfChange(CInt(i)) And CInt(Fix(_VSFILECHANGEFLAGS.VSFILECHG_Attr))) Then
                    Dim fileAttrs As FileAttributes = File.GetAttributes(fileName_Renamed)
                    Dim isReadOnly As Integer = CInt(Fix(fileAttrs)) And CInt(Fix(FileAttributes.ReadOnly))
                    SetReadOnly(isReadOnly <> 0)
                End If
                ' if it looks like the file contents have changed (either the size or the modified
                ' time has changed) then we need to prompt the user to see if we should reload the
                ' file. it is important to not synchronously reload the file inside of this FilesChanged
                ' notification. first it is possible that there will be more than one FilesChanged 
                ' notification being sent (sometimes you get separate notifications for file attribute
                ' changing and file size/time changing). also it is the preferred UI style to not
                ' prompt the user until the user re-activates the environment application window.
                ' this is why we use a timer to delay prompting the user.
                If 0 <> (rggrfChange(CInt(i)) And CInt(Fix(_VSFILECHANGEFLAGS.VSFILECHG_Time Or _VSFILECHANGEFLAGS.VSFILECHG_Size))) Then
                    If (Not fileChangedTimerSet) Then
                        FileChangeTrigger = New Timer()
                        fileChangedTimerSet = True
                        FileChangeTrigger.Interval = 1000
                        AddHandler FileChangeTrigger.Tick, AddressOf OnFileChangeEvent
                        FileChangeTrigger.Enabled = True
                    End If
                End If
            End If
        Next i

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Notify the editor of the changes made to a directory
    ''' </summary>
    ''' <param name="pszDirectory">Name of the directory that has changed</param>
    ''' <returns></returns>
    Private Function DirectoryChanged(ByVal pszDirectory As String) As Integer Implements IVsFileChangeEvents.DirectoryChanged
        'Nothing to do here
        Return VSConstants.S_OK
    End Function
#End Region

#Region "IVsDocDataFileChangeControl Members"

    ''' <summary>
    ''' Used to determine whether changes to DocData in files should be ignored or not
    ''' </summary>
    ''' <param name="fIgnore">a non zero value indicates that the file changes should be ignored
    ''' </param>
    ''' <returns></returns>
    Private Function IgnoreFileChanges(ByVal fIgnore As Integer) As Integer Implements IVsDocDataFileChangeControl.IgnoreFileChanges
        Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, Microsoft.VisualBasic.Constants.vbTab & " **** Inside IgnoreFileChanges ****"))

        If fIgnore <> 0 Then
            ignoreFileChangeLevel += 1
        Else
            If ignoreFileChangeLevel > 0 Then
                ignoreFileChangeLevel -= 1
            End If

            ' We need to check here if our file has changed from "Read Only"
            ' to "Read/Write" or vice versa while the ignore level was non-zero.
            ' This may happen when a file is checked in or out under source
            ' code control. We need to check here so we can update our caption.
            Dim fileAttrs As FileAttributes = File.GetAttributes(fileName_Renamed)
            Dim isReadOnly As Integer = CInt(Fix(fileAttrs)) And CInt(Fix(FileAttributes.ReadOnly))
            SetReadOnly(isReadOnly <> 0)
        End If
        Return VSConstants.S_OK
    End Function
#End Region

#Region "File Change Notification Helpers"

    ''' <summary>
    ''' In this function we inform the shell when we wish to receive 
    ''' events when our file is changed or we inform the shell when 
    ''' we wish not to receive events anymore.
    ''' </summary>
    ''' <param name="pszFileName">File name string</param>
    ''' <param name="fStart">TRUE indicates advise, FALSE indicates unadvise.</param>
    ''' <returns>Result of the operation</returns>
    Private Function SetFileChangeNotification(ByVal pszFileName As String, ByVal fStart As Boolean) As Integer
        Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, Microsoft.VisualBasic.Constants.vbTab & " **** Inside SetFileChangeNotification ****"))

        Dim result As Integer = VSConstants.E_FAIL

        'Get the File Change service
        If Nothing Is vsFileChangeEx Then
            vsFileChangeEx = CType(GetService(GetType(SVsFileChangeEx)), IVsFileChangeEx)
        End If
        If Nothing Is vsFileChangeEx Then
            Return VSConstants.E_UNEXPECTED
        End If

        ' Setup Notification if fStart is TRUE, Remove if fStart is FALSE.
        If fStart Then
            If vsFileChangeCookie = VSConstants.VSCOOKIE_NIL Then
                'Receive notifications if either the attributes of the file change or 
                'if the size of the file changes or if the last modified time of the file changes
                result = vsFileChangeEx.AdviseFileChange(pszFileName, CUInt(_VSFILECHANGEFLAGS.VSFILECHG_Attr Or _VSFILECHANGEFLAGS.VSFILECHG_Size Or _VSFILECHANGEFLAGS.VSFILECHG_Time), CType(Me, IVsFileChangeEvents), vsFileChangeCookie)
                If vsFileChangeCookie = VSConstants.VSCOOKIE_NIL Then
                    Return VSConstants.E_FAIL
                End If
            End If
        Else
            If vsFileChangeCookie <> VSConstants.VSCOOKIE_NIL Then
                result = vsFileChangeEx.UnadviseFileChange(vsFileChangeCookie)
                vsFileChangeCookie = VSConstants.VSCOOKIE_NIL
            End If
        End If
        Return result
    End Function

    ''' <summary>
    ''' In this function we suspend receiving file change events for
    ''' a file or we reinstate a previously suspended file depending
    ''' on the value of the given fSuspend flag.
    ''' </summary>
    ''' <param name="pszFileName">File name string</param>
    ''' <param name="fSuspend">TRUE indicates that the events needs to be suspended</param>
    ''' <returns></returns>

    Private Function SuspendFileChangeNotification(ByVal pszFileName As String, ByVal fSuspend As Integer) As Integer
        Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, Microsoft.VisualBasic.Constants.vbTab & " **** Inside SuspendFileChangeNotification ****"))

        If Nothing Is vsFileChangeEx Then
            vsFileChangeEx = CType(GetService(GetType(SVsFileChangeEx)), IVsFileChangeEx)
        End If
        If Nothing Is vsFileChangeEx Then
            Return VSConstants.E_UNEXPECTED
        End If

        If 0 = fSuspend Then
            ' we are transitioning from suspended to non-suspended state - so force a
            ' sync first to avoid asynchronous notifications of our own change
            If vsFileChangeEx.SyncFile(pszFileName) = VSConstants.E_FAIL Then
                Return VSConstants.E_FAIL
            End If
        End If

        'If we use the VSCOOKIE parameter to specify the file, then pszMkDocument parameter 
        'must be set to a null reference and vice versa 
        Return vsFileChangeEx.IgnoreFile(vsFileChangeCookie, Nothing, fSuspend)
    End Function
#End Region

#Region "IVsFileBackup Members"

    ''' <summary>
    ''' This method is used to Persist the data to a single file. On a successful backup this 
    ''' should clear up the backup dirty bit
    ''' </summary>
    ''' <param name="pszBackupFileName">Name of the file to persist</param>
    ''' <returns>S_OK if the data can be successfully persisted.
    ''' This should return STG_S_DATALOSS or STG_E_INVALIDCODEPAGE if there is no way to 
    ''' persist to a file without data loss
    ''' </returns>
    Private Function BackupFile(ByVal pszBackupFileName As String) As Integer Implements IVsFileBackup.BackupFile
        Try
            editorControl.RichTextBoxControl.SaveFile(pszBackupFileName)
            backupObsolete = False
        Catch e1 As ArgumentException
            Return VSConstants.E_FAIL
        Catch e2 As IOException
            Return VSConstants.E_FAIL
        End Try
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Used to set the backup dirty bit. This bit should be set when the object is modified 
    ''' and cleared on calls to BackupFile and any Save method
    ''' </summary>
    ''' <param name="pbObsolete">the dirty bit to be set</param>
    ''' <returns>returns 1 if the backup dirty bit is set, 0 otherwise</returns>
    Private Function IsBackupFileObsolete(<System.Runtime.InteropServices.Out()> ByRef pbObsolete As Integer) As Integer Implements IVsFileBackup.IsBackupFileObsolete
        If backupObsolete Then
            pbObsolete = 1
        Else
            pbObsolete = 0
        End If
        Return VSConstants.S_OK
    End Function

#End Region

#Region "IVsToolboxUser Interface"
    Public Function IsSupported(ByVal pDO As Microsoft.VisualStudio.OLE.Interop.IDataObject) As Integer Implements IVsToolboxUser.IsSupported
        ' Create a OleDataObject from the input interface.
        Dim oleData As New OleDataObject(pDO)
        ' && editorControl.RichTextBoxControl.CanPaste(DataFormats.GetFormat(DataFormats.UnicodeText))
        ' Check if the data object is of type UnicodeText.
        If oleData.GetDataPresent(DataFormats.UnicodeText) Then
            Return VSConstants.S_OK
        End If

        ' In all the other cases return S_FALSE
        Return VSConstants.S_FALSE
    End Function

    Public Function ItemPicked(ByVal pDO As Microsoft.VisualStudio.OLE.Interop.IDataObject) As Integer Implements IVsToolboxUser.ItemPicked
        ' Create a OleDataObject from the input interface.
        Dim oleData As New OleDataObject(pDO)

        ' Check if the picked item is the one we can paste.
        If oleData.GetDataPresent(DataFormats.UnicodeText) Then
            Dim o As Object = Nothing
            editorControl.TextSelection.Paste(o, 0)
        End If

        Return VSConstants.S_OK
    End Function
#End Region

    ''' <summary>
    ''' Used to ReadOnly property for the Rich TextBox and correspondingly update the editor caption
    ''' </summary>
    ''' <param name="_isFileReadOnly">Indicates whether the file loaded is Read Only or not</param>
    Private Sub SetReadOnly(ByVal _isFileReadOnly As Boolean)
        Me.editorControl.RichTextBoxControl.ReadOnly = _isFileReadOnly

        'update editor caption with "[Read Only]" or "" as necessary
        Dim frame As IVsWindowFrame = CType(GetService(GetType(SVsWindowFrame)), IVsWindowFrame)
        Dim editorCaption As String = ""
        If _isFileReadOnly Then
            editorCaption = Me.GetResourceString("@100")
        End If
        ErrorHandler.ThrowOnFailure(frame.SetProperty(CInt(Fix(__VSFPROPID.VSFPROPID_EditorCaption)), editorCaption))
        backupObsolete = True
    End Sub

    ''' <summary>
    ''' This event is triggered when one of the files loaded into the environment has changed outside of the
    ''' editor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OnFileChangeEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        'Disable the timer
        FileChangeTrigger.Enabled = False

        Dim message As String = Me.GetResourceString("@101") 'get the message string from the resource
        Dim VsUiShell As IVsUIShell = CType(GetService(GetType(SVsUIShell)), IVsUIShell)
        Dim result As Integer = 0
        Dim tempGuid As Guid = Guid.Empty
        If VsUiShell IsNot Nothing Then
            'Show up a message box indicating that the file has changed outside of VS environment
            ErrorHandler.ThrowOnFailure(VsUiShell.ShowMessageBox(0, tempGuid, fileName_Renamed, message, Nothing, 0, OLEMSGBUTTON.OLEMSGBUTTON_YESNOCANCEL, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, OLEMSGICON.OLEMSGICON_QUERY, 0, result))
        End If
        'if the user selects "Yes", reload the current file
        If result = CInt(Fix(DialogResult.Yes)) Then
            ErrorHandler.ThrowOnFailure(CType(Me, IVsPersistDocData).ReloadDocData(0))
        End If

        fileChangedTimerSet = False
    End Sub

    ''' <summary>
    ''' This method loads a localized string based on the specified resource.
    ''' </summary>
    ''' <param name="resourceName">Resource to load</param>
    ''' <returns>String loaded for the specified resource</returns>
    Friend Function GetResourceString(ByVal resourceName As String) As String
        Dim resourceValue As String = Nothing
        Dim resourceManager As IVsResourceManager = CType(GetService(GetType(SVsResourceManager)), IVsResourceManager)
        If resourceManager Is Nothing Then
            Throw New InvalidOperationException("Could not get SVsResourceManager service. Make sure the package is Sited before calling this method")
        End If
        Dim packageGuid As Guid = myPackage.GetType().GUID
        Dim hr As Integer = resourceManager.LoadResourceString(packageGuid, -1, resourceName, resourceValue)
        Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr)
        Return resourceValue
    End Function

    ''' <summary>
    ''' This function asks to the QueryEditQuerySave service if it is possible to
    ''' edit the file.
    ''' </summary>
    Private Function CanEditFile() As Boolean
        Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, Microsoft.VisualBasic.Constants.vbTab & "**** CanEditFile called ****"))

        ' Check the status of the recursion guard
        If gettingCheckoutStatus Then
            Return False
        End If

        Try
            ' Set the recursion guard
            gettingCheckoutStatus = True

            ' Get the QueryEditQuerySave service
            Dim queryEditQuerySave As IVsQueryEditQuerySave2 = CType(GetService(GetType(SVsQueryEditQuerySave)), IVsQueryEditQuerySave2)

            ' Now call the QueryEdit method to find the edit status of this file
            Dim documents As String() = {Me.fileName_Renamed}
            Dim result As UInteger
            Dim outFlags As UInteger

            ' Note that this function can popup a dialog to ask the user to checkout the file.
            ' When this dialog is visible, it is possible to receive other request to change
            ' the file and this is the reason for the recursion guard.
            Dim hr As Integer = queryEditQuerySave.QueryEditFiles(0, 1, documents, Nothing, Nothing, result, outFlags)
            If ErrorHandler.Succeeded(hr) AndAlso (result = CUInt(tagVSQueryEditResult.QER_EditOK)) Then
                ' In this case (and only in this case) we can return true from this function.
                Return True
            End If

        Finally
            gettingCheckoutStatus = False
        End Try
        Return False
    End Function

    ''' <summary>
    ''' This event is triggered when there contents of the file are changed inside the editor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId:="Microsoft.VisualStudio.Shell.Interop.ITrackSelection.OnSelectChange(Microsoft.VisualStudio.Shell.Interop.ISelectionContainer)")> _
    Private Sub OnTextChange(ByVal sender As Object, ByVal e As System.EventArgs)
        ' During the load operation the text of the control will change, but
        ' this change must not be stored in the status of the document.
        If (Not loading) Then
            ' The only interesting case is when we are changing the document
            ' for the first time
            If (Not isDirty_Renamed) Then
                ' Check if the QueryEditQuerySave service allow us to change the file
                If (Not CanEditFile()) Then
                    ' We can not change the file (e.g. a checkout operation failed),
                    ' so undo the change and exit.
                    editorControl.RichTextBoxControl.Undo()
                    Return
                End If

                ' It is possible to change the file, so update the status.
                isDirty_Renamed = True
                Dim track As ITrackSelection = TrackSelection
                If Nothing IsNot track Then
                    ' Note: here we don't need to check the return code.
                    track.OnSelectChange(CType(selContainer, ISelectionContainer))
                End If
                backupObsolete = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' This event is triggered when the control's GotFocus event is fired.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Mobility", "CA1601:DoNotUseTimersThatPreventPowerStateChanges")> _
    Private Sub OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Nothing Is FNFStatusbarTrigger Then
            FNFStatusbarTrigger = New Timer()
        End If

        FileChangeTrigger.Interval = 1000
        AddHandler FNFStatusbarTrigger.Tick, AddressOf OnSetStatusBar
        FNFStatusbarTrigger.Start()
    End Sub

    Private Sub OnSetStatusBar(ByVal sender As Object, ByVal e As System.EventArgs)
        FNFStatusbarTrigger.Stop()
        ErrorHandler.ThrowOnFailure(CType(Me, IVsStatusbarUser).SetInfo())
    End Sub

#Region "IVsStatusbarUser Members"

    ''' <summary>
    ''' This is the IVsStatusBarUser function that will update our status bar.
    ''' Note that the IDE calls this function only when our document window is
    ''' initially activated.
    ''' </summary>
    ''' <returns> HResult that represents success or failure.</returns>
    Private Function SetInfo() As Integer Implements IVsStatusbarUser.SetInfo
        ' Call the helper function that updates the status bar insert mode
        Dim hrSetInsertMode As Integer = SetStatusBarInsertMode()

        ' Call the helper function that updates the status bar selection mode
        Dim hrSetSelectionMode As Integer = SetStatusBarSelectionMode()

        ' Call the helper function that updates the status bar position
        Dim hrSetPosition As Integer = SetStatusBarPosition()

        If (hrSetInsertMode = VSConstants.S_OK AndAlso hrSetSelectionMode = VSConstants.S_OK AndAlso hrSetPosition = VSConstants.S_OK) Then
            Return VSConstants.S_OK
        Else
            Return VSConstants.E_FAIL
        End If
    End Function

    ''' <summary>
    ''' Helper function that updates the insert mode displayed on the status bar.
    ''' This is the text that is displayed in the right side of the status bar that
    ''' will either say INS or OVR.
    ''' </summary>
    ''' <returns> HResult that represents success or failure.</returns>
    Private Function SetStatusBarInsertMode() As Integer
        ' Get the IVsStatusBar interface
        Dim statusBar As IVsStatusbar = TryCast(GetService(GetType(SVsStatusbar)), IVsStatusbar)
        If statusBar Is Nothing Then
            Return VSConstants.E_FAIL
        End If

        ' Set the insert mode based on our editorControl.richTextBoxCtrl.Overstrike value.  If 1 is passed
        ' in then it will display OVR and if 0 is passed in it will display INS.
        Dim insertMode As Object
        If Me.editorControl.Overstrike Then
            insertMode = CObj(1)
        Else
            insertMode = CObj(0)
        End If
        Return statusBar.SetInsMode(insertMode)
    End Function

    ''' <summary>
    ''' This is an extra command handler that we will use to check when the insert
    ''' key is pressed.  Note that even if we detect that the insert key is pressed
    ''' we are not setting the handled property to true, so other event handlers will
    ''' also see it.
    ''' </summary>
    ''' <param name="sender"> Not used.</param>
    ''' <param name="e"> KeyEventArgs instance that we will use to get the key that was pressed.</param>
    Private Sub OnKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        ' If the key pressed is the insert key...
        If e.KeyValue = 45 Then
            ' Toggle our stored insert value
            Me.editorControl.Overstrike = Not Me.editorControl.Overstrike

            ' Call the function to update the status bar insert mode
            SetStatusBarInsertMode()
        End If
    End Sub

    ''' <summary>
    ''' Helper function that updates the selection mode displayed on the status
    ''' bar.  Right now we only support stream selection.
    ''' </summary>
    ''' <returns> HResult that represents success or failure.</returns>
    Private Function SetStatusBarSelectionMode() As Integer
        ' Get the IVsStatusBar interface.
        Dim statusBar As IVsStatusbar = TryCast(GetService(GetType(SVsStatusbar)), IVsStatusbar)
        If statusBar Is Nothing Then
            Return VSConstants.E_FAIL
        End If

        ' Set the selection mode.  Since we only support stream selection we will
        ' always pass in zero here.  Passing in one would make "COL" show up
        ' just to the left of the insert mode on the status bar.
        Dim selectionMode As Object = 0
        Return statusBar.SetSelMode(selectionMode)
    End Function

    ''' <summary>
    ''' Helper function that updates the cursor position displayed on the status bar.
    ''' </summary>
    ''' <returns> HResult that represents success or failure.</returns>
    Private Function SetStatusBarPosition() As Integer
        ' Get the IVsStatusBar interface.
        Dim statusBar As IVsStatusbar = TryCast(GetService(GetType(SVsStatusbar)), IVsStatusbar)
        If statusBar Is Nothing Then
            Return VSConstants.E_FAIL
        End If

        ' If there is no selection then textBox1.SelectionStart will tell us
        ' the position of the cursor.  If there is a selection then this value will tell
        ' us the position of the "left" side of the selection (the side of the selection that
        ' has the smaller index value).
        Dim startIndex As Integer = editorControl.RichTextBoxControl.SelectionStart

        ' If the cursor is at the end of the selection then we need to add the selection
        ' length to the index value.
        If (editorControl.TextSelection.Flags And CInt(Fix(tom.tomConstants.tomSelStartActive))) = 0 Then
            startIndex += editorControl.RichTextBoxControl.SelectionLength
        End If

        ' Call the function that gets the (zero-based) line index based on the buffer index.
        Dim lineNumber As Integer = editorControl.RichTextBoxControl.GetLineFromCharIndex(startIndex)

        ' To get the (zero-based) character number subtract the index of the first character
        ' on this line from the buffer index.
        Dim charNumber As Integer = startIndex - editorControl.RichTextBoxControl.GetFirstCharIndexFromLine(lineNumber)

        ' Call the SetLineChar function, making sure to add one to our line and
        ' character values since the values we get from the RichTextBox calls
        ' are zero based.
        Dim line As Object = CObj(lineNumber + 1)
        Dim chr As Object = CObj(charNumber + 1)

        ' Call the IVsStatusBar's SetLineChar function and return it's HResult
        Return statusBar.SetLineChar(line, chr)
    End Function

#End Region

#Region "IVsFindTarget Members"

    ''' <summary>
    ''' Return the object that was requested
    ''' </summary>
    ''' <param name="propid">Id of the requested object</param>
    ''' <param name="pvar">Object returned</param>
    ''' <returns>HResult</returns>
    Private Function GetProperty(ByVal propid As UInteger, <System.Runtime.InteropServices.Out()> ByRef pvar As Object) As Integer Implements IVsFindTarget.GetProperty
        pvar = Nothing

        Select Case propid
            Case CUInt(__VSFTPROPID.VSFTPROPID_DocName)
                ' Return a copy of the file name
                pvar = fileName_Renamed
                Exit Select
            Case CUInt(__VSFTPROPID.VSFTPROPID_InitialPattern), CUInt(__VSFTPROPID.VSFTPROPID_InitialPatternAggressive)
                ' Return the selected text
                GetInitialSearchString(pvar)
                'pvar = editorControl.RichTextBoxControl.SelectedText;
                Exit Select
            Case CUInt(__VSFTPROPID.VSFTPROPID_WindowFrame)
                ' Return the Window frame
                pvar = CType(GetService(GetType(SVsWindowFrame)), IVsWindowFrame)
                Exit Select
            Case CUInt(__VSFTPROPID.VSFTPROPID_IsDiskFile)
                ' We currently assume the file is on disk
                pvar = True
                Exit Select
            Case Else
                Return VSConstants.E_NOTIMPL
        End Select

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="grfOptions"></param>
    ''' <param name="ppSpans"></param>
    ''' <param name="ppTextImage"></param>
    Private Function GetSearchImage(ByVal grfOptions As UInteger, ByVal ppSpans As IVsTextSpanSet(), <System.Runtime.InteropServices.Out()> ByRef ppTextImage As IVsTextImage) As Integer Implements IVsFindTarget.GetSearchImage
        'set the IVsTextSpanSet object
        If Not Nothing Is ppSpans AndAlso ppSpans.Length > 0 Then
            ppSpans(0) = CType(Me, IVsTextSpanSet)
        End If

        'set the IVsTextImage object
        ppTextImage = CType(Me, IVsTextImage)

        'attach this text image to the span
        If Nothing IsNot ppSpans AndAlso ppSpans.Length > 0 Then
            ErrorHandler.ThrowOnFailure(ppSpans(0).AttachTextImage(ppTextImage))
        End If

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Retrieve a previously stored object
    ''' </summary>
    ''' <returns>The object that is being asked</returns>
    Private Function GetFindState(<System.Runtime.InteropServices.Out()> ByRef ppunk As Object) As Integer Implements IVsFindTarget.GetFindState
        ppunk = findState
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Search for the string in the text of our editor.
    ''' Options specify how we do the search. No need to implement this since we implement IVsTextImage
    ''' </summary>
    ''' <param name="pszSearch">Search string</param>
    ''' <param name="grfOptions">Search options</param>
    ''' <param name="fResetStartPoint">Is this a new search?</param>
    ''' <param name="pHelper">We are not using it</param>
    ''' <param name="pResult">True if we found the search string</param>
    Private Function IVsFindTarget_Find(ByVal pszSearch As String, ByVal grfOptions As UInteger, ByVal fResetStartPoint As Integer, ByVal pHelper As IVsFindHelper, <System.Runtime.InteropServices.Out()> ByRef pResult As UInteger) As Integer Implements IVsFindTarget.Find
        pResult = 0

        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' Bring the focus to a specific position in the document
    ''' </summary>
    ''' <param name="pts">Location where to move the cursor to</param>
    Private Function NavigateTo(ByVal pts As TextSpan()) As Integer Implements IVsFindTarget.NavigateTo
        Dim hr As Integer = VSConstants.S_OK

        ' Activate the window
        Dim frame As IVsWindowFrame = CType(GetService(GetType(SVsWindowFrame)), IVsWindowFrame)
        If frame IsNot Nothing Then
            hr = frame.Show()
        Else
            Return VSConstants.E_NOTIMPL
        End If

        ' Now navigate to the specified location (if any)
        If ErrorHandler.Succeeded(hr) AndAlso (Nothing IsNot pts) AndAlso (pts.Length > 0) Then
            ' first set start location
            Dim NewPosition As Integer = editorControl.RichTextBoxControl.GetFirstCharIndexFromLine(pts(0).iStartLine)
            NewPosition += pts(0).iStartIndex
            If NewPosition > editorControl.RichTextBoxControl.Text.Length Then
                NewPosition = editorControl.RichTextBoxControl.Text.Length
            End If
            editorControl.RichTextBoxControl.SelectionStart = NewPosition

            ' now set the length of the selection
            NewPosition = editorControl.RichTextBoxControl.GetFirstCharIndexFromLine(pts(0).iEndLine)
            NewPosition += pts(0).iEndIndex
            If NewPosition > editorControl.RichTextBoxControl.Text.Length Then
                NewPosition = editorControl.RichTextBoxControl.Text.Length
            End If
            Dim length As Integer = NewPosition - editorControl.RichTextBoxControl.SelectionStart
            If length >= 0 Then
                editorControl.RichTextBoxControl.SelectionLength = length
            Else
                editorControl.RichTextBoxControl.SelectionLength = 0
            End If
        End If
        Return hr
    End Function

    ''' <summary>
    ''' Get current cursor location
    ''' </summary>
    ''' <param name="pts">Current location</param>
    ''' <returns>Hresult</returns>
    Private Function GetCurrentSpan(ByVal pts As TextSpan()) As Integer Implements IVsFindTarget.GetCurrentSpan
        If Nothing Is pts OrElse 0 = pts.Length Then
            Return VSConstants.E_INVALIDARG
        End If

        pts(0).iStartIndex = editorControl.GetColumnFromIndex(editorControl.RichTextBoxControl.SelectionStart)
        pts(0).iEndIndex = editorControl.GetColumnFromIndex(editorControl.RichTextBoxControl.SelectionStart + editorControl.RichTextBoxControl.SelectionLength)
        pts(0).iStartLine = editorControl.RichTextBoxControl.GetLineFromCharIndex(editorControl.RichTextBoxControl.SelectionStart)
        pts(0).iEndLine = editorControl.RichTextBoxControl.GetLineFromCharIndex(editorControl.RichTextBoxControl.SelectionStart + editorControl.RichTextBoxControl.SelectionLength)

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Highlight a given text span. No need to implement
    ''' </summary>
    ''' <param name="pts"></param>
    ''' <returns></returns>
    Private Function MarkSpan(ByVal pts As TextSpan()) As Integer Implements IVsFindTarget.MarkSpan
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' Replace a string in the text. No need to implement since we implement IVsTextImage
    ''' </summary>
    ''' <param name="pszSearch">string containing the search text</param>
    ''' <param name="pszReplace">string containing the replacement text</param>
    ''' <param name="grfOptions">Search options available</param>
    ''' <param name="fResetStartPoint">flag to reset the search start point</param>
    ''' <param name="pHelper">IVsFindHelper interface object</param>
    ''' <param name="pfReplaced">returns whether replacement was successful or not</param>
    ''' <returns></returns>
    Private Function Replace(ByVal pszSearch As String, ByVal pszReplace As String, ByVal grfOptions As UInteger, ByVal fResetStartPoint As Integer, ByVal pHelper As IVsFindHelper, <System.Runtime.InteropServices.Out()> ByRef pfReplaced As Integer) As Integer Implements IVsFindTarget.Replace
        pfReplaced = 0

        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' Store an object that will later be returned
    ''' </summary>
    ''' <returns>The object that is being stored</returns>
    Private Function SetFindState(ByVal pUnk As Object) As Integer Implements IVsFindTarget.SetFindState
        findState = pUnk
        Return VSConstants.S_OK
    End Function


    ''' <summary>
    ''' This implementation does not use notification
    ''' </summary>
    ''' <param name="notification"></param>
    Private Function NotifyFindTarget(ByVal notification As UInteger) As Integer Implements IVsFindTarget.NotifyFindTarget
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Specify which search option we support.
    ''' </summary>
    ''' <param name="pfImage">Do we support IVsTextImage?</param>
    ''' <param name="pgrfOptions">Supported options</param>
    Private Function GetCapabilities(ByVal pfImage As Boolean(), ByVal pgrfOptions As UInteger()) As Integer Implements IVsFindTarget.GetCapabilities
        ' We do support IVsTextImage
        If pfImage IsNot Nothing AndAlso pfImage.Length > 0 Then
            pfImage(0) = True
        End If

        If pgrfOptions IsNot Nothing AndAlso pgrfOptions.Length > 0 Then
            pgrfOptions(0) = CUInt(__VSFINDOPTIONS.FR_Backwards) 'Search backwards from the insertion point
            pgrfOptions(0) = pgrfOptions(0) Or CUInt(__VSFINDOPTIONS.FR_MatchCase) 'Match the case while searching
            pgrfOptions(0) = pgrfOptions(0) Or CUInt(__VSFINDOPTIONS.FR_WholeWord) 'Match whole word while searching
            pgrfOptions(0) = pgrfOptions(0) Or CUInt(__VSFINDOPTIONS.FR_Selection) 'Search in selected text only
            pgrfOptions(0) = pgrfOptions(0) Or CUInt(__VSFINDOPTIONS.FR_ActionMask) 'Find/Replace capabilities

            ' Only support selection if something is selected
            If editorControl Is Nothing OrElse editorControl.RichTextBoxControl.SelectionLength = 0 Then
                pgrfOptions(0) = pgrfOptions(0) And Not (CUInt(__VSFINDOPTIONS.FR_Selection))
            End If

            'if the file is read only, don't support replace
            If editorControl Is Nothing OrElse editorControl.RichTextBoxControl.ReadOnly Then
                pgrfOptions(0) = pgrfOptions(0) And Not (CUInt(__VSFINDOPTIONS.FR_Replace) Or CUInt(__VSFINDOPTIONS.FR_ReplaceAll))
            End If
        End If
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Return the Screen coordinates of the matched string. No need to implement
    ''' </summary>
    ''' <param name="prc"></param>
    ''' <returns></returns>
    Private Function GetMatchRect(ByVal prc As RECT()) As Integer Implements IVsFindTarget.GetMatchRect
        Return VSConstants.E_NOTIMPL
    End Function

#End Region

    ''' <summary>
    ''' Function to return the string to be used in the "Find What" field of the find window. Will return
    ''' null if no text is selected or if there are multiple lines of text selected.
    ''' </summary>
    ''' <param name="pvar">the string to be returned</param>
    Private Sub GetInitialSearchString(<System.Runtime.InteropServices.Out()> ByRef pvar As Object)
        'If no text is selected, return null
        If 0 = editorControl.RichTextBoxControl.SelectionLength Then
            pvar = Nothing
            Return
        End If

        'Now check if multiple lines have been selected
        Dim endIndex As Integer = editorControl.RichTextBoxControl.SelectionStart + editorControl.RichTextBoxControl.SelectionLength
        Dim endline As Integer = editorControl.RichTextBoxControl.GetLineFromCharIndex(endIndex)
        Dim startline As Integer = editorControl.RichTextBoxControl.GetLineFromCharIndex(editorControl.RichTextBoxControl.SelectionStart)
        If startline <> endline Then
            pvar = Nothing
            Return
        End If

        pvar = editorControl.RichTextBoxControl.SelectedText
    End Sub

#Region "IVsTextImage members"

    ''' <summary>
    ''' To return the number of characters in the text image. No need to implement
    ''' </summary>
    ''' <param name="pcch">contain the number of characters</param>
    ''' <returns></returns>
    Private Function GetCharSize(<System.Runtime.InteropServices.Out()> ByRef pcch As Integer) As Integer Implements IVsTextImage.GetCharSize
        pcch = 0
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' To return the number of lines in the text image
    ''' </summary>
    ''' <param name="pcLines">pointer to the number of lines in the text image</param>
    ''' <returns>S_OK</returns>
    Private Function GetLineSize(<System.Runtime.InteropServices.Out()> ByRef pcLines As Integer) As Integer Implements IVsTextImage.GetLineSize
        'get the number of the lines in the control
        Dim len As Integer = editorControl.RichTextBoxControl.Lines.Length
        pcLines = len

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' To return the buffer address of the given text address. No need to implement
    ''' </summary>
    ''' <param name="ta">contains the TextAddress</param>
    ''' <param name="piOffset">will contain the offset from the start of the buffer</param>
    ''' <returns></returns>
    Private Function GetOffsetOfTextAddress(ByVal ta As TextAddress, <System.Runtime.InteropServices.Out()> ByRef piOffset As Integer) As Integer Implements IVsTextImage.GetOffsetOfTextAddress
        piOffset = 0
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' To return the text address of the given buffer address. No need to implement
    ''' </summary>
    ''' <param name="iOffset">offset from the start of the buffer</param>
    ''' <param name="pta">will contain the TextAddress</param>
    ''' <returns></returns>
    Private Function GetTextAddressOfOffset(ByVal iOffset As Integer, ByVal pta As TextAddress()) As Integer Implements IVsTextImage.GetTextAddressOfOffset
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' Notification for a text span replacement
    ''' </summary>
    ''' <param name="dwFlags">Flags used for the replace</param>
    ''' <param name="pts">Contains the TextSpan to be replaced</param>
    ''' <param name="cch">count of characters in pchText</param>
    ''' <param name="pchText">the replacement text</param>
    ''' <param name="ptsChanged">TextSpan of the replaced text</param>
    ''' <returns></returns>
    Private Function Replace(ByVal dwFlags As UInteger, ByVal pts As TextSpan(), ByVal cch As Integer, ByVal pchText As String, ByVal ptsChanged As TextSpan()) As Integer Implements IVsTextImage.Replace
        'pts contains the span of the item which is to be replaced
        If Nothing Is pts OrElse 0 = pts.Length Then
            Return VSConstants.E_INVALIDARG
        End If

        If Nothing Is pchText Then
            Return VSConstants.E_INVALIDARG
        End If

        ' first set start location
        Dim NewPosition As Integer = editorControl.RichTextBoxControl.GetFirstCharIndexFromLine(pts(0).iStartLine)
        NewPosition += pts(0).iStartIndex
        If NewPosition > editorControl.RichTextBoxControl.Text.Length Then
            NewPosition = editorControl.RichTextBoxControl.Text.Length
        End If
        editorControl.RichTextBoxControl.SelectionStart = NewPosition

        ' now set the length of the selection
        NewPosition = editorControl.RichTextBoxControl.GetFirstCharIndexFromLine(pts(0).iEndLine)
        NewPosition += pts(0).iEndIndex
        If NewPosition > editorControl.RichTextBoxControl.Text.Length Then
            NewPosition = editorControl.RichTextBoxControl.Text.Length
        End If
        Dim length As Integer = NewPosition - editorControl.RichTextBoxControl.SelectionStart
        If length >= 0 Then
            editorControl.RichTextBoxControl.SelectionLength = length
        Else
            editorControl.RichTextBoxControl.SelectionLength = 0
        End If

        'replace the text
        editorControl.RichTextBoxControl.SelectedText = pchText

        If (dwFlags And CUInt(__VSFINDOPTIONS.FR_Backwards)) = 0 Then
            ' In case of forward search we have to place the insertion point at the
            ' end of the new text, so it will be skipped during the next call to Find.
            editorControl.RichTextBoxControl.SelectionStart += editorControl.RichTextBoxControl.SelectionLength
        Else
            ' If the search is backward, then set the end position at the
            ' beginning of the new text.
            editorControl.RichTextBoxControl.SelectionLength = 0
        End If

        'set the ptsChanged to the TextSpan of the replaced text
        If Nothing IsNot ptsChanged AndAlso ptsChanged.Length > 0 Then
            ptsChanged(0).iStartIndex = editorControl.GetColumnFromIndex(editorControl.RichTextBoxControl.SelectionStart)
            ptsChanged(0).iEndIndex = editorControl.GetColumnFromIndex(editorControl.RichTextBoxControl.SelectionStart + editorControl.RichTextBoxControl.SelectionLength)
            ptsChanged(0).iStartLine = editorControl.RichTextBoxControl.GetLineFromCharIndex(editorControl.RichTextBoxControl.SelectionStart)
            ptsChanged(0).iEndLine = editorControl.RichTextBoxControl.GetLineFromCharIndex(editorControl.RichTextBoxControl.SelectionStart + editorControl.RichTextBoxControl.SelectionLength)
        End If

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' To return the number of characters in a TextSpan
    ''' </summary>
    ''' <param name="pts">The TextSpan structure</param>
    ''' <param name="pcch">will contain the number of characters</param>
    ''' <returns></returns>
    Private Function GetSpanLength(ByVal pts As TextSpan(), <System.Runtime.InteropServices.Out()> ByRef pcch As Integer) As Integer Implements IVsTextImage.GetSpanLength
        pcch = 0
        If Nothing Is pts OrElse 0 = pts.Length Then
            Return VSConstants.E_INVALIDARG
        End If

        Dim startIndex As Integer = editorControl.GetIndexFromLineAndColumn(pts(0).iStartLine, pts(0).iStartIndex)
        If startIndex < 0 Then
            Return VSConstants.E_INVALIDARG
        End If

        Dim endIndex As Integer = editorControl.GetIndexFromLineAndColumn(pts(0).iEndLine, pts(0).iEndIndex)
        If endIndex < 0 Then
            Return VSConstants.E_INVALIDARG
        End If

        pcch = Math.Abs(endIndex - startIndex)

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' to return the text of a TextSpan as a BSTR
    ''' </summary>
    ''' <param name="pts">the TextSpan structure</param>
    ''' <param name="pbstrText">the BSTR text</param>
    ''' <returns></returns>
    Private Function GetTextBSTR(ByVal pts As TextSpan(), <System.Runtime.InteropServices.Out()> ByRef pbstrText As String) As Integer Implements IVsTextImage.GetTextBSTR
        pbstrText = Nothing
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' To return the text of a TextSpan. No need to implement
    ''' </summary>
    ''' <param name="pts">TextSpan structure</param>
    ''' <param name="cch">number of characters to return</param>
    ''' <param name="psz">will contain the text</param>
    ''' <returns></returns>
    Private Function GetText(ByVal pts As TextSpan(), ByVal cch As Integer, ByVal psz As UShort()) As Integer Implements IVsTextImage.GetText
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' To return the length of a particular line
    ''' </summary>
    ''' <param name="iLine">zero based line number</param>
    ''' <param name="piLength">will contain the length</param>
    ''' <returns></returns>
    Private Function GetLineLength(ByVal iLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piLength As Integer) As Integer Implements IVsTextImage.GetLineLength
        Dim numberOfLines As Integer = 0
        piLength = 0
        ErrorHandler.ThrowOnFailure(CType(Me, IVsTextImage).GetLineSize(numberOfLines))

        If iLine < 0 OrElse iLine > numberOfLines - 1 Then
            Return VSConstants.E_INVALIDARG
        End If
        piLength = editorControl.RichTextBoxControl.Lines(iLine).Length

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' To provide line oriented access to the text buffer
    ''' </summary>
    ''' <param name="grfGet">flags containing information on the line to get</param>
    ''' <param name="iLine">zero based line number</param>
    ''' <param name="iStartIndex">starting character index of the line</param>
    ''' <param name="iEndIndex">ending character index of the line</param>
    ''' <param name="pLineData">Will contain the filled LINEDATA structure</param>
    ''' <returns></returns>
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Private Function GetLine(ByVal grfGet As UInteger, ByVal iLine As Integer, ByVal iStartIndex As Integer, ByVal iEndIndex As Integer, ByVal pLineData As LINEDATAEX()) As Integer Implements IVsTextImage.GetLine
        If Nothing Is pLineData OrElse 0 = pLineData.Length Then
            Return VSConstants.E_INVALIDARG
        End If

        'first initialize the Line Data object
        pLineData(0).iLength = 0
        pLineData(0).pszText = IntPtr.Zero
        pLineData(0).iEolType = EOLTYPE.eolCR
        pLineData(0).pAttributes = IntPtr.Zero
        pLineData(0).dwFlags = CUShort(LINEDATAEXFLAGS.ldfDefault)
        pLineData(0).dwReserved = 0
        pLineData(0).pAtomicTextChain = IntPtr.Zero

        Dim lineCount As Integer = editorControl.RichTextBoxControl.Lines.Length
        If (iLine < 0) OrElse (iLine >= lineCount) OrElse (iStartIndex < 0) OrElse (iEndIndex < 0) OrElse (iStartIndex > iEndIndex) Then
            Return VSConstants.E_INVALIDARG
        End If

        Dim lineText As String = editorControl.RichTextBoxControl.Lines(iLine)
        ' If the line is empty then do not attempt to calculate the span in the normal way; just return.
        If String.IsNullOrEmpty(lineText) AndAlso iStartIndex = 0 AndAlso iEndIndex = 0 Then
            Return VSConstants.S_OK
        End If
        Dim lineLength As Integer = lineText.Length

        'Error if startIndex is greater than the line length
        If iStartIndex >= lineLength OrElse iEndIndex >= lineLength Then
            Return VSConstants.E_INVALIDARG
        End If

        Dim spanLength As Integer = iEndIndex - iStartIndex + 1

        'Error in arguments if the span length is greater than the line length
        If spanLength > lineLength Then
            Return VSConstants.E_INVALIDARG
        End If

        'If we are looking for a subset of the line i.e. a line span
        If 0 <> (grfGet And CUInt(GLDE_FLAGS.gldeSubset)) Then
            pLineData(0).iLength = spanLength
            Dim spanText As String = lineText.Substring(iStartIndex, spanLength)
            pLineData(0).pszText = New IntPtr()
            pLineData(0).pszText = Marshal.StringToCoTaskMemAuto(spanText)
            'else we need to return the complete line
        Else
            pLineData(0).iLength = lineLength
            pLineData(0).pszText = New IntPtr()
            pLineData(0).pszText = Marshal.StringToCoTaskMemAuto(lineText)
        End If

        Return VSConstants.S_OK

    End Function

    ''' <summary>
    ''' Release the LINEDATAEX structure
    ''' </summary>
    ''' <param name="pLineData">pointer to the LINEDATAEX structure</param>
    ''' <returns></returns>
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Private Function ReleaseLine(ByVal pLineData As LINEDATAEX()) As Integer Implements IVsTextImage.ReleaseLine
        If Nothing Is pLineData OrElse 0 = pLineData.Length Then
            Return VSConstants.E_INVALIDARG
        End If

        'clear the Line Data object
        pLineData(0).iLength = 0
        Marshal.FreeCoTaskMem(pLineData(0).pszText)
        pLineData(0).iEolType = EOLTYPE.eolNONE
        pLineData(0).pAttributes = IntPtr.Zero
        pLineData(0).dwFlags = CUShort(LINEDATAEXFLAGS.ldfDefault)
        pLineData(0).dwReserved = 0
        pLineData(0).pAtomicTextChain = IntPtr.Zero

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Registers the environment to retrieve notifications of text image changes.
    ''' </summary>
    ''' <param name="pSink">Object requesting notification on text image changes</param>
    ''' <param name="pCookie">Handle for the event sink</param>
    ''' <returns></returns>
    Private Function AdviseTextImageEvents(ByVal pSink As IVsTextImageEvents, <System.Runtime.InteropServices.Out()> ByRef pCookie As UInteger) As Integer Implements IVsTextImage.AdviseTextImageEvents
        'We don't use this
        pCookie = 0
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Cancels notification for text image changes
    ''' </summary>
    ''' <param name="Cookie">Handle to the event sink</param>
    ''' <returns></returns>
    Private Function UnadviseTextImageEvents(ByVal Cookie As UInteger) As Integer Implements IVsTextImage.UnadviseTextImageEvents
        'We don't use this
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Notification from the environment that it is locking an image
    ''' </summary>
    ''' <param name="grfLock">the locking flag</param>
    ''' <returns></returns>
    Private Function LockImage(ByVal grfLock As UInteger) As Integer Implements IVsTextImage.LockImage
        'We only allow one reader/writer
        If (Not lockImage_Renamed) Then
            lockImage_Renamed = True
            Return VSConstants.S_OK
        Else
            Return VSConstants.E_FAIL
        End If
    End Function

    ''' <summary>
    ''' Notification from the environment that the text image is not in use
    ''' </summary>
    ''' <param name="grfLock">the locking flag</param>
    ''' <returns></returns>
    Private Function UnlockImage(ByVal grfLock As UInteger) As Integer Implements IVsTextImage.UnlockImage
        lockImage_Renamed = False
        Return VSConstants.S_OK
    End Function

#End Region

#Region "IVsTextSpanSet Members"

    ''' <summary>
    ''' The environment uses this to get a text image
    ''' </summary>
    ''' <param name="pText">Pointer to the text image</param>
    ''' <returns></returns>
    Private Function AttachTextImage(ByVal pText As Object) As Integer Implements IVsTextSpanSet.AttachTextImage
        If Nothing Is pText Then
            Return VSConstants.E_INVALIDARG
        End If

        If Nothing IsNot spTextImage Then
            If Equals(pText) Then
                Return VSConstants.S_OK
            End If
        End If



        spTextImage = CType(Me, IVsTextImage)

        'get the number of lines in the Text Image
        Dim lineCount As Integer = 0
        ErrorHandler.ThrowOnFailure(spTextImage.GetLineSize(lineCount))

        'create a text span for the entire text image
        Dim textSpan As New TextSpan()
        textSpan.iStartLine = 0
        textSpan.iStartIndex = 0
        textSpan.iEndLine = 0

        'get the length of the last line
        Dim lastLineLength As Integer = 0
        If lineCount > 0 Then
            textSpan.iEndLine = lineCount - 1
            ErrorHandler.ThrowOnFailure(spTextImage.GetLineLength(lineCount - 1, lastLineLength))
        End If

        'set the end index corresponding to the last line length
        textSpan.iEndIndex = lastLineLength

        'add it to the text span array
        textSpanArray.Add(textSpan)

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' To Release a text image
    ''' </summary>
    ''' <returns></returns>
    Private Function Detach() As Integer Implements IVsTextSpanSet.Detach
        spTextImage = Nothing
        textSpanArray.RemoveRange(0, textSpanArray.Count)

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Not needed to be implemented
    ''' </summary>
    ''' <returns></returns>
    Private Function SuspendTracking() As Integer Implements IVsTextSpanSet.SuspendTracking
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' Not needed to be implemented
    ''' </summary>
    ''' <returns></returns>
    Private Function ResumeTracking() As Integer Implements IVsTextSpanSet.ResumeTracking
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' To add the TExtSpan to an array at the specified location
    ''' </summary>
    ''' <param name="cEl">the index to insert</param>
    ''' <param name="pSpan">the TextSpan object</param>
    ''' <returns></returns>
    Private Function Add(ByVal cEl As Integer, ByVal pSpan As TextSpan()) As Integer Implements IVsTextSpanSet.Add
        If Nothing Is pSpan OrElse 0 = pSpan.Length Then
            Return VSConstants.E_INVALIDARG
        End If

        If cEl < 0 Then
            Return VSConstants.E_INVALIDARG
        End If

        textSpanArray.Insert(cEl, pSpan(0))
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Returns the number of text spans in the array
    ''' </summary>
    ''' <param name="pcel">will contain the count</param>
    ''' <returns></returns>
    Private Function GetCount(<System.Runtime.InteropServices.Out()> ByRef pcel As Integer) As Integer Implements IVsTextSpanSet.GetCount
        pcel = textSpanArray.Count
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Return the text span at the requested index
    ''' </summary>
    ''' <param name="iEl">the index</param>
    ''' <param name="pSpan">will contain the TextSpan returned</param>
    ''' <returns></returns>
    Private Function GetAt(ByVal iEl As Integer, ByVal pSpan As TextSpan()) As Integer Implements IVsTextSpanSet.GetAt
        If iEl >= textSpanArray.Count OrElse iEl < 0 Then
            Return VSConstants.E_INVALIDARG
        End If

        If Nothing Is pSpan OrElse 0 = pSpan.Length Then
            Return VSConstants.E_INVALIDARG
        End If

        pSpan(0) = CType(textSpanArray(iEl), TextSpan)

        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' Clear up the text span array
    ''' </summary>
    ''' <returns></returns>
    Private Function RemoveAll() As Integer Implements IVsTextSpanSet.RemoveAll
        textSpanArray.RemoveRange(0, textSpanArray.Count)
        Return VSConstants.S_OK
    End Function

    ''' <summary>
    ''' No need to implement this
    ''' </summary>
    ''' <param name="sortOptions"></param>
    ''' <returns></returns>
    Private Function Sort(ByVal SortOptions As UInteger) As Integer Implements IVsTextSpanSet.Sort
        Return VSConstants.E_NOTIMPL
    End Function

    ''' <summary>
    ''' No need to implement this
    ''' </summary>
    ''' <param name="pEnum"></param>
    ''' <returns></returns>
    Private Function AddFromEnum(ByVal pEnum As IVsEnumTextSpans) As Integer Implements IVsTextSpanSet.AddFromEnum
        Return VSConstants.E_NOTIMPL
    End Function
#End Region

#Region "IVsTextBuffer Members"

    'The IVsTextBuffer interface is used to provide just general information about the Text Buffer used
    'by the Editor. For our sample this is just provided so that the find in files scenario will work
    'properly.  It isn't necessary to implement most of the methods for this
    'scenario to work correctly.

    Public Function GetLanguageServiceID(<System.Runtime.InteropServices.Out()> ByRef pguidLangService As Guid) As Integer Implements IVsTextBuffer.GetLanguageServiceID, IVsTextLines.GetLanguageServiceID
        pguidLangService = Guid.Empty
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function GetLastLineIndex(<System.Runtime.InteropServices.Out()> ByRef piLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piIndex As Integer) As Integer Implements IVsTextBuffer.GetLastLineIndex, IVsTextLines.GetLastLineIndex
        'Initialize the parameters first
        piLine = 0
        piIndex = 0

        Dim totalLines As Integer = editorControl.RichTextBoxControl.Lines.Length
        If totalLines > 0 Then
            piLine = totalLines - 1
        End If
        Dim lineLen As Integer = editorControl.RichTextBoxControl.Lines(piLine).Length
        If lineLen >= 1 Then
            piIndex = lineLen - 1
        Else
            piIndex = lineLen
        End If

        Return VSConstants.S_OK
    End Function

    Public Function GetLengthOfLine(ByVal iLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piLength As Integer) As Integer Implements IVsTextBuffer.GetLengthOfLine, IVsTextLines.GetLengthOfLine
        piLength = 0
        Dim totalLines As Integer = editorControl.RichTextBoxControl.Lines.Length

        If iLine < 0 OrElse iLine >= totalLines Then
            Return VSConstants.E_INVALIDARG
        End If

        piLength = editorControl.RichTextBoxControl.Lines(iLine).Length

        Return VSConstants.S_OK
    End Function

    Public Function GetLineCount(<System.Runtime.InteropServices.Out()> ByRef piLineCount As Integer) As Integer Implements IVsTextBuffer.GetLineCount, IVsTextLines.GetLineCount
        piLineCount = editorControl.RichTextBoxControl.Lines.Length
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function GetLineIndexOfPosition(ByVal iPosition As Integer, <System.Runtime.InteropServices.Out()> ByRef piLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piColumn As Integer) As Integer Implements IVsTextBuffer.GetLineIndexOfPosition, IVsTextLines.GetLineIndexOfPosition
        'Initialize the parameters first
        piLine = 0
        piColumn = 0

        Return VSConstants.E_NOTIMPL
    End Function

    Public Function GetPositionOfLine(ByVal iLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piPosition As Integer) As Integer Implements IVsTextBuffer.GetPositionOfLine, IVsTextLines.GetPositionOfLine
        piPosition = 0

        Return VSConstants.E_NOTIMPL
    End Function

    Public Function GetPositionOfLineIndex(ByVal iLine As Integer, ByVal iIndex As Integer, <System.Runtime.InteropServices.Out()> ByRef piPosition As Integer) As Integer Implements IVsTextBuffer.GetPositionOfLineIndex, IVsTextLines.GetPositionOfLineIndex
        piPosition = 0

        Return VSConstants.E_NOTIMPL
    End Function

    Public Function GetSize(<System.Runtime.InteropServices.Out()> ByRef piLength As Integer) As Integer Implements IVsTextBuffer.GetSize, IVsTextLines.GetSize
        piLength = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function GetStateFlags(<System.Runtime.InteropServices.Out()> ByRef pdwReadOnlyFlags As UInteger) As Integer Implements IVsTextBuffer.GetStateFlags, IVsTextLines.GetStateFlags
        pdwReadOnlyFlags = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function GetUndoManager(<System.Runtime.InteropServices.Out()> ByRef ppUndoManager As IOleUndoManager) As Integer Implements IVsTextBuffer.GetUndoManager, IVsTextLines.GetUndoManager
        ppUndoManager = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function InitializeContent(ByVal pszText As String, ByVal iLength As Integer) As Integer Implements IVsTextBuffer.InitializeContent, IVsTextLines.InitializeContent
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function LockBuffer() As Integer Implements IVsTextBuffer.LockBuffer, IVsTextLines.LockBuffer
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function LockBufferEx(ByVal dwFlags As UInteger) As Integer Implements IVsTextBuffer.LockBufferEx, IVsTextLines.LockBufferEx
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reload(ByVal fUndoable As Integer) As Integer Implements IVsTextBuffer.Reload, IVsTextLines.Reload
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function SetLanguageServiceID(ByRef guidLangService As Guid) As Integer Implements IVsTextBuffer.SetLanguageServiceID, IVsTextLines.SetLanguageServiceID
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function SetStateFlags(ByVal dwReadOnlyFlags As UInteger) As Integer Implements IVsTextBuffer.SetStateFlags, IVsTextLines.SetStateFlags
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function UnlockBuffer() As Integer Implements IVsTextBuffer.UnlockBuffer, IVsTextLines.UnlockBuffer
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function UnlockBufferEx(ByVal dwFlags As UInteger) As Integer Implements IVsTextBuffer.UnlockBufferEx, IVsTextLines.UnlockBufferEx
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved1() As Integer Implements IVsTextBuffer.Reserved1, IVsTextLines.Reserved1
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved2() As Integer Implements IVsTextBuffer.Reserved2, IVsTextLines.Reserved2
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved3() As Integer Implements IVsTextBuffer.Reserved3, IVsTextLines.Reserved3
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved4() As Integer Implements IVsTextBuffer.Reserved4, IVsTextLines.Reserved4
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved5() As Integer Implements IVsTextBuffer.Reserved5, IVsTextLines.Reserved5
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved6() As Integer Implements IVsTextBuffer.Reserved6, IVsTextLines.Reserved6
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved7() As Integer Implements IVsTextBuffer.Reserved7, IVsTextLines.Reserved7
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved8() As Integer Implements IVsTextBuffer.Reserved8, IVsTextLines.Reserved8
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved9() As Integer Implements IVsTextBuffer.Reserved9, IVsTextLines.Reserved9
        Return VSConstants.E_NOTIMPL
    End Function

    Public Function Reserved10() As Integer Implements IVsTextBuffer.Reserved10, IVsTextLines.Reserved10
        Return VSConstants.E_NOTIMPL
    End Function
#End Region

#Region "IVsTextView Members"

    'This interface contains methods to manage the Text View i.e. the editor window which is shown to
    'the user. For our sample this is just provided so that the find in files scenario will work
    'properly.  It isn't necessary to implement most of the methods for this
    'scenario to work correctly.

    Private Function AddCommandFilter(ByVal pNewCmdTarg As IOleCommandTarget, <System.Runtime.InteropServices.Out()> ByRef ppNextCmdTarg As IOleCommandTarget) As Integer Implements IVsTextView.AddCommandFilter
        ppNextCmdTarg = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CenterColumns(ByVal iLine As Integer, ByVal iLeftCol As Integer, ByVal iColCount As Integer) As Integer Implements IVsTextView.CenterColumns
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CenterLines(ByVal iTopLine As Integer, ByVal iCount As Integer) As Integer Implements IVsTextView.CenterLines
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ClearSelection(ByVal fMoveToAnchor As Integer) As Integer Implements IVsTextView.ClearSelection
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CloseView() As Integer Implements IVsTextView.CloseView
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function EnsureSpanVisible(ByVal span As TextSpan) As Integer Implements IVsTextView.EnsureSpanVisible
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetBufferText(<System.Runtime.InteropServices.Out()> ByRef ppBuffer As IVsTextLines) As Integer Implements IVsTextView.GetBuffer
        ppBuffer = CType(Me, IVsTextLines)
        Return VSConstants.S_OK
    End Function

    Private Function GetCaretPos(<System.Runtime.InteropServices.Out()> ByRef piLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piColumn As Integer) As Integer Implements IVsTextView.GetCaretPos
        piLine = 0
        piColumn = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetLineAndColumn(ByVal iPos As Integer, <System.Runtime.InteropServices.Out()> ByRef piLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piIndex As Integer) As Integer Implements IVsTextView.GetLineAndColumn
        piLine = 0
        piIndex = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetLineHeight(<System.Runtime.InteropServices.Out()> ByRef piLineHeight As Integer) As Integer Implements IVsTextView.GetLineHeight
        piLineHeight = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetNearestPosition(ByVal iLine As Integer, ByVal iCol As Integer, <System.Runtime.InteropServices.Out()> ByRef piPos As Integer, <System.Runtime.InteropServices.Out()> ByRef piVirtualSpaces As Integer) As Integer Implements IVsTextView.GetNearestPosition
        piPos = 0
        piVirtualSpaces = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetPointOfLineColumn(ByVal iLine As Integer, ByVal iCol As Integer, ByVal ppt As Microsoft.VisualStudio.OLE.Interop.POINT()) As Integer Implements IVsTextView.GetPointOfLineColumn
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetScrollInfo(ByVal iBar As Integer, <System.Runtime.InteropServices.Out()> ByRef piMinUnit As Integer, <System.Runtime.InteropServices.Out()> ByRef piMaxUnit As Integer, <System.Runtime.InteropServices.Out()> ByRef piVisibleUnits As Integer, <System.Runtime.InteropServices.Out()> ByRef piFirstVisibleUnit As Integer) As Integer Implements IVsTextView.GetScrollInfo
        piMinUnit = 0
        piMaxUnit = 0
        piVisibleUnits = 0
        piFirstVisibleUnit = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetSelectedText(<System.Runtime.InteropServices.Out()> ByRef pbstrText As String) As Integer Implements IVsTextView.GetSelectedText
        pbstrText = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetSelection(<System.Runtime.InteropServices.Out()> ByRef piAnchorLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piAnchorCol As Integer, <System.Runtime.InteropServices.Out()> ByRef piEndLine As Integer, <System.Runtime.InteropServices.Out()> ByRef piEndCol As Integer) As Integer Implements IVsTextView.GetSelection
        piAnchorLine = 0
        piAnchorCol = 0
        piEndLine = 0
        piEndCol = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetSelectionDataObject(<System.Runtime.InteropServices.Out()> ByRef ppIDataObject As Microsoft.VisualStudio.OLE.Interop.IDataObject) As Integer Implements IVsTextView.GetSelectionDataObject
        ppIDataObject = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetSelectionMode() As TextSelMode Implements IVsTextView.GetSelectionMode
        Return TextSelMode.SM_STREAM
    End Function

    Private Function GetSelectionSpan(ByVal pSpan As TextSpan()) As Integer Implements IVsTextView.GetSelectionSpan
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetTextStream(ByVal iTopLine As Integer, ByVal iTopCol As Integer, ByVal iBottomLine As Integer, ByVal iBottomCol As Integer, <System.Runtime.InteropServices.Out()> ByRef pbstrText As String) As Integer Implements IVsTextView.GetTextStream
        pbstrText = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetWindowHandle() As IntPtr Implements IVsTextView.GetWindowHandle
        Return IntPtr.Zero
    End Function

    Private Function GetWordExtent(ByVal iLine As Integer, ByVal iCol As Integer, ByVal dwFlags As UInteger, ByVal pSpan As TextSpan()) As Integer Implements IVsTextView.GetWordExtent
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function HighlightMatchingBrace(ByVal dwFlags As UInteger, ByVal cSpans As UInteger, ByVal rgBaseSpans As TextSpan()) As Integer Implements IVsTextView.HighlightMatchingBrace
        Return VSConstants.E_NOTIMPL
    End Function

    Private Shadows Function Initialize(ByVal pBuffer As IVsTextLines, ByVal hwndParent As IntPtr, ByVal InitFlags As UInteger, ByVal pInitView As INITVIEW()) As Integer Implements IVsTextView.Initialize
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function PositionCaretForEditing(ByVal iLine As Integer, ByVal cIndentLevels As Integer) As Integer Implements IVsTextView.PositionCaretForEditing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function RemoveCommandFilter(ByVal pCmdTarg As IOleCommandTarget) As Integer Implements IVsTextView.RemoveCommandFilter
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ReplaceTextOnLine(ByVal iLine As Integer, ByVal iStartCol As Integer, ByVal iCharsToReplace As Integer, ByVal pszNewText As String, ByVal iNewLen As Integer) As Integer Implements IVsTextView.ReplaceTextOnLine
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function RestrictViewRange(ByVal iMinLine As Integer, ByVal iMaxLine As Integer, ByVal pClient As IVsViewRangeClient) As Integer Implements IVsTextView.RestrictViewRange
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SendExplicitFocus() As Integer Implements IVsTextView.SendExplicitFocus
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetBufferText(ByVal pBuffer As IVsTextLines) As Integer Implements IVsTextView.SetBuffer
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetCaretPos(ByVal iLine As Integer, ByVal iColumn As Integer) As Integer Implements IVsTextView.SetCaretPos
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetScrollPosition(ByVal iBar As Integer, ByVal iFirstVisibleUnit As Integer) As Integer Implements IVsTextView.SetScrollPosition
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetSelection(ByVal iAnchorLine As Integer, ByVal iAnchorCol As Integer, ByVal iEndLine As Integer, ByVal iEndCol As Integer) As Integer Implements IVsTextView.SetSelection
        ' first set start location
        Dim startPosition As Integer = editorControl.GetIndexFromLineAndColumn(iAnchorLine, iAnchorCol)
        If startPosition < 0 Then
            Return VSConstants.E_INVALIDARG
        End If
        editorControl.RichTextBoxControl.SelectionStart = startPosition

        ' now set the length of the selection
        Dim endPosition As Integer = editorControl.GetIndexFromLineAndColumn(iEndLine, iEndCol)
        If endPosition < 0 Then
            Return VSConstants.E_INVALIDARG
        End If
        Dim length As Integer = endPosition - editorControl.RichTextBoxControl.SelectionStart
        If length >= 0 Then
            editorControl.RichTextBoxControl.SelectionLength = length
        Else
            editorControl.RichTextBoxControl.SelectionLength = 0
        End If
        Return VSConstants.S_OK
    End Function

    Private Function SetSelectionMode(ByVal iSelMode As TextSelMode) As Integer Implements IVsTextView.SetSelectionMode
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetTopLine(ByVal iBaseLine As Integer) As Integer Implements IVsTextView.SetTopLine
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function UpdateCompletionStatus(ByVal pCompSet As IVsCompletionSet, ByVal dwFlags As UInteger) As Integer Implements IVsTextView.UpdateCompletionStatus
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function UpdateTipWindow(ByVal pTipWindow As IVsTipWindow, ByVal dwFlags As UInteger) As Integer Implements IVsTextView.UpdateTipWindow
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function UpdateViewFrameCaption() As Integer Implements IVsTextView.UpdateViewFrameCaption
        Return VSConstants.E_NOTIMPL
    End Function

#End Region

#Region "IVsTextViewEvents Members"

    'This interface is used as a notifier for the events that are occurring on the Text View.
    'For our sample this is just provided so that the find in files scenario will work
    'properly.  It isn't necessary to implement any of the methods.

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMethodsAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")> _
    Public Sub OnChangeCaretLine(ByVal pView As IVsTextView, ByVal iNewLine As Integer, ByVal iOldLine As Integer)
        'Not Implemented
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMethodsAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")> _
    Public Sub OnChangeScrollInfo(ByVal pView As IVsTextView, ByVal iBar As Integer, ByVal iMinUnit As Integer, ByVal iMaxUnits As Integer, ByVal iVisibleUnits As Integer, ByVal iFirstVisibleUnit As Integer)
        'Not Implemented
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMethodsAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")> _
    Public Sub OnKillFocus(ByVal pView As IVsTextView)
        'Not Implemented
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMethodsAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")> _
    Public Sub OnSetBuffer(ByVal pView As IVsTextView, ByVal pBuffer As IVsTextLines)
        'Not Implemented
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMethodsAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")> _
    Public Sub OnSetFocus(ByVal pView As IVsTextView)
        'Not Implemented
    End Sub
#End Region

#Region "IVsCodeWindow Members"

    ' This interface is used for hosting of the views for a text buffer. Multiple views can be enclosed
    'with the code window.
    'Since our editor support the LOGVIEWID_TextView logical view, we need to implement this interface
    'for find in files scenario to work properly.
    'It isn't necessary to implement most of the methods for this scenario to work correctly.

    Private Function GetPrimaryView(<System.Runtime.InteropServices.Out()> ByRef ppView As IVsTextView) As Integer Implements IVsCodeWindow.GetPrimaryView
        ppView = CType(Me, IVsTextView)
        Return VSConstants.S_OK
    End Function

    Private Function GetSecondaryView(<System.Runtime.InteropServices.Out()> ByRef ppView As IVsTextView) As Integer Implements IVsCodeWindow.GetSecondaryView
        ppView = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetLastActiveView(<System.Runtime.InteropServices.Out()> ByRef ppView As IVsTextView) As Integer Implements IVsCodeWindow.GetLastActiveView
        ppView = CType(Me, IVsTextView)
        Return VSConstants.S_OK
    End Function

    Private Function Close() As Integer Implements IVsCodeWindow.Close
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetBuffer(<System.Runtime.InteropServices.Out()> ByRef ppBuffer As IVsTextLines) As Integer Implements IVsCodeWindow.GetBuffer
        ppBuffer = CType(Me, IVsTextLines)
        Return VSConstants.S_OK
    End Function

    Private Function GetEditorCaption(ByVal dwReadOnly As READONLYSTATUS, <System.Runtime.InteropServices.Out()> ByRef pbstrEditorCaption As String) As Integer Implements IVsCodeWindow.GetEditorCaption
        pbstrEditorCaption = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetViewClassID(<System.Runtime.InteropServices.Out()> ByRef pclsidView As Guid) As Integer Implements IVsCodeWindow.GetViewClassID
        pclsidView = Guid.Empty
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetBaseEditorCaption(ByVal pszBaseEditorCaption As String()) As Integer Implements IVsCodeWindow.SetBaseEditorCaption
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetBuffer(ByVal pBuffer As IVsTextLines) As Integer Implements IVsCodeWindow.SetBuffer
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function SetViewClassID(ByRef clsidView As Guid) As Integer Implements IVsCodeWindow.SetViewClassID
        Return VSConstants.E_NOTIMPL
    End Function

#End Region

#Region "IVsTextLines Members"

    ' This interface is used for a line-oriented access to the contents of the text buffer.
    'For our sample all methods return E_NOTIMPL. This is needed for Find/Replace to work appropriately.
    'The Caller just does a QueryInterface for this particular interface, but does not use any
    'of the methods available on the interface

    Private Function AdviseTextLinesEvents(ByVal pSink As IVsTextLinesEvents, <System.Runtime.InteropServices.Out()> ByRef pdwCookie As UInteger) As Integer Implements IVsTextLines.AdviseTextLinesEvents
        pdwCookie = 0
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function UnadviseTextLinesEvents(ByVal dwCookie As UInteger) As Integer Implements IVsTextLines.UnadviseTextLinesEvents
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CanReplaceLines(ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, ByVal iNewLen As Integer) As Integer Implements IVsTextLines.CanReplaceLines
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CopyLineText(ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, ByVal pszBuf As IntPtr, ByRef pcchBuf As Integer) As Integer Implements IVsTextLines.CopyLineText
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CreateEditPoint(ByVal iLine As Integer, ByVal iIndex As Integer, <System.Runtime.InteropServices.Out()> ByRef ppEditPoint As Object) As Integer Implements IVsTextLines.CreateEditPoint
        ppEditPoint = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CreateLineMarker(ByVal iMarkerType As Integer, ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, ByVal pClient As IVsTextMarkerClient, ByVal ppMarker As IVsTextLineMarker()) As Integer Implements IVsTextLines.CreateLineMarker
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function CreateTextPoint(ByVal iLine As Integer, ByVal iIndex As Integer, <System.Runtime.InteropServices.Out()> ByRef ppTextPoint As Object) As Integer Implements IVsTextLines.CreateTextPoint
        ppTextPoint = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function EnumMarkers(ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, ByVal iMarkerType As Integer, ByVal dwFlags As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppEnum As IVsEnumLineMarkers) As Integer Implements IVsTextLines.EnumMarkers
        ppEnum = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function FindMarkerByLineIndex(ByVal iMarkerType As Integer, ByVal iStartingLine As Integer, ByVal iStartingIndex As Integer, ByVal dwFlags As UInteger, <System.Runtime.InteropServices.Out()> ByRef ppMarker As IVsTextLineMarker) As Integer Implements IVsTextLines.FindMarkerByLineIndex
        ppMarker = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetMarkerData(ByVal iTopLine As Integer, ByVal iBottomLine As Integer, ByVal pMarkerData As MARKERDATA()) As Integer Implements IVsTextLines.GetMarkerData
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ReleaseMarkerData(ByVal pMarkerData As MARKERDATA()) As Integer Implements IVsTextLines.ReleaseMarkerData
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetLineData(ByVal iLine As Integer, ByVal pLineData As LINEDATA(), ByVal pMarkerData As MARKERDATA()) As Integer Implements IVsTextLines.GetLineData
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ReleaseLineData(ByVal pLineData As LINEDATA()) As Integer Implements IVsTextLines.ReleaseLineData
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetLineDataEx(ByVal dwFlags As UInteger, ByVal iLine As Integer, ByVal iStartIndex As Integer, ByVal iEndIndex As Integer, ByVal pLineData As LINEDATAEX(), ByVal pMarkerData As MARKERDATA()) As Integer Implements IVsTextLines.GetLineDataEx
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ReleaseLineDataEx(ByVal pLineData As LINEDATAEX()) As Integer Implements IVsTextLines.ReleaseLineDataEx
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function IVsTextLinesReserved1(ByVal iLine As Integer, ByVal pLineData As LINEDATA(), ByVal fAttributes As Integer) As Integer Implements IVsTextLines.IVsTextLinesReserved1
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetLineText(ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, <System.Runtime.InteropServices.Out()> ByRef pbstrBuf As String) As Integer Implements IVsTextLines.GetLineText
        pbstrBuf = Nothing
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function GetPairExtents(ByVal pSpanIn As TextSpan(), ByVal pSpanOut As TextSpan()) As Integer Implements IVsTextLines.GetPairExtents
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ReplaceLines(ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, ByVal pszText As IntPtr, ByVal iNewLen As Integer, ByVal pChangedSpan As TextSpan()) As Integer Implements IVsTextLines.ReplaceLines
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ReplaceLinesEx(ByVal dwFlags As UInteger, ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, ByVal pszText As IntPtr, ByVal iNewLen As Integer, ByVal pChangedSpan As TextSpan()) As Integer Implements IVsTextLines.ReplaceLinesEx
        Return VSConstants.E_NOTIMPL
    End Function

    Private Function ReloadLines(ByVal iStartLine As Integer, ByVal iStartIndex As Integer, ByVal iEndLine As Integer, ByVal iEndIndex As Integer, ByVal pszText As IntPtr, ByVal iNewLen As Integer, ByVal pChangedSpan As TextSpan()) As Integer Implements IVsTextLines.ReloadLines
        Return VSConstants.E_NOTIMPL
    End Function

#End Region
End Class