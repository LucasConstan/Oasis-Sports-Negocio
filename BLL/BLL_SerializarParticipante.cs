using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    public class BLL_SerializarParticipante
    {
        public void Serializar_348LC(List<Participante> participantes_348LC, string ruta_348LC)
        {
            XmlSerializer serializador_348LC = new XmlSerializer(typeof(List<Participante>));
            using (StreamWriter escritor_348LC = new StreamWriter(ruta_348LC))
            {
                serializador_348LC.Serialize(escritor_348LC, participantes_348LC);
            }
        }
    }
}
