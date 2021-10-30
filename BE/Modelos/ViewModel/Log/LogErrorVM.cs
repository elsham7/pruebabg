using System;

namespace ViewModel.Logs
{
    public class LogErrorVM
    {
        public string Aplicacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }        
        public int IdUsuario { get; set; }
        public string EspacioNombre { get; set; }
        public string Clase { get; set; }
        public string Metodo { get; set; }
        public object Parametro { get; set; }
        public string Error { get; set; }
        public string IpRemota { get; set; }
    }
}
