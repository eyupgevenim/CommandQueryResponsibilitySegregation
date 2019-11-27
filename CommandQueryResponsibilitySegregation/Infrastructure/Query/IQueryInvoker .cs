namespace CommandQueryResponsibilitySegregation.Infrastructure.Query
{
    public interface IQueryInvoker
    {
        TResult Query<TQuery, TResult>(TQuery query) 
            where TQuery : IQuery
            where TResult : IResult;
    }
}
