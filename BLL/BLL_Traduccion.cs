using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class BLL_Traduccion
    {
        DAL_Traduccion dal = new DAL_Traduccion();

        public List<Traduccion> ObtenerPorIdioma(int idIdioma)
        {
            return dal.ObtenerPorIdioma(idIdioma);
        }

        public List<string> ObtenerTodasLasClaves()
        {
            return dal.ObtenerTodasLasClaves();
        }

        public void GuardarOActualizar(Traduccion traduccion)
        {
            dal.GuardarOActualizar(traduccion);
        }

        public void CambiarIdioma(int idIdioma)
        {
            List<Traduccion> traducciones = dal.ObtenerPorIdioma(idIdioma);
            LanguageManager.GetInstance().CambiarIdioma(idIdioma, traducciones);
        }
    }
}
