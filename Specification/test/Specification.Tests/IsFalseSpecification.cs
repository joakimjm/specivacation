using System;
using System.Linq.Expressions;

namespace Specification.Tests
{
    public sealed class IsFalseSpecification : Specification<bool>
    {
        public override Expression<Func<bool, bool>> ToExpression()
        {
            return x => x == false;
        }
    }
}
