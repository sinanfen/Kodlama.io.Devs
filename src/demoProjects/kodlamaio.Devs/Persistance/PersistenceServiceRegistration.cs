using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaDevsConnectionString")));
            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();

            return services;
        }
    }
}
