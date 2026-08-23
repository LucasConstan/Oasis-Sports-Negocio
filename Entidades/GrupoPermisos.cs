using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GrupoPermisos:ComponentePermiso
    {
        public readonly List<ComponentePermiso> _hijos = new List<ComponentePermiso>();

        public void Agregar(ComponentePermiso permiso)
        {
            _hijos.Add(permiso);
        }

        public void Quitar(ComponentePermiso permiso)
        {
            _hijos.Remove(permiso);
        }

        public override bool TienePermiso(string codigoPermiso)
        {
            foreach (ComponentePermiso hijo in _hijos)
            {
                if (hijo.TienePermiso(codigoPermiso))
                    return true;
            }

            return false;
        }

        public override List<ComponentePermiso> ObtenerHijos()
        {
            return _hijos;
        }
    }
}
