using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenwichCommunityTheatre.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GctDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<GctDbContext>().AddDefaultTokenProviders().AddUserStore<UserStore<User,Role,GctDbContext,string>>().AddRoleStore<RoleStore<Role, GctDbContext, string>>();
        }
    }
}
