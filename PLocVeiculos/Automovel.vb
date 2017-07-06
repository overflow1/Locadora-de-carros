Imports System.Data.SqlClient

Public Class Automovel
    Private idAUTOMOVEL As Integer
    Private MODELO_idMODELO As Integer
    Private DESCAUTOMOVEL As String

    Public Property id_automovel As Integer
        Get
            Return idAUTOMOVEL
        End Get
        Set(value As Integer)
            idAUTOMOVEL = value
        End Set
    End Property


    Public Property id_modelo As Integer
        Get
            Return MODELO_idMODELO
        End Get
        Set(value As Integer)
            MODELO_idMODELO = value
        End Set
    End Property


    Public Property desc_automovel As String
        Get
            Return DESCAUTOMOVEL
        End Get
        Set(value As String)
            DESCAUTOMOVEL = value
        End Set
    End Property


    Public Function Salvar() As Integer
        Dim retorno As Integer = 0

        If Not IsNumeric(id_modelo) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If desc_automovel = " " Then
            MsgBox("O campo modelo não pode ser vazio!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("INSERT INTO AUTOMOVEL VALUES (@MODELO_idMODELO,@DESCAUTOMOVEL)", frmPrincipal.Conexao)

            MyCommand.Parameters.Add(New SqlParameter("@MODELO_idMODELO", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@DESCAUTOMOVEL", SqlDbType.VarChar))

            MyCommand.Parameters("@MODELO_idMODELO").Value = MODELO_idMODELO
            MyCommand.Parameters("@DESCAUTOMOVEL").Value = DESCAUTOMOVEL

            nReg = MyCommand.ExecuteNonQuery()

            If nReg > 0 Then
                MsgBox("Inserção realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir automóvel!", MsgBoxStyle.Critical)
        End Try

        Return retorno
    End Function

    Public Function Alterar() As Integer
        Dim retorno As Integer = 0

        If (String.IsNullOrWhiteSpace(desc_automovel)) Then
            MsgBox("A Descrição deve ser preenchida!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("UPDATE AUTOMOVEL SET DESCAUTOMOVEL = @DESCAUTOMOVEL WHERE idAUTOMOVEL = @idAUTOMOVEL", frmPrincipal.Conexao)


            MyCommand.Parameters.Add(New SqlParameter("@idAUTOMOVEL", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@MODELO_idMODELO", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@DESCAUTOMOVEL", SqlDbType.VarChar))


            MyCommand.Parameters("@idAUTOMOVEL").Value = id_automovel
            MyCommand.Parameters("@MODELO_idMODELO").Value = id_modelo
            MyCommand.Parameters("@DESCAUTOMOVEL").Value = desc_automovel

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Alteração realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar alterar automovel!", MsgBoxStyle.Critical)
        End Try
        Return retorno
    End Function

    Public Function Listar() As DataTable
        Dim daAutomovel As SqlDataAdapter
        Dim dtAutomovel As New DataTable()
        Try
            daAutomovel = New SqlDataAdapter("SELECT * FROM AUTOMOVEL", frmPrincipal.Conexao)
            daAutomovel.Fill(dtAutomovel)
            daAutomovel.FillSchema(dtAutomovel, SchemaType.Source)
        Catch ex As Exception
            MsgBox("Erro ao carregar automovel!!!")
        End Try
        Return dtAutomovel
    End Function


    Public Function Excluir() As Integer
        Dim nReg As Integer = 0

        Try
            Dim MyCommand As SqlCommand

            MyCommand = New SqlCommand("DELETE FROM AUTOMOVEL WHERE idAUTOMOVEL=@idAUTOMOVEL", frmPrincipal.Conexao)
            MyCommand.Parameters.Add(New SqlParameter("@idAUTOMOVEL", SqlDbType.Int))
            MyCommand.Parameters("@idAUTOMOVEL").Value = CInt(id_automovel)

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Automovel excluido com sucesso!", MsgBoxStyle.Information, "Mensagem")
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir o automovel, pode ser que existam clientes cadastrados com ele!", MsgBoxStyle.Critical)
        End Try

        Return nReg
    End Function
End Class