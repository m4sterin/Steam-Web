using Steam.Jogos.Dominio;
using Steam.Jogos.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Jogos.Dados.Entity.TypeConfiguration
{
    class JogosTypeConfiguration : SteamEntityAbstractConfig<Jogo>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome");

            Property(p => p.Descricao)
                .IsOptional()
                .HasMaxLength(1000)
                .HasColumnName("Descricao");

            Property(p => p.Preco)
                .IsRequired()
                .HasColumnName("Preco");

            Property(p => p.Desenvolvedora)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("Desenvolvedora");

            Property(p => p.EmailDev)
                .IsRequired()
                .HasColumnName("EmailDev");

        }

        protected override void ConfigurarChaveEstrangeira()
        {       
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Jogo");
        }
    }
}
