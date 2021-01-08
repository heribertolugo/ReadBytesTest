Public Class ByteObject
    Private _byteVal As Byte
    Private _hexValLong As String
    Private _hexVal As String
    Private _intVal As Integer
    Private _strVal As String
    Private _binVal As String
    Private _asciiVal As Char
    Private _toStringFormat As ByteObjectToString

    Public Sub New()
        Me.ByteVal = Convert.ToByte(0)
        _toStringFormat = ByteObjectToString.Int
    End Sub

    Public Sub New(ByVal byteValue As Byte)
        Me.ByteVal = byteValue

        _toStringFormat = ByteObjectToString.Int
    End Sub

    'Public Sub New(ByVal hexValue As String)
    '    'Me.ByteVal = byteValue

    '    _toStringFormat = ByteObjectToString.Int
    'End Sub


    Public Property ByteVal As Byte
        Get
            Return _byteVal
        End Get
        Set(value As Byte)
            Dim bytes(0) As Byte
            bytes(0) = value

            _byteVal = value
            _hexValLong = value.ToString("X8")
            _hexVal = value.ToString("X")
            '_hexVal = Convert.ToString(value, 16)
            '_hexVal = Conversion.Hex(value)
            _intVal = CInt(value)
            _strVal = value.ToString
            _binVal = Convert.ToString(value, 2).PadLeft(8, "0"c)
            _asciiVal = System.Convert.ToChar(value) 'System.Text.Encoding.Default.GetChars(bytes)(0)
        End Set
    End Property

    Public ReadOnly Property HexValLong As String
        Get
            Return _hexValLong
        End Get
    End Property

    Public ReadOnly Property HexVal As String
        Get
            Return _hexVal
        End Get
    End Property

    Public ReadOnly Property IntVal As Integer
        Get
            Return _intVal
        End Get
    End Property

    Public ReadOnly Property StrVal As String
        Get
            Return _strVal
        End Get
    End Property

    Public ReadOnly Property BinaryVal As String
        Get
            Return _binVal
        End Get
    End Property

    Public ReadOnly Property AsciiVal As Char
        Get
            Return _asciiVal
        End Get
    End Property

    Public Property ToStringFormat As ByteObjectToString
        Get
            Return _toStringFormat
        End Get
        Set(value As ByteObjectToString)
            _toStringFormat = value
        End Set
    End Property

    Public Function SetFromHex(ByVal hexvalue As String) As Boolean
        Try
            Me.ByteVal = Convert.ToByte(hexvalue, 16)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function setFromHexLong(ByVal hexValue As String) As Boolean
        Return SetFromHex(HexVal)
    End Function

    Public Function SetFromInteger(ByVal intValue As Integer) As Boolean
        Try
            Me.ByteVal = Convert.ToByte(IntVal)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SetFromBinaryValue( ByVal binaryValue As String) As Boolean
        Try
            Me.ByteVal = Convert.ToByte(BinaryVal, 2)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SetFromBinaryValue(ByVal binaryValue As Integer) As Boolean
        Return SetFromBinaryValue(BinaryVal.ToString)
    End Function

    Public Function SetFromBitArray(ByVal bitArray() As Object) As Boolean
        Dim bit As Integer = -1
        Dim byteString As String = ""

        While bit < bitArray.Length Or bit <= 8
            bit += 1
            If Not bitArray(bit).ToString() = "0" Or Not bitArray(bit).ToString() = "1" Then Return False

            byteString &= bitArray(bit).ToString()
        End While

        Return SetFromBinaryValue(byteString.PadLeft(8, "0"c))
    End Function

    Public Function SetFromAscii(ByVal ascii As String) As Boolean
        Return SetFromAscii(ascii(0))
    End Function

    Public Function SetFromAscii(ByVal ascii As Char) As Boolean
        Try
            Convert.ToByte(ascii)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    Public Function SetFromCurrent(ByVal obj As Object) As Boolean
        Try
            Select Case _toStringFormat
                Case ByteObjectToString.Hex
                    Return SetFromHex(obj.ToString)
                Case ByteObjectToString.HexLong
                    Return setFromHexLong(obj.ToString)
                Case ByteObjectToString.Int
                    Return SetFromInteger(CInt(obj))
                Case ByteObjectToString.Binary
                    Return SetFromBinaryValue(obj.ToString)
                Case ByteObjectToString.Ascii
                    Return SetFromAscii(obj.ToString)
                Case Else
                    Return False
            End Select
        Catch e As Exception
            Return False
        End Try
    End Function


    Public Overrides Function ToString() As String

        Select Case _toStringFormat
            Case ByteObjectToString.Hex
                Return _hexVal
            Case ByteObjectToString.HexLong
                Return _hexValLong
            Case ByteObjectToString.Int
                Return _intVal.ToString
            Case ByteObjectToString.Binary
                Return _binVal
            Case ByteObjectToString.Ascii
                Return _asciiVal
            Case Else
                Return _byteVal.ToString
        End Select

    End Function
End Class


Public Enum ByteObjectToString
    Hex
    HexLong
    Int
    Binary
    Ascii
End Enum

