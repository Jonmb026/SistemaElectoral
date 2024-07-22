using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace SistemaElectoral
{
    public partial class Resultados : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResultados();
            }
        }

        private void CargarResultados()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand("SP_ObtenerResultados", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    gvResultados.DataSource = reader;
                    gvResultados.DataBind();
                    reader.Close();
                }
            }
        }

        protected void btnResultadoFinal_Click(object sender, EventArgs e)
        {
            if (Session["Rol"] != null && Session["Rol"].ToString() == "Admin")
            {
                ObtenerGanador();
            }
            else
            {
                lblGanador.Text = "No tienes permiso para ver el resultado final.";
                lblGanador.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ObtenerGanador()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand("SP_ObtenerGanador", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        string nombreGanador = reader["NombreCompleto"].ToString();
                        string porcentajeVotos = reader["PorcentajeVotos"].ToString();
                        lblGanador.Text = $"El ganador de las elecciones es {nombreGanador} con el {porcentajeVotos}% de los votos. ¡Felicidades al nuevo presidente!";
                        lblGanador.ForeColor = System.Drawing.Color.Green;
                    }
                    reader.Close();
                }
            }
        }
    }
}
