using Prism.Commands;
using Prism.Mvvm;
using Sceenshoter.Domain.Models;
using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using Screenshoter.ScreenshoterApplication.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Screenshoter.WPF.UI.ViewModels
{
    public class ScreenshotsWindowViewModel : BindableBase
    {
        private IScreenshoterHttpClient _client;
        private ObservableCollection<ScreenshotLookupDto> _screenshots;

        public string Title => "Screenshoter";

        public ObservableCollection<ScreenshotLookupDto> Screenshots { get => _screenshots; set => SetProperty(ref _screenshots, value); }

        public ScreenshotsWindowViewModel(IScreenshoterHttpClient client)
        {
            _client = client;

        }

        public ICommand GetAllScreenshotsAsync => new DelegateCommand(async() =>
        {
            Screenshots = await _client.GetAllScreenshotsAsync();

        });
    }
}
