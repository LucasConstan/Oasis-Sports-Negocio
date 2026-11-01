using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HistorialCambio
    {
        public int IdHistorial { get; set; }
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Bloqueado { get; set; }
        public bool Eliminado { get; set; }
        public string Operacion { get; set; }
        public string UsuarioCambio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
