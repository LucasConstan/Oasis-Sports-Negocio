using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class ComponentePermiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }


        public abstract bool TienePermiso(string codigoPermiso);
        public abstract List<ComponentePermiso> ObtenerHijos();
    }
}
