﻿using System;
using System.Linq.Expressions;

using Xunit;

namespace SpeciVacation.Tests
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void TEST_ToAndSpecification_GIVEN_SpecificationOfStartsWithAndContains_EXPECT_BeSatisfyedWhenBothConditionMet()
        {
            var andSpec = new Specification<string>[] { new StartsWithSpecification("test"), new ContainsSpecification("2") }.ToAndSpecification();
            
            Assert.False(andSpec.IsSatisfiedBy("test"));
            Assert.False(andSpec.IsSatisfiedBy("2"));
            Assert.False(andSpec.IsSatisfiedBy("none"));
            Assert.True(andSpec.IsSatisfiedBy("test2"));
        }

        [Fact]
        public void TEST_ToOrSpecification_GIVEN_SpecificationOfStartAndContains_EXPECT_BeSafisfyedWhenAnyConditionMet()
        {
            var orSpec = new Specification<string>[] { new StartsWithSpecification("test"), new ContainsSpecification("2") }.ToOrSpecification();

            Assert.True(orSpec.IsSatisfiedBy("test"));
            Assert.True(orSpec.IsSatisfiedBy("2"));
            Assert.False(orSpec.IsSatisfiedBy("none"));
            Assert.True(orSpec.IsSatisfiedBy("test2"));
        }

        [Fact]
        public void TEST_ToOrSpecificationFromEnumerable_GIVEN_SpecificationOfContains_EXPECT_BeSatisfyedWhenAnyConditionMet()
        {
            var orSpec = new [] {"test", "2"}.ToOrSpecification(s => new ContainsSpecification(s));

            Assert.True(orSpec.IsSatisfiedBy("test"));
            Assert.True(orSpec.IsSatisfiedBy("2"));
            Assert.False(orSpec.IsSatisfiedBy("none"));
            Assert.True(orSpec.IsSatisfiedBy("test2"));
        }
        
        [Fact]
        public void TEST_ToAndSpecificationFromEnumerable_GIVEN_SpecificationOfStartsWithAndContains_EXPECT_BeSatisfyedWhenBothConditionMet()
        {
            var andSpec =new [] {"test", "2"}.ToAndSpecification(s => new ContainsSpecification(s));
            
            Assert.False(andSpec.IsSatisfiedBy("test"));
            Assert.False(andSpec.IsSatisfiedBy("2"));
            Assert.False(andSpec.IsSatisfiedBy("none"));
            Assert.True(andSpec.IsSatisfiedBy("test2"));
        }

        public class StartsWithSpecification : Specification<string>
        {
            private readonly string _start;

            public StartsWithSpecification(string start)
            {
                _start = start;
            }

            public override Expression<Func<string, bool>> ToExpression()
            {
                return s => s.StartsWith(_start);
            }
        }

        public class ContainsSpecification : Specification<string>
        {
            private readonly string _part;

            public ContainsSpecification(string part)
            {
                _part = part;
            }

            public override Expression<Func<string, bool>> ToExpression()
            {
                return s => s.Contains(_part);
            }
        }
    }
}
