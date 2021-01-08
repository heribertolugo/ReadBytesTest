Public Class ByteObjectDataGridView
    Inherits DataGridView

    Private WithEvents _columns As New DataGridViewByteObjectColumnCollection(Me)

    'Protected Overrides Sub OnColumnAdded(e As System.Windows.Forms.DataGridViewColumnEventArgs)
    '    Dim byteobjectCol As New ByteObjectColumn
    '    Dim eOverride As DataGridViewColumnEventArgs

    '    byteobjectCol.AutoSizeMode = e.Column.AutoSizeMode
    '    byteobjectCol.ContextMenuStrip = e.Column.ContextMenuStrip
    '    byteobjectCol.DataPropertyName = e.Column.DataPropertyName
    '    byteobjectCol.DefaultCellStyle = e.Column.DefaultCellStyle
    '    byteobjectCol.DefaultHeaderCellType = e.Column.DefaultHeaderCellType
    '    byteobjectCol.DisplayIndex = e.Column.DisplayIndex
    '    byteobjectCol.DividerWidth = e.Column.DividerWidth
    '    byteobjectCol.FillWeight = e.Column.FillWeight
    '    byteobjectCol.Frozen = e.Column.Frozen
    '    byteobjectCol.HeaderCell = e.Column.HeaderCell
    '    byteobjectCol.HeaderText = e.Column.HeaderText
    '    byteobjectCol.MinimumWidth = e.Column.MinimumWidth
    '    byteobjectCol.Name = e.Column.Name
    '    byteobjectCol.ReadOnly = e.Column.ReadOnly
    '    byteobjectCol.Resizable = e.Column.Resizable
    '    byteobjectCol.Selected = e.Column.Selected
    '    byteobjectCol.Site = e.Column.Site
    '    byteobjectCol.SortMode = e.Column.SortMode
    '    byteobjectCol.Tag = e.Column.Tag
    '    byteobjectCol.ToolTipText = e.Column.ToolTipText
    '    byteobjectCol.Visible = e.Column.Visible
    '    byteobjectCol.Width = e.Column.Width

    '    eOverride = New DataGridViewColumnEventArgs(byteobjectCol)
    '    MyBase.OnColumnAdded(eOverride)
    'End Sub

    Public Sub New()
        _columns = New DataGridViewByteObjectColumnCollection(Me)

    End Sub

    Private columnAddedByCode As Boolean = False

    Protected Overrides Sub OnColumnAdded(e As System.Windows.Forms.DataGridViewColumnEventArgs)
        If Not columnAddedByCode Then
            MyBase.OnColumnAdded(e)

            columnAddedByCode = True

            MyBase.Columns.Remove(e.Column)
            MyBase.Columns.Insert(e.Column.Index, CreateAsByteObjectColumn(e.Column))
        Else
            columnAddedByCode = False
        End If
    End Sub

    'Protected Overrides Function CreateColumnsInstance() As System.Windows.Forms.DataGridViewColumnCollection
    '    'Return MyBase.CreateColumnsInstance()
    '    MyBase.CreateColumnsInstance()
    '    _columns = New DataGridViewByteObjectColumnCollection(Me)

    '    Return _columns
    'End Function

    Public Overrides Function BeginEdit(selectAll As Boolean) As Boolean
        Return MyBase.BeginEdit(selectAll)
    End Function

    Protected Overrides Sub OnCellBeginEdit(e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        MyBase.OnCellBeginEdit(e)
    End Sub

    'Public Shadows ReadOnly Property Columns As DataGridViewColumnCollection
    '    Get
    '        Return If(Me._columns.Count = 0, Me.CreateColumnsInstance, _columns)
    '    End Get
    '    'Set(value As DataGridViewColumnCollection)
    '    '    _columns = CType(value, DataGridViewByteObjectColumnCollection)
    '    'End Set
    'End Property

    'Private Sub nboo(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs) Handles _columns.CollectionChanged
    '    If e.Action = System.ComponentModel.CollectionChangeAction.Add Then
    '        Dim cea As New DataGridViewColumnEventArgs(_columns(_columns.Count - 1))
    '        'MyBase.Co = _columns(_columns.Count - 1)
    '    End If
    'End Sub



    Private Function CreateAsByteObjectColumn(ByVal Column As DataGridViewColumn) As ByteObjectColumn
        Dim byteobjectCol As New ByteObjectColumn

        byteobjectCol.AutoSizeMode = Column.AutoSizeMode
        byteobjectCol.ContextMenuStrip = Column.ContextMenuStrip
        byteobjectCol.DataPropertyName = Column.DataPropertyName
        byteobjectCol.DefaultCellStyle = Column.DefaultCellStyle
        byteobjectCol.DefaultHeaderCellType = Column.DefaultHeaderCellType
        byteobjectCol.DisplayIndex = Column.DisplayIndex
        byteobjectCol.DividerWidth = Column.DividerWidth
        byteobjectCol.FillWeight = Column.FillWeight
        byteobjectCol.Frozen = Column.Frozen
        byteobjectCol.HeaderCell = Column.HeaderCell
        byteobjectCol.HeaderText = "soso" ' Column.HeaderText
        byteobjectCol.MinimumWidth = Column.MinimumWidth
        byteobjectCol.Name = Column.Name
        byteobjectCol.ReadOnly = Column.ReadOnly
        byteobjectCol.Resizable = Column.Resizable
        byteobjectCol.Selected = Column.Selected
        byteobjectCol.Site = Column.Site
        byteobjectCol.SortMode = Column.SortMode
        byteobjectCol.Tag = Column.Tag
        byteobjectCol.ToolTipText = Column.ToolTipText
        byteobjectCol.Visible = Column.Visible
        byteobjectCol.Width = Column.Width

        Return byteobjectCol
    End Function

    'Private Sub OnColumnAdded(sender As Object, e As DataGridViewColumnEventArgs)
    '    Throw New NotImplementedException
    'End Sub

End Class


Public Class DataGridViewByteObjectColumnCollection
    Inherits DataGridViewColumnCollection

    'Private _list As ArrayList

    Public Sub New(dataGridView As DataGridView)
        MyBase.New(dataGridView)

        'MyBase.List = New ArrayList
    End Sub

    Public Overrides Function Add(columnName As String, headerText As String) As Integer
        Dim bObjCol As New ByteObjectColumn
        bObjCol.Name = columnName
        bObjCol.HeaderText = headerText

        'Dim i As Integer = MyBase.List.Add(bObjCol)
        Dim q As ArrayList = MyBase.List
        Return (Me.Add(bObjCol))
    End Function

    Public Overrides Function Add(dataGridViewColumn As System.Windows.Forms.DataGridViewColumn) As Integer

        Dim c As New DataGridViewColumn
        c.DisplayIndex = MyBase.Count
        c.Visible = True
        c.Name = "nono"
        c.HeaderText = "nono"

        MyBase.List.Add(c)
        Dim e As New System.ComponentModel.CollectionChangeEventArgs(System.ComponentModel.CollectionChangeAction.Add, MyBase.List)
        MyBase.OnCollectionChanged(e)
        'Me.OnCollectionChanged(e)
        'MyBase.Insert(MyBase.List.Count - 1, dataGridViewColumn)
        'MyBase.Add(dataGridViewColumn)
        'MyBase.Item(dataGridViewColumn.Name).DisplayIndex
        'Return (MyBase.List.Count)
        'Dim c As ByteObjectColumn = CreateAsByteObjectColumn(dataGridViewColumn)

        Return (MyBase.Count - 1)

    End Function

    Public Overrides Sub AddRange(ParamArray dataGridViewColumns() As System.Windows.Forms.DataGridViewColumn)
        For Each c As DataGridViewColumn In dataGridViewColumns
            MyBase.AddRange(CreateAsByteObjectColumn(c))
        Next
    End Sub

    Private Function CreateAsByteObjectColumn(ByVal Column As DataGridViewColumn) As DataGridViewColumn
        Dim byteobjectCol As New DataGridViewColumn

        byteobjectCol.AutoSizeMode = Column.AutoSizeMode
        byteobjectCol.ContextMenuStrip = Column.ContextMenuStrip
        byteobjectCol.DataPropertyName = Column.DataPropertyName
        byteobjectCol.DefaultCellStyle = Column.DefaultCellStyle
        byteobjectCol.DefaultHeaderCellType = Column.DefaultHeaderCellType
        byteobjectCol.DisplayIndex = Column.DisplayIndex
        byteobjectCol.DividerWidth = Column.DividerWidth
        byteobjectCol.FillWeight = Column.FillWeight
        byteobjectCol.Frozen = Column.Frozen
        byteobjectCol.HeaderCell = Column.HeaderCell
        byteobjectCol.HeaderText = Column.HeaderText
        byteobjectCol.MinimumWidth = Column.MinimumWidth
        byteobjectCol.Name = Column.Name
        byteobjectCol.ReadOnly = Column.ReadOnly
        byteobjectCol.Resizable = Column.Resizable
        byteobjectCol.Selected = Column.Selected
        byteobjectCol.Site = Column.Site
        byteobjectCol.SortMode = Column.SortMode
        byteobjectCol.Tag = Column.Tag
        byteobjectCol.ToolTipText = Column.ToolTipText
        byteobjectCol.Visible = Column.Visible
        byteobjectCol.Width = Column.Width

        Return byteobjectCol
    End Function

End Class