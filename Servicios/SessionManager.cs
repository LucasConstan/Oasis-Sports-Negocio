namespace Servicios;
    using Entidades;

    public class SessionManager
    {
        private static SessionManager instance;
        private static readonly object padlock = new object();

        private Usuario usuarioActual;

        private SessionManager() { }

        public static SessionManager GetInstance()
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new SessionManager();

                return instance;
            }
        }

        public Usuario Usuario
        {
            get { return usuarioActual; }
        }

        public void Login(Usuario usuario)
        {
            usuarioActual = usuario;
        }

        public void Logout()
        {
            usuarioActual = null;
        }

        public bool IsLogged()
        {
            return usuarioActual != null;
        }

    
}

