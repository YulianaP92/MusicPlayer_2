using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Media;

namespace MusicPlayer
{
    public abstract class GenericPlayer<T> where T : PlayingItem<T>
    {
        private const int minVolume = 0;
        private const int maxVolume = 300;
        private int _volume;
        public bool Locked;
        public bool Playing;
        public event Action<string> PlayerStarted;
        public event Action<string> PlayerStopped;
        public event Action<string> PlayerLocked;
        public event Action<string> PlayerUnlocked;
        public event Action<string> PlayerVolumeChange;
        public GenericPlayer()
        {

        }
        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value < minVolume)
                {
                    _volume = minVolume;
                }
                if (value > maxVolume)
                {
                    _volume = maxVolume;
                }
                else
                {
                    _volume = value;
                }
            }
        }
        public void VolumeUp()
        {
            if (Locked)
                Console.WriteLine("Player is locked");
            else
            {
                Volume++;
                Console.WriteLine("Increase volume by one");
            }
        }
        public void VolumeDown()
        {
            if (Locked)
                Console.WriteLine("Player is locked");
            else
            {
                Volume--;
                Console.WriteLine("Decrease volume by one");
            }
        }
        public void VolumeChange(int step)
        {
            if (Locked)
                PlayerLocked?.Invoke("Player is locked");
            else
            {
                Volume += step;
                PlayerVolumeChange?.Invoke($"To change the volume on: {step}");
            }
        }
        public void Lock()
        {
            PlayerLocked?.Invoke("Player is locked");
            Locked = true;
           
        }
        public void Unlock()
        {
            Locked = false;
            PlayerUnlocked?.Invoke("Player is unlocked");
        }

        public bool Stop()
        {
            if (!Locked)
            {
                Playing = false;
                PlayerStopped?.Invoke("Player is stopped");
            }
            else
                Console.WriteLine("Player is locked");
            return Playing;
        }
        public bool Start(bool loop = false)
        {

            if (!Locked)
            {
                Playing = true;
                PlayerStarted?.Invoke("Player is started");
            }
            else
                Console.WriteLine("Player is locked");
            return Playing;
        }
        public abstract void Load(string path);

        public abstract void Clear();

    }
}
