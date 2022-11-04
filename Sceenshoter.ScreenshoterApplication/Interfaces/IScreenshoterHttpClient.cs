using Prism.Commands;
using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Screenshoter.ScreenshoterApplication.Interfaces
{
    public interface IScreenshoterHttpClient
    {
        HttpClient Client { get; }
        Task<ObservableCollection<ScreenshotLookupDto>> GetAllScreenshotsAsync();
    }
}
