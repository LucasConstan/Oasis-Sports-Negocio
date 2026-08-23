using DAL;
using Entidades;

namespace BLL
{
    public class BLL_Idioma
    {
        DAL_Idioma dal = new DAL_Idioma();

        public List<Idioma> Listar()
        {
            return dal.Listar();
        }

        public void Agregar(Idioma idioma)
        {
            if (string.IsNullOrWhiteSpace(idioma.Nombre))
                throw new Exception("El nombre del idioma no puede estar vacío.");
            //
            dal.Agregar(idioma);
        }
    }
}
