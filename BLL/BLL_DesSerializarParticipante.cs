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
    public class BLL_DesSerializarParticipante
    {
        public List<Participante> DesSerializar_348LC(string ruta_348LC)
        {
            XmlSerializer serializador_348LC = new XmlSerializer(typeof(List<Participante>));
            using (StreamReader lector_348LC = new StreamReader(ruta_348LC))
            {
                return (List<Participante>)serializador_348LC.Deserialize(lector_348LC);
            }
        }
    }
}
