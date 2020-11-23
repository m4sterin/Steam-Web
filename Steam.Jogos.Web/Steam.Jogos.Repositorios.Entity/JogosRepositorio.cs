using Steam.Jogos.Dados.Entity.Context;
using Steam.Jogos.Dominio;
using System.Data.Entity;
using Steam.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Jogos.Repositorios.Entity
{
    public class JogosRepositorio : RepositorioGenericoEntity<Jogo, int>
    {
        public JogosRepositorio(JogoDbContext contexto)
           : base(contexto)
        {

        }

        public override List<Jogo> Selecionar()
        {
            return _contexto.Set<Jogo>().Include(p => p.Dlcs).ToList();
        }

        public override Jogo SelecionarPorId(int id)
        {
            return _contexto.Set<Jogo>().Include(p => p.Dlcs)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}
