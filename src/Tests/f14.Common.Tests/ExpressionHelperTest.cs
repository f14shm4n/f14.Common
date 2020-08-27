using f14.Common.Tests.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace f14.Common.Tests
{
    [TestFixture]
    public class ExpressionHelperTest
    {
        [Test]
        public void GetMemberExpression_Generic()
        {
            var me = ExpressionHelper.GetMemberExpression<ExpressionTestModel>(x => x.IntType);

            Assert.NotNull(me);
            Assert.AreEqual(nameof(ExpressionTestModel.IntType), me.Member.Name);
        }

        [Test]
        public void CreateSetter_IntType()
        {
            const int TestVal = 2;
            var model = new ExpressionTestModel { IntType = 1 };
            var setter = ExpressionHelper.CreateSetter<ExpressionTestModel, int>(x => x.IntType);

            setter(model, TestVal);

            Assert.AreEqual(TestVal, model.IntType);
        }

        [Test]
        public void CreateSetter_StringType()
        {
            const string TestVal = "No";
            var model = new ExpressionTestModel { StringType = "Yes" };
            var setter = ExpressionHelper.CreateSetter<ExpressionTestModel, string>(x => x.StringType);

            setter(model, TestVal);

            Assert.AreEqual(TestVal, model.StringType);
        }

        [Test]
        public void CreateSetter_ListType()
        {
            List<int> TestVal = new List<int>();
            var model = new ExpressionTestModel
            {
                ListOfInt = new List<int> { 1, 2, 3 }
            };
            var setter = ExpressionHelper.CreateSetter<ExpressionTestModel, List<int>>(x => x.ListOfInt);

            setter(model, TestVal);

            Assert.AreEqual(TestVal, model.ListOfInt);
        }
    }
}
