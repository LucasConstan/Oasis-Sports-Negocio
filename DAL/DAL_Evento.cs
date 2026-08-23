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
    public class DAL_Evento
    {
        public void RegistrarEvento(Evento evento)
        {
            Conexion conexion = new Conexion();

            SqlConnection cn = conexion.ObtenerConexion();

            cn.Open();

            string query =  @"INSERT INTO BitacoraEventos (Usuario,Modulo,Descripcion,Fecha,Criticidad)
            VALUES(@Usuario,@Modulo,@Descripcion,@Fecha,@Criticidad)";

            SqlCommand cmd = new SqlCommand(query, cn);

            cmd.Parameters.AddWithValue("@Usuario", evento.Usuario);
            cmd.Parameters.AddWithValue("@Modulo", evento.Modulo);
            cmd.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
            cmd.Parameters.AddWithValue("@Fecha", evento.Fecha);
            cmd.Parameters.AddWithValue("@Criticidad", evento.Criticidad);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public DataTable ListarEventos()
        {
            Conexion conexion = new Conexion();

            SqlConnection cn = conexion.ObtenerConexion();

            cn.Open();
            string query = @"SELECT * FROM BitacoraEventos ORDER BY Fecha DESC";

            SqlDataAdapter da = new SqlDataAdapter(query, cn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            cn.Close();

            return dt;
        }
    }
}
