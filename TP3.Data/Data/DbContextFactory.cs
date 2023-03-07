using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TP3.Data.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<FriendsDbContext>
    {
        public FriendsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FriendsDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
            return new FriendsDbContext(optionsBuilder.Options);
        }
    }
}
