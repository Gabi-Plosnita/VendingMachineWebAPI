using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Business.Services;
using VendingMachine.DataAccess.Repository;

namespace VendingMachine.Business.Extensions
{
    public static class ServicesExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRepository, ProductRepositorySqlite>();
        }

    }
}
