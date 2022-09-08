using FluentAssertions;
using Margarida.Core.Attributes.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Margarida.Core.Attributes.Tests
{
    [TestClass]
    public class DependencyInjectorAttributesTests
    {
        [Scoped]
        class ScopeTest { }

        [Transient]
        class TransientTest { }

        [Singleton]
        class SingletonTest { }

        interface Interface
        {
        }

        [Transient(typeof(Interface))]
        class InterfaceImpl
        {
        }

        [TestMethod]
        public void AttributesDescribedByScoped_ShouldBeAdded()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMarkedByAttributes(x => x.RegisterFromAssembly(GetType().Assembly));
            services.Should().Contain(x => x.ServiceType == typeof(ScopeTest));
            services.Should().Contain(x => x.Lifetime == ServiceLifetime.Scoped);
        }

        [TestMethod]
        public void AttributesDescribedBySingleton_ShouldBeAdded()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMarkedByAttributes(x => x.RegisterFromAssembly(GetType().Assembly));
            services.Should().Contain(x => x.ServiceType == typeof(TransientTest));
            services.Should().Contain(x => x.Lifetime == ServiceLifetime.Transient);
        }

        [TestMethod]
        public void AttributesDescribedByTransient_ShouldBeAdded()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMarkedByAttributes(x => x.RegisterFromAssembly(GetType().Assembly));
            services.Should().Contain(x => x.ServiceType == typeof(SingletonTest));
            services.Should().Contain(x => x.Lifetime == ServiceLifetime.Singleton);
        }

        [TestMethod]
        public void AttributesDescribedByTransientUsingInterface_ShouldBeAdded()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMarkedByAttributes(x => x.RegisterFromAssembly(GetType().Assembly));
            services.Should().Contain(x => x.ServiceType == typeof(Interface));
            services.Should().Contain(x => x.ImplementationType == typeof(InterfaceImpl));
            services.Should().Contain(x => x.Lifetime == ServiceLifetime.Transient);
        }
    }
}
