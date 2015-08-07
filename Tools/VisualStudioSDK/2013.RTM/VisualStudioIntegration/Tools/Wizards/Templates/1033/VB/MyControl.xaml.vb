Imports System.Security.Permissions

'''<summary>
'''  Interaction logic for MyControl.xaml
'''</summary>
Partial Public Class MyControl
    Inherits System.Windows.Controls.UserControl

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")> _
    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        
        System.Windows.MessageBox.Show(String.Format(System.Globalization.CultureInfo.CurrentUICulture, "%ToolWindowOnButtonClickText%", Me.ToString()), _
                        "%ToolWindowName%")
    End Sub
End Class