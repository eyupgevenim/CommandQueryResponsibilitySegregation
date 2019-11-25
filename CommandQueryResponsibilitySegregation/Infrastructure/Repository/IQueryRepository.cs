using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Repository
{
    public interface IQueryRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
    }
}
