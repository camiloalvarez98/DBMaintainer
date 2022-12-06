Public Class ClsBodega

#Region "Variables privadas"

    Private _codigo_Bodega As Integer
    Private _descripcion As String

#End Region

#Region "Constructor"

    Public Sub New()

    End Sub

#End Region


#Region "Variables públicas"

    Public Property Codigo_Bodega As Integer
        Get
            Return _codigo_Bodega
        End Get
        Set(value As Integer)
            _codigo_Bodega = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
#End Region

End Class
