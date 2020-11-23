using Steam.Jogos.Dados.Entity.Context;
using Steam.Jogos.Dominio;
using Steam.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Steam.Jogos.Repositorios.Entity
{
    public class DlcsRepositorio : RepositorioGenericoEntity<Dlc, int>
    {
        public DlcsRepositorio(JogoDbContext contexto)
           : base(contexto)
        {

        }
        public override List<Dlc> Selecionar()
        {
            return _contexto.Set<Dlc>().Include(p => p.Jogo).ToList();
        }

        public override Dlc SelecionarPorId(int id)
        {
            return _contexto.Set<Dlc>().Include(p => p.Jogo)
                .SingleOrDefault(a => a.IdDlc == id);
        }
    }
}
