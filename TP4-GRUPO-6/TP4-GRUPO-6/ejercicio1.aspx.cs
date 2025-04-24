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
        private const string cadenaconexion = @"Data Source=DESKTOP-AI58QHE\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        //En la parte de "data source" hay que cambiar el desktop. El que está es de la pc. Si alguno sabe cómo globalizarlo, sería de gran ayuda.
        private const string consultaProvincias = "SELECT * FROM Provincias";
        private const string consultaLocalidades = "SELECT * FROM Localidades";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(cadenaconexion);
                connection.Open();

                SqlCommand comando = new SqlCommand(consultaProvincias,connection);
                SqlDataReader provinciasReader = comando.ExecuteReader();

                listaProvinciaInicio.DataSource = provinciasReader;
                listaProvinciaInicio.DataTextField = "NombreProvincia";
                listaProvinciaInicio.DataValueField = "IdProvincia";
                listaProvinciaInicio.DataBind();

                provinciasReader.Close();
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(consultaLocalidades, connection);
                DataSet dataSet2 = new DataSet();
                dataAdapter2.Fill(dataSet2, "Tabla Localidades");

                foreach (DataRow datarow2 in dataSet2.Tables["Tabla Localidades"].Rows)
                {
                    listaLocalidadesInicio.Items.Add(Convert.ToString(datarow2["NombreLocalidad"]));
                }



                connection.Close();
            }
        }

        
    }
}