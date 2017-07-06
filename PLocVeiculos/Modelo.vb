Imports System.Data.SqlClient

Public Class Modelo
    Private idMODELO As Integer
    Private FABMODELO As String
    Private DESCMODELO As String

    Public Property id_modelo As Integer
        Get
            Return idMODELO
        End Get
        Set(value As Integer)
            idMODELO = value
        End Set
    End Property


    Public Property fab_modelo As String
        Get
            Return FABMODELO
        End Get
        Set(value As String)
            FABMODELO = value
        End Set
    End Property


    Public Property desc_modelo As String
        Get
            Return DESCMODELO
        End Get
        Set(value As String)
            DESCMODELO = value
        End Set
    End Property


    Public Function Salvar() As Integer
        Dim retorno As Integer = 0

        If Not IsNumeric(id_modelo) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If fab_modelo = " " Then
            MsgBox("O campo modelo não pode ser vazio!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If


        If desc_modelo = " " Then
            MsgBox("Este campo deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If


        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("INSERT INTO MODELO VALUES (@DESCMODELO,@FABMODELO)", frmPrincipal.Conexao)


            MyCommand.Parameters.Add(New SqlParameter("@DESCMODELO", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@FABMODELO", SqlDbType.VarChar))


            MyCommand.Parameters("@DESCMODELO").Value = DESCMODELO
            MyCommand.Parameters("@FABMODELO").Value = FABMODELO

            nReg = MyCommand.ExecuteNonQuery()

            If nReg > 0 Then
                MsgBox("Inserção realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir modelo!", MsgBoxStyle.Critical)
        End Try

        Return retorno
    End Function

    Public Function Alterar() As Integer
        Dim retorno As Integer = 0

        If (String.IsNullOrWhiteSpace(desc_modelo)) Then
            MsgBox("Modelo deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If (String.IsNullOrWhiteSpace(fab_modelo)) Then
            MsgBox("Estado deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("UPDATE MODELO SET DESCMODELO = @DESCMODELO ,FABMODELO = @FABMODELO WHERE idMODELO = @idMODELO", frmPrincipal.Conexao)

            MyCommand.Parameters.Add(New SqlParameter("@DESCMODELO", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@FABMODELO", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@idMODELO", SqlDbType.Int))

            MyCommand.Parameters("@idMODELO").Value = idMODELO
            MyCommand.Parameters("@DESCMODELO").Value = DESCMODELO
            MyCommand.Parameters("@FABMODELO").Value = FABMODELO

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Alteração realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar alterar modelo!", MsgBoxStyle.Critical)
        End Try
        Return retorno
    End Function

    Public Function Listar() As DataTable
        Dim daModelo As SqlDataAdapter
        Dim dtModelo As New DataTable()
        Try
            daModelo = New SqlDataAdapter("SELECT * FROM MODELO", frmPrincipal.Conexao)
            daModelo.Fill(dtModelo)
            daModelo.FillSchema(dtModelo, SchemaType.Source)
        Catch ex As Exception
            MsgBox("Erro ao carregar modelo!!!")
        End Try
        Return dtModelo
    End Function


    Public Function Excluir() As Integer
        Dim nReg As Integer = 0

        Try
            Dim MyCommand As SqlCommand

            MyCommand = New SqlCommand("DELETE FROM MODELO WHERE idMODELO=@idMODELO", frmPrincipal.Conexao)
            MyCommand.Parameters.Add(New SqlParameter("@idMODELO", SqlDbType.Int))
            MyCommand.Parameters("@idMODELO").Value = CInt(id_modelo)

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Modelo excluido com sucesso!", MsgBoxStyle.Information, "Mensagem")
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir o modelo, pode ser que existam clientes cadastrados com ele!", MsgBoxStyle.Critical)
        End Try

        Return nReg
    End Function
End Class