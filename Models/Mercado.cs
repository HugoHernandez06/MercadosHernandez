using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadosHernandez.Models
{
    public class Mercado
    {
        public int Id { get; set; }
        public string Fecha_Creacion { get; set; }
        public int PropietarioID { get; set; }
        public Propietario Propietario { get; set; }
        public string Estado { get; set; }
        public ICollection<Compra> Compras { get; set; }

    }
}
