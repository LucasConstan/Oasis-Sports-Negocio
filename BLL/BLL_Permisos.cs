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
            Usuario usuario = new DAL_Usuario().Listar().FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null || usuario.Eliminado)
                throw new Exception("No se pueden asignar permisos a un usuario inexistente o eliminado.");

            List<ComponentePermiso> permisosUsuario = permisoDAL.ObtenerPermisosDeUsuario(usuarioId);
            ValidarSinRedundancia(permisoId, permisosUsuario, "al usuario");

            permisoDAL.AsignarPermiso(usuarioId, permisoId);
        }

        public void ValidarPermisoParaGrupo(int grupoId, ComponentePermiso permiso, List<ComponentePermiso> permisosDelGrupo)
        {
            if (Contiene(permisoDAL.ObtenerArbolPermiso(permiso.Id), grupoId))
                throw new Exception($"No se puede agregar '{permiso.Nombre}'.");

            ValidarSinRedundancia(permiso.Id, permisosDelGrupo, "al grupo");
        }

        private void ValidarSinRedundancia(int permisoId, List<ComponentePermiso> existentes, string destino)
        {
            ComponentePermiso nuevo = permisoDAL.ObtenerArbolPermiso(permisoId);

            foreach (ComponentePermiso existente in existentes)
            {
                if (existente.Id == nuevo.Id)
                    throw new Exception($"El permiso '{nuevo.Nombre}' ya está asignado {destino}.");

                ComponentePermiso arbolExistente = permisoDAL.ObtenerArbolPermiso(existente.Id);

                if (Contiene(arbolExistente, nuevo.Id))
                    throw new Exception($"'{nuevo.Nombre}' ya está incluido en el grupo '{arbolExistente.Nombre}' asignado {destino}.");

                if (Contiene(nuevo, existente.Id))
                    throw new Exception($"El grupo '{nuevo.Nombre}' ya incluye '{arbolExistente.Nombre}', que está asignado {destino}. Quítelo antes de agregar el grupo.");
            }
        }

        private bool Contiene(ComponentePermiso componente, int permisoId)
        {
            return componente.Id == permisoId || componente.ObtenerHijos().Any(h => Contiene(h, permisoId));
        }

        public const int ID_PERFIL_ADMIN = 6;

        public void QuitarPermisoAUsuario(int usuarioId, int permisoId)
        {
            if (usuarioId == BLLUsuario.ID_USUARIO_ADMIN && permisoId == ID_PERFIL_ADMIN)
                throw new Exception("No se puede quitar el perfil Admin al usuario administrador del sistema.");

            permisoDAL.QuitarPermiso(usuarioId, permisoId);
        }

        public List<ComponentePermiso> ObtenerTodos()
        {
            return permisoDAL.ObtenerTodos();
        }

        public int CrearGrupoPermiso(string nombre)
        {
            nombre = ValidarNombreGrupo(nombre, 0);
            return permisoDAL.CrearGrupoPermiso(nombre);
        }

        public void AgregarPermisoAGrupo(int grupoId, int permisoHijoId)
        {
            if (Contiene(permisoDAL.ObtenerArbolPermiso(permisoHijoId), grupoId))
                throw new Exception("No se puede agregar el permiso.");

            permisoDAL.AgregarPermisoAGrupo(grupoId, permisoHijoId);
        }

        public List<ComponentePermiso> ObtenerPermisosGrupo(int grupoId)
        {
            return permisoDAL.ObtenerPermisosGrupo(grupoId);
        }

        private string ValidarNombreGrupo(string nombre, int grupoId)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debe ingresar un nombre para el grupo.");

            nombre = nombre.Trim();

            if (nombre.Length < 3 || nombre.Length > 100)
                throw new Exception("El nombre del grupo debe tener entre 3 y 100 caracteres.");

            bool duplicado = permisoDAL.ObtenerTodos().Any(p =>
                p.Id != grupoId &&
                p.Nombre.Trim().Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (duplicado)
                throw new Exception($"Ya existe un permiso o grupo con el nombre '{nombre}'.");

            return nombre;
        }

        public void ModificarGrupoPermiso(int grupoId, string nombre, List<ComponentePermiso> permisosNuevos)
        {
            nombre = ValidarNombreGrupo(nombre, grupoId);

            if (permisosNuevos.Count == 0)
                throw new Exception("El grupo debe tener al menos un permiso.");

            List<ComponentePermiso> validados = new List<ComponentePermiso>();
            foreach (ComponentePermiso permiso in permisosNuevos)
            {
                ValidarPermisoParaGrupo(grupoId, permiso, validados);
                validados.Add(permiso);
            }

            permisoDAL.ActualizarNombreGrupo(grupoId, nombre);
            permisoDAL.EliminarPermisosDeGrupo(grupoId);

            foreach (ComponentePermiso permiso in permisosNuevos)
                permisoDAL.AgregarPermisoAGrupo(grupoId, permiso.Id);
        }

        public void EliminarGrupoPermiso(int grupoId)
        {
            if (permisoDAL.GrupoPoseeUsuarios(grupoId))
                throw new Exception("No se puede eliminar el grupo porque hay usuarios que lo tienen asignado.");

            if (permisoDAL.GrupoPerteneceAOtroGrupo(grupoId))
                throw new Exception("No se puede eliminar el grupo porque forma parte de otro grupo. Quítelo de ese grupo primero.");

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
