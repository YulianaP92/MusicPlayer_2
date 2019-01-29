using System;
using System.Collections.Generic;
using System.Linq;
using MusicPlayer.Extensions;
using System.IO;
using System.Xml.Serialization;
using System.Media;

namespace MusicPlayer
{
    public class Player : GenericPlayer<Song>, IDisposable
    {
        public List<Song> Song;
        private SoundPlayer soundPlayer;
        private FileStream fs;
        public override string SkinString(Song song)
        {
            string list;
            list = $"Name Artist: {song.Artist.Name}\n" +
            $"Name song: {song.Name}\n" +
            $"Genre: {song.Artist._Genre}\n" +
            $"Album: {song.Album.Name}\n" +
            $"Year of album release: {song.Album.Year}\n" +
            $"Duration song: {song.Duration} second\n" +
            $"Lyrics: {song.Lyrics}\n\n";
            return list;
        }

        public void Shuffle()
        {
            Song.Shuffle();
        }

        public void Sort()
        {
            Song.Sort();
        }
        public override List<Song> FilterByGenre(string genry)
        {
            var sortedName = Song.Where(u => u.Artist._Genre == genry).OrderBy(u => u.Name).ToList();
            return sortedName;
        }
        public override void Clear()
        {
            Song.Clear();
            Console.WriteLine("\nList cleared");
        }
        public override void Load(string path)
        {
            Song = new List<Song>();
            DirectoryInfo directory = new DirectoryInfo(path);
            if (directory.Exists)
            {
                var files = directory.GetFiles("*.wav");
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Exists)
                    {
                        var song = new Song()
                        {
                            Duration = (int)files[i].Length,
                            Name = files[i].Name,
                        };
                        Song.Add(song);
                        Console.Clear();
                        Console.WriteLine(song.Name);
                        soundPlayer = new SoundPlayer();
                        soundPlayer.SoundLocation = files[i].FullName;//текущий проигрываемый объект
                        soundPlayer.PlaySync();
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                        Console.WriteLine("No files exist");
                }
            }
            else
            {
                Console.WriteLine("No folders exist");
            }
        }
        public void SaveAsPlaylist(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));
            fs = new FileStream(path, FileMode.OpenOrCreate);
            formatter.Serialize(fs, Song);
            Console.WriteLine("Serialization was successful");
        }
        public void LoadPlaylist(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));
            fs = new FileStream(path, FileMode.OpenOrCreate);
            Song = (List<Song>)formatter.Deserialize(fs);
            foreach (var i in Song)
            {
                Console.WriteLine($"Name: {i.Name}\nDutation: {i.Duration}\nPlayItem: {i.PlayItem}\nLike{i._like}");
            }
        }

        //AL4-Player1/1. IDisposable.
        private bool _disposed = false;//флаг, вызывался ли объектом метод Dispose()
        public void Dispose()
        {
            Dispose(true);//вызов виртуального метода
            GC.SuppressFinalize(this);//сообщаем сборщику мусора, что наш объект уже освободил ресурсы
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // освобождаем управляемые ресурсы 
                    Song = null;
                    if (fs != null)
                    {
                        fs.Dispose();
                        fs = null;
                    }
                    if (soundPlayer != null)
                    {
                        soundPlayer.Dispose();
                        soundPlayer = null;
                    }
                }
                // освобождаем НЕУПРАВЛЯЕМЫЕ ресурсы 
            }
            _disposed = true;
        }
        ~Player()
        {
            Dispose(false);//false указывает,что очистка была инициирована сборщиком мусора
        }
    }
}
