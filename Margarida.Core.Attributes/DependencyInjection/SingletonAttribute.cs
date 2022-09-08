using System;

namespace Margarida.Core.Attributes.DependencyInjection
{
    /// <summary>
    /// When AddMarkedByAttributes is used, the class marked with it will be added to the dependency injection service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : LifecicleAttribute
    {
        public SingletonAttribute() : base(null)
        {
        }

        public SingletonAttribute(Type @interface) : base(@interface)
        {
        }
    }
}
