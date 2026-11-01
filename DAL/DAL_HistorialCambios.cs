using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL_HistorialCambios
    {
        public void Registrar(HistorialCambio version)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"INSERT INTO HistorialCambios
                                (Id_Usuario, NomUsuario, Contraseña, Bloqueado, Eliminado, Operacion, UsuarioCambio, Fecha)
                                VALUES (@IdUsuario, @NomUsuario, @Contraseña, @Bloqueado, @Eliminado, @Operacion, @UsuarioCambio, @Fecha)";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", version.IdUsuario);
                    cmd.Parameters.AddWithValue("@NomUsuario", version.Username);
                    cmd.Parameters.AddWithValue("@Contraseña", version.Password);
                    cmd.Parameters.AddWithValue("@Bloqueado", version.Bloqueado);
                    cmd.Parameters.AddWithValue("@Eliminado", version.Eliminado);
                    cmd.Parameters.AddWithValue("@Operacion", version.Operacion);
                    cmd.Parameters.AddWithValue("@UsuarioCambio", version.UsuarioCambio);
                    cmd.Parameters.AddWithValue("@Fecha", version.Fecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<HistorialCambio> ListarPorUsuario(int idUsuario)
        {
            List<HistorialCambio> lista = new List<HistorialCambio>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT IdHistorial, Id_Usuario, NomUsuario, Contraseña, Bloqueado, Eliminado, Operacion, UsuarioCambio, Fecha
                                 FROM HistorialCambios
                                 WHERE Id_Usuario = @IdUsuario
                                 ORDER BY Fecha DESC, IdHistorial DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new HistorialCambio
                            {
                                IdHistorial = Convert.ToInt32(reader["IdHistorial"]),
                                IdUsuario = Convert.ToInt32(reader["Id_Usuario"]),
                                Username = reader["NomUsuario"].ToString(),
                                Password = reader["Contraseña"].ToString(),
                                Bloqueado = Convert.ToBoolean(reader["Bloqueado"]),
                                Eliminado = Convert.ToBoolean(reader["Eliminado"]),
                                Operacion = reader["Operacion"].ToString(),
                                UsuarioCambio = reader["UsuarioCambio"].ToString(),
                                Fecha = Convert.ToDateTime(reader["Fecha"])
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
