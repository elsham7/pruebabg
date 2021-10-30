using System.Collections.Generic;

namespace ViewModel.Venta
{
    public class CarritoVM
    {
        public List<ItemCarritoVM> Items { get; set; } = new List<ItemCarritoVM>();
        public decimal Total { get; set; }
    }
}
