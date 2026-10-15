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

            idioma.Nombre = idioma.Nombre.Trim();

            if (idioma.Nombre.Length < 3 || idioma.Nombre.Length > 50)
                throw new Exception("El nombre del idioma debe tener entre 3 y 50 caracteres.");

            if (!idioma.Nombre.All(c => char.IsLetter(c) || c == ' '))
                throw new Exception("El nombre del idioma solo puede contener letras y espacios.");

            if (dal.Listar().Any(i => i.Nombre.Trim().Equals(idioma.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ya existe un idioma con ese nombre.");

            dal.Agregar(idioma);
        }
    }
}
