using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Traduccion
    {
        public List<Traduccion> ObtenerPorIdioma(int idIdioma)
        {
            var lista = new List<Traduccion>();

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT IdTraduccion, IdIdioma, Clave, Texto FROM Traduccion WHERE IdIdioma = @IdIdioma";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@IdIdioma", idIdioma);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Traduccion
                    {
                        IdTraduccion = (int)reader["IdTraduccion"],
                        IdIdioma     = (int)reader["IdIdioma"],
                        Clave        = reader["Clave"].ToString()!,
                        Texto        = reader["Texto"].ToString()!
                    });
                }
            }

            cn.Close();
            return lista;
        }

        public List<string> ObtenerTodasLasClaves()
        {
            var lista = new List<string>();

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT DISTINCT Clave FROM Traduccion ORDER BY Clave";
            SqlCommand cmd = new SqlCommand(query, cn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    lista.Add(reader["Clave"].ToString()!);
            }

            cn.Close();
            return lista;
        }

        public void GuardarOActualizar(Traduccion traduccion)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string queryCheck = "SELECT COUNT(*) FROM Traduccion WHERE IdIdioma = @IdIdioma AND Clave = @Clave";
            SqlCommand cmdCheck = new SqlCommand(queryCheck, cn);
            cmdCheck.Parameters.AddWithValue("@IdIdioma", traduccion.IdIdioma);
            cmdCheck.Parameters.AddWithValue("@Clave", traduccion.Clave);
            int existe = (int)cmdCheck.ExecuteScalar()!;

            if (existe > 0)
            {
                string queryUpdate = "UPDATE Traduccion SET Texto = @Texto WHERE IdIdioma = @IdIdioma AND Clave = @Clave";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, cn);
                cmdUpdate.Parameters.AddWithValue("@Texto", traduccion.Texto);
                cmdUpdate.Parameters.AddWithValue("@IdIdioma", traduccion.IdIdioma);
                cmdUpdate.Parameters.AddWithValue("@Clave", traduccion.Clave);
                cmdUpdate.ExecuteNonQuery();
            }
            else
            {
                string queryInsert = "INSERT INTO Traduccion (IdIdioma, Clave, Texto) VALUES (@IdIdioma, @Clave, @Texto)";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, cn);
                cmdInsert.Parameters.AddWithValue("@IdIdioma", traduccion.IdIdioma);
                cmdInsert.Parameters.AddWithValue("@Clave", traduccion.Clave);
                cmdInsert.Parameters.AddWithValue("@Texto", traduccion.Texto);
                cmdInsert.ExecuteNonQuery();
            }

            cn.Close();
        }
    }
}
