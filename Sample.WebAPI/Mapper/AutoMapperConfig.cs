using AutoMapper;
using Sample.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebAPI.Mapper
{
    public class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppUser, DAL.Entities.AppUser>().ReverseMap();

                cfg.CreateMap<Login, BLL.AuthenticationModels.Login>().ReverseMap();

                cfg.CreateMap<Registration, BLL.AuthenticationModels.Registration>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
