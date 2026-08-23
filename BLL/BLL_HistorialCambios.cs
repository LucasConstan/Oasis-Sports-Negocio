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