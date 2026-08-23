namespace Entidades
{
    public class Idioma
    {
        public int IdIdioma { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
