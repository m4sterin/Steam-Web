using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Jogos.Dominio
{
    public class Dlc
    {
        public long IdDlc { get; set; }
        public string NomeDlc { get; set; }
        public string DescricaoDlc { get; set; }
        public int PrecoDlc { get; set; }
        public virtual Jogo Jogo { get; set; }
        public int IdJogo { get; set; }


    }
}
