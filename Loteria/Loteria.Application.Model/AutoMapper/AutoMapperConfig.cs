using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Loteria.Application.Model.AutoMapper.Profile;

namespace Loteria.Application.Model.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelProfile());
                cfg.AddProfile(new ViewModelToDomainProfile());
            });
        }
    }
}
