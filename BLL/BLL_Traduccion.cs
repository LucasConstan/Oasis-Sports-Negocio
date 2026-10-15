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
            if (string.IsNullOrWhiteSpace(traduccion.Clave))
                throw new Exception("La clave de la traducción es obligatoria.");

            if (string.IsNullOrWhiteSpace(traduccion.Texto))
                throw new Exception("El texto de la traducción es obligatorio.");

            if (traduccion.Clave.Length > 100)
                throw new Exception("La clave no puede superar los 100 caracteres.");

            if (traduccion.Texto.Length > 200)
                throw new Exception("El texto de la traducción no puede superar los 200 caracteres.");

            dal.GuardarOActualizar(traduccion);
        }

        public void CambiarIdioma(int idIdioma)
        {
            List<Traduccion> traducciones = dal.ObtenerPorIdioma(idIdioma);
            LanguageManager.GetInstance().CambiarIdioma(idIdioma, traducciones);
        }
    }
}
