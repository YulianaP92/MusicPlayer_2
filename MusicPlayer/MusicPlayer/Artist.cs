namespace MusicPlayer
{
    class Artist
    {
        public enum Genre
        {
            Rock,
            Pop,
            Classical,
            Blues,
            Dance,
            Hip_hop
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
