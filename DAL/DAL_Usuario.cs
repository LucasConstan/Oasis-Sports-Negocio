using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Servicios;
using System.Collections;

namespace DAL
{
    public class DAL_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "select Id_Usuario, NomUsuario, Contraseña, Bloqueado, Eliminado from Usuarios";

            SqlCommand cmd = new SqlCommand(query, cn);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id = Convert.ToInt32(reader["Id_Usuario"]),
                            Username = reader["NomUsuario"].ToString(),
                            Password = reader["Contraseña"].ToString(),
                            Bloqueado = Convert.ToBoolean(reader["Bloqueado"]),
                            Eliminado = Convert.ToBoolean(reader["Eliminado"]),


                        });

                    }
                }
            }
            catch (Exception ex) 
            {
                System.Console.WriteLine("Error en la búsqueda: " + ex.Message);
                
            }



            return lista;
        }

        Encriptacion encriptador = new Encriptacion();



        public void AñadirUsuario(Usuario usuario)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "INSERT INTO usuarios (nomUsuario, contraseña) VALUES (@NomUsuario, @Contraseña)";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                
                cmd.Parameters.AddWithValue("@NomUsuario", usuario.Username);
                cmd.Parameters.AddWithValue("@Contraseña", encriptador.Encriptar(usuario.Password)); 

                
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "UPDATE Usuarios SET Eliminado = 1 WHERE Id_Usuario = @Id_Usuario"; ;

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarUsuario(int idUsuario, Usuario usuario)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = @"UPDATE Usuarios
                     SET NomUsuario = @NomUsuario,
                         Contraseña = @Contraseña
                     WHERE Id_Usuario = @IdUsuario";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@NomUsuario", usuario.Username);
                cmd.Parameters.AddWithValue("@Contraseña", encriptador.Encriptar(usuario.Password));

                cmd.ExecuteNonQuery();
            }
        }

        public Usuario ObtenerPorUsuario(string username)
        {
            Usuario usuario = null;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT Id_Usuario, NomUsuario, Contraseña, Bloqueado FROM Usuarios WHERE NomUsuario = @Username";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id_Usuario"]),
                                Username = reader["NomUsuario"].ToString(),
                                Password = reader["Contraseña"].ToString(),
                                Bloqueado = Convert.ToBoolean(reader["Bloqueado"])
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public void BloquearUsuario(int idUsuario)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"UPDATE Usuarios
                         SET Bloqueado = 1
                         WHERE Id_Usuario = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
