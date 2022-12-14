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
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Point = System.Drawing.Point;
using Screenshoter.WPF.UI.Infrastructure;

namespace Screenshoter.WPF.UI.ViewModels
{
    public class ScreenshotsWindowViewModel : BindableBase
    {
        #region Private property
        private IScreenshoterHttpClient _client;
        private ScreenshotLookupDto _screenshot = new();
        private ScreenshotLookupDto _selectedScreenshot = new();
        private ObservableCollection<ScreenshotLookupDto> _screenshots;
        private bool _isChecked;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        #endregion

        #region Public property
        public string Title => "Screenshoter";

        public ScreenshotLookupDto Screenshot { get => _screenshot; set => SetValue(ref _screenshot, value); }
        public ScreenshotLookupDto SelectedScreenshot { get => _selectedScreenshot; set => SetValue(ref _selectedScreenshot, value); }
        public ObservableCollection<ScreenshotLookupDto> Screenshots { get => _screenshots; set => SetValue(ref _screenshots, value); }
        public bool IsChecked { get => _isChecked; set => SetValue(ref _isChecked, value); }
        public DateTime StartDate { get => _startDate; set => SetValue(ref _startDate, value); }
        public DateTime EndDate { get => _endDate; set => SetValue(ref _endDate, value); }
        #endregion

        #region Ctor
        public ScreenshotsWindowViewModel(IScreenshoterHttpClient client)
        {
            _client = client;

            IsChecked = Convert.ToBoolean(ReadSettings(1));

            HotKeyManager.RegisterHotKey(Keys.N, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
        }
        #endregion

        #region Commands
        public ICommand GetScreenshotsAsyncCommand => new DelegateCommand(async () =>
        {
            Screenshots = await _client.GetScreenshotsAsync(StartDate, EndDate);

        });

        /// <summary>
        /// Screenshot Command
        /// </summary>
        public ICommand TakeAScreenshotAsycnCommand => new DelegateCommand<FrameworkElement>(async (frameworkElement) =>
        {
            TakeAScreenshot();
        });

        

        /// <summary>
        /// Delete screen command as DB
        /// </summary>
        public ICommand DeleteScreenshotAsyncCommand => new DelegateCommand<ScreenshotLookupDto>(async (screen) =>
        {
            await _client.DeleteScreenshotServerAsync(SelectedScreenshot);

            Screenshots = await _client.GetScreenshotsAsync(StartDate, EndDate);

        }, (scr) => scr?.Base64 != null);

        /// <summary>
        /// Delete screen command 
        /// </summary>
        public ICommand DeleteScreenshotCommand => new DelegateCommand<string>((str) =>
        {
            Screenshot.Base64 = null;

        }, (str) => str != null);

        /// <summary>
        /// Upload to server command
        /// </summary>
        public ICommand UploadToServerAsyncCommand => new DelegateCommand<string>(async (str) =>
        {
            await _client.UploadToServerAsync(Screenshot);

        }, (str) => str != null & !IsChecked);

        /// <summary>
        /// Save status command
        /// </summary>
        public ICommand IsCheckedCommand => new DelegateCommand(() =>
        {
            WriteSettings(_isChecked);
        });

        #endregion

        #region Methods
        /// <summary>
        /// Take a screenshot method 
        /// </summary>
        private void TakeAScreenshot()
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
                    Screenshot.CreateDate = DateTime.Now;
                }
            }

            if (IsChecked) _client.UploadToServerAsync(Screenshot);
        }
        /// <summary>
        /// Keyboard Shortcut Event Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotKeyManager_HotKeyPressed(object? sender, HotKeyEventArgs e)
        {
            TakeAScreenshot();
        }
        /// <summary>
        ///  Write to language settings file
        /// </summary>
        /// <param name="isCheked"></param>
        private void WriteSettings(bool isCheked)
        {
            var path = "Settings.txt";
            using (StreamWriter writer = new StreamWriter(Path.GetFullPath(path)))
            {
                writer.WriteLine(isCheked);
            }
        }

        /// <summary>
        /// Read to settings file
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        private string ReadSettings(int lineNumber)
        {
            var path = "Settings.txt";

            string line = null;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    for (int i = 0; i < lineNumber; ++i)
                    {
                        line = reader.ReadLine();
                    }
                }
                return line;
            };
        }
        #endregion
    }
}
