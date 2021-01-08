<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextBoxWithButton
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox_Control = New System.Windows.Forms.TextBox()
        Me.Image_Control = New System.Windows.Forms.PictureBox()
        CType(Me.Image_Control, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox_Control
        '
        Me.TextBox_Control.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_Control.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_Control.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_Control.Location = New System.Drawing.Point(0, 0)
        Me.TextBox_Control.Multiline = True
        Me.TextBox_Control.Name = "TextBox_Control"
        Me.TextBox_Control.Size = New System.Drawing.Size(815, 22)
        Me.TextBox_Control.TabIndex = 0
        '
        'Image_Control
        '
        Me.Image_Control.BackColor = System.Drawing.SystemColors.Window
        Me.Image_Control.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Image_Control.Dock = System.Windows.Forms.DockStyle.Right
        Me.Image_Control.Location = New System.Drawing.Point(815, 0)
        Me.Image_Control.Name = "Image_Control"
        Me.Image_Control.Size = New System.Drawing.Size(22, 22)
        Me.Image_Control.TabIndex = 1
        Me.Image_Control.TabStop = False
        '
        'TextBoxWithButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.TextBox_Control)
        Me.Controls.Add(Me.Image_Control)
        Me.Name = "TextBoxWithButton"
        Me.Size = New System.Drawing.Size(837, 22)
        CType(Me.Image_Control, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents TextBox_Control As System.Windows.Forms.TextBox
    Private WithEvents Image_Control As System.Windows.Forms.PictureBox

End Class
