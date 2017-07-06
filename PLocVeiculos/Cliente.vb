Imports System.Data.SqlClient
Public Class Cliente
    Private idCLIENTE As Integer
    Private CIDADE_idCIDADE As Integer
    Private NOMECLIENTE As String
    Private ENDCLIENTE As String
    Private CPFCLIENTE As String
    Private RGCLIENTE As String
    Private CEPCLIENTE As String
    Private FONECLIENTE As String
    Private EMAILCLIENTE As String
    Private DTCADCLIENTE As Date

    Public Property id_cliente As Integer
        Get
            Return idcliente
        End Get
        Set(value As Integer)
            idcliente = value
        End Set
    End Property

    Public Property cidade_id_cidade As Integer
        Get
            Return CIDADE_idCIDADE
        End Get
        Set(value As Integer)
            CIDADE_idCIDADE = value
        End Set
    End Property

    Public Property nome_cliente As String
        Get
            Return nomecliente
        End Get
        Set(value As String)
            nomecliente = value
        End Set
    End Property

    Public Property end_cliente As String
        Get
            Return endcliente
        End Get
        Set(value As String)
            endcliente = value
        End Set
    End Property

    Public Property cpf_cliente As String
        Get
            Return cpfcliente
        End Get
        Set(value As String)
            cpfcliente = value
        End Set
    End Property

    Public Property rg_cliente As String
        Get
            Return rgcliente
        End Get
        Set(value As String)
            rgcliente = value
        End Set
    End Property

    Public Property cep_cliente As String
        Get
            Return cepcliente
        End Get
        Set(value As String)
            cepcliente = value
        End Set
    End Property

    Public Property fone_cliente As String
        Get
            Return fonecliente
        End Get
        Set(value As String)
            fonecliente = value
        End Set
    End Property

    Public Property email_cliente As String
        Get
            Return emailcliente
        End Get
        Set(value As String)
            emailcliente = value
        End Set
    End Property

    Public Property dtcad_cliente As Date
        Get
            Return dtcadcliente
        End Get
        Set(value As Date)
            dtcadcliente = value
        End Set
    End Property

    Public Function Salvar() As Integer
        Dim retorno As Integer = 0

        If Not IsNumeric(idcliente) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(CIDADE_idCIDADE) Then
            MsgBox("O campo é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If


        If nomecliente = "" Then
            MsgBox("O campo nome não pode ser vazio!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If endcliente = "" Then
            MsgBox("Endereço deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If cpfcliente = "" Then
            MsgBox("CPF deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function

        End If

        If rgcliente = "" Then
            MsgBox("RG deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If cepcliente = "" Then
            MsgBox("CEP deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If fonecliente = "" Then
            MsgBox("Telefone deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If emailcliente = "" Then
            MsgBox("Email deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtcadcliente) Then
            MsgBox("Data deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("INSERT INTO CLIENTE VALUES (@CIDADE_idCIDADE,@NOMECLIENTE,@ENDCLIENTE,@CPFCLIENTE,@RGCLIENTE,@CEPCLIENTE,@FONECLIENTE,@EMAILCLIENTE,@DTCADCLIENTE)", frmPrincipal.Conexao)

            MyCommand.Parameters.Add(New SqlParameter("@CIDADE_idCIDADE", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@NOMECLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@ENDCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@CPFCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@RGCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@CEPCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@FONECLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@EMAILCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@DTCADCLIENTE", SqlDbType.Date))

            MyCommand.Parameters("@CIDADE_idCIDADE").Value = CIDADE_idCIDADE
            MyCommand.Parameters("@NOMECLIENTE").Value = NOMECLIENTE
            MyCommand.Parameters("@ENDCLIENTE").Value = ENDCLIENTE
            MyCommand.Parameters("@CPFCLIENTE").Value = CPFCLIENTE
            MyCommand.Parameters("@RGCLIENTE").Value = RGCLIENTE
            MyCommand.Parameters("@CEPCLIENTE").Value = CEPCLIENTE
            MyCommand.Parameters("@FONECLIENTE").Value = FONECLIENTE
            MyCommand.Parameters("@EMAILCLIENTE").Value = EMAILCLIENTE
            MyCommand.Parameters("@DTCADCLIENTE").Value = DTCADCLIENTE

            nReg = MyCommand.ExecuteNonQuery()

            If nReg > 0 Then
                MsgBox("Inserção realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir cliente!", MsgBoxStyle.Critical)
        End Try

        Return retorno

    End Function

    Public Function Alterar() As Integer
        Dim retorno As Integer = 0

        If Not IsNumeric(CIDADE_idCIDADE) Then
            MsgBox("O campo é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If nomecliente = "" Then
            MsgBox("O campo nome não pode ser vazio!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If endcliente = "" Then
            MsgBox("Endereço deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If cpfcliente = "" Then
            MsgBox("CPF deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function

        End If

        If rgcliente = "" Then
            MsgBox("RG deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If cepcliente = "" Then
            MsgBox("CEP deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If fonecliente = "" Then
            MsgBox("Telefone deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If emailcliente = "" Then
            MsgBox("Email deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtcadcliente) Then

            MsgBox("Data deve ser preenchido!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("UPDATE CLIENTE SET CIDADE_idCIDADE = @CIDADE_idCIDADE,NOMECLIENTE = @NOMECLIENTE,ENDCLIENTE = @ENDCLIENTE,CPFCLIENTE = @CPFCLIENTE,RGCLIENTE = @RGCLIENTE,CEPCLIENTE = @CEPCLIENTE,FONECLIENTE = @FONECLIENTE,EMAILCLIENTE = @EMAILCLIENTE,DTCADCLIENTE = @DTCADCLIENTE  WHERE idCLIENTE = @idCLIENTE", frmPrincipal.Conexao)

            MyCommand.Parameters.Add(New SqlParameter("@CIDADE_idCIDADE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@NOMECLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@ENDCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@CPFCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@RGCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@CEPCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@FONECLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@EMAILCLIENTE", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@DTCADCLIENTE", SqlDbType.Date))
            MyCommand.Parameters.Add(New SqlParameter("@idCLIENTE", SqlDbType.Int))

            MyCommand.Parameters("@CIDADE_idCIDADE").Value = cidade_id_cidade
            MyCommand.Parameters("@NOMECLIENTE").Value = nome_cliente
            MyCommand.Parameters("@ENDCLIENTE").Value = end_cliente
            MyCommand.Parameters("@CPFCLIENTE").Value = cpf_cliente
            MyCommand.Parameters("@RGCLIENTE").Value = rg_cliente
            MyCommand.Parameters("@CEPCLIENTE").Value = cep_cliente
            MyCommand.Parameters("@FONECLIENTE").Value = fone_cliente
            MyCommand.Parameters("@EMAILCLIENTE").Value = email_cliente
            MyCommand.Parameters("@DTCADCLIENTE").Value = dtcad_cliente
            MyCommand.Parameters("@idCLIENTE").Value = id_cliente

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Alteração realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar alterar o cliente!", MsgBoxStyle.Critical)
        End Try
        Return retorno

    End Function

    Public Function Listar() As DataTable
        Dim daCliente As SqlDataAdapter
        Dim dtCliente As New DataTable()
        Try
            daCliente = New SqlDataAdapter("SELECT * FROM CLIENTE", frmPrincipal.Conexao)
            daCliente.Fill(dtCliente)
            daCliente.FillSchema(dtCliente, SchemaType.Source)
        Catch ex As Exception
            MsgBox("Erro ao carregar clientes!!!")
        End Try
        Return dtCliente
    End Function

    Public Function Excluir() As Integer
        Dim nReg As Integer = 0

        Try
            Dim MyCommand As SqlCommand

            MyCommand = New SqlCommand("DELETE FROM CLIENTE WHERE idcliente = @idCLIENTE", frmPrincipal.Conexao)
            MyCommand.Parameters.Add(New SqlParameter("@idCLIENTE", SqlDbType.Int))
            MyCommand.Parameters("@idCLIENTE").Value = CInt(idcliente)

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Cliente excluído com sucesso!", MsgBoxStyle.Information, "Mensagem")
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir o cliente", MsgBoxStyle.Critical)
        End Try

        Return nReg
    End Function
End Class