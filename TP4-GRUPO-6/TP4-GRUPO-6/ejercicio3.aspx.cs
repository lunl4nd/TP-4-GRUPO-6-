using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP4_GRUPO_6
{
   
    public partial class ejercicio3 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=localhostData;Initial Catalog=Libreria;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
            }
        }

        protected void verlibros_Click(object sender, EventArgs e)
        {
            Server.Transfer("ejercicio3b.aspx");
        }
    }
}