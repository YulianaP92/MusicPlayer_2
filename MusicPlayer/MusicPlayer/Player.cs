using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Media;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Player : GenericPlayer<Song>
    {
        public List<Song> Song;
        private SoundPlayer soundPlayer;
        public event Action<List<Song>, Song, bool, int> SongStartedEvent;
        public event Action<List<Song>, Song, bool, int> SongsListChangedEvent;


        public void Sort()
        {
            Song.Sort();
        }
        public override void Clear()
        {
            Song.Clear();
            Console.WriteLine("\nList cleared");
        }
        public static bool flag;
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
                            Name = files[i].Name,
                            Path = files[i].FullName,
                        };
                        Song.Add(song);                       
                    }
                    else
                        Console.WriteLine("No files exist");
                }              
            }
            else
            {
                Console.WriteLine("No folders exist");
            }
            SongsListChangedEvent?.Invoke(Song, null, Locked, Volume);
            flag = true;
        }
        //LA8.Player1/2. AsyncPlaySong.
        public async void Play()
        {
            if (!Locked && Song.Count > 0)
            {
                Playing = true;
            }
            if (Playing)
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < Song.Count; i++)
                    {
                        soundPlayer = new SoundPlayer();
                        SongStartedEvent?.Invoke(Song, Song[i], Locked, Volume);
                        soundPlayer.SoundLocation = Song[i].Path;//текущий проигрываемый объект
                        soundPlayer.PlaySync();
                        System.Threading.Thread.Sleep(2000);
                    }
            });
        }
            Playing = false;
        }
    }
}
