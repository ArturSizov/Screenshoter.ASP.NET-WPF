namespace Screenshoter.Interaction.Context
{
    public class DbInitializer
    {
        public static void Initialize(ScreenshotsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
