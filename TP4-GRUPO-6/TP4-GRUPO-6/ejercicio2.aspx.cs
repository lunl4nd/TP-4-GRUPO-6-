using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP4_GRUPO_6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";
        private const string consultaProductos = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(consultaProductos, conexion);
                    SqlDataReader productosReader = comando.ExecuteReader();
                    grillaProductos.DataSource = productosReader;
                    grillaProductos.DataBind();

                }   
            }
        }

        protected void filtrar_Click(object sender, EventArgs e)
        {
            int idProductoSeleccionado;
            int idCategoriaSeleccionada;

            if (int.TryParse(txtProducto.Text,out idProductoSeleccionado))
            {
                string filtradoPorIdProducto = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad FROM Productos WHERE IdProducto = @IdProducto";
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(filtradoPorIdProducto, conexion);
                    comando.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado);

                    SqlDataReader productosReader = comando.ExecuteReader();

                    grillaProductos.DataSource = productosReader;
                    grillaProductos.DataBind();
                }
            }

            if (int.TryParse(txtCategoria.Text, out idCategoriaSeleccionada))
            {
                string filtradoPorIdCategoria = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad FROM Productos WHERE IdCategoría = @IdCategoria";

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(filtradoPorIdCategoria, conexion);
                    comando.Parameters.AddWithValue("@IdCategoria", idCategoriaSeleccionada);

                    SqlDataReader productosReader = comando.ExecuteReader();

                    grillaProductos.DataSource = productosReader;
                    grillaProductos.DataBind();
                }
            }

            if (int.TryParse(txtProducto.Text, out idProductoSeleccionado) && int.TryParse(txtCategoria.Text, out idCategoriaSeleccionada))
            {
                string filtradoPorIds= "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad FROM Productos WHERE IdProducto = @IdProducto AND IdCategoría = @IdCategoria";

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(filtradoPorIds, conexion);
                    comando.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado);
                    comando.Parameters.AddWithValue("@IdCategoria", idCategoriaSeleccionada);

                    SqlDataReader productosReader = comando.ExecuteReader();

                    grillaProductos.DataSource = productosReader;
                    grillaProductos.DataBind();
                }
            }
        }
    }
}