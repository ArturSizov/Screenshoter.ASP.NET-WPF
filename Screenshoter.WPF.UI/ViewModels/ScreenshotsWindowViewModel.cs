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

namespace Screenshoter.WPF.UI.ViewModels
{
    public class ScreenshotsWindowViewModel : BindableBase
    {
        #region Private property
        private IScreenshoterHttpClient _client;
        private ScreenshotLookupDto _screenshot = new();
        private ObservableCollection<ScreenshotLookupDto> _screenshots;
        private bool _isChecked;
        #endregion

        #region Public property
        public string Title => "Screenshoter";

        public ScreenshotLookupDto Screenshot { get => _screenshot; set => SetValue(ref _screenshot, value); }

        public ObservableCollection<ScreenshotLookupDto> Screenshots { get => _screenshots; set => SetValue(ref _screenshots, value); }

        public bool IsChecked { get => _isChecked; set => SetValue(ref _isChecked, value); }
        #endregion

        #region Ctor
        public ScreenshotsWindowViewModel(IScreenshoterHttpClient client)
        {
            _client = client;

            IsChecked = Convert.ToBoolean(ReadSettings(1));
        }
        #endregion

        #region Commands
        public ICommand GetAllScreenshotsAsync => new DelegateCommand(async() =>
        {
            Screenshots = await _client.GetAllScreenshotsAsync();

        });

        /// <summary>
        /// Screenshot Command
        /// </summary>
        public ICommand TakeAScreenshot => new DelegateCommand(async() =>
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
            if (IsChecked) await _client.UploadToServerAsync(Screenshot);
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
        public ICommand UploadToServer => new DelegateCommand<string>(async(str) =>
        {
            await _client.UploadToServerAsync(Screenshot);

        },(str) => str != null & !IsChecked);

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
