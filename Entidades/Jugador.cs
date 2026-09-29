using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador:IVerificable
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Posicion { get; set; }
        public int Numero { get; set; }
        public int IdEquipo { get; set; }
        public bool Eliminado { get; set; }
        public string NombreEquipo { get; set; }

        public int DVH { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
            Id,
            DNI?.Length ?? 0,
            Edad,
            Numero,
            IdEquipo,
            Eliminado ? 1 : 0
            };
        }
    }
}
