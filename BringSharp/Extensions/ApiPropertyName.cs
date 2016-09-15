using System;

namespace BringSharp.Extensions
{
    [AttributeUsage(AttributeTargets.Field)]
    class ApiPropertyName : Attribute
    {
        public string Description { get; }

        public ApiPropertyName(string description)
        {
            Description = description;
        }
    }
}
