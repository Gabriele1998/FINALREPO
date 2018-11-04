using Microsoft.EntityFrameworkCore;
using Models.Tabelle;
namespace Models
{
    public class AnagraficaContext : DbContext
    {
        public DbSet<Anagrafica> Anagrafica { get; set; }
        public DbSet<Contatti> Contatti { get; set; }
        public DbSet<Indirizzi> Indirizzi { get; set; }
        public DbSet<TipoAnagrafica> TipoAnagrafica { get; set; }
        public DbSet<TipoContatto> TipoContatto { get; set; }
        public DbSet<TipoIndirizzo> TipoIndirizzo { get; set; }
        public AnagraficaContext(DbContextOptions<AnagraficaContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=anagrafica.db");
        }
    }
}