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
            using (var player = new Player())
            {
                player.Load(@"D:\Music");               
            }
            
            Console.ReadLine();
        }
       
    }
}
