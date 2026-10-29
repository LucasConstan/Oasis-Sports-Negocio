using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Profesor
    {
        public List<Profesor> Listar_348LC()
        {
            List<Profesor> lista_348LC = new List<Profesor>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Profesor, DNI, Nombre, Apellido, Especialidad, Eliminado FROM Profesores WHERE Eliminado = 0";

            SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC);
            try
            {
                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Profesor()
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Profesor"]),
                            DNI = reader_348LC["DNI"].ToString(),
                            Nombre = reader_348LC["Nombre"].ToString(),
                            Apellido = reader_348LC["Apellido"].ToString(),
                            Especialidad = reader_348LC["Especialidad"].ToString(),
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

        public List<Profesor> ListarDisponibles_348LC(Clase clase_348LC)
        {
            List<Profesor> lista_348LC = new List<Profesor>();

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT p.Id_Profesor, p.DNI, p.Nombre, p.Apellido, p.Especialidad, p.Eliminado
                         FROM Profesores p
                         WHERE p.Eliminado = 0
                         AND NOT EXISTS (SELECT 1 FROM Clases c
                                         WHERE c.Id_Profesor = p.Id_Profesor
                                         AND c.Fecha = @Fecha
                                         AND c.HoraInicio < DATEADD(MINUTE, @Duracion, @HoraInicio)
                                         AND @HoraInicio < DATEADD(MINUTE, c.Duracion, c.HoraInicio)
                                         AND c.Eliminado = 0)";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Fecha", clase_348LC.Fecha.Date);
                    cmd_348LC.Parameters.AddWithValue("@HoraInicio", clase_348LC.HoraInicio);
                    cmd_348LC.Parameters.AddWithValue("@Duracion", clase_348LC.Duracion);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        while (reader_348LC.Read())
                        {
                            lista_348LC.Add(new Profesor
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Profesor"]),
                                DNI = reader_348LC["DNI"].ToString(),
                                Nombre = reader_348LC["Nombre"].ToString(),
                                Apellido = reader_348LC["Apellido"].ToString(),
                                Especialidad = reader_348LC["Especialidad"].ToString(),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            });
                        }
                    }
                }
            }

            return lista_348LC;
        }

        public int AñadirProfesor_348LC(Profesor profesor_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Profesores (DNI, Nombre, Apellido, Especialidad)
             VALUES (@DNI, @Nombre, @Apellido, @Especialidad);
             SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@DNI", profesor_348LC.DNI);
                cmd_348LC.Parameters.AddWithValue("@Nombre", profesor_348LC.Nombre);
                cmd_348LC.Parameters.AddWithValue("@Apellido", profesor_348LC.Apellido);
                cmd_348LC.Parameters.AddWithValue("@Especialidad", profesor_348LC.Especialidad);

                return (int)cmd_348LC.ExecuteScalar();
            }
        }

        public void EliminarProfesor_348LC(int idProfesor_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Profesores SET Eliminado = 1 WHERE Id_Profesor = @Id_Profesor";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Profesor", idProfesor_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ModificarProfesor_348LC(int idProfesor_348LC, Profesor profesor_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Profesores
                     SET DNI = @DNI,
                         Nombre = @Nombre,
                         Apellido = @Apellido,
                         Especialidad = @Especialidad
                     WHERE Id_Profesor = @Id_Profesor";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Profesor", idProfesor_348LC);
                cmd_348LC.Parameters.AddWithValue("@DNI", profesor_348LC.DNI);
                cmd_348LC.Parameters.AddWithValue("@Nombre", profesor_348LC.Nombre);
                cmd_348LC.Parameters.AddWithValue("@Apellido", profesor_348LC.Apellido);
                cmd_348LC.Parameters.AddWithValue("@Especialidad", profesor_348LC.Especialidad);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public Profesor ObtenerPorId_348LC(int idProfesor_348LC)
        {
            Profesor profesor_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Profesor, DNI, Nombre, Apellido, Especialidad, Eliminado
                         FROM Profesores WHERE Id_Profesor = @Id_Profesor";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Profesor", idProfesor_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            profesor_348LC = new Profesor
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Profesor"]),
                                DNI = reader_348LC["DNI"].ToString(),
                                Nombre = reader_348LC["Nombre"].ToString(),
                                Apellido = reader_348LC["Apellido"].ToString(),
                                Especialidad = reader_348LC["Especialidad"].ToString(),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return profesor_348LC;
        }

        public List<Profesor> ObtenerTodosParaVerificar_348LC()
        {
            List<Profesor> lista_348LC = new List<Profesor>();
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Profesor, DNI, Nombre, Apellido, Especialidad, Eliminado, DVH FROM Profesores";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
            {
                while (reader_348LC.Read())
                {
                    lista_348LC.Add(new Profesor
                    {
                        Id = Convert.ToInt32(reader_348LC["Id_Profesor"]),
                        DNI = reader_348LC["DNI"].ToString(),
                        Nombre = reader_348LC["Nombre"].ToString(),
                        Apellido = reader_348LC["Apellido"].ToString(),
                        Especialidad = reader_348LC["Especialidad"].ToString(),
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

            string query_348LC = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Profesores'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                return (int)cmd_348LC.ExecuteScalar();
        }

        public void ActualizarDVH_348LC(int idProfesor_348LC, int dvh_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Profesores SET DVH = @dvh WHERE Id_Profesor = @id";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvh", dvh_348LC);
                cmd_348LC.Parameters.AddWithValue("@id", idProfesor_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV_348LC(int dvv_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Profesores'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvv", dvv_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
