using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sismog.Context;

namespace Sismog.Postgres;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<InfiniteContext>
{
    public InfiniteContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<InfiniteContext>();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("PostgresConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Connection string 'PostgresConnection' não encontrada.");


        _ = builder.UseNpgsql(connectionString,
            npgsql =>
            {
                _ = npgsql.MigrationsAssembly("Sismog");
                _ = npgsql.MigrationsHistoryTable("__EFMigrationsHistory_Sismog", "migrations");
            });

        return new InfiniteContext(builder.Options, configuration);
    }
}