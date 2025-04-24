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
        private const string cadenaconexion = @"Data Source=DESKTOP-HP1QFPI\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;Encrypt=False";
        //En la parte de "data source" hay que cambiar el desktop. El que está es de la pc. Si alguno sabe cómo globalizarlo, sería de gran ayuda.
        private const string consulta = "SELECT * FROM Provincias";
        private const string consulta2 = "SELECT * FROM Localidades";
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

                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(consulta2, connection);
                DataSet dataSet2 = new DataSet();
                dataAdapter2.Fill(dataSet2, "Tabla Localidades");
                
                foreach (DataRow datarow2 in dataSet2.Tables["Tabla Localidades"].Rows)
                {
                    ddlLocalidadInicio.Items.Add(datarow2["IdLocalidad"] + "- " + datarow2["NombreLocalidad"]);
                }
                connection.Close();
            }
        }
    }
}