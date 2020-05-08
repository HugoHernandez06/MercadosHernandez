using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MercadosHernandez.Models;

namespace MercadosHernandez.Data
{
    public class MercadosHernandezContext : DbContext
    {
        public MercadosHernandezContext(DbContextOptions<MercadosHernandezContext> options)
            : base(options)
        {
        }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<UnidadResidencial> UnidadResisdenciales { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Compra> Compras { get; set; }

    }
}
