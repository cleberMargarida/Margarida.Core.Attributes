using FluentAssertions;
using Margarida.Core.Attributes.Description;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Margarida.Core.Attributes.Tests
{
    [TestClass]
    public class DescriptionAttributeTests
    {
        enum some
        {
            [Description.Description("val1")]
            val1 = 1,
            [Description.Description("val2")]
            val2 = 2
        }

        [TestMethod]
        public void EnumMarkedWithDescriptionAttribute_ShouldReturnDescription()
        {
            some.val1.GetDescription().Should().Be("val1");
            some.val2.GetDescription().Should().Be("val2");
        }
    }
}
