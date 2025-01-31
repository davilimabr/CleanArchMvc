using CleanArchMvc.Application.Clubs.Get;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseMySql(
                 configuration.GetConnectionString("BancoDeDados"),
                 new MySqlServerVersion(new Version(8, 0, 21)),
                 b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                 ));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(GetClubHandler))));

            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITrophyRepository, TrophyRepository>();

            
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ITrophyService, TrophyService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}
