using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Description = Margarida.Core.Attributes.DescriptionAttribute;

namespace Margarida.Core.Attributes.Tests
{
    [TestClass]
    public class DescriptionAttributeTests
    {
        enum some
        {
            [@Description("val1")]
            val1 = 1,
            [@Description("val2")]
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
