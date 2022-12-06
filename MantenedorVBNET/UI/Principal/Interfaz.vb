Imports Entidades
Imports Negocio
Public Class Interfaz
    Private Sub Interfaz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarArticulos()
        Button2.Visible = False
        Label8.Visible = False
    End Sub


#Region "Botones"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim value As Integer = Nothing, value2 As Integer = Nothing, value3 As Integer = Nothing
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) OrElse String.IsNullOrEmpty(TextBox3.Text) OrElse String.IsNullOrEmpty(TextBox4.Text) Then
            MessageBox.Show("Rellene los campos de artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Integer.TryParse(TextBox3.Text.Trim(), value) AndAlso Integer.TryParse(TextBox2.Text.Trim(), value2) AndAlso Integer.TryParse(TextBox4.Text.Trim(), value3) Then
                Dim bodega As New ClsBodega()
                bodega.Codigo_Bodega = Convert.ToInt32(TextBox4.Text)
                Dim objBodegaLn = New ClsBodegaLn()
                Dim respuesta As Integer
                respuesta = objBodegaLn.ValidarBodega(bodega)
                If respuesta = 0 Then
                    MessageBox.Show("El código de bodega ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Else
                    Dim dialogResult As DialogResult = MessageBox.Show("Está a punto de crear el artículo " & TextBox1.Text & vbLf & "¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If dialogResult = DialogResult.Yes Then
                        Dim articulo As New ClsArticulo With {
                        .Descripcion = TextBox1.Text,
                        .Valor = Convert.ToInt32(TextBox2.Text),
                        .StockMinimo = Convert.ToInt32(TextBox3.Text),
                        .Codigo_Bodega = Convert.ToInt32(TextBox4.Text),
                        .Fecha_ingreso = DateTimePicker1.Value
                        }
                        Dim objArticuloLn = New ClsArticuloLn()
                        objArticuloLn.Create(articulo)
                        MessageBox.Show("El Articulo " + articulo.Descripcion + " fue ingresado correctamente", "Transacción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        ListarArticulos()
                    End If
                End If
            Else
                MessageBox.Show("Los campos Valor, Stock mínimo y Código deben ser valores numéricos (enteros)", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim value As Integer = Nothing, value2 As Integer = Nothing, value3 As Integer = Nothing
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) OrElse String.IsNullOrEmpty(TextBox3.Text) OrElse String.IsNullOrEmpty(TextBox4.Text) Then
            MessageBox.Show("Rellene los campos de artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Integer.TryParse(TextBox3.Text.Trim(), value) AndAlso Integer.TryParse(TextBox2.Text.Trim(), value2) AndAlso Integer.TryParse(TextBox4.Text.Trim(), value3) Then
                Dim bodega As New ClsBodega()
                bodega.Codigo_Bodega = Convert.ToInt32(TextBox4.Text)
                Dim objBodegaLn = New ClsBodegaLn()
                Dim respuesta As Integer
                respuesta = objBodegaLn.ValidarBodega(bodega)
                If respuesta = 0 Then
                    MessageBox.Show("El código de bodega ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Else
                    Dim dialogResult As DialogResult = MessageBox.Show("Está a punto de actualizar un artículo ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If dialogResult = DialogResult.Yes Then
                        Dim articulo As New ClsArticulo With {
                            .Codigo = Convert.ToInt32(Label8.Text),
                            .Descripcion = TextBox1.Text,
                            .Valor = Convert.ToInt32(TextBox2.Text),
                            .StockMinimo = Convert.ToInt32(TextBox3.Text),
                            .Codigo_Bodega = Convert.ToInt32(TextBox4.Text),
                            .Fecha_ingreso = DateTimePicker1.Value
                        }
                        Dim objArticuloLn = New ClsArticuloLn()
                        objArticuloLn.Update(articulo)
                        MessageBox.Show("El Artículo (Código: " & Label8.Text & ") fue actualizado correctamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        Button2.Visible = False
                        ListarArticulos()
                    End If
                End If
            Else
                MessageBox.Show("Los campos Valor, Stock mínimo y Código deben ser valores numéricos (enteros)", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim value As Integer = Nothing
        If String.IsNullOrEmpty(TextBox5.Text) Then
            MessageBox.Show("Rellene los campos de artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Integer.TryParse(TextBox5.Text.Trim(), value) Then
                Consultar()
            Else
                MessageBox.Show("El campo 'Código artículo' debe ser un valor numérico (entero)", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        End If
    End Sub


#End Region


#Region "Acciones"
    Private Sub Consultar()

        Dim articulo As New ClsArticulo()
        articulo.Codigo = Convert.ToInt32(TextBox5.Text)
        Dim objArticuloLn = New ClsArticuloLn()
        Dim articuloResp As New ClsArticulo()
        articuloResp = objArticuloLn.Consultar(articulo)
        If articuloResp Is Nothing Then
            MessageBox.Show("Articulo (Código: " & TextBox5.Text & ") no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox4.Clear()
        Else
            MessageBox.Show("Articulo " & articuloResp.Descripcion & " (Código: " + TextBox5.Text & ")" & vbLf & "Nombre bodega: " + articuloResp.Nombre_Bodega, "Consulta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox4.Clear()
        End If

    End Sub

    Private Sub ListarArticulos()
        Dim objNegocio As New ClsArticuloLn
        DataGridView1.DataSource = objNegocio.Index.Tables("Articulos")
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False


    End Sub

    Private Sub Eliminard(e As DataGridViewCellEventArgs)
        Dim articulo As New ClsArticulo
        Dim articuloResp As New ClsArticulo
        articulo.Codigo = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("Codigo").Value.ToString())
        Dim objArticuloLn As New ClsArticuloLn
        articuloResp = objArticuloLn.Read(articulo)
        Dim dialogResult As DialogResult = MessageBox.Show("¿Estás seguro de eliminar el artículo " & articuloResp.Descripcion & " (Código: " + articuloResp.Codigo.ToString() & ")?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If dialogResult = DialogResult.Yes Then
            objArticuloLn.Delete(articulo)
            MessageBox.Show("El Artículo (Código " + articulo.Codigo.ToString() + ") fue eliminado correctamente", "Transacción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ListarArticulos()
        End If
    End Sub

    Private Sub Cargar_Datos_Update(e As DataGridViewCellEventArgs)
        Dim articulo As New ClsArticulo
        articulo.Codigo = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("Codigo").Value.ToString())
        Label8.Text = articulo.Codigo.ToString()
        Dim objArticuloLn As New ClsArticuloLn
        Dim articuloResp As New ClsArticulo
        articuloResp = objArticuloLn.Read(articulo)
        TextBox1.Text = articuloResp.Descripcion.ToString()
        TextBox2.Text = articuloResp.Valor.ToString()
        TextBox3.Text = articuloResp.StockMinimo.ToString()
        TextBox4.Text = articuloResp.Codigo_Bodega.ToString()
        DateTimePicker1.Value = articuloResp.Fecha_ingreso

    End Sub

#End Region



#Region "DataSet"

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try

            If DataGridView1.Columns(e.ColumnIndex).Name = "Editar" Then
                Button2.Visible = True
                Cargar_Datos_Update(e)
            ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Eliminar" Then
                Eliminard(e)

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region






End Class
