using Prism.Commands;
using Screenshoter.ScreenshoterApplication.Interfaces;
using System.Windows.Input;

namespace Screenshoter.WPF.UI.ViewModels
{
    public class ScreenshotsWindowViewModel
    {
        private IScreenshoterHttpClient _client;

        public string Title => "Screenshoter";

        public ScreenshotsWindowViewModel(IScreenshoterHttpClient client)
        {
            _client = client;
        }

        public ICommand GetAllScreenshots => new DelegateCommand(async () =>
        {
            _client.GetAllScreenshots();
        });
    }
}
