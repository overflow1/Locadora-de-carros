Imports System.Data.SqlClient
Public Class Locacao

    Private idLOCACAO As Integer
    Private CLIENTE_idCLIENTE As Integer
    Private AUTOMOVEL_idAUTOMOVEL As Integer
    Private KMINICIAL As String
    Private KMFINAL As String
    Private PRECOLOCACAO As Double
    Private DTINICIALLOCACAO As Date
    Private DTFINALLOCACAO As Date
    Private DTCADLOCAO As Date

    Public Property id_locacao As Integer
        Get
            Return idLOCACAO
        End Get
        Set(value As Integer)
            idLOCACAO = value
        End Set
    End Property

    Public Property cliente_id_cliente As Integer
        Get
            Return CLIENTE_idCLIENTE
        End Get
        Set(value As Integer)
            CLIENTE_idCLIENTE = value
        End Set
    End Property

    Public Property automovel_id_automovel As Integer
        Get
            Return AUTOMOVEL_idAUTOMOVEL
        End Get
        Set(value As Integer)
            AUTOMOVEL_idAUTOMOVEL = value
        End Set
    End Property

    Public Property km_inicial As String
        Get
            Return KMINICIAL
        End Get
        Set(value As String)
            KMINICIAL = value
        End Set
    End Property

    Public Property km_final As String
        Get
            Return KMFINAL
        End Get
        Set(value As String)
            KMFINAL = value
        End Set
    End Property

    Public Property preco_locacao As Double
        Get
            Return PRECOLOCACAO
        End Get
        Set(value As Double)
            PRECOLOCACAO = value
        End Set
    End Property

    Public Property dtinicial_locacao As Date
        Get
            Return DTINICIALLOCACAO
        End Get
        Set(value As Date)
            DTINICIALLOCACAO = value
        End Set
    End Property

    Public Property dtfinal_locacao As Date
        Get
            Return DTFINALLOCACAO
        End Get
        Set(value As Date)
            DTFINALLOCACAO = value
        End Set
    End Property
  
    Public Property dtcad_locao As Date
        Get
            Return DTCADLOCAO
        End Get
        Set(value As Date)
            DTCADLOCAO = value
        End Set
    End Property

    Public Function Salvar() As Integer
        Dim retorno As Integer = 0

        If Not IsNumeric(id_locacao) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(cliente_id_cliente) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(automovel_id_automovel) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(km_inicial) Then
            MsgBox("O campo KM INICIAL deve ser composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(km_final) Then
            MsgBox("O campo KM FINAL deve ser composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(preco_locacao) Then
            MsgBox("O campo PREÇO deve ser composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtinicial_locacao) Then
            MsgBox("O campo deve ter o formato de data!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtfinal_locacao) Then
            MsgBox("O campo deve ter o formato de data!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtcad_locao) Then
            MsgBox("O campo deve ter o formato de data!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If


        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("INSERT INTO LOCACAO VALUES (@CLIENTE_idCLIENTE, @AUTOMOVEL_idAUTOMOVEL,@KMINICIAL, @KMFINAL, @PRECOLOCACAO, @DTINICIALLOCACAO, @DTFINALLOCACAO, @DTCADLOCAO)", frmPrincipal.Conexao)

            MyCommand.Parameters.Add(New SqlParameter("@CLIENTE_idCLIENTE", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@AUTOMOVEL_idAUTOMOVEL", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@KMINICIAL", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@KMFINAL", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@PRECOLOCACAO", SqlDbType.Float))
            MyCommand.Parameters.Add(New SqlParameter("@DTINICIALLOCACAO", SqlDbType.Date))
            MyCommand.Parameters.Add(New SqlParameter("@DTFINALLOCACAO", SqlDbType.Date))
            MyCommand.Parameters.Add(New SqlParameter("@DTCADLOCAO", SqlDbType.Date))

            MyCommand.Parameters("@CLIENTE_idCLIENTE").Value = cliente_id_cliente
            MyCommand.Parameters("@AUTOMOVEL_idAUTOMOVEL").Value = automovel_id_automovel
            MyCommand.Parameters("@KMINICIAL").Value = km_inicial
            MyCommand.Parameters("@KMFINAL").Value = km_final
            MyCommand.Parameters("@PRECOLOCACAO").Value = preco_locacao
            MyCommand.Parameters("@DTINICIALLOCACAO").Value = dtinicial_locacao
            MyCommand.Parameters("@DTFINALLOCACAO").Value = dtfinal_locacao
            MyCommand.Parameters("@DTCADLOCAO").Value = dtcad_locao

            nReg = MyCommand.ExecuteNonQuery()

            If nReg > 0 Then
                MsgBox("Inserção realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar incluir dados da locação!", MsgBoxStyle.Critical)
        End Try

        Return retorno
    End Function

    Public Function Alterar() As Integer
        Dim retorno As Integer = 0

        If Not IsNumeric(id_locacao) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(cliente_id_cliente) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(automovel_id_automovel) Then
            MsgBox("O campo ID é composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(km_inicial) Then
            MsgBox("O campo KM INICIAL deve ser composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(km_final) Then
            MsgBox("O campo KM FINAL deve ser composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsNumeric(preco_locacao) Then
            MsgBox("O campo PREÇO deve ser composto apenas de números!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtinicial_locacao) Then
            MsgBox("O campo deve ter o formato de data!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtfinal_locacao) Then
            MsgBox("O campo deve ter o formato de data!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        If Not IsDate(dtcad_locao) Then
            MsgBox("O campo deve ter o formato de data!", MsgBoxStyle.Critical, "Atenção")
            Return retorno
            Exit Function
        End If

        Try
            Dim MyCommand As SqlCommand
            Dim nReg As Integer

            MyCommand = New SqlCommand("UPDATE LOCACAO SET CLIENTE_idCLIENTE = @CLIENTE_idCLIENTE,AUTOMOVEL_idAUTOMOVEL = @AUTOMOVEL_idAUTOMOVEL, KMINICIAL = @KMINICIAL, KMFINAL = @KMFINAL, PRECOLOCACAO = @PRECOLOCACAO, DTINICIALLOCACAO = @DTINICIALLOCACAO, DTFINALLOCACAO = @DTFINALLOCACAO, DTCADLOCAO = @DTCADLOCAO WHERE idLOCACAO = @idLOCACAO", frmPrincipal.Conexao)


            MyCommand.Parameters.Add(New SqlParameter("@CLIENTE_idCLIENTE", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@AUTOMOVEL_idAUTOMOVEL", SqlDbType.Int))
            MyCommand.Parameters.Add(New SqlParameter("@KMINICIAL", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@KMFINAL", SqlDbType.VarChar))
            MyCommand.Parameters.Add(New SqlParameter("@PRECOLOCACAO", SqlDbType.Float))
            MyCommand.Parameters.Add(New SqlParameter("@DTINICIALLOCACAO", SqlDbType.Date))
            MyCommand.Parameters.Add(New SqlParameter("@DTFINALLOCACAO", SqlDbType.Date))
            MyCommand.Parameters.Add(New SqlParameter("@DTCADLOCAO", SqlDbType.Date))
            MyCommand.Parameters.Add(New SqlParameter("@idLOCACAO", SqlDbType.Int))


            MyCommand.Parameters("@CLIENTE_idCLIENTE").Value = cliente_id_cliente
            MyCommand.Parameters("@AUTOMOVEL_idAUTOMOVEL").Value = automovel_id_automovel
            MyCommand.Parameters("@KMINICIAL").Value = km_inicial
            MyCommand.Parameters("@KMFINAL").Value = km_final
            MyCommand.Parameters("@PRECOLOCACAO").Value = preco_locacao
            MyCommand.Parameters("@DTINICIALLOCACAO").Value = dtinicial_locacao
            MyCommand.Parameters("@DTFINALLOCACAO").Value = dtfinal_locacao
            MyCommand.Parameters("@DTCADLOCAO").Value = dtcad_locao
            MyCommand.Parameters("@idLOCACAO").Value = id_locacao

            nReg = MyCommand.ExecuteNonQuery()

            If nReg > 0 Then
                MsgBox("Inserção realizada com sucesso!", MsgBoxStyle.Information, "Mensagem")
                retorno = nReg
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar alterar locação!", MsgBoxStyle.Critical)
        End Try

        Return retorno
    End Function

    Public Function Listar() As DataTable
        Dim daLocacao As SqlDataAdapter
        Dim dtLocacao As New DataTable()
        Try
            daLocacao = New SqlDataAdapter("SELECT * FROM LOCACAO", frmPrincipal.Conexao)
            daLocacao.Fill(dtLocacao)
            daLocacao.FillSchema(dtLocacao, SchemaType.Source)
        Catch ex As Exception
            MsgBox("Erro ao carregar Locação!!!")
        End Try
        Return dtLocacao
    End Function


    Public Function Excluir() As Integer
        Dim nReg As Integer = 0

        Try
            Dim MyCommand As SqlCommand

            MyCommand = New SqlCommand("DELETE FROM LOCACAO WHERE idLOCACAO=@idLOCACAO", frmPrincipal.Conexao)
            MyCommand.Parameters.Add(New SqlParameter("@idLOCACAO", SqlDbType.Int))
            MyCommand.Parameters("@idLOCACAO").Value = CInt(id_locacao)

            nReg = MyCommand.ExecuteNonQuery()
            If nReg > 0 Then
                MsgBox("Locação excluido com sucesso!", MsgBoxStyle.Information, "Mensagem")
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar excluir a locação!", MsgBoxStyle.Critical)
        End Try

        Return nReg
    End Function
End Class