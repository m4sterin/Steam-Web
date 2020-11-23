using Steam.Jogos.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Steam.Jogos.Web.ViewModels.Jogo
{
    public class JogoViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório")]
        public int Id { get; set; }


        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maximo 100 caracteres")]
        [Display(Name = "Nome do Jogo")]
        public string Nome { get; set; }

        [MaxLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
        [Display(Name = "Descricao do Jogo")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço do jogo é obrigatório")]
        [Display(Name = "Preço do Jogo")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "A desenvolvedora é obrigatorio")]
        [MaxLength(200, ErrorMessage = "A desenvolvedora deve ter no maximo 200 caracteres")]
        [Display(Name = "Desenvolvedora do Jogo")]
        public string Desenvolvedora { get; set; }

        [Required(ErrorMessage ="O E-mail da desenvolvedora é obrigatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail da desenvovedora para contato")]
        [Email(ErrorMessage ="O dominío do e-mail deve ser @dev.com.br")]
        public string EmailDev { get; set; }
    }
}