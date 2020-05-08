using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadosHernandez.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public double Cantidad { get; set; }
        public int MercadoID { get; set; }
        public int ProductoID { get; set; }
        public Mercado Mercado { get; set; }
        public Producto Producto { get; set; }

    }
}
