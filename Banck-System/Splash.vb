Public Class Splash


    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        ' BunifuProgressBar1.Increment()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(30)
        If (ProgressBar1.Value = 100) Then
            Me.Hide()
            Timer1.Stop()
            LoginForm1.Show()
        End If
    End Sub


End Class
