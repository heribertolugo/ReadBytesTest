Public Class ByteObjectColumn
    Inherits DataGridViewColumn
    'Private Shared _index As Integer = -1

    Public Sub New()
        MyBase.New(New ByteObjectCell())
        'MyBase.new(New DataGridViewTextBoxCell)
    End Sub


    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a ByteObjectCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(DataGridViewCell)) _
                Then
                Throw New InvalidCastException("Must be a ByteObjectCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property
End Class
