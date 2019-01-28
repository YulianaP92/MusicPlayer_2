using System;
using System.Collections.Generic;
using System.Linq;
using MusicPlayer.Extensions;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace MusicPlayer
{
   public class Player : GenericPlayer<Song>
    {

        public List<Song> Song;
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
        public override List<Song> FilterByGenre(List<Song> songs, string genry)
        {
            var sortedName = songs.Where(u => u.Artist._Genre == genry).OrderBy(u => u.Name).ToList();
            return sortedName;
        }
        //AL6-Player1/2-AudioFiles.
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
                var files = directory.GetFiles("*.mp3");
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
                        Console.WriteLine($"Name song: {song.Name}\nDuration: {song.Duration}");                       
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
        //AL6-Player2/2-PlaylistSrlz
        public void SaveAsPlaylist(string path)
        {           
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Song);
                Console.WriteLine("Serialization was successful");
            }
        }
        public void LoadPlaylist(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Song = (List<Song>)formatter.Deserialize(fs);
                foreach (var i in Song)
                {
                    Console.WriteLine($"Name: {i.Name}\nDutation: {i.Duration}\nPlayItem: {i.PlayItem}\nLike{i._like}");
                }
            }
        }
    }
}
