using Xunit;

namespace Specification.Tests
{
    public sealed class IsFalseSpecificationTests
    {
        [Fact]
        public void TEST_IsSatisfiedBy_GIVEN_True_EXPECT_False()
        {
            // Arrange
            var target = new IsFalseSpecification();

            // Act
            var result = target.IsSatisfiedBy(true);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TEST_IsSatisfiedBy_GIVEN_False_EXPECT_True()
        {
            // Arrange
            var target = new IsFalseSpecification();

            // Act
            var result = target.IsSatisfiedBy(false);

            // Assert
            Assert.True(result);
        }
    }
}
