using Microsoft.EntityFrameworkCore;
using Repository;

namespace Tutorial_OnionArchitecture.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }

        public static void ConfigureSqlDbContext(this IServiceCollection services , IConfiguration configuration )
        {
            services.AddDbContext<RepositoryContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"), builder =>
                {
                    builder.MigrationsAssembly("Tutorial-OnionArchitecture");// migrationın hangi assemblyde olacağını söylüyor.
                });
            });
        }
    }
}
