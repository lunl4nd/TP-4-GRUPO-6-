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
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    string consultaLibros = "SELECT IdLibro, IdTema, Titulo, Precio, Autor FROM Libros WHERE IdTema = @IdTema";
                    conexion.Open();
                    
                    int idTema = Convert.ToInt32(((DropDownList)PreviousPage.FindControl("ddlTemas")).SelectedValue);
                    SqlCommand comando = new SqlCommand(consultaLibros, conexion);
                    comando.Parameters.AddWithValue("@IdTema", idTema);

                    SqlDataReader temaReader = comando.ExecuteReader();

                    gvTema.DataSource = temaReader;
                    gvTema.DataBind();
                }
                
            }
        }

        protected void lbOtroTema_Click(object sender, EventArgs e)
        {
            Server.Transfer("ejercicio3.aspx");
            
        }
    }
}