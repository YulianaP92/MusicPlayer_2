using System;

namespace MusicPlayer
{
   public class Song:PlayingItem<Song>,IComparable
    {
        public string Name;
        public Artist Artist_;
        public Album Album_;
        public bool PlayItem = false;
        public string Path;
        public Song()
        {

        }
        public int CompareTo(object obj)
        {
            return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
        }
    }
}
