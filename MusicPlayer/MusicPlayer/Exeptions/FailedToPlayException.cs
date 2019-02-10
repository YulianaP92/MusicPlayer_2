namespace MusicPlayer
{
    class FailedToPlayException:PlayerException
    {
        public string Path { get; set; }
        public FailedToPlayException(string message,string path):base(message)
        {
            Path = path;
        }
        
    }
}
