using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Margarida.Core.Attributes.DependencyInjection
{
    delegate IServiceCollection AddForType(IServiceCollection services, Type type);
    delegate IServiceCollection AddForInterface(IServiceCollection services, Type @interface, Type type);

    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Add to services collection all services that was Marked with Singleton, Scoped and Transient Attributes.
        /// </summary>
        /// <param name="services">service collection.</param>
        /// <param name="action">The action to specify an assembly.</param>
        /// <returns>service collection.</returns>
        public static IServiceCollection AddMarkedByAttributes(this IServiceCollection services,
                                                               Action<AssemblySelectorBuilder> action)
        {
            var assemblySelectorBuilder = new AssemblySelectorBuilder();
            action(assemblySelectorBuilder);
            var assemblies = assemblySelectorBuilder.Build();

            Add<ScopedAttribute>(services,
                                 assemblies,
                                 ServiceCollectionServiceExtensions.AddScoped,
                                 ServiceCollectionServiceExtensions.AddScoped);

            Add<TransientAttribute>(services,
                                    assemblies,
                                    ServiceCollectionServiceExtensions.AddTransient,
                                    ServiceCollectionServiceExtensions.AddTransient);

            Add<SingletonAttribute>(services,
                                    assemblies,
                                    ServiceCollectionServiceExtensions.AddSingleton,
                                    ServiceCollectionServiceExtensions.AddSingleton);

            return services;
        }

        private static void Add<T>(IServiceCollection services,
                                   List<Assembly> assemblies,
                                   AddForInterface addForInterface,
                                   AddForType addForType)
            where T : LifecicleAttribute
        {
            foreach (var assembly in assemblies)
            {
                foreach (var type in AttributeDescritor.GetTypesDescribedBy<T>(assembly))
                {
                    var @interface = type.GetCustomAttribute<T>().Interface;

                    if (@interface is null)
                    {
                        addForType(services, type);
                    }
                    else
                    {
                        addForInterface(services, @interface, type);
                    }
                }
            }
        }
    }
}
