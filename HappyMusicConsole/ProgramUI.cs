using HappyMusicConsole.ConsoleServices;
using Music.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMusicConsole
{
    public class ProgramUI
    {
        bool KeepRunning = true;
        public void Menu()
        {
            while (KeepRunning)
            {


                AlbumServiceAsync asyncAlbumService = new AlbumServiceAsync();
                Album album = asyncAlbumService.GetAlbumAsync().Result;


                Console.Clear();

                Console.WriteLine("==================================================================================================");
                Console.WriteLine("Welcome to HappyMusic! ");
                Console.WriteLine("Press 1 to see all albums!");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine(album.Title);
                        Console.WriteLine(album.Songs);
                        Console.WriteLine(album.Genre);
                        break;
                    case "2":
                        KeepRunning = false;
                        break;
                }
            }
        }
    }
}
