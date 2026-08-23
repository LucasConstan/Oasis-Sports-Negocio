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
            DAL_Usuario.AñadirUsuario(usuario);
        }

        public void ModificarUsuario(int idUsuario, Usuario usuarioNuevo)
        {
            
            Usuario usuarioAntes = DAL_Usuario.ObtenerPorUsuario(
                DAL_Usuario.Listar().FirstOrDefault(u => u.Id == idUsuario)?.Username ?? ""
            );          
            DAL_Usuario.ModificarUsuario(idUsuario, usuarioNuevo);         
            if (usuarioAntes != null)
            {
                usuarioNuevo.Id = idUsuario;
                BLL_HistorialCambios bllHistorial = new BLL_HistorialCambios();
                string quienModifica = Servicios.SessionManager.GetInstance().Usuario?.Username ?? "sistema";
                bllHistorial.RegistrarCambiosUsuario(usuarioAntes, usuarioNuevo, quienModifica);
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            DAL_Usuario.EliminarUsuario(idUsuario);
        }

        private Encriptacion encriptador = new Encriptacion();

        private int intentosFallidos = 0;

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
                intentosFallidos++;

                if (intentosFallidos >= 3)
                {
                    DAL_Usuario.BloquearUsuario(usuario.Id);
                    throw new Exception("Usuario bloqueado por exceso de intentos.");
                }

                throw new Exception(
                    $"Usuario o contraseña incorrectos. Intento {intentosFallidos}/3");
            }

            intentosFallidos = 0;

            return usuario;
        }

       
    }
}
