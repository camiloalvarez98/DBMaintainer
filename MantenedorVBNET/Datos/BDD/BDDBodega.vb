Imports System.Data.SqlClient
Imports Entidades

Public Class BDDBodega

    Dim objConexion As New Conexion
    Dim data As SqlDataAdapter
    Dim conexion As SqlConnection

#Region "Métodos públicos"

    Public Function ValidarBodega(ByVal objBodega As ClsBodega) As Integer

        conexion = objConexion.Conectar
        conexion.Open()
        data = New SqlDataAdapter("dbo.SP_Bodega_ValidarBodega", conexion)
        data.SelectCommand.CommandType = CommandType.StoredProcedure
        With data.SelectCommand.Parameters
            .Add("@Codigo_Bodega", SqlDbType.Int).Value = objBodega.Codigo_Bodega
        End With
        Dim codigo_bodega As Integer
        codigo_bodega = data.SelectCommand.ExecuteScalar
        Return codigo_bodega

    End Function

#End Region

End Class
