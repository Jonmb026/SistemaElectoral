using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Clsusuario
{
    private string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

    public void InsertarUsuario(string nombreUsuario, string contraseña, string nombreCompleto, string primerApellido, string segundoApellido, string correoElectronico, string telefono, string provincia, string rol)
    {
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
                conexion.Close();
            }
        }
    }

    public void ActualizarUsuario(int idUsuario, string nombreUsuario, string contraseña, string nombreCompleto, string primerApellido, string segundoApellido, string correoElectronico, string telefono, string provincia, string rol)
    {
        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_ActualizarUsuario", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
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
                conexion.Close();
            }
        }
    }

    public void EliminarUsuario(int idUsuario)
    {
        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_EliminarUsuario", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }

    public DataTable ObtenerUsuarioPorId(int idUsuario)
    {
        DataTable dtUsuario = new DataTable();

        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_ObtenerUsuarioPorId", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(comando))
                {
                    da.Fill(dtUsuario);
                }
                conexion.Close();
            }
        }

        return dtUsuario;
    }

    public DataTable ObtenerTodosLosUsuarios()
    {
        DataTable dtUsuarios = new DataTable();

        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_ObtenerTodosLosUsuarios", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(comando))
                {
                    da.Fill(dtUsuarios);
                }
                conexion.Close();
            }
        }

        return dtUsuarios;
    }
}
