Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guid%ProjectClass%PkgString As String = "%PackageGuid%"
    Public Const guid%ProjectClass%CmdSetString As String = "%CmdSetGuid%"
%ToolWindowItemStart%    Public Const guidToolWindowPersistanceString As String = "%ToolGuid%"
%ToolWindowItemEnd%%EditorStart%    Public Const guid%ProjectClass%EditorFactoryString As String = "%FactoryGuid%"
%EditorEnd%
    Public Shared ReadOnly guid%ProjectClass%CmdSet As New Guid(guid%ProjectClass%CmdSetString)
%EditorStart%    Public Shared ReadOnly guid%ProjectClass%EditorFactory As New Guid(guid%ProjectClass%EditorFactoryString)
%EditorEnd%End Class