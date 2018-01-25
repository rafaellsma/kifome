using AutoMapper;
using AutoMapper.Configuration;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Services.AutoMapper
{
    public class AutoMapperConfiguration
    {

        public MapperConfigurationExpression Configuration()
        {
            MapperConfigurationExpression configurationExpression = new MapperConfigurationExpression();
            configurationExpression.CreateMap<Garnish, GarnishOutputDTO>();
            configurationExpression.CreateMap<GarnishInputDTO, Garnish>();
            configurationExpression.CreateMap<Meal, MealOutputDTO>();
            configurationExpression.CreateMap<Meal, MealDTO>();
            return configurationExpression;
        }
    }
}
