using System;

namespace Margarida.Core.Attributes.DependencyInjection
{
    /// <summary>
    /// When AddMarkedByAttributes is used, the class marked with it will be added to the dependency injection service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ScopedAttribute : LifecicleAttribute
    {
        public ScopedAttribute() : base(null)
        {
        }

        public ScopedAttribute(Type @interface) : base(@interface)
        {
        }
    }
}
