using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadosHernandez.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public Boolean Estado { get; set; }
        public ICollection<Compra> Compras { get; set; }
        


    }
}
