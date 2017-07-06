Imports System.Data.SqlClient

Public Class frmPrincipal

    Public Conexao As SqlConnection

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Conexao = New SqlConnection("Data Source=.\SQLExpress;Initial Catalog=Projeto;Integrated Security=True")
            Conexao.Open()
        Catch ex As SqlException
            MsgBox("Erro de banco de dados =/")
        Catch ex As Exception
            MsgBox("Outros Erros =/")
        End Try
    End Sub

    Private Sub FrmPrincipal_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Conexao.Close()
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SobreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SobreToolStripMenuItem.Click
        frmSobre.Show()
    End Sub

    Private Sub CidadeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CidadeToolStripMenuItem.Click
        frmCidade.Show()
    End Sub

    Private Sub ModeloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModeloToolStripMenuItem.Click
        frmModelo.Show()
    End Sub

    Private Sub AutomovelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomóvelToolStripMenuItem.Click
        frmAutomovel.Show()
    End Sub


    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        frmCliente.Show()
    End Sub

    Private Sub LocaçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocaçõesToolStripMenuItem.Click
        frmLocacao.show()
    End Sub
End Class

