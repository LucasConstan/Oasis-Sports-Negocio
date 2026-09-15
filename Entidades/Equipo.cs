using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public string NombreResponsable { get; set; }
        public string ColorPrincipal { get; set; }
        public string ColorSecundario { get; set; }
        public bool Eliminado { get; set; }
    }
}
