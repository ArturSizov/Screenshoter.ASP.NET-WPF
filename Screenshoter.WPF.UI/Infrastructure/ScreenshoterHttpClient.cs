using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using Screenshoter.ScreenshoterApplication.Interaction.Commands.CreateScreenshot;
using Screenshoter.ScreenshoterApplication.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Screenshoter.WPF.UI.Infrastructure
{
    public class ScreenshoterHttpClient : IScreenshoterHttpClient
    {
        public HttpClient Client { get; }

        private string _url = "https://localhost:7082/api/Screenshot";
        public ScreenshoterHttpClient()
        {
            
            Client = new HttpClient();
            Client.BaseAddress = new Uri(_url);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ObservableCollection<ScreenshotLookupDto>> GetAllScreenshotsAsync()
        {
            var col = JsonConvert.DeserializeObject<ScreenshotList>(await Client.GetStringAsync(_url));

            return new ObservableCollection<ScreenshotLookupDto>(col.Screenshots);  
        }

        /// <summary>
        /// Upload to Server method
        /// </summary>
        /// <returns></returns>
        public async Task UploadToServerAsync(ScreenshotLookupDto screenshot)
        {
            var ceateScreen = new CreateScreenshotDto
            {
                Base64 = screenshot.Base64
            };
            await Client.PostAsJsonAsync(_url, ceateScreen);
        }
    }
}
