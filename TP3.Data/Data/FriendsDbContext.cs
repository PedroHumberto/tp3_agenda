using Microsoft.EntityFrameworkCore;
using TP3.Domain;

namespace TP3.Data.Data
{
    public class FriendsDbContext : DbContext
    {
        public FriendsDbContext(DbContextOptions<FriendsDbContext> options) : base(options)
        {
                
        }

        public DbSet<Friend> Friends { get; set; }
    }
}
