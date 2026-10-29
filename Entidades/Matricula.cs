using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Matricula : IVerificable
    {
        public int Id { get; set; }
        public int IdClase { get; set; }
        public int IdParticipante { get; set; }
        public DateTime FechaMatricula { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreClase { get; set; }
        public decimal CostoClase { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                Id,
                IdClase,
                IdParticipante,
                FechaMatricula.DayOfYear,
                Eliminado ? 1 : 0
            };
        }
    }
}
