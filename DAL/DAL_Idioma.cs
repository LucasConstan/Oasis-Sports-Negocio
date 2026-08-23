using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Idioma
    {
        public List<Idioma> Listar()
        {
            var lista = new List<Idioma>();

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT IdIdioma, Nombre FROM Idioma";
            SqlCommand cmd = new SqlCommand(query, cn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Idioma
                    {
                        IdIdioma = (int)reader["IdIdioma"],
                        Nombre = reader["Nombre"].ToString()!
                    });
                }
            }

            cn.Close();
            return lista;
        }

        public void Agregar(Idioma idioma)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "INSERT INTO Idioma (Nombre) VALUES (@Nombre)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Nombre", idioma.Nombre);
            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}
