using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class PlayerException:Exception
    {
        public PlayerException(string message):base(message)
        {

        }
    }
}
