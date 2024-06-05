using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MEInsight.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        private const string _databaseConnection = "DefaultConnection";
        private const string _migrationAssembly = "MEInsight.Migrations";

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            var connectionString = configuration.GetConnectionString(_databaseConnection);
            var serviceProvider = new ServiceCollection().AddHttpContextAccessor().BuildServiceProvider();
            var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(connectionString, x => x.MigrationsAssembly(_migrationAssembly));

            return new ApplicationDbContext(builder.Options, httpContextAccessor);
        }
    }
}
