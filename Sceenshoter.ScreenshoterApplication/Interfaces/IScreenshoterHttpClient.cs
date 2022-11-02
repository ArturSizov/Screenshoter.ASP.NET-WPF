using Prism.Commands;
using System.Windows.Input;

namespace Screenshoter.ScreenshoterApplication.Interfaces
{
    public interface IScreenshoterHttpClient
    {
        HttpClient Client { get; }

        void GetAllScreenshots();
    }
}
