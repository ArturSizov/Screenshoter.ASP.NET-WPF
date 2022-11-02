using Screenshoter.WPF.UI.Infrastructure;
using Unity;

namespace Screenshoter.WPF.UI.ViewModels.Locator
{
    public class ViewModelLocator
    {
        public ScreenshotsWindowViewModel ScreenshotsWindowViewModel => RootContainer.Container.Resolve<ScreenshotsWindowViewModel>();
    }
}
