using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Clscandidato
{
    private string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

    public void InsertarCandidato(string nombre, string primerApellido, string segundoApellido, string partidoPolitico, string plataforma, string cargo, string provincia)
    {
        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_InsertarCandidato", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@PrimerApellido", primerApellido);
                comando.Parameters.AddWithValue("@SegundoApellido", segundoApellido);
                comando.Parameters.AddWithValue("@PartidoPolitico", partidoPolitico);
                comando.Parameters.AddWithValue("@Plataforma", plataforma);
                comando.Parameters.AddWithValue("@Cargo", cargo);
                comando.Parameters.AddWithValue("@Provincia", provincia);

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }

    public void ActualizarCandidato(int idCandidato, string nombre, string primerApellido, string segundoApellido, string partidoPolitico, string plataforma, string cargo, string provincia)
    {
        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_ActualizarCandidato", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCandidato", idCandidato);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@PrimerApellido", primerApellido);
                comando.Parameters.AddWithValue("@SegundoApellido", segundoApellido);
                comando.Parameters.AddWithValue("@PartidoPolitico", partidoPolitico);
                comando.Parameters.AddWithValue("@Plataforma", plataforma);
                comando.Parameters.AddWithValue("@Cargo", cargo);
                comando.Parameters.AddWithValue("@Provincia", provincia);

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }

    public void EliminarCandidato(int idCandidato)
    {
        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_EliminarCandidato", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCandidato", idCandidato);

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }

    public DataTable ObtenerCandidatoPorId(int idCandidato)
    {
        DataTable dtCandidato = new DataTable();

        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_ObtenerCandidatoPorId", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCandidato", idCandidato);

                conexion.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(comando))
                {
                    da.Fill(dtCandidato);
                }
                conexion.Close();
            }
        }

        return dtCandidato;
    }

    public DataTable ObtenerTodosLosCandidatos()
    {
        DataTable dtCandidatos = new DataTable();

        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_ObtenerTodosLosCandidatos", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(comando))
                {
                    da.Fill(dtCandidatos);
                }
                conexion.Close();
            }
        }

        return dtCandidatos;
    }
}
