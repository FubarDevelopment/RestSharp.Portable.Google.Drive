namespace RestSharp.Portable.Google.Drive
{
    internal static class StringExtensions
    {
        public static string Escape(this string s)
        {
            return s?.Replace("\\", "\\\\").Replace("'", "\\'");
        }
    }
}
