﻿using HepsiburadaApi.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace HepsiburadaApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
