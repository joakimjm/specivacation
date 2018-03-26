using System;
using System.Linq.Expressions;
using LinqKit;

namespace Specification
{
    internal sealed class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return _left.ToExpression().And(_right.ToExpression());
        }
    }
}