namespace CommandQueryResponsibilitySegregation.Infrastructure.Query
{
    public interface IQueryHandler<TQuery, TResult> 
        where TQuery : IQuery 
        where TResult : IResult
    {
        TResult Query(TQuery query);
    }
}
