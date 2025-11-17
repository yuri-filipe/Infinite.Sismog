using Microsoft.EntityFrameworkCore;
using Sismog.Mappings;

namespace Sismog.Context;

public class InfiniteContext : DbContext
{
    private readonly IConfiguration _configuration;

    public InfiniteContext(DbContextOptions<InfiniteContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var conn = _configuration.GetConnectionString("PostgresConnection");

            if (string.IsNullOrWhiteSpace(conn))
                throw new InvalidOperationException(
                    "String de conexão 'PostgresConnection' não foi encontrada no appsettings.");

            _ = optionsBuilder.UseNpgsql(conn, b =>
            {
                _ = b.MigrationsAssembly(typeof(InfiniteContext).Assembly.FullName);
                _ = b.MigrationsHistoryTable("__EFMigrationsHistory_Sismog", "migrations");
            });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstoqueMapping).Assembly);
    }
}
