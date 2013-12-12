Imports Microsoft.VisualBasic

Imports System
Imports System.Windows.Forms
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Diagnostics.CodeAnalysis
Imports tom

Partial Public Class MyEditor
    Inherits UserControl
    Private Const GetOleInterfaceCommandId As Integer = 1084

    Private m_TextToRecord As String
    Private m_Recorder As VSMacroRecorder

    Public Sub New()
        InitializeComponent()
        Me.richTextBoxCtrl.WordWrap = False
        Me.richTextBoxCtrl.HideSelection = False

        m_Recorder = New VSMacroRecorder(GuidList.guid%ProjectClass%EditorFactory)
    End Sub

    Public ReadOnly Property RichTextBoxControl() As EditorTextBox
        Get
            Return Me.richTextBoxCtrl
        End Get
    End Property

#Region "Fields"

    ''' <summary> 
    ''' This value is used internally so that we know what to display on the status bar. 
    ''' NOTE: Setting this value will not actually change the insert/overwrite behavior 
    ''' of the editor, it is just used so that we can keep track of the state internally. 
    ''' </summary> 
    Private m_overstrike As Boolean
    Public Property Overstrike() As Boolean
        Get
            Return Me.m_overstrike
        End Get
        Set(ByVal value As Boolean)
            Me.m_overstrike = value
        End Set
    End Property

    Private m_textDocument As ITextDocument

    ''' <summary> 
    ''' This property exposes the ITextDocument interface associated with 
    ''' our Rich Text editor. 
    ''' </summary> 
    Public ReadOnly Property TextDocument() As ITextDocument
        <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
        Get
            If m_textDocument IsNot Nothing Then
                Return m_textDocument
            End If

            ' To get the IRichEditOle interface we need to call SendMessage, which 
            ' we imported from user32.dll 
            Dim editOle As Object = Nothing
            ' The rich text box handle 
            ' The command ID for EM_GETOLEINTERFACE 
            ' null 
            ' This will be set to the IRichEditOle interface 
            NativeMethods.SendMessage(richTextBoxCtrl.Handle, GetOleInterfaceCommandId, IntPtr.Zero, editOle)

            ' Call GetIUnknownForObject with the IRichEditOle interface that we 
            ' just got so that we have an IntPtr to pass into QueryInterface 
            Dim editOlePtr As IntPtr = IntPtr.Zero
            editOlePtr = Marshal.GetIUnknownForObject(editOle)

            ' Call QueryInterface to get the pointer to the ITextDocument 
            Dim iTextDocument As IntPtr = IntPtr.Zero
            Dim iTextDocumentGuid As Guid = GetType(ITextDocument).GUID
            Marshal.QueryInterface(editOlePtr, iTextDocumentGuid, iTextDocument)

            ' We need to call Marshal.Release with the pointer that we got 
            ' from the GetIUnknownForObject call 
            Marshal.Release(editOlePtr)

            ' Call GetObjectForIUnknown passing in the pointer that was set 
            ' by QueryInterface and return it as an ITextDocument 
            m_textDocument = TryCast(Marshal.GetObjectForIUnknown(iTextDocument), ITextDocument)
            Return m_textDocument
        End Get
    End Property

    ''' <summary> 
    ''' This property will return the current ITextRange interface. 
    ''' </summary> 
    Public ReadOnly Property TextRange() As ITextRange
        Get
            Return Me.TextDocument.Range(0, CInt(tom.tomConstants.tomForward))
        End Get
    End Property

    ''' <summary> 
    ''' This property will return the current ITextSelection interface. 
    ''' </summary> 
    Public ReadOnly Property TextSelection() As ITextSelection
        Get
            Return Me.TextDocument.Selection
        End Get
    End Property

#End Region

    ''' <summary> 
    ''' Returns the column number from the specified index 
    ''' </summary> 
    ''' <param name="index">index of the character</param> 
    ''' <returns>column number</returns> 
    Public Function GetColumnFromIndex(ByVal index As Integer) As Integer
        'first get the index of the first char of the current line 
        Dim currentLineIndex As Integer = richTextBoxCtrl.GetFirstCharIndexOfCurrentLine()
        Return index - currentLineIndex
    End Function

    ''' <summary> 
    ''' Returns the index from the specified line and column number 
    ''' </summary> 
    ''' <param name="line">line number</param> 
    ''' <param name="column">column number</param> 
    ''' <returns>index</returns> 
    Public Function GetIndexFromLineAndColumn(ByVal line As Integer, ByVal column As Integer) As Integer
        If line < 0 Then
            Return -1
        End If
        'first get the index of the first char of the specified line 
        Dim firstCharLineIndex As Integer = richTextBoxCtrl.GetFirstCharIndexFromLine(line)
        If firstCharLineIndex < 0 Then
            Return -1
        End If

        Return firstCharLineIndex + column
    End Function

#Region "Macro Recording methods"
    Public Sub RecordDelete(ByVal backspace As Boolean, ByVal word As Boolean)
        ' If not backspace then it's a delete
        ' If not word then it's a single character
        Dim macroType As LastMacro
        If backspace Then
            If word Then
                macroType = LastMacro.BackspaceWord
            Else
                macroType = LastMacro.BackspaceChar
            End If
        Else
            If word Then
                macroType = (LastMacro.DeleteWord)
            Else
                macroType = (LastMacro.DeleteChar)
            End If
        End If

        ' Get the number of times the macro type calculated above has been recorded already
        ' (if any) and then add one to get the current count
        Dim count As UInteger = CType(m_Recorder.GetTimesPreviouslyRecorded(macroType) + 1, UInteger)

        Dim macroString As String = ""
        ' if this parameter is negative, it indicates a backspace, rather then a delete
        If word Then
            If backspace Then
                macroString &= "ActiveDocument.Object.Delete(" & CInt(Fix(tom.tomConstants.tomWord)) & ", " & (-1 * count) & ")"
            Else
                macroString &= "ActiveDocument.Object.Delete(" & CInt(Fix(tom.tomConstants.tomWord)) & ", " & (count) & ")"
            End If
        Else
            If backspace Then
                macroString &= "ActiveDocument.Object.Delete(" & CInt(Fix(tom.tomConstants.tomCharacter)) & ", " & (-1 * count) & ")"
            Else
                macroString &= "ActiveDocument.Object.Delete(" & CInt(Fix(tom.tomConstants.tomCharacter)) & ", " & (count) & ")"
            End If
        End If

        m_Recorder.RecordBatchedLine(macroType, macroString)
    End Sub

    Public Sub RecordMove(ByVal state As LastMacro, ByVal direction As String, ByVal scope As MoveScope, ByVal extend As Boolean)

        Dim macroString As String = ""
        macroString &= "ActiveDocument.Object.Move"
        macroString &= direction
        ' Get the number of times this macro type has been recorded already
        ' (if any) and then add one to get the current count
        If extend Then
            macroString &= "(" & CInt(Fix(scope)) & ", " & (m_Recorder.GetTimesPreviouslyRecorded(state) + 1) & ", " & CInt(Fix(tom.tomConstants.tomExtend)) & ")"
        Else
            macroString &= "(" & CInt(Fix(scope)) & ", " & (m_Recorder.GetTimesPreviouslyRecorded(state) + 1) & ", " & CInt(Fix(tom.tomConstants.tomMove)) & ")"
        End If

        m_Recorder.RecordBatchedLine(state, macroString)
    End Sub

    Public Sub RecordCommand(ByVal command As String)
        If m_Recorder.IsRecording() Then
            Dim line As String = "ActiveDocument.Object."

            line &= command

            m_Recorder.RecordLine(line)
        End If
    End Sub

    Public Sub StopRecorder()
        m_Recorder.Stop()
    End Sub

    <SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId:="0#")> _
    Public Sub RecordPrintableChar(ByVal currentValue As Char)
        Dim macroString As String = ""

        If (Not m_Recorder.IsLastRecordedMacro(LastMacro.Text)) Then
            m_TextToRecord = ""
        End If

        ' Only deal with text characters.  Everything, space and above is a text character
        ' except DEL (0x7f).  Include carriage return (enter key) and tab, which are
        ' below space, since those are also text characters.
        If Char.IsLetterOrDigit(currentValue) OrElse Char.IsPunctuation(currentValue) OrElse Char.IsSeparator(currentValue) OrElse Char.IsSymbol(currentValue) OrElse Char.IsWhiteSpace(currentValue) OrElse ControlChars.Cr = currentValue OrElse ControlChars.Tab = currentValue Then
            If ControlChars.Cr = currentValue Then
                ' Emit "\r\n" as the standard line terminator
                m_TextToRecord &= """ & vbCr & """
            ElseIf ControlChars.Tab = currentValue Then
                ' Emit "\t" as the standard tab
                m_TextToRecord &= """ & vbTab & """
            Else
                m_TextToRecord &= currentValue
            End If

            macroString &= "ActiveDocument.Object.TypeText("""
            macroString &= m_TextToRecord
            macroString &= """)"

            If m_Recorder.RecordBatchedLine(LastMacro.Text, macroString, 100) Then ' arbitrary max length
                ' Clear out the buffer if the line hit max length, since
                ' it will not continue to be appended to
                m_TextToRecord = ""
            End If
        End If
    End Sub

    <SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")> _
    Public Sub RecordNonprintableChar(ByVal currentKey As Keys)
        Dim macroString As String = ""

        ' Obtain the CTRL and SHIFT as they modify a number of the virtual keys. 
        Dim shiftDown As Boolean = System.Windows.Forms.Keys.Shift = (System.Windows.Forms.Control.ModifierKeys And System.Windows.Forms.Keys.Shift) 'Keyboard::IsKeyDown(VK_SHIFT);
        Dim controlDown As Boolean = System.Windows.Forms.Keys.Control = (System.Windows.Forms.Control.ModifierKeys And System.Windows.Forms.Keys.Control) 'Keyboard::IsKeyDown(VK_CONTROL);

        ' msg.WParam indicates the virtual key.
        Select Case currentKey
            Case Keys.Back ' BackSpace key
                ' Note that SHIFT does not affect this command
                RecordDelete(True, controlDown)

            Case Keys.Delete
                ' Note that SHIFT completely disables this command
                If (Not shiftDown) Then
                    RecordDelete(False, controlDown)
                End If

            Case Keys.Left ' Left Arrow
                ' SHIFT indicates selection, CTRL indicates words instead of characters
                Dim macroType As LastMacro
                If controlDown Then
                    If shiftDown Then
                        macroType = LastMacro.LeftArrowWordSelection
                    Else
                        macroType = LastMacro.LeftArrowWord
                    End If
                Else
                    If shiftDown Then
                        macroType = (LastMacro.LeftArrowCharSelection)
                    Else
                        macroType = (LastMacro.LeftArrowChar)
                    End If
                End If

                If controlDown Then
                    RecordMove(macroType, "Left", MoveScope.Word, shiftDown)
                Else
                    RecordMove(macroType, "Left", MoveScope.Character, shiftDown)
                End If

            Case Keys.Right ' Right Arrow
                ' SHIFT indicates selection, CTRL indicates words instead of characters
                Dim macroType As LastMacro
                If controlDown Then
                    If shiftDown Then
                        macroType = LastMacro.RightArrowWordSelection
                    Else
                        macroType = LastMacro.RightArrowWord
                    End If
                Else
                    If shiftDown Then
                        macroType = (LastMacro.RightArrowCharSelection)
                    Else
                        macroType = (LastMacro.RightArrowChar)
                    End If
                End If

                If controlDown Then
                    RecordMove(macroType, "Right", MoveScope.Word, shiftDown)
                Else
                    RecordMove(macroType, "Right", MoveScope.Character, shiftDown)
                End If

            Case Keys.Up ' Up Arrow
                ' SHIFT indicates selection, CTRL indicates paragraphs instead of lines
                Dim macroType As LastMacro
                If controlDown Then
                    If shiftDown Then
                        macroType = LastMacro.UpArrowParaSelection
                    Else
                        macroType = LastMacro.UpArrowPara
                    End If
                Else
                    If shiftDown Then
                        macroType = (LastMacro.UpArrowLineSelection)
                    Else
                        macroType = (LastMacro.UpArrowLine)
                    End If
                End If

                If controlDown Then
                    RecordMove(macroType, "Up", MoveScope.Paragraph, shiftDown)
                Else
                    RecordMove(macroType, "Up", MoveScope.Line, shiftDown)
                End If

            Case Keys.Down ' Down Arrow
                ' SHIFT indicates selection, CTRL indicates paragraphs instead of lines
                Dim macroType As LastMacro
                If controlDown Then
                    If shiftDown Then
                        macroType = LastMacro.DownArrowParaSelection
                    Else
                        macroType = LastMacro.DownArrowPara
                    End If
                Else
                    If shiftDown Then
                        macroType = (LastMacro.DownArrowLineSelection)
                    Else
                        macroType = (LastMacro.DownArrowLine)
                    End If
                End If

                If controlDown Then
                    RecordMove(macroType, "Down", MoveScope.Paragraph, shiftDown)
                Else
                    RecordMove(macroType, "Down", MoveScope.Line, shiftDown)
                End If

            Case Keys.Prior, Keys.Next ' Page Up
                macroString &= "ActiveDocument.Object.Move"

                If System.Windows.Forms.Keys.Prior = currentKey Then
                    macroString &= "Up"
                Else
                    macroString &= "Down"
                End If

                If controlDown Then
                    If shiftDown Then
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomWindow)) & ", 1, " & CInt(Fix(tom.tomConstants.tomExtend)) & ")"
                    Else
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomWindow)) & ", 1, " & CInt(Fix(tom.tomConstants.tomMove)) & ")"
                    End If
                Else
                    If shiftDown Then
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomScreen)) & ", 1, " & CInt(Fix(tom.tomConstants.tomExtend)) & ")"
                    Else
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomScreen)) & ", 1, " & CInt(Fix(tom.tomConstants.tomMove)) & ")"
                    End If
                End If

                m_Recorder.RecordLine(macroString)

            Case Keys.End, Keys.Home
                macroString &= "ActiveDocument.Object."

                If System.Windows.Forms.Keys.End = currentKey Then
                    macroString &= "EndKey"
                Else
                    macroString &= "HomeKey"
                End If

                If controlDown Then
                    If shiftDown Then
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomStory)) & ", " & CInt(Fix(tom.tomConstants.tomExtend)) & ")"
                    Else
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomStory)) & ", " & CInt(Fix(tom.tomConstants.tomMove)) & ")"
                    End If
                Else
                    If shiftDown Then
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomLine)) & ", " & CInt(Fix(tom.tomConstants.tomExtend)) & ")"
                    Else
                        macroString &= "(" & CInt(Fix(tom.tomConstants.tomLine)) & ", " & CInt(Fix(tom.tomConstants.tomMove)) & ")"
                    End If
                End If

                m_Recorder.RecordLine(macroString)

            Case Keys.Insert
                ' Note that the CTRL completely disables this command.  Also the SHIFT+INSERT
                ' actually generates a WM_PASTE message rather than a WM_KEYDOWN
                If (Not controlDown) Then
                    macroString = "ActiveDocument.Object.Flags = ActiveDocument.Object.Flags Xor "
                    macroString &= CInt(Fix(tom.tomConstants.tomSelOvertype))
                    m_Recorder.RecordLine(macroString)
                End If
        End Select
    End Sub

    ' This event returns the literal key that was pressed and does not account for
    ' case of characters.  KeyPress is used to handled printable characters.
    Private Sub richTextBoxCtrl_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If m_Recorder.IsRecording() Then
            RecordNonprintableChar(e.KeyCode)
        End If
    End Sub

    ' The arguments of this event will give us the char value of the key press taking into
    ' account other characters press such as shift or caps lock for proper casing.
    Private Sub richTextBoxCtrl_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If m_Recorder.IsRecording() Then
            RecordPrintableChar(e.KeyChar)
        End If
    End Sub
#End Region

    Private Sub richTextBoxCtrl_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        If m_Recorder.IsRecording() Then
            richTextBoxCtrl.FilterMouseClickMessages = True
        Else
            richTextBoxCtrl.FilterMouseClickMessages = False
        End If
    End Sub
End Class
