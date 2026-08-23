using Entidades;
using Microsoft.Data.SqlClient;

namespace Servicios
{
    public class LanguageManager
    {
        
        private static LanguageManager? instancia;
        private static readonly object candado = new object();

        private LanguageManager() { }

        public static LanguageManager GetInstance()
        {
            lock (candado)
            {
                if (instancia == null)
                    instancia = new LanguageManager();
                return instancia;
            }
        }


        
        private int idIdiomaActual = 1;
        private List<Traduccion> traducciones = new List<Traduccion>();
        private List<IObserverIdioma> observadores = new List<IObserverIdioma>();

        public int IdIdiomaActual => idIdiomaActual;

        public void Agregar(IObserverIdioma observador)
        {
            if (!observadores.Contains(observador))
                observadores.Add(observador);
        }

        public void Quitar(IObserverIdioma observador)
        {
            observadores.Remove(observador);
        }

        private void Notificar()
        {
            foreach (var obs in observadores.ToList())
                obs.ActualizarIdioma();
        }

        public void CambiarIdioma(int idIdioma, List<Traduccion> traducciones)
        {
            idIdiomaActual = idIdioma;
            this.traducciones = traducciones;
            Notificar();
        }



        public string ObtenerTexto(string clave)
        {
            var t = traducciones.FirstOrDefault(x => x.Clave == clave);
            return t != null ? t.Texto : clave;
        }


        public void TraducirControles(Control formulario)
        {
            TraducirRecursivo(formulario.Controls);
        }

        private void TraducirRecursivo(System.Windows.Forms.Control.ControlCollection controles)
        {
            foreach (System.Windows.Forms.Control c in controles)
            {
                string texto = ObtenerTexto(c.Name);
                if (texto != c.Name)
                    c.Text = texto;

                if (c.Controls.Count > 0)
                    TraducirRecursivo(c.Controls);

                if (c is System.Windows.Forms.MenuStrip ms)
                    TraducirMenuItems(ms.Items);

                if (c is System.Windows.Forms.ToolStrip ts)
                    TraducirMenuItems(ts.Items);
            }
        }

        private void TraducirMenuItems(System.Windows.Forms.ToolStripItemCollection items)
        {
            foreach (System.Windows.Forms.ToolStripItem item in items)
            {
                string texto = ObtenerTexto(item.Name);
                if (texto != item.Name)
                    item.Text = texto;

                if (item is System.Windows.Forms.ToolStripMenuItem mi && mi.DropDownItems.Count > 0)
                    TraducirMenuItems(mi.DropDownItems);
            }
        }
    }
}
