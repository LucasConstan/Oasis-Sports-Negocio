using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Inscripcion
    {
        public List<Equipo> ListarEquiposDelTorneo_348LC(int idTorneo_348LC)
        {
            List<Equipo> lista_348LC = new List<Equipo>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"SELECT EQ.Id_Equipo, EQ.NombreEquipo, EQ.NombreResponsable, EQ.ColorPrincipal, EQ.ColorSecundario, EQ.Eliminado
                     FROM Inscripciones I
                     JOIN Equipos EQ ON EQ.Id_Equipo = I.Id_Equipo
                     WHERE I.Id_Torneo = @Id_Torneo AND I.Eliminado = 0";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Torneo", idTorneo_348LC);

                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Equipo()
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Equipo"]),
                            NombreEquipo = reader_348LC["NombreEquipo"].ToString(),
                            NombreResponsable = reader_348LC["NombreResponsable"].ToString(),
                            ColorPrincipal = reader_348LC["ColorPrincipal"].ToString(),
                            ColorSecundario = reader_348LC["ColorSecundario"].ToString(),
                            Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]),
                        });
                    }
                }
            }

            return lista_348LC;
        }

        public Inscripcion ObtenerInscripcion_348LC(int idTorneo_348LC, int idEquipo_348LC)
        {
            Inscripcion inscripcion_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Inscripcion, Id_Torneo, Id_Equipo, FechaInscripcion, Eliminado
                         FROM Inscripciones WHERE Id_Torneo = @Id_Torneo AND Id_Equipo = @Id_Equipo AND Eliminado = 0";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Torneo", idTorneo_348LC);
                    cmd_348LC.Parameters.AddWithValue("@Id_Equipo", idEquipo_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            inscripcion_348LC = new Inscripcion
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Inscripcion"]),
                                IdTorneo = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                                IdEquipo = Convert.ToInt32(reader_348LC["Id_Equipo"]),
                                FechaInscripcion = Convert.ToDateTime(reader_348LC["FechaInscripcion"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return inscripcion_348LC;
        }

        public int AñadirInscripcion_348LC(Inscripcion inscripcion_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Inscripciones (Id_Torneo, Id_Equipo, FechaInscripcion)
             VALUES (@Id_Torneo, @Id_Equipo, @FechaInscripcion);
             SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Torneo", inscripcion_348LC.IdTorneo);
                cmd_348LC.Parameters.AddWithValue("@Id_Equipo", inscripcion_348LC.IdEquipo);
                cmd_348LC.Parameters.AddWithValue("@FechaInscripcion", inscripcion_348LC.FechaInscripcion);

                return (int)cmd_348LC.ExecuteScalar();
            }
        }

        public void EliminarInscripcion_348LC(int idInscripcion_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Inscripciones SET Eliminado = 1 WHERE Id_Inscripcion = @Id_Inscripcion";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Inscripcion", idInscripcion_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public Jugador ObtenerJugadorEnTorneo_348LC(int idTorneo_348LC, string dni_348LC)
        {
            Jugador jugador_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT J.Id_Jugador, J.DNI, J.Nombre, J.Apellido, J.Edad, J.Posicion, J.Numero, J.Id_Equipo, J.Eliminado
                         FROM Jugadores J
                         JOIN Inscripciones I ON I.Id_Equipo = J.Id_Equipo
                         WHERE I.Id_Torneo = @Id_Torneo AND I.Eliminado = 0 AND J.DNI = @DNI AND J.Eliminado = 0";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Torneo", idTorneo_348LC);
                    cmd_348LC.Parameters.AddWithValue("@DNI", dni_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            jugador_348LC = new Jugador
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Jugador"]),
                                DNI = reader_348LC["DNI"].ToString(),
                                Nombre = reader_348LC["Nombre"].ToString(),
                                Apellido = reader_348LC["Apellido"].ToString(),
                                Edad = Convert.ToInt32(reader_348LC["Edad"]),
                                Posicion = reader_348LC["Posicion"].ToString(),
                                Numero = Convert.ToInt32(reader_348LC["Numero"]),
                                IdEquipo = Convert.ToInt32(reader_348LC["Id_Equipo"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return jugador_348LC;
        }

        public List<Inscripcion> ObtenerTodosParaVerificar_348LC()
        {
            List<Inscripcion> lista_348LC = new List<Inscripcion>();
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Inscripcion, Id_Torneo, Id_Equipo, FechaInscripcion, Eliminado, DVH FROM Inscripciones";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
            {
                while (reader_348LC.Read())
                {
                    lista_348LC.Add(new Inscripcion
                    {
                        Id = Convert.ToInt32(reader_348LC["Id_Inscripcion"]),
                        IdTorneo = Convert.ToInt32(reader_348LC["Id_Torneo"]),
                        IdEquipo = Convert.ToInt32(reader_348LC["Id_Equipo"]),
                        FechaInscripcion = Convert.ToDateTime(reader_348LC["FechaInscripcion"]),
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

            string query_348LC = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Inscripciones'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                return (int)cmd_348LC.ExecuteScalar();
        }

        public void ActualizarDVH_348LC(int idInscripcion_348LC, int dvh_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Inscripciones SET DVH = @dvh WHERE Id_Inscripcion = @id";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvh", dvh_348LC);
                cmd_348LC.Parameters.AddWithValue("@id", idInscripcion_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV_348LC(int dvv_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Inscripciones'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvv", dvv_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
