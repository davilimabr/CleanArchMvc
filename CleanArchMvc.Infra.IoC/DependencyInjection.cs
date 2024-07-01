using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseMySql(
                 configuration.GetConnectionString("BancoDeDados"),
                 new MySqlServerVersion(new Version(8, 0, 21)),
                 b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                 ));

            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITrophyRepository, TrophyRepository>();

            return services;
        }
    }
}
