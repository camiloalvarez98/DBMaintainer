Imports System.Windows.Forms
Imports Entidades
Imports Datos

Public Class ClsArticuloLn

    Dim objBDDArticulo As New BDDArticulo

#Region "Métodos públicos"

    Public Function Index() As DataSet
        Return objBDDArticulo.Index()
    End Function

    Public Function Consultar(ByVal objArticulo As ClsArticulo) As ClsArticulo
        Return objBDDArticulo.Consultar(objArticulo)
    End Function

    Public Sub Create(ByVal objArticulo As ClsArticulo)
        objBDDArticulo.Create(objArticulo)
    End Sub

    Public Sub Update(ByVal objArticulo As ClsArticulo)
        objBDDArticulo.Update(objArticulo)
    End Sub

    Public Function Read(ByVal objArticulo As ClsArticulo) As ClsArticulo
        Return objBDDArticulo.Read(objArticulo)
    End Function

    Public Sub Delete(ByVal objArticulo As ClsArticulo)
        objBDDArticulo.Delete(objArticulo)
    End Sub

#End Region

End Class
