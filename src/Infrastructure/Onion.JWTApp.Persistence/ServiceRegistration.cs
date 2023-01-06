using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.JWTApp.Application.Interfaces;
using Onion.JWTApp.Persistence.Context;
using Onion.JWTApp.Persistence.Repositories;

namespace Onion.JWTApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JwtContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("local"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
