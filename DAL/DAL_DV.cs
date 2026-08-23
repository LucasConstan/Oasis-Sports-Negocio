using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_DV
    {
        Encriptacion encriptador = new Encriptacion();
        public List<Usuario> ObtenerTodosParaVerificar()
        {
            List<Usuario> lista = new List<Usuario>();
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT Id_Usuario, NomUsuario, contraseña, Bloqueado, Eliminado, DVH FROM Usuarios";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Usuario
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Bloqueado = reader.GetBoolean(3),
                        Eliminado = reader.GetBoolean(4),
                        DVH = reader.GetInt32(5)
                    });
                }
            }
            return lista;
        }

        public int ObtenerDVV()
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT ValorDVV FROM DVVertical WHERE Tabla = 'Usuarios'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
                return (int)cmd.ExecuteScalar();
        }

        public void ActualizarDVH(int idUsuario, int dvh)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "UPDATE Usuarios SET DVH = @dvh WHERE Id_Usuario = @id";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@dvh", dvh);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarDVV(int dvv)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "UPDATE DVVertical SET ValorDVV = @dvv WHERE Tabla = 'Usuarios'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@dvv", dvv);
                cmd.ExecuteNonQuery();
            }
        }

        public void InicializarDVs()
        {

            List<Usuario> usuarios = ObtenerTodosParaVerificar();

            ValidadorDeIntegridad validador = new ValidadorDeIntegridad();


            foreach (Usuario u in usuarios)
            {
                int dvh = validador.CalcularDV(u);
                ActualizarDVH(u.Id, dvh);
            }


            usuarios = ObtenerTodosParaVerificar();
            List<IVerificable> objetos = usuarios.Cast<IVerificable>().ToList();
            int dvv = validador.CalcularDVV(objetos);
            ActualizarDVV(dvv);
        }
        public void RestaurarCampo(int idUsuario, string campo, string valorAnterior)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();


            string columna = "";
            if (campo == "Username") columna = "NomUsuario";
            if (campo == "Password") columna = "Contraseña";
            if (campo == "Bloqueado") columna = "Bloqueado";

            if (string.IsNullOrEmpty(columna))
            {
                cn.Close();
                return;
            }

            string query = $"UPDATE Usuarios SET {columna} = @Valor WHERE Id_Usuario = @Id";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {

                if (campo == "Bloqueado")
                    cmd.Parameters.AddWithValue("@Valor", valorAnterior == "Sí" ? 1 : 0);
                else if (campo == "Password")
                    cmd.Parameters.AddWithValue("@Valor", encriptador.Encriptar(valorAnterior));
                else
                    cmd.Parameters.AddWithValue("@Valor", valorAnterior);

                cmd.Parameters.AddWithValue("@Id", idUsuario);
                cmd.ExecuteNonQuery();
            }

            cn.Close();
        }
    }
}
