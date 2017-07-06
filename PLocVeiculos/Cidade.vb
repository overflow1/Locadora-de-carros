Imports System.Data.SqlClient
Public Class Cidade
    Private idcidade As Integer
    Private nomecidade As String
    Private ufcidade As String

    Public Property id_cidade As Integer
        Get
            Return idcidade
        End Get
        Set(value As Integer)
            idcidade = value
        End Set
    End Property


    Public Property nome_cidade As String
        Get
            Return nomecidade
        End Get
        Set(value As String)
            nomecidade = value
        End Set
    End Property


    Public Property uf_cidade As String
        Get
            Return ufcidade
        End Get
        Set(value As String)
            ufcidade = value
        End Set
    End Property


    Public Function Salvar() As Integer
        Dim retorno As Integer = 0

        If Not IsNumeric(idcidade) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If nomecidade = "" Then
            MsgBox("O campo nome da cidade não pode ser vazio!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If IsNumeric(nomecidade) Then
            MsgBox("O campo nome da cidade só podem conter letras!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If ufcidade = "" Then
            MsgBox("Estado deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If


        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("INSERT INTO CIDADE VALUES (@DESCCIDADE,@ufcidade)", frmPrincipal.Conexao)


            MyCommand.Parameters.Add(New SqlParameter("@DESCCIDADE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@ufcidade", SqlDbType.VarChar))


            MyCommand.Parameters("@DESCCIDADE").Value = nomecidade
            MyCommand.Parameters("@ufcidade").Value = ufcidade

            nReg = MyCommand.ExecuteNonQuery()

            If nReg > 0 Then
                MsgBox("Inserção realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir cidade!", MsgBoxStyle.Critical)
        End Try

        Return retorno
    End Function

    Public Function Alterar() As Integer
        Dim retorno As Integer = 0

        If nomecidade = "" Then
            MsgBox("Cidade deve ser preenchida!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If IsNumeric(nomecidade) Then
            MsgBox("O campo nome da cidade só podem conter letras!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If ufcidade = "" Then
            MsgBox("Estado deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("UPDATE CIDADE SET DESCCIDADE = @DESCCIDADE ,ufcidade = @ufcidade WHERE idcidade = @idcidade", frmPrincipal.Conexao)

            MyCommand.Parameters.Add(New SqlParameter("@DESCCIDADE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@ufcidade", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@idcidade", SqlDbType.Int))

            MyCommand.Parameters("@idcidade").Value = idcidade
            MyCommand.Parameters("@DESCCIDADE").Value = nomecidade
            MyCommand.Parameters("@ufcidade").Value = ufcidade

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Alteração realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar alterar cidade!", MsgBoxStyle.Critical)
        End Try
        Return retorno
    End Function

    Public Function Listar() As DataTable
        Dim daCidade As SqlDataAdapter
        Dim dtCidade As New DataTable()
        Try
            daCidade = New SqlDataAdapter("SELECT * FROM CIDADE", frmPrincipal.Conexao)
            daCidade.Fill(dtCidade)
            daCidade.FillSchema(dtCidade, SchemaType.Source)
        Catch ex As Exception
            MsgBox("Erro ao carregar cidades!!!")
        End Try
        Return dtCidade
    End Function


    Public Function Excluir() As Integer
        Dim nReg As Integer = 0

        Try
            Dim MyCommand As SqlCommand

            MyCommand = New SqlCommand("DELETE FROM CIDADE WHERE idcidade=@idcidade", frmPrincipal.Conexao)
            MyCommand.Parameters.Add(New SqlParameter("@idcidade", SqlDbType.Int))
            MyCommand.Parameters("@idcidade").Value = CInt(idcidade)

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Cidade excluída com sucesso!", MsgBoxStyle.Information, "Mensagem")
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir a cidade!", MsgBoxStyle.Critical)
        End Try

        Return nReg
    End Function

End Class

