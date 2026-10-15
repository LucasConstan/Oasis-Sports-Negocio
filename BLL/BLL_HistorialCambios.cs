using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class BLL_HistorialCambios
    {
        DAL_HistorialCambios dal = new DAL_HistorialCambios();

      
        public void RegistrarCambiosUsuario(Usuario antes, Usuario despues, string usuarioQueModifica)
        {
            if (antes.Username != despues.Username)
            {
                dal.Registrar(new HistorialCambio
                {
                    EntidadId = antes.Id,
                    NombreEntidad = "Usuario",
                    NombreCampo = "Username",
                    ValorAnterior = antes.Username,
                    ValorNuevo = despues.Username,
                    Usuario = usuarioQueModifica,
                    Fecha = DateTime.Now
                });
            }

            if (antes.Password != despues.Password)
            {
                dal.Registrar(new HistorialCambio
                {
                    EntidadId = antes.Id,
                    NombreEntidad = "Usuario",
                    NombreCampo = "Password",
                    ValorAnterior = "***",   
                    ValorNuevo = "***",
                    Usuario = usuarioQueModifica,
                    Fecha = DateTime.Now
                });
            }

            if (antes.Bloqueado != despues.Bloqueado)
            {
                dal.Registrar(new HistorialCambio
                {
                    EntidadId = antes.Id,
                    NombreEntidad = "Usuario",
                    NombreCampo = "Bloqueado",
                    ValorAnterior = antes.Bloqueado ? "Sí" : "No",
                    ValorNuevo = despues.Bloqueado ? "Sí" : "No",
                    Usuario = usuarioQueModifica,
                    Fecha = DateTime.Now
                });
            }
        }

        public DataTable ObtenerHistorialUsuario(int idUsuario)
        {
            return dal.ObtenerPorEntidad(idUsuario, "Usuario");
        }

        public void RestaurarCampo(int idUsuario, string campo, string valorAnterior, string usuarioQueRestaura)
        {
            List<Usuario> usuarios = new DAL_Usuario().Listar();
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);

            if (usuario == null || usuario.Eliminado)
                throw new Exception("El usuario no existe o fue eliminado.");

            if (campo == "Username")
            {
                if (string.IsNullOrWhiteSpace(valorAnterior))
                    throw new Exception("No se puede restaurar un nombre de usuario vacío.");

                bool enUso = usuarios.Any(u =>
                    !u.Eliminado &&
                    u.Id != idUsuario &&
                    u.Username.Trim().Equals(valorAnterior.Trim(), StringComparison.OrdinalIgnoreCase));

                if (enUso)
                    throw new Exception($"No se puede restaurar: el nombre '{valorAnterior}' ya lo usa otro usuario.");
            }

            if (campo == "Bloqueado" && idUsuario == BLLUsuario.ID_USUARIO_ADMIN && valorAnterior == "Sí")
                throw new Exception("No se puede bloquear al usuario administrador del sistema.");

            DAL_DV dal_DV = new DAL_DV();
            dal_DV.RestaurarCampo(idUsuario, campo, valorAnterior);

           
            dal.Registrar(new HistorialCambio
            {
                EntidadId = idUsuario,
                NombreEntidad = "Usuario",
                NombreCampo = campo,
                ValorAnterior = "(restauración)",
                ValorNuevo = valorAnterior,
                Usuario = usuarioQueRestaura,
                Fecha = DateTime.Now
            });
        }
    }
}