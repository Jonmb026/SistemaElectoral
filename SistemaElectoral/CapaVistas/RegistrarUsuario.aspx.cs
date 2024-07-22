using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SistemaElectoral
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerificarConexionBaseDatos();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == txtConfirmarContraseña.Text)
            {
                if (EsUsuarioUnico(txtNombreUsuario.Text, txtCorreoElectronico.Text))
                {
                    InsertarUsuario(txtNombreUsuario.Text, txtContraseña.Text, txtNombreCompleto.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtCorreoElectronico.Text, txtTelefono.Text, ddlProvincia.SelectedValue, ddlRol.SelectedValue);
                    lblMensaje.Text = "Usuario registrado exitosamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "El nombre de usuario o correo electrónico ya están en uso.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool EsUsuarioUnico(string nombreUsuario, string correoElectronico)
        {
            bool esUnico = true;

            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand("SP_VerificarUsuarioUnico", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        esUnico = false;
                    }
                    reader.Close();
                }
            }

            return esUnico;
        }

        private void InsertarUsuario(string nombreUsuario, string contraseña, string nombreCompleto, string primerApellido, string segundoApellido, string correoElectronico, string telefono, string provincia, string rol)
        {
            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand("SP_InsertarUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);
                    comando.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                    comando.Parameters.AddWithValue("@PrimerApellido", primerApellido);
                    comando.Parameters.AddWithValue("@SegundoApellido", segundoApellido);
                    comando.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@Provincia", provincia);
                    comando.Parameters.AddWithValue("@Rol", rol);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
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
