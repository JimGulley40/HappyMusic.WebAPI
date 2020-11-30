using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HappyMusicConsole.ConsoleServices
{
    public class AlbumServiceAsync
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = "https://localhost:44338/";

        public async Task<Music.Data.Album> GetAlbumAsync()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + "api/album/");
            if (response.IsSuccessStatusCode)
            {
                Music.Data.Album album = await response.Content.ReadAsAsync<Music.Data.Album>();
                return album;
            }
            return null;
        }
    }
}
