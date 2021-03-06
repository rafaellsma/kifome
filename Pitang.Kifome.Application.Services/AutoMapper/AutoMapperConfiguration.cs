﻿using AutoMapper;
using AutoMapper.Configuration;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Application.Entities.Comment;
using Pitang.Kifome.Application.Entities.Garnish;
using Pitang.Kifome.Application.Entities.User;
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
            configurationExpression.CreateMap<GarnishWithSellerDTO, Garnish>();
            configurationExpression.CreateMap<Meal, MealOutputDTO>();
            configurationExpression.CreateMap<Meal, MealDTO>();
            configurationExpression.CreateMap<GarnishUpdateDTO, Garnish>();
            configurationExpression.CreateMap<CommentInputDTO, Comment>();
            configurationExpression.CreateMap<User, SellerOutputDTO>();
            return configurationExpression;
        }
    }
}
