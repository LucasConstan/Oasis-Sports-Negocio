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

        public List<string> ObtenerTablasAlteradas()
        {
            List<string> tablas = new List<string>();

            if (!VerificarIntegridad()) tablas.Add("Usuarios");
            if (!new BLL_Equipo().VerificarIntegridad_348LC()) tablas.Add("Equipos");
            if (!new BLL_Jugador().VerificarIntegridad_348LC()) tablas.Add("Jugadores");
            if (!new BLL_Torneo().VerificarIntegridad_348LC()) tablas.Add("Torneos");
            if (!new BLL_Inscripcion().VerificarIntegridad_348LC()) tablas.Add("Inscripciones");
            if (!new BLL_Partido().VerificarIntegridad_348LC()) tablas.Add("Partidos");

            return tablas;
        }

        public void RecalcularTablas(List<string> tablas)
        {
            foreach (string tabla in tablas)
            {
                switch (tabla)
                {
                    case "Usuarios": InicializarDVs(); break;
                    case "Equipos": new BLL_Equipo().RecalcularTodos_348LC(); break;
                    case "Jugadores": new BLL_Jugador().RecalcularTodos_348LC(); break;
                    case "Torneos": new BLL_Torneo().RecalcularTodos_348LC(); break;
                    case "Inscripciones": new BLL_Inscripcion().RecalcularTodos_348LC(); break;
                    case "Partidos": new BLL_Partido().RecalcularTodos_348LC(); break;
                }
            }
        }

    }
}
