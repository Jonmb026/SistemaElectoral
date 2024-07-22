using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SistemaElectoral
{
    public partial class RegistrarCandidato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null || Session["Rol"].ToString() != "Admin")
                {
                    Response.Redirect("NoAutorizado.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (EsCandidatoUnico(txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text))
            {
                Clscandidato candidato = new Clscandidato();
                candidato.InsertarCandidato(txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtPartidoPolitico.Text, txtPlataforma.Text, ddlCargo.SelectedValue, ddlProvincia.SelectedValue);
                lblMensaje.Text = "Candidato registrado exitosamente.";
            }
            else
            {
                lblMensaje.Text = "El candidato ya está registrado.";
            }
        }

        private bool EsCandidatoUnico(string nombre, string primerApellido, string segundoApellido)
        {
            bool esUnico = true;

            string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand("SP_VerificarCandidatoUnico", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@PrimerApellido", primerApellido);
                    comando.Parameters.AddWithValue("@SegundoApellido", segundoApellido);

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
    }
}
