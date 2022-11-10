using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using Screenshoter.ScreenshoterApplication.Interaction.Commands.CreateScreenshot;
using System.Collections.ObjectModel;

namespace Screenshoter.ScreenshoterApplication.Interfaces
{
    public interface IScreenshoterHttpClient
    {
        HttpClient Client { get; }
        Task<ObservableCollection<ScreenshotLookupDto>> GetAllScreenshotsAsync();
        Task UploadToServerAsync(ScreenshotLookupDto screenshot);
    }
}
