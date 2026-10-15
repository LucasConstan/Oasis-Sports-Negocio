using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Resultado
    {
        public List<Partido> ListarPendientes_348LC(int idTorneo_348LC)
        {
            List<Partido> lista_348LC = new List<Partido>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"SELECT P.Id_Partido, P.Id_Torneo, T.NombreTorneo, P.Id_EquipoLocal, P.Id_EquipoVisitante,
             EL.NombreEquipo AS NombreEquipoLocal, EV.NombreEquipo AS NombreEquipoVisitante,
             P.FechaPartido, P.HoraInicio, P.NumeroCancha, P.GolesEquipoLocal, P.GolesEquipoVisitante,
             P.Suspendido, P.Eliminado
             FROM Partidos P
             JOIN Torneos T ON T.Id_Torneo = P.Id_Torneo
             JOIN Equipos EL ON EL.Id_Equipo = P.Id_EquipoLocal
             JOIN Equipos EV ON EV.Id_Equipo = P.Id_EquipoVisitante
             WHERE P.Id_Torneo = @Id_Torneo AND P.Eliminado = 0
             AND P.Suspendido = 0 AND P.GolesEquipoLocal IS NULL AND P.GolesEquipoVisitante IS NULL";

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
                            NombreTorneo = reader_348LC["NombreTorneo"].ToString(),
                            EquipoLocal = reader_348LC["NombreEquipoLocal"].ToString(),
                            EquipoVisitante = reader_348LC["NombreEquipoVisitante"].ToString(),
                            IdEquipoLocal = Convert.ToInt32(reader_348LC["Id_EquipoLocal"]),
                            IdEquipoVisitante = Convert.ToInt32(reader_348LC["Id_EquipoVisitante"]),
                            FechaPartido = Convert.ToDateTime(reader_348LC["FechaPartido"]),
                            HoraInicio = (TimeSpan)reader_348LC["HoraInicio"],
                            NumeroCancha = Convert.ToInt32(reader_348LC["NumeroCancha"]),
                            Suspendido = Convert.ToBoolean(reader_348LC["Suspendido"]),
                            Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]), 
                        });
                    }
                }
            }

            return lista_348LC;
        }

        public void ActualizarResultado_348LC(int idPartido_348LC, int golesLocal_348LC, int golesVisitante_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Partidos
                     SET GolesEquipoLocal = @GolesEquipoLocal,
                         GolesEquipoVisitante = @GolesEquipoVisitante,
                         Suspendido = 0
                     WHERE Id_Partido = @Id_Partido";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Partido", idPartido_348LC);
                cmd_348LC.Parameters.AddWithValue("@GolesEquipoLocal", golesLocal_348LC);
                cmd_348LC.Parameters.AddWithValue("@GolesEquipoVisitante", golesVisitante_348LC);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void MarcarSuspendido_348LC(int idPartido_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Partidos SET Suspendido = 1 WHERE Id_Partido = @Id_Partido";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Partido", idPartido_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void Reprogramar_348LC(int idPartido_348LC, DateTime fechaPartido_348LC, TimeSpan horaInicio_348LC, int numeroCancha_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Partidos
                     SET FechaPartido = @FechaPartido,
                         HoraInicio = @HoraInicio,
                         NumeroCancha = @NumeroCancha,
                         Suspendido = 0
                     WHERE Id_Partido = @Id_Partido";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Partido", idPartido_348LC);
                cmd_348LC.Parameters.AddWithValue("@FechaPartido", fechaPartido_348LC.Date);
                cmd_348LC.Parameters.AddWithValue("@HoraInicio", horaInicio_348LC);
                cmd_348LC.Parameters.AddWithValue("@NumeroCancha", numeroCancha_348LC);

                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
