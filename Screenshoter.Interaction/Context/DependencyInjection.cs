using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sceenshoter.Application.Interfaces;

namespace Screenshoter.Interaction.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ScreenshotsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IScreenshoterDbContext>(provider => provider.GetService<ScreenshotsDbContext>());
            return services;
        }
    }
}
