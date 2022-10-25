using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sceenshoter.Domain.Models;

namespace Screenshoter.Interaction.EntityTypeConfigurations
{
    public class ScreenshoterConfiguration : IEntityTypeConfiguration<Screenshot>
    {
        public void Configure(EntityTypeBuilder<Screenshot> builder)
        {
            builder.HasKey(screenshot => screenshot.Id);
            builder.HasIndex(screenshot => screenshot.Id).IsUnique();
            builder.Property(screenshot => screenshot.Base64);
        }
    }
}
