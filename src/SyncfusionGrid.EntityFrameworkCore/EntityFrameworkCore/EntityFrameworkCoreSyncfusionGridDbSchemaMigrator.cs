using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SyncfusionGrid.Data;
using Volo.Abp.DependencyInjection;

namespace SyncfusionGrid.EntityFrameworkCore;

public class EntityFrameworkCoreSyncfusionGridDbSchemaMigrator
    : ISyncfusionGridDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSyncfusionGridDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SyncfusionGridDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SyncfusionGridDbContext>()
            .Database
            .MigrateAsync();
    }
}
