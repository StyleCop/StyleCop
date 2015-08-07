Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.ComponentModel.Design
Imports Microsoft.Win32
Imports Microsoft.VisualStudio
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop
Imports Microsoft.VisualStudio.Shell

''' <summary>
''' This is the class that implements the package exposed by this assembly.
'''
''' The minimum requirement for a class to be considered a valid package for Visual Studio
''' is to implement the IVsPackage interface and register itself with the shell.
''' This package uses the helper classes defined inside the Managed Package Framework (MPF)
''' to do it: it derives from the Package class that provides the implementation of the 
''' IVsPackage interface and uses the registration attributes defined in the framework to 
''' register itself and its components with the shell.
''' </summary>
' The PackageRegistration attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class
' is a package.
'
' The InstalledProductRegistration attribute is used to register the information needed to show this package
' in the Help/About dialog of Visual Studio.
%MenuItemToolWindowEditorStart%    '
' The ProvideMenuResource attribute is needed to let the shell know that this package exposes some menus.
%MenuItemToolWindowEditorEnd%%ToolWindowItemStart%    '
' The ProvideToolWindow attribute registers a tool window exposed by this package.
%ToolWindowItemEnd%%EditorStart%
' 
' Our Editor supports Find and Replace therefore we need to declare support for LOGVIEWID_TextView.
' The ProvideEditorLogicalView attribute declares that your EditorPane class implements IVsCodeWindow interface
' used to navigate to find results from a "Find in Files" type of operation.
' 
%EditorEnd%
    <PackageRegistration(UseManagedResourcesOnly := true), _ 
    InstalledProductRegistration("#110", "#112", "1.0", IconResourceID := 400), _%MenuItemToolWindowEditorStart%
    ProvideMenuResource("Menus.ctmenu", 1), _%MenuItemToolWindowEditorEnd%%ToolWindowItemStart%
    ProvideToolWindow(GetType(MyToolWindow)), _%ToolWindowItemEnd%%EditorStart%    
    ProvideEditorExtension(GetType(EditorFactory), ".%Extension%", 50, ProjectGuid := "{A2FE74E1-B743-11d0-AE1A-00A0C90FFFC3}", TemplateDir := "Templates", NameResourceID := 105, DefaultName := "%PackageName%"), _
    ProvideKeyBindingTable(GuidList.guid%ProjectClass%EditorFactoryString, 102), _
    ProvideEditorLogicalView(GetType(EditorFactory), VSConstants.LOGVIEWID.TextView_string), _%EditorEnd%    
    Guid(GuidList.guid%ProjectClass%PkgString)> _
    Public NotInheritable Class %ProjectClass%Package
Inherits Package

''' <summary>
''' Default constructor of the package.
''' Inside this method you can place any initialization code that does not require 
''' any Visual Studio service because at this point the package object is created but 
''' not sited yet inside Visual Studio environment. The place to do all the other 
''' initialization is the Initialize method.
''' </summary>
Public Sub New()
    Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", Me.GetType().Name))
End Sub

%ToolWindowItemStart%        ''' <summary>
''' This function is called when the user clicks the menu item that shows the 
''' tool window. See the Initialize method to see how the menu item is associated to 
''' this function using the OleMenuCommandService service and the MenuCommand class.
''' </summary>
Private Sub ShowToolWindow(ByVal sender As Object, ByVal e As EventArgs)
    ' Get the instance number 0 of this tool window. This window is single instance so this instance
    ' is actually the only one.
    ' The last flag is set to true so that if the tool window does not exists it will be created.
    Dim window As ToolWindowPane = Me.FindToolWindow(GetType(MyToolWindow), 0, True)
    If (window Is Nothing) Or (window.Frame Is Nothing) Then
        Throw New NotSupportedException(Resources.CanNotCreateWindow)
    End If

    Dim windowFrame As IVsWindowFrame = TryCast(window.Frame, IVsWindowFrame)
    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show())
End Sub
%ToolWindowItemEnd%

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Overridden Package Implementation
#Region "Package Members"

''' <summary>
''' Initialization of the package; this method is called right after the package is sited, so this is the place
''' where you can put all the initialization code that rely on services provided by VisualStudio.
''' </summary>
Protected Overrides Sub Initialize()
    Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", Me.GetType().Name))
    MyBase.Initialize()
%EditorStart%
    'Create Editor Factory. Note that the base Package class will call Dispose on it.
    MyBase.RegisterEditorFactory(New EditorFactory(Me))
%EditorEnd%
%MenuItemToolWindowStart%            ' Add our command handlers for menu (commands must exist in the .vsct file)
    Dim mcs As OleMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
    If Not mcs Is Nothing Then
%MenuItemStart%                ' Create the command for the menu item.
                Dim menuCommandID As New CommandID(GuidList.guid%ProjectClass%CmdSet, CInt(PkgCmdIDList.%CommandID%))
        Dim menuItem As New MenuCommand(New EventHandler(AddressOf MenuItemCallback), menuCommandID)
        mcs.AddCommand(menuItem)
%MenuItemEnd%%ToolWindowItemStart%                ' Create the command for the tool window
                Dim toolwndCommandID As New CommandID(GuidList.guid%ProjectClass%CmdSet, CInt(PkgCmdIDList.%ToolCommandID%))
        Dim menuToolWin As New MenuCommand(New EventHandler(AddressOf ShowToolWindow), toolwndCommandID)
        mcs.AddCommand(menuToolWin)
%ToolWindowItemEnd%            End If
%MenuItemToolWindowEnd%        End Sub
#End Region
%MenuItemStart%
''' <summary>
''' This function is the callback used to execute a command when the a menu item is clicked.
''' See the Initialize method to see how the menu item is associated to this function using
''' the OleMenuCommandService service and the MenuCommand class.
''' </summary>
Private Sub MenuItemCallback(ByVal sender As Object, ByVal e As EventArgs)
    ' Show a Message Box to prove we were here
    Dim uiShell As IVsUIShell = TryCast(GetService(GetType(SVsUIShell)), IVsUIShell)
    Dim clsid As Guid = Guid.Empty
    Dim result As Integer
    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(0, clsid, "%PackageName%", String.Format(CultureInfo.CurrentCulture, "%MenuItemCallbackText%", Me.GetType().Name), String.Empty, 0, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, OLEMSGICON.OLEMSGICON_INFO, 0, result))
End Sub
%MenuItemEnd%
End Class
