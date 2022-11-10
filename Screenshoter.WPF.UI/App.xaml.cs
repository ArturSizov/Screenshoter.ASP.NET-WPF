using Screenshoter.ScreenshoterApplication.Common.Mappings;
using Screenshoter.ScreenshoterApplication.Interfaces;
using Screenshoter.WPF.UI.Infrastructure;
using System.Windows;
using Unity;

namespace Screenshoter.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureIOC();
        }
        private void ConfigureIOC()
        {
            RootContainer.Container.RegisterSingleton<IScreenshoterHttpClient, ScreenshoterHttpClient>();
        }
    }
}
