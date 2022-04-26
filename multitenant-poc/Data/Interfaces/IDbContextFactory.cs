using Microsoft.Extensions.Configuration;
using multitenant_poc.Data;
using multitenant_poc.Models;

namespace multitenant_poc.Data.Interfaces
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext(Tenant tenant, IConfiguration confifuration);
    }
}
