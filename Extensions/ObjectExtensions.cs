namespace Infirmary.Extensions
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, string> ToDictionary(this object obj)
        {
            if (obj == null)
                return new Dictionary<string, string>();

            var dict = new Dictionary<string, string>();

            var props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                var value = prop.GetValue(obj);
                dict[prop.Name] = value?.ToString() ?? "";
            }

            return dict;
        }
    }

}
