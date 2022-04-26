using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using multitenant_poc.Data.Entities;
using multitenant_poc.Models;
using multitenant_poc.Middlewares;
using multitenant_poc.Extensions;

namespace multitenant_poc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly Tenant _tenant;
        private readonly IConfiguration _configuration;
        public DbSet<College> Colleges { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, Tenant tenant) : base(options)
        {
            _tenant = tenant;
            _configuration = configuration;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration,
            ITenantProvider tenantProvider)
            : base(options)
        {
            _configuration = configuration;
            _tenant = tenantProvider.GetTenant();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.SetDatabaseProvider(_tenant);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
