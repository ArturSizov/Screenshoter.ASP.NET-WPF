using Newtonsoft.Json;
using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using Screenshoter.ScreenshoterApplication.Interfaces;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<ObservableCollection<ScreenshotLookupDto>> GetAllScreenshotsAsync()
        {
            var col = JsonConvert.DeserializeObject<ScreenshotList>(await Client.GetStringAsync("Screenshot"));

            return  new ObservableCollection<ScreenshotLookupDto>(col.Screenshots);  
        }
    }
}
