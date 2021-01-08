Imports System.ComponentModel

Partial Class TextBoxWithButton

    Public Event ImageClicked(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ImageMouseOver(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ImageMouseOut(ByVal sender As Object, ByVal e As EventArgs)
    Public Shadows Event TextChanged(ByVal sender As Object, ByVal e As EventArgs)


    Private textBoxSize As Size = New Size(0, 0)
    Private imageSize As Size = New Size(0, 0)
    Private _image As Image = Nothing
    Private _imageOnTextEmpty As Image = Nothing
    Private _imageOnText As Image = Nothing
    Private _imageOnCheck As Image = Nothing
    Private _imageOnIndeterminate As Image = Nothing
    Private _imageOnUnCheck As Image = Nothing
    Private _checkedState As CheckState = Windows.Forms.CheckState.Unchecked
    Private _checked As Boolean = False
    Private _useThreeState As Boolean = False
    Private _useCheckedState As Boolean = False
    Private sizeChangedbyMe As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        textBoxSize = Me.TextBox_Control.Size
        imageSize = Me.Image_Control.Size

        sizeChangedbyMe = False
    End Sub

    Public ReadOnly Property TextBox As TextBox
        Get
            Return Me.TextBox_Control
        End Get
    End Property

    Public Property Image As Image
        Get
            Return _image
        End Get
        Set(value As Image)
            'If value Is Nothing Then Exit Property
            '_image = New Bitmap(value)
            'SetImage(Nothing, EventArgs.Empty)

            _image = value

            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property ImageOnTextEmpty As Image
        Get
            Return _imageOnTextEmpty
        End Get
        Set(value As Image)
            'If value Is Nothing Then Exit Property
            '_imageOnTextEmpty = New Bitmap(value)
            'SetImage(Nothing, EventArgs.Empty)

            _imageOnTextEmpty = value

            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property ImageOnText As Image
        Get
            Return _imageOnText
        End Get
        Set(value As Image)
            'If value Is Nothing Then Exit Property
            '_imageOnText = New Bitmap(value)
            'SetImage(Nothing, EventArgs.Empty)

            _imageOnText = value

            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property ImageOnChecked As Image
        Get
            Return _imageOnCheck
        End Get
        Set(value As Image)
            'If value Is Nothing Then Exit Property
            '_imageOnCheck = New Bitmap(value)
            'SetImage(Nothing, EventArgs.Empty)

            _imageOnCheck = value

            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property ImageOnIndeterminate As Image
        Get
            Return _imageOnIndeterminate
        End Get
        Set(value As Image)
            'If value Is Nothing Then Exit Property
            '_imageOnIndeterminate = New Bitmap(value)
            'SetImage(Nothing, EventArgs.Empty)

            _imageOnIndeterminate = value

            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property ImageOnUnchecked As Image
        Get
            Return _imageOnUnCheck
        End Get
        Set(value As Image)
            'If value Is Nothing Then
            '    _imageOnUnCheck = value
            '    Exit Property
            'Else
            '    _imageOnUnCheck = New Bitmap(value)
            'End If
            _imageOnUnCheck = value

            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property CheckState As CheckState
        Get
            Return _checkedState
        End Get
        Set(value As CheckState)
            _checkedState = value

            If value = Windows.Forms.CheckState.Unchecked Then
                _checked = False
            Else
                _checked = True
            End If
            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return _checked
        End Get
        Set(value As Boolean)
            _checked = value

            If _checked And _useThreeState Then _checkedState = Windows.Forms.CheckState.Checked
            If Not _checked And _useThreeState Then _checkedState = Windows.Forms.CheckState.Unchecked

            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    '<Browsable(True), _
    'EditorBrowsable(EditorBrowsableState.Always), _
    '    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    '<EditorAttribute(GetType(System.Drawing.Design.ImageEditor), GetType(System.Drawing.Design.UITypeEditor))> _

    Public Property ImageCursor As Cursor
        Get
            Return Me.Image_Control.Cursor
        End Get
        Set(value As Cursor)
            If value Is Nothing Then Exit Property
            Me.Image_Control.Cursor = value
        End Set
    End Property

    Public Shadows Property Text As String
        Get
            Return Me.TextBox_Control.Text
        End Get
        Set(value As String)
            Me.TextBox_Control.Text = value
            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property UseThreeState As Boolean
        Get
            Return _useThreeState
        End Get
        Set(value As Boolean)
            _useThreeState = value
            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Public Property UseCheckedState As Boolean
        Get
            Return _useCheckedState
        End Get
        Set(value As Boolean)
            _useCheckedState = value
            SetImage(Nothing, EventArgs.Empty)
        End Set
    End Property

    Private Sub KillTextBoxSizeChange(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox_Control.SizeChanged
        If Not sizeChangedbyMe Then
            Me.TextBox_Control.Size = textBoxSize
        End If
    End Sub

    Private Sub KillImageSizeChange(ByVal sender As Object, ByVal e As EventArgs) Handles Image_Control.SizeChanged
        If Not sizeChangedbyMe Then
            Me.Image_Control.Size = imageSize
        End If
    End Sub

    Private Sub ChangeChildrensSizes(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        sizeChangedbyMe = True
        Me.Image_Control.Size = New Size(Me.Height, Me.Height)
        Me.TextBox_Control.Size = New Size(Me.Width - Me.Height, Me.Height)

        textBoxSize = Me.TextBox_Control.Size
        imageSize = Me.Image_Control.Size
        sizeChangedbyMe = False
    End Sub

    Private Sub OnImageMouseOver(ByVal sender As Object, ByVal e As EventArgs) Handles Image_Control.MouseHover
        RaiseEvent ImageMouseOver(sender, e)
    End Sub

    Private Sub OnImageMouseOut(ByVal sender As Object, ByVal e As EventArgs) Handles Image_Control.MouseLeave
        RaiseEvent ImageMouseOut(sender, e)
    End Sub

    Private Sub OnImageClicked(ByVal sender As Object, ByVal e As EventArgs) Handles Image_Control.Click
        If _useThreeState Then
            Dim curState As Integer = CInt(_checkedState)

            curState += 1

            If curState > 2 Then
                curState = 0
            End If

            Me.CheckState = CType(curState, CheckState)

        ElseIf _useCheckedState And Not _useThreeState Then
            Me.Checked = Not _checked
        Else
            SetImage(sender, e)
        End If

        RaiseEvent ImageClicked(sender, e)
    End Sub

    Private Sub SetImage(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load, TextBox_Control.TextChanged

        If _useCheckedState And _useThreeState And _checkedState = Windows.Forms.CheckState.Indeterminate Then ' And Not _imageOnIndeterminate Is Nothing
            Me.Image_Control.Image = _imageOnIndeterminate
            Exit Sub
        ElseIf _useCheckedState And _checked Then ' And Not _imageOnCheck Is Nothing
            Me.Image_Control.Image = _imageOnCheck
            Exit Sub
        ElseIf _useCheckedState And Not _checked Then ' And Not _imageOnUnCheck Is Nothing
            Me.Image_Control.Image = _imageOnUnCheck
            Exit Sub
        ElseIf Trim(Me.TextBox_Control.Text).Count > 0 Then ' Not _imageOnTextEmpty Is Nothing And
            Me.Image_Control.Image = _imageOnTextEmpty
            Exit Sub
        ElseIf Trim(Me.TextBox_Control.Text).Count = 0 Then ' Not _imageOnText Is Nothing And
            Me.Image_Control.Image = _imageOnText
            Exit Sub
        Else 'If Not _image Is Nothing Then
            Me.Image_Control.Image = _image
            Exit Sub
        End If
    End Sub

    Private Shadows Sub OnTextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox_Control.TextChanged
        RaiseEvent TextChanged(sender, e)
    End Sub

    Public Overrides Function ToString() As String
        Return Me.TextBox_Control.Text
    End Function

End Class
