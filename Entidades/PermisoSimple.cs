using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PermisoSimple:ComponentePermiso
    {

        public override bool TienePermiso(string codigoPermiso)
        {
            return Codigo == codigoPermiso;
        }

        public override List<ComponentePermiso> ObtenerHijos()
        {
            return new List<ComponentePermiso>();
        }
    }
}
