using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.PlayerStarted += Show;
            player.SongStartedEvent += TraceInfo;
            player.SongsListChangedEvent += TraceInfo;
            player.PlayerVolumeChange += Show;
            player.PlayerStopped += Show;
            player.PlayerLocked += Show;
            player.PlayerUnlocked += Show;

            VisualizerAsync(player);
            if (Player.flag)
            {
                player.Play();
            }           
            Console.ReadLine();
        }
        //LA8.Player2/2**. AsyncCommands.
        public static async void VisualizerAsync(Player player)
        {
            Console.WriteLine("Select the required command");
            var variant = Console.ReadLine();
            switch (variant)
            {
                case "1":
                   await Task.Run(()=>player.Start());
                    break;                    
                case "2":
                    await Task.Run(() => player.Stop());
                    break;
                case "3":
                    await Task.Run(() => player.Load(Console.ReadLine()));//@"D:\Music"
                    break;
                default:
                    VisualizerAsync(player);
                    break;
            }
        }
        private static void TraceInfo(List<Song> songs, Song playingSong, bool locked, int volume)
        {
            Console.Clear();// remove old data
            
            //Render the list of songs
            foreach (var song in songs)
            {
                if (playingSong == song)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(song.Name);//Render current song in other color.
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(song.Name);
                }
            }

            //Render status bar
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Volume is: {volume}. Locked: {locked}");
            Console.ResetColor();
        }
        private static void Show(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
