Imports System.Threading

Public NotInheritable Class ProgressWin

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub ProgressWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).


        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Delegate Sub setProgMax(ByVal value As Integer)
    Private Delegate Sub setProgVal(ByVal value As Integer)
    Private Delegate Sub setProgText(ByVal value As String)

    'Private Delegate Sub writeItem(ByVal value As String)

    'Protected Friend Sub SetText(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

    '    If Label1.InvokeRequired Then
    '        Label1.Invoke(New writeItem(AddressOf upadteProgLbl), e.Argument)
    '    Else
    '        Label1.Text = CStr(e.Argument)

    '    End If
    '    Thread.Sleep(100)
    'End Sub

    'Protected Friend Sub upadteProgLbl(ByVal t As String)
    '    Label1.Text = t
    'End Sub

    Protected Friend Sub UpdateProgressMax(ByVal value As Integer)
        Me.ProgressBar1.Maximum = value
    End Sub

    Private Sub UpdateProgressVal(ByVal value As Integer)
        Me.ProgressBar1.Value = value
    End Sub

    Private Sub UpdateProgressText(ByVal value As String)
        Me.Label1.Text = value
    End Sub

    Protected Friend Sub ProgressTotal(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

        If Me.ProgressBar1.InvokeRequired Then
            Me.ProgressBar1.Invoke(New setProgMax(AddressOf UpdateProgressMax), e.ProgressPercentage)
        Else
            Me.ProgressBar1.Maximum = e.ProgressPercentage
        End If

    End Sub

    Protected Friend Sub ProgressVal(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

        If Me.ProgressBar1.InvokeRequired Then
            Me.ProgressBar1.Invoke(New setProgVal(AddressOf UpdateProgressVal), e.ProgressPercentage)
        Else
            Me.ProgressBar1.Value = e.ProgressPercentage
        End If

    End Sub

    Protected Friend Sub ProgressText(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

        If Me.Label1.InvokeRequired Then
            Me.Label1.Invoke(New setProgText(AddressOf UpdateProgressText), e.UserState.ToString)
        Else
            Me.Label1.Text = e.UserState.ToString
        End If

    End Sub


End Class
