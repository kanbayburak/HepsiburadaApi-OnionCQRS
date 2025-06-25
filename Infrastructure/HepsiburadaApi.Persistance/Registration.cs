using HepsiburadaApi.Application.Interfaces;
using HepsiburadaApi.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Persistance
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //alttaki kısımda ReadRepository lerin Depency Injection larını gerçeklerştiriyorum
            services.AddScoped(typeof(IReadRepository<>), typeof(IReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(IWriteRepository<>)); 
        }
    }
}
