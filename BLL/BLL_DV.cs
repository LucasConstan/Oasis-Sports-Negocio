using DAL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DV
    {
        private DAL_DV dal_DV = new DAL_DV(); 
        private ValidadorDeIntegridad validador = new ValidadorDeIntegridad();

        public bool VerificarIntegridad()
        {
            List<Usuario> usuarios = dal_DV.ObtenerTodosParaVerificar();


            List<IVerificable> objetos = usuarios.Cast<IVerificable>().ToList();
            List<int> dvhsGuardados = usuarios.Select(u => u.DVH).ToList();
            int dvvGuardado = dal_DV.ObtenerDVV();

            return validador.VerificarIntegridad(objetos, dvhsGuardados, dvvGuardado);
        }

        public void RecalcularYGuardar(Usuario u)
        {

            int dvh = validador.CalcularDV(u);
            dal_DV.ActualizarDVH(u.Id, dvh);


            List<Usuario> todos = dal_DV.ObtenerTodosParaVerificar();
            List<IVerificable> objetos = todos.Cast<IVerificable>().ToList();
            int dvv = validador.CalcularDVV(objetos);
            dal_DV.ActualizarDVV(dvv);
        }

        public void InicializarDVs()
        {
            dal_DV.InicializarDVs();
        }

    }
}
