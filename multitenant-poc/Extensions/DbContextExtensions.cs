using Microsoft.EntityFrameworkCore;
using multitenant_poc.Models;
using System;
using System.IO;

namespace multitenant_poc.Extensions
{
    public static class DbContextExtensions
    {
        public static DbContextOptionsBuilder SetDatabaseProvider(this DbContextOptionsBuilder optionsBuilder, ITenant tenant)
        {
            switch (tenant.Provider)
            {
                case DatabaseProvider.MSSQLSERVER:
                    optionsBuilder.UseSqlServer(ReconstructSqliteConnectionString(tenant.ConnectionString));
                    break;
                default:
                    throw new Exception(string.Format("Database provider: {0} not supported", tenant.Provider));
            }
            return optionsBuilder;
        }

        public static string ReconstructSqliteConnectionString(string connectionString)
        {
            var reconstructedConnectionString = string.Empty;
            var connStringSplitted = connectionString.Split("=");
            reconstructedConnectionString = connStringSplitted.Length > 1
                ? string.Format("{0}={1}", connStringSplitted[0],
                    Path.Combine(Directory.GetCurrentDirectory(), "db", connStringSplitted[1]))
                : string.Format("DataSource={0}", connStringSplitted[0]);

            return reconstructedConnectionString;
        }
    }

}
