using System;
using System.Linq.Expressions;
using LinqKit;

namespace SpeciVacation
{
    internal sealed class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return _left.ToExpression().Or(_right.ToExpression());
        }
    }
}