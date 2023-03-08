using Microsoft.EntityFrameworkCore;
using WebapiCelulares.Entities;

namespace WebapiCelulares

{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Celular> Celulares { get; set; }
        public DbSet<Marca> Marcas { get; set; }

    }
}
