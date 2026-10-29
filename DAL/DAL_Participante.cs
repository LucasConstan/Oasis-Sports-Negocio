using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Participante
    {
        public List<Participante> Listar_348LC()
        {
            List<Participante> lista_348LC = new List<Participante>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Participante, DNI, Nombre, Apellido, Edad, Telefono, Direccion, Eliminado FROM Participantes WHERE Eliminado = 0";

            SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC);
            try
            {
                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Participante()
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Participante"]),
                            DNI = reader_348LC["DNI"].ToString(),
                            Nombre = reader_348LC["Nombre"].ToString(),
                            Apellido = reader_348LC["Apellido"].ToString(),
                            Edad = Convert.ToInt32(reader_348LC["Edad"]),
                            Telefono = reader_348LC["Telefono"].ToString(),
                            Direccion = reader_348LC["Direccion"] == DBNull.Value ? "" : reader_348LC["Direccion"].ToString(),
                            Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                        });
                    }
                }
            }
            catch (Exception ex_348LC)
            {
                System.Console.WriteLine("Error en la búsqueda: " + ex_348LC.Message);
            }

            return lista_348LC;
        }

        public int AñadirParticipante_348LC(Participante participante_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Participantes (DNI, Nombre, Apellido, Edad, Telefono, Direccion)
             VALUES (@DNI, @Nombre, @Apellido, @Edad, @Telefono, @Direccion);
             SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@DNI", participante_348LC.DNI);
                cmd_348LC.Parameters.AddWithValue("@Nombre", participante_348LC.Nombre);
                cmd_348LC.Parameters.AddWithValue("@Apellido", participante_348LC.Apellido);
                cmd_348LC.Parameters.AddWithValue("@Edad", participante_348LC.Edad);
                cmd_348LC.Parameters.AddWithValue("@Telefono", participante_348LC.Telefono);
                cmd_348LC.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(participante_348LC.Direccion) ? (object)DBNull.Value : participante_348LC.Direccion);

                return (int)cmd_348LC.ExecuteScalar();
            }
        }

        public void EliminarParticipante_348LC(int idParticipante_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Participantes SET Eliminado = 1 WHERE Id_Participante = @Id_Participante";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Participante", idParticipante_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ModificarParticipante_348LC(int idParticipante_348LC, Participante participante_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Participantes
                     SET DNI = @DNI,
                         Nombre = @Nombre,
                         Apellido = @Apellido,
                         Edad = @Edad,
                         Telefono = @Telefono,
                         Direccion = @Direccion
                     WHERE Id_Participante = @Id_Participante";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Participante", idParticipante_348LC);
                cmd_348LC.Parameters.AddWithValue("@DNI", participante_348LC.DNI);
                cmd_348LC.Parameters.AddWithValue("@Nombre", participante_348LC.Nombre);
                cmd_348LC.Parameters.AddWithValue("@Apellido", participante_348LC.Apellido);
                cmd_348LC.Parameters.AddWithValue("@Edad", participante_348LC.Edad);
                cmd_348LC.Parameters.AddWithValue("@Telefono", participante_348LC.Telefono);
                cmd_348LC.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(participante_348LC.Direccion) ? (object)DBNull.Value : participante_348LC.Direccion);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public Participante ObtenerPorId_348LC(int idParticipante_348LC)
        {
            Participante participante_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Participante, DNI, Nombre, Apellido, Edad, Telefono, Direccion, Eliminado
                         FROM Participantes WHERE Id_Participante = @Id_Participante";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Participante", idParticipante_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            participante_348LC = new Participante
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Participante"]),
                                DNI = reader_348LC["DNI"].ToString(),
                                Nombre = reader_348LC["Nombre"].ToString(),
                                Apellido = reader_348LC["Apellido"].ToString(),
                                Edad = Convert.ToInt32(reader_348LC["Edad"]),
                                Telefono = reader_348LC["Telefono"].ToString(),
                                Direccion = reader_348LC["Direccion"] == DBNull.Value ? "" : reader_348LC["Direccion"].ToString(),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return participante_348LC;
        }

        public List<Participante> ObtenerTodosParaVerificar_348LC()
        {
            List<Participante> lista_348LC = new List<Participante>();
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Participante, DNI, Nombre, Apellido, Edad, Telefono, Direccion, Eliminado, DVH FROM Participantes";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
            {
                while (reader_348LC.Read())
                {
                    lista_348LC.Add(new Participante
                    {
                        Id = Convert.ToInt32(reader_348LC["Id_Participante"]),
                        DNI = reader_348LC["DNI"].ToString(),
                        Nombre = reader_348LC["Nombre"].ToString(),
                        Apellido = reader_348LC["Apellido"].ToString(),
                        Edad = Convert.ToInt32(reader_348LC["Edad"]),
                        Telefono = reader_348LC["Telefono"].ToString(),
                        Direccion = reader_348LC["Direccion"] == DBNull.Value ? "" : reader_348LC["Direccion"].ToString(),
                        Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]),
                        DVH = Convert.ToInt32(reader_348LC["DVH"])
                    });
                }
            }
            return lista_348LC;
        }

        public int ObtenerDVV_348LC()
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Participantes'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                return (int)cmd_348LC.ExecuteScalar();
        }

        public void ActualizarDVH_348LC(int idParticipante_348LC, int dvh_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Participantes SET DVH = @dvh WHERE Id_Participante = @id";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvh", dvh_348LC);
                cmd_348LC.Parameters.AddWithValue("@id", idParticipante_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV_348LC(int dvv_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Participantes'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvv", dvv_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
