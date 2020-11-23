using Steam.Jogos.Dados.Entity.TypeConfiguration;
using Steam.Jogos.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Jogos.Dados.Entity.Context
{
   public class JogoDbContext : DbContext
    {
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Dlc> Dlc { get; set; }

        public JogoDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JogosTypeConfiguration());
            modelBuilder.Configurations.Add(new DlcsTypeConfiguration());
        }
    }
}
