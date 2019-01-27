//A.L1.Player1/1.
using System;
using System.Collections.Generic;
using System.Linq;
using MusicPlayer.Visualization;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            var listSongs=player.Load(@"D:\Music");
            // player.Clear(listSongs);
            player.SaveAsPlaylist(listSongs);
            listSongs = player.LoadPlaylist();
            Console.ReadLine();
        }
       
    }
}
