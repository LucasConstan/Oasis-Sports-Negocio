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
        
        public void Registrar(HistorialCambio cambio)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = @"INSERT INTO HistorialCambios 
                            (EntidadId, NombreEntidad, NombreCampo, ValorAnterior, ValorNuevo, Usuario, Fecha)
                            VALUES (@EntidadId, @NombreEntidad, @NombreCampo, @ValorAnterior, @ValorNuevo, @Usuario, @Fecha)";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@EntidadId", cambio.EntidadId);
            cmd.Parameters.AddWithValue("@NombreEntidad", cambio.NombreEntidad);
            cmd.Parameters.AddWithValue("@NombreCampo", cambio.NombreCampo);
            cmd.Parameters.AddWithValue("@ValorAnterior", cambio.ValorAnterior ?? "");
            cmd.Parameters.AddWithValue("@ValorNuevo", cambio.ValorNuevo ?? "");
            cmd.Parameters.AddWithValue("@Usuario", cambio.Usuario);
            cmd.Parameters.AddWithValue("@Fecha", cambio.Fecha);
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        
        public DataTable ObtenerPorEntidad(int entidadId, string nombreEntidad)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = @"SELECT NombreCampo, ValorAnterior, ValorNuevo, Usuario, Fecha
                             FROM HistorialCambios
                             WHERE EntidadId = @EntidadId AND NombreEntidad = @NombreEntidad
                             ORDER BY Fecha DESC";

            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            da.SelectCommand.Parameters.AddWithValue("@EntidadId", entidadId);
            da.SelectCommand.Parameters.AddWithValue("@NombreEntidad", nombreEntidad);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cn.Close();
            return dt;
        }
    }
}