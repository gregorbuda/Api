using Infraestructura.Contracts;
using Infraestructura.Models;
using Infraestructura.Repositories;
using Infrastucture.Contracts;
using Infrastucture.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SistemaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"),
                sqlOptions => sqlOptions.EnableRetryOnFailure())
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
