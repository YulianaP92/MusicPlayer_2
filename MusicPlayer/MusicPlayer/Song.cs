using System;

namespace MusicPlayer
{
    class Song:PlayingItem<Song>,IComparable
    {
        public int Duration;
        public string Name;
        public Artist Artist;
        public Album Album;
        public string Lyrics;
        public bool PlayItem = false;
        public bool? _like;

        public Song()
        {

        }
        public Song(int duration, string name, Artist artist, Album album)
        {
            Duration = duration;
            Name = name;
            Artist = artist;
            Album = album;
            Lyrics = "Текст песни";
        }
        public int CompareTo(object obj)
        {
            return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
        }

        public void Deconstruct(out string name, out int year,out int durationMinutes,out int durationSeconds)
        {
            name = Name;
            year = Album.Year;
            durationMinutes = Duration / 60;
            durationSeconds = Duration % 60;           
        }
        public override Song CreateItems()
        {
            var artist = new Artist("Queen", "Rock");
            var album = new Album();
            album.Name = "Bohemian Rhapsody";
            album.Year = 1975;
            var song = new Song()
            {
                Album = album,
                Duration = 100,
                Name = "I want to break free",
                Artist = artist
            };

            return song;
        }
    }
}
