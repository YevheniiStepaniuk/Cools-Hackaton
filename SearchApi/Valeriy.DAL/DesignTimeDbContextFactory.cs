using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Valeriy.Domain.Extensions;

namespace Valeriy.DAL
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<ValeriyDbContext>
    {
        public ValeriyDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var connstr = config.GetCurrenConnectionString();

            if (connstr.IsNullOrWhiteSpace())
            {
                throw new InvalidOperationException("Could not find a connection string named '(default)'.");
            }

            return Create(connstr);
        }

        private ValeriyDbContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Argument is null or empty.", nameof(connectionString));
            }

            var optionsBuilder = new DbContextOptionsBuilder<ValeriyDbContext>();

            optionsBuilder.UseSqlite(connectionString);

            return new ValeriyDbContext(optionsBuilder.Options);
        }

    }
}