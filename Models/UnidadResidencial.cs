using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadosHernandez.Models
{
    public class UnidadResidencial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Ciudad Ciudad { get; set; }
        public Boolean Estado { get; set; }
        public ICollection<Apartamento> Apartamentos { get; set; }

    }
}
