using Steam.Jogos.Dominio;
using Steam.Jogos.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Jogos.Dados.Entity.TypeConfiguration
{
    class DlcsTypeConfiguration : SteamEntityAbstractConfig<Dlc>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdDlc)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.NomeDlc)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NomeDlc");

            Property(p => p.DescricaoDlc)
                .IsOptional()
                .HasMaxLength(1000)
                .HasColumnName("Descricao");

            Property(p => p.PrecoDlc)
                .IsRequired()
                .HasColumnName("Preco");

        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(p => p.Jogo)
                .WithMany(p => p.Dlcs)
                .HasForeignKey(fk => fk.IdJogo);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.IdDlc);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Dlc");
        }
    }
}
