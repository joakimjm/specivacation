using System;
using System.Linq.Expressions;

namespace SpeciVacation.Tests
{
    public sealed class IsTrueSpecification : Specification<bool>
    {
        public override Expression<Func<bool, bool>> ToExpression()
        {
            return x => x;
        }
    }
}
