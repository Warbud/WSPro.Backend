#nullable enable
namespace WSPro.Backend.Utils
{
    public static class Parser
    {
        public static string? NullParser(string? value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)
                ? null
                : value;
        }
    }
}