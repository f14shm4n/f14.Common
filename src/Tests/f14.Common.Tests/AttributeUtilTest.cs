using f14.Common.Tests.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace f14.Common.Tests
{
    [TestFixture]
    public class AttributeUtilTest
    {        
        [Test]
        public void GetAttributesFromEnumValue()
        {
            var displayAttrs = AttributeUtil.GetAttributesFromEnumValue<DisplayAttribute, FancyEnum>(FancyEnum.Sample_0);

            Assert.AreEqual("Sample_0", displayAttrs[0].Name);
        }

        [Test]
        public void GetAttributes_Expression()
        {
            var atts = AttributeUtil.GetAttributes<DisplayAttribute, ExpressionTestModel>(x => x.IntType, false);

            Assert.AreEqual("IntType", atts.First().Name);

            var atts2 = AttributeUtil.GetAttributes<RequiredAttribute, ExpressionTestModel>(x => x.StringType, false);

            Assert.IsNotEmpty(atts2);
        }
    }
}
