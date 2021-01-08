Public Class ByteObjectEditingControl
    'Inherits DateTimePicker
    Inherits TextBox
    Implements IDataGridViewEditingControl

    Private _dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer
    Private _byteObject As ByteObject
    Private previousByteValue As Byte


    Public Sub New()
        'Me.Format = DateTimePickerFormat.Short
        _byteObject = New ByteObject
        _byteObject.ToStringFormat = ByteObjectToString.Int
    End Sub

    Private Property ByteObject As ByteObject
        Get
            Return _byteObject
        End Get
        Set(value As ByteObject)
            _byteObject = value
            previousByteValue = _byteObject.ByteVal
        End Set
    End Property


    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            'Return Me.Value.ToShortDateString()
            Return Me.ByteObject.ToString
        End Get

        Set(ByVal value As Object)
            'If TypeOf value Is String Then
            'Me.Value = DateTime.Parse(CStr(value))
            Me.ByteObject.SetFromCurrent(value)
            'End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        'Return Me.Value.ToShortDateString()
        Return Me.ByteObject.ToString

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        'Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        'Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        'Select Case key And Keys.KeyCode
        '    Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
        '        Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

        Return True

        '    Case Else
        '        Return False
        'End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.
        previousByteValue = Me.ByteObject.ByteVal
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return _dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            _dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Public Property CurrentDisplayType As ByteObjectToString
        Get
            Return Me.ByteObject.ToStringFormat
        End Get
        Set(value As ByteObjectToString)
            Me.ByteObject.ToStringFormat = value
        End Set
    End Property

    'Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

    '    ' Notify the DataGridView that the contents of the cell have changed.
    '    valueIsChanged = True
    '    Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
    '    MyBase.OnValueChanged(eventargs)

    'End Sub

    Protected Overrides Sub OnLeave(e As System.EventArgs)
        If Not IsNothing(previousByteValue) Then
            If previousByteValue <> Me.ByteObject.ByteVal Then
                If Me.ByteObject.SetFromCurrent(Me.Text) Then
                    valueIsChanged = True
                    'Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
                Else
                    valueIsChanged = False
                    'Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
                End If

            Else
                valueIsChanged = False
            End If
        End If

        Me.EditingControlDataGridView.NotifyCurrentCellDirty(valueIsChanged)
        MyBase.OnLeave(e)
    End Sub
End Class
