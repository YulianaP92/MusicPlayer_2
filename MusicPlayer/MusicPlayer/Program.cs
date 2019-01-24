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
            var song = new Song();
            List<Song> songs = player.GetItems();
            player.TraceInfo(songs);

            Console.ReadLine();
        }
       
    }
}
