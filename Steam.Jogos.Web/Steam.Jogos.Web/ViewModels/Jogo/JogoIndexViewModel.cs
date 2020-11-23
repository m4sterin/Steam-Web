using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Steam.Jogos.Web.ViewModels.Jogo
{
    public class JogoIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Jogo")]
        public string Nome { get; set; }

        [Display(Name = "Descricao do Jogo")]
        public string Descricao { get; set; }

        [Display(Name = "Preço do Jogo")]
        public float Preco { get; set; }

        [Display(Name = "Desenvolvedora do Jogo")]
        public string Desenvolvedora { get; set; }

        [Display(Name = "E-mail da Desenvovedora do Game")]
        public string EmailDev { get; set; }
    }
}