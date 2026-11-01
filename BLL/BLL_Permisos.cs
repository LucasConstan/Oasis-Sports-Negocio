using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entidades;
using Servicios;

namespace BLL
{
    public class BLL_Permisos
    {
        private DAL_Permisos permisoDAL = new DAL_Permisos();

        public const string CODIGO_PERFIL_ADMIN = "AD001";
        private static readonly string[] PERMISOS_OBLIGATORIOS_ADMIN = { "SE001", "SE002" };

        public bool TienePermiso(string codigoPermiso)
        {
            Usuario usuario = SessionManager.GetInstance().Usuario;

            return usuario != null && usuario.Perfil != null && usuario.Perfil.TienePermiso(codigoPermiso);
        }

        public void CargarPerfil(Usuario usuario)
        {
            usuario.Perfil = permisoDAL.ObtenerPerfilDeUsuario(usuario.Id);
        }

        public bool EsAdministrador(Usuario usuario)
        {
            return usuario.Perfil != null && usuario.Perfil.Codigo == CODIGO_PERFIL_ADMIN;
        }

        public GrupoPermisos ObtenerPerfilUsuario(int usuarioId)
        {
            return permisoDAL.ObtenerPerfilDeUsuario(usuarioId);
        }

        public List<ComponentePermiso> ObtenerTodos()
        {
            return permisoDAL.ObtenerTodos();
        }

        public List<GrupoPermisos> ObtenerPerfiles()
        {
            return permisoDAL.ObtenerTodos().OfType<GrupoPermisos>().ToList();
        }

        public List<ComponentePermiso> ObtenerArbolesCompletos()
        {
            return permisoDAL.ObtenerArboles();
        }

        public void AsignarPerfil(int usuarioId, ComponentePermiso perfil)
        {
            if (!(perfil is GrupoPermisos))
                throw new Exception("El perfil de un usuario debe ser un permiso compuesto.");

            ValidarCambioDePerfil(usuarioId);

            if (usuarioId == BLLUsuario.ID_USUARIO_ADMIN && perfil.Codigo != CODIGO_PERFIL_ADMIN)
                throw new Exception("El usuario administrador del sistema debe conservar el perfil Administrador.");

            GrupoPermisos perfilActual = permisoDAL.ObtenerPerfilDeUsuario(usuarioId);

            if (perfilActual != null && perfilActual.Id == perfil.Id)
                throw new Exception($"El usuario ya tiene asignado el perfil '{perfil}'.");

            permisoDAL.AsignarPerfil(usuarioId, perfil.Id);
        }

        public void QuitarPerfil(int usuarioId)
        {
            ValidarCambioDePerfil(usuarioId);

            if (usuarioId == BLLUsuario.ID_USUARIO_ADMIN)
                throw new Exception("No se puede quitar el perfil al usuario administrador del sistema.");

            permisoDAL.QuitarPerfil(usuarioId);
        }

        private void ValidarCambioDePerfil(int usuarioId)
        {
            Usuario usuario = new DAL_Usuario().Listar().FirstOrDefault(u => u.Id == usuarioId);

            if (usuario == null || usuario.Eliminado)
                throw new Exception("No se puede modificar el perfil de un usuario inexistente o eliminado.");

            Usuario usuarioSesion = SessionManager.GetInstance().Usuario;

            if (usuarioSesion != null && usuarioSesion.Id == usuarioId)
                throw new Exception("No puede modificar su propio perfil.");
        }

        public void ValidarPermisoParaGrupo(int grupoId, ComponentePermiso permiso, List<ComponentePermiso> permisosDelGrupo)
        {
            ComponentePermiso nuevo = permisoDAL.ObtenerArbolPermiso(permiso.Id);

            if (Contiene(nuevo, grupoId))
                throw new Exception($"No se puede agregar '{nuevo}' porque contiene al grupo que se está editando.");

            foreach (ComponentePermiso existente in permisosDelGrupo)
            {
                if (existente.Id == nuevo.Id)
                    throw new Exception($"'{nuevo}' ya está en el grupo.");

                ComponentePermiso arbolExistente = permisoDAL.ObtenerArbolPermiso(existente.Id);

                if (Contiene(arbolExistente, nuevo.Id))
                    throw new Exception($"'{nuevo}' ya está incluido en '{arbolExistente}', que forma parte del grupo.");

                if (Contiene(nuevo, existente.Id))
                    throw new Exception($"'{nuevo}' ya incluye a '{arbolExistente}', que forma parte del grupo. Quítelo antes de agregarlo.");
            }
        }

        private void ValidarComposicion(int grupoId, List<ComponentePermiso> permisos)
        {
            if (permisos == null || permisos.Count == 0)
                throw new Exception("El grupo debe tener al menos un permiso.");

            List<ComponentePermiso> validados = new List<ComponentePermiso>();

            foreach (ComponentePermiso permiso in permisos)
            {
                ValidarPermisoParaGrupo(grupoId, permiso, validados);
                validados.Add(permiso);
            }
        }

        private bool Contiene(ComponentePermiso componente, int permisoId)
        {
            return componente.Id == permisoId || componente.ObtenerHijos().Any(h => Contiene(h, permisoId));
        }

        private string ValidarCodigo(string codigo, int grupoId)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("Debe ingresar un código para el grupo.");

            codigo = codigo.Trim().ToUpper();

            if (!Regex.IsMatch(codigo, "^[A-Z]{2}[0-9]{3}$"))
                throw new Exception("El código debe tener 2 letras y 3 números (por ejemplo: GE050).");

            bool duplicado = permisoDAL.ObtenerTodos().Any(p =>
                p.Id != grupoId &&
                string.Equals(p.Codigo, codigo, StringComparison.OrdinalIgnoreCase));

            if (duplicado)
                throw new Exception($"Ya existe un permiso con el código '{codigo}'.");

            return codigo;
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

        public int CrearGrupoPermiso(string codigo, string nombre, List<ComponentePermiso> permisos)
        {
            codigo = ValidarCodigo(codigo, 0);
            nombre = ValidarNombreGrupo(nombre, 0);
            ValidarComposicion(0, permisos);

            return permisoDAL.CrearGrupo(codigo, nombre, permisos.Select(p => p.Id).ToList());
        }

        public void ModificarGrupoPermiso(int grupoId, string codigo, string nombre, List<ComponentePermiso> permisos)
        {
            ComponentePermiso grupo = permisoDAL.ObtenerTodos().FirstOrDefault(p => p.Id == grupoId);

            if (!(grupo is GrupoPermisos))
                throw new Exception("El grupo seleccionado no existe.");

            codigo = ValidarCodigo(codigo, grupoId);
            nombre = ValidarNombreGrupo(nombre, grupoId);
            ValidarComposicion(grupoId, permisos);

            if (grupo.Codigo == CODIGO_PERFIL_ADMIN)
                ValidarPerfilAdministrador(codigo, permisos);

            permisoDAL.ModificarGrupo(grupoId, codigo, nombre, permisos.Select(p => p.Id).ToList());

            Usuario usuarioSesion = SessionManager.GetInstance().Usuario;

            if (usuarioSesion != null)
                CargarPerfil(usuarioSesion);
        }

        private void ValidarPerfilAdministrador(string codigo, List<ComponentePermiso> permisos)
        {
            if (codigo != CODIGO_PERFIL_ADMIN)
                throw new Exception("No se puede cambiar el código del perfil Administrador.");

            GrupoPermisos simulado = new GrupoPermisos();

            foreach (ComponentePermiso permiso in permisos)
                simulado.Agregar(permisoDAL.ObtenerArbolPermiso(permiso.Id));

            foreach (string codigoObligatorio in PERMISOS_OBLIGATORIOS_ADMIN)
            {
                if (!simulado.TienePermiso(codigoObligatorio))
                    throw new Exception($"El perfil Administrador debe incluir el permiso '{codigoObligatorio}'.");
            }
        }

        public void EliminarGrupoPermiso(int grupoId)
        {
            ComponentePermiso grupo = permisoDAL.ObtenerTodos().FirstOrDefault(p => p.Id == grupoId);

            if (!(grupo is GrupoPermisos))
                throw new Exception("El grupo seleccionado no existe.");

            if (grupo.Codigo == CODIGO_PERFIL_ADMIN)
                throw new Exception("No se puede eliminar el perfil Administrador.");

            if (permisoDAL.GrupoPoseeUsuarios(grupoId))
                throw new Exception("No se puede eliminar el grupo porque es el perfil de al menos un usuario.");

            if (permisoDAL.GrupoPerteneceAOtroGrupo(grupoId))
                throw new Exception("No se puede eliminar el grupo porque forma parte de otro grupo. Quítelo de ese grupo primero.");

            permisoDAL.EliminarGrupo(grupoId);
        }

        public Dictionary<int, int> ObtenerCantidadUsuariosPorPerfil()
        {
            return permisoDAL.ObtenerCantidadUsuariosPorPerfil();
        }

        public bool GrupoPoseeUsuarios(int grupoId)
        {
            return permisoDAL.GrupoPoseeUsuarios(grupoId);
        }
    }
}
