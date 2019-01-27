using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
   public class Album
    {
        public string Name;
        public int Year;

        public Album()
        {

        }
        public Album(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
