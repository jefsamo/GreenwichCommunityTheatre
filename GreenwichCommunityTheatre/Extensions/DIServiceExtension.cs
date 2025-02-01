using GreenwichCommunityTheatre.Infrastructure.Context;
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
        }
    }
}
