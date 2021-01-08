Imports System.IO

Public Class MainForm
    Private WithEvents FileGetDialog As New OpenFileDialog
    Private WithEvents FileSaveDialog As New SaveFileDialog
    Private WithEvents toolTip As New ToolTip
    Private WithEvents SrchItmsInDgvContextMnu As New ContextMenuStrip

    Private WithEvents progWin As ProgressWin
    Private WithEvents ProgressThread As System.ComponentModel.BackgroundWorker

    Private workingExtension As String = ".txt"

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '''''''''' SET THE OPEN FILE DIALOG PROPERTIES '''''''''''''''
        Me.FileGetDialog.Title = "Select a file"
        Me.FileGetDialog.Multiselect = False

        '''''''''' SET THE BYTES DATAGRIDVIEW PROPERTIES '''''''''''''
        Me.BytesGrid_DGView.AutoGenerateColumns = False

        '''''''''' SET THE PROPERTIES FOR THE CONTEXT MENU FOR THE DATAGRIDVIEW 
        SrchItmsInDgvContextMnu.Name = "DgvContextMenu"
        SrchItmsInDgvContextMnu.Items.Add("Copy selected as comma delimited", Nothing, AddressOf Me.CopySelectedAsCommaDel)
        SrchItmsInDgvContextMnu.Items.Add("Copy selected as tab delimited", Nothing, AddressOf Me.CopySelectedAsTabDel)

        '''''''''' ADD/ASSIGN THE CONTEXT MENU
        Me.SearchItemsIndeces_DGView.ContextMenuStrip = SrchItmsInDgvContextMnu
        Me.BytesGrid_DGView.ContextMenuStrip = SrchItmsInDgvContextMnu

        '''''''''' SET PROPERTIES FOR BACKGROUND WORKER ''''''''''''''
        Me.ProgressThread = New System.ComponentModel.BackgroundWorker()
        Me.ProgressThread.WorkerSupportsCancellation = True
        Me.ProgressThread.WorkerReportsProgress = True
        progWin = New ProgressWin

        '''''''''' SET THE ITEMS IN COMBOBOX TO CHANGE THE FORMATTING OF THE VALUES IN DATAGRIDVIEW WHICH SHOWS THE FILES BYTES
        'Dim members As String() = System.Enum.GetNames(GetType(ByteObjectToString))
        'Me.ChangeResultFormat_CBox.Items.AddRange(System.Enum.GetNames(GetType(ByteObjectToString)))
        Me.WorkingFormat_CBox.Items.Add(New KeyValpair(Of String, ByteObjectToString)("Results to Integer", ByteObjectToString.Int))
        Me.WorkingFormat_CBox.Items.Add(New KeyValpair(Of String, ByteObjectToString)("Results to Hex", ByteObjectToString.Hex))
        Me.WorkingFormat_CBox.Items.Add(New KeyValpair(Of String, ByteObjectToString)("Results to HexLong", ByteObjectToString.HexLong))
        Me.WorkingFormat_CBox.Items.Add(New KeyValpair(Of String, ByteObjectToString)("Results to Binary", ByteObjectToString.Binary))
        Me.WorkingFormat_CBox.Items.Add(New KeyValpair(Of String, ByteObjectToString)("Results to ASCII", ByteObjectToString.Ascii))
        Me.WorkingFormat_CBox.SelectedIndex = 0


        'Form2.Show()
    End Sub

    Private Sub GetFile_But_Click(sender As System.Object, e As System.EventArgs) Handles OpenFile_TStripBut.Click, FilePath_TxtBoxBut.ImageClicked
        FileGetDialog.ShowDialog()
    End Sub

    Public Sub ReturnFilePath(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FileGetDialog.FileOk
        Me.FilePath_TxtBoxBut.Text = CType(sender, OpenFileDialog).FileName
    End Sub

    Private Sub ShowByteData_But_Click(sender As System.Object, e As System.EventArgs) Handles GetByteData_But.Click
        Dim filepath As String = Me.FilePath_TxtBoxBut.Text
        'Get a array of byte data from the file we selected
        If IO.File.Exists(filepath) Then
            'Dim hider As New Panel
            'hider.BackColor = Color.FromArgb(255, Color.Black)
            'hider.Size = Me.Size
            'Me.Controls.Add(hider)
            'hider.BringToFront()

            'progWin.ShowInTaskbar = False
            'progWin.TopMost = True
            'progWin.StartPosition = FormStartPosition.Manual
            'progWin.Location = New Point(CInt(Me.Location.X + ((Me.Width - ProgressWin.Width) / 2)), Me.Location.Y + (Me.Height - ProgressWin.Height))
            'progWin.Show()


            'Our collection of bytedata
            Dim byteData As Byte() = GetByteData(filepath)
            'byteData1 = GetByteData(filepath)

            'If we already have items to be searched for lets display them. For no good reason.
            'If Trim(Me.Search_TxtBox.Text).Count > 0 Then
            '    Dim searchItems As IEnumerable = Helper.splitString(Me.Search_TxtBox.Text)
            '    Dim foundItems As Dictionary(Of Integer, Object) = Helper.GetItemsLocation(searchItems, byteData, Me.AsHex_RadBut.Checked, Me.ConsecutiveVal_ChkBox.Checked)
            '    Dim test = foundItems.Values.Distinct().ToList()

            '    For Each item As Byte In foundItems.Values.Distinct
            '        Dim lambdaItem As Integer = CInt(item)
            '        Dim r = foundItems.Where(Function(x, z) CInt(x.Value) = lambdaItem).ToList
            '        Dim l As New List(Of Object)

            '        For Each h As KeyValuePair(Of Integer, Object) In r
            '            l.Add(h.Key)
            '        Next

            '        Dim kv As New KeyValpair(Of Integer, Object)(CInt(item), l)

            '        Me.SearchItems_ListBox.Items.Add(kv)
            '    Next
            'End If

            Me.workingExtension = Path.GetExtension(filepath)

            Me.SearchItems_ListBox.Items.Clear()
            Me.BytesGrid_DGView.Rows.Clear()
            Me.BytesGrid_DGView.Columns.Clear()
            Me.SearchItemsIndeces_DGView.Rows.Clear()
            Me.SearchItemsIndeces_DGView.Columns.Clear()

            'progWin.UpdateProgressMax(byteData1.Count)
            'Now show that data in datagridview
            'Helper.ShowDataToGrid(byteData, Me.BytesGrid_DGView, Me.progWin.ProgressTotal, Me.progWin.ProgressVal, Me.progWin.ProgressText)
            'Me.ProgressThread.RunWorkerAsync()
            'Threading.Thread.Sleep(1000)
            Dim byteObjects As New List(Of ByteObject)

            For Each b As Byte In byteData
                byteObjects.Add(New ByteObject(b))
            Next

            Helper.ShowDataToGrid(byteObjects, Me.BytesGrid_DGView)
        End If
    End Sub
    'Private byteData1 As ICollection
    Private Sub ProgressWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles ProgressThread.DoWork
        'Helper.ShowDataToGrid(byteData1, Me.BytesGrid_DGView, Me.ProgressThread)

        progWin.ShowInTaskbar = False
        progWin.TopMost = True
        progWin.StartPosition = FormStartPosition.Manual
        progWin.Location = New Point(CInt(Me.Location.X + ((Me.Width - ProgressWin.Width) / 2)), Me.Location.Y + (Me.Height - ProgressWin.Height))
        progWin.Show()

    End Sub

    Private Sub ProgressUpdate(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles ProgressThread.ProgressChanged
        Me.progWin.ProgressTotal(sender, e)
        Me.progWin.ProgressText(sender, e)
    End Sub

    Private Sub DisplayFoundItems()
        If Trim(Me.Search_TxtBox.Text).Count > 0 Then
            Dim searchItems As IEnumerable = Helper.splitString(Me.Search_TxtBox.Text)
            'Dim foundItems As Dictionary(Of Integer, Object) = Helper.GetItemsLocation(searchItems, Helper.GetDataFromGrid(Me.BytesGrid_DGView), Me.AsHex_RadBut.Checked)
            'Dim test = foundItems.Values.Distinct().ToList()
            Dim foundItems As Dictionary(Of Integer, Byte) = Helper.GetItemsLocation(searchItems, Me.BytesGrid_DGView, Me.AsHex_RadBut.Checked, Me.ConsecutiveVal_ChkBox.Checked)


            For Each item As Byte In foundItems.Values.Distinct
                Dim lambdaItem As Byte = item
                Dim r = foundItems.Where(Function(x, z) CInt(x.Value) = lambdaItem).ToList
                Dim l As New List(Of Object)

                For Each h As KeyValuePair(Of Integer, Byte) In r
                    l.Add(h.Key)
                Next

                'The key is what will be displayed in listbox, the value is a list of all the indeces in which the key was found
                'The indeces are values of its location in a byte array (or linear read), not the indeces of its position in a grid
                Dim kv As New KeyValpair(Of Byte, Object)(item, l)

                Me.SearchItems_ListBox.Items.Add(kv)
            Next

        End If
    End Sub

    Private Sub Search_But_Click(sender As System.Object, e As System.EventArgs) Handles Search_But.Click
        'Get the string and remove all spaces and tab characters
        Dim searchText As String = Trim(Me.Search_TxtBox.Text)

        'Now test to make sure that string actually contains something before we do anything
        If searchText.Length > 0 Then
            'Turn the contents in our searchbox to a list
            Dim searchList As IEnumerable = Helper.splitString(Me.Search_TxtBox.Text)
            'Get the locations of the items in our list from the datagridview as they would be if they were a string (or array), not the locations as they would be in a datagridview
            Dim itemLocastions As IEnumerable = Helper.GetItemsLocation(searchList, Me.BytesGrid_DGView, Me.AsHex_RadBut.Checked, Me.ConsecutiveVal_ChkBox.Checked).Keys.ToList

            'Highlight the locations in our datagridview
            Helper.HighlightGridByPos(itemLocastions, Me.BytesGrid_DGView)

            'Or you can just call them all and not sperate into variables
            'Helper.HighlightGridByPos(Helper.GetItemsLocation(Helper.splitString(Me.Search_TxtBox.Text), Me.BytesGrid_DGView, Me.AsHex_RadBut.Checked).Keys.ToList, Me.BytesGrid_DGView, True)

            GetLocations_But_Click(sender, e)

        End If
    End Sub

    Private Sub SearchItems_ListBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles SearchItems_ListBox.SelectedIndexChanged
        Dim vList As ICollection = CType(CType(Me.SearchItems_ListBox.SelectedItem, KeyValpair(Of Byte, Object)).Value, ICollection)
        'Dim bList(0) As Byte '= CType(CType(Me.SearchItems_ListBox.SelectedItem, KeyValpair(Of Integer, Byte())).Value, Byte())
        'Dim vList As Byte()
        'Dim test As List(Of ByteObject)

        'For Each b As Byte In CType(Me.SearchItems_ListBox.SelectedItem, KeyValpair(Of Integer, Byte())).Value
        '    Array.Resize(bList, bList.Count + 1)
        '    bList(bList.Count - 1) = b
        'Next

        'CType(Me.SearchItems_ListBox.SelectedItem, KeyValpair(Of String, Byte)).Value
        Me.SearchItemsIndeces_DGView.Rows.Clear()
        Me.SearchItemsIndeces_DGView.Columns.Clear()
        Helper.ShowDataToGrid(vList, Me.SearchItemsIndeces_DGView)

        Me.TotalCountFound_Lbl.Text = vList.Count.ToString
    End Sub

    Private Sub GetLocations_But_Click(sender As System.Object, e As System.EventArgs)

        SearchItems_ListBox.Items.Clear()
        DisplayFoundItems()
    End Sub

    Private Sub SaveLocations_But_Click(sender As System.Object, e As System.EventArgs) Handles SaveLocations_But.Click
        Dim outputData As New List(Of String)
        Dim filePath As String
        Dim delim As String

        If Me.SearchItemsIndeces_DGView.Rows.Count < 1 Then
            MsgBox("There is nothing to save!", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "Error")
            Exit Sub
        End If

        FileSaveDialog.Filter = "Comma Delimited (*.csv)|*.csv|Tab Delimited (*.txt)|*.txt"
        FileSaveDialog.Title = "Save found location indeces as delimited file."
        FileSaveDialog.ShowDialog()
        filePath = FileSaveDialog.FileName

        If String.IsNullOrWhiteSpace(filePath) Then Exit Sub

        If FileSaveDialog.FilterIndex = 1 Then
            delim = ", "
        Else
            delim = (vbTab)
        End If

        Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(filePath, False)

        With Me.SearchItemsIndeces_DGView
            For Each r As DataGridViewRow In .Rows

                Dim selCells(.ColumnCount - 1) As DataGridViewCell

                r.Cells.CopyTo(selCells, 0)
                outputData.Add(Helper.CreateDelimitedStrFromCells(selCells, delim))
            Next
        End With

        For Each l As String In outputData
            outFile.WriteLine(l)
            Console.WriteLine(l)
        Next
        FileSaveDialog.Reset()
        outFile.Close()
    End Sub

    Private Sub FindAtLocations_But_Click(sender As System.Object, e As System.EventArgs) Handles FindAtLocations_But.Click
        Dim locations As IEnumerable = Helper.splitString(Me.FindAtLocations_TxtBox.Text)

        If Me.BytesGrid_DGView.RowCount < 1 Then Exit Sub
        Me.FilePath_TxtBoxBut.Text = ""
        Helper.HighlightGridByPos(locations, Me.BytesGrid_DGView)

        Me.GoToLocation_CBox.Items.Clear()

        For Each l As Object In locations
            Me.GoToLocation_CBox.Items.Add(l)
        Next
    End Sub

    Private Sub GoToLocation_CBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles GoToLocation_CBox.SelectedIndexChanged
        Dim location As Integer = Integer.Parse(CType(sender, ComboBox).SelectedItem.ToString)
        Dim cellLocation As Point = Helper.GetCellCoordinatesFromLinearLocation(location, Me.BytesGrid_DGView)

        Me.BytesGrid_DGView.CurrentCell = Me.BytesGrid_DGView.Rows(cellLocation.Y).Cells(cellLocation.X)
        Me.BytesGrid_DGView.FirstDisplayedCell = Me.BytesGrid_DGView.CurrentCell
    End Sub

    Private Sub CopySelectedAsCommaDel(ByVal sender As Object, ByVal e As EventArgs)

        Dim dgv As DataGridView = CType(CType(CType(sender, ToolStripMenuItem).GetCurrentParent, ContextMenuStrip).SourceControl, DataGridView)
        Dim selCells(dgv.SelectedCells.Count - 1) As DataGridViewCell

        dgv.SelectedCells.CopyTo(selCells, 0)

        My.Computer.Clipboard.SetText(Helper.CreateDelimitedStrFromCells(CType(selCells, Global.System.Collections.Generic.IEnumerable(Of Global.System.Windows.Forms.DataGridViewCell)), ", "), System.Windows.Forms.TextDataFormat.Text)
    End Sub

    Private Sub CopySelectedAsTabDel(ByVal sender As Object, ByVal e As EventArgs)
        Dim dgv As DataGridView = CType(CType(CType(sender, ToolStripMenuItem).GetCurrentParent, ContextMenuStrip).SourceControl, DataGridView)
        Dim selCells(dgv.SelectedCells.Count - 1) As DataGridViewCell

        dgv.SelectedCells.CopyTo(selCells, 0)

        My.Computer.Clipboard.SetText(Helper.CreateDelimitedStrFromCells(CType(selCells, Global.System.Collections.Generic.IEnumerable(Of Global.System.Windows.Forms.DataGridViewCell)), (vbTab & " ")), System.Windows.Forms.TextDataFormat.Text)
    End Sub

    Private Sub ReplaceValues_But_Click(sender As System.Object, e As System.EventArgs) Handles ReplaceValues_But.Click
        Dim locs As New List(Of Point)
        Dim bObject As ByteObject

        'Dim byteValAsInt As Integer = -1
        'Dim byteValAsStr = Me.ReplaceValues_TxtBox.Text
        'Dim byteVal As Byte

        ''If we are dealing with a hex val that we need to convert to byte
        'If Me.ReplaceResultsAsHex_RadBut.Checked Then
        '    Try
        '        byteValAsInt = Convert.ToInt32(byteValAsStr, 16)
        '    Catch ex As Exception
        '        MsgBox(byteValAsStr & " is not valid!", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "ERROR")
        '        byteValAsInt = -1
        '    End Try
        'Else
        '    'Or we are dealing with an int value we need to convert to byte
        '    If Not Integer.TryParse(byteValAsStr, byteValAsInt) Then byteValAsInt = -1
        'End If

        ''Lets make sure we have a good value to tuen into a byte, It must be greater than -1 and less than 255
        'If byteValAsInt < 0 Or byteValAsInt > 255 Then
        '    MsgBox(byteValAsInt & " is not valid!", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "ERROR")
        '    Exit Sub
        'Else
        '    'We have good value, convert to byte and continue with what we need to do

        '    byteVal = Convert.ToByte(byteValAsInt)
        'End If

        If Trim(Me.ReplaceValues_TxtBox.Text).Length < 1 Then Exit Sub
        If Me.SearchItemsIndeces_DGView.RowCount < 1 Then Exit Sub

        For Each r As DataGridViewRow In SearchItemsIndeces_DGView.Rows
            For Each c As DataGridViewCell In r.Cells
                If c.Value Is Nothing Then Continue For
                locs.Add(Helper.GetCellCoordinatesFromLinearLocation(Integer.Parse(c.Value.ToString), Me.BytesGrid_DGView))
            Next
        Next


        If Not Helper.CreateValidbyteObject(Me.ReplaceValues_TxtBox.Text, Me.ReplaceResultsAsHex_RadBut.Checked, bObject) Then
            MsgBox(Me.ReplaceValues_TxtBox.Text & " is not valid!", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "ERROR")
            Exit Sub
        End If

        'Helper.ReplaceItemsInGridByCords(byteVal, locs, Me.BytesGrid_DGView, Me.ReplaceResultsAsHex_RadBut.Checked)
        Helper.ReplaceItemsInGridByCords(bObject, locs, Me.BytesGrid_DGView)

        RemoveHandler Me.SearchItems_ListBox.SelectedIndexChanged, AddressOf SearchItems_ListBox_SelectedIndexChanged

        Me.SearchItemsIndeces_DGView.Rows.Clear()
        Me.SearchItemsIndeces_DGView.Columns.Clear()

        Me.SearchItems_ListBox.Items.RemoveAt(Me.SearchItems_ListBox.SelectedIndex)
        'Dim itemObj As KeyValpair(Of Integer, Object) = CType(Me.SearchItems_ListBox.Items(Me.SearchItems_ListBox.SelectedIndex), KeyValpair(Of Integer, Object))
        'itemObj.Key = integerMe.ReplaceValues_TxtBox.Text
        'Me.SearchItems_ListBox.Items(Me.SearchItems_ListBox.SelectedIndex) = .Key

        'Dim keyVal As Integer = If(Me.ReplaceResultsAsHex_RadBut.Checked, Integer.Parse(Hex(CType(Me.SearchItems_ListBox.Items(Me.SearchItems_ListBox.SelectedIndex), KeyValpair(Of Integer, Object)).Key)), CType(Me.SearchItems_ListBox.Items(Me.SearchItems_ListBox.SelectedIndex), KeyValpair(Of Integer, Object)).Key)

        'Me.Search_TxtBox.Text = Me.Search_TxtBox.Text.Replace(keyVal.ToString, Me.ReplaceValues_TxtBox.Text)
        'Me.SearchItems_ListBox.Items.Clear()


        'Me.Search_But_Click(Me.Search_But, System.EventArgs.Empty)

        AddHandler Me.SearchItems_ListBox.SelectedIndexChanged, AddressOf SearchItems_ListBox_SelectedIndexChanged
    End Sub

    Private Sub Form1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        'For Each path In files
        '    MsgBox(path)
        'Next
        Me.FilePath_TxtBoxBut.Text = files(0)
        Me.ShowByteData_But_Click(Me.GetByteData_But, EventArgs.Empty)
    End Sub

    Private Sub Form1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub SaveFile_But_Click(sender As System.Object, e As System.EventArgs) Handles SaveFile_TStripBut.Click
        Dim filePath As String

        FileSaveDialog.Filter = "Original File (*" & workingExtension & ")|*" & workingExtension & ""
        FileSaveDialog.Title = "Save found location indeces as delimited file."
        FileSaveDialog.ShowDialog()
        filePath = FileSaveDialog.FileName

        If filePath Is Nothing Then Exit Sub
        'If File.Exists(filePath) Then filePath = Path.GetDirectoryName(filePath) & Path.GetFileNameWithoutExtension(filePath) & "_" & Path.GetExtension(filePath)

        'filePath &= Me.workingExtension

        Dim outData As Byte() = Helper.GetDataFromGridAsBytes(Me.BytesGrid_DGView)
        Dim data(0) As Byte '= br.Write(CInt(numBytes))

        FileSaveDialog.Reset()

        'For Each b As Object In outData
        '    If b Is Nothing Then Continue For
        '    Array.Resize(data, data.Count + 1)
        '    data(data.Count - 1) = CType(b, Byte)
        'Next

        File.WriteAllBytes(filePath, outData)
    End Sub

    Private currentValue As ByteObject

    Private Sub BytesGrid_DGView_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles BytesGrid_DGView.CellBeginEdit
        currentValue = CType(CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value, ByteObject)
    End Sub

    Private Sub BytesGrid_DGView_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BytesGrid_DGView.CellEndEdit
        Dim gridFormat As ByteObjectToString = CType(WorkingFormat_CBox.SelectedItem, KeyValpair(Of String, ByteObjectToString)).Value
        Dim ishex As Boolean = (gridFormat = ByteObjectToString.Hex Or gridFormat = ByteObjectToString.HexLong)
        Dim newValue As ByteObject

        If CreateValidbyteObject(CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value.ToString, ishex, newValue) Then
            CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value = newValue
        Else
            CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value = currentValue
        End If
    End Sub

    Private Sub ChangeResultFormat_CBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles WorkingFormat_CBox.SelectedIndexChanged
        For Each r As DataGridViewRow In Me.BytesGrid_DGView.Rows
            For Each c As DataGridViewCell In r.Cells
                If c.Value Is Nothing Then Continue For
                CType(c.Value, ByteObject).ToStringFormat = CType(WorkingFormat_CBox.SelectedItem, KeyValpair(Of String, ByteObjectToString)).Value
                Me.BytesGrid_DGView.InvalidateCell(c)
            Next
        Next
        Me.BytesGrid_DGView.AutoResizeColumns()
    End Sub

    Private Sub SearchItemsIndeces_DGView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SearchItemsIndeces_DGView.CellDoubleClick
        Dim location As Integer = CInt(CType(sender, DataGridView).Item(e.ColumnIndex, e.RowIndex).Value)
        Dim cellLocation As Point = Helper.GetCellCoordinatesFromLinearLocation(location, Me.BytesGrid_DGView)

        Me.BytesGrid_DGView.CurrentCell = Me.BytesGrid_DGView.Rows(cellLocation.Y).Cells(cellLocation.X)
        Me.BytesGrid_DGView.FirstDisplayedCell = Me.BytesGrid_DGView.CurrentCell
    End Sub


End Class
