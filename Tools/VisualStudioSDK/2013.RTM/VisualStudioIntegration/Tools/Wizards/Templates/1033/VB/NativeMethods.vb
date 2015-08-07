Imports Microsoft.VisualBasic
Imports System
Imports System.Runtime.InteropServices

''' <summary>
''' This class will contain all methods that we need to import.
''' </summary>
<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")> _
Friend Class NativeMethods
    Public Const WM_LBUTTONDOWN As Integer = &H201
    Public Const WM_LBUTTONDBLCLK As Integer = &H203
    Public Const WM_RBUTTONDOWN As Integer = &H204
    Public Const WM_MBUTTONDOWN As Integer = &H207

    'Including a private constructor to prevent a compiler-generated default constructor
    Private Sub New()
    End Sub

    ' Import the SendMessage function from user32.dll
    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, <System.Runtime.InteropServices.Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef lParam As Object) As IntPtr
    End Function
End Class