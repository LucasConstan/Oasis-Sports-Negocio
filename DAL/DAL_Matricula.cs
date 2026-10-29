using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Matricula
    {
        public List<Matricula> ListarPorClase_348LC(int idClase_348LC)
        {
            List<Matricula> lista_348LC = new List<Matricula>();

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT m.Id_Matricula, m.Id_Clase, m.Id_Participante, m.FechaMatricula, m.Eliminado,
                         p.DNI, p.Nombre, p.Apellido
                         FROM Matriculas m
                         JOIN Participantes p ON p.Id_Participante = m.Id_Participante
                         WHERE m.Id_Clase = @Id_Clase AND m.Eliminado = 0";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Clase", idClase_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        while (reader_348LC.Read())
                        {
                            lista_348LC.Add(new Matricula
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Matricula"]),
                                IdClase = Convert.ToInt32(reader_348LC["Id_Clase"]),
                                IdParticipante = Convert.ToInt32(reader_348LC["Id_Participante"]),
                                FechaMatricula = Convert.ToDateTime(reader_348LC["FechaMatricula"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]),
                                DNI = reader_348LC["DNI"].ToString(),
                                Nombre = reader_348LC["Nombre"].ToString(),
                                Apellido = reader_348LC["Apellido"].ToString()
                            });
                        }
                    }
                }
            }

            return lista_348LC;
        }

        public void EliminarMatricula_348LC(int idMatricula_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Matriculas SET Eliminado = 1 WHERE Id_Matricula = @Id_Matricula";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Matricula", idMatricula_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public int ContarMatriculados_348LC(int idClase_348LC)
        {
            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = "SELECT COUNT(*) FROM Matriculas WHERE Id_Clase = @Id_Clase AND Eliminado = 0";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Clase", idClase_348LC);
                    return (int)cmd_348LC.ExecuteScalar();
                }
            }
        }

        public bool ExisteMatricula_348LC(int idClase_348LC, int idParticipante_348LC)
        {
            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = "SELECT COUNT(*) FROM Matriculas WHERE Id_Clase = @Id_Clase AND Id_Participante = @Id_Participante AND Eliminado = 0";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Clase", idClase_348LC);
                    cmd_348LC.Parameters.AddWithValue("@Id_Participante", idParticipante_348LC);
                    return (int)cmd_348LC.ExecuteScalar() > 0;
                }
            }
        }

        public int AñadirMatricula_348LC(Matricula matricula_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Matriculas (Id_Clase, Id_Participante, FechaMatricula)
             VALUES (@Id_Clase, @Id_Participante, @FechaMatricula);
             SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Clase", matricula_348LC.IdClase);
                cmd_348LC.Parameters.AddWithValue("@Id_Participante", matricula_348LC.IdParticipante);
                cmd_348LC.Parameters.AddWithValue("@FechaMatricula", matricula_348LC.FechaMatricula.Date);

                return (int)cmd_348LC.ExecuteScalar();
            }
        }

        public Matricula ObtenerPorId_348LC(int idMatricula_348LC)
        {
            Matricula matricula_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Matricula, Id_Clase, Id_Participante, FechaMatricula, Eliminado
                         FROM Matriculas WHERE Id_Matricula = @Id_Matricula";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Matricula", idMatricula_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            matricula_348LC = new Matricula
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Matricula"]),
                                IdClase = Convert.ToInt32(reader_348LC["Id_Clase"]),
                                IdParticipante = Convert.ToInt32(reader_348LC["Id_Participante"]),
                                FechaMatricula = Convert.ToDateTime(reader_348LC["FechaMatricula"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return matricula_348LC;
        }

        public List<Matricula> ObtenerTodosParaVerificar_348LC()
        {
            List<Matricula> lista_348LC = new List<Matricula>();
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Matricula, Id_Clase, Id_Participante, FechaMatricula, Eliminado, DVH FROM Matriculas";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
            {
                while (reader_348LC.Read())
                {
                    lista_348LC.Add(new Matricula
                    {
                        Id = Convert.ToInt32(reader_348LC["Id_Matricula"]),
                        IdClase = Convert.ToInt32(reader_348LC["Id_Clase"]),
                        IdParticipante = Convert.ToInt32(reader_348LC["Id_Participante"]),
                        FechaMatricula = Convert.ToDateTime(reader_348LC["FechaMatricula"]),
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

            string query_348LC = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Matriculas'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                return (int)cmd_348LC.ExecuteScalar();
        }

        public void ActualizarDVH_348LC(int idMatricula_348LC, int dvh_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Matriculas SET DVH = @dvh WHERE Id_Matricula = @id";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvh", dvh_348LC);
                cmd_348LC.Parameters.AddWithValue("@id", idMatricula_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV_348LC(int dvv_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Matriculas'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvv", dvv_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
