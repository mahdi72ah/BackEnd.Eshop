using Angular.Eshop.DataLayer.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Angular.Eshop.Core.Utilities.Extentions.Conection
{
    public static class ConnectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service,
          IConfiguration configuration)
        {
            service.AddDbContext<AngularEshopdbContext>(options =>
            {
                var connectionString = "ConnectionStrings:AngularEshopConnection:Development";
                options.UseSqlServer(configuration[connectionString]);
            });

            return service;
        }
    }
}
