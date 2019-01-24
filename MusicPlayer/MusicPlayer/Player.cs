using System;
using System.Collections.Generic;
using System.Linq;
using MusicPlayer.Extensions;
using MusicPlayer.Visualization;

namespace MusicPlayer
{
   class Player:GenericPlayer<Song>
    {
        
        public List<Song> Song;
        public override List<Song> GetItems()
        {
            List<Artist> artists = new List<Artist>()
            {
                new Artist("Queen", "Rock"),
                new Artist("Marilyn Manson", "Rock"),
                new Artist("Maroon 5", "Rock"),
                new Artist("Nirvana", "Rock"),
                new Artist("Green Day","Rock")
            };
            List<Album> album = new List<Album>()
            {
                new Album("Queen II", 1974),
                new Album("Sweet Dreams", 2000),
                new Album("Makes Me Wonder", 2008),
                new Album("Nevermind", 1991),
                new Album("Greatest", 2017)
            };

            List<Song> songs = new List<Song>()
            {
                new Song(120, "I want to break free", artists[0], album[0]),
                new Song(130, "Bowling for Columbine", artists[1], album[1]),
                new Song(200, "Makes Me Wonder", artists[2], album[2]),
                new Song(240, "Flash Gordon", artists[3], album[3]),
                new Song(300, "Windowpane", artists[4], album[4])
            };
            return songs;
        }
        public override string SkinString(Song song)
        {
            string list;
            list = $"Name Artist: {song.Artist.Name}\n" +
            $"Name song: {song.Name}\n" +
            $"Genre: {song.Artist._Genre}\n" +
            $"Album: {song.Album.Name}\n" +
            $"Year of album release: {song.Album.Year}\n" +
            $"Duration song: {song.Duration} second\n" +
            $"Lyrics: {song.Lyrics}\n\n";
            return list;
        }

        public void Shuffle()
        {
            Song.Shuffle();
        }

        public void Sort()
        {
            Song.Sort();
        }
        public override List<Song> FilterByGenre(List<Song> songs, string genry)
        {
            var sortedName = songs.Where(u => u.Artist._Genre == genry).OrderBy(u => u.Name).ToList();
            return sortedName;
        }
    }
}
