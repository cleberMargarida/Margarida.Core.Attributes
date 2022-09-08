using System;
using System.Linq;

namespace Margarida.Core.Attributes.Description
{
    public static class DescriptionAttributeExtensions
    {
        public static string GetDescription<T>(this T value)
            where T : struct, IConvertible
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);

            var attribute = enumType
                    .GetField(name)?
                    .GetCustomAttributes(false)
                    .OfType<DescriptionAttribute>()
                    .SingleOrDefault();

            if (attribute is null)
            {
                throw new Exception($"The member of {typeof(T).Name} has not marked with \'Description\' attribute.");
            }

            return attribute.Description;
        }
    }
}
