using Entidades;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Servicios;
using System.Windows.Forms;

namespace BLL
{
    public class BLLUsuario
    {
        public DAL_Usuario DAL_Usuario = new DAL_Usuario();

        public List<Usuario> Listar()
        {
            return DAL_Usuario.Listar();
        }

        public void AñadirUsuario(Usuario usuario)
        {
            ValidarDatosUsuario(usuario, 0);
            DAL_Usuario.AñadirUsuario(usuario);
        }

        public void ModificarUsuario(int idUsuario, Usuario usuarioNuevo)
        {
            Usuario usuarioAntes = ObtenerUsuarioActivo(idUsuario);
            ValidarDatosUsuario(usuarioNuevo, idUsuario);

            DAL_Usuario.ModificarUsuario(idUsuario, usuarioNuevo);

            Usuario usuarioDespues = new Usuario
            {
                Id = idUsuario,
                Username = usuarioNuevo.Username,
                Password = encriptador.Encriptar(usuarioNuevo.Password),
                Bloqueado = usuarioAntes.Bloqueado,
                Eliminado = usuarioAntes.Eliminado
            };

            BLL_HistorialCambios bllHistorial = new BLL_HistorialCambios();
            string quienModifica = Servicios.SessionManager.GetInstance().Usuario?.Username ?? "sistema";
            bllHistorial.RegistrarCambiosUsuario(usuarioAntes, usuarioDespues, quienModifica);
        }

        private Usuario ObtenerUsuarioActivo(int idUsuario)
        {
            Usuario usuario = DAL_Usuario.Listar().FirstOrDefault(u => u.Id == idUsuario);

            if (usuario == null || usuario.Eliminado)
                throw new Exception("El usuario no existe o fue eliminado.");

            return usuario;
        }

        private void ValidarDatosUsuario(Usuario usuario, int idUsuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Username))
                throw new Exception("El nombre de usuario es obligatorio.");

            usuario.Username = usuario.Username.Trim();

            if (usuario.Username.Length < 3 || usuario.Username.Length > 50)
                throw new Exception("El nombre de usuario debe tener entre 3 y 50 caracteres.");

            if (!usuario.Username.All(char.IsLetterOrDigit))
                throw new Exception("El nombre de usuario solo puede contener letras y números, sin espacios.");

            if (string.IsNullOrEmpty(usuario.Password))
                throw new Exception("La contraseña es obligatoria.");

            if (usuario.Password.Length < 6)
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");

            if (!usuario.Password.Any(char.IsLetter) || !usuario.Password.Any(char.IsDigit))
                throw new Exception("La contraseña debe contener al menos una letra y un número.");

            bool duplicado = DAL_Usuario.Listar().Any(u =>
                !u.Eliminado &&
                u.Id != idUsuario &&
                u.Username.Trim().Equals(usuario.Username, StringComparison.OrdinalIgnoreCase));

            if (duplicado)
                throw new Exception("Ya existe un usuario con ese nombre.");
        }

        public const int ID_USUARIO_ADMIN = 11;

        public void EliminarUsuario(int idUsuario)
        {
            if (idUsuario == ID_USUARIO_ADMIN)
                throw new Exception("El usuario administrador del sistema no puede eliminarse.");

            if (SessionManager.GetInstance().Usuario?.Id == idUsuario)
                throw new Exception("No puede eliminar al usuario con el que está logueado actualmente.");

            ObtenerUsuarioActivo(idUsuario);

            DAL_Usuario.EliminarUsuario(idUsuario);
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

            string quienModifica = Servicios.SessionManager.GetInstance().Usuario?.Username ?? "sistema";
            new BLL_HistorialCambios().RegistrarCambiosUsuario(usuarioAntes, usuarioDespues, quienModifica);
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
