Imports Microsoft.VisualBasic
Imports Microsoft.VisualStudio
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Security.Permissions
Imports System.Diagnostics.CodeAnalysis

Partial Public Class EditorTextBox
    Inherits RichTextBox

    Private m_FilterMouseClickMessages As Boolean

    Public Property FilterMouseClickMessages() As Boolean
        Get
            Return m_FilterMouseClickMessages
        End Get
        Set(ByVal value As Boolean)
            m_FilterMouseClickMessages = value
        End Set
    End Property

    ' Override WndProc so that we can ignore the mouse clicks when macro recording
    <SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case NativeMethods.WM_LBUTTONDOWN, NativeMethods.WM_RBUTTONDOWN, NativeMethods.WM_MBUTTONDOWN, NativeMethods.WM_LBUTTONDBLCLK
                If m_FilterMouseClickMessages Then
                    Focus()
                    Return
                End If
        End Select

        MyBase.WndProc(m)
    End Sub

    Private Sub richTextBoxCtrl_MouseRecording(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.MouseEnter
        SetCursor(m_FilterMouseClickMessages)
    End Sub

    Private Sub richTextBoxCtrl_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.MouseLeave
        If m_FilterMouseClickMessages Then
            SetCursor((Not m_FilterMouseClickMessages))
        End If
    End Sub

    Private Sub SetCursor(ByVal cursorNo As Boolean)
        If cursorNo Then
            Cursor = Cursors.No
        Else
            Cursor = Cursors.Default
        End If
    End Sub
End Class