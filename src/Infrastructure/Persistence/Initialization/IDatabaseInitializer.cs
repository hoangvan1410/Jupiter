using GAO.WebApi.Infrastructure.Multitenancy;

namespace GAO.WebApi.Infrastructure.Persistence.Initialization;

internal interface IDatabaseInitializer
{
    Task InitializeDatabasesAsync(CancellationToken cancellationToken);
    Task InitializeApplicationDbForTenantAsync(GAOTenantInfo tenant, CancellationToken cancellationToken);
}