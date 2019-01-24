using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Visualization
{
    class СapslockSkin : ISkin
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            string newText = text.ToUpper();
            Console.WriteLine(newText);
        }
    }
}
