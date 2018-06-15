using System;
using System.Linq;

namespace Log.It
{
    public static class TypeExtensions
    {
        public static string GetPrettyName(this Type type)
        {
            var name = type.FullName;

            if (name == null)
            {
                return string.Empty;
            }

            if (type.IsGenericType == false)
            {
                return name;
            }
            
            name = name.Substring(0, name.IndexOf('`'));
            name += $"<{type.GetGenericArguments().Select(GetPrettyName).Join(", ")}>";

            return name;
        }
    }
}