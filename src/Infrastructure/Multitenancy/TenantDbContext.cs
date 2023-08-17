using Finbuckle.MultiTenant.Stores;
using GAO.WebApi.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GAO.WebApi.Infrastructure.Multitenancy;

public class TenantDbContext : EFCoreStoreDbContext<GAOTenantInfo>
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GAOTenantInfo>().ToTable("Tenants", SchemaNames.MultiTenancy);
    }
}