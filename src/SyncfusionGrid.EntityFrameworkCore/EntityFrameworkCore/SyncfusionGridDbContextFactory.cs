using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SyncfusionGrid.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SyncfusionGridDbContextFactory : IDesignTimeDbContextFactory<SyncfusionGridDbContext>
{
    public SyncfusionGridDbContext CreateDbContext(string[] args)
    {
        SyncfusionGridEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SyncfusionGridDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SyncfusionGridDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SyncfusionGrid.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
