namespace MusicPlayer.Extensions
{
    public static class StringSubstring
    {
        public static string Substring_2(this string newString)
        {
            newString = newString.Substring(0, newString.Length - 2);

            return $"{newString}...";
        }
    }
}
