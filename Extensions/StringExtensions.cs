namespace Infirmary.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string value)
        {
            return Convert.ToInt32(value?.ToString());
        }
    }
}
