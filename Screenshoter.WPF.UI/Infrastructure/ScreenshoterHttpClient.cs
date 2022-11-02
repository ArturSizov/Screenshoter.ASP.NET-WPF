using Prism.Commands;
using Screenshoter.ScreenshoterApplication.Interfaces;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace Screenshoter.WPF.UI.Infrastructure
{
    public class ScreenshoterHttpClient : IScreenshoterHttpClient
    {
        public HttpClient Client { get; }

        public ScreenshoterHttpClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new System.Uri("https://localhost:7082/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async void GetAllScreenshots()
        {
            var res = await Client.GetStringAsync("Screenshot");
    }
}
