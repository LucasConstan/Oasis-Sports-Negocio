namespace Entidades
{
    public class Usuario:IVerificable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Bloqueado { get; set; }
        public bool Eliminado { get; set; }
        public int DVH { get; set; }

        public List<ComponentePermiso> Permisos { get; set; } = new List<ComponentePermiso>();

        public int ObtenerIdParaDV() => Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                Id              * 1,
                SumaASCII(Username)  * 3,
                SumaASCII(Password)  * 7,
                (Bloqueado ? 1 : 0)    * 11,
                (Eliminado ? 1 : 0)    * 13
            };
        }

        private int SumaASCII(string texto)
        {
            int suma = 0;
            if (!string.IsNullOrEmpty(texto))
                foreach (char c in texto)
                    suma += (int)c;
            return suma;
        }
    }
}
