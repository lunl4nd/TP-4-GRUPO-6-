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
    public partial class ejercicio3b : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhostData;Initial Catalog=Libreria;Integrated Security=True";
        private string consultaLibros = "SELECT IdLibro, IdTema, Titulo, Precio, Autor FROM Libros WHERE IdTema = @IdTema";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection conexion = new SqlConnection(cadenaConexion);
            }
        }
    }
}