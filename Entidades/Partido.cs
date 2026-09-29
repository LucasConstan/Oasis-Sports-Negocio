using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Partido:IVerificable
    {
        public int Id { get; set; }
        public int IdTorneo { get; set; }
        public string NombreTorneo { get; set; }
        public int IdEquipoLocal { get; set; }
        public int IdEquipoVisitante { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime FechaPartido { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int NumeroCancha { get; set; }
        public int? GolesEquipoLocal { get; set; }
        public int? GolesEquipoVisitante { get; set; }
        public bool Suspendido { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
            Id,
            IdTorneo,
            IdEquipoLocal,
            IdEquipoVisitante,
            NumeroCancha,
            GolesEquipoLocal ?? 0,
            GolesEquipoVisitante ?? 0,
            Suspendido ? 1 : 0,
            Eliminado ? 1 : 0
            };
        }
    }
}
