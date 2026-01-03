using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.DesignTime;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RestaurantDbContext>
{
    public RestaurantDbContext CreateDbContext(string[] args)
    {
        // Fallback connection string used at design time. You can override
        // it with the environment variable DOTNET_RUNNING_IN_CONTAINER or
        // by passing a different value here.
        var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION")
                               ?? "server=localhost;port=3306;database=AppRestaurant;user=root;password=root1234";

        var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();

        // Use a fixed server version to avoid contacting the database during design-time
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

        optionsBuilder.UseMySql(connectionString, serverVersion);

        return new RestaurantDbContext(optionsBuilder.Options);
    }
}
