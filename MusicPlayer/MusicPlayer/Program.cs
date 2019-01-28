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

            player.Load(@"D:\Music");
            player.SaveAsPlaylist(@"D:/ListSongs.xml");
            player.LoadPlaylist(@"D:/ListSongs.xml");
            //playler.Play();
            Console.ReadLine();
        }
       
    }
}
