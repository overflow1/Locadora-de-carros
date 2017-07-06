Imports System.Data.SqlClient
Public Class frmCidade

    Private bnCidade As New BindingSource
    Private bInclusao As Boolean = False
    Private dsCidade As New DataSet()

    Private Sub frmCidade_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Dim Cid As New Cidade()
            dsCidade.Tables.Add(Cid.Listar())
            bnCidade.DataSource = dsCidade.Tables("Cidade")
            dgvCidade.DataSource = bnCidade
            bnvCidade.BindingSource = bnCidade

            txtID.DataBindings.Add("TEXT", bnCidade, "idcidade")
            txtNomeCidade.DataBindings.Add("TEXT", bnCidade, "DESCCIDADE")
            txtUF.DataBindings.Add("TEXT", bnCidade, "ufcidade")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnNovoRegistro_Click(sender As System.Object, e As System.EventArgs) Handles btnNovoRegistro.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        bnCidade.AddNew()

        txtID.Enabled = False
        txtNomeCidade.Enabled = True
        txtUF.Enabled = True

        txtID.Focus()
        btnSalvar.Enabled = True
        btnAlterar.Enabled = False
        btnNovoRegistro.Enabled = False
        btnExcluir.Enabled = False
        btnCancelar.Enabled = True

        bInclusao = True
    End Sub


    Private Sub btnSalvar_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvar.Click
        Dim RegCid As New Cidade()

        RegCid.id_cidade = CInt(txtID.Text)
        RegCid.nome_cidade = txtNomeCidade.Text
        RegCid.uf_cidade = txtUF.Text

        If bInclusao Then

            If RegCid.Salvar() > 0 Then

                btnSalvar.Enabled = False

                txtID.Enabled = False
                txtNomeCidade.Enabled = False
                txtUF.Enabled = False

                btnSalvar.Enabled = False
                btnAlterar.Enabled = True
                btnNovoRegistro.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False

                bInclusao = False

                dsCidade.Tables.Clear()
                dsCidade.Tables.Add(RegCid.Listar())
            End If
        Else
            If RegCid.Alterar() > 0 Then

                dsCidade.Tables.Clear()
                dsCidade.Tables.Add(RegCid.Listar())

                txtID.Enabled = False
                txtNomeCidade.Enabled = False
                txtUF.Enabled = False

                btnSalvar.Enabled = False
                btnAlterar.Enabled = True
                btnNovoRegistro.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False
            End If

        End If
    End Sub


    Private Sub btnAlterar_Click(sender As System.Object, e As System.EventArgs) Handles btnAlterar.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        txtId.Enabled = False
        txtNomeCidade.Enabled = True
        txtUF.Enabled = True

        txtID.Focus()
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

        If MsgBox("Tem certeza que deseja excluir permanentemente a cidade?", MsgBoxStyle.YesNo, "Atenção!") = Windows.Forms.DialogResult.Yes Then

            Dim RegCid As New Cidade()

            RegCid.id_cidade = CInt(txtId.Text)
            RegCid.nome_cidade = txtNomeCidade.Text
            RegCid.uf_cidade = txtUF.Text

            If RegCid.Excluir() > 0 Then
                Dim R As New Cidade()
                dsCidade.Tables.Clear()
                dsCidade.Tables.Add(R.Listar())
                bnCidade.DataSource = dsCidade.Tables("Cidade")
            End If
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

        bnCidade.CancelEdit()

        btnSalvar.Enabled = False

        txtID.Enabled = False
        txtNomeCidade.Enabled = False
        txtUF.Enabled = False

        btnAlterar.Enabled = True
        btnNovoRegistro.Enabled = True
        btnExcluir.Enabled = True
    End Sub

    Private Sub btnSair_Click(sender As System.Object, e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

End Class