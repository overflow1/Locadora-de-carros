Imports System.Data.SqlClient
Public Class frmCliente

    Private bnCliente As New BindingSource
    Private bInclusao As Boolean = False
    Private dsCliente As New DataSet()

    Private Sub frmCidade_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Dim Cli As New Cliente()
            dsCliente.Tables.Add(Cli.Listar())
            bnCliente.DataSource = dsCliente.Tables("CLIENTE")
            dgvCliente.DataSource = bnCliente
            bnvCliente.BindingSource = bnCliente

            Dim bnCidade As New BindingSource
            Dim dsCidade As New DataSet()
            Dim Cid As New Cidade()

            dsCidade.Tables.Add(Cid.Listar())
            cbxCidade.DataSource = dsCidade.Tables("CIDADE")
            cbxCidade.DisplayMember = "DESCCIDADE"
            cbxCidade.ValueMember = "idCIDADE"

            txtID.DataBindings.Add("TEXT", bnCliente, "idCLIENTE")
            cbxCidade.DataBindings.Add("SELECTEDVALUE", bnCliente, "CIDADE_idCIDADE")
            txtNome.DataBindings.Add("TEXT", bnCliente, "NOMECLIENTE")
            txtEndereco.DataBindings.Add("TEXT", bnCliente, "ENDCLIENTE")
            txtCPF.DataBindings.Add("TEXT", bnCliente, "CPFCLIENTE")
            txtRG.DataBindings.Add("TEXT", bnCliente, "RGCLIENTE")
            txtCEP.DataBindings.Add("TEXT", bnCliente, "CEPCLIENTE")
            txtFone.DataBindings.Add("TEXT", bnCliente, "FONECLIENTE")
            txtEmail.DataBindings.Add("TEXT", bnCliente, "EMAILCLIENTE")
            txtDatacad.DataBindings.Add("TEXT", bnCliente, "DTCADCLIENTE")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnNovoRegistro_Click(sender As System.Object, e As System.EventArgs) Handles btnNovoRegistro.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        Dim bnCidade As New BindingSource
        Dim dsCidade As New DataSet()
        Dim Cid As New Cidade()

        bnCliente.AddNew()

        cbxCidade.Enabled = True
        txtID.Enabled = False
        txtNome.Enabled = True
        txtEndereco.Enabled = True
        txtCPF.Enabled = True
        txtRG.Enabled = True
        txtCEP.Enabled = True
        txtFone.Enabled = True
        txtEmail.Enabled = True
        txtDatacad.Enabled = True

        txtID.Focus()
        btnSalvar.Enabled = True
        btnAlterar.Enabled = False
        btnNovoRegistro.Enabled = False
        btnExcluir.Enabled = False
        btnCancelar.Enabled = True

        bInclusao = True
    End Sub


    Private Sub btnSalvar_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvar.Click

        Dim RegCli As New Cliente()

        RegCli.id_cliente = CInt(txtID.Text)
        RegCli.cidade_id_cidade = CInt(cbxCidade.SelectedValue.ToString)
        RegCli.nome_cliente = txtNome.Text
        RegCli.end_cliente = txtEndereco.Text
        RegCli.cpf_cliente = txtCPF.Text
        RegCli.rg_cliente = txtRG.Text
        RegCli.cep_cliente = txtCEP.Text
        RegCli.fone_cliente = txtFone.Text
        RegCli.email_cliente = txtEmail.Text
        RegCli.dtcad_cliente = CDate(txtDatacad.Text)

        If bInclusao Then

            If RegCli.Salvar() > 0 Then

                btnSalvar.Enabled = False

                txtID.Enabled = False
                cbxCidade.Enabled = False
                txtNome.Enabled = False
                txtEndereco.Enabled = False
                txtCPF.Enabled = True
                txtRG.Enabled = True
                txtCEP.Enabled = True
                txtFone.Enabled = True
                txtEmail.Enabled = False
                txtDatacad.Enabled = False

                btnSalvar.Enabled = False
                btnAlterar.Enabled = True
                btnNovoRegistro.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False

                bInclusao = False

                dsCliente.Tables.Clear()
                dsCliente.Tables.Add(RegCli.Listar())
            End If
        Else
            If RegCli.Alterar() > 0 Then

                dsCliente.Tables.Clear()
                dsCliente.Tables.Add(RegCli.Listar())


                txtID.Enabled = False
                cbxCidade.Enabled = False
                txtNome.Enabled = False
                txtEndereco.Enabled = False
                txtCPF.Enabled = True
                txtRG.Enabled = True
                txtCEP.Enabled = True
                txtFone.Enabled = True
                txtEmail.Enabled = False
                txtDatacad.Enabled = False

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
        cbxCidade.Enabled = True
        txtNome.Enabled = True
        txtEndereco.Enabled = True
        txtCPF.Enabled = True
        txtRG.Enabled = True
        txtCEP.Enabled = True
        txtFone.Enabled = True
        txtEmail.Enabled = True
        txtDatacad.Enabled = True

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

        If MsgBox("Tem certeza que deseja excluir permanentemente o cliente?", MsgBoxStyle.YesNo, "Atenção!") = Windows.Forms.DialogResult.Yes Then

            Dim RegCli As New Cliente()

            RegCli.id_cliente = CInt(txtID.Text)
            RegCli.cidade_id_cidade = CInt(cbxCidade.SelectedValue.ToString)
            RegCli.nome_cliente = txtNome.Text
            RegCli.end_cliente = txtEndereco.Text
            RegCli.cpf_cliente = txtCPF.Text
            RegCli.rg_cliente = txtRG.Text
            RegCli.cep_cliente = txtCEP.Text
            RegCli.fone_cliente = txtFone.Text
            RegCli.email_cliente = txtEmail.Text
            RegCli.dtcad_cliente = CDate(txtDatacad.Text)

            If RegCli.Excluir() > 0 Then
                Dim R As New Cliente()
                dsCliente.Tables.Clear()
                dsCliente.Tables.Add(R.Listar())
                bnCliente.DataSource = dsCliente.Tables("Cliente")
            End If
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

        bnCliente.CancelEdit()

        btnSalvar.Enabled = False

        txtID.Enabled = False
        cbxCidade.Enabled = False
        txtNome.Enabled = False
        txtEndereco.Enabled = False
        txtCPF.Enabled = True
        txtRG.Enabled = True
        txtCEP.Enabled = True
        txtFone.Enabled = True
        txtEmail.Enabled = False
        txtDatacad.Enabled = False


        btnAlterar.Enabled = True
        btnNovoRegistro.Enabled = True
        btnExcluir.Enabled = True
    End Sub

    Private Sub btnSair_Click(sender As System.Object, e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub
End Class
