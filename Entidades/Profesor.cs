using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesor : IVerificable
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                Id,
                (DNI ?? "").Sum(c => (int)c),
                (Nombre ?? "").Sum(c => (int)c),
                (Apellido ?? "").Sum(c => (int)c),
                (Especialidad ?? "").Sum(c => (int)c),
                Eliminado ? 1 : 0
            };
        }
    }
}
