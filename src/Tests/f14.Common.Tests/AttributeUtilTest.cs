using f14.Common.Tests.Models;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace f14.Common.Tests
{
    public class AttributeUtilTest
    {
        [Fact]
        public void GetAttributesFromEnumValue()
        {
            var displayAttrs = AttributeUtil.GetAttributesFromEnumValue<DisplayAttribute, FancyEnum>(FancyEnum.Sample_0);
            displayAttrs[0].Name.Should().Be("Sample_0");
        }

        [Fact]
        public void GetAttributes_Expression()
        {
            var atts = AttributeUtil.GetAttributes<DisplayAttribute, ExpressionTestModel>(x => x.IntType, false);
            atts.First().Name.Should().Be("IntType");

            var atts2 = AttributeUtil.GetAttributes<RequiredAttribute, ExpressionTestModel>(x => x.StringType, false);
            atts2.Should().NotBeEmpty();
        }
    }
}
