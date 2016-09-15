using System;
using System.Linq;
using System.Reflection;
using BringSharp.Extensions;

namespace BringSharp.Converters
{
    class AttributeConverter
    {
        public static string GetValue(Enum value)
        {
            var attribute = value.GetType()
            .GetRuntimeField(value.ToString())
            .GetCustomAttributes(typeof(ApiPropertyName), false)
            .SingleOrDefault() as ApiPropertyName;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
