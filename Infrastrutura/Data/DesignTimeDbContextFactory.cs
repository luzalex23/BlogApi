using Infrastrutura.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var fileName = Directory.GetCurrentDirectory() + $"/../BlogApi/appsettings.{environmentName}.json";

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");

        var builder = new DbContextOptionsBuilder<AppDbContext>();

        builder.UseNpgsql(connectionString);


        return new AppDbContext(builder.Options);
    }
}
