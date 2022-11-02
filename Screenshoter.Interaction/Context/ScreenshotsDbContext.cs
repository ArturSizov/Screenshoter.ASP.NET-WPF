using Microsoft.EntityFrameworkCore;
using Sceenshoter.ScreenshoterApplication.Interfaces;
using Sceenshoter.Domain.Models;
using Screenshoter.Interaction.EntityTypeConfigurations;

namespace Screenshoter.Interaction.Context
{
    public class ScreenshotsDbContext : DbContext, IScreenshoterDbContext
    {
        public DbSet<Screenshot> Screenshots { get; set; }

        public ScreenshotsDbContext(DbContextOptions<ScreenshotsDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ScreenshoterConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
