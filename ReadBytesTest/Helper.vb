Imports System.IO
Imports System.Globalization

Module Helper

    Friend Function GetByteData(ByVal filePath As String) As Byte()
        Dim fInfo As New FileInfo(filePath)
        Dim numBytes As Long = fInfo.Length
        Dim data As Byte() = Nothing

        Using fStream As New FileStream(filePath, FileMode.Open, FileAccess.Read)

            Using br As New BinaryReader(fStream)
                data = br.ReadBytes(CInt(numBytes))

            End Using
        End Using


        Return Data
    End Function

    Friend Sub ShowDataToGrid(ByVal data As ICollection, ByRef DataGrid As DataGridView, Optional ByRef backgroundworker As System.ComponentModel.BackgroundWorker = Nothing) 'Optional ByRef progressMax As Integer = 0, Optional ByRef progressVal As Integer = 0, Optional ByRef progressText As String = "")
        Dim dimension As Integer = CInt(Math.Ceiling(Math.Sqrt(data.Count)))
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim index As Integer = 0
        Dim progressVal As Integer = index
        Dim cellFont As Font = If(DataGrid.DefaultCellStyle.Font Is Nothing, DataGrid.RowsDefaultCellStyle.Font, DataGrid.DefaultCellStyle.Font)

        If Not backgroundworker Is Nothing Then backgroundworker.RunWorkerAsync()
        'Threading.Thread.Sleep(1000)
        DataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        'DataGrid.Visible = False
        For Each b As Object In data
            If col = dimension Then
                If Not backgroundworker Is Nothing Then
                    progressVal += 1
                    backgroundworker.ReportProgress((progressVal), "Creating Row...")
                End If


                col = 0
                row += 1
                DataGrid.Rows.Add()
                Dim newRowCount As Integer = (DataGrid.ColumnCount * row)
                DataGrid.Rows(DataGrid.Rows.Count - 1).HeaderCell.Value = newRowCount.ToString
            End If
            If row = 0 Then
                If Not backgroundworker Is Nothing Then
                    progressVal += 1
                    backgroundworker.ReportProgress(progressVal, "Creating Column...")
                End If

                DataGrid.Columns.Add(col.ToString, col.ToString)
            End If

            If DataGrid.RowCount = 0 Then
                If Not backgroundworker Is Nothing Then
                    progressVal += 1
                    backgroundworker.ReportProgress(progressVal, "Creating Row...")
                End If

                DataGrid.Rows.Add()
                Dim newRowCount As Integer = (index + (DataGrid.ColumnCount * row)) + row
                DataGrid.Rows(DataGrid.Rows.Count - 1).HeaderCell.Value = newRowCount.ToString
            End If

            If Not backgroundworker Is Nothing Then
                progressVal += 1
                backgroundworker.ReportProgress(progressVal, ("Creating Value... " & b.ToString))
            End If

            DataGrid.Item(col, row).Value = b
            DataGrid.Columns(col).FillWeight = 2
            col += 1
            index += 1

            'If Not backgroundworker Is Nothing Then backgroundworker.ReportProgress(index, ("Finished Value... " & o.ToString))
        Next

        If Not backgroundworker Is Nothing Then
            progressVal += 1
            backgroundworker.ReportProgress(progressVal, "Resizing Grid...")
        End If

        DataGrid.AutoResizeColumns()
        DataGrid.AutoResizeRows()
        'DataGrid.Visible = True

        If Not backgroundworker Is Nothing Then
            progressVal += 1
            backgroundworker.ReportProgress(progressVal, "Done...")
        End If
    End Sub


    Function splitString(ByVal str As String, Optional ByVal delimeter As Char = CChar(",")) As IEnumerable
        Dim splitStr As New List(Of String)
        Dim tmpStr As String = str
        Dim delIndex As Integer = 0

        While delIndex > -1
            Dim strFound As String

            delIndex = tmpStr.IndexOf(delimeter)

            strFound = If(delIndex > -1, tmpStr.Substring(0, delIndex), tmpStr)
            tmpStr = If(delIndex > -1, tmpStr.Remove(0, delIndex + 1), tmpStr)

            splitStr.Add(strFound)
        End While

        Return splitStr.AsEnumerable
    End Function


    Friend Sub HighlightGridByPos(ByVal linearPosList As IEnumerable, ByRef DataGrid As DataGridView)


        DataGrid.SelectAll()
        For Each dr As DataGridViewRow In DataGrid.Rows
            For Each dc As DataGridViewCell In dr.Cells
                dc.Style.BackColor = dr.DefaultCellStyle.BackColor
            Next
        Next

        For Each index As Integer In linearPosList
            Dim cellPosition As Point = GetCellCoordinatesFromLinearLocation(index, DataGrid)

            If cellPosition.X > DataGrid.ColumnCount Then Continue For
            If cellPosition.Y > DataGrid.RowCount Then Continue For

            DataGrid.Item(cellPosition.X, cellPosition.Y).Style.BackColor = Color.Yellow
        Next

        DataGrid.ClearSelection()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="searchItems"></param>
    ''' <param name="DataGrid"></param>
    ''' <param name="isHex"></param>
    ''' <param name="onlyConsecutive"></param>
    ''' <returns></returns>
    ''' <remarks>Will return a Dictionary(of integer, </remarks>
    Friend Function GetItemsLocation(ByVal searchItems As IEnumerable, ByRef DataGrid As DataGridView, ByVal isHex As Boolean, Optional ByVal onlyConsecutive As Boolean = False) As Dictionary(Of Integer, Byte)
        Dim itemsLoc As New Dictionary(Of Integer, Byte)

        Dim pos As Integer = -1


        For Each r As DataGridViewRow In DataGrid.Rows
            For Each c As DataGridViewColumn In DataGrid.Columns
                Dim cellVal As ByteObject = CType(r.Cells(c.Name).Value, ByteObject)

                If cellVal Is Nothing Then Continue For
                For Each srchItem As Object In searchItems
                    Dim itemStr As String = srchItem.ToString
                    Dim intVal As Integer
                    If Not If(isHex, Integer.TryParse(itemStr, Globalization.NumberStyles.AllowHexSpecifier, CultureInfo.CurrentCulture, intVal), Integer.TryParse(itemStr, intVal)) Then Continue For
                    'If intVal = CInt(cellVal) Then
                    If intVal = cellVal.IntVal Then
                        pos = (DataGrid.ColumnCount * r.Index) + c.Index

                        'itemsLoc.Add(pos, cellVal)
                        itemsLoc.Add(pos, cellVal.ByteVal)

                    End If
                Next
            Next
        Next

        If onlyConsecutive Then
            Dim tempDict As New Dictionary(Of Integer, Byte)

            For i As Integer = 0 To (itemsLoc.Count - 1) Step 1
                If (i + 1) = itemsLoc.Count Then Exit For
                If itemsLoc.ElementAt(i).Value = itemsLoc.ElementAt(i + 1).Value Then
                    If CInt(itemsLoc.ElementAt(i).Key) = (CInt(itemsLoc.ElementAt(i + 1).Key) - 1) Then
                        If Not tempDict.Keys.Contains(itemsLoc.ElementAt(i).Key) Then tempDict.Add(itemsLoc.ElementAt(i).Key, itemsLoc.ElementAt(i).Value)
                        If Not tempDict.Keys.Contains(itemsLoc.ElementAt(i + 1).Key) Then tempDict.Add(itemsLoc.ElementAt(i + 1).Key, itemsLoc.ElementAt(i + 1).Value)
                    End If
                End If
            Next

            itemsLoc = tempDict
        End If

        Return itemsLoc
    End Function


    Friend Function GetDataFromGrid(ByVal DatGrid As DataGridView) As List(Of Object)
        Dim bytes As New List(Of Object)

        For Each r As DataGridViewRow In DatGrid.Rows
            For Each c As DataGridViewColumn In DatGrid.Columns
                If r.Cells(c.Name).Value Is Nothing Then Continue For
                bytes.Add(r.Cells(c.Name).Value)
            Next
        Next

        Return bytes
    End Function

    Friend Function GetDataFromGridAsBytes(ByVal DatGrid As DataGridView) As Byte()
        Dim bytes(-1) As Byte

        For Each r As DataGridViewRow In DatGrid.Rows
            For Each c As DataGridViewColumn In DatGrid.Columns
                If r.Cells(c.Name).Value Is Nothing Then Continue For
                Array.Resize(bytes, bytes.Count + 1)
                bytes(bytes.Count - 1) = CType(r.Cells(c.Name).Value, ByteObject).ByteVal
                'bytes.Add(r.Cells(c.Name).Value)
            Next
        Next

        Return bytes
    End Function

    Friend Function GetCellCoordinatesFromLinearLocation(ByVal linearLoc As Integer, ByVal dataGrid As DataGridView) As Point
        'Dim location As Integer = linearLoc
        Dim row As Integer = CInt(linearLoc \ dataGrid.ColumnCount)
        Dim col As Integer = (linearLoc - (dataGrid.ColumnCount * row))

        Return New Point(col, row)
    End Function



    Friend Function CreateDelimitedStrFromCells(ByVal valList As IEnumerable(Of DataGridViewCell), Optional ByVal delimiter As String = ", ") As String
        Dim delStr As String = ""
        Dim sortedCells As New List(Of DataGridViewCell)
        Dim sortedCellData As New List(Of String)

        For Each c As DataGridViewCell In valList
            sortedCells.Add(c)
        Next

        Dim query As IOrderedEnumerable(Of DataGridViewCell) = From c In sortedCells
                                                               Select c
                                                               Order By c.RowIndex, c.ColumnIndex

        sortedCells = query.ToList

        For Each c In sortedCells
            If c.Value Is Nothing Then Continue For
            sortedCellData.Add(c.Value.ToString)
        Next

        delStr = String.Join(delimiter, sortedCellData)


        Return delStr
    End Function



    Friend Sub ReplaceItemsInGridByCords(ByVal newVal As ByteObject, ByVal cords As IEnumerable(Of Point), ByRef dataGrid As DataGridView)
        For Each c As Point In cords
            'Dim newValInt As Integer
            'Dim b As Boolean = If(isHex, Integer.TryParse(newVal.ToString, Globalization.NumberStyles.AllowHexSpecifier, Globalization.CultureInfo.CurrentCulture, newValInt), Integer.TryParse(newVal.ToString, newValInt))
            'dataGrid.Item(c.X, c.Y).Value = newValInt
            dataGrid.Item(c.X, c.Y).Value = newVal 'New KeyValpair(Of String, Byte)(newValInt.ToString, CByte(newValInt))
        Next
    End Sub

    Function CreateValidbyteObject(ByVal newvalue As String, Optional ByVal fromHex As Boolean = False, Optional ByRef byteObject As ByteObject = Nothing) As Boolean
        Dim byteValAsInt As Integer = -1
        Dim byteValAsStr = newvalue
        Dim byteVal As Byte

        'If we are dealing with a hex val that we need to convert to byte
        If fromHex Then
            Try
                byteValAsInt = Convert.ToInt32(byteValAsStr, 16)
            Catch ex As Exception
                Return False 'MsgBox(byteValAsStr & " is not valid!", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "ERROR")
                byteValAsInt = -1
            End Try
        Else
            'Or we are dealing with an int value we need to convert to byte
            If Not Integer.TryParse(byteValAsStr, byteValAsInt) Then byteValAsInt = -1
        End If

        'Lets make sure we have a good value to turn into a byte, It must be greater than -1 and less than 255
        If byteValAsInt < 0 Or byteValAsInt > 255 Then
            Return False 'MsgBox(byteValAsInt & " is not valid!", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, MsgBoxStyle), "ERROR")
        Else
            'We have good value, convert to byte and continue with what we need to do
            byteVal = Convert.ToByte(byteValAsInt)
        End If

        byteObject = New ByteObject(byteVal)
        Return True
    End Function

End Module

Public Structure KeyValpair(Of K, V)
    Private _key As K
    Private _value As V

    Public Sub New(ByVal TKey As K, ByVal TValue As V)
        _key = TKey
        _value = TValue
    End Sub

    Public ReadOnly Property Key As K
        Get
            Return _key
        End Get
        'Set(value As K)
        '    _key = value
        'End Set
    End Property

    Public ReadOnly Property Value As V
        Get
            Return _value
        End Get
        'Set(value As V)
        '    _value = value
        'End Set
    End Property

    Public Overrides Function ToString() As String
        Return _key.ToString
    End Function
End Structure
