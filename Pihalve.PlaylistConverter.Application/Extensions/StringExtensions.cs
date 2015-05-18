using System.Globalization;

namespace Pihalve.PlaylistConverter.Application.Extensions
{
    public static class StringExtensions
    {
        public static string Remove(this string source, string valueToRemove, CompareOptions options)
        {
            int idx = CultureInfo.CurrentCulture.CompareInfo.IndexOf(source, valueToRemove, options);
            if (idx > -1)
            {
                return source.Remove(idx, valueToRemove.Length);
            }
            return source;
        }
    }
}
