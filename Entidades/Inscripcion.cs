using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int IdTorneo { get; set; }
        public int IdEquipo { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public bool Eliminado { get; set; }
    }
}
