using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace SistemaElectoral
{
    public partial class Votacion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null || Session["Rol"].ToString() != "Votante")
                {
                    Response.Redirect("NoAutorizado.aspx");
                }
                CargarCandidatos();
            }
        }

        private void CargarCandidatos()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand("SP_ObtenerTodosLosCandidatos", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    ddlCandidatos.DataSource = reader;
                    ddlCandidatos.DataTextField = "NombreCompleto"; // Cambiar esto a un campo concatenado de Nombre, Cargo y Partido
                    ddlCandidatos.DataValueField = "IdCandidato";
                    ddlCandidatos.DataBind();
                    reader.Close();
                }
            }
        }

        protected void btnVotar_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                int idVotante = Convert.ToInt32(Session["IdUsuario"]);
                int idCandidato = Convert.ToInt32(ddlCandidatos.SelectedValue);
                DateTime fechaVoto = DateTime.Now;

                if (!HaVotado(idVotante))
                {
                    string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                    using (SqlConnection conexion = new SqlConnection(conexionString))
                    {
                        using (SqlCommand comando = new SqlCommand("SP_InsertarVoto", conexion))
                        {
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.AddWithValue("@IdVotante", idVotante);
                            comando.Parameters.AddWithValue("@IdCandidato", idCandidato);
                            comando.Parameters.AddWithValue("@FechaVoto", fechaVoto);

                            conexion.Open();
                            try
                            {
                                comando.ExecuteNonQuery();
                                lblMensaje.Text = "Voto registrado exitosamente.";
                                lblMensaje.ForeColor = System.Drawing.Color.Green;
                            }
                            catch (SqlException ex)
                            {
                                lblMensaje.Text = "Error al registrar el voto: " + ex.Message;
                                lblMensaje.ForeColor = System.Drawing.Color.Red;
                            }
                            conexion.Close();
                        }
                    }
                }
                else
                {
                    lblMensaje.Text = "Ya has votado.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMensaje.Text = "Debes iniciar sesión para votar.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool HaVotado(int idVotante)
        {
            bool haVotado = false;

            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand("SP_VerificarVoto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdVotante", idVotante);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        haVotado = true;
                    }
                    reader.Close();
                }
            }

            return haVotado;
        }
    }
}
