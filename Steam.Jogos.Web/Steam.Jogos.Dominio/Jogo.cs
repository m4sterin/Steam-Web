using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Jogos.Dominio
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Desenvolvedora { get; set; }
        public string  EmailDev { get; set; }
        public virtual List<Dlc> Dlcs { get; set; }
    }
}
