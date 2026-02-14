using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vektorel.Northwind.Data.Context;

namespace Vektorel.Northwind.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNorthwind(this IServiceCollection services)
    {
        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlServer("Server=127.0.0.1,10001;Database=Northwind;User ID=sa;Password=1q2w3e4R!;TrustServerCertificate=True");
        });
        return services;
    }
}
