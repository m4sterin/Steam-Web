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
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<JogoViewModel, Jogo>();
            Mapper.CreateMap<DlcViewModel, Dlc>();
        }
    }
}