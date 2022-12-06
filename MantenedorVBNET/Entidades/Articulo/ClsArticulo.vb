Public Class ClsArticulo

#Region "Variables privadas"
    Private _codigo, _valor, _stockMinimo, _codigo_Bodega As Integer
    Private _descripcion, _nombre_Bodega As String
    Private _fecha_ingreso As DateTime
    'atributos de manejo de la base de datos

#End Region

#Region "Constructor"

    Public Sub New()

    End Sub
#End Region


#Region "Variables públicas"

    Public Property Codigo As Integer
        Get
            Return _codigo
        End Get
        Set(value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property Valor As Integer
        Get
            Return _valor
        End Get
        Set(value As Integer)
            _valor = value
        End Set
    End Property

    Public Property StockMinimo As Integer
        Get
            Return _stockMinimo
        End Get
        Set(value As Integer)
            _stockMinimo = value
        End Set
    End Property

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

    Public Property Nombre_Bodega As String
        Get
            Return _nombre_Bodega
        End Get
        Set(value As String)
            _nombre_Bodega = value
        End Set
    End Property

    Public Property Fecha_ingreso As Date
        Get
            Return _fecha_ingreso
        End Get
        Set(value As Date)
            _fecha_ingreso = value
        End Set
    End Property


#End Region
End Class
