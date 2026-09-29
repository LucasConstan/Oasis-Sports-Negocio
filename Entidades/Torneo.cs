using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Torneo : IVerificable
    {
        public int Id { get; set; }
        public string NombreTorneo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadMaximaEquipos { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
            Id,
            NombreTorneo?.Length ?? 0,
            Categoria?.Length ?? 0,
            CantidadMaximaEquipos,
            Eliminado ? 1 : 0
            };
        }
    }
}
