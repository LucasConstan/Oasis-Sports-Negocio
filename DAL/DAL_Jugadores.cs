using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Jugador
    {
        public List<Jugador> Listar_348LC()
        {
            List<Jugador> lista_348LC = new List<Jugador>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "select Id_Jugador, DNI, Nombre, Apellido, Edad, Posicion, Numero, Id_Equipo, Eliminado from Jugadores where Eliminado = 0";

            SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC);
            try
            {
                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Jugador()
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Jugador"]),
                            DNI = reader_348LC["DNI"].ToString(),
                            Nombre = reader_348LC["Nombre"].ToString(),
                            Apellido = reader_348LC["Apellido"].ToString(),
                            Edad = Convert.ToInt32(reader_348LC["Edad"]),
                            Posicion = reader_348LC["Posicion"].ToString(),
                            Numero = Convert.ToInt32(reader_348LC["Numero"]),
                            IdEquipo = Convert.ToInt32(reader_348LC["Id_Equipo"]),
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

        public void AñadirJugador_348LC(Jugador jugador_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Jugadores (DNI, Nombre, Apellido, Edad, Posicion, Numero, Id_Equipo)
                     VALUES (@DNI, @Nombre, @Apellido, @Edad, @Posicion, @Numero, @Id_Equipo)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@DNI", jugador_348LC.DNI);
                cmd_348LC.Parameters.AddWithValue("@Nombre", jugador_348LC.Nombre);
                cmd_348LC.Parameters.AddWithValue("@Apellido", jugador_348LC.Apellido);
                cmd_348LC.Parameters.AddWithValue("@Edad", jugador_348LC.Edad);
                cmd_348LC.Parameters.AddWithValue("@Posicion", jugador_348LC.Posicion);
                cmd_348LC.Parameters.AddWithValue("@Numero", jugador_348LC.Numero);
                cmd_348LC.Parameters.AddWithValue("@Id_Equipo", jugador_348LC.IdEquipo);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void EliminarJugador_348LC(int idJugador_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Jugadores SET Eliminado = 1 WHERE Id_Jugador = @Id_Jugador";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Jugador", idJugador_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ModificarJugador_348LC(int idJugador_348LC, Jugador jugador_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Jugadores
                     SET DNI = @DNI,
                         Nombre = @Nombre,
                         Apellido = @Apellido,
                         Edad = @Edad,
                         Posicion = @Posicion,
                         Numero = @Numero,
                         Id_Equipo = @Id_Equipo
                     WHERE Id_Jugador = @IdJugador";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@IdJugador", idJugador_348LC);
                cmd_348LC.Parameters.AddWithValue("@DNI", jugador_348LC.DNI);
                cmd_348LC.Parameters.AddWithValue("@Nombre", jugador_348LC.Nombre);
                cmd_348LC.Parameters.AddWithValue("@Apellido", jugador_348LC.Apellido);
                cmd_348LC.Parameters.AddWithValue("@Edad", jugador_348LC.Edad);
                cmd_348LC.Parameters.AddWithValue("@Posicion", jugador_348LC.Posicion);
                cmd_348LC.Parameters.AddWithValue("@Numero", jugador_348LC.Numero);
                cmd_348LC.Parameters.AddWithValue("@Id_Equipo", jugador_348LC.IdEquipo);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public Jugador ObtenerPorId_348LC(int idJugador_348LC)
        {
            Jugador jugador_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Jugador, DNI, Nombre, Apellido, Edad, Posicion, Numero, Id_Equipo, Eliminado
                         FROM Jugadores WHERE Id_Jugador = @Id_Jugador";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Jugador", idJugador_348LC);

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
    }
}
