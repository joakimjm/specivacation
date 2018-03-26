using Xunit;

namespace Specification.Tests
{
    public sealed class IsTrueSpecificationTests
    {
        [Fact]
        public void TEST_IsSatisfiedBy_GIVEN_True_EXPECT_True()
        {
            // Arrange
            var target = new IsTrueSpecification();

            // Act
            var result = target.IsSatisfiedBy(true);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TEST_IsSatisfiedBy_GIVEN_False_EXPECT_False()
        {
            // Arrange
            var target = new IsTrueSpecification();

            // Act
            var result = target.IsSatisfiedBy(false);

            // Assert
            Assert.False(result);
        }
    }
}
