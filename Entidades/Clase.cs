using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clase : IVerificable
    {
        public int Id { get; set; }
        public string NombreClase { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int Duracion { get; set; }
        public int CupoMaximo { get; set; }
        public int IdProfesor { get; set; }
        public int NumeroCancha { get; set; }
        public decimal CostoClase { get; set; }
        public DateTime FechaInicioInscripcion { get; set; }
        public DateTime FechaFinInscripcion { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }
        public string NombreProfesor { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                Id,
                (NombreClase ?? "").Sum(c => (int)c),
                Fecha.DayOfYear,
                (int)HoraInicio.TotalMinutes,
                Duracion,
                CupoMaximo,
                IdProfesor,
                NumeroCancha,
                (int)(CostoClase * 100),
                Eliminado ? 1 : 0
            };
        }
    }
}
