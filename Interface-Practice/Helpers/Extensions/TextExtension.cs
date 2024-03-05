namespace Interface_Practice.Helpers.Extensions
{
    public static class TextExtension
    {
        public static bool ContainsIgnoreCase(this string str1, string str2)
        {
            return str1.Trim().ToLower().Contains(str2.Trim().ToLower());
        }
    }
}
