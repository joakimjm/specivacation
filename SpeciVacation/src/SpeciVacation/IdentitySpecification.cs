using System;
using System.Linq.Expressions;

namespace SpeciVacation
{
    internal struct IdentitySpecification<T> : ISpecification<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            return true;
        }

        public Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
