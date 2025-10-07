using f14.Common.Tests.Models;
using FluentAssertions;

namespace f14.Common.Tests
{
    public class ExpressionHelperTest
    {
        [Fact]
        public void GetMemberExpression_Generic()
        {
            var me = ExpressionHelper.GetMemberExpression<ExpressionTestModel>(x => x.IntType);
            me.Should().NotBeNull();
            me.Member.Name.Should().Be(nameof(ExpressionTestModel.IntType));
        }

        [Fact]
        public void CreateSetter_IntType()
        {
            const int TestVal = 2;
            var model = new ExpressionTestModel { IntType = 1 };
            var setter = ExpressionHelper.CreateSetter<ExpressionTestModel, int>(x => x.IntType);
            setter.Should().NotBeNull();
            setter(model, TestVal);
            model.IntType.Should().Be(TestVal);
        }

        [Fact]
        public void CreateSetter_StringType()
        {
            const string TestVal = "No";
            var model = new ExpressionTestModel { StringType = "Yes" };
            var setter = ExpressionHelper.CreateSetter<ExpressionTestModel, string>(x => x.StringType);
            setter.Should().NotBeNull();
            setter(model, TestVal);

            model.StringType.Should().Be(TestVal);
        }

        [Fact]
        public void CreateSetter_ListType()
        {
            List<int> TestVal = [];
            var model = new ExpressionTestModel
            {
                ListOfInt = [1, 2, 3]
            };
            var setter = ExpressionHelper.CreateSetter<ExpressionTestModel, List<int>>(x => x.ListOfInt);
            setter.Should().NotBeNull();
            setter(model, TestVal);
            model.ListOfInt.Should().BeEquivalentTo(TestVal);
        }
    }
}
