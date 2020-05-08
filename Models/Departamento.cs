using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadosHernandez.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PaisID { get; set; }
        public Pais Pais { get; set; }
        public Boolean Estado { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; }

    }
}
