using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;


namespace EasyNutrition.API.Extensions
{
    public static class EnumExtentions
    {
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[])info
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}
