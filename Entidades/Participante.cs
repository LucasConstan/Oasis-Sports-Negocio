using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Participante : IVerificable
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        [XmlIgnore]
        public bool Eliminado { get; set; }
        [XmlIgnore]
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
                Edad,
                (Telefono ?? "").Sum(c => (int)c),
                (Direccion ?? "").Sum(c => (int)c),
                Eliminado ? 1 : 0
            };
        }
    }
}
