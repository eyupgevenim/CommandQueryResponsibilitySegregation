using CommandQueryResponsibilitySegregation.Infrastructure.DependencyInjection;
using System;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Query
{
    public class QueryInvoker : IQueryInvoker
    {
        public TResult Query<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
            where TResult : IResult
        {
            if (query == null)
                throw new ArgumentNullException("query");

            var _queryHandler = ContextEngine<IQueryHandler<TQuery, TResult>>.Resolve;
            return _queryHandler.Query(query);
        }
    }
}
