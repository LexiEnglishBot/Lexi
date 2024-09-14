namespace Core.Helpers;

public static class StringExtensions
{
    public static bool Equals(this string str, IEnumerable<string> items, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
        return items.Any(item => str.Equals(item, stringComparison));
    }
}