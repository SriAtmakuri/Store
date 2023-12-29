using FashionStore.Core.Interfaces.Repositories;
using FashionStore.Core.Interfaces.Services;
using FashionStore.Core.Services;
using FashionStore.Infrastructure.Context;
using FashionStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FashionStoreAPI
{
    public static class DependencyInjectionService
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            IConfiguration? configuration1=services.BuildServiceProvider().GetService<IConfiguration>();
            IConfiguration? configuration = configuration1;

            services.AddScoped<IFashionStoreRepository,FashionStoreRepository>();
            services.AddScoped<IFashionStoreService,FashionStoreService>();

            services.AddDbContext<FashionStoreContext>(options =>
            {
                options.UseSqlServer(configuration?.GetConnectionString("FashionStoreConnectionString"));
            });
        }
    }
}
