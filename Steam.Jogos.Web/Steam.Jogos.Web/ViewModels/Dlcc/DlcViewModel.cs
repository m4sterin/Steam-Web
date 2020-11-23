using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Steam.Jogos.Web.ViewModels.Dlcc
{
    public class DlcViewModel
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public long IdDlc { get; set; }

        [Display(Name = "Nome do Jogo")]
        [Required(ErrorMessage = "Selecione um Jogo")]
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O Nome da DLC é obrigatório")]
        [Display(Name = "Nome da DLC")]
        public string NomeDlc { get; set; }

        [MaxLength(300, ErrorMessage = "O nome deve ter no máximo 300 caracteres")]
        [Display(Name = "Descricao da DLC")]
        public string DescricaoDlc { get; set; }

        [Required(ErrorMessage = "O Preco é obrigatório")]
        [Display(Name = "Preco da DLC")]
        public int PrecoDlc { get; set; }
    }
}