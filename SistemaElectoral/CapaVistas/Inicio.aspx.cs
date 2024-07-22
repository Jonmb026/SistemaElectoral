using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaElectoral
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                VerificarConexionBaseDatos();
            }
        }

        private void VerificarConexionBaseDatos()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();
                    lblConexion.Text = "Conectado a la base de datos";
                    lblConexion.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception)
                {
                    lblConexion.Text = "No se encuentra conectado a la base de datos";
                    lblConexion.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
