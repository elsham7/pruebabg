using System;

namespace ViewModel.Logs
{
    public class LogAccesoVM
    {
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }        
        public int IdUsuario { get; set; }
        public string Modulo { get; set; }
        public string Vista { get; set; }
    }
}
