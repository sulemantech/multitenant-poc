using System.Collections.Generic;
using multitenant_poc.Models;

namespace multitenant_poc.Middlewares
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
        IEnumerable<Tenant> AllTenants { get; }
    }
}
