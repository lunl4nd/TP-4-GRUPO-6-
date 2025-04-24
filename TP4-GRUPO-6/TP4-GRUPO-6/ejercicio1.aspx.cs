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
    public partial class ejercicio1 : System.Web.UI.Page
    {
        private const string cadenaconexion = @"Data Source=DESKTOP-H5DSIS0\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        //En la parte de "data source" hay que cambiar el desktop. El que está es de la pc. Si alguno sabe cómo globalizarlo, sería de gran ayuda.
        private const string consulta = "SELECT * FROM Provincias";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(cadenaconexion);
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, connection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Tabla Provincias");

                foreach (DataRow datarow in dataSet.Tables["Tabla Provincias"].Rows)
                {
                    listaprovinicio.Items.Add(datarow["IdProvincia"] + "- " + datarow["NombreProvincia"]);
                }
            }
        }
    }
}