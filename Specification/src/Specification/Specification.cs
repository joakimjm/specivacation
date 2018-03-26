using System;
using System.Linq.Expressions;

namespace Specification
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();
        private Func<T, bool> _predicate;

        public bool IsSatisfiedBy(T entity)
        {
            _predicate = _predicate ?? ToExpression().Compile();
            return _predicate(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
