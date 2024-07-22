using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Clspermiso
{
    private string conexionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

    // Método para verificar permisos
    public bool VerificarPermiso(string usuario, string permiso)
    {
        bool tienePermiso = false;

        using (SqlConnection conexion = new SqlConnection(conexionString))
        {
            using (SqlCommand comando = new SqlCommand("SP_VerificarPermiso", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Permiso", permiso);

                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    tienePermiso = true;
                }

                reader.Close();
            }
        }

        return tienePermiso;
    }
}
