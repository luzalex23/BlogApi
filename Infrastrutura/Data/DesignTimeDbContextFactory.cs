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

        // Verifica se o ambiente está definido; se não, define como Development por padrão
        if (string.IsNullOrEmpty(environmentName))
        {
            environmentName = "Development";
        }

        var fileName = Directory.GetCurrentDirectory() + $"/../BlogApi/appsettings.{environmentName}.json";
        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));

        builder.UseNpgsql(connectionString, options =>
        {
            options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            options.MigrationsAssembly("Infrastrutura.Data");
            options.MigrationsHistoryTable("__EFMigrationsHistory");
        });

        return new AppDbContext(builder.Options);
    }
}
