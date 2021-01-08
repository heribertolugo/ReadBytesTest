Public Class ByteObjectCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
        'Me.Value = New ByteObject
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        'Dim ctl As ByteObjectEditingControl = _
        '    CType(DataGridView.EditingControl, ByteObjectEditingControl)
        ''ctl.Value = CType(Me.Value, DateTime)
        'ctl.Text = CType(Me.Value, ByteObject).ToString
        Dim ctl As ByteObjectEditingControl = _
            CType(DataGridView.EditingControl, ByteObjectEditingControl)
        'ctl.Value = CType(Me.Value, DateTime)
        ctl.Text = Me.Value.ToString

    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(DataGridViewTextBoxEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            '' Return the type of the value that CalendarCell contains.
            'Return GetType(DateTime)
            ' Return the type of the value that ByteObject contains.
            Return GetType(ByteObject)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            'Return DateTime.Now.
            Return Nothing
        End Get
    End Property


End Class
