using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Clase
    {
        public int AñadirClase_348LC(Clase clase_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Clases (NombreClase, Descripcion, Fecha, HoraInicio, Duracion, CupoMaximo, Id_Profesor, NumeroCancha, CostoClase, FechaInicioInscripcion, FechaFinInscripcion)
             VALUES (@NombreClase, @Descripcion, @Fecha, @HoraInicio, @Duracion, @CupoMaximo, @Id_Profesor, @NumeroCancha, @CostoClase, @FechaInicioInscripcion, @FechaFinInscripcion);
             SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@NombreClase", clase_348LC.NombreClase);
                cmd_348LC.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(clase_348LC.Descripcion) ? (object)DBNull.Value : clase_348LC.Descripcion);
                cmd_348LC.Parameters.AddWithValue("@Fecha", clase_348LC.Fecha.Date);
                cmd_348LC.Parameters.AddWithValue("@HoraInicio", clase_348LC.HoraInicio);
                cmd_348LC.Parameters.AddWithValue("@Duracion", clase_348LC.Duracion);
                cmd_348LC.Parameters.AddWithValue("@CupoMaximo", clase_348LC.CupoMaximo);
                cmd_348LC.Parameters.AddWithValue("@Id_Profesor", clase_348LC.IdProfesor);
                cmd_348LC.Parameters.AddWithValue("@NumeroCancha", clase_348LC.NumeroCancha);
                cmd_348LC.Parameters.AddWithValue("@CostoClase", clase_348LC.CostoClase);
                cmd_348LC.Parameters.AddWithValue("@FechaInicioInscripcion", clase_348LC.FechaInicioInscripcion.Date);
                cmd_348LC.Parameters.AddWithValue("@FechaFinInscripcion", clase_348LC.FechaFinInscripcion.Date);

                return (int)cmd_348LC.ExecuteScalar();
            }
        }

        public bool ExisteSuperposicion_348LC(Clase clase_348LC)
        {
            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT COUNT(*) FROM Clases c
                         WHERE c.Fecha = @Fecha
                         AND c.HoraInicio < DATEADD(MINUTE, @Duracion, @HoraInicio)
                         AND @HoraInicio < DATEADD(MINUTE, c.Duracion, c.HoraInicio)
                         AND c.Eliminado = 0
                         AND (c.Id_Profesor = @Id_Profesor OR c.NumeroCancha = @NumeroCancha)";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Fecha", clase_348LC.Fecha.Date);
                    cmd_348LC.Parameters.AddWithValue("@HoraInicio", clase_348LC.HoraInicio);
                    cmd_348LC.Parameters.AddWithValue("@Duracion", clase_348LC.Duracion);
                    cmd_348LC.Parameters.AddWithValue("@Id_Profesor", clase_348LC.IdProfesor);
                    cmd_348LC.Parameters.AddWithValue("@NumeroCancha", clase_348LC.NumeroCancha);

                    return (int)cmd_348LC.ExecuteScalar() > 0;
                }
            }
        }

        public List<Clase> ListarConInscripcionVigente_348LC()
        {
            List<Clase> lista_348LC = new List<Clase>();

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT c.Id_Clase, c.NombreClase, c.Descripcion, c.Fecha, c.HoraInicio, c.Duracion, c.CupoMaximo, c.Id_Profesor,
                         c.NumeroCancha, c.CostoClase, c.FechaInicioInscripcion, c.FechaFinInscripcion, c.Eliminado,
                         p.Nombre + ' ' + p.Apellido AS NombreProfesor
                         FROM Clases c
                         JOIN Profesores p ON p.Id_Profesor = c.Id_Profesor
                         WHERE c.Eliminado = 0
                         AND CAST(GETDATE() AS DATE) BETWEEN c.FechaInicioInscripcion AND c.FechaFinInscripcion";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Clase
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Clase"]),
                            NombreClase = reader_348LC["NombreClase"].ToString(),
                            Descripcion = reader_348LC["Descripcion"] == DBNull.Value ? "" : reader_348LC["Descripcion"].ToString(),
                            Fecha = Convert.ToDateTime(reader_348LC["Fecha"]),
                            HoraInicio = (TimeSpan)reader_348LC["HoraInicio"],
                            Duracion = Convert.ToInt32(reader_348LC["Duracion"]),
                            CupoMaximo = Convert.ToInt32(reader_348LC["CupoMaximo"]),
                            IdProfesor = Convert.ToInt32(reader_348LC["Id_Profesor"]),
                            NumeroCancha = Convert.ToInt32(reader_348LC["NumeroCancha"]),
                            CostoClase = Convert.ToDecimal(reader_348LC["CostoClase"]),
                            FechaInicioInscripcion = Convert.ToDateTime(reader_348LC["FechaInicioInscripcion"]),
                            FechaFinInscripcion = Convert.ToDateTime(reader_348LC["FechaFinInscripcion"]),
                            Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]),
                            NombreProfesor = reader_348LC["NombreProfesor"].ToString()
                        });
                    }
                }
            }

            return lista_348LC;
        }

        public Clase ObtenerPorId_348LC(int idClase_348LC)
        {
            Clase clase_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Clase, NombreClase, Descripcion, Fecha, HoraInicio, Duracion, CupoMaximo, Id_Profesor,
                         NumeroCancha, CostoClase, FechaInicioInscripcion, FechaFinInscripcion, Eliminado
                         FROM Clases WHERE Id_Clase = @Id_Clase";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Clase", idClase_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            clase_348LC = new Clase
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Clase"]),
                                NombreClase = reader_348LC["NombreClase"].ToString(),
                                Descripcion = reader_348LC["Descripcion"] == DBNull.Value ? "" : reader_348LC["Descripcion"].ToString(),
                                Fecha = Convert.ToDateTime(reader_348LC["Fecha"]),
                                HoraInicio = (TimeSpan)reader_348LC["HoraInicio"],
                                Duracion = Convert.ToInt32(reader_348LC["Duracion"]),
                                CupoMaximo = Convert.ToInt32(reader_348LC["CupoMaximo"]),
                                IdProfesor = Convert.ToInt32(reader_348LC["Id_Profesor"]),
                                NumeroCancha = Convert.ToInt32(reader_348LC["NumeroCancha"]),
                                CostoClase = Convert.ToDecimal(reader_348LC["CostoClase"]),
                                FechaInicioInscripcion = Convert.ToDateTime(reader_348LC["FechaInicioInscripcion"]),
                                FechaFinInscripcion = Convert.ToDateTime(reader_348LC["FechaFinInscripcion"]),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return clase_348LC;
        }

        public List<Clase> ObtenerTodosParaVerificar_348LC()
        {
            List<Clase> lista_348LC = new List<Clase>();
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"SELECT Id_Clase, NombreClase, Descripcion, Fecha, HoraInicio, Duracion, CupoMaximo, Id_Profesor,
             NumeroCancha, CostoClase, FechaInicioInscripcion, FechaFinInscripcion, Eliminado, DVH FROM Clases";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
            {
                while (reader_348LC.Read())
                {
                    lista_348LC.Add(new Clase
                    {
                        Id = Convert.ToInt32(reader_348LC["Id_Clase"]),
                        NombreClase = reader_348LC["NombreClase"].ToString(),
                        Descripcion = reader_348LC["Descripcion"] == DBNull.Value ? "" : reader_348LC["Descripcion"].ToString(),
                        Fecha = Convert.ToDateTime(reader_348LC["Fecha"]),
                        HoraInicio = (TimeSpan)reader_348LC["HoraInicio"],
                        Duracion = Convert.ToInt32(reader_348LC["Duracion"]),
                        CupoMaximo = Convert.ToInt32(reader_348LC["CupoMaximo"]),
                        IdProfesor = Convert.ToInt32(reader_348LC["Id_Profesor"]),
                        NumeroCancha = Convert.ToInt32(reader_348LC["NumeroCancha"]),
                        CostoClase = Convert.ToDecimal(reader_348LC["CostoClase"]),
                        FechaInicioInscripcion = Convert.ToDateTime(reader_348LC["FechaInicioInscripcion"]),
                        FechaFinInscripcion = Convert.ToDateTime(reader_348LC["FechaFinInscripcion"]),
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

            string query_348LC = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Clases'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                return (int)cmd_348LC.ExecuteScalar();
        }

        public void ActualizarDVH_348LC(int idClase_348LC, int dvh_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Clases SET DVH = @dvh WHERE Id_Clase = @id";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvh", dvh_348LC);
                cmd_348LC.Parameters.AddWithValue("@id", idClase_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV_348LC(int dvv_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Clases'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvv", dvv_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
