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
    public class BLL_Evento
    {
        DAL_Evento dalEvento = new DAL_Evento();

        public void RegistrarEvento(Evento evento)
        {
            dalEvento.RegistrarEvento(evento);
        }

        public DataTable ListarEventos()
        {
            return dalEvento.ListarEventos();
        }
    }
}
