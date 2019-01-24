using System;
using System.Collections.Generic;

namespace MusicPlayer.Extensions
{
    static class SongsExtensions
    {
        public static List<Song> Shuffle(this List<Song> songs)
        {
            Random rnd = new Random();
            for (int i = songs.Count - 1; i >= 0; i--)
            {
                var song = songs[rnd.Next(songs.Count - 1)];
                songs.Remove(song);
                songs.Add(song);
            }
            return songs;
        }
    }
}
