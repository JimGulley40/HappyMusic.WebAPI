using MusicModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicConsole
{
    public class ProgramUI
    {
        HttpClient httpClient = new HttpClient();
        string baseUrl = "https://localhost:44338/";
        bool KeepRunning = true;

        public void Menu()
        {
            while (KeepRunning)
            {

            Console.WriteLine(<);
                string userInput = Console.ReadLine();
                
                switch(userInput)
                {
                    case "1":
                        // method here
                        break;
                    case "2":
                        ViewAlbums();
                        break;
                    case "3":
                        KeepRunning = false;
                        break;

                }
            }
        }
        public void ViewAlbums()
        {
            Console.Clear();
            Task<HttpResponseMessage> result = httpClient.GetAsync(baseUrl + "api/album");
            HttpResponseMessage response = result.Result;
            if (response.IsSuccessStatusCode)
            {
                List<AlbumListItem> albumList = httpClient.GetAsync(baseUrl + "api/album").Result.Content.ReadAsAsync<List<AlbumListItem>>().Result;
                foreach(AlbumListItem item in albumList)
                {
                    Console.WriteLine(item.ArtistName, item.ReleaseDate, item.Songs, item.Title);
                }
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
