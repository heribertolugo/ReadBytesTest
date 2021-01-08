<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.GetByteData_But = New System.Windows.Forms.Button()
        Me.BytesGrid_DGView = New System.Windows.Forms.DataGridView()
        Me.Search_TxtBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ConsecutiveVal_ChkBox = New System.Windows.Forms.CheckBox()
        Me.AsInt_RadBut = New System.Windows.Forms.RadioButton()
        Me.AsHex_RadBut = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Search_But = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.WorkingFormat_CBox = New System.Windows.Forms.ComboBox()
        Me.GoToLocation_CBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FindAtLocations_TxtBox = New System.Windows.Forms.TextBox()
        Me.FindAtLocations_But = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ReplaceValues_But = New System.Windows.Forms.Button()
        Me.ReplaceResultsAsInteger_RadBut = New System.Windows.Forms.RadioButton()
        Me.ReplaceResultsAsHex_RadBut = New System.Windows.Forms.RadioButton()
        Me.ReplaceValues_TxtBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SaveLocations_But = New System.Windows.Forms.Button()
        Me.TotalCountFound_Lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SearchItemsIndeces_DGView = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchItems_ListBox = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewFile_TStripBut = New System.Windows.Forms.ToolStripButton()
        Me.OpenFile_TStripBut = New System.Windows.Forms.ToolStripButton()
        Me.SaveFile_TStripBut = New System.Windows.Forms.ToolStripButton()
        Me.PrintFile_TStripBut = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FilePath_TxtBoxBut = New ReadBytesTest.TextBoxWithButton()
        CType(Me.BytesGrid_DGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SearchItemsIndeces_DGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GetByteData_But
        '
        Me.GetByteData_But.Location = New System.Drawing.Point(346, 41)
        Me.GetByteData_But.Name = "GetByteData_But"
        Me.GetByteData_But.Size = New System.Drawing.Size(75, 23)
        Me.GetByteData_But.TabIndex = 2
        Me.GetByteData_But.Text = "Get Bytes"
        Me.GetByteData_But.UseVisualStyleBackColor = True
        '
        'BytesGrid_DGView
        '
        Me.BytesGrid_DGView.AllowUserToAddRows = False
        Me.BytesGrid_DGView.AllowUserToDeleteRows = False
        Me.BytesGrid_DGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BytesGrid_DGView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BytesGrid_DGView.Location = New System.Drawing.Point(0, 352)
        Me.BytesGrid_DGView.Name = "BytesGrid_DGView"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BytesGrid_DGView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.BytesGrid_DGView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.BytesGrid_DGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.BytesGrid_DGView.ShowCellErrors = False
        Me.BytesGrid_DGView.ShowEditingIcon = False
        Me.BytesGrid_DGView.ShowRowErrors = False
        Me.BytesGrid_DGView.Size = New System.Drawing.Size(767, 128)
        Me.BytesGrid_DGView.TabIndex = 3
        '
        'Search_TxtBox
        '
        Me.Search_TxtBox.Location = New System.Drawing.Point(0, 53)
        Me.Search_TxtBox.Name = "Search_TxtBox"
        Me.Search_TxtBox.Size = New System.Drawing.Size(200, 20)
        Me.Search_TxtBox.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ConsecutiveVal_ChkBox)
        Me.GroupBox1.Controls.Add(Me.AsInt_RadBut)
        Me.GroupBox1.Controls.Add(Me.AsHex_RadBut)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Search_But)
        Me.GroupBox1.Controls.Add(Me.Search_TxtBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 157)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'ConsecutiveVal_ChkBox
        '
        Me.ConsecutiveVal_ChkBox.AutoSize = True
        Me.ConsecutiveVal_ChkBox.Location = New System.Drawing.Point(7, 109)
        Me.ConsecutiveVal_ChkBox.Name = "ConsecutiveVal_ChkBox"
        Me.ConsecutiveVal_ChkBox.Size = New System.Drawing.Size(120, 17)
        Me.ConsecutiveVal_ChkBox.TabIndex = 10
        Me.ConsecutiveVal_ChkBox.Text = "Consecutive Values"
        Me.ConsecutiveVal_ChkBox.ThreeState = True
        Me.ConsecutiveVal_ChkBox.UseVisualStyleBackColor = True
        '
        'AsInt_RadBut
        '
        Me.AsInt_RadBut.AutoSize = True
        Me.AsInt_RadBut.Location = New System.Drawing.Point(130, 105)
        Me.AsInt_RadBut.Name = "AsInt_RadBut"
        Me.AsInt_RadBut.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AsInt_RadBut.Size = New System.Drawing.Size(58, 17)
        Me.AsInt_RadBut.TabIndex = 9
        Me.AsInt_RadBut.Text = "Integer"
        Me.AsInt_RadBut.UseVisualStyleBackColor = True
        '
        'AsHex_RadBut
        '
        Me.AsHex_RadBut.AutoSize = True
        Me.AsHex_RadBut.Checked = True
        Me.AsHex_RadBut.Location = New System.Drawing.Point(144, 82)
        Me.AsHex_RadBut.Name = "AsHex_RadBut"
        Me.AsHex_RadBut.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AsHex_RadBut.Size = New System.Drawing.Size(44, 17)
        Me.AsHex_RadBut.TabIndex = 8
        Me.AsHex_RadBut.TabStop = True
        Me.AsHex_RadBut.Text = "Hex"
        Me.AsHex_RadBut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 30)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Enter values to search. Sperate multiple values with a comma (No spaces)."
        '
        'Search_But
        '
        Me.Search_But.Location = New System.Drawing.Point(6, 79)
        Me.Search_But.Name = "Search_But"
        Me.Search_But.Size = New System.Drawing.Size(75, 23)
        Me.Search_But.TabIndex = 6
        Me.Search_But.Text = "Search"
        Me.Search_But.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.WorkingFormat_CBox)
        Me.Panel1.Controls.Add(Me.GoToLocation_CBox)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.FindAtLocations_TxtBox)
        Me.Panel1.Controls.Add(Me.FindAtLocations_But)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.FilePath_TxtBoxBut)
        Me.Panel1.Controls.Add(Me.GetByteData_But)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(767, 327)
        Me.Panel1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 270)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Format"
        '
        'WorkingFormat_CBox
        '
        Me.WorkingFormat_CBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WorkingFormat_CBox.FormattingEnabled = True
        Me.WorkingFormat_CBox.Location = New System.Drawing.Point(18, 286)
        Me.WorkingFormat_CBox.Name = "WorkingFormat_CBox"
        Me.WorkingFormat_CBox.Size = New System.Drawing.Size(121, 21)
        Me.WorkingFormat_CBox.TabIndex = 19
        '
        'GoToLocation_CBox
        '
        Me.GoToLocation_CBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GoToLocation_CBox.FormattingEnabled = True
        Me.GoToLocation_CBox.Location = New System.Drawing.Point(641, 305)
        Me.GoToLocation_CBox.Name = "GoToLocation_CBox"
        Me.GoToLocation_CBox.Size = New System.Drawing.Size(121, 21)
        Me.GoToLocation_CBox.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 310)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(269, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Find values by location (seperate locations with comma)"
        '
        'FindAtLocations_TxtBox
        '
        Me.FindAtLocations_TxtBox.Location = New System.Drawing.Point(278, 305)
        Me.FindAtLocations_TxtBox.Name = "FindAtLocations_TxtBox"
        Me.FindAtLocations_TxtBox.Size = New System.Drawing.Size(164, 20)
        Me.FindAtLocations_TxtBox.TabIndex = 14
        '
        'FindAtLocations_But
        '
        Me.FindAtLocations_But.Location = New System.Drawing.Point(448, 303)
        Me.FindAtLocations_But.Name = "FindAtLocations_But"
        Me.FindAtLocations_But.Size = New System.Drawing.Size(105, 23)
        Me.FindAtLocations_But.TabIndex = 13
        Me.FindAtLocations_But.Text = "Find at locations"
        Me.FindAtLocations_But.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ReplaceValues_But)
        Me.GroupBox2.Controls.Add(Me.ReplaceResultsAsInteger_RadBut)
        Me.GroupBox2.Controls.Add(Me.ReplaceResultsAsHex_RadBut)
        Me.GroupBox2.Controls.Add(Me.ReplaceValues_TxtBox)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.SaveLocations_But)
        Me.GroupBox2.Controls.Add(Me.TotalCountFound_Lbl)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.SearchItemsIndeces_DGView)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.SearchItems_ListBox)
        Me.GroupBox2.Location = New System.Drawing.Point(219, 87)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(536, 186)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Locations in File"
        '
        'ReplaceValues_But
        '
        Me.ReplaceValues_But.Location = New System.Drawing.Point(400, 160)
        Me.ReplaceValues_But.Name = "ReplaceValues_But"
        Me.ReplaceValues_But.Size = New System.Drawing.Size(75, 23)
        Me.ReplaceValues_But.TabIndex = 18
        Me.ReplaceValues_But.Text = "Replace"
        Me.ReplaceValues_But.UseVisualStyleBackColor = True
        '
        'ReplaceResultsAsInteger_RadBut
        '
        Me.ReplaceResultsAsInteger_RadBut.AutoSize = True
        Me.ReplaceResultsAsInteger_RadBut.Location = New System.Drawing.Point(336, 163)
        Me.ReplaceResultsAsInteger_RadBut.Name = "ReplaceResultsAsInteger_RadBut"
        Me.ReplaceResultsAsInteger_RadBut.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ReplaceResultsAsInteger_RadBut.Size = New System.Drawing.Size(58, 17)
        Me.ReplaceResultsAsInteger_RadBut.TabIndex = 17
        Me.ReplaceResultsAsInteger_RadBut.Text = "Integer"
        Me.ReplaceResultsAsInteger_RadBut.UseVisualStyleBackColor = True
        '
        'ReplaceResultsAsHex_RadBut
        '
        Me.ReplaceResultsAsHex_RadBut.AutoSize = True
        Me.ReplaceResultsAsHex_RadBut.Checked = True
        Me.ReplaceResultsAsHex_RadBut.Location = New System.Drawing.Point(286, 163)
        Me.ReplaceResultsAsHex_RadBut.Name = "ReplaceResultsAsHex_RadBut"
        Me.ReplaceResultsAsHex_RadBut.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ReplaceResultsAsHex_RadBut.Size = New System.Drawing.Size(44, 17)
        Me.ReplaceResultsAsHex_RadBut.TabIndex = 16
        Me.ReplaceResultsAsHex_RadBut.TabStop = True
        Me.ReplaceResultsAsHex_RadBut.Text = "Hex"
        Me.ReplaceResultsAsHex_RadBut.UseVisualStyleBackColor = True
        '
        'ReplaceValues_TxtBox
        '
        Me.ReplaceValues_TxtBox.Location = New System.Drawing.Point(111, 163)
        Me.ReplaceValues_TxtBox.Name = "ReplaceValues_TxtBox"
        Me.ReplaceValues_TxtBox.Size = New System.Drawing.Size(169, 20)
        Me.ReplaceValues_TxtBox.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Replace values with:"
        '
        'SaveLocations_But
        '
        Me.SaveLocations_But.Location = New System.Drawing.Point(426, 20)
        Me.SaveLocations_But.Name = "SaveLocations_But"
        Me.SaveLocations_But.Size = New System.Drawing.Size(104, 23)
        Me.SaveLocations_But.TabIndex = 14
        Me.SaveLocations_But.Text = "Save Locations"
        Me.SaveLocations_But.UseVisualStyleBackColor = True
        '
        'TotalCountFound_Lbl
        '
        Me.TotalCountFound_Lbl.AutoSize = True
        Me.TotalCountFound_Lbl.Location = New System.Drawing.Point(338, 28)
        Me.TotalCountFound_Lbl.Name = "TotalCountFound_Lbl"
        Me.TotalCountFound_Lbl.Size = New System.Drawing.Size(13, 13)
        Me.TotalCountFound_Lbl.TabIndex = 12
        Me.TotalCountFound_Lbl.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Total of:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Found at Locations (Indeces):"
        '
        'SearchItemsIndeces_DGView
        '
        Me.SearchItemsIndeces_DGView.AllowUserToAddRows = False
        Me.SearchItemsIndeces_DGView.AllowUserToDeleteRows = False
        Me.SearchItemsIndeces_DGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SearchItemsIndeces_DGView.Location = New System.Drawing.Point(135, 44)
        Me.SearchItemsIndeces_DGView.Name = "SearchItemsIndeces_DGView"
        Me.SearchItemsIndeces_DGView.ReadOnly = True
        Me.SearchItemsIndeces_DGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.SearchItemsIndeces_DGView.ShowCellErrors = False
        Me.SearchItemsIndeces_DGView.ShowEditingIcon = False
        Me.SearchItemsIndeces_DGView.ShowRowErrors = False
        Me.SearchItemsIndeces_DGView.Size = New System.Drawing.Size(395, 107)
        Me.SearchItemsIndeces_DGView.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Search Items:"
        '
        'SearchItems_ListBox
        '
        Me.SearchItems_ListBox.FormattingEnabled = True
        Me.SearchItems_ListBox.Location = New System.Drawing.Point(9, 44)
        Me.SearchItems_ListBox.Name = "SearchItems_ListBox"
        Me.SearchItems_ListBox.Size = New System.Drawing.Size(120, 108)
        Me.SearchItems_ListBox.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(558, 303)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(206, 23)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Go To Location"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 480)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(767, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFile_TStripBut, Me.OpenFile_TStripBut, Me.SaveFile_TStripBut, Me.PrintFile_TStripBut, Me.toolStripSeparator, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.toolStripSeparator1, Me.HelpToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(767, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewFile_TStripBut
        '
        Me.NewFile_TStripBut.Image = CType(resources.GetObject("NewFile_TStripBut.Image"), System.Drawing.Image)
        Me.NewFile_TStripBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewFile_TStripBut.Name = "NewFile_TStripBut"
        Me.NewFile_TStripBut.Size = New System.Drawing.Size(51, 22)
        Me.NewFile_TStripBut.Text = "&New"
        '
        'OpenFile_TStripBut
        '
        Me.OpenFile_TStripBut.Image = CType(resources.GetObject("OpenFile_TStripBut.Image"), System.Drawing.Image)
        Me.OpenFile_TStripBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenFile_TStripBut.Name = "OpenFile_TStripBut"
        Me.OpenFile_TStripBut.Size = New System.Drawing.Size(56, 22)
        Me.OpenFile_TStripBut.Text = "&Open"
        '
        'SaveFile_TStripBut
        '
        Me.SaveFile_TStripBut.Image = CType(resources.GetObject("SaveFile_TStripBut.Image"), System.Drawing.Image)
        Me.SaveFile_TStripBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveFile_TStripBut.Name = "SaveFile_TStripBut"
        Me.SaveFile_TStripBut.Size = New System.Drawing.Size(51, 22)
        Me.SaveFile_TStripBut.Text = "&Save"
        '
        'PrintFile_TStripBut
        '
        Me.PrintFile_TStripBut.Image = CType(resources.GetObject("PrintFile_TStripBut.Image"), System.Drawing.Image)
        Me.PrintFile_TStripBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintFile_TStripBut.Name = "PrintFile_TStripBut"
        Me.PrintFile_TStripBut.Size = New System.Drawing.Size(52, 22)
        Me.PrintFile_TStripBut.Text = "&Print"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(46, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(52, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        '
        'FilePath_TxtBoxBut
        '
        Me.FilePath_TxtBoxBut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilePath_TxtBoxBut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FilePath_TxtBoxBut.Checked = True
        Me.FilePath_TxtBoxBut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FilePath_TxtBoxBut.Image = Nothing
        Me.FilePath_TxtBoxBut.ImageCursor = System.Windows.Forms.Cursors.Hand
        Me.FilePath_TxtBoxBut.ImageOnChecked = Global.ReadBytesTest.My.Resources.Resources.arrow_right
        Me.FilePath_TxtBoxBut.ImageOnIndeterminate = Nothing
        Me.FilePath_TxtBoxBut.ImageOnText = Nothing
        Me.FilePath_TxtBoxBut.ImageOnTextEmpty = Nothing
        Me.FilePath_TxtBoxBut.ImageOnUnchecked = Nothing
        Me.FilePath_TxtBoxBut.Location = New System.Drawing.Point(6, 13)
        Me.FilePath_TxtBoxBut.Name = "FilePath_TxtBoxBut"
        Me.FilePath_TxtBoxBut.Size = New System.Drawing.Size(755, 22)
        Me.FilePath_TxtBoxBut.TabIndex = 1
        Me.FilePath_TxtBoxBut.UseCheckedState = True
        Me.FilePath_TxtBoxBut.UseThreeState = True
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 502)
        Me.Controls.Add(Me.BytesGrid_DGView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(783, 541)
        Me.MinimumSize = New System.Drawing.Size(783, 541)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Read and Edit File Bytes"
        CType(Me.BytesGrid_DGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.SearchItemsIndeces_DGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FilePath_TxtBoxBut As TextBoxWithButton
    Friend WithEvents GetByteData_But As System.Windows.Forms.Button
    Friend WithEvents BytesGrid_DGView As System.Windows.Forms.DataGridView
    Friend WithEvents Search_TxtBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ConsecutiveVal_ChkBox As System.Windows.Forms.CheckBox
    Friend WithEvents AsInt_RadBut As System.Windows.Forms.RadioButton
    Friend WithEvents AsHex_RadBut As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Search_But As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SearchItemsIndeces_DGView As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SearchItems_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents TotalCountFound_Lbl As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SaveLocations_But As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FindAtLocations_TxtBox As System.Windows.Forms.TextBox
    Friend WithEvents FindAtLocations_But As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GoToLocation_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents ReplaceValues_But As System.Windows.Forms.Button
    Friend WithEvents ReplaceResultsAsInteger_RadBut As System.Windows.Forms.RadioButton
    Friend WithEvents ReplaceResultsAsHex_RadBut As System.Windows.Forms.RadioButton
    Friend WithEvents ReplaceValues_TxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents WorkingFormat_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewFile_TStripBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFile_TStripBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFile_TStripBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintFile_TStripBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
