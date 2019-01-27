using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicPlayer
{
   public abstract class PlayingItem<T>
    {
        public int Duration;
        public string Name;
        public Artist Artist;
        public Album Album;
        public string Lyrics;
        public bool PlayItem = false;
        public bool? _like;

        public void Like()
        {
            _like = true;
        }

        public void Dislike()
        {
            _like = false;
        }
    }
}
