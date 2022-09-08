using System;
using System.Collections.Generic;
using System.Reflection;

namespace Margarida.Core.Attributes.DependencyInjection
{
    public class AssemblySelectorBuilder
    {
        private List<Assembly> _assemblies = new List<Assembly>();

        /// <summary>
        /// Register an assembly.
        /// </summary>
        /// <param name="assembly">The instance of Assembly.</param>
        /// <returns>AssemblySelectorBuilder instance.</returns>
        public AssemblySelectorBuilder RegisterFromAssembly(Assembly assembly)
        {
            _assemblies.Add(assembly);
            return this;
        }

        /// <summary>
        /// Register an assembly from type.
        /// </summary>
        /// <param name="type">The type that containing an assembly.</param>
        /// <returns>AssemblySelectorBuilder instance.</returns>
        public AssemblySelectorBuilder AssemblyContaining(Type type)
        {
            _assemblies.Add(type.Assembly);
            return this;
        }

        /// <summary>
        /// Register an assembly from type.
        /// </summary>
        /// <typeparam name="T">The type that containing an assembly.</typeparam>
        /// <returns>AssemblySelectorBuilder instance.</returns>
        public AssemblySelectorBuilder AssemblyContaining<T>()
        {
            _assemblies.Add(typeof(T).Assembly);
            return this;
        }

        internal List<Assembly> Build()
        {
            return _assemblies;
        }
    }
}
