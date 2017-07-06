Imports System.Data.SqlClient

Public Class frmAutomovel
    Private bnAutomovel As New BindingSource
    Private bnModelo As New BindingSource
    Private bInclusao As Boolean = False
    Private dsAutomovel As New DataSet()
    Private dsModelo As New DataSet()

    Private Sub frmAutomovel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Dim Auto As New Automovel()
            dsAutomovel.Tables.Add(Auto.Listar())
            bnAutomovel.DataSource = dsAutomovel.Tables("AUTOMOVEL")
            dgvAutomovel.DataSource = bnAutomovel
            bnvAutomovel.BindingSource = bnAutomovel

            txtIdAutomovel.DataBindings.Add("TEXT", bnAutomovel, "idAUTOMOVEL")
            txtDescAutomovel.DataBindings.Add("TEXT", bnAutomovel, "DESCAUTOMOVEL")

            Dim Mode As New Modelo()
            dsModelo.Tables.Add(Mode.Listar())
            cbxModelo.DataSource = dsModelo.Tables("MODELO")
            cbxModelo.DisplayMember = "FABMODELO"
            cbxModelo.ValueMember = "idmodelo"
            cbxModelo.DataBindings.Add("SELECTEDVALUE", bnAutomovel, "MODELO_idMODELO")



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNovoRegistro_Click(sender As System.Object, e As System.EventArgs) Handles btnNovoRegistro.Click
        If TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectTab(1)
        End If

        bnAutomovel.AddNew()

        txtIdAutomovel.Enabled = False
        cbxModelo.Enabled = True
        txtDescAutomovel.Enabled = True
        txtIdAutomovel.Focus()
        btnSalvar.Enabled = True
        btnAlterar.Enabled = False
        btnNovoRegistro.Enabled = False
        btnExcluir.Enabled = False
        btnCancelar.Enabled = True

        bInclusao = True
    End Sub


    Private Sub btnSalvar_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvar.Click
        Dim RegAuto As New Automovel()

        RegAuto.id_automovel = CInt(txtIdAutomovel.Text)
        RegAuto.id_modelo = CInt(cbxModelo.SelectedValue.ToString)
        RegAuto.desc_automovel = txtDescAutomovel.Text

        If bInclusao Then

            If RegAuto.Salvar() > 0 Then

                btnNovoRegistro.Enabled = False
                txtIdAutomovel.Enabled = False
                cbxModelo.Enabled = False
                txtDescAutomovel.Enabled = False
                btnSalvar.Enabled = False
                btnAlterar.Enabled = True
                btnNovoRegistro.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False

                bInclusao = False

                dsAutomovel.Tables.Clear()
                dsAutomovel.Tables.Add(RegAuto.Listar())
            End If
        Else
            RegAuto.id_automovel = CInt(txtIdAutomovel.Text)

            If RegAuto.Alterar() > 0 Then
                dsAutomovel.Tables.Clear()
                dsAutomovel.Tables.Add(RegAuto.Listar())
                txtIdAutomovel.Enabled = False
                cbxModelo.Enabled = False
                txtDescAutomovel.Enabled = False
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

        txtIdAutomovel.Enabled = False
        txtDescAutomovel.Enabled = True
        cbxModelo.Enabled = True


        txtIdAutomovel.Focus()
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

        If MsgBox("Tem certeza que deseja excluir permanentemente o automovel?", MsgBoxStyle.YesNo, "Atenção!") = Windows.Forms.DialogResult.Yes Then

            Dim RegAuto As New Automovel()

            RegAuto.id_automovel = CInt(txtIdAutomovel.Text)
            RegAuto.id_modelo = CInt(cbxModelo.SelectedValue.ToString)
            RegAuto.desc_automovel = txtDescAutomovel.Text

            If RegAuto.Excluir() > 0 Then
                Dim R As New Automovel()
                dsAutomovel.Tables.Clear()
                dsAutomovel.Tables.Add(R.Listar())
                bnAutomovel.DataSource = dsAutomovel.Tables("AUTOMOVEL")
            End If
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

        bnAutomovel.CancelEdit()

        btnSalvar.Enabled = False
        txtIdAutomovel.Enabled = False
        cbxModelo.Enabled = False
        txtDescAutomovel.Enabled = False
        btnAlterar.Enabled = True
        btnNovoRegistro.Enabled = True
        btnExcluir.Enabled = True
    End Sub

    Private Sub btnSair_Click(sender As System.Object, e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub



End Class