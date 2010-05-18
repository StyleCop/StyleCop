Partial Class MyEditor
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()

        Me.richTextBoxCtrl = New EditorTextBox()
        Me.SuspendLayout()
        ' 
        ' richTextBoxCtrl
        ' 
        Me.richTextBoxCtrl.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.richTextBoxCtrl.Location = New System.Drawing.Point(0, 0)
        Me.richTextBoxCtrl.Name = "richTextBoxCtrl"
        Me.richTextBoxCtrl.Size = New System.Drawing.Size(150, 150)
        Me.richTextBoxCtrl.TabIndex = 0
        AddHandler Me.richTextBoxCtrl.MouseEnter, New System.EventHandler(AddressOf Me.richTextBoxCtrl_MouseEnter)
        AddHandler Me.richTextBoxCtrl.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.richTextBoxCtrl_KeyPress)
        AddHandler Me.richTextBoxCtrl.KeyDown, New System.Windows.Forms.KeyEventHandler(AddressOf Me.richTextBoxCtrl_KeyDown)
        ' 
        ' MyEditor
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.Controls.Add(Me.richTextBoxCtrl)
        Me.Name = "MyEditor"
        Me.ResumeLayout(False)
    End Sub

#End Region

    Private richTextBoxCtrl As EditorTextBox
End Class
