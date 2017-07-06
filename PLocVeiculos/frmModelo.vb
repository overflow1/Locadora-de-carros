Imports System.Data.SqlClient

Public Class frmModelo

    Private bnModelo As New BindingSource
    Private bInclusao As Boolean = False
    Private dsModelo As New DataSet()

    Private Sub frmModelo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Dim Mode As New Modelo()
            dsModelo.Tables.Add(Mode.Listar())
            bnModelo.DataSource = dsModelo.Tables("MODELO")
            dgvModelo.DataSource = bnModelo
            bnvModelo.BindingSource = bnModelo

            txtIdModelo.DataBindings.Add("TEXT", bnModelo, "idMODELO")
            txtDescModelo.DataBindings.Add("TEXT", bnModelo, "DESCMODELO")
            txtFabModelo.DataBindings.Add("TEXT", bnModelo, "FABMODELO")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNovoRegistro_Click(sender As System.Object, e As System.EventArgs) Handles btnNovoRegistro.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        bnModelo.AddNew()
        txtIdModelo.Enabled = False
        txtFabModelo.Enabled = True
        txtDescModelo.Enabled = True

        txtIdModelo.Focus()
        btnSalvar.Enabled = True
        btnAlterar.Enabled = False
        btnNovoRegistro.Enabled = False
        btnExcluir.Enabled = False
        btnAlterar.Enabled = True

        bInclusao = True
    End Sub


    Private Sub btnSalvar_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvar.Click
        Dim RegMode As New Modelo()

        RegMode.id_modelo = CInt(txtIdModelo.Text)
        RegMode.desc_modelo = txtDescModelo.Text
        RegMode.fab_modelo = txtFabModelo.Text

        If bInclusao Then

            If RegMode.Salvar() > 0 Then

                btnSalvar.Enabled = False

                txtIdModelo.Enabled = False
                txtDescModelo.Enabled = False
                txtFabModelo.Enabled = False
                btnSalvar.Enabled = False
                btnAlterar.Enabled = True
                btnNovoRegistro.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False

                bInclusao = False

                dsModelo.Tables.Clear()
                dsModelo.Tables.Add(RegMode.Listar())
            End If
        Else
            If RegMode.Alterar() > 0 Then
                dsModelo.Tables.Clear()
                dsModelo.Tables.Add(RegMode.Listar())
                txtIdModelo.Enabled = False
                txtFabModelo.Enabled = False
                txtDescModelo.Enabled = False
                btnSalvar.Enabled = False
                btnAlterar.Enabled = True
                btnNovoRegistro.Enabled = True
                btnExcluir.Enabled = True
                btnAlterar.Enabled = False
            End If
        End If
    End Sub


    Private Sub btnAlterar_Click(sender As System.Object, e As System.EventArgs) Handles btnAlterar.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        txtIdModelo.Enabled = False
        txtDescModelo.Enabled = True
        txtFabModelo.Enabled = True

        txtIdModelo.Focus()
        btnSalvar.Enabled = True
        btnAlterar.Enabled = False
        btnNovoRegistro.Enabled = False
        btnExcluir.Enabled = False
        btnCancelar.Enabled = True

        bInclusao = False
    End Sub


    Private Sub btnExcluir_Click(sender As System.Object, e As System.EventArgs) Handles btnExcluir.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        If MsgBox("Tem certeza que deseja excluir permanentemente o modelo?", MsgBoxStyle.YesNo, "Atenção!") = Windows.Forms.DialogResult.Yes Then

            Dim RegMode As New Modelo()

            RegMode.id_modelo = CInt(txtIdModelo.Text)
            RegMode.desc_modelo = txtDescModelo.Text
            RegMode.fab_modelo = txtFabModelo.Text

            If RegMode.Excluir() > 0 Then
                Dim M As New Modelo()
                dsModelo.Tables.Clear()
                dsModelo.Tables.Add(M.Listar())
                bnModelo.DataSource = dsModelo.Tables("MODELO")
            End If
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnAlterar.Click

        bnModelo.CancelEdit()

        btnNovoRegistro.Enabled = False
        txtIdModelo.Enabled = False
        txtFabModelo.Enabled = False
        txtDescModelo.Enabled = False
        btnAlterar.Enabled = True
        btnNovoRegistro.Enabled = True
        btnExcluir.Enabled = True
    End Sub

    Private Sub btnSair_Click(sender As System.Object, e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

End Class
