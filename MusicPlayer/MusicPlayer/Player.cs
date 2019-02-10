using System;
using System.Collections.Generic;
using System.IO;
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
        public event Action<string> OnError;
        public event Action<string, string, ConsoleColor> OnWarning;
        
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
        //AL5-Player1/2. ExceptionHandling.
        //AL5-Player1/2. CustomExceptions.
        //LA8.Player1/2. AsyncPlaySong.
        public async Task PlayAsync()
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
                        try
                        {
                            if (File.Exists(Song[i].Path))                               
                                soundPlayer.SoundLocation = Song[i].Path;//текущий проигрываемый объект
                            else
                                throw new FailedToPlayException("Your file not found!", Song[i].Path);
                            if (soundPlayer.IsLoadCompleted)
                                soundPlayer.PlaySync();                            
                            else
                                throw new FailedToPlayException("File format not supported", Song[i].Path);
                            System.Threading.Thread.Sleep(2000);
                        }
                        //catch (FileNotFoundException ex)
                        //{
                        //    OnError?.Invoke(ex.Message);
                        //}
                        //catch (InvalidOperationException ex)
                        //{
                        //    OnError?.Invoke(ex.Message);
                        //}
                        catch (PlayerException ex)
                        {
                            var exNew = (FailedToPlayException)ex;
                            OnWarning?.Invoke(exNew.Message, exNew.Path,ConsoleColor.Yellow);
                        }
                        catch (Exception ex)
                        {
                            OnError?.Invoke(ex.Message);
                        }
                    }
                });
            }
            Playing = false;
        }
    }
}
