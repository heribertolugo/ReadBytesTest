<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ByteObjectDataGridView1 = New ReadBytesTest.ByteObjectDataGridView()
        CType(Me.ByteObjectDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ByteObjectDataGridView1
        '
        Me.ByteObjectDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ByteObjectDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ByteObjectDataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.ByteObjectDataGridView1.Name = "ByteObjectDataGridView1"
        Me.ByteObjectDataGridView1.Size = New System.Drawing.Size(581, 445)
        Me.ByteObjectDataGridView1.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 445)
        Me.Controls.Add(Me.ByteObjectDataGridView1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.ByteObjectDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ByteObjectDataGridView1 As ReadBytesTest.ByteObjectDataGridView
End Class
