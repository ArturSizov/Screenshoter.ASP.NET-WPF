using DevExpress.Mvvm;
using System.Drawing;
using System.Windows.Input;
using System.Drawing.Imaging;
using System.Windows.Forms; //Добавил для получения полного скрина окна. TODO: другого способа пока не нашел
using System.Collections.ObjectModel;
using Screenshoter.ScreenshoterApplication.Interfaces;
using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using System.IO;
using System;
using Screenshoter.WPF.UI.Converters;

namespace Screenshoter.WPF.UI.ViewModels
{
    public class ScreenshotsWindowViewModel : BindableBase
    {
        private IScreenshoterHttpClient _client;
        private ObservableCollection<ScreenshotLookupDto> _screenshots;
        public bool _isEnabled = false;

        public string Title => "Screenshoter";

        private ScreenshotLookupDto _screenshot = new();
       
        public ScreenshotLookupDto Screenshot { get => _screenshot; set => SetValue(ref _screenshot, value); }

        public ObservableCollection<ScreenshotLookupDto> Screenshots { get => _screenshots; set => SetValue(ref _screenshots, value); }

        public bool IsEnabled { get => _isEnabled; set => SetValue(ref _isEnabled, value); }


        public ScreenshotsWindowViewModel(IScreenshoterHttpClient client) => _client = client;

        public ICommand GetAllScreenshotsAsync => new DelegateCommand(async() =>
        {
            Screenshots = await _client.GetAllScreenshotsAsync();

        });

        /// <summary>
        /// Screenshot Command
        /// </summary>
        public ICommand TakeAScreenshot => new DelegateCommand(() =>
        {
            var bounds = Screen.GetBounds(Point.Empty);

            using (var ms = new MemoryStream())
            {
                using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    var g = Graphics.FromImage(bitmap);
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    Screenshot.Base64 = Convert.ToBase64String(ms.GetBuffer());
                }
            }
            IsEnabled = true;
        });

        /// <summary>
        /// Delete screen command
        /// </summary>
        public ICommand DeleteScreenshot => new DelegateCommand<string>((str) =>
        {
            Screenshot.Base64 = null;

        },(str)=> str != null);

        /// <summary>
        /// Upload to server command
        /// </summary>
        public ICommand UploadToServer => new DelegateCommand<string>((str) =>
        {

        },(str) => str != null);

    }
}
