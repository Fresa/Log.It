﻿using System;
using System.Linq;
using System.Reflection;

namespace Log.It
{
    public static class TypeExtensions
    {
        public static string GetPrettyName(this Type type)
        {
            var name = type?.FullName;

            if (name == null)
            {
                return string.Empty;
            }

            if (type.GetTypeInfo().IsGenericType == false)
            {
                return name;
            }
            
            name = name.Substring(0, name.IndexOf('`'));
            name += $"<{type.GenericTypeArguments.Select(GetPrettyName).Join(", ")}>";

            return name;
        }
    }
}