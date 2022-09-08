using System;
using System.Collections.Generic;
using System.Text;

namespace Margarida.Core.Attributes.DependencyInjection
{
    public class LifecicleAttribute : Attribute
    {
        public LifecicleAttribute(Type @interface)
        {
            Interface = @interface;
        }

        public Type Interface { get; set; }
    }
}
