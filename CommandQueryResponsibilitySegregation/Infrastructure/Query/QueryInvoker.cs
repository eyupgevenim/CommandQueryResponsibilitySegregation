using System;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Query
{
    public class QueryInvoker : IQueryInvoker
    {
        private readonly IQueryHandler<IQuery, IResult> _queryHandler;

        public QueryInvoker(IQueryHandler<IQuery, IResult> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        public IResult Query(IQuery query) 
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return _queryHandler.Query(query);
        }
    }
}
