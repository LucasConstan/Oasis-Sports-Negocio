using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Equipo
    {
        public List<Equipo> Listar_348LC()
        {
            List<Equipo> lista_348LC = new List<Equipo>();

            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "select Id_Equipo, NombreEquipo, NombreResponsable, ColorPrincipal, ColorSecundario, Eliminado from Equipos where Eliminado = 0";

            SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC);
            try
            {
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
            catch (Exception ex_348LC)
            {
                System.Console.WriteLine("Error en la búsqueda: " + ex_348LC.Message);
            }

            return lista_348LC;
        }

        public void AñadirEquipo_348LC(Equipo equipo_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"INSERT INTO Equipos (NombreEquipo, NombreResponsable, ColorPrincipal, ColorSecundario)
                     VALUES (@NombreEquipo, @NombreResponsable, @ColorPrincipal, @ColorSecundario)";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@NombreEquipo", equipo_348LC.NombreEquipo);
                cmd_348LC.Parameters.AddWithValue("@NombreResponsable", equipo_348LC.NombreResponsable);
                cmd_348LC.Parameters.AddWithValue("@ColorPrincipal", equipo_348LC.ColorPrincipal);
                cmd_348LC.Parameters.AddWithValue("@ColorSecundario", equipo_348LC.ColorSecundario);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void EliminarEquipo_348LC(int idEquipo_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = "UPDATE Equipos SET Eliminado = 1 WHERE Id_Equipo = @Id_Equipo";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@Id_Equipo", idEquipo_348LC);
                cmd_348LC.ExecuteNonQuery();
            }
        }

        public void ModificarEquipo_348LC(int idEquipo_348LC, Equipo equipo_348LC)
        {
            Conexion conexion_348LC = new Conexion();
            SqlConnection cn_348LC = conexion_348LC.ObtenerConexion();
            cn_348LC.Open();

            string query_348LC = @"UPDATE Equipos
                     SET NombreEquipo = @NombreEquipo,
                         NombreResponsable = @NombreResponsable,
                         ColorPrincipal = @ColorPrincipal,
                         ColorSecundario = @ColorSecundario
                     WHERE Id_Equipo = @IdEquipo";

            using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
            {
                cmd_348LC.Parameters.AddWithValue("@IdEquipo", idEquipo_348LC);
                cmd_348LC.Parameters.AddWithValue("@NombreEquipo", equipo_348LC.NombreEquipo);
                cmd_348LC.Parameters.AddWithValue("@NombreResponsable", equipo_348LC.NombreResponsable);
                cmd_348LC.Parameters.AddWithValue("@ColorPrincipal", equipo_348LC.ColorPrincipal);
                cmd_348LC.Parameters.AddWithValue("@ColorSecundario", equipo_348LC.ColorSecundario);

                cmd_348LC.ExecuteNonQuery();
            }
        }

        public Equipo ObtenerPorId_348LC(int idEquipo_348LC)
        {
            Equipo equipo_348LC = null;

            using (SqlConnection cn_348LC = new Conexion().ObtenerConexion())
            {
                cn_348LC.Open();

                string query_348LC = @"SELECT Id_Equipo, NombreEquipo, NombreResponsable, ColorPrincipal, ColorSecundario, Eliminado
                         FROM Equipos WHERE Id_Equipo = @Id_Equipo";

                using (SqlCommand cmd_348LC = new SqlCommand(query_348LC, cn_348LC))
                {
                    cmd_348LC.Parameters.AddWithValue("@Id_Equipo", idEquipo_348LC);

                    using (SqlDataReader reader_348LC = cmd_348LC.ExecuteReader())
                    {
                        if (reader_348LC.Read())
                        {
                            equipo_348LC = new Equipo
                            {
                                Id = Convert.ToInt32(reader_348LC["Id_Equipo"]),
                                NombreEquipo = reader_348LC["NombreEquipo"].ToString(),
                                NombreResponsable = reader_348LC["NombreResponsable"].ToString(),
                                ColorPrincipal = reader_348LC["ColorPrincipal"].ToString(),
                                ColorSecundario = reader_348LC["ColorSecundario"].ToString(),
                                Eliminado = Convert.ToBoolean(reader_348LC["Eliminado"])
                            };
                        }
                    }
                }
            }

            return equipo_348LC;
        }
    }
}
