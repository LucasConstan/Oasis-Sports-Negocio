using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Servicios;

namespace BLL
{
    public class BLL_Permisos
    {
        private  DAL_Permisos permisoDAL = new DAL_Permisos();




        public bool UsuarioTienePermiso(int usuarioId, string codigoPermiso)
        {
            List<ComponentePermiso> permisos = permisoDAL.ObtenerPermisosDeUsuario(usuarioId);

            foreach (ComponentePermiso permiso in permisos)
            {
                if (permiso.TienePermiso(codigoPermiso))
                    return true;
            }

            return false;
        }

        public List<ComponentePermiso> ObtenerPermisosUsuario(int usuarioId)
        {
            return permisoDAL.ObtenerPermisosDeUsuario(usuarioId);
        }

        public bool TienePermiso(string codigoPermiso, int usuarioId)
        {
            if (SessionManager.GetInstance().Usuario == null)
                return false;

            List<ComponentePermiso> permisos = permisoDAL.ObtenerPermisosDeUsuario(usuarioId);

            foreach (ComponentePermiso permiso in permisos)
            {
                if (permiso.TienePermiso(codigoPermiso))
                    return true;
            }

            return false;
        }

        public void AsignarPermiso(int usuarioId, int permisoId)
        {
            permisoDAL.AsignarPermiso(usuarioId, permisoId);
        }

        public void QuitarPermisoAUsuario(int usuarioId, int permisoId)
        {
            permisoDAL.QuitarPermiso(usuarioId, permisoId);
        }

        public List<ComponentePermiso> ObtenerTodos()
        {
            return permisoDAL.ObtenerTodos();
        }

        public int CrearGrupoPermiso(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debe ingresar un nombre para el grupo.");

            return permisoDAL.CrearGrupoPermiso(nombre);
        }

        public void AgregarPermisoAGrupo(int grupoId, int permisoHijoId)
        {
            if (grupoId == permisoHijoId)
                throw new Exception("Un grupo no puede contenerse a sí mismo.");

            permisoDAL.AgregarPermisoAGrupo(grupoId, permisoHijoId);
        }

        public List<ComponentePermiso> ObtenerPermisosGrupo(int grupoId)
        {
            return permisoDAL.ObtenerPermisosGrupo(grupoId);
        }

        public void ModificarGrupoPermiso(int grupoId, string nombre, List<ComponentePermiso> permisosNuevos)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debe ingresar un nombre para el grupo.");

            
            permisoDAL.ActualizarNombreGrupo(grupoId, nombre);
            permisoDAL.EliminarPermisosDeGrupo(grupoId);

            foreach (ComponentePermiso permiso in permisosNuevos)
                permisoDAL.AgregarPermisoAGrupo(grupoId, permiso.Id);
        }

        public void EliminarGrupoPermiso(int grupoId)
        {
            permisoDAL.EliminarPermisosDeGrupo(grupoId); 
            permisoDAL.EliminarGrupo(grupoId);           
        }

        public bool GrupoPoseeUsuarios(int grupoId)
        {
            return permisoDAL.GrupoPoseeUsuarios(grupoId);
        }

        public bool EsAdministrador(int usuarioId)
        {
            return permisoDAL.EsAdministrador(usuarioId);
        }

        public bool ExisteGrupoConNombre(string nombre, List<ComponentePermiso> permisosExistentes)
        {
            return permisosExistentes
                .OfType<GrupoPermisos>()
                .Any(g => g.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }


    }
}
