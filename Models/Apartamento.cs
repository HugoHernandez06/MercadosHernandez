using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadosHernandez.Models
{
    public class Apartamento
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Bloque { get; set; }
        public int UnidadResidencialID { get; set; }
        public int PropietarioID { get; set; }
        public UnidadResidencial Unidad { get; set; }
        public Propietario Propietario { get; set; }
        public Boolean Estado { get; set; }
        

    }
}
