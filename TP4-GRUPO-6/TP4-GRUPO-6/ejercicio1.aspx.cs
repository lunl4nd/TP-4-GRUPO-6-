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
        private const string cadenaconexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        //Ya no hace falta cambiar el desktop, ya que usamos localhost.
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

                listaProvinciaInicio.Items.Insert(0, "--Selecciona una provincia--");

                provinciasReader.Close();

                listaLocalidadesInicio.Items.Insert(0,"--Primero seleccione una provincia--");
                connection.Close();
            }
        }

        protected void listaProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {

            int provinciaSeleccionada;
            if (!int.TryParse(listaProvinciaInicio.SelectedValue, out provinciaSeleccionada))
            {
                listaLocalidadesInicio.Items.Clear();
                listaLocalidadesInicio.Items.Insert(0, "--Primero seleccione una provincia--");
                return;
            }

            SqlConnection connection = new SqlConnection(cadenaconexion);
            connection.Open();
            SqlCommand comando = new SqlCommand(consultaLocalidades,connection);
            SqlDataReader localidadesReader = comando.ExecuteReader();
            listaLocalidadesInicio.Items.Clear();
            listaLocalidadesInicio.Items.Insert(0,"--Seleccione una localidad--");
            while(localidadesReader.Read())
            {
                int idProvincia = (int)localidadesReader["IdProvincia"];
                if(provinciaSeleccionada == idProvincia)
                {
                    string nombreLocalidad = localidadesReader["NombreLocalidad"].ToString();
                    string IdLocalidad = localidadesReader["IdLocalidad"].ToString();

                    listaLocalidadesInicio.Items.Add(IdLocalidad + "- " + nombreLocalidad);
                }

            }
        }
    }
}