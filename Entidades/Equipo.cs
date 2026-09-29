using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo: IVerificable
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public string NombreResponsable { get; set; }
        public string ColorPrincipal { get; set; }
        public string ColorSecundario { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
            Id,
            NombreEquipo?.Length ?? 0,
            NombreResponsable?.Length ?? 0,
            Eliminado ? 1 : 0
            };
        }
    }
}
