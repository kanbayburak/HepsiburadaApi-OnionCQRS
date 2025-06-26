using HepsiburadaApi.Application.Interfaces.Repositories;
using HepsiburadaApi.Application.Interfaces.UnitOfWorks;
using HepsiburadaApi.Persistance.Context;
using HepsiburadaApi.Persistance.Repositories;
using HepsiburadaApi.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiburadaApi.Persistance
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //alttaki kısımda ReadRepository lerin Depency Injection larını gerçeklerştiriyorum
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
