using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Venta
{
    public class ItemCarritoVM
    {
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public short Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
