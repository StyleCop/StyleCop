Imports Microsoft.VisualBasic
Imports System
Imports System.Runtime.InteropServices
Imports EnvDTE
Imports tom

''' <summary>
''' IEditor is the automation interface for EditorDocument.
''' The implementation of the methods is just a wrapper over the rich
''' edit control's object model.
''' </summary>
<InterfaceType(ComInterfaceType.InterfaceIsIDispatch)> _
Public Interface IEditor
    Property DefaultTabStop() As Single
    ReadOnly Property Range() As ITextRange
    ReadOnly Property Selection() As ITextSelection
    Property SelectionProperties() As Integer
    Function FindText(ByVal textToFind As String) As Integer
    Function SetText(ByVal textToSet As String) As Integer
    Function TypeText(ByVal textToType As String) As Integer
    Function Cut() As Integer
    Function Copy() As Integer
    Function Paste() As Integer
    Function Delete(ByVal unit As Long, ByVal count As Long) As Integer
    Function MoveUp(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer
    Function MoveDown(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer
    Function MoveLeft(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer
    Function MoveRight(ByVal unit As Integer, ByVal count As Integer, ByVal extend As Integer) As Integer
    Function EndKey(ByVal unit As Integer, ByVal extend As Integer) As Integer
    Function HomeKey(ByVal unit As Integer, ByVal extend As Integer) As Integer
End Interface
