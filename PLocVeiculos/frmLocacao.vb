Imports System.Data.SqlClient

Public Class frmLocacao
    Private bnLocacao As New BindingSource
    Private bInclusao As Boolean = False
    Private dsLocacao As New DataSet()

    Private Sub frmLocacao_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Dim Loc As New Locacao()
            dsLocacao.Tables.Add(Loc.Listar())
            bnLocacao.DataSource = dsLocacao.Tables("LOCACAO")
            dgvLocacao.DataSource = bnLocacao
            bnvLocacao.BindingSource = bnLocacao

            Dim bnCliente As New BindingSource
            Dim dsCliente As New DataSet()
            Dim Cli As New Cliente()

            dsCliente.Tables.Add(Cli.Listar())
            cbxCliente.DataSource = dsCliente.Tables("CLIENTE")
            cbxCliente.DisplayMember = "NOMECLIENTE"
            cbxCliente.ValueMember = "idCLIENTE"

            Dim bnAutomovel As New BindingSource
            Dim dsAutomovel As New DataSet()
            Dim Auto As New Automovel()

            dsAutomovel.Tables.Add(Auto.Listar())
            cbxAutomovel.DataSource = dsAutomovel.Tables("AUTOMOVEL")
            cbxAutomovel.DisplayMember = "DESCAUTOMOVEL"
            cbxAutomovel.ValueMember = "idAUTOMOVEL"

            txtID.DataBindings.Add("TEXT", bnLocacao, "idLOCACAO")
            cbxCliente.DataBindings.Add("SELECTEDVALUE", bnLocacao, "CLIENTE_idCLIENTE")
            cbxAutomovel.DataBindings.Add("SELECTEDVALUE", bnLocacao, "AUTOMOVEL_idAUTOMOVEL")
            txtKmInicial.DataBindings.Add("TEXT", bnLocacao, "KMINICIAL")
            txtKmFinal.DataBindings.Add("TEXT", bnLocacao, "KMFINAL")
            txtPrecoLocacao.DataBindings.Add("TEXT", bnLocacao, "PRECOLOCACAO")
            txtDataInicial.DataBindings.Add("TEXT", bnLocacao, "DTINICIALLOCACAO")
            txtDataFinal.DataBindings.Add("TEXT", bnLocacao, "DTFINALLOCACAO")
            txtDataCadLocacao.DataBindings.Add("TEXT", bnLocacao, "DTCADLOCAO")

           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnNovoRegistro_Click(sender As System.Object, e As System.EventArgs) Handles btnNovoRegistro.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        bnLocacao.AddNew()

        txtID.Enabled = False
        cbxCliente.Enabled = True
        cbxAutomovel.Enabled = True
        txtKmInicial.Enabled = True
        txtKmFinal.Enabled = True
        txtDataInicial.Enabled = True
        txtDataFinal.Enabled = True
        txtPrecoLocacao.Enabled = True
        txtDataCadLocacao.Enabled = True

        txtID.Focus()
        btnSalvar.Enabled = True
        btnAlterar.Enabled = False
        btnNovoRegistro.Enabled = False
        btnExcluir.Enabled = False
        btnCancelar.Enabled = True

        bInclusao = True
    End Sub


    Private Sub btnSalvar_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvar.Click

        Dim RegLoc As New Locacao()

        RegLoc.id_locacao = CInt(txtID.Text)
        RegLoc.cliente_id_cliente = CInt(cbxCliente.SelectedValue.ToString)
        RegLoc.automovel_id_automovel = CInt(cbxAutomovel.SelectedValue.ToString)
        RegLoc.km_inicial = txtKmInicial.Text
        RegLoc.km_final = txtKmFinal.Text
        RegLoc.preco_locacao = CDbl(txtPrecoLocacao.Text)
        RegLoc.dtinicial_locacao = CDate(txtDataInicial.Text)
        RegLoc.dtfinal_locacao = CDate(txtDataFinal.Text)
        RegLoc.dtcad_locao = CDate(txtDataCadLocacao.Text)

        If bInclusao Then

            If RegLoc.Salvar() > 0 Then

                btnSalvar.Enabled = False

                txtID.Enabled = False
                cbxCliente.Enabled = False
                cbxAutomovel.Enabled = False
                txtKmInicial.Enabled = False
                txtKmFinal.Enabled = False
                txtDataInicial.Enabled = False
                txtDataFinal.Enabled = False
                txtPrecoLocacao.Enabled = False
                txtDataCadLocacao.Enabled = False

                btnSalvar.Enabled = False
                btnAlterar.Enabled = True
                btnNovoRegistro.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False

                bInclusao = False

                dsLocacao.Tables.Clear()
                dsLocacao.Tables.Add(RegLoc.Listar())
            End If
        Else
            If RegLoc.Alterar() > 0 Then

                dsLocacao.Tables.Clear()
                dsLocacao.Tables.Add(RegLoc.Listar())

                txtID.Enabled = False
                cbxCliente.Enabled = False
                cbxAutomovel.Enabled = False
                txtKmInicial.Enabled = False
                txtKmFinal.Enabled = False
                txtDataInicial.Enabled = False
                txtDataFinal.Enabled = False
                txtPrecoLocacao.Enabled = False
                txtDataCadLocacao.Enabled = False
              

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


        txtID.Enabled = False
        cbxCliente.Enabled = True
        cbxAutomovel.Enabled = True
        txtKmInicial.Enabled = True
        txtKmFinal.Enabled = True
        txtDataInicial.Enabled = True
        txtDataFinal.Enabled = True
        txtPrecoLocacao.Enabled = True
        txtDataCadLocacao.Enabled = True

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

        If MsgBox("Tem certeza que deseja excluir permanentemente a locacao?", MsgBoxStyle.YesNo, "Atenção!") = Windows.Forms.DialogResult.Yes Then

            Dim RegLoc As New Locacao()

            RegLoc.id_locacao = CInt(txtID.Text)
            RegLoc.cliente_id_cliente = CInt(cbxCliente.SelectedValue.ToString)
            RegLoc.automovel_id_automovel = CInt(cbxAutomovel.SelectedValue.ToString)
            RegLoc.km_inicial = txtKmInicial.Text
            RegLoc.km_final = txtKmFinal.Text
            RegLoc.preco_locacao = CDbl(txtPrecoLocacao.Text)
            RegLoc.dtinicial_locacao = CDate(txtDataInicial.Text)
            RegLoc.dtfinal_locacao = CDate(txtDataFinal.Text)
            RegLoc.dtcad_locao = CDate(txtDataCadLocacao.Text)

            If RegLoc.Excluir() > 0 Then
                Dim R As New Locacao()
                dsLocacao.Tables.Clear()
                dsLocacao.Tables.Add(R.Listar())
                bnLocacao.DataSource = dsLocacao.Tables("LOCACAO")
            End If
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

        bnLocacao.CancelEdit()

        btnSalvar.Enabled = False

        txtID.Enabled = False
        cbxCliente.Enabled = False
        cbxAutomovel.Enabled = False
        txtKmInicial.Enabled = False
        txtKmFinal.Enabled = False
        txtDataInicial.Enabled = False
        txtDataFinal.Enabled = False
        txtPrecoLocacao.Enabled = False
        txtDataCadLocacao.Enabled = False


        btnAlterar.Enabled = True
        btnNovoRegistro.Enabled = True
        btnExcluir.Enabled = True
    End Sub

    Private Sub btnSair_Click(sender As System.Object, e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

End Class