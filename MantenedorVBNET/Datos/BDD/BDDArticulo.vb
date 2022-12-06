Imports System.Data.SqlClient
Imports Entidades

Public Class BDDArticulo

    Dim objConexion As New Conexion
    Dim data As SqlDataAdapter
    Dim conexion As SqlConnection

#Region "Métodos públicos"

    'Método Index
    Public Function Index() As DataSet

        conexion = objConexion.Conectar
        data = New SqlDataAdapter("dbo.SP_Articulo_Index", conexion)
        Dim dataset As New DataSet
        data.Fill(dataset, "Articulos")
        Return dataset

    End Function

    Public Sub Create(ByVal objArticulo As ClsArticulo)

        conexion = objConexion.Conectar
        conexion.Open()
        data = New SqlDataAdapter("dbo.SP_Articulo_Create", conexion)
        data.SelectCommand.CommandType = CommandType.StoredProcedure
        With data.SelectCommand.Parameters
            .Add("@Descripcion", SqlDbType.VarChar).Value = objArticulo.Descripcion
            .Add("@Valor", SqlDbType.Int).Value = objArticulo.Valor
            .Add("@StockMinimo", SqlDbType.Int).Value = objArticulo.StockMinimo
            .Add("@Codigo_Bodega", SqlDbType.Int).Value = objArticulo.Codigo_Bodega
            .Add("@Fecha_Ingreso", SqlDbType.DateTime).Value = objArticulo.Fecha_ingreso
        End With
        data.SelectCommand.ExecuteNonQuery()

    End Sub

    Public Function Consultar(ByVal objArticulo As ClsArticulo) As ClsArticulo
        conexion = objConexion.Conectar
        conexion.Open()
        data = New SqlDataAdapter("dbo.SP_Articulo_Consultar", conexion)
        data.SelectCommand.CommandType = CommandType.StoredProcedure
        With data.SelectCommand.Parameters
            .Add("@Codigo", SqlDbType.Int).Value = objArticulo.Codigo
        End With
        Dim tabla As New DataTable()
        data.Fill(tabla)
        If tabla.Rows.Count() > 0 Then
            Dim articuloResp As New ClsArticulo With {
            .Descripcion = tabla.Rows(0)(0).ToString(),
            .Nombre_Bodega = tabla.Rows(0)(1).ToString()
            }
            Return articuloResp
        Else
            Return Nothing
        End If


    End Function

    Public Sub Update(ByVal objArticulo As ClsArticulo)

        conexion = objConexion.Conectar
        conexion.Open()
        data = New SqlDataAdapter("dbo.SP_Articulo_Update", conexion)
        data.SelectCommand.CommandType = CommandType.StoredProcedure
        With data.SelectCommand.Parameters
            .Add("@Codigo", SqlDbType.Int).Value = objArticulo.Codigo
            .Add("@Descripcion", SqlDbType.VarChar).Value = objArticulo.Descripcion
            .Add("@Valor", SqlDbType.Int).Value = objArticulo.Valor
            .Add("@StockMinimo", SqlDbType.Int).Value = objArticulo.StockMinimo
            .Add("@Codigo_Bodega", SqlDbType.Int).Value = objArticulo.Codigo_Bodega
            .Add("@Fecha_Ingreso", SqlDbType.DateTime).Value = objArticulo.Fecha_ingreso
        End With
        data.SelectCommand.ExecuteNonQuery()

    End Sub

    Public Function Read(ByVal objArticulo As ClsArticulo) As ClsArticulo
        conexion = objConexion.Conectar
        conexion.Open()
        data = New SqlDataAdapter("dbo.SP_Articulo_Read", conexion)
        data.SelectCommand.CommandType = CommandType.StoredProcedure
        With data.SelectCommand.Parameters
            .Add("@Codigo", SqlDbType.Int).Value = objArticulo.Codigo
        End With
        Dim tabla As New DataTable()
        data.Fill(tabla)
        Dim articulo As New ClsArticulo With {
            .Codigo = tabla.Rows(0)(0).ToString(),
            .Descripcion = tabla.Rows(0)(1).ToString(),
            .Fecha_ingreso = tabla.Rows(0)(2).ToString(),
            .Valor = tabla.Rows(0)(3).ToString(),
            .StockMinimo = tabla.Rows(0)(4).ToString(),
            .Codigo_Bodega = tabla.Rows(0)(5).ToString()
        }
        Return articulo
    End Function

    Public Sub Delete(ByVal objArticulo As ClsArticulo)
        conexion = objConexion.Conectar
        conexion.Open()
        data = New SqlDataAdapter("dbo.SP_Articulo_Delete", conexion)
        data.SelectCommand.CommandType = CommandType.StoredProcedure
        With data.SelectCommand.Parameters
            .Add("@Codigo", SqlDbType.Int).Value = objArticulo.Codigo
        End With
        data.SelectCommand.ExecuteNonQuery()
    End Sub

#End Region

End Class
