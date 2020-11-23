using AutoMapper;
using Steam.Jogos.Dominio;
using Steam.Jogos.Web.ViewModels.Dlcc;
using Steam.Jogos.Web.ViewModels.Jogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Jogos.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Jogo, JogoIndexViewModel>()
                .ForMember(p => p.Nome, opt =>
                {
                    opt.MapFrom(src =>
                        string.Format("{0} {1}", src.Nome, src.Preco.ToString())
                        );
                });
            Mapper.CreateMap<Jogo, JogoViewModel>();


            Mapper.CreateMap<Dlc, DlcIndexViewModel>()
            .ForMember(p => p.NomeJogo, opt =>
             {
                 opt.MapFrom(src =>
                     src.Jogo.Nome
                     );
             });
            Mapper.CreateMap<Dlc, DlcViewModel>();
        }
    }
}