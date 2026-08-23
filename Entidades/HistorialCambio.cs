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
        public int EntidadId { get; set; }
        public string NombreEntidad { get; set; }
        public string NombreCampo { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
