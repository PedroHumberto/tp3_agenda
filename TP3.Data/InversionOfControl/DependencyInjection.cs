
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TP3.Application.Interfaces;
using TP3.Data.Data;
using TP3.Data.Repository;
using TP3.Data.Services;

namespace TP3.Data.InversionofControl
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, ConfigurationManager configuration)
        {
            //DbContext
            services.AddDbContext<FriendsDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            //Interfaces Injections
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IFriendService, FriendService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
