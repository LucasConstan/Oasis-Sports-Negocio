using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Torneo
    {
        public List<Torneo> Listar_348LC()
        {
            List<Torneo> lista_348LC = new List<Torneo>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "select Id_Torneo, NombreTorneo, Descripcion, Categoria, FechaInicio, FechaFin, CantidadMaximaEquipos, Eliminado from Torneos where Eliminado = 0";

            SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC);
            try
            {
                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Torneo()
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                            NombreTorneo = reader_348LC["NombreTorneo"].ToString(),
                            Descripcion = reader_348LC["Descripcion"] == DBNull.Value ? null : reader_348LC["Descripcion"].ToString(),
                            Categoria = reader_348LC["Categoria"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader_348LC["FechaInicio"]),
                            FechaFin = Convert.ToDateTime(reader_348LC["FechaFin"]),
                            CantidadMaximaEquipos = Convert.ToInt32(reader_348LC["CantidadMaximaEquipos"]),
                            Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]),
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

        public int AñadirTorneo_348LC(Torneo torneo_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Torneos (NombreTorneo, Descripcion, Categoria, FechaInicio, FechaFin, CantidadMaximaEquipos)
             VALUES (@NombreTorneo, @Descripcion, @Categoria, @FechaInicio, @FechaFin, @CantidadMaximaEquipos);
             SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@NombreTorneo", torneo_348LC.NombreTorneo);
                cmd_348LC.Parameters.AddWithValue("@Descripcion", (object)torneo_348LC.Descripcion ?? DBNull.Value);
                cmd_348LC.Parameters.AddWithValue("@Categoria", torneo_348LC.Categoria);
                cmd_348LC.Parameters.AddWithValue("@FechaInicio", torneo_348LC.FechaInicio);
                cmd_348LC.Parameters.AddWithValue("@FechaFin", torneo_348LC.FechaFin);
                cmd_348LC.Parameters.AddWithValue("@CantidadMaximaEquipos", torneo_348LC.CantidadMaximaEquipos);

                return (int)cmd_348LC.ExecuteScalar();
            }
        }

        public void ModificarTorneo_348LC(int idTorneo_348LC, Torneo torneo_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Torneos
                     SET NombreTorneo = @NombreTorneo,
                         Descripcion = @Descripcion,
                         Categoria = @Categoria,
                         FechaInicio = @FechaInicio,
                         FechaFin = @FechaFin,
                         CantidadMaximaEquipos = @CantidadMaximaEquipos
                     WHERE Id_Torneo = @IdTorneo";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@IdTorneo", idTorneo_348LC);
                cmd_348LC.Parameters.AddWithValue("@NombreTorneo", torneo_348LC.NombreTorneo);
                cmd_348LC.Parameters.AddWithValue("@Descripcion", (object)torneo_348LC.Descripcion ?? DBNull.Value);
                cmd_348LC.Parameters.AddWithValue("@Categoria", torneo_348LC.Categoria);
                cmd_348LC.Parameters.AddWithValue("@FechaInicio", torneo_348LC.FechaInicio);
                cmd_348LC.Parameters.AddWithValue("@FechaFin", torneo_348LC.FechaFin);
                cmd_348LC.Parameters.AddWithValue("@CantidadMaximaEquipos", torneo_348LC.CantidadMaximaEquipos);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void EliminarTorneo_348LC(int idTorneo_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Torneos SET Eliminado = 1 WHERE Id_Torneo = @Id_Torneo";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Torneo", idTorneo_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public Torneo ObtenerPorId_348LC(int idTorneo_348LC)
        {
            Torneo torneo_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Torneo, NombreTorneo, Descripcion, Categoria, FechaInicio, FechaFin, CantidadMaximaEquipos, Eliminado
                         FROM Torneos WHERE Id_Torneo = @Id_Torneo";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Torneo", idTorneo_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            torneo_348LC = new Torneo
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                                NombreTorneo = reader_348LC["NombreTorneo"].ToString(),
                                Descripcion = reader_348LC["Descripcion"] == DBNull.Value ? null : reader_348LC["Descripcion"].ToString(),
                                Categoria = reader_348LC["Categoria"].ToString(),
                                FechaInicio = Convert.ToDateTime(reader_348LC["FechaInicio"]),
                                FechaFin = Convert.ToDateTime(reader_348LC["FechaFin"]),
                                CantidadMaximaEquipos = Convert.ToInt32(reader_348LC["CantidadMaximaEquipos"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return torneo_348LC;
        }

        public Torneo ObtenerPorNombre_348LC(string nombreTorneo_348LC)
        {
            Torneo torneo_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Torneo, NombreTorneo, Descripcion, Categoria, FechaInicio, FechaFin, CantidadMaximaEquipos, Eliminado
                         FROM Torneos WHERE NombreTorneo = @NombreTorneo AND Eliminado = 0";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@NombreTorneo", nombreTorneo_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            torneo_348LC = new Torneo
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                                NombreTorneo = reader_348LC["NombreTorneo"].ToString(),
                                Descripcion = reader_348LC["Descripcion"] == DBNull.Value ? null : reader_348LC["Descripcion"].ToString(),
                                Categoria = reader_348LC["Categoria"].ToString(),
                                FechaInicio = Convert.ToDateTime(reader_348LC["FechaInicio"]),
                                FechaFin = Convert.ToDateTime(reader_348LC["FechaFin"]),
                                CantidadMaximaEquipos = Convert.ToInt32(reader_348LC["CantidadMaximaEquipos"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return torneo_348LC;
        }

        public List<Torneo> ObtenerTodosParaVerificar_348LC()
        {
            List<Torneo> lista_348LC = new List<Torneo>();
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Torneo, NombreTorneo, Descripcion, Categoria, FechaInicio, FechaFin, CantidadMaximaEquipos, Eliminado, DVH FROM Torneos";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
            {
                while (reader_348LC.Read())
                {
                    lista_348LC.Add(new Torneo
                    {
                        Id = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                        NombreTorneo = reader_348LC["NombreTorneo"].ToString(),
                        Descripcion = reader_348LC["Descripcion"] == DBNull.Value ? null : reader_348LC["Descripcion"].ToString(),
                        Categoria = reader_348LC["Categoria"].ToString(),
                        FechaInicio = Convert.ToDateTime(reader_348LC["FechaInicio"]),
                        FechaFin = Convert.ToDateTime(reader_348LC["FechaFin"]),
                        CantidadMaximaEquipos = Convert.ToInt32(reader_348LC["CantidadMaximaEquipos"]),
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

            string query_348LC = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Torneos'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                return (int)cmd_348LC.ExecuteScalar();
        }

        public void ActualizarDVH_348LC(int idTorneo_348LC, int dvh_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Torneos SET DVH = @dvh WHERE Id_Torneo = @id";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvh", dvh_348LC);
                cmd_348LC.Parameters.AddWithValue("@id", idTorneo_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV_348LC(int dvv_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Torneos'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvv", dvv_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
