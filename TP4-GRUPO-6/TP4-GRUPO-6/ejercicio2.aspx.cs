﻿using System;
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
        int maxIdProductos, maxIdCategoria;
        
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
                    productosReader.Close();

                    //Obtener los valores maximos de IdProductos 
                    SqlCommand comandoIdProductos = new SqlCommand("SELECT MAX(IdProducto) FROM Productos", conexion);  
                    maxIdProductos = (int)comandoIdProductos.ExecuteScalar();
                    RVProductos.MaximumValue = maxIdProductos.ToString();
                    //Se utiliza el .ToString() porque esa variable solo permite strings
                    RVProductos.ErrorMessage = "Solo se permiten IDs del " + RVProductos.MinimumValue + " al " + RVProductos.MaximumValue;

                    //Obtener los valores maximos de IdCategoria
                    SqlCommand comandoIdCategoria = new SqlCommand("SELECT MAX(IdCategoría) FROM Productos", conexion);
                    maxIdCategoria = (int)comandoIdCategoria.ExecuteScalar();
                    RVCategoria.MaximumValue = maxIdCategoria.ToString();
                    //Se utiliza el .ToString() porque esa variable solo permite strings
                    RVCategoria.ErrorMessage = "Solo se permiten IDs del " + RVCategoria.MinimumValue + " al " + RVCategoria.MaximumValue;

                    conexion.Close();
                }
            }
        }

        protected void filtrar_Click(object sender, EventArgs e)
        {
            lblSinResultados.Visible = false;
            int idProductoSeleccionado;
            int idCategoriaSeleccionada;

            string operacionProducto = "";
            string operacionCategoria = "";

            switch (int.Parse(ddlProducto.SelectedValue))
            {
                case 0:
                    operacionProducto = "=";
                    break;
                case 1:
                    operacionProducto = ">";
                    break;
                case 2:
                    operacionProducto = "<";
                    break;
            }

            switch (int.Parse(ddlCategoria.SelectedValue))
            {
                case 0:
                    operacionCategoria = "=";
                    break;
                case 1:
                    operacionCategoria = ">";
                    break;
                case 2:
                    operacionCategoria = "<";
                    break;
            }


            if (int.TryParse(txtProducto.Text, out idProductoSeleccionado))
            {
                string filtradoPorIdProducto = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad FROM Productos WHERE IdProducto " + operacionProducto + " @IdProducto";
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
                string filtradoPorIdCategoria = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad FROM Productos WHERE IdCategoría " + operacionCategoria +" @IdCategoria";

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
                string filtradoPorIdCategoria = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad FROM Productos WHERE IdProducto " + operacionProducto + " @IdProducto AND IdCategoría " + operacionCategoria +" @IdCategoria";

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(filtradoPorIdCategoria, conexion);
                    comando.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado);
                    comando.Parameters.AddWithValue("@IdCategoria", idCategoriaSeleccionada);

                    SqlDataReader productosReader = comando.ExecuteReader();

                    grillaProductos.DataSource = productosReader;
                    grillaProductos.DataBind();
                }
            }
            if (string.IsNullOrWhiteSpace(txtProducto.Text) && string.IsNullOrWhiteSpace(txtCategoria.Text))
            {

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string traertodo = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";
                    SqlCommand comando = new SqlCommand(traertodo, conexion);

                    SqlDataReader productosReader = comando.ExecuteReader();
                    grillaProductos.DataSource = productosReader;
                    grillaProductos.DataBind();
                    
                    productosReader.Close();
                    conexion.Close();
                }
                
            }
                if (grillaProductos.Rows.Count == 0)
                    lblSinResultados.Visible = true;
                txtCategoria.Text = "";
                txtProducto.Text = "";
        }

        protected void quitarFiltro_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            SqlCommand command = new SqlCommand(consultaProductos, conexion);
            SqlDataReader productosReader = command.ExecuteReader();
            grillaProductos.DataSource = productosReader;
            grillaProductos.DataBind();
            productosReader.Close();
            conexion.Close();
        }
    }
}