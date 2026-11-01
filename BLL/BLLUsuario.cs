using Entidades;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Servicios;

namespace BLL
{
    public class BLLUsuario
    {
        public DAL_Usuario DAL_Usuario = new DAL_Usuario();

        public List<Usuario> Listar()
        {
            return DAL_Usuario.Listar();
        }

        public List<Usuario> ListarActivos()
        {
            return DAL_Usuario.Listar().Where(u => !u.Eliminado).OrderBy(u => u.Username).ToList();
        }

        public void AñadirUsuario(Usuario usuario)
        {
            ValidarDatosUsuario(usuario, 0, true);
            DAL_Usuario.AñadirUsuario(usuario);

            Usuario creado = DAL_Usuario.ObtenerPorUsuario(usuario.Username);
            if (creado != null)
            {
                new BLL_DV().RecalcularYGuardar(creado);
                new BLL_HistorialCambios().RegistrarVersion(creado.Id, "Alta");
            }
        }

        public void ModificarUsuario(int idUsuario, Usuario usuarioNuevo)
        {
            ObtenerUsuarioActivo(idUsuario);

            bool cambiaContraseña = !string.IsNullOrEmpty(usuarioNuevo.Password);
            ValidarDatosUsuario(usuarioNuevo, idUsuario, cambiaContraseña);

            if (cambiaContraseña)
                DAL_Usuario.ModificarUsuario(idUsuario, usuarioNuevo);
            else
                DAL_Usuario.ModificarNombreUsuario(idUsuario, usuarioNuevo.Username);

            new BLL_DV().RecalcularYGuardar(ObtenerUsuarioActivo(idUsuario));

            Usuario usuarioSesion = SessionManager.GetInstance().Usuario;
            if (usuarioSesion != null && usuarioSesion.Id == idUsuario)
                usuarioSesion.Username = usuarioNuevo.Username;

            new BLL_HistorialCambios().RegistrarVersion(idUsuario, "Modificación");
        }

        private Usuario ObtenerUsuarioActivo(int idUsuario)
        {
            Usuario usuario = DAL_Usuario.Listar().FirstOrDefault(u => u.Id == idUsuario);

            if (usuario == null || usuario.Eliminado)
                throw new Exception("El usuario no existe o fue eliminado.");

            return usuario;
        }

        private void ValidarDatosUsuario(Usuario usuario, int idUsuario, bool validarContraseña)
        {
            if (string.IsNullOrWhiteSpace(usuario.Username))
                throw new Exception("El nombre de usuario es obligatorio.");

            usuario.Username = usuario.Username.Trim();

            if (usuario.Username.Length < 3 || usuario.Username.Length > 50)
                throw new Exception("El nombre de usuario debe tener entre 3 y 50 caracteres.");

            if (!usuario.Username.All(char.IsLetterOrDigit))
                throw new Exception("El nombre de usuario solo puede contener letras y números, sin espacios.");

            if (validarContraseña)
                ValidarFormatoContraseña(usuario.Password);

            bool duplicado = DAL_Usuario.Listar().Any(u =>
                !u.Eliminado &&
                u.Id != idUsuario &&
                u.Username.Trim().Equals(usuario.Username, StringComparison.OrdinalIgnoreCase));

            if (duplicado)
                throw new Exception("Ya existe un usuario con ese nombre.");
        }

        private void ValidarFormatoContraseña(string contraseña)
        {
            if (string.IsNullOrEmpty(contraseña))
                throw new Exception("La contraseña es obligatoria.");

            if (contraseña.Length < 6)
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");

            if (!contraseña.Any(char.IsLetter) || !contraseña.Any(char.IsDigit))
                throw new Exception("La contraseña debe contener al menos una letra y un número.");
        }

        public void CambiarContraseña(int idUsuario, string contraseñaActual, string contraseñaNueva, string confirmacion)
        {
            if (string.IsNullOrEmpty(contraseñaActual))
                throw new Exception("Debe ingresar la contraseña actual.");

            if (string.IsNullOrEmpty(contraseñaNueva))
                throw new Exception("Debe ingresar la nueva contraseña.");

            if (string.IsNullOrEmpty(confirmacion))
                throw new Exception("Debe confirmar la nueva contraseña.");

            Usuario usuario = ObtenerUsuarioActivo(idUsuario);

            if (usuario.Bloqueado)
                throw new Exception("El usuario se encuentra bloqueado.");

            if (usuario.Password != encriptador.Encriptar(contraseñaActual))
                throw new Exception("La contraseña actual es incorrecta.");

            if (contraseñaNueva != confirmacion)
                throw new Exception("La nueva contraseña y su confirmación no coinciden.");

            if (contraseñaNueva == contraseñaActual)
                throw new Exception("La nueva contraseña debe ser distinta de la actual.");

            ValidarFormatoContraseña(contraseñaNueva);

            DAL_Usuario.CambiarContraseña(idUsuario, contraseñaNueva);

            usuario.Password = encriptador.Encriptar(contraseñaNueva);
            new BLL_DV().RecalcularYGuardar(usuario);

            new BLL_HistorialCambios().RegistrarVersion(idUsuario, "Cambio de contraseña");
        }

        public const int ID_USUARIO_ADMIN = 11;

        public void EliminarUsuario(int idUsuario)
        {
            if (idUsuario == ID_USUARIO_ADMIN)
                throw new Exception("El usuario administrador del sistema no puede eliminarse.");

            if (SessionManager.GetInstance().Usuario?.Id == idUsuario)
                throw new Exception("No puede eliminar al usuario con el que está logueado actualmente.");

            Usuario usuario = ObtenerUsuarioActivo(idUsuario);

            DAL_Usuario.EliminarUsuario(idUsuario);

            usuario.Eliminado = true;
            new BLL_DV().RecalcularYGuardar(usuario);
            intentosFallidos.Remove(idUsuario);

            new BLL_HistorialCambios().RegistrarVersion(idUsuario, "Baja");
        }

        public void BloquearUsuario(int idUsuario)
        {
            if (idUsuario == ID_USUARIO_ADMIN)
                throw new Exception("El usuario administrador del sistema no puede bloquearse.");

            if (SessionManager.GetInstance().Usuario?.Id == idUsuario)
                throw new Exception("No puede bloquear al usuario con el que está logueado actualmente.");

            Usuario usuario = ObtenerUsuarioActivo(idUsuario);

            if (usuario.Bloqueado)
                throw new Exception("El usuario ya se encuentra bloqueado.");

            DAL_Usuario.BloquearUsuario(idUsuario);

            usuario.Bloqueado = true;
            new BLL_DV().RecalcularYGuardar(usuario);
            intentosFallidos.Remove(idUsuario);

            new BLL_HistorialCambios().RegistrarVersion(idUsuario, "Bloqueo manual");
        }

        public void DesbloquearUsuario(int idUsuario)
        {
            Usuario usuarioAntes = DAL_Usuario.Listar().FirstOrDefault(u => u.Id == idUsuario);

            if (usuarioAntes == null || usuarioAntes.Eliminado)
                throw new Exception("El usuario no existe.");

            if (!usuarioAntes.Bloqueado)
                throw new Exception("El usuario no se encuentra bloqueado.");

            DAL_Usuario.DesbloquearUsuario(idUsuario);

            Usuario usuarioDespues = new Usuario
            {
                Id = usuarioAntes.Id,
                Username = usuarioAntes.Username,
                Password = usuarioAntes.Password,
                Bloqueado = false,
                Eliminado = usuarioAntes.Eliminado
            };

            new BLL_DV().RecalcularYGuardar(usuarioDespues);
            intentosFallidos.Remove(idUsuario);

            new BLL_HistorialCambios().RegistrarVersion(idUsuario, "Desbloqueo");
        }

        private Encriptacion encriptador = new Encriptacion();

        private static Dictionary<int, int> intentosFallidos = new Dictionary<int, int>();

        public Usuario ValidarUsuario(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Debe ingresar un usuario.");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Debe ingresar una contraseña.");


            

            Usuario usuario = DAL_Usuario.ObtenerPorUsuario(username);

            if (usuario == null)
                throw new Exception("Usuario o contraseña incorrectos.");

            if (usuario.Bloqueado)
                throw new Exception("El usuario se encuentra bloqueado.");

            string hash = encriptador.Encriptar(password);

            if (usuario.Password != hash)
            {
                intentosFallidos.TryGetValue(usuario.Id, out int intentos);
                intentos++;
                intentosFallidos[usuario.Id] = intentos;

                if (intentos >= 3)
                {
                    intentosFallidos.Remove(usuario.Id);
                    DAL_Usuario.BloquearUsuario(usuario.Id);
                    usuario.Bloqueado = true;
                    new BLL_DV().RecalcularYGuardar(usuario);
                    new BLL_HistorialCambios().RegistrarVersion(usuario.Id, "Bloqueo por intentos fallidos");
                    throw new Exception("Usuario bloqueado por exceso de intentos.");
                }

                throw new Exception(
                    $"Usuario o contraseña incorrectos. Intento {intentos}/3");
            }

            intentosFallidos.Remove(usuario.Id);

            return usuario;
        }

       
    }
}
