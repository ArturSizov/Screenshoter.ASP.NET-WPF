using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Sceenshoter.Domain.Models;
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
        private HttpClient _client;

        private string _url = "https://localhost:7082/api/Screenshot";
        public ScreenshoterHttpClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_url);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ObservableCollection<ScreenshotLookupDto>>GetAllScreenshotsAsync()
        {
            var col = JsonConvert.DeserializeObject<ScreenshotList>(await _client.GetStringAsync(_url));

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
            await _client.PostAsJsonAsync(_url, ceateScreen);
        }
    }
}
