using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    interface ISkin
    {
        void Clear();//очистка экрана плеера
        void Render(string text);//вывод строки на экран плеера
    }
}
