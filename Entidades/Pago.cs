using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pago : IVerificable
    {
        public int Id { get; set; }
        public int IdMatricula { get; set; }
        public decimal Monto { get; set; }
        public string MedioPago { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Estado { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreClase { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                Id,
                IdMatricula,
                (int)(Monto * 100),
                (MedioPago ?? "").Sum(c => (int)c),
                FechaPago?.DayOfYear ?? 0,
                (Estado ?? "").Sum(c => (int)c),
                Eliminado ? 1 : 0
            };
        }
    }
}
