using System;
using System.Linq.Expressions;

namespace SpeciVacation
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        Expression<Func<T, bool>> ToExpression();
    }
}
