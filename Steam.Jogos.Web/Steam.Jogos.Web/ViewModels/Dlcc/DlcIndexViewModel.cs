using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Steam.Jogos.Web.ViewModels.Dlcc
{
    public class DlcIndexViewModel
    {
        public long IdDlc { get; set; }

        [Display(Name = "Nome do Jogo")]
        public string NomeJogo { get; set; }

        [Display(Name = "Nome da DLC")]
        public string NomeDlc { get; set; }

        [Display(Name = "Descricao da DLC")]
        public string DescricaoDlc { get; set; }

        [Display(Name = "Preco da DLC")]
        public int PrecoDlc { get; set; }
    }
}