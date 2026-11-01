using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Servicios;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Permisos
    {
        public List<ComponentePermiso> ObtenerTodos()
        {
            List<ComponentePermiso> permisos = new List<ComponentePermiso>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT Id, Nombre, Codigo, EsGrupo FROM Permiso ORDER BY EsGrupo DESC, Codigo";

                using (SqlCommand comando = new SqlCommand(query, cn))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                        permisos.Add(CrearComponente(reader));
                }
            }

            return permisos;
        }

        public ComponentePermiso ObtenerArbolPermiso(int permisoId)
        {
            return ArmarArbol(permisoId, ObtenerTodos(), ObtenerRelaciones());
        }

        public List<ComponentePermiso> ObtenerArboles()
        {
            List<ComponentePermiso> permisos = ObtenerTodos();
            List<(int PadreId, int HijoId)> relaciones = ObtenerRelaciones();

            return permisos.Select(p => ArmarArbol(p.Id, permisos, relaciones)).ToList();
        }

        private ComponentePermiso ArmarArbol(int permisoId, List<ComponentePermiso> permisos, List<(int PadreId, int HijoId)> relaciones)
        {
            ComponentePermiso datos = permisos.FirstOrDefault(p => p.Id == permisoId);

            if (datos == null)
                throw new Exception("Permiso no encontrado.");

            if (datos is PermisoSimple)
                return new PermisoSimple { Id = datos.Id, Nombre = datos.Nombre, Codigo = datos.Codigo };

            GrupoPermisos grupo = new GrupoPermisos { Id = datos.Id, Nombre = datos.Nombre, Codigo = datos.Codigo };

            IEnumerable<ComponentePermiso> hijos = relaciones
                .Where(r => r.PadreId == permisoId)
                .Select(r => permisos.First(p => p.Id == r.HijoId))
                .OrderBy(p => p is PermisoSimple)
                .ThenBy(p => p.Codigo);

            foreach (ComponentePermiso hijo in hijos)
                grupo.Agregar(ArmarArbol(hijo.Id, permisos, relaciones));

            return grupo;
        }

        private List<(int PadreId, int HijoId)> ObtenerRelaciones()
        {
            List<(int PadreId, int HijoId)> relaciones = new List<(int PadreId, int HijoId)>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT PadreId, HijoId FROM PermisoRelacion";

                using (SqlCommand comando = new SqlCommand(query, cn))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                        relaciones.Add((Convert.ToInt32(reader["PadreId"]), Convert.ToInt32(reader["HijoId"])));
                }
            }

            return relaciones;
        }

        private ComponentePermiso CrearComponente(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["Id"]);
            string nombre = reader["Nombre"].ToString();
            string codigo = reader["Codigo"].ToString();

            if (Convert.ToBoolean(reader["EsGrupo"]))
                return new GrupoPermisos { Id = id, Nombre = nombre, Codigo = codigo };

            return new PermisoSimple { Id = id, Nombre = nombre, Codigo = codigo };
        }

        public GrupoPermisos ObtenerPerfilDeUsuario(int usuarioId)
        {
            object perfilId;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT PermisoId FROM UsuarioPermiso WHERE UsuarioId = @UsuarioId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    perfilId = comando.ExecuteScalar();
                }
            }

            if (perfilId == null || perfilId == DBNull.Value)
                return null;

            return ObtenerArbolPermiso(Convert.ToInt32(perfilId)) as GrupoPermisos;
        }

        public void AsignarPerfil(int usuarioId, int perfilId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"UPDATE UsuarioPermiso SET PermisoId = @PermisoId WHERE UsuarioId = @UsuarioId;
                IF @@ROWCOUNT = 0
                    INSERT INTO UsuarioPermiso (UsuarioId, PermisoId) VALUES (@UsuarioId, @PermisoId);";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    comando.Parameters.AddWithValue("@PermisoId", perfilId);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void QuitarPerfil(int usuarioId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "DELETE FROM UsuarioPermiso WHERE UsuarioId = @UsuarioId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public int CrearGrupo(string codigo, string nombre, List<int> hijosIds)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        int grupoId;
                        string query = "INSERT INTO Permiso (Nombre, Codigo, EsGrupo) OUTPUT INSERTED.Id VALUES (@Nombre, @Codigo, 1)";

                        using (SqlCommand comando = new SqlCommand(query, cn, transaccion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nombre);
                            comando.Parameters.AddWithValue("@Codigo", codigo);
                            grupoId = Convert.ToInt32(comando.ExecuteScalar());
                        }

                        InsertarHijos(cn, transaccion, grupoId, hijosIds);

                        transaccion.Commit();
                        return grupoId;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ModificarGrupo(int grupoId, string codigo, string nombre, List<int> hijosIds)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"UPDATE Permiso SET Nombre = @Nombre, Codigo = @Codigo WHERE Id = @Id AND EsGrupo = 1;
                        DELETE FROM PermisoRelacion WHERE PadreId = @Id;";

                        using (SqlCommand comando = new SqlCommand(query, cn, transaccion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nombre);
                            comando.Parameters.AddWithValue("@Codigo", codigo);
                            comando.Parameters.AddWithValue("@Id", grupoId);
                            comando.ExecuteNonQuery();
                        }

                        InsertarHijos(cn, transaccion, grupoId, hijosIds);

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        private void InsertarHijos(SqlConnection cn, SqlTransaction transaccion, int grupoId, List<int> hijosIds)
        {
            string query = "INSERT INTO PermisoRelacion (PadreId, HijoId) VALUES (@PadreId, @HijoId)";

            foreach (int hijoId in hijosIds)
            {
                using (SqlCommand comando = new SqlCommand(query, cn, transaccion))
                {
                    comando.Parameters.AddWithValue("@PadreId", grupoId);
                    comando.Parameters.AddWithValue("@HijoId", hijoId);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarGrupo(int grupoId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"DELETE FROM PermisoRelacion WHERE PadreId = @Id;
                        DELETE FROM Permiso WHERE Id = @Id AND EsGrupo = 1;";

                        using (SqlCommand comando = new SqlCommand(query, cn, transaccion))
                        {
                            comando.Parameters.AddWithValue("@Id", grupoId);
                            comando.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool GrupoPoseeUsuarios(int grupoId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT COUNT(*) FROM UsuarioPermiso WHERE PermisoId = @PermisoId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@PermisoId", grupoId);
                    return (int)comando.ExecuteScalar() > 0;
                }
            }
        }

        public Dictionary<int, int> ObtenerCantidadUsuariosPorPerfil()
        {
            Dictionary<int, int> cantidades = new Dictionary<int, int>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT PermisoId, COUNT(*) AS Cantidad FROM UsuarioPermiso GROUP BY PermisoId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                        cantidades[Convert.ToInt32(reader["PermisoId"])] = Convert.ToInt32(reader["Cantidad"]);
                }
            }

            return cantidades;
        }

        public bool GrupoPerteneceAOtroGrupo(int grupoId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT COUNT(*) FROM PermisoRelacion WHERE HijoId = @HijoId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@HijoId", grupoId);
                    return (int)comando.ExecuteScalar() > 0;
                }
            }
        }
    }
}
