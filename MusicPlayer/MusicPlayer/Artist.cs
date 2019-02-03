using System;
using System.Xml.Serialization;

namespace MusicPlayer
{
    public class Artist
    {
        public Artist()
        {

        }
        public string Name;
        public string _Genre;
        public Artist(string name, string genre)
        {
            Name = name;
            _Genre = genre;
        }
    }
}
