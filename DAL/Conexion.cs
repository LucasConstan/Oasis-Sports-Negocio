using Microsoft.Data.SqlClient;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DAL
{
    public class Conexion
    {
        public static string cadena1 =
         "Data Source=localhost\\SQLEXPRESS;" +
         "Initial Catalog=OasisSports;" +
         "Integrated Security=True;" +
         "Encrypt=True;" +
         "TrustServerCertificate=True;";

        public static string cadena2 = "Data Source=.;Initial Catalog=OasisSports;" +
            "Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;" +
            "Trust Server Certificate=True;Command Timeout=0";

        public static string cadena3 =
        "Data Source=.;" +
        "Initial Catalog=OasisSports;" +
        "Integrated Security=True;" +
        "Encrypt=True;" +
        "TrustServerCertificate=True;";

        private SqlConnection conexion;

       
        public Conexion()
        {
            conexion = new SqlConnection(cadena1);
        }

       
        public void AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
                Console.WriteLine("Conexión abierta");
            }
        }

       
        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
                Console.WriteLine("Conexión cerrada");
            }
        }

        
        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }

    }
}
