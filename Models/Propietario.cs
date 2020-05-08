using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadosHernandez.Models
{
    public class Propietario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public ICollection<Mercado> Mercados { get; set; }
        public ICollection<Apartamento> Apartamentos { get; set; }

    }
}
