using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace SistemaElectoral
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar conexión a la base de datos
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                string query = "SP_ObtenerUsuarioPorNombreYContraseña";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreUsuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Session["Usuario"] = reader["NombreUsuario"].ToString();
                        Session["IdUsuario"] = reader["IdUsuario"].ToString();
                        Session["Rol"] = reader["Rol"].ToString();
                        Response.Redirect("Inicio.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    }
                    reader.Close();
                }
            }
        }
    }
}
