' PkgCmdID.vb
Imports System

Class PkgCmdIDList
    Private Sub New()
    End Sub

%MenuItemStart%        Public Const %CommandID% As UInteger = &H100%MenuItemEnd%
%ToolWindowItemStart%        Public Const %ToolCommandID% As UInteger = &H101%ToolWindowItemEnd%
%EditorStart%
    ' Menus
    Public Const IDM_TLB_RTF As UInteger = &H1 ' toolbar
    Public Const IDMX_RTF As UInteger = &H2 ' context menu
    Public Const IDM_RTFMNU_ALIGN As UInteger = &H4
    Public Const IDM_RTFMNU_SIZE As UInteger = &H5

    ' Menu Groups
    Public Const IDG_RTF_FMT_FONT1 As UInteger = &H1000
    Public Const IDG_RTF_FMT_FONT2 As UInteger = &H1001
    Public Const IDG_RTF_FMT_INDENT As UInteger = &H1002
    Public Const IDG_RTF_FMT_BULLET As UInteger = &H1003

    Public Const IDG_RTF_TLB_FONT1 As UInteger = &H1004
    Public Const IDG_RTF_TLB_FONT2 As UInteger = &H1005
    Public Const IDG_RTF_TLB_INDENT As UInteger = &H1006
    Public Const IDG_RTF_TLB_BULLET As UInteger = &H1007
    Public Const IDG_RTF_TLB_FONT_COMBOS As UInteger = &H1008

    Public Const IDG_RTF_CTX_EDIT As UInteger = &H1009
    Public Const IDG_RTF_CTX_PROPS As UInteger = &H100A

    Public Const IDG_RTF_EDITOR_CMDS As UInteger = &H100B

    ' Command IDs

    Public Const icmdStrike As UInteger = &H4
%EditorEnd%
End Class