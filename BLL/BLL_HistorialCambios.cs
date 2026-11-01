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
        DAL_Usuario dalUsuario = new DAL_Usuario();

        public void RegistrarVersion(int idUsuario, string operacion)
        {
            Usuario usuario = dalUsuario.Listar().FirstOrDefault(u => u.Id == idUsuario);

            if (usuario == null)
                throw new Exception("No se encontró el usuario para registrar el historial.");

            dal.Registrar(new HistorialCambio
            {
                IdUsuario = usuario.Id,
                Username = usuario.Username,
                Password = usuario.Password,
                Bloqueado = usuario.Bloqueado,
                Eliminado = usuario.Eliminado,
                Operacion = operacion,
                UsuarioCambio = Servicios.SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Fecha = DateTime.Now
            });
        }

        public List<HistorialCambio> ListarHistorial(int idUsuario)
        {
            return dal.ListarPorUsuario(idUsuario);
        }

        public string DescribirCambios(HistorialCambio version, HistorialCambio? anterior)
        {
            if (anterior == null)
                return "Versión inicial";

            List<string> cambios = new List<string>();

            if (version.Username != anterior.Username)
                cambios.Add($"Nombre: {anterior.Username} → {version.Username}");

            if (version.Password != anterior.Password)
                cambios.Add("Contraseña modificada");

            if (version.Bloqueado != anterior.Bloqueado)
                cambios.Add($"Bloqueado: {(anterior.Bloqueado ? "Sí" : "No")} → {(version.Bloqueado ? "Sí" : "No")}");

            if (version.Eliminado != anterior.Eliminado)
                cambios.Add($"Eliminado: {(anterior.Eliminado ? "Sí" : "No")} → {(version.Eliminado ? "Sí" : "No")}");

            return cambios.Count == 0 ? "Sin cambios" : string.Join("; ", cambios);
        }

        public void RestaurarVersion(int idUsuario, int idHistorial)
        {
            HistorialCambio version = dal.ListarPorUsuario(idUsuario).FirstOrDefault(h => h.IdHistorial == idHistorial);

            if (version == null)
                throw new Exception("La versión seleccionada no existe.");

            List<Usuario> usuarios = dalUsuario.Listar();
            Usuario actual = usuarios.FirstOrDefault(u => u.Id == idUsuario);

            if (actual == null)
                throw new Exception("El usuario no existe.");

            if (Servicios.SessionManager.GetInstance().Usuario?.Id == idUsuario)
                throw new Exception("No puede restaurar el usuario con el que está logueado actualmente.");

            if (actual.Username == version.Username &&
                actual.Password == version.Password &&
                actual.Bloqueado == version.Bloqueado &&
                actual.Eliminado == version.Eliminado)
                throw new Exception("El usuario ya se encuentra en el estado de esa versión.");

            if (idUsuario == BLLUsuario.ID_USUARIO_ADMIN && (version.Bloqueado || version.Eliminado))
                throw new Exception("El usuario administrador del sistema no puede quedar bloqueado ni eliminado.");

            if (!version.Eliminado)
            {
                bool enUso = usuarios.Any(u =>
                    !u.Eliminado &&
                    u.Id != idUsuario &&
                    u.Username.Trim().Equals(version.Username.Trim(), StringComparison.OrdinalIgnoreCase));

                if (enUso)
                    throw new Exception($"No se puede restaurar: el nombre '{version.Username}' ya lo usa otro usuario.");
            }

            Usuario restaurado = new Usuario
            {
                Id = idUsuario,
                Username = version.Username,
                Password = version.Password,
                Bloqueado = version.Bloqueado,
                Eliminado = version.Eliminado
            };

            dalUsuario.Restaurar(restaurado);
            new BLL_DV().RecalcularYGuardar(restaurado);

            RegistrarVersion(idUsuario, $"Restauración (versión del {version.Fecha:dd/MM/yyyy HH:mm:ss})");
        }
    }
}
