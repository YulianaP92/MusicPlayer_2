using System;
using System.Collections.Generic;

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

            player.Start();
            player.Load(@"D:\Music");
            player.Play();
            player.VolumeUp();

            player.Play();
            player.Lock();

            player.Play();
            player.Unlock();

            Console.ReadLine();
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
