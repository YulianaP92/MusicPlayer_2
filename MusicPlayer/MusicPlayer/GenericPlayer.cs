using System;
using System.Collections.Generic;
using System.Linq;
using MusicPlayer.Visualization;
using System.Threading.Tasks;

namespace MusicPlayer
{
   abstract class GenericPlayer<T>where T:Song
    {
        private const int minVolume = 0;
        private const int maxVolume = 300;
        private int _volume;
        public bool Locked;
        public bool Playing;
        private ISkin skin;
        public GenericPlayer()
        {

        }
        public GenericPlayer(ISkin skin)
        {
            this.skin = skin;
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
                Console.WriteLine("Player is locked");
            else
            {
                Volume += step;
                Console.WriteLine($"To change the volume on: {step}");
            }
        }
        public void Lock()
        {
            Locked = true;
            Console.WriteLine("Player is locked");
        }
        public void Unlock()
        {
            Locked = false;
            Console.WriteLine("Player is unlocked");
        }

        public bool Stop()
        {
            if (!Locked)
            {
                Playing = false;
                Console.WriteLine("Player is stopped");
            }
            else
                Console.WriteLine("Player is locked");
            return Playing;
        }
        public bool Start(List<T> items, bool loop = false)
        {

            if (!Locked)
            {
                Playing = true;
                Console.WriteLine("Player is playing");               
            }
            else
                Console.WriteLine("Player is locked");
            return Playing;
        }
        public abstract List<T> GetItems();            
        public List<T> SortByTitle(List<T> item)
        {
            List<string> name = new List<string>();
            foreach (var i in item)
            {
                name.Add(i.Name);
            }
            name.Sort();
            List<T> newList = new List<T>();
            for (int i = 0; i < name.Count; i++)
            {
                if (name[i] == item[i].Name)
                {
                    newList.Add(item[i]);
                }
            }
            var sortedName = newList.OrderBy(u => u.Name).ToList();
            return sortedName;
        }

        public virtual void IncludeItem(T item)
        {
            if (Playing)
            {
                item.PlayItem = true;
                Console.WriteLine($"The item is played: {item.Name}");
            }
        }
        public (string name, (int hours, int minutes, int seconds), bool play) GetItemData(T item)
        {
            return (
                item.Name,
                (item.Duration / 3600,
                (item.Duration % 3600) / 60,
                (item.Duration % 3600) % 60
                ),
                item.PlayItem);
        }

        public void ListItems(List<T> items, T includeItem)
        {
            IncludeItem(includeItem);
            for (int i = 0; i < items.Count; i++)
            {
                var item = GetItemData(items[i]);
                Console.WriteLine($"{item.name}-{item.play} - {item.Item2.hours}:{item.Item2.minutes}:{item.Item2.seconds}");
            }
        }
        public void GetSongData_2(T item)
        {
            (string name, _, int durationMinutes, _) = item;
            Console.WriteLine($"{name} - {durationMinutes}");
        }

        public static ISkin GetSkin()
        {
            Console.WriteLine("How do you want to display the list of songs?:" +
              "\n1-Displays text line by line in standard mode" +
              "\n2-Displays text line by line in the color you specify" +
              "\n3-Random text color output" +
              "\n4-Caps Lock text");
            var variant = Console.ReadLine();
            switch (variant)
            {
                case "1":
                    return new ClassicSkin();
                case "2":
                    return new ColorSkin(ConsoleColor.Green);
                case "3":
                    return new ColorSkin_2();
                case "4":
                    return new СapslockSkin();
                default:
                    return new ClassicSkin();
            }
        }
        public void TraceInfo(List<T> Item)
        {
            skin.Clear();
            foreach (var i in Item)
            {
                skin.Render(SkinString(i));
            }
        }
        public abstract string SkinString(T item);
        public abstract List<T> FilterByGenre(List<T> items, string genry);
  
    }
}
