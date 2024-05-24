using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentProject.Domain.Repositories;
using StudentProject.Infrastructure.Persistance;
using StudentProject.Infrastructure.Persistance.Repositories;

namespace StudentProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddDbContextPool<ApplicationDbContext>(builder =>
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            });

            return services;
        }
    }
}
