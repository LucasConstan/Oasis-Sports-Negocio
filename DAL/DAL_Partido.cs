using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Partido
    {
        public List<Partido> ListarPorTorneo_348LC(int idTorneo_348LC)
        {
            List<Partido> lista_348LC = new List<Partido>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"SELECT Id_Partido, Id_Torneo, Id_EquipoLocal, Id_EquipoVisitante, FechaPartido, HoraInicio,
                     NumeroCancha, GolesEquipoLocal, GolesEquipoVisitante, Suspendido, Eliminado
                     FROM Partidos WHERE Id_Torneo = @Id_Torneo AND Eliminado = 0";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Torneo", idTorneo_348LC);

                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Partido()
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Partido"]),
                            IdTorneo = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                            IdEquipoLocal = Convert.ToInt32(reader_348LC["Id_EquipoLocal"]),
                            IdEquipoVisitante = Convert.ToInt32(reader_348LC["Id_EquipoVisitante"]),
                            FechaPartido = Convert.ToDateTime(reader_348LC["FechaPartido"]),
                            HoraInicio = (TimeSpan)reader_348LC["HoraInicio"],
                            NumeroCancha = Convert.ToInt32(reader_348LC["NumeroCancha"]),
                            GolesEquipoLocal = reader_348LC["GolesEquipoLocal"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader_348LC["GolesEquipoLocal"]),
                            GolesEquipoVisitante = reader_348LC["GolesEquipoVisitante"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader_348LC["GolesEquipoVisitante"]),
                            Suspendido = Convert.ToBoolean(reader_348LC["Suspendido"]),
                            Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]),
                        });
                    }
                }
            }

            return lista_348LC;
        }

        public Partido ObtenerCanchaOcupada_348LC(DateTime fechaPartido_348LC, TimeSpan horaInicio_348LC, int numeroCancha_348LC, int idPartidoExcluir_348LC = 0)
        {
            Partido partido_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Partido, Id_Torneo, Id_EquipoLocal, Id_EquipoVisitante, FechaPartido, HoraInicio,
                         NumeroCancha, GolesEquipoLocal, GolesEquipoVisitante, Suspendido, Eliminado
                         FROM Partidos
                         WHERE FechaPartido = @FechaPartido AND HoraInicio = @HoraInicio AND NumeroCancha = @NumeroCancha
                         AND Suspendido = 0 AND Eliminado = 0 AND Id_Partido <> @IdPartidoExcluir";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@FechaPartido", fechaPartido_348LC.Date);
                    cmd_348LC.Parameters.AddWithValue("@HoraInicio", horaInicio_348LC);
                    cmd_348LC.Parameters.AddWithValue("@NumeroCancha", numeroCancha_348LC);
                    cmd_348LC.Parameters.AddWithValue("@IdPartidoExcluir", idPartidoExcluir_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            partido_348LC = new Partido
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Partido"]),
                                IdTorneo = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                                IdEquipoLocal = Convert.ToInt32(reader_348LC["Id_EquipoLocal"]),
                                IdEquipoVisitante = Convert.ToInt32(reader_348LC["Id_EquipoVisitante"]),
                                FechaPartido = Convert.ToDateTime(reader_348LC["FechaPartido"]),
                                HoraInicio = (TimeSpan)reader_348LC["HoraInicio"],
                                NumeroCancha = Convert.ToInt32(reader_348LC["NumeroCancha"]),
                                Suspendido = Convert.ToBoolean(reader_348LC["Suspendido"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return partido_348LC;
        }

        public void AñadirPartido_348LC(Partido partido_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Partidos (Id_Torneo, Id_EquipoLocal, Id_EquipoVisitante, FechaPartido, HoraInicio, NumeroCancha)
                     VALUES (@Id_Torneo, @Id_EquipoLocal, @Id_EquipoVisitante, @FechaPartido, @HoraInicio, @NumeroCancha)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Torneo", partido_348LC.IdTorneo);
                cmd_348LC.Parameters.AddWithValue("@Id_EquipoLocal", partido_348LC.IdEquipoLocal);
                cmd_348LC.Parameters.AddWithValue("@Id_EquipoVisitante", partido_348LC.IdEquipoVisitante);
                cmd_348LC.Parameters.AddWithValue("@FechaPartido", partido_348LC.FechaPartido.Date);
                cmd_348LC.Parameters.AddWithValue("@HoraInicio", partido_348LC.HoraInicio);
                cmd_348LC.Parameters.AddWithValue("@NumeroCancha", partido_348LC.NumeroCancha);

                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
