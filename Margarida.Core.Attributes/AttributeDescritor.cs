using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Margarida.Core.Attributes
{
    public static class AttributeDescritor
    {
        internal static IEnumerable<Type> GetTypesDescribedBy<T>(Assembly assembly)
            where T : Attribute
        {
                foreach (var type in assembly.GetTypes())
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                        yield return type;
        }
    }
}
