using Xunit;

namespace SpeciVacation.Tests
{
    public sealed class SpecificationTests
    {
        [Fact]
        public void TEST_And_GIVEN_IdentitySpecification_EXPECT_ToReturnOther()
        {
            // Arrange
            var all = Specification<bool>.All;
            var isFalseSpec = new IsFalseSpecification();

            // Act
            // Assert
            Assert.Same(all.And(isFalseSpec), isFalseSpec);
            Assert.Same(isFalseSpec.And(all), isFalseSpec);
        }

        [Fact]
        public void TEST_And_GIVEN_NoneSpecification_EXPECT_ToNotSatisfy()
        {
            // Arrange
            var none = Specification<bool>.None;
            var isTrueSpec = new IsTrueSpecification();

            // Act
            // Assert
            Assert.False(none.And(isTrueSpec).IsSatisfiedBy(true));
            Assert.False(isTrueSpec.And(none).IsSatisfiedBy(true));
            Assert.False(none.And(isTrueSpec).IsSatisfiedBy(false));
            Assert.False(isTrueSpec.And(none).IsSatisfiedBy(false));
        }

        [Fact]
        public void TEST_And_GIVEN_TwoSpecifications_EXPECT_ToCombine()
        {
            // Arrange
            var isTrueSpec = new IsTrueSpecification();
            var isFalseSpec = new IsFalseSpecification();

            // Act
            var target = isTrueSpec.And(isFalseSpec);

            // Assert
            Assert.False(target.IsSatisfiedBy(true));
            Assert.False(target.ToExpression().Compile()(true));
        }

        [Fact]
        public void TEST_Or_GIVEN_IdentitySpecification_EXPECT_ToReturnIdentitySpecification()
        {
            // Arrange
            var all = Specification<bool>.All;
            var isFalseSpec = new IsFalseSpecification();

            // Act
            // Assert
            Assert.Same(all.Or(isFalseSpec), all);
            Assert.Same(isFalseSpec.Or(all), all);
        }

        [Fact]
        public void TEST_Or_GIVEN_NoneSpecification_EXPECT_IsSatisfiedByOther()
        {
            // Arrange
            var none = Specification<bool>.None;
            var isTrueSpec = new IsTrueSpecification();

            // Act
            // Assert
            Assert.Equal(none.Or(isTrueSpec).IsSatisfiedBy(true), isTrueSpec.IsSatisfiedBy(true));
            Assert.Equal(isTrueSpec.Or(none).IsSatisfiedBy(true), isTrueSpec.IsSatisfiedBy(true));
            Assert.Equal(none.Or(isTrueSpec).IsSatisfiedBy(false), isTrueSpec.IsSatisfiedBy(false));
            Assert.Equal(isTrueSpec.Or(none).IsSatisfiedBy(false), isTrueSpec.IsSatisfiedBy(false));
        }

        [Fact]
        public void TEST_Or_GIVEN_TwoSpecifications_EXPECT_ToCombine()
        {
            // Arrange
            var isTrueSpec = new IsTrueSpecification();
            var isFalseSpec = new IsFalseSpecification();

            // Act
            var target = isTrueSpec.Or(isFalseSpec);

            // Assert
            Assert.True(target.IsSatisfiedBy(true));
            Assert.True(target.ToExpression().Compile()(true));
        }

        [Fact]
        public void TEST_Not_GIVEN_Specification_EXPECT_ToReturnInversedSpecification()
        {
            // Arrange
            var isFalseSpec = new IsFalseSpecification();

            // Act
            var target = isFalseSpec.Not();

            // Assert
            Assert.True(target.IsSatisfiedBy(true));
            Assert.True(target.ToExpression().Compile()(true));
        }
    }
}
