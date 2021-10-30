namespace ViewModel.General
{
    public class EstadoTransaccionVM
    {
        
        public bool ExiteError { get; set; }
        public bool ExiteRegistro { get; set; }
        public bool ExiteAdvertencia { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }
    }
}
