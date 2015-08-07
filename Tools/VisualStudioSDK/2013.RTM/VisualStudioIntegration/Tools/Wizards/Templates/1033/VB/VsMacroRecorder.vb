Imports Microsoft.VisualBasic
Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports Microsoft.VisualStudio
Imports Microsoft.VisualStudio.Shell.Interop

' Last command type sent to the macro recorder. Note that there are more commands
' recorded than is implied by this list. Commands in this list (other than
' LastMacroNone) are coalesced when multiples of the same command are received
' consecutively.

' This enum should be extended or replaced with your own command identifiers to enable
' Coalescing of commands.
Public Enum LastMacro
    None
    Text
    DownArrowLine
    DownArrowLineSelection
    DownArrowPara
    DownArrowParaSelection
    UpArrowLine
    UpArrowLineSelection
    UpArrowPara
    UpArrowParaSelection
    LeftArrowChar
    LeftArrowCharSelection
    LeftArrowWord
    LeftArrowWordSelection
    RightArrowChar
    RightArrowCharSelection
    RightArrowWord
    RightArrowWordSelection
    DeleteChar
    DeleteWord
    BackspaceChar
    BackspaceWord
End Enum

<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")> _
Public Enum MoveScope
    Character = tom.tomConstants.tomCharacter
    Word = tom.tomConstants.tomWord
    Line = tom.tomConstants.tomLine
    Paragraph = tom.tomConstants.tomParagraph
End Enum

''' <summary>
''' The VSMacroRecorder class implementation and the IVsMacroRecorder Interface definition
''' were included here in this separate class because they were not included in the 
''' interop assemblies shipped with Visual Studio 2005.
''' 
''' When implementing a macro recorder this class should be copied into your own name space
''' and not shared between different 3rd party packages.
''' </summary>
Public Class VSMacroRecorder
    Private m_VsMacroRecorder As IVsMacroRecorder
    Private m_LastMacroRecorded As LastMacro
    Private m_TimesPreviouslyRecorded As UInteger
    Private m_GuidEmitter As Guid

    Public Sub New(ByVal emitter As Guid)
        Me.m_LastMacroRecorded = LastMacro.None

        Me.m_GuidEmitter = emitter
    End Sub

    ' Compiler generated destructor is fine

    Public Sub Reset()
        m_LastMacroRecorded = LastMacro.None
        m_TimesPreviouslyRecorded = 0
    End Sub

    Public Sub [Stop]()
        Reset()
        m_VsMacroRecorder = Nothing
    End Sub

    Public Function IsLastRecordedMacro(ByVal macro As LastMacro) As Boolean
        If (macro = m_LastMacroRecorded AndAlso ObjectIsLastMacroEmitter()) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsRecording() As Boolean
        ' If the property can not be retrieved it is assumed no macro is being recorded.
        Dim recordState As VSRECORDSTATE = VSRECORDSTATE.VSRECORDSTATE_OFF

        ' Retrieve the macro recording state.
        Dim vsShell As IVsShell = CType(Microsoft.VisualStudio.Shell.Package.GetGlobalService(GetType(SVsShell)), IVsShell)
        If vsShell IsNot Nothing Then
            Dim var As Object = Nothing
            If ErrorHandler.Succeeded(vsShell.GetProperty(CInt(Fix(__VSSPROPID.VSSPROPID_RecordState)), var)) AndAlso Nothing IsNot var Then
                recordState = CType(var, VSRECORDSTATE)
            End If
        End If

        ' If there is a change in the record state to OFF or ON we must either obtain
        ' or release the macro recorder. 
        If recordState = VSRECORDSTATE.VSRECORDSTATE_ON AndAlso m_VsMacroRecorder Is Nothing Then
            ' If this QueryService fails we no macro recording
            m_VsMacroRecorder = CType(Microsoft.VisualStudio.Shell.Package.GetGlobalService(GetType(IVsMacroRecorder)), IVsMacroRecorder)
        ElseIf recordState = VSRECORDSTATE.VSRECORDSTATE_OFF AndAlso m_VsMacroRecorder IsNot Nothing Then
            ' If the macro recording state has been switched off then we can release
            ' the service. Note that if the state has become paused we take no action.
            [Stop]()
        End If

        Return (m_VsMacroRecorder IsNot Nothing)
    End Function

    Public Sub RecordLine(ByVal line As String)
        m_VsMacroRecorder.RecordLine(line, m_GuidEmitter)
        Reset()
    End Sub

    Public Function RecordBatchedLine(ByVal macroRecorded As LastMacro, ByVal line As String) As Boolean
        If Nothing Is line Then
            line = String.Empty
        End If

        Return RecordBatchedLine(macroRecorded, line, 0)
    End Function

    Public Function RecordBatchedLine(ByVal macroRecorded As LastMacro, ByVal line As String, ByVal maxLineLength As Integer) As Boolean
        If Nothing Is line Then
            line = String.Empty
        End If

        If maxLineLength > 0 AndAlso line.Length >= maxLineLength Then
            ' Reset the state after recording the line, so it will not be appended to further
            RecordLine(line)
            ' Notify the caller that the this line will not be appended to further
            Return True
        End If

        If IsLastRecordedMacro(macroRecorded) Then
            m_VsMacroRecorder.ReplaceLine(line, m_GuidEmitter)
            ' m_LastMacroRecorded can stay the same

            m_TimesPreviouslyRecorded = CType(m_TimesPreviouslyRecorded + 1, UInteger)

        Else
            m_VsMacroRecorder.RecordLine(line, m_GuidEmitter)
            m_LastMacroRecorded = macroRecorded
            m_TimesPreviouslyRecorded = 1
        End If

        Return False
    End Function

    Public Function GetTimesPreviouslyRecorded(ByVal macro As LastMacro) As UInteger
        If IsLastRecordedMacro(macro) Then
            Return m_TimesPreviouslyRecorded
        Else
            Return 0
        End If
    End Function

    ' This function determines if the last line sent to the macro recorder was
    ' sent from this emitter. Note it is not valid to call this function if
    ' macro recording is switched off.
    Private Function ObjectIsLastMacroEmitter() As Boolean
        Dim guid As Guid
        m_VsMacroRecorder.GetLastEmitterId(guid)
        Return guid.Equals(m_GuidEmitter)
    End Function
End Class

#Region "IVsMacro Interfaces"
<StructLayout(LayoutKind.Sequential, Pack:=4), ComConversionLoss()> _
Friend Structure _VSPROPSHEETPAGE
    Public dwSize As UInteger
    Public dwFlags As UInteger
    <ComAliasName("vbapkg.ULONG_PTR")> _
    Public hInstance As UInteger
    Public wTemplateId As UShort
    Public dwTemplateSize As UInteger
    <ComConversionLoss()> _
    Public pTemplate As IntPtr
    <ComAliasName("vbapkg.ULONG_PTR")> _
    Public pfnDlgProc As UInteger
    <ComAliasName("vbapkg.LONG_PTR")> _
    Public lParam As Integer
    <ComAliasName("vbapkg.ULONG_PTR")> _
    Public pfnCallback As UInteger
    <ComConversionLoss()> _
    Public pcRefParent As IntPtr
    Public dwReserved As UInteger
    <ComConversionLoss(), ComAliasName("vbapkg.wireHWND")> _
    Public hwndDlg As IntPtr
End Structure

Friend Enum _VSRECORDMODE
    ' Fields
    VSRECORDMODE_ABSOLUTE = 1
    VSRECORDMODE_RELATIVE = 2
End Enum

<ComImport(), ComConversionLoss(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("55ED27C1-4CE7-11D2-890F-0060083196C6")> _
Friend Interface IVsMacros
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub GetMacroCommands(<Out()> ByVal ppsaMacroCanonicalNames As IntPtr)
End Interface

<ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("04BBF6A5-4697-11D2-890E-0060083196C6")> _
Friend Interface IVsMacroRecorder
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub RecordStart(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszReserved As String)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub RecordEnd()
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub RecordLine(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszLine As String, <[In]()> ByRef rguidEmitter As Guid)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub GetLastEmitterId(<Out()> ByRef pguidEmitter As Guid)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub ReplaceLine(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszLine As String, <[In]()> ByRef rguidEmitter As Guid)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub RecordCancel()
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub RecordPause()
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub RecordResume()
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub SetCodeEmittedFlag(<[In]()> ByVal fFlag As Integer)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub GetCodeEmittedFlag(<Out()> ByVal pfFlag As Integer)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub GetKeyWord(<[In]()> ByVal uiKeyWordId As UInteger, <Out(), MarshalAs(UnmanagedType.BStr)> ByVal pbstrKeyWord As String)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub IsValidIdentifier(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszIdentifier As String)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub GetRecordMode(<Out()> ByVal peRecordMode As _VSRECORDMODE)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub SetRecordMode(<[In]()> ByVal eRecordMode As _VSRECORDMODE)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub GetStringLiteralExpression(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszStringValue As String, <Out(), MarshalAs(UnmanagedType.BStr)> ByVal pbstrLiteralExpression As String)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub ExecuteLine(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszLine As String)
    <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
    Sub AddTypeLibRef(<[In]()> ByRef guidTypeLib As Guid, <[In]()> ByVal uVerMaj As UInteger, <[In]()> ByVal uVerMin As UInteger)
End Interface
#End Region