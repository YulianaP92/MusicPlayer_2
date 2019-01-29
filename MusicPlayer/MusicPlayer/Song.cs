using System;

namespace MusicPlayer
{
    [Serializable]
   public class Song:PlayingItem<Song>,IComparable
    {
        public int Duration;
        public string Name;
        [NonSerialized]
        public Artist Artist_;
        [NonSerialized]
        public Album Album_;
        [NonSerialized]
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
            Artist_ = artist;
            Album_ = album;
            Lyrics = "Текст песни";
        }


        public int CompareTo(object obj)
        {
            return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
        }
    }
}
