Imports Entidades
Imports Datos

Public Class ClsBodegaLn

    Dim objBDDBodega As New BDDBodega

#Region "Métodos públicos"

    Public Function ValidarBodega(ByVal objBodega As ClsBodega)
        Return objBDDBodega.ValidarBodega(objBodega)
    End Function

#End Region

End Class
