using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using System.Collections.ObjectModel;

namespace Screenshoter.ScreenshoterApplication.Interfaces
{
    public interface IScreenshoterHttpClient
    {
        Task<ObservableCollection<ScreenshotLookupDto>> GetScreenshotsAsync(DateTime startDate, DateTime endDate);
        Task UploadToServerAsync(ScreenshotLookupDto screenshot);
    }
}
