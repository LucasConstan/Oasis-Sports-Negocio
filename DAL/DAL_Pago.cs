using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Pago
    {
        public List<Pago> Listar_348LC()
        {
            List<Pago> lista_348LC = new List<Pago>();

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT pg.Id_Pago, pg.Id_Matricula, pg.Monto, pg.MedioPago, pg.FechaPago, pg.Estado, pg.Eliminado,
                         p.DNI, p.Nombre, p.Apellido, c.NombreClase
                         FROM Pagos pg
                         JOIN Matriculas m ON m.Id_Matricula = pg.Id_Matricula
                         JOIN Participantes p ON p.Id_Participante = m.Id_Participante
                         JOIN Clases c ON c.Id_Clase = m.Id_Clase
                         WHERE pg.Eliminado = 0
                         ORDER BY pg.Id_Pago DESC";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                {
                    while (reader_348LC.Read())
                    {
                        lista_348LC.Add(new Pago
                        {
                            Id = Convert.ToInt32(reader_348LC["Id_Pago"]),
                            IdMatricula = Convert.ToInt32(reader_348LC["Id_Matricula"]),
                            Monto = Convert.ToDecimal(reader_348LC["Monto"]),
                            MedioPago = reader_348LC["MedioPago"].ToString(),
                            FechaPago = reader_348LC["FechaPago"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader_348LC["FechaPago"]),
                            Estado = reader_348LC["Estado"].ToString(),
                            Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"]),
                            DNI = reader_348LC["DNI"].ToString(),
                            Nombre = reader_348LC["Nombre"].ToString(),
                            Apellido = reader_348LC["Apellido"].ToString(),
                            NombreClase = reader_348LC["NombreClase"].ToString()
                        });
                    }
                }
            }

            return lista_348LC;
        }

        public Pago ObtenerPorId_348LC(int idPago_348LC)
        {
            Pago pago_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Pago, Id_Matricula, Monto, MedioPago, FechaPago, Estado, Eliminado
                         FROM Pagos WHERE Id_Pago = @Id_Pago";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Pago", idPago_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            pago_348LC = new Pago
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Pago"]),
                                IdMatricula = Convert.ToInt32(reader_348LC["Id_Matricula"]),
                                Monto = Convert.ToDecimal(reader_348LC["Monto"]),
                                MedioPago = reader_348LC["MedioPago"].ToString(),
                                FechaPago = reader_348LC["FechaPago"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader_348LC["FechaPago"]),
                                Estado = reader_348LC["Estado"].ToString(),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return pago_348LC;
        }

        public int AñadirPago_348LC(Pago pago_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Pagos (Id_Matricula, Monto, Estado)
             VALUES (@Id_Matricula, @Monto, @Estado);
             SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Matricula", pago_348LC.IdMatricula);
                cmd_348LC.Parameters.AddWithValue("@Monto", pago_348LC.Monto);
                cmd_348LC.Parameters.AddWithValue("@Estado", pago_348LC.Estado);

                return (int)cmd_348LC.ExecuteScalar();
            }
        }

        public void ModificarPago_348LC(int idPago_348LC, Pago pago_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Pagos
                     SET MedioPago = @MedioPago,
                         FechaPago = @FechaPago,
                         Estado = @Estado
                     WHERE Id_Pago = @Id_Pago";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Pago", idPago_348LC);
                cmd_348LC.Parameters.AddWithValue("@MedioPago", string.IsNullOrEmpty(pago_348LC.MedioPago) ? (object)DBNull.Value : pago_348LC.MedioPago);
                cmd_348LC.Parameters.AddWithValue("@FechaPago", pago_348LC.FechaPago.HasValue ? (object)pago_348LC.FechaPago.Value.Date : DBNull.Value);
                cmd_348LC.Parameters.AddWithValue("@Estado", pago_348LC.Estado);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public List<Pago> ObtenerTodosParaVerificar_348LC()
        {
            List<Pago> lista_348LC = new List<Pago>();
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "SELECT Id_Pago, Id_Matricula, Monto, MedioPago, FechaPago, Estado, Eliminado, DVH FROM Pagos";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
            {
                while (reader_348LC.Read())
                {
                    lista_348LC.Add(new Pago
                    {
                        Id = Convert.ToInt32(reader_348LC["Id_Pago"]),
                        IdMatricula = Convert.ToInt32(reader_348LC["Id_Matricula"]),
                        Monto = Convert.ToDecimal(reader_348LC["Monto"]),
                        MedioPago = reader_348LC["MedioPago"].ToString(),
                        FechaPago = reader_348LC["FechaPago"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader_348LC["FechaPago"]),
                        Estado = reader_348LC["Estado"].ToString(),
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

            string query_348LC = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Pagos'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                return (int)cmd_348LC.ExecuteScalar();
        }

        public void ActualizarDVH_348LC(int idPago_348LC, int dvh_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Pagos SET DVH = @dvh WHERE Id_Pago = @id";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvh", dvh_348LC);
                cmd_348LC.Parameters.AddWithValue("@id", idPago_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV_348LC(int dvv_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Pagos'";
            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@dvv", dvv_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }
    }
}
