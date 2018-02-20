using Loteria.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Application.Model.AutoMapper.Profile
{
    public class DomainToViewModelProfile : global::AutoMapper.Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Aposta, ApostaViewModel>();
        }
    }
}
