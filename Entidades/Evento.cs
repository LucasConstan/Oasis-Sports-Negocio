using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evento
    {
        public string Usuario { get; set; }

        public string Modulo { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public int Criticidad { get; set; }
    }
}
